using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using System.Linq;
using VRGameSelectorDTO;

namespace VRGameSelectorClientDaemon
{
    public partial class ClientDaemon
    {
        // incomming vr command for game selector client UI
        private void HandleIncomingCommandClientUI(PacketHeader packetHeader, Connection connection, VRCommand vrCommand)
        {
            switch (vrCommand.ControlMessage)
            {
                case Enums.ControlMessage.PLAY_LOG:

                    Tile playTile = _internalTileConfig.MainScreenTiles.Where(x => x.TileID == vrCommand.PlayLog.TileID).FirstOrDefault();

                    if (playTile != null)
                    {
                        _internalCurrentPlayingTile = playTile;
                    }
                    else
                    {
                        foreach (Tile tile in _internalTileConfig.MainScreenTiles)
                        {
                            if (tile.ChildTiles != null)
                            {
                                playTile = tile.ChildTiles.Where(x => x.TileID == vrCommand.PlayLog.TileID).FirstOrDefault();

                                if (playTile != null)
                                {
                                    _internalCurrentPlayingTile = playTile;
                                }
                            }
                        }
                    }

                    break;

                case Enums.ControlMessage.LOAD_CONFIG:

                    SetClientUITileConfig();

                    break;

                case Enums.ControlMessage.CLIENT_UI_READY:

                    if (_internalCurrentClientStatus == Enums.LiveClientStatus.GAMEOVER_FOR_CLEANING || _internalCurrentClientStatus == Enums.LiveClientStatus.CLEANING_DONE)
                    {
                        VRCommand cmd = new VRCommand(new EndNow(Utility.GetSystemConfig(_internalEndGameMessageConfigType) ?? "Your Time is up. Thanks for playing!"));
                        SendCommandToUIClient(cmd);
                    }

                    _isGameSelectorInitDone = true;


                    break;

                default:
                    break;
            }

            _targetUIClientLastCommunicationTime = DateTime.Now;

        }
    }
}
