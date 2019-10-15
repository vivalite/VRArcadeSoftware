using System;
using System.Collections.Generic;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using VRGameSelectorServerDTO;

namespace VRArcadeServer
{
    public partial class VRGameSelectorServer
    {
        private void HandleIncomingCommandManagingSystem(PacketHeader packetHeader, Connection connection, VRCommandServer vrCommandServer)
        {
            OperationInfo opInfo = new OperationInfo() { SourceType = Enums.SourceType.MANAGEMENT_SYSTEM, ConnectionInfo = connection.ConnectionInfo };

            switch (vrCommandServer.ControlMessage)
            {
                case VRGameSelectorServerDTO.Enums.ControlMessage.NONE:
                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.GET_SYSCONFIG:

                    GetSysConfig(connection.ConnectionInfo, vrCommandServer.SystemConfig);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.SET_SYSCONFIG:

                    SetSysConfig(vrCommandServer.SystemConfig);
                    UpdateAllClientDaemonSystemConfig();

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.GET_CONFIGED_CLIENT_LIST:

                    GetConfiguredClientList(connection.ConnectionInfo);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.MODIFY_CLIENT_CONFIG:

                    ModifyClientConfig(connection.ConnectionInfo, vrCommandServer.Client);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.ADD_CLIENT_CONFIG:

                    AddClientConfig(connection.ConnectionInfo, vrCommandServer.Client);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.DELETE_CLIENT_CONFIG:

                    DeleteClientConfig(connection.ConnectionInfo, vrCommandServer.Client);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.GET_CONFIG_SET_LIST:

                    GetConfigSetList(connection.ConnectionInfo);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.MODIFY_CONFIG_SET:

                    ModifyConfigSetList(connection.ConnectionInfo, vrCommandServer.ConfigSet);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.ADD_CONFIG_SET:

                    AddConfigSetList(connection.ConnectionInfo, vrCommandServer.ConfigSet);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.DELETE_CONFIG_SET:

                    DeleteConfigSetList(connection.ConnectionInfo, vrCommandServer.ConfigSet);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.GET_TILE_CONFIG:

                    GetTileConfigList(connection.ConnectionInfo, vrCommandServer.TileConfig.TileConfigSetID);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.MODIFY_TILE_CONFIG:

                    ModifyTileConfig(connection.ConnectionInfo, vrCommandServer.TileConfig);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.ADD_TILE_CONFIG:

                    AddTileConfig(connection.ConnectionInfo, vrCommandServer.TileConfig);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.DELETE_TILE_CONFIG:

                    DeleteTileConfig(connection.ConnectionInfo, vrCommandServer.TileConfig);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.REORDER_UP_TILE_CONFIG:

                    ReorderUpTileConfig(connection.ConnectionInfo, vrCommandServer.TileConfig);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.REORDER_DOWN_TILE_CONFIG:

                    ReorderDownTileConfig(connection.ConnectionInfo, vrCommandServer.TileConfig);

                    break;
                case Enums.ControlMessage.SYNC_TILE_CONFIG:

                    UpdateAllClientDaemonTileConfig();

                    break;
                case Enums.ControlMessage.REINIT_CLIENT_SETTING:

                    BuildInternalClientStatus();

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.GET_LIVE_SYSTEM_INFO:

                    SendLiveSystemInfoToManagingSystem(connection.ConnectionInfo);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.START_TIMING:

                    SendStartTiming(vrCommandServer.ClientParm, opInfo);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.START_NOW:

                    SendStartNow(vrCommandServer.ClientParm, opInfo);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.END_NOW:

                    SendEndNow(vrCommandServer.ClientParm, opInfo);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.REBOOT:

                    SendReboot(vrCommandServer.ClientParm, opInfo);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.TURN_OFF:

                    SendTurnOff(vrCommandServer.ClientParm, opInfo);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.TURN_OFF_KMU:

                    SendTurnOffKMU(vrCommandServer.ClientParm, opInfo);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.TURN_ON_KMU:

                    SendTurnOnKMU(vrCommandServer.ClientParm, opInfo);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.HELP_PROVIDED:

                    ResetHelpRequestStatus(vrCommandServer.ClientParm, opInfo);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.CLEANING_PROVIDED:

                    ResetCleaningStatus(vrCommandServer.ClientParm, opInfo);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.GET_GAME_PLAY_HISTORY:

                    GetGamePlayHistory(connection.ConnectionInfo, vrCommandServer.ClientParm);

                    break;
                case VRGameSelectorServerDTO.Enums.ControlMessage.GENERATE_BARCODE:

                    GenerateBarcode(connection.ConnectionInfo, vrCommandServer.BarcodeInfo);

                    break;
                case Enums.ControlMessage.GET_KEY:

                    GetKey(connection.ConnectionInfo);

                    break;
                case Enums.ControlMessage.DELETE_KEY:

                    DeleteKey(connection.ConnectionInfo, vrCommandServer.ListKeyInfo);

                    break;
                case Enums.ControlMessage.ADD_KEY:

                    AddKey(connection.ConnectionInfo, vrCommandServer.ListKeyInfo);

                    break;
                case Enums.ControlMessage.GET_KEY_TYPE:

                    GetKeyType(connection.ConnectionInfo);

                    break;
                case Enums.ControlMessage.GET_PENDING_WAIVER:

                    GetPendingWaiverList(connection.ConnectionInfo);

                    break;
                case Enums.ControlMessage.GET_BOOKING_REF_SETTING:

                    GetBookingReferenceSetting(connection.ConnectionInfo, vrCommandServer.BookingReference);

                    break;
                case Enums.ControlMessage.DELETE_PENDING_WAIVER:

                    DeletePendingWaiver(connection.ConnectionInfo, vrCommandServer.ListWaiverInfo);

                    break;
                case Enums.ControlMessage.MARK_WAIVER_RECEIVED:

                    MarkWaiverReceived(connection.ConnectionInfo, vrCommandServer.ListWaiverInfo);

                    break;
                default:
                    break;
            }




        }


    }
}
