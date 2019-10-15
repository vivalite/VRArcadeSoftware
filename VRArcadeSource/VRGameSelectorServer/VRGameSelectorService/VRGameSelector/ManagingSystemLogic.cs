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


        private void GetSysConfig(ConnectionInfo connectionInfo, List<SystemConfig> systemConfig)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                List<SystemConfig> lsc = new List<SystemConfig>();

                foreach (SystemConfig sc in systemConfig)
                {
                    VRConfiguration vc = m.VRConfigurations.Where(x => x.Type == Enum.GetName(typeof(VRGameSelectorServerDTO.Enums.SysConfigType), sc.Type)).FirstOrDefault();

                    if (vc != null)
                    {
                        lsc.Add(new SystemConfig((VRGameSelectorServerDTO.Enums.SysConfigType)Enum.Parse(typeof(VRGameSelectorServerDTO.Enums.SysConfigType), vc.Type, true), vc.Value));
                    }
                    else
                    {
                        lsc.Add(new SystemConfig(sc.Type, ""));
                    }

                }

                VRCommandServer vcs = new VRCommandServer(VRGameSelectorServerDTO.Enums.ControlMessage.GET_SYSCONFIG, lsc);

                SendCommandToPeer(connectionInfo, vcs);
            }
        }

        private void SetSysConfig(List<SystemConfig> systemConfig)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {

                foreach (SystemConfig sc in systemConfig)
                {
                    VRConfiguration vc = m.VRConfigurations.Where(x => x.Type == Enum.GetName(typeof(VRGameSelectorServerDTO.Enums.SysConfigType), sc.Type)).FirstOrDefault();

                    if (vc != null)
                    {
                        // existing
                        vc.Value = sc.Value;
                    }
                    else
                    {
                        // new
                        VRConfiguration vrc = new VRConfiguration()
                        {
                            Type = Enum.GetName(typeof(VRGameSelectorServerDTO.Enums.SysConfigType), sc.Type),
                            Value = sc.Value
                        };

                        m.Add(vrc);
                    }
                }

                m.SaveChanges();
                //m.Cache.Release(m.VRConfigurations);

            }
        }

        private void DeleteTileConfig(ConnectionInfo connectionInfo, VRGameSelectorServerDTO.TileConfig tileConfig)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                VRTileconfig vtc = m.VRTileconfigs.Where(x => x.ID == tileConfig.ID).FirstOrDefault();

                if (vtc != null)
                {
                    vtc.IsDeleted = true;
                    m.SaveChanges();
                    //m.Cache.Release(m.VRTileconfigs);
                }

            }

            GetTileConfigList(connectionInfo, tileConfig.TileConfigSetID);
        }

        private void AddTileConfig(ConnectionInfo connectionInfo, VRGameSelectorServerDTO.TileConfig tileConfig)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                VRTileconfig vtc = new VRTileconfig()
                {
                    TileGUID = tileConfig.TileGUID,
                    TileTitle = tileConfig.TileTitle,
                    TileHeight = tileConfig.TileHeight,
                    TileWidth = tileConfig.TileWidth,
                    TileDesc = tileConfig.TileDesc,
                    Command = tileConfig.Command,
                    Arguments = tileConfig.Arguments,
                    WorkingPath = tileConfig.WorkingPath,
                    Order = tileConfig.Order,
                    TileRowNumber = tileConfig.TileRowNumber,
                    TileConfigSetID = tileConfig.TileConfigSetID,
                    VRTileconfigID = tileConfig.TileconfigID,
                    ImageData = tileConfig.TileImage.ImageData,
                    AgeRequire = tileConfig.AgeRequire,
                    VideoURL = tileConfig.VideoURL,
                    IsDeleted = false
                };

                m.Add(vtc);
                m.SaveChanges();
                //m.Cache.Release(m.VRTileconfigs);
            }

            GetTileConfigList(connectionInfo, tileConfig.TileConfigSetID);
        }

        private void ModifyTileConfig(ConnectionInfo connectionInfo, VRGameSelectorServerDTO.TileConfig tileConfig)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {

                VRTileconfig vtc = m.VRTileconfigs.Where(x => x.ID == tileConfig.ID).FirstOrDefault();

                if (vtc != null)
                {
                    vtc.TileGUID = tileConfig.TileGUID;
                    vtc.TileTitle = tileConfig.TileTitle;
                    vtc.TileHeight = tileConfig.TileHeight;
                    vtc.TileWidth = tileConfig.TileWidth;
                    vtc.TileDesc = tileConfig.TileDesc;
                    vtc.Command = tileConfig.Command;
                    vtc.Arguments = tileConfig.Arguments;
                    vtc.WorkingPath = tileConfig.WorkingPath;
                    vtc.Order = tileConfig.Order;
                    vtc.TileRowNumber = tileConfig.TileRowNumber;
                    vtc.VRTileconfigID = tileConfig.TileconfigID;
                    vtc.ImageData = tileConfig.TileImage.ImageData;
                    vtc.AgeRequire = tileConfig.AgeRequire;
                    vtc.VideoURL = tileConfig.VideoURL;

                    m.SaveChanges();
                    //m.Cache.Release(m.VRTileconfigs);
                }

            }

            GetTileConfigList(connectionInfo, tileConfig.TileConfigSetID);
        }

        private void GetTileConfigList(ConnectionInfo connectionInfo, int tileConfigSetID)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {

                List<VRTileconfig> lvrtc = m.VRTileconfigs.Where(x => x.TileConfigSetID == tileConfigSetID && !x.IsDeleted).ToList();

                List<VRGameSelectorServerDTO.TileConfig> ltc = new List<VRGameSelectorServerDTO.TileConfig>();

                foreach (VRTileconfig item in lvrtc)
                {
                    ltc.Add(new VRGameSelectorServerDTO.TileConfig()
                    {
                        ID = item.ID,
                        TileGUID = item.TileGUID,
                        TileTitle = item.TileTitle,
                        TileHeight = item.TileHeight,
                        TileWidth = item.TileWidth,
                        TileDesc = item.TileDesc,
                        Command = item.Command,
                        Arguments = item.Arguments,
                        WorkingPath = item.WorkingPath,
                        Order = item.Order,
                        TileRowNumber = item.TileRowNumber,
                        TileConfigSetID = item.TileConfigSetID,
                        TileconfigID = item.VRTileconfigID,
                        AgeRequire = item.AgeRequire,
                        VideoURL = item.VideoURL,
                        TileImage = new VRGameSelectorServerDTO.ImageInfo(item.ImageData)
                    });
                }


                VRCommandServer vcs = new VRCommandServer(VRGameSelectorServerDTO.Enums.ControlMessage.GET_TILE_CONFIG, ltc);

                SendCommandToPeer(connectionInfo, vcs);
            }
        }

        private void ReorderUpTileConfig(ConnectionInfo connectionInfo, VRGameSelectorServerDTO.TileConfig tileConfig)
        {
            ReorderTileConfig(true, tileConfig);

            GetTileConfigList(connectionInfo, tileConfig.TileConfigSetID);
        }

        private void ReorderDownTileConfig(ConnectionInfo connectionInfo, VRGameSelectorServerDTO.TileConfig tileConfig)
        {
            ReorderTileConfig(false, tileConfig);

            GetTileConfigList(connectionInfo, tileConfig.TileConfigSetID);
        }


        private void ReorderTileConfig(bool isMovingUp, VRGameSelectorServerDTO.TileConfig tileConfig)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                VRTileconfig currentVrtc = m.VRTileconfigs.Where(x => x.ID == tileConfig.ID && !x.IsDeleted).ToList().FirstOrDefault();

                List<VRTileconfig> rootLevelVrtcs;
                List<VRTileconfig> sortedRootLevelVrtcs;
                VRTileconfig targetRootLevelVrtc;

                List<VRTileconfig> sortedSubVrtcs;
                VRTileconfig targetSubVrtc;

                if (currentVrtc != null)
                {
                    if (tileConfig.TileconfigID == 0)
                    {
                        // root level tile

                        rootLevelVrtcs = m.VRTileconfigs.Where(x => x.VRTileconfigID == 0 && x.TileConfigSetID == tileConfig.TileConfigSetID && !x.IsDeleted).ToList();
                        sortedRootLevelVrtcs = rootLevelVrtcs.OrderBy(x => x.Order).ToList();

                        if (sortedRootLevelVrtcs.Count > 1)
                        {
                            int posCurrentVrtc = sortedRootLevelVrtcs.IndexOf(currentVrtc);

                            if (posCurrentVrtc > 0 && isMovingUp)
                            {
                                targetRootLevelVrtc = sortedRootLevelVrtcs[posCurrentVrtc - 1];
                                targetRootLevelVrtc.Order++;
                                currentVrtc.Order--;
                            }
                            else if (posCurrentVrtc < sortedRootLevelVrtcs.Count - 1 && !isMovingUp)
                            {
                                targetRootLevelVrtc = sortedRootLevelVrtcs[posCurrentVrtc + 1];
                                targetRootLevelVrtc.Order--;
                                currentVrtc.Order++;
                            }
                        }
                    }
                    else
                    {
                        // sub level tile

                        VRTileconfig parentVrtc = m.VRTileconfigs.Where(x => x.ID == tileConfig.TileconfigID && !x.IsDeleted).ToList().FirstOrDefault();

                        if (parentVrtc != null && parentVrtc.VRTileconfigs.Count > 1)
                        {
                            sortedSubVrtcs = parentVrtc.VRTileconfigs.OrderBy(x => x.Order).ToList();

                            if (sortedSubVrtcs.Count > 1)
                            {
                                int posCurrentVrtc = sortedSubVrtcs.IndexOf(currentVrtc);

                                if (posCurrentVrtc > 0 && isMovingUp)
                                {
                                    targetSubVrtc = sortedSubVrtcs[posCurrentVrtc - 1];
                                    targetSubVrtc.Order++;
                                    currentVrtc.Order--;
                                }
                                else if (posCurrentVrtc < sortedSubVrtcs.Count - 1 && !isMovingUp)
                                {
                                    targetSubVrtc = sortedSubVrtcs[posCurrentVrtc + 1];
                                    targetSubVrtc.Order--;
                                    currentVrtc.Order++;
                                }
                            }
                        }

                    }

                    m.SaveChanges();
                    //m.Cache.Release(m.VRTileconfigs);
                }


            }
        }


        private void ModifyConfigSetList(ConnectionInfo connectionInfo, ConfigSet configSet)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                VRTileconfigset vcs = m.VRTileconfigsets.Where(x => x.ID == configSet.ID).FirstOrDefault();

                if (vcs != null)
                {
                    vcs.Name = configSet.Name;
                    m.SaveChanges();
                    //m.Cache.Release(m.VRTileconfigsets);
                }
            }

            GetConfigSetList(connectionInfo);
        }

        private void DeleteConfigSetList(ConnectionInfo connectionInfo, ConfigSet configSet)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                VRTileconfigset vcs = m.VRTileconfigsets.Where(x => x.ID == configSet.ID).FirstOrDefault();

                if (vcs != null)
                {
                    vcs.IsDeleted = true;
                    m.SaveChanges();
                    //m.Cache.Release(m.VRTileconfigsets);
                }

            }

            GetConfigSetList(connectionInfo);
        }

        private void AddConfigSetList(ConnectionInfo connectionInfo, ConfigSet configSet)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                VRTileconfigset vcs = new VRTileconfigset()
                {
                    Name = configSet.Name,
                    IsDeleted = false
                };

                m.Add(vcs);
                m.SaveChanges();
                //m.Cache.Release(m.VRTileconfigsets);
            }

            GetConfigSetList(connectionInfo);
        }

        private void GetConfigSetList(ConnectionInfo connectionInfo)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {

                List<VRTileconfigset> lvrcs = m.VRTileconfigsets.Where(x => !x.IsDeleted).ToList();
                List<ConfigSet> lcs = new List<ConfigSet>();

                foreach (VRTileconfigset item in lvrcs)
                {
                    lcs.Add(new ConfigSet() { ID = item.ID, Name = item.Name });
                }


                VRCommandServer vcs = new VRCommandServer(VRGameSelectorServerDTO.Enums.ControlMessage.GET_CONFIG_SET_LIST, lcs);

                SendCommandToPeer(connectionInfo, vcs);
            }
        }

        private void AddClientConfig(ConnectionInfo connectionInfo, Client client)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                VRClient vrc = new VRClient()
                {
                    IPAddress = client.IPAddress,
                    DashboardModuleIP = client.DashboardModuleIP,
                    TileConfigSetID = client.TileConfigSetID,
                    Tileconfigset = null,
                    MachineName = "",
                    VRClienthistories = null,
                    IsDeleted = false
                };

                m.Add(vrc);
                m.SaveChanges();
                //m.Cache.Release(m.VRClients);
            }

            //BuildInternalClientStatus();

            GetConfiguredClientList(connectionInfo);
        }

        private void DeleteClientConfig(ConnectionInfo connectionInfo, Client client)
        {

            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                VRClient vrc = m.VRClients.Where(x => x.ID == client.ClientID).FirstOrDefault();

                if (vrc != null)
                {
                    vrc.IsDeleted = true;
                    m.SaveChanges();
                    //m.Cache.Release(m.VRClients);
                }

            }

            //BuildInternalClientStatus();

            GetConfiguredClientList(connectionInfo);
        }

        private void ModifyClientConfig(ConnectionInfo connectionInfo, Client client)
        {
            bool isChangeConfigSetOnly = false;

            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {

                VRClient vrc = m.VRClients.Where<VRClient>(x => x.ID == client.ClientID).FirstOrDefault();

                if (vrc != null)
                {

                    if (vrc.IPAddress == client.IPAddress && vrc.DashboardModuleIP == client.DashboardModuleIP)
                    {
                        isChangeConfigSetOnly = true;
                    }
                    else
                    {
                        vrc.IPAddress = client.IPAddress;
                        vrc.DashboardModuleIP = client.DashboardModuleIP;
                    }

                    vrc.TileConfigSetID = client.TileConfigSetID;

                    m.SaveChanges();
                    //m.Cache.Release(m.VRClients);
                }

            }

            if (isChangeConfigSetOnly)
            {
                RefreshConfigSetForClient(client.ClientID, client.TileConfigSetID);
            }

            //BuildInternalClientStatus();

            GetConfiguredClientList(connectionInfo);
        }


        private void GetConfiguredClientList(ConnectionInfo connectionInfo)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {

                List<VRClient> vc = m.VRClients.Where(x => !x.IsDeleted).ToList();
                List<Client> lc = new List<Client>();

                foreach (VRClient item in vc)
                {
                    string tcsName = "";

                    if (item.Tileconfigset != null)
                    {
                        tcsName = item.Tileconfigset.Name;
                    }

                    lc.Add(new Client(item.ID, item.IPAddress, item.DashboardModuleIP, item.MachineName, item.TileConfigSetID, tcsName));
                }



                VRCommandServer vcs = new VRCommandServer(VRGameSelectorServerDTO.Enums.ControlMessage.GET_CONFIGED_CLIENT_LIST, lc);

                SendCommandToPeer(connectionInfo, vcs);
            }
        }

        private void SetHelpRequestStatus(ConnectionInfo connectionInfo, OperationInfo opInfo)
        {
            string ipAdd = ((IPEndPoint)connectionInfo.RemoteEndPoint).Address.MapToIPv4().ToString();

            InternalClientStatus ics = _internalClientStatus.Where(x => x.ClientIP == ipAdd).FirstOrDefault();

            if (ics != null)
            {
                ics.IsRequireAssistance = true;
            }

            isManageSystemPushRequired = true;

            CreateManageLog(opInfo.SourceType, VRGameSelectorServerDTO.Enums.OperationType.HELP_REQUESTED,
                                ((IPEndPoint)opInfo.ConnectionInfo.RemoteEndPoint).Address.MapToIPv4().ToString(),
                                (opInfo.ClientID != null) ? opInfo.ClientID : ics.ClientID, null, opInfo.TicketGUID, "");
        }

        private void ResetHelpRequestStatus(List<ClientParm> clientParm, OperationInfo opInfo)
        {
            foreach (ClientParm cp in clientParm)
            {
                UpdateInternalClientStatus(cp.ClientID, new InternalClientStatus()
                {
                    IsRequireAssistance = false
                });

                isManageSystemPushRequired = true;

                CreateManageLog(opInfo.SourceType, VRGameSelectorServerDTO.Enums.OperationType.HELP_REQUEST_CLEARED,
                                ((IPEndPoint)opInfo.ConnectionInfo.RemoteEndPoint).Address.MapToIPv4().ToString(),
                                (opInfo.ClientID != null) ? opInfo.ClientID : cp.ClientID, null, opInfo.TicketGUID, "");
            }
        }

        private void ResetCleaningStatus(List<ClientParm> clientParm, OperationInfo opInfo)
        {
            foreach (ClientParm cp in clientParm)
            {
                InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.ClientID == cp.ClientID).FirstOrDefault();

                if (iClientStatus != null)
                {
                    ConnectionInfo connInfo = _targetClientDaemonConnection.Where(x => ((IPEndPoint)x.RemoteEndPoint).Address.MapToIPv4().ToString() == iClientStatus.ClientIP).FirstOrDefault();

                    if (connInfo != null)
                    {
                        VRCommand vrc = new VRCommand(VRGameSelectorDTO.Enums.ControlMessage.CLEANING_PROVIDED);

                        SendCommandToPeer(connInfo, vrc);

                        CreateManageLog(opInfo.SourceType, VRGameSelectorServerDTO.Enums.OperationType.CLEAN_REQUEST_CLEARED,
                                ((IPEndPoint)opInfo.ConnectionInfo.RemoteEndPoint).Address.MapToIPv4().ToString(),
                                (opInfo.ClientID != null) ? opInfo.ClientID : cp.ClientID, null, opInfo.TicketGUID, "");

                    }
                }

            }
        }

        private void GetGamePlayHistory(ConnectionInfo connection, List<ClientParm> clientParm)
        {
            ClientParm cp = clientParm.FirstOrDefault();
            System.IO.StringWriter output = new System.IO.StringWriter();

            if (cp != null)
            {
                using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
                {
                    List<VRClienthistory> lvch = m.VRClienthistories.Where(x => x.VRClientID == cp.ClientID).OrderByDescending(y => y.ID).Take(500).ToList();

                    List<GamePlayHistory> lgph = new List<GamePlayHistory>();

                    foreach (VRClienthistory vch in lvch)
                    {
                        GamePlayHistory gph = new GamePlayHistory();

                        gph.TileID = vch.TileConfigID;
                        gph.StartTime = vch.StartTime ?? DateTime.MinValue;
                        gph.EndTime = vch.EndTime ?? DateTime.MinValue;

                        if (vch.TileConfigID != -1)
                        {
                            VRTileconfig vtc = m.VRTileconfigs.Where(x => x.ID == vch.TileConfigID).FirstOrDefault();

                            gph.TileName = (vtc != null) ? vtc.TileTitle : "ERROR!";

                        }
                        else
                        {
                            gph.TileName = "VR Game Selector Interface";
                        }

                        lgph.Add(gph);
                    }

                    VRCommandServer vrc = new VRCommandServer(VRGameSelectorServerDTO.Enums.ControlMessage.GET_GAME_PLAY_HISTORY, lgph);

                    SendCommandToPeer(connection, vrc);
                }
            }
        }

        public int GetCustomerAge(string guid)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                guid = (guid == null) ? "" : guid.Trim();

                if (guid.Length > 0)
                {
                    VRTicket vrTicket = m.VRTickets.Where(x => x.GUID == guid).FirstOrDefault();

                    if (vrTicket != null && vrTicket.WaiverLog != null)
                    {
                        if (vrTicket.WaiverLog.DOB != DateTime.MinValue)
                        {
                            double daySinceBirty = DateTime.Now.Subtract(vrTicket.WaiverLog.DOB).TotalDays;
                            int age = (int)Math.Floor(daySinceBirty / 365D);

                            return age;
                        }
                    }

                }

                return 0;
            }
        }

        private void SendStartTiming(List<ClientParm> clientParm, OperationInfo opInfo)
        {
            foreach (ClientParm cp in clientParm)
            {
                InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.ClientID == cp.ClientID).FirstOrDefault();

                if (iClientStatus != null)
                {
                    ConnectionInfo connInfo = _targetClientDaemonConnection.Where(x => ((IPEndPoint)x.RemoteEndPoint).Address.MapToIPv4().ToString() == iClientStatus.ClientIP).FirstOrDefault();

                    if (connInfo != null)
                    {
                        int duration = 0;
                        int.TryParse(cp.Parameters["Duration"], out duration);

                        UpdateInternalClientSetup(cp.ClientID, DateTime.Now, VRGameSelectorDTO.Enums.ClientRunningMode.TIMING_ON, GetCustomerAge(opInfo.TicketGUID), duration);

                        VRCommand vrc = new VRCommand(VRGameSelectorDTO.Enums.ControlMessage.START_TIMING);

                        SendCommandToPeer(connInfo, vrc);

                        CreateManageLog(opInfo.SourceType, VRGameSelectorServerDTO.Enums.OperationType.START_TIMING,
                            ((IPEndPoint)opInfo.ConnectionInfo.RemoteEndPoint).Address.MapToIPv4().ToString(),
                            (opInfo.ClientID != null) ? opInfo.ClientID : cp.ClientID, null, opInfo.TicketGUID, duration.ToString());
                    }
                }
            }
        }

        private void SendStartNow(List<ClientParm> clientParm, OperationInfo opInfo)
        {
            foreach (ClientParm cp in clientParm)
            {
                InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.ClientID == cp.ClientID).FirstOrDefault();

                if (iClientStatus != null)
                {
                    ConnectionInfo connInfo = _targetClientDaemonConnection.Where(x => ((IPEndPoint)x.RemoteEndPoint).Address.MapToIPv4().ToString() == iClientStatus.ClientIP).FirstOrDefault();

                    if (connInfo != null)
                    {
                        UpdateInternalClientSetup(cp.ClientID, DateTime.Now, VRGameSelectorDTO.Enums.ClientRunningMode.NO_TIMING_ON, GetCustomerAge(opInfo.TicketGUID));

                        VRCommand vrc = new VRCommand(VRGameSelectorDTO.Enums.ControlMessage.START_NOW);

                        SendCommandToPeer(connInfo, vrc);

                        CreateManageLog(opInfo.SourceType, VRGameSelectorServerDTO.Enums.OperationType.START_NON_TIMING,
                            ((IPEndPoint)opInfo.ConnectionInfo.RemoteEndPoint).Address.MapToIPv4().ToString(),
                            (opInfo.ClientID != null) ? opInfo.ClientID : cp.ClientID, null, opInfo.TicketGUID, "");
                    }
                }
            }
        }

        private void SendEndNow(List<ClientParm> clientParm, OperationInfo opInfo)
        {
            foreach (ClientParm cp in clientParm)
            {
                InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.ClientID == cp.ClientID).FirstOrDefault();

                if (iClientStatus != null)
                {
                    ConnectionInfo connInfo = _targetClientDaemonConnection.Where(x => ((IPEndPoint)x.RemoteEndPoint).Address.MapToIPv4().ToString() == iClientStatus.ClientIP).FirstOrDefault();

                    switch (cp.Parameters["EndMode"])
                    {
                        case "Manual":

                            UpdateInternalClientSetup(cp.ClientID, DateTime.Now, VRGameSelectorDTO.Enums.ClientRunningMode.ENDED_MANUAL);

                            break;
                        case "Timing":

                            UpdateInternalClientSetup(cp.ClientID, DateTime.Now, VRGameSelectorDTO.Enums.ClientRunningMode.ENDED_TIMING);

                            break;
                        case "Emergency":

                            UpdateInternalClientSetup(cp.ClientID, DateTime.Now, VRGameSelectorDTO.Enums.ClientRunningMode.ENDED_EMERGENCY);

                            break;
                        default:
                            break;
                    }

                    if (connInfo != null)
                    {

                        VRCommand vrc = new VRCommand(VRGameSelectorDTO.Enums.ControlMessage.END_NOW);

                        SendCommandToPeer(connInfo, vrc);

                        if (cp.Parameters["EndMode"] != "Timing")
                        {
                            CreateManageLog(opInfo.SourceType, VRGameSelectorServerDTO.Enums.OperationType.MANUAL_END,
                                ((IPEndPoint)opInfo.ConnectionInfo.RemoteEndPoint).Address.MapToIPv4().ToString(),
                                (opInfo.ClientID != null) ? opInfo.ClientID : cp.ClientID, null, opInfo.TicketGUID, cp.Parameters["EndMode"]);
                        }

                    }
                }
            }
        }

        private void SendReboot(List<ClientParm> clientParm, OperationInfo opInfo)
        {
            foreach (ClientParm cp in clientParm)
            {
                InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.ClientID == cp.ClientID).FirstOrDefault();

                if (iClientStatus != null)
                {
                    ConnectionInfo connInfo = _targetClientDaemonConnection.Where(x => ((IPEndPoint)x.RemoteEndPoint).Address.MapToIPv4().ToString() == iClientStatus.ClientIP).FirstOrDefault();

                    if (connInfo != null)
                    {
                        VRCommand vrc = new VRCommand(VRGameSelectorDTO.Enums.ControlMessage.REBOOT);

                        SendCommandToPeer(connInfo, vrc);

                        CreateManageLog(opInfo.SourceType, VRGameSelectorServerDTO.Enums.OperationType.REBOOT,
                                ((IPEndPoint)opInfo.ConnectionInfo.RemoteEndPoint).Address.MapToIPv4().ToString(),
                                (opInfo.ClientID != null) ? opInfo.ClientID : cp.ClientID, null, opInfo.TicketGUID, "");
                    }
                }
            }
        }

        private void SendTurnOff(List<ClientParm> clientParm, OperationInfo opInfo)
        {
            foreach (ClientParm cp in clientParm)
            {
                InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.ClientID == cp.ClientID).FirstOrDefault();

                if (iClientStatus != null)
                {
                    ConnectionInfo connInfo = _targetClientDaemonConnection.Where(x => ((IPEndPoint)x.RemoteEndPoint).Address.MapToIPv4().ToString() == iClientStatus.ClientIP).FirstOrDefault();

                    if (connInfo != null)
                    {
                        VRCommand vrc = new VRCommand(VRGameSelectorDTO.Enums.ControlMessage.TURN_OFF);

                        SendCommandToPeer(connInfo, vrc);

                        CreateManageLog(opInfo.SourceType, VRGameSelectorServerDTO.Enums.OperationType.TURN_OFF,
                                ((IPEndPoint)opInfo.ConnectionInfo.RemoteEndPoint).Address.MapToIPv4().ToString(),
                                (opInfo.ClientID != null) ? opInfo.ClientID : cp.ClientID, null, opInfo.TicketGUID, "");

                    }
                }
            }
        }

        private void SendTurnOffKMU(List<ClientParm> clientParm, OperationInfo opInfo)
        {
            foreach (ClientParm cp in clientParm)
            {
                InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.ClientID == cp.ClientID).FirstOrDefault();

                if (iClientStatus != null)
                {
                    ConnectionInfo connInfo = _targetClientDaemonConnection.Where(x => ((IPEndPoint)x.RemoteEndPoint).Address.MapToIPv4().ToString() == iClientStatus.ClientIP).FirstOrDefault();

                    if (connInfo != null)
                    {
                        VRCommand vrc = new VRCommand(VRGameSelectorDTO.Enums.ControlMessage.TURN_OFF_KMU);

                        SendCommandToPeer(connInfo, vrc);

                        CreateManageLog(opInfo.SourceType, VRGameSelectorServerDTO.Enums.OperationType.TURN_OFF_KMU,
                                ((IPEndPoint)opInfo.ConnectionInfo.RemoteEndPoint).Address.MapToIPv4().ToString(),
                                (opInfo.ClientID != null) ? opInfo.ClientID : cp.ClientID, null, opInfo.TicketGUID, "");

                    }
                }
            }
        }

        private void SendTurnOnKMU(List<ClientParm> clientParm, OperationInfo opInfo)
        {
            foreach (ClientParm cp in clientParm)
            {
                InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.ClientID == cp.ClientID).FirstOrDefault();

                if (iClientStatus != null)
                {
                    ConnectionInfo connInfo = _targetClientDaemonConnection.Where(x => ((IPEndPoint)x.RemoteEndPoint).Address.MapToIPv4().ToString() == iClientStatus.ClientIP).FirstOrDefault();

                    if (connInfo != null)
                    {
                        VRCommand vrc = new VRCommand(VRGameSelectorDTO.Enums.ControlMessage.TURN_ON_KMU);

                        SendCommandToPeer(connInfo, vrc);

                        CreateManageLog(opInfo.SourceType, VRGameSelectorServerDTO.Enums.OperationType.TURN_ON_KMU,
                                ((IPEndPoint)opInfo.ConnectionInfo.RemoteEndPoint).Address.MapToIPv4().ToString(),
                                (opInfo.ClientID != null) ? opInfo.ClientID : cp.ClientID, null, opInfo.TicketGUID, "");

                    }
                }
            }
        }

        private void SendLiveSystemInfoToManagingSystem(ConnectionInfo connectionInfo)
        {
            LiveSystemInfo lsi = new LiveSystemInfo();

            foreach (InternalClientStatus ics in _internalClientStatus)
            {
                TimeSpan timeLeft = new TimeSpan(0, 0, 0);

                if (ics.ClientRunningModeSetup.RunningMode == VRGameSelectorDTO.Enums.ClientRunningMode.TIMING_ON)
                {
                    timeLeft = (ics.ClientRunningModeSetup.StartTime != DateTime.MinValue) ? ics.ClientRunningModeSetup.StartTime.AddMinutes(ics.ClientRunningModeSetup.Duration).Subtract(DateTime.Now) : timeLeft;
                }
                else if (ics.ClientRunningModeSetup.RunningMode == VRGameSelectorDTO.Enums.ClientRunningMode.NO_TIMING_ON)
                {
                    timeLeft = (ics.ClientRunningModeSetup.StartTime != DateTime.MinValue) ? DateTime.Now.Subtract(ics.ClientRunningModeSetup.StartTime) : timeLeft;
                }

                lsi.LiveClientStatus.Add(new LiveClientStatus()
                {
                    ClientID = ics.ClientID,
                    ClientIP = ics.ClientIP,
                    ClientName = string.IsNullOrEmpty(ics.ClientName) ? ics.ClientIP : ics.ClientName,
                    AdditionalInfo = ics.AdditionalInfo,
                    ClientStatus = ics.ClientStatus ?? default(VRGameSelectorServerDTO.Enums.LiveClientStatus),
                    IsAssistanceRequested = ics.IsRequireAssistance ?? default(bool),
                    TimeLeft = timeLeft,
                    Mode = ics.ClientRunningModeSetup.RunningMode.ToString()
                });
            }

            VRCommandServer vcs = new VRCommandServer(VRGameSelectorServerDTO.Enums.ControlMessage.GET_LIVE_SYSTEM_INFO, lsi);

            SendCommandToPeer(connectionInfo, vcs);

        }

        public void MarkWaiverReceived(ConnectionInfo connectionInfo, List<WaiverInfo> listWaiverInfo)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                foreach (WaiverInfo wi in listWaiverInfo)
                {
                    VRWaiverLog vwl = m.VRWaiverLogs.Where(x => x.ID == wi.ID).FirstOrDefault();

                    if (vwl != null)
                    {
                        vwl.IsNewEntry = false;

                        if (vwl.BookingReference != null)
                        {
                            vwl.BookingReference.NumberOfBookingLeft -= (vwl.BookingReference.NumberOfBookingLeft == 0 ? 0 : 1);
                        }
                        else
                        {
                            VRBookingReference vbr = m.VRBookingReferences.Where(x => x.Reference == wi.BookingReference.Reference).FirstOrDefault();

                            if (vbr != null)
                            {
                                vwl.BookingReference = vbr;
                            }
                        }

                    }
                }

                m.SaveChanges();
                //m.Cache.Release(m.VRWaiverLogs);
                //m.Cache.Release(m.VRBookingReferences);
            }
        }

        private void GenerateBarcode(ConnectionInfo connectionInfo, BarcodeInfo barcodeInfo)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                if (barcodeInfo.BarcodeItems.Count > 0)
                {
                    foreach (BarcodeItem bi in barcodeInfo.BarcodeItems)
                    {
                        VRTicketType vrTT = null;
                        string ticketType = "";
                        Guid guid = Utility.CreateGuid();

                        bi.DateStampCreate = DateTime.Now;

                        if (bi.IsPrintingTicket)
                        {
                            ticketType = "TICKET";
                        }
                        else if (bi.IsPrintingKey)
                        {
                            ticketType = bi.KeyName;
                        }

                        vrTT = m.VRTicketTypes.Where(x => x.Type == ticketType).FirstOrDefault();


                        VRTicket vrt = new VRTicket()
                        {
                            GUID = guid.ToString(),
                            Minutes = bi.Minutes,
                            TimeStampCreate = bi.DateStampCreate,
                            VRTicketTypeID = (vrTT != null) ? (int?)vrTT.ID : null,
                            WaiverLogID = bi.WaiverLogID
                        };

                        //string t = Convert.ToBase64String(guid.ToByteArray()).Replace("=", "");

                        //byte[] b = Convert.FromBase64String(t + "==");

                        //var g = new Guid(b);

                        m.Add(vrt);
                        bi.GUID = guid;

                    }

                    m.SaveChanges();
                    //m.Cache.Release(m.VRTickets);

                    VRCommandServer vcs = new VRCommandServer(VRGameSelectorServerDTO.Enums.ControlMessage.GENERATE_BARCODE, barcodeInfo);

                    if (connectionInfo != null)
                    {
                        SendCommandToPeer(connectionInfo, vcs);
                    }
                    else
                    {
                        foreach (ConnectionInfo managingSysConn in _targetManagingSystemConnection)
                        {
                            SendCommandToPeer(managingSysConn, vcs);
                        }
                    }

                }

            }
        }


        private void GetKey(ConnectionInfo connectionInfo)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {

                List<VRTicket> lvrTicket = m.VRTickets.Where(x => x.VRTicketType.Type.StartsWith("KEY-") && !x.IsDeleted).ToList();
                List<KeyInfo> keyInfo = new List<KeyInfo>();

                foreach (VRTicket vrTicket in lvrTicket)
                {
                    keyInfo.Add(new KeyInfo()
                    {
                        Key = vrTicket.GUID,
                        KeyTypeID = vrTicket.VRTicketTypeID ?? 0,
                        KeyTypeName = vrTicket.VRTicketType.Type,
                        Minutes = vrTicket.Minutes,
                        CreateDate = vrTicket.TimeStampCreate
                    });
                }

                VRCommandServer vcs = new VRCommandServer(VRGameSelectorServerDTO.Enums.ControlMessage.GET_KEY, keyInfo);

                SendCommandToPeer(connectionInfo, vcs);
            }
        }

        private void DeleteKey(ConnectionInfo connectionInfo, List<KeyInfo> listKeyInfo)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                foreach (KeyInfo keyInfo in listKeyInfo)
                {
                    VRTicket vrTicket = m.VRTickets.Where(x => x.GUID == keyInfo.Key).FirstOrDefault();

                    vrTicket.IsDeleted = true;
                    vrTicket.TimeStampDelete = DateTime.Now;
                }

                m.SaveChanges();
                //m.Cache.Release(m.VRTickets);
            }

            GetKey(connectionInfo);
        }

        private void AddKey(ConnectionInfo connectionInfo, List<KeyInfo> listKeyInfo)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                BarcodeInfo bInfo = new BarcodeInfo();

                if (listKeyInfo != null)
                {
                    foreach (KeyInfo keyInfo in listKeyInfo)
                    {
                        VRTicketType vrTicketType = m.VRTicketTypes.Where(x => x.ID == keyInfo.KeyTypeID).FirstOrDefault();

                        if (vrTicketType != null)
                        {
                            BarcodeItem barcodeItem = new BarcodeItem()
                            {
                                IsPrintingKey = true,
                                KeyName = vrTicketType.Type,
                                Minutes = keyInfo.Minutes
                            };

                            bInfo.BarcodeItems.Add(barcodeItem);
                        }
                    }

                    GenerateBarcode(connectionInfo, bInfo);
                    GetKey(connectionInfo);
                }
            }

        }

        private void GetKeyType(ConnectionInfo connectionInfo)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                List<VRTicketType> lvrTicketType = m.VRTicketTypes.Where(x => x.Type.StartsWith("KEY-")).ToList();
                List<KeyTypeInfo> keyTypeInfo = new List<KeyTypeInfo>();

                foreach (VRTicketType vrTicketType in lvrTicketType)
                {
                    keyTypeInfo.Add(new KeyTypeInfo()
                    {
                        KeyTypeID = vrTicketType.ID,
                        KeyTypeName = vrTicketType.Type
                    });
                }

                VRCommandServer vcs = new VRCommandServer(VRGameSelectorServerDTO.Enums.ControlMessage.GET_KEY_TYPE, keyTypeInfo);

                SendCommandToPeer(connectionInfo, vcs);

            }
        }

        private void GetPendingWaiverList(ConnectionInfo connectionInfo)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                List<VRWaiverLog> lWaiverLog = m.VRWaiverLogs.Where(x => x.IsNewEntry == true && !x.IsDeleted).ToList();

                List<VRGameSelectorServerDTO.WaiverInfo> lwi = new List<VRGameSelectorServerDTO.WaiverInfo>();

                Dictionary<string, int> bookingNumLeftDict = new Dictionary<string, int>();

                foreach (VRWaiverLog waiverLog in lWaiverLog)
                {
                    if (waiverLog.BookingReference != null && !bookingNumLeftDict.ContainsKey(waiverLog.BookingReference.Reference))
                    {
                        bookingNumLeftDict.Add(waiverLog.BookingReference.Reference, waiverLog.BookingReference.NumberOfBookingLeft);
                    }
                }

                foreach (VRWaiverLog waiverLog in lWaiverLog)
                {
                    BookingReference bookingRef = null;

                    if (waiverLog.BookingReference != null && waiverLog.BookingReference.BookingDeleted == null && waiverLog.BookingReference.NumberOfBookingLeft > 0)
                    {
                        int bNumLeft = bookingNumLeftDict[waiverLog.BookingReference.Reference];

                        if (bNumLeft > 0)
                        {
                            bookingRef = new BookingReference()
                            {
                                ID = waiverLog.BookingReference.ID,
                                Reference = waiverLog.BookingReference.Reference,
                                IsNonTimedTiming = waiverLog.BookingReference.IsNonTimedTiming,
                                IsTimedTiming = waiverLog.BookingReference.IsTimedTiming,
                                TimeCreated = waiverLog.BookingReference.TimeStampCreate,
                                Duration = waiverLog.BookingReference.Duration,
                                NumberOfBookingLeft = waiverLog.BookingReference.NumberOfBookingLeft,
                                NumberOfBookingTotal = waiverLog.BookingReference.NumberOfBookingTotal,
                                BookingStartTime = (DateTime)waiverLog.BookingReference.BookingStartTime,
                                BookingEndTime = (DateTime)waiverLog.BookingReference.BookingEndTime
                            };

                            bookingNumLeftDict[waiverLog.BookingReference.Reference] = bNumLeft - 1;
                        }
                    }

                    lwi.Add(new VRGameSelectorServerDTO.WaiverInfo()
                    {
                        ID = waiverLog.ID,
                        FirstName = waiverLog.FirstName,
                        LastName = waiverLog.LastName,
                        Address = waiverLog.Address,
                        City = waiverLog.City,
                        Postcode = waiverLog.Postcode,
                        Province = waiverLog.Province,
                        Cell = waiverLog.Cell,
                        DOB = waiverLog.DOB,
                        Email = waiverLog.Email,
                        SignFileName = waiverLog.SignFileName,
                        TimeCreated = waiverLog.TimeStampCreate,
                        BookingReference = bookingRef
                    });
                }

                VRCommandServer vcs = new VRCommandServer(VRGameSelectorServerDTO.Enums.ControlMessage.GET_PENDING_WAIVER, lwi);

                SendCommandToPeer(connectionInfo, vcs);
            }
        }

        private void GetBookingReferenceSetting(ConnectionInfo connectionInfo, BookingReference bookingReference)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                VRBookingReference vbr = m.VRBookingReferences.Where(x => x.Reference == bookingReference.Reference && x.BookingDeleted == null && x.NumberOfBookingLeft > 0).FirstOrDefault();

                if (vbr != null)
                {
                    bookingReference.IsNonTimedTiming = vbr.IsNonTimedTiming;
                    bookingReference.IsTimedTiming = vbr.IsTimedTiming;
                    bookingReference.Duration = vbr.Duration;
                    bookingReference.NumberOfBookingLeft = vbr.NumberOfBookingLeft;
                    bookingReference.NumberOfBookingTotal = vbr.NumberOfBookingTotal;
                    bookingReference.BookingStartTime = (vbr.BookingStartTime != null) ? (DateTime)vbr.BookingStartTime : DateTime.MinValue;
                    bookingReference.BookingEndTime = (vbr.BookingEndTime != null) ? (DateTime)vbr.BookingEndTime : DateTime.MinValue;
                }
                else
                {
                    bookingReference.Reference = "";
                }

                VRCommandServer vcs = new VRCommandServer(VRGameSelectorServerDTO.Enums.ControlMessage.GET_BOOKING_REF_SETTING, bookingReference);

                SendCommandToPeer(connectionInfo, vcs);
            }
        }

        private void DeletePendingWaiver(ConnectionInfo connectionInfo, List<WaiverInfo> listWaiverInfo)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                foreach (WaiverInfo wi in listWaiverInfo)
                {
                    VRWaiverLog vwl = m.VRWaiverLogs.Where(x => x.ID == wi.ID).FirstOrDefault();

                    if (vwl != null)
                    {
                        vwl.IsDeleted = true;
                    }
                }

                m.SaveChanges();
                //m.Cache.Release(m.VRWaiverLogs);

            }

            GetPendingWaiverList(connectionInfo);
        }



        public string WaiverBarcodeGen(int waiverID)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                VRWaiverLog vrWaiverLog = m.VRWaiverLogs.Where(x => x.ID == waiverID).FirstOrDefault();

                if (vrWaiverLog != null)
                {
                    int minutes = 0;
                    string bookingRef = "";
                    if (vrWaiverLog.BookingReference != null && vrWaiverLog.BookingReference.IsTimedTiming)
                    {
                        minutes = vrWaiverLog.BookingReference.Duration;
                        bookingRef = vrWaiverLog.BookingReference.Reference;
                    }


                    BarcodeItem bItem = new BarcodeItem()
                    {
                        IsPrintingTicket = true,
                        Minutes = minutes,
                        CustomerName = vrWaiverLog.FirstName + " " + vrWaiverLog.LastName,
                        BookingReference = bookingRef,
                        WaiverLogID = vrWaiverLog.ID
                    };

                    BarcodeInfo bInfo = new BarcodeInfo();
                    bInfo.BarcodeItems.Add(bItem);

                    GenerateBarcode(null, bInfo);

                }

            }


            return "";
        }
    }
}
