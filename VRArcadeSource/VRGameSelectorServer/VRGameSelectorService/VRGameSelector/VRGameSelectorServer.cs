using NetworkCommsDotNet;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Timers;
using VRGameSelectorDTO;
using VRGameSelectorServerDB;

namespace VRArcadeServer
{
    public partial class VRGameSelectorServer
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        static readonly VRGameSelectorServer instance = new VRGameSelectorServer();
        ServiceHost _webServiceHostDashboardModule;
        private List<ConnectionInfo> _targetClientDaemonConnection;
        private List<ConnectionInfo> _targetManagingSystemConnection;
        private List<InternalClientStatus> _internalClientStatus;
        System.Timers.Timer _timer1s;
        System.Timers.Timer _timer1m;
        System.Timers.Timer _timerRandomStartDelay;
        System.Timers.Timer _timer24h;
        Random _rand = new Random();

        private bool isManageSystemPushRequired;

        readonly object _lockUpdateInternalClientStatus = new object();

        static VRGameSelectorServer()
        {

        }

        public static VRGameSelectorServer Instance
        {
            get
            {
                return instance;
            }
        }

        public VRGameSelectorServer()
        {
            BookingReferenceClientApi.OnBookingReferenceResult += BookingReferenceClientApi_OnBookingReferenceResult;

            Utility.InitCoreConfig(AppDomain.CurrentDomain.BaseDirectory);

            InitWCFService();

            InitNetworkComms();

            BuildInternalClientStatus();

            _timer1s = new System.Timers.Timer();
            _timer1s.Elapsed += new ElapsedEventHandler(OnTimer1sEvent);
            _timer1s.Interval = 1000;
            _timer1s.Enabled = true;

            _timer1m = new System.Timers.Timer();
            _timer1m.Elapsed += new ElapsedEventHandler(OnTimer1mEvent);
            _timer1m.Interval = 10000; //60000;
            _timer1m.Enabled = true;
            OnTimer1mEvent(null, null);

            _timerRandomStartDelay = new System.Timers.Timer();
            _timerRandomStartDelay.Elapsed += _timerRandomStartDelay_Elapsed;
            _timerRandomStartDelay.Interval = _rand.Next(10000, 60000);
            _timerRandomStartDelay.Enabled = true;
            _timerRandomStartDelay.AutoReset = false;

            _timer24h = new System.Timers.Timer();
            _timer24h.Elapsed += _timer24h_Elapsed;
            _timer24h.Interval = 86400000;
            _timer24h.Enabled = false;
        }



        ~VRGameSelectorServer()
        {
            BookingReferenceClientApi.OnBookingReferenceResult -= BookingReferenceClientApi_OnBookingReferenceResult;
            NetworkComms.Shutdown();
            _webServiceHostDashboardModule.Close();
        }

        private void OnTimer1sEvent(object sender, ElapsedEventArgs e)
        {
            if (isManageSystemPushRequired)
            {
                PushManagingSystemInfo();
                isManageSystemPushRequired = false;
            }
            ProcessInternalClientStatus();
        }

        private void OnTimer1mEvent(object sender, ElapsedEventArgs e)
        {
            //UpdateLocalBookingReference();
        }

        private void _timer24h_Elapsed(object sender, ElapsedEventArgs e)
        {
            Utility.SyncClock();
        }

        private void _timerRandomStartDelay_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timerRandomStartDelay.Enabled = false;
            _timer24h.Enabled = true;

