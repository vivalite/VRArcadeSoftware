using NetworkCommsDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using VRGameSelectorDTO;
using VRGameSelectorServerDB;
using VRGameSelectorServerDTO;

namespace VRArcadeServer
{
    public partial class VRGameSelectorServer
    {

        public void ResetCleaningStatusDashboard(string ipAdd)
        {
            InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.DashboardModuleIP == ipAdd).FirstOrDefault();

            logger.Debug("CLEANING STATUS RESET from dashboard " + ipAdd);

            if (iClientStatus != null)
            {
                ConnectionInfo connInfo = _targetClientDaemonConnection.Where(x => ((IPEndPoint)x.RemoteEndPoint).Address.MapToIPv4().ToString() == iClientStatus.ClientIP).FirstOrDefault();

                if (connInfo != null)
                {
                    VRCommand vrc = new VRCommand(VRGameSelectorDTO.Enums.ControlMessage.CLEANING_PROVIDED);

                    SendCommandToPeer(connInfo, vrc);

                }
            }
        }

        public void ResetHelpRequestStatusDashboard(string ipAdd)
        {
            InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.DashboardModuleIP == ipAdd).FirstOrDefault();

            if (iClientStatus != null)
            {
                UpdateInternalClientStatus(iClientStatus.ClientID, new InternalClientStatus()
                {
                    IsRequireAssistance = false
                });

                isManageSystemPushRequired = true;
            }
        }

        public void ProcessBarcode(string ipAdd, string barcode)
        {
            try
            {
                logger.Debug("BARCODE IN  " + barcode);
                logger.Debug("From dashboard: " + ipAdd);

                InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.DashboardModuleIP == ipAdd).FirstOrDefault();

                Ascii85 a85 = new Ascii85();
                //Guid guid = new Guid(Convert.FromBase64String(barcode.BarcodeReadout + "=="));

                Guid guid = new Guid(a85.Decode(barcode));

                logger.Debug(guid.ToString());

                if (iClientStatus != null && guid != null && guid != Guid.Empty)
                {
                    logger.Debug("P1");
                    using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
                    {
                        VRTicket vrt = m.VRTickets.Where(x => x.GUID == guid.ToString() && !x.IsDeleted).FirstOrDefault();

                        if (vrt != null && vrt.VRTicketType != null)
                        {
                            logger.Debug("P2");
                            List<ClientParm> clientParm = new List<ClientParm>();
                            IPAddress ipa = null;
                            if (!IPAddress.TryParse(ipAdd, out ipa))
                            {
                                ipa = IPAddress.Parse("0.0.0.0");
                            }

                            OperationInfo opInfo = new OperationInfo()
                            {
                                ConnectionInfo = new ConnectionInfo(new IPEndPoint(ipa, 0)),
                                TicketGUID = vrt.GUID,
                                SourceType = VRGameSelectorServerDTO.Enums.SourceType.LCD_BARCODE_MODULE,
                                ClientID = iClientStatus.ClientID
                            };

                            if (vrt.VRTicketType.Type == "TICKET" && iClientStatus.ClientStatus == VRGameSelectorServerDTO.Enums.LiveClientStatus.CLEANING_DONE)
                            {
                                if (Math.Abs(DateTime.Now.Subtract(vrt.TimeStampCreate).TotalMinutes) <= 60)
                                {
                                    logger.Debug("P3");
                                    VRClient vrc = m.VRClients.Where(x => x.ID == iClientStatus.ClientID).FirstOrDefault();

                                    if (vrt.Minutes == 0)
                                    {
                                        // non-timing
                                        clientParm.Add(new ClientParm(iClientStatus.ClientID));
                                        SendStartNow(clientParm, opInfo);
                                        logger.Debug("NON-TIMING");
                                    }
                                    else
                                    {
                                        // timing
                                        Dictionary<string, string> dict = new Dictionary<string, string>() { { "Duration", vrt.Minutes.ToString() } };

                                        clientParm.Add(new ClientParm(iClientStatus.ClientID, dict));
                                        SendStartTiming(clientParm, opInfo);
                                        logger.Debug("TIMING:" + vrt.Minutes.ToString());
                                    }

                                    vrt.IsDeleted = true;
                                    vrt.TimeStampDelete = DateTime.Now;
                                    vrt.VRClientID = (vrc != null) ? (int?)vrc.ID : null;

                                    m.SaveChanges();


                                }
                                else
                                {
                                    logger.Debug("P4");
                                }


                            }
                            else if (vrt.VRTicketType.Type == "KEY-START-NON-TIMING")
                            {
                                clientParm.Add(new ClientParm(iClientStatus.ClientID));
                                SendStartNow(clientParm, opInfo);

                            }
                            else if (vrt.VRTicketType.Type == "KEY-START-TIMING")
                            {
                                Dictionary<string, string> dict = new Dictionary<string, string>() { { "Duration", vrt.Minutes.ToString() } };

                                clientParm.Add(new ClientParm(iClientStatus.ClientID, dict));
                                SendStartTiming(clientParm, opInfo);

                            }
                            else if (vrt.VRTicketType.Type == "KEY-END-GAME")
                            {
                                Dictionary<string, string> dict = new Dictionary<string, string>() { { "EndMode", "Manual" } };

                                clientParm.Add(new ClientParm(iClientStatus.ClientID, dict));
                                SendEndNow(clientParm, opInfo);

                            }
                            else if (vrt.VRTicketType.Type == "KEY-REBOOT")
                            {
                                clientParm.Add(new ClientParm(iClientStatus.ClientID));
                                SendReboot(clientParm, opInfo);

                            }
                            else if (vrt.VRTicketType.Type == "KEY-TURNOFF")
                            {
                                clientParm.Add(new ClientParm(iClientStatus.ClientID));
                                SendTurnOff(clientParm, opInfo);

                            }
                            else if (vrt.VRTicketType.Type == "KEY-KMU-ON")
                            {
                                clientParm.Add(new ClientParm(iClientStatus.ClientID));
                                SendTurnOnKMU(clientParm, opInfo);

                            }
                            else if (vrt.VRTicketType.Type == "KEY-KMU-OFF")
                            {
                                clientParm.Add(new ClientParm(iClientStatus.ClientID));
                                SendTurnOffKMU(clientParm, opInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Debug("Barcode Decoding Error: " + ex.Message);
            }

        }

        public DashboardModuleInfo PopulateDashboardModuleInfo(string ipAdd)
        {

            //logger.Debug("PopulateDashboardModuleInfo: " + ipAdd);

            InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.DashboardModuleIP == ipAdd).FirstOrDefault();

            DashboardModuleInfo dmInfo = new DashboardModuleInfo();

            if (iClientStatus != null)
            {
                dmInfo.CurrentRunningMode = (VRGameSelectorServerDTO.Enums.ClientRunningMode)Enum.Parse(typeof(VRGameSelectorServerDTO.Enums.ClientRunningMode), iClientStatus.ClientRunningModeSetup.RunningMode.ToString());

                dmInfo.IsRequireAssistant = iClientStatus.IsRequireAssistance ?? false;

                dmInfo.CurrentRunningTitle = (iClientStatus.ClientRunningModeSetup.TileConfig != null) ? iClientStatus.ClientRunningModeSetup.TileConfig.TileTitle : "";

                dmInfo.LiveClientStatus = iClientStatus.ClientStatus ?? VRGameSelectorServerDTO.Enums.LiveClientStatus.NONE;

            }

            return dmInfo;

        }


    }
}
