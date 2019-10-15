using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Tools;
using NLog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Timers;
using VRGameSelectorServerDTO;

namespace ManagingSystem
{
    public sealed class NetworkFunction
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static event EventHandler OnIncommingSystemConfig = delegate { };
        public static event EventHandler OnIncommingConfigerClientList = delegate { };
        public static event EventHandler OnIncommingConfigSetList = delegate { };
        public static event EventHandler OnIncommingTileConfigList = delegate { };
        public static event EventHandler OnIncommingLiveSystemInfo = delegate { };
        public static event EventHandler OnIncommingGamePlayHistory = delegate { };
        public static event EventHandler OnIncommingBarcodeInfo = delegate { };
        public static event EventHandler OnIncommingKeyInfoList = delegate { };
        public static event EventHandler OnIncommingKeyTypeInfoList = delegate { };
        public static event EventHandler OnIncommingWaiverInfoList = delegate { };
        public static event EventHandler OnIncommingBookingReference = delegate { };

        private static System.Timers.Timer _timerPing;
        private static ConnectionInfo _targetServerConnectionInfo;
        private static DateTime _lastRefreshTime = DateTime.MinValue;
        private static double _secondSinceRefresh = 0;

        public static bool IsServerConnected;

        static NetworkFunction()
        {
        }


        public static void Init()
        {
            InitNetworkComms();
        }


        private static void InitNetworkComms()
        {
            DataSerializer dataSerializer = DPSManager.GetDataSerializer<ProtobufSerializer>();
            List<DataProcessor> dataProcessors = new List<DataProcessor>();
            Dictionary<string, string> dataProcessorOptions = new Dictionary<string, string>();

            dataProcessors.Add(DPSManager.GetDataProcessor<SharpZipLibCompressor.SharpZipLibGzipCompressor>());
            NetworkComms.DefaultSendReceiveOptions = new SendReceiveOptions(dataSerializer, dataProcessors, dataProcessorOptions);
            NetworkComms.DefaultSendReceiveOptions.IncludePacketConstructionTime = true;
            NetworkComms.DefaultSendReceiveOptions.ReceiveHandlePriority = QueueItemPriority.AboveNormal;

            NetworkComms.AppendGlobalIncomingPacketHandler<VRCommandServer>("Command", HandleGlobalIncomingCommand);

            NetworkComms.AppendGlobalConnectionEstablishHandler(HandleGlobalConnectionEstablishEvent);
            NetworkComms.AppendGlobalConnectionCloseHandler(HandleGlobalConnectionCloseEvent);

            IPEndPoint ip = IPTools.ParseEndPointFromString(Utility.GetCoreConfig("ServerIPPort"));
            _targetServerConnectionInfo = new ConnectionInfo(ip, ApplicationLayerProtocolStatus.Enabled);


            _timerPing = new System.Timers.Timer();
            _timerPing.Elapsed += new ElapsedEventHandler(OnTimerPingEvent);
            _timerPing.Interval = 3000;
            _timerPing.Enabled = true;

        }

        private static void OnTimerPingEvent(object sender, ElapsedEventArgs e)
        {
            SendPingToServer();
        }

        private static void HandleGlobalConnectionEstablishEvent(Connection connection)
        {
            IsServerConnected = true;
        }
        private static void HandleGlobalConnectionCloseEvent(Connection connection)
        {
            IsServerConnected = false;
        }

