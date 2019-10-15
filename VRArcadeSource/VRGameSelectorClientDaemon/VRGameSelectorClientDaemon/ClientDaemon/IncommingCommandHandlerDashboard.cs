using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using System.Diagnostics;
using VRGameSelectorDTO;

namespace VRGameSelectorClientDaemon
{
    public partial class ClientDaemon
    {
        // incomming vr command for game selector Dashboard
        private void HandleIncomingCommandDashboard(PacketHeader packetHeader, Connection connection, VRCommand vrCommand)
        {

            switch (vrCommand.ControlMessage)
            {
                case Enums.ControlMessage.REQUEST_HELP:

                    Debug.WriteLine(connection.ToString() + " Help Requested!");

                    VRCommand cmd = new VRCommand(Enums.ControlMessage.REQUEST_HELP);

                    SendCommandToServer(cmd);

                    break;
                case Enums.ControlMessage.UNITY_DASHBOARD_EXITGAME:

                    Debug.WriteLine(connection.ToString() + " ExitGame Received!");

                    if (_internalCurrentClientStatus == Enums.LiveClientStatus.IN_GAME)
                    {
                        _exitGameFlag = true;
                    }

                    break;
                case Enums.ControlMessage.UNITY_DASHBOARD_GETRUNNINGGAMES:

                    Debug.WriteLine(connection.ToString() + " Running Games Result incoming!");

                    break;
                case Enums.ControlMessage.UNITY_DASHBOARD_GETTIMELEFT:

                    Debug.WriteLine(connection.ToString() + " Get Time Left!");

                    break;
                case Enums.ControlMessage.UNITY_DASHBOARD_VOLUMEUP:

                    Debug.WriteLine(connection.ToString() + " Volume Up Received!");

                    VolumeControl("UP");

                    break;
                case Enums.ControlMessage.UNITY_DASHBOARD_VOLUMEDOWN:

                    Debug.WriteLine(connection.ToString() + " Volume Down Requested!");

                    VolumeControl("DOWN");

                    break;

            }

            _targetDashboardClientLastCommunicationTime = DateTime.Now;
        }
    }
}
