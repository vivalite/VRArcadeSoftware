using NetworkCommsDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using VRGameSelectorDTO;
using VRGameSelectorServerDB;

namespace VRArcadeServer
{
    public partial class VRGameSelectorServer
    {
        private void HandleClientDaemonPing(ConnectionInfo connectionInfo)
        {
            string ipAdd = ((IPEndPoint)connectionInfo.RemoteEndPoint).Address.MapToIPv4().ToString();
            UpdateInternalClientStatus(ipAdd);
        }

        private void UpdateAllClientDaemonSystemConfig()
        {
            foreach (ConnectionInfo ci in _targetClientDaemonConnection)
            {
                ClientSetAllSysConfig(ci);
            }
        }

        private void ClientSetAllSysConfig(ConnectionInfo connectionInfo)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {

                List<SysConfig> lsc = new List<SysConfig>();

                List<VRConfiguration> sysConfig = m.VRConfigurations.ToList();


                foreach (VRConfiguration vrc in sysConfig)
                {
                    lsc.Add(new SysConfig((VRGameSelectorDTO.Enums.SysConfigType)Enum.Parse(typeof(VRGameSelectorDTO.Enums.SysConfigType), vrc.Type, true), vrc.Value));
                }

                VRCommand vcs = new VRCommand(VRGameSelectorDTO.Enums.ControlMessage.GET_ALL_SYSCONFIG, lsc);

                SendCommandToPeer(connectionInfo, vcs);

            }

        }

        private void ProcessPlayLog(ConnectionInfo connectionInfo, PlayLog playLog)
        {
            string ipAdd = ((IPEndPoint)connectionInfo.RemoteEndPoint).Address.MapToIPv4().ToString();

            InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.ClientIP == ipAdd).FirstOrDefault();

