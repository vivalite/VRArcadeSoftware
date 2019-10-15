using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System.Linq;
using System.Net;
using VRGameSelectorDTO;

namespace VRArcadeServer
{
    public partial class VRGameSelectorServer
    {
        private void HandleIncomingCommandClientDaemon(PacketHeader packetHeader, Connection connection, VRCommand vrCommand)
        {
            switch (vrCommand.ControlMessage)
            {
                case VRGameSelectorDTO.Enums.ControlMessage.NONE:

                    HandleClientDaemonPing(connection.ConnectionInfo);

                    break;
                case VRGameSelectorDTO.Enums.ControlMessage.GET_ALL_SYSCONFIG:

                    ClientSetAllSysConfig(connection.ConnectionInfo);

                    break;
                case VRGameSelectorDTO.Enums.ControlMessage.GET_ALL_TILE_CONFIG:

                    if (CheckAbleToSendAllTileConfig(connection.ConnectionInfo))
                    {
                        ClientSetAllTileConfig(connection.ConnectionInfo);
                    }

                    break;
                case Enums.ControlMessage.GET_ALL_TILE_CONFIG_WITH_IMAGE:

                    if (CheckAbleToSendAllTileConfig(connection.ConnectionInfo))
                    {
                        ClientSetAllTileConfigWithImage(connection.ConnectionInfo);
                    }

                    break;
                case VRGameSelectorDTO.Enums.ControlMessage.START_TIMING:
                    break;
                case VRGameSelectorDTO.Enums.ControlMessage.START_NOW:
                    break;
                case VRGameSelectorDTO.Enums.ControlMessage.END_NOW:
                    break;
                case VRGameSelectorDTO.Enums.ControlMessage.TURN_OFF:
                    break;
                case VRGameSelectorDTO.Enums.ControlMessage.STATUS:

                    ClientSetRunningMode(connection.ConnectionInfo);

                    break;
                case VRGameSelectorDTO.Enums.ControlMessage.LOAD_CONFIG:
                    break;
                case VRGameSelectorDTO.Enums.ControlMessage.PLAY_LOG:

                    ProcessPlayLog(connection.ConnectionInfo, vrCommand.PlayLog);

                    break;
                case VRGameSelectorDTO.Enums.ControlMessage.CLIENT_UI_READY:
                    break;
                case VRGameSelectorDTO.Enums.ControlMessage.REQUEST_HELP:

                    OperationInfo opInfo = new OperationInfo() { SourceType = VRGameSelectorServerDTO.Enums.SourceType.CLIENT, ConnectionInfo = connection.ConnectionInfo };
                    SetHelpRequestStatus(connection.ConnectionInfo, opInfo);

                    break;
                default:
                    break;
            }

            IPEndPoint ep = (IPEndPoint)connection.ConnectionInfo.RemoteEndPoint;

            string ipAdd = ep.Address.MapToIPv4().ToString();
            string machineName = (vrCommand.MachineName != null) ? vrCommand.MachineName : "";

            InternalClientStatus iClientStatus = _internalClientStatus.Where(x => x.ClientIP == ipAdd).FirstOrDefault();

            if (iClientStatus != null && (iClientStatus.ClientName != machineName || iClientStatus.ClientStatus != (VRGameSelectorServerDTO.Enums.LiveClientStatus)vrCommand.LiveClientStatus))
            {
                UpdateInternalClientStatus(ipAdd, machineName, vrCommand.LiveClientStatus, vrCommand.AdditionalInfo);
                isManageSystemPushRequired = true;
            }



        }
    }
}
