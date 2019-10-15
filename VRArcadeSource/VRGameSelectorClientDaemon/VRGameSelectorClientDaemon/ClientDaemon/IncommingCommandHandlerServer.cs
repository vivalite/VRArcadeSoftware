using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using VRGameSelectorDTO;

namespace VRGameSelectorClientDaemon
{
    public partial class ClientDaemon
    {
        // Incomming message from server
        private void HandleIncomingServer(PacketHeader packetHeader, Connection connection, VRCommand vrCommand)
        {
            switch (vrCommand.ControlMessage)
            {
                case Enums.ControlMessage.NONE:
                    break;
                case Enums.ControlMessage.GET_ALL_SYSCONFIG:

                    SetAllSysConfigFromServer(vrCommand.SystemConfig);

                    break;
                case Enums.ControlMessage.GET_ALL_TILE_CONFIG:

                    SetAllTileConfigFromServer(vrCommand.TileConfig);
                    SetClientUITileConfig();

                    break;
                case Enums.ControlMessage.START_TIMING:

                    GetClientStatusFromServer();

                    break;
                case Enums.ControlMessage.START_NOW:

                    GetClientStatusFromServer();

                    break;
                case Enums.ControlMessage.END_NOW:

                    GetClientStatusFromServer();

                    break;
                case Enums.ControlMessage.TURN_OFF:

                    TurnOffComputer();

                    break;
                case Enums.ControlMessage.REBOOT:

                    RebootComputer();

                    break;
                case Enums.ControlMessage.STATUS:

                    SetClientCurrentRunningMode(vrCommand.ClientStatus);

                    break;
                case Enums.ControlMessage.LOAD_CONFIG:
                    break;
                case Enums.ControlMessage.PLAY_LOG:
                    break;
                case Enums.ControlMessage.CLIENT_UI_READY:
                    break;
                case Enums.ControlMessage.REQUEST_HELP:
                    break;
                case Enums.ControlMessage.CLEANING_PROVIDED:

                    SetCleaningProvided();

                    break;
                case Enums.ControlMessage.TURN_OFF_KMU:

                    TurnOffKUM();

                    break;
                case Enums.ControlMessage.TURN_ON_KMU:

                    TurnOnKUM();

                    break;
                default:
                    break;
            }
        }

    }
}