            if (iClientStatus != null)
            {
                int tileID = 0;

                int.TryParse(playLog.TileID, out tileID);

                using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
                {

                    VRTileconfig vtc = m.VRTileconfigs.Where(x => x.ID == tileID && !x.IsDeleted).FirstOrDefault();
                    VRClienthistory vrh = new VRClienthistory();

                    vrh.VRClientID = iClientStatus.ClientID;

                    if (tileID == -1)
                    {
                        vrh.TileConfigID = -1;
                    }
                    else
                    {
                        vrh.TileConfigID = (vtc != null) ? vtc.ID : 0;
                    }

                    if (playLog.SignalType == VRGameSelectorDTO.Enums.PlayLogSignalType.Start)
                    {
                        // start game
                        if (tileID > 0)
                        {
                            string imagePath = (vtc.ImageData.Length > 0) ? vtc.ID.ToString() + ".bmp" : ""; // full path will be decided on client end
                            VRGameSelectorDTO.ImageInfo ii = new VRGameSelectorDTO.ImageInfo(vtc.ImageData);
                            VRGameSelectorDTO.Tile tileConfig = new Tile(vtc.TileHeight, vtc.TileWidth, vtc.TileRowNumber, vtc.ID.ToString(), vtc.TileTitle, imagePath, vtc.TileDesc, vtc.Command, vtc.Arguments, vtc.WorkingPath, ii, vtc.AgeRequire, vtc.VideoURL);

                            iClientStatus.ClientRunningModeSetup.TileConfig = tileConfig;
                        }

                        iClientStatus.ClientRunningModeSetup.CurrentRunningTileID = tileID;

                        vrh.StartTime = DateTime.Now;
                    }
                    else
                    {
                        // end game
                        iClientStatus.ClientRunningModeSetup.CurrentRunningTileID = 0;
                        iClientStatus.ClientRunningModeSetup.TileConfig = null;

                        vrh.EndTime = DateTime.Now;
                    }

                    m.Add(vrh);
                    m.SaveChanges();
                    //m.Cache.Release(m.VRClienthistories);
                }

            }
        }

        private void ClientSetRunningMode(ConnectionInfo connectionInfo)
        {
            string ipAdd = ((IPEndPoint)connectionInfo.RemoteEndPoint).Address.MapToIPv4().ToString();

            InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.ClientIP == ipAdd).FirstOrDefault();

            if (iClientStatus != null)
            {
                VRCommand vrc = new VRCommand(iClientStatus.ClientRunningModeSetup);

                SendCommandToPeer(connectionInfo, vrc);
            }


        }

        private void UpdateAllClientDaemonTileConfig()
        {
            foreach (ConnectionInfo ci in _targetClientDaemonConnection)
            {
                ClientSetAllTileConfig(ci);
            }
        }

        private bool CheckAbleToSendAllTileConfig(ConnectionInfo connectionInfo)
        {
            string ipAdd = ((IPEndPoint)connectionInfo.RemoteEndPoint).Address.MapToIPv4().ToString();

            InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.ClientIP == ipAdd).FirstOrDefault();

            if (iClientStatus != null)
            {
                if (iClientStatus.LastTileConfigDownloadTimestamp == DateTime.MinValue)
                {
                    iClientStatus.LastTileConfigDownloadTimestamp = DateTime.Now.Subtract(TimeSpan.FromSeconds(1f));
                }

                double secDiff = DateTime.Now.Subtract(iClientStatus.LastTileConfigDownloadTimestamp).TotalSeconds;
                secDiff = (secDiff > 60) ? 60 : secDiff;
                double chance = secDiff / 60;
                double numGen = _rand.NextDouble();

                if (numGen <= chance)
                {
                    iClientStatus.LastTileConfigDownloadTimestamp = DateTime.Now;
                    return true;
                }

            }

            return false;
        }

        private void ClientSetAllTileConfigWithImage(ConnectionInfo connectionInfo)
        {
            ClientSetAllTileConfig(connectionInfo, true);
        }

        private void ClientSetAllTileConfig(ConnectionInfo connectionInfo, bool withImage = false)
        {
            using (VRArcadeDataAccessModel m = new VRArcadeDataAccessModel())
            {
                string ipAdd = ((IPEndPoint)connectionInfo.RemoteEndPoint).Address.MapToIPv4().ToString();

                InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.ClientIP == ipAdd).FirstOrDefault();

                VRClient vrc = m.VRClients.Where(x => x.IPAddress == ipAdd && !x.IsDeleted).FirstOrDefault();

                if (vrc != null)
                {
                    List<VRTileconfig> lvrt0 = m.VRTileconfigs.Where(x => x.TileConfigSetID == vrc.TileConfigSetID && x.VRTileconfigID == 0 && !x.IsDeleted).ToList(); // root level

                    if (lvrt0 != null)
                    {
                        VRGameSelectorDTO.TileConfig tc = new VRGameSelectorDTO.TileConfig();

                        foreach (VRTileconfig vrt in lvrt0) // first process root level
                        {
                            string imagePath = (vrt.ImageData.Length > 0) ? vrt.ID.ToString() + ".bmp" : ""; // full path will be decided on client end

                            if (withImage)
                            {
                                GetType();
                            }

                            VRGameSelectorDTO.ImageInfo ii = new VRGameSelectorDTO.ImageInfo(vrt.ImageData, !withImage);

                            Tile t = new Tile(vrt.TileHeight, vrt.TileWidth, vrt.TileRowNumber, vrt.ID.ToString(), vrt.TileTitle, imagePath, vrt.TileDesc, vrt.Command, vrt.Arguments, vrt.WorkingPath, ii, vrt.AgeRequire, vrt.VideoURL);

                            tc.MainScreenTiles.Add(t);
                        }

                        List<VRTileconfig> lvrt1 = m.VRTileconfigs.Where(x => x.TileConfigSetID == vrc.TileConfigSetID && x.VRTileconfigID != 0 && !x.IsDeleted).ToList(); // sub level

                        if (lvrt1 != null)
                        {
                            foreach (VRTileconfig vrt in lvrt1)
                            {
                                Tile targetVrt = tc.MainScreenTiles.Where(x => x.TileID == vrt.VRTileconfigID.ToString()).FirstOrDefault();

                                if (targetVrt != null)
                                {
                                    string imagePath = (vrt.ImageData.Length > 0) ? vrt.ID.ToString() + ".bmp" : ""; // full path will be decided on client end

                                    VRGameSelectorDTO.ImageInfo ii = new VRGameSelectorDTO.ImageInfo(vrt.ImageData, !withImage);


                                    Tile t = new Tile(vrt.TileHeight, vrt.TileWidth, vrt.TileRowNumber, vrt.ID.ToString(), vrt.TileTitle, imagePath, vrt.TileDesc, vrt.Command, vrt.Arguments, vrt.WorkingPath, ii, vrt.AgeRequire, vrt.VideoURL);

                                    targetVrt.ChildTiles.Add(t);
                                }
                            }
                        }



                        VRCommand vcs = new VRCommand(VRGameSelectorDTO.Enums.ControlMessage.GET_ALL_TILE_CONFIG, tc);

                        SendCommandToPeer(connectionInfo, vcs);

                        if (iClientStatus != null)
                        {
                            iClientStatus.LastTileConfigDownloadTimestamp = DateTime.Now;
                        }

                    }
                }

            }
        }


    }
}