        private static void HandleGlobalIncomingCommand(PacketHeader packetHeader, Connection connection, VRCommandServer vrCommandServer)
        {
            switch (vrCommandServer.ControlMessage)
            {
                case Enums.ControlMessage.NONE:
                    break;
                case Enums.ControlMessage.GET_SYSCONFIG:

                    SystemConfigEvent sce = new SystemConfigEvent()
                    {
                        SystemConfig = vrCommandServer.SystemConfig.Clone()
                    };

                    OnIncommingSystemConfig(null, sce);

                    break;
                case Enums.ControlMessage.GET_CONFIGED_CLIENT_LIST:

                    ClientEvent ce = new ClientEvent()
                    {
                        ListClients = vrCommandServer.ListClients.Clone()
                    };

                    OnIncommingConfigerClientList(null, ce);

                    break;
                case Enums.ControlMessage.GET_CONFIG_SET_LIST:

                    ConfigSetEvent cse = new ConfigSetEvent()
                    {
                        ListConfigSets = vrCommandServer.ListConfigSet.Clone()
                    };

                    OnIncommingConfigSetList(null, cse);

                    break;
                case Enums.ControlMessage.GET_TILE_CONFIG:

                    TileConfigEvent tce = new TileConfigEvent()
                    {
                        ListTileConfigs = vrCommandServer.ListTileConfig.Clone()
                    };

                    OnIncommingTileConfigList(null, tce);

                    break;
                case Enums.ControlMessage.GET_LIVE_SYSTEM_INFO:

                    LiveSystemInfoEvent lsie = new LiveSystemInfoEvent()
                    {
                        LiveSystemInfo = vrCommandServer.LiveSystemInfo.Clone()
                    };

                    OnIncommingLiveSystemInfo(null, lsie);

                    if (_lastRefreshTime != DateTime.MinValue)
                    {
                        _secondSinceRefresh = DateTime.Now.Subtract(_lastRefreshTime).TotalSeconds;
                    }
                    _lastRefreshTime = DateTime.Now;

                    break;
                case Enums.ControlMessage.GET_GAME_PLAY_HISTORY:

                    GamePlayHistoryEvent gphe = new GamePlayHistoryEvent()
                    {
                        ListGamePlayHistory = vrCommandServer.GamePlayHistory.Clone()
                    };

                    OnIncommingGamePlayHistory(null, gphe);

                    break;
                case Enums.ControlMessage.GENERATE_BARCODE:

                    BarcodeInfoEvent bie = new BarcodeInfoEvent()
                    {
                        BarcodeInfo = vrCommandServer.BarcodeInfo
                    };

                    OnIncommingBarcodeInfo(null, bie);

                    break;
                case Enums.ControlMessage.GET_KEY:

                    KeyInfoEvent kie = new KeyInfoEvent()
                    {
                        ListKeyInfo = vrCommandServer.ListKeyInfo
                    };

                    OnIncommingKeyInfoList(null, kie);

                    break;
                case Enums.ControlMessage.GET_KEY_TYPE:

                    KeyTypeInfoEvent ktie = new KeyTypeInfoEvent()
                    {
                        ListKeyTypeInfo = vrCommandServer.ListKeyTypeInfo
                    };

                    OnIncommingKeyTypeInfoList(null, ktie);

                    break;
                case Enums.ControlMessage.GET_PENDING_WAIVER:

                    WaiverInfoEvent wie = new WaiverInfoEvent()
                    {
                        ListWaiverInfo = vrCommandServer.ListWaiverInfo
                    };

                    OnIncommingWaiverInfoList(null, wie);

                    break;
                case Enums.ControlMessage.GET_BOOKING_REF_SETTING:

                    BookingReferenceEvent bre = new BookingReferenceEvent()
                    {
                        BookingReference = vrCommandServer.BookingReference
                    };

                    OnIncommingBookingReference(null, bre);

                    break;
                default:
                    break;
            }
        }





        public static void GetSystemConfig(SystemConfig systemConfig)
        {
            List<SystemConfig> lsc = new List<SystemConfig>();
            lsc.Add(systemConfig);

            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.GET_SYSCONFIG, lsc);