            Utility.SyncClock();
        }


        private void PushManagingSystemInfo()
        {
            foreach (ConnectionInfo connectionInfo in _targetManagingSystemConnection)
            {
                SendLiveSystemInfoToManagingSystem(connectionInfo);
            }
        }


        private void ProcessInternalClientStatus()
        {
            foreach (InternalClientStatus iClientStatus in _internalClientStatus)
            {
                double diffPing = (DateTime.Now - iClientStatus.LastPingTimeStamp).TotalSeconds;

                if (diffPing > 10 && iClientStatus.ClientStatus != VRGameSelectorServerDTO.Enums.LiveClientStatus.OFFLINE)
                {
                    iClientStatus.ClientStatus = VRGameSelectorServerDTO.Enums.LiveClientStatus.OFFLINE;
                    isManageSystemPushRequired = true;
                }

                lock (_lockUpdateInternalClientStatus)
                {
                    if (iClientStatus.ClientRunningModeSetup.RunningMode == VRGameSelectorDTO.Enums.ClientRunningMode.TIMING_ON)
                    {
                        double diffStartTime = (DateTime.Now - iClientStatus.ClientRunningModeSetup.StartTime).TotalMinutes;
                        if (diffStartTime > iClientStatus.ClientRunningModeSetup.Duration)
                        {
                            ConnectionInfo connInfo = _targetClientDaemonConnection.Where(x => ((IPEndPoint)x.RemoteEndPoint).Address.MapToIPv4().ToString() == iClientStatus.ClientIP).FirstOrDefault();

                            UpdateInternalClientSetup(iClientStatus.ClientID, DateTime.Now, VRGameSelectorDTO.Enums.ClientRunningMode.ENDED_TIMING);

                            iClientStatus.ClientRunningModeSetup.StartTime = DateTime.MinValue;

                            if (connInfo != null)
                            {

                                VRCommand vrc = new VRCommand(VRGameSelectorDTO.Enums.ControlMessage.END_NOW);

                                SendCommandToPeer(connInfo, vrc);

                            }
                        }
                    }

                }

            }
        }

        private void RefreshConfigSetForClient(int clientID, int tileConfigSetID)
        {
            if (_internalClientStatus != null)
            {
                InternalClientStatus ics = _internalClientStatus.Where(x => x.ClientID == clientID).FirstOrDefault();

                if (ics != null)
                {
                    ConnectionInfo connInfo = _targetClientDaemonConnection.Where(x => ((IPEndPoint)x.RemoteEndPoint).Address.MapToIPv4().ToString() == ics.ClientIP).FirstOrDefault();

                    ClientSetAllTileConfig(connInfo);
                }
            }
        }

        private void BuildInternalClientStatus()
        {
            if (_internalClientStatus == null)
            {
                _internalClientStatus = new List<InternalClientStatus>();
            }
            else
            {
                _internalClientStatus.Clear();
            }


            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                foreach (VRClient vc in m.VRClients.Where(x => !x.IsDeleted).ToList())
                {
                    ClientRunningMode cs = new ClientRunningMode(vc.ID, vc.IPAddress, DateTime.MinValue, 0, 0, VRGameSelectorDTO.Enums.ClientRunningMode.ENDED_TIMING, null, 0);

                    InternalClientStatus ics = new InternalClientStatus()
                    {
                        ClientID = vc.ID,
                        ClientIP = vc.IPAddress,
                        DashboardModuleIP = vc.DashboardModuleIP,
                        ClientName = vc.MachineName,
                        AdditionalInfo = "",
                        IsRequireAssistance = false,
                        ClientStatus = VRGameSelectorServerDTO.Enums.LiveClientStatus.NONE,
                        LastPingTimeStamp = DateTime.MinValue,
                        LastTileConfigDownloadTimestamp = DateTime.MinValue,
                        ClientRunningModeSetup = cs
                    };

                    _internalClientStatus.Add(ics);

                }
            }

            isManageSystemPushRequired = true;

            foreach (ConnectionInfo cInfo in _targetClientDaemonConnection)
            {
                string ipAdd = ((IPEndPoint)cInfo.RemoteEndPoint).Address.MapToIPv4().ToString();

                InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.ClientIP == ipAdd).FirstOrDefault();

                if (iClientStatus != null)
                {
                    UpdateInternalClientSetup(iClientStatus.ClientID, DateTime.Now, VRGameSelectorDTO.Enums.ClientRunningMode.ENDED_MANUAL);

                    VRCommand vrc = new VRCommand(VRGameSelectorDTO.Enums.ControlMessage.END_NOW);

                    SendCommandToPeer(cInfo, vrc);
                }
            }

        }

        private void UpdateInternalClientStatus(string ipAddress, string machineName, VRGameSelectorDTO.Enums.LiveClientStatus liveClientStatus, string addInfo)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.ClientIP == ipAddress).FirstOrDefault();

                if (iClientStatus != null)
                {
                    VRClient vrc = m.VRClients.Where(x => x.IPAddress == ipAddress && !x.IsDeleted).FirstOrDefault();

                    if (vrc != null && !vrc.MachineName.ToString().Equals(machineName))
                    {
                        vrc.MachineName = machineName;
                        m.SaveChanges();
                        //m.Cache.Release(m.VRClients);
                    }

                    iClientStatus.ClientName = machineName;
                    iClientStatus.ClientStatus = (VRGameSelectorServerDTO.Enums.LiveClientStatus)liveClientStatus;
                    iClientStatus.AdditionalInfo = addInfo;

                }


            }
        }

        private void UpdateInternalClientStatus(string ipAddress, VRGameSelectorDTO.Enums.LiveClientStatus liveClientStatus)
        {
            if (_internalClientStatus != null)
            {
                InternalClientStatus existClientStatus = _internalClientStatus.Where(x => x.ClientIP == ipAddress).FirstOrDefault();

                if (existClientStatus != null)
                {
                    existClientStatus.ClientStatus = (VRGameSelectorServerDTO.Enums.LiveClientStatus)liveClientStatus;
                }
            }
        }

        private void UpdateInternalClientStatus(string ipAddress)
        {
            if (_internalClientStatus != null)
            {
                InternalClientStatus existClientStatus = _internalClientStatus.Where(x => x.ClientIP == ipAddress).FirstOrDefault();

                if (existClientStatus != null)
                {
                    existClientStatus.LastPingTimeStamp = DateTime.Now;
                }
            }
        }

        private void UpdateInternalClientSetup(int clientID, DateTime startTime, VRGameSelectorDTO.Enums.ClientRunningMode runningMode, int customerAge = 0, int duration = 0)
        {
            if (_internalClientStatus != null)
            {
                InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.ClientID == clientID).FirstOrDefault();

                if (iClientStatus != null)
                {
                    lock (_lockUpdateInternalClientStatus)
                    {
                        iClientStatus.ClientRunningModeSetup.RunningMode = runningMode;
                        iClientStatus.ClientRunningModeSetup.StartTime = startTime;
                        iClientStatus.ClientRunningModeSetup.Duration = duration;
                        iClientStatus.ClientRunningModeSetup.CustomerAge = customerAge;
                    }
                }
            }

        }

        private void UpdateInternalClientStatus(int clientID, InternalClientStatus internalClientStatus)
        {
            if (_internalClientStatus != null)
            {
                InternalClientStatus existClientStatus = _internalClientStatus.Where(x => x.ClientID == clientID).FirstOrDefault();

                if (existClientStatus != null)
                {
                    existClientStatus.ClientIP = (internalClientStatus.ClientIP != null) ? internalClientStatus.ClientIP : existClientStatus.ClientIP;
                    existClientStatus.DashboardModuleIP = (internalClientStatus.DashboardModuleIP != null) ? internalClientStatus.DashboardModuleIP : existClientStatus.DashboardModuleIP;
                    existClientStatus.ClientName = (internalClientStatus.ClientName != null) ? internalClientStatus.ClientName : existClientStatus.ClientName;
                    existClientStatus.ClientStatus = (internalClientStatus.ClientStatus != null) ? internalClientStatus.ClientStatus : existClientStatus.ClientStatus;
                    existClientStatus.IsRequireAssistance = (internalClientStatus.IsRequireAssistance != null) ? internalClientStatus.IsRequireAssistance : existClientStatus.IsRequireAssistance;
                    existClientStatus.AdditionalInfo = (internalClientStatus.AdditionalInfo != null) ? internalClientStatus.AdditionalInfo : existClientStatus.AdditionalInfo;
                    existClientStatus.LastPingTimeStamp = (internalClientStatus.LastPingTimeStamp != null) ? internalClientStatus.LastPingTimeStamp : existClientStatus.LastPingTimeStamp;
                }
            }
        }


        private void CreateManageLog(VRGameSelectorServerDTO.Enums.SourceType sourceType, VRGameSelectorServerDTO.Enums.OperationType operationType, string sourceIdentity, int? clientID, int? tileID, string ticketGUID, string additionalInfo)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                VRManageLog vrManLog = new VRManageLog()
                {
                    Source = sourceType.ToString(),
                    SourceIdentity = sourceIdentity,
                    Operation = operationType.ToString(),
                    AdditonalInfo = additionalInfo,
                    VRClientID = clientID,
                    VRTileconfigID = tileID,
                    VRTicketGUID = ticketGUID,
                    TimeStamp = DateTime.Now
                };

                m.Add(vrManLog);
                m.SaveChanges();

            }
        }


        private void UpdateLocalBookingReference()
        {
            string url = Utility.GetCoreConfig("BookingSystemIntergrationURL");
            string passcode = Utility.GetCoreConfig("Passcode");

            BookingReferenceClientApi.GetBookingReferenceAsync(url, passcode);
        }

        private void BookingReferenceClientApi_OnBookingReferenceResult(object sender, EventArgs e)
        {
            List<BookingReferenceJson> lbrj = ((BookingReferenceJsonEvent)e).ListBookingReference;

            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                int sessionLength = 50;

                VRConfiguration vrc = m.VRConfigurations.Where(x => x.Type == Enum.GetName(typeof(VRGameSelectorServerDTO.Enums.SysConfigType), VRGameSelectorServerDTO.Enums.SysConfigType.DEFAULT_TIMED_SESSION_LENGTH)).FirstOrDefault();

                if (vrc != null)
                {
                    int.TryParse(vrc.Value, out sessionLength);
                }

                foreach (BookingReferenceJson brj in lbrj)
                {
                    DateTime bookingUpdateTime = DateTime.MinValue;
                    DateTime bookingDeleteTime = DateTime.MinValue;
                    DateTime bookingStartTime = DateTime.MinValue;
                    DateTime bookingEndTime = DateTime.MinValue;
                    int bookingTotalNum = 0;

                    DateTime.TryParse(brj.booking_updated, out bookingUpdateTime);
                    DateTime.TryParse(brj.booking_deleted, out bookingDeleteTime);
                    DateTime.TryParse(brj.booking_start_time, out bookingStartTime);
                    DateTime.TryParse(brj.booking_end_time, out bookingEndTime);
                    int.TryParse(brj.booking_num_total, out bookingTotalNum);

                    bookingUpdateTime = (bookingUpdateTime != DateTime.MinValue) ? DateTime.SpecifyKind(bookingUpdateTime, DateTimeKind.Utc).ToLocalTime() : bookingUpdateTime;
                    bookingDeleteTime = (bookingDeleteTime != DateTime.MinValue) ? DateTime.SpecifyKind(bookingDeleteTime, DateTimeKind.Utc).ToLocalTime() : bookingDeleteTime;
                    bookingStartTime = (bookingStartTime != DateTime.MinValue) ? DateTime.SpecifyKind(bookingStartTime, DateTimeKind.Utc).ToLocalTime() : bookingStartTime;
                    bookingEndTime = (bookingEndTime != DateTime.MinValue) ? DateTime.SpecifyKind(bookingEndTime, DateTimeKind.Utc).ToLocalTime() : bookingEndTime;

                    sessionLength = Math.Abs((int)bookingEndTime.Subtract(bookingStartTime).TotalMinutes);

                    VRBookingReference vrBookingRef = m.VRBookingReferences.Where(x => x.Reference == brj.booking_id).FirstOrDefault();

                    if (vrBookingRef != null)
                    {
                        // existing record
                        if (bookingUpdateTime != DateTime.MinValue && (vrBookingRef.BookingChanged ?? DateTime.MinValue) != bookingUpdateTime)
                        {
                            vrBookingRef.BookingChanged = bookingUpdateTime;
                            vrBookingRef.BookingStartTime = bookingStartTime;
                            vrBookingRef.BookingEndTime = bookingEndTime;

                            if (vrBookingRef.NumberOfBookingTotal < bookingTotalNum) // add people
                            {
                                vrBookingRef.NumberOfBookingLeft += (bookingTotalNum - vrBookingRef.NumberOfBookingTotal);
                            }
                            else if (vrBookingRef.NumberOfBookingTotal > bookingTotalNum) // remove people
                            {
                                vrBookingRef.NumberOfBookingLeft -= (vrBookingRef.NumberOfBookingTotal - bookingTotalNum);
                            }

                            vrBookingRef.NumberOfBookingTotal = bookingTotalNum;

                            // value guard
                            if (vrBookingRef.NumberOfBookingLeft > vrBookingRef.NumberOfBookingTotal)
                            {
                                vrBookingRef.NumberOfBookingLeft = vrBookingRef.NumberOfBookingTotal;
                            }
                            else if (vrBookingRef.NumberOfBookingLeft < 0)
                            {
                                vrBookingRef.NumberOfBookingLeft = 0;
                            }



                        }
                        if (bookingDeleteTime != DateTime.MinValue && (vrBookingRef.BookingDeleted ?? DateTime.MinValue) != bookingDeleteTime)
                        {
                            vrBookingRef.BookingDeleted = bookingDeleteTime;
                        }

                    }
                    else
                    {
                        // new record

                        // 
                        VRBookingReference vrbr = new VRBookingReference()
                        {
                            BookingStartTime = bookingStartTime,
                            BookingEndTime = bookingEndTime,
                            Reference = brj.booking_id,
                            IsTimedTiming = true,
                            IsNonTimedTiming = false,
                            Duration = sessionLength,
                            NumberOfBookingTotal = bookingTotalNum,
                            NumberOfBookingLeft = bookingTotalNum,
                            TimeStampCreate = DateTime.Now
                        };

                        m.Add(vrbr);
                    }

                    m.SaveChanges();
                }
            }

        }


    }


}