            SendCommandToServer(cmd);

        }

        public static void GetSystemConfig(List<SystemConfig> systemConfig)
        {

            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.GET_SYSCONFIG, systemConfig);

            SendCommandToServer(cmd);

        }

        public static void SetSystemConfig(SystemConfig systemConfig)
        {
            List<SystemConfig> lsc = new List<SystemConfig>();
            lsc.Add(systemConfig);

            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.SET_SYSCONFIG, lsc);

            SendCommandToServer(cmd);
        }

        public static void SetSystemConfig(List<SystemConfig> systemConfig)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.SET_SYSCONFIG, systemConfig);

            SendCommandToServer(cmd);
        }

        public static void GetConfigSet()
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.GET_CONFIG_SET_LIST);

            SendCommandToServer(cmd);

        }

        public static void AddConfigSet(ConfigSet configSet)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.ADD_CONFIG_SET, configSet);

            SendCommandToServer(cmd);

        }

        public static void DeleteConfigSet(ConfigSet configSet)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.DELETE_CONFIG_SET, configSet);

            SendCommandToServer(cmd);

        }

        public static void ModifyConfigSet(ConfigSet configSet)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.MODIFY_CONFIG_SET, configSet);

            SendCommandToServer(cmd);

        }

        public static void GetClientConfig()
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.GET_CONFIGED_CLIENT_LIST);

            SendCommandToServer(cmd);

        }


        public static void ModifyClientConfig(Client client)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.MODIFY_CLIENT_CONFIG, client);

            SendCommandToServer(cmd);

        }

        public static void AddClientConfig(Client client)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.ADD_CLIENT_CONFIG, client);

            SendCommandToServer(cmd);

        }

        public static void DeleteClientConfig(Client client)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.DELETE_CLIENT_CONFIG, client);

            SendCommandToServer(cmd);

        }

        public static void GetTileConfig(int tileConfigSetID)
        {
            TileConfig tc = new TileConfig()
            {
                TileConfigSetID = tileConfigSetID
            };

            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.GET_TILE_CONFIG, tc);

            SendCommandToServer(cmd);

        }

        public static void ModifyTileConfig(TileConfig tileConfig)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.MODIFY_TILE_CONFIG, tileConfig);

            SendCommandToServer(cmd);

        }

        public static void AddTileConfig(TileConfig tileConfig)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.ADD_TILE_CONFIG, tileConfig);

            SendCommandToServer(cmd);

        }

        public static void DeleteTileConfig(TileConfig tileConfig)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.DELETE_TILE_CONFIG, tileConfig);

            SendCommandToServer(cmd);

        }

        public static void ReOrderUpTileConfig(TileConfig tileConfig)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.REORDER_UP_TILE_CONFIG, tileConfig);

            SendCommandToServer(cmd);

        }

        public static void ReOrderDownTileConfig(TileConfig tileConfig)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.REORDER_DOWN_TILE_CONFIG, tileConfig);

            SendCommandToServer(cmd);

        }

        public static void SyncTileConfig()
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.SYNC_TILE_CONFIG);

            SendCommandToServer(cmd);

        }

        public static void ReInitClientSetting()
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.REINIT_CLIENT_SETTING);

            SendCommandToServer(cmd);

        }

        public static void GetLiveSystemInfo()
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.GET_LIVE_SYSTEM_INFO);

            SendCommandToServer(cmd);
        }


        public static void SendStartTiming(List<ClientParm> clientParm)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.START_TIMING, clientParm);

            SendCommandToServer(cmd);
        }

        public static void SendStartNow(List<ClientParm> clientParm)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.START_NOW, clientParm);

            SendCommandToServer(cmd);
        }

        public static void SendEndNow(List<ClientParm> clientParm)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.END_NOW, clientParm);

            SendCommandToServer(cmd);
        }

        public static void SendReboot(List<ClientParm> clientParm)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.REBOOT, clientParm);

            SendCommandToServer(cmd);
        }

        public static void SendTurnOff(List<ClientParm> clientParm)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.TURN_OFF, clientParm);

            SendCommandToServer(cmd);
        }

        public static void SendTurnOffKMU(List<ClientParm> clientParm)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.TURN_OFF_KMU, clientParm);

            SendCommandToServer(cmd);
        }

        public static void SendTurnOnKMU(List<ClientParm> clientParm)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.TURN_ON_KMU, clientParm);

            SendCommandToServer(cmd);
        }

        public static void TurnOffAssistingFlag(List<ClientParm> clientParm)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.HELP_PROVIDED, clientParm);

            SendCommandToServer(cmd);
        }

        public static void TurnOffCleaningFlag(List<ClientParm> clientParm)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.CLEANING_PROVIDED, clientParm);

            SendCommandToServer(cmd);
        }

        public static void GenerateBarcode(BarcodeInfo barcodeInfo)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.GENERATE_BARCODE, barcodeInfo);

            SendCommandToServer(cmd);
        }

        public static void GetGamePlayHistory(int clientID)
        {

            List<ClientParm> cp = new List<ClientParm>();
            cp.Add(new ClientParm(clientID));

            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.GET_GAME_PLAY_HISTORY, cp);

            SendCommandToServer(cmd);

        }

        public static void GetKeyType()
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.GET_KEY_TYPE);

            SendCommandToServer(cmd);
        }

        public static void GetKey()
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.GET_KEY);

            SendCommandToServer(cmd);
        }

        public static void AddKey(List<KeyInfo> keyInfo)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.ADD_KEY, keyInfo);

            SendCommandToServer(cmd);
        }

        public static void DeleteKey(List<KeyInfo> keyInfo)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.DELETE_KEY, keyInfo);

            SendCommandToServer(cmd);
        }

        public static void GetPendingWaiver()
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.GET_PENDING_WAIVER);

            SendCommandToServer(cmd);
        }

        public static void GetBookingReferenceSetting(BookingReference bookingReference)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.GET_BOOKING_REF_SETTING, bookingReference);

            SendCommandToServer(cmd);
        }

        public static void DeletePendingWaiver(List<WaiverInfo> listWaverInfo)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.DELETE_PENDING_WAIVER, listWaverInfo);

            SendCommandToServer(cmd);
        }

        public static void MarkWaiverReceived(List<WaiverInfo> listWaverInfo)
        {
            VRCommandServer cmd = new VRCommandServer(Enums.ControlMessage.MARK_WAIVER_RECEIVED, listWaverInfo);

            SendCommandToServer(cmd);
        }


        public static double GetSecondsSinceLastRefresh()
        {
            if (IsServerConnected)
            {
                return _secondSinceRefresh;
            }
            else
            {
                return -1;
            }
        }


        // generic method to send command object to server
        private static Task SendCommandToServer(object cmdObj)
        {
            return Task.Run(() =>
            {
                try
                {
                    TCPConnection conn = TCPConnection.GetConnection(_targetServerConnectionInfo);

                    conn.SendObject("Command", cmdObj);


                }
                catch (Exception ex)
                {
                    //throw (ex);
                }
            });
        }

        private static void SendPingToServer()
        {

            //SendCommandToServer(new VRCommandServer(Enums.ControlMessage.NONE)); // instead of send ping, send refresh request

            GetLiveSystemInfo();

        }


        public static void ShutDown()
        {
            NetworkComms.Shutdown();
        }


    }
}
