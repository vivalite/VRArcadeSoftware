using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Tools;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using VRGameSelectorDTO;

namespace VRGameSelectorClientDaemon
{
    public partial class ClientDaemon
    {
        private void InitNetworkComms()
        {
            DataSerializer dataSerializer = DPSManager.GetDataSerializer<ProtobufSerializer>();
            List<DataProcessor> dataProcessors = new List<DataProcessor>();
            Dictionary<string, string> dataProcessorOptions = new Dictionary<string, string>();

            dataProcessors.Add(DPSManager.GetDataProcessor<SharpZipLibCompressor.SharpZipLibGzipCompressor>());
            NetworkComms.DefaultSendReceiveOptions = new SendReceiveOptions(dataSerializer, dataProcessors, dataProcessorOptions);
            NetworkComms.DefaultSendReceiveOptions.IncludePacketConstructionTime = true;
            NetworkComms.DefaultSendReceiveOptions.ReceiveHandlePriority = QueueItemPriority.AboveNormal;


            List<ConnectionListenerBase> GameSelectorUIListenList = Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Loopback, 20015)); // listen on 20015 for local UI client
            List<ConnectionListenerBase> DashboardListenList = Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Loopback, 20016)); // listen on 20016 for local Dashboard client

            GameSelectorUIListenList.ForEach(x => x.AppendIncomingPacketHandler<VRCommand>("Command", HandleIncomingCommandClientUI));
            DashboardListenList.ForEach(x => x.AppendIncomingPacketHandler<VRCommand>("Command", HandleIncomingCommandDashboard));

            NetworkComms.AppendGlobalConnectionEstablishHandler(HandleGlobalConnectionEstablished);
            NetworkComms.AppendGlobalConnectionCloseHandler(HandleGlobalConnectionClosed);

            IPEndPoint ip = IPTools.ParseEndPointFromString(Utility.GetCoreConfig("ServerIPPort"));
            _targetServerConnectionInfo = new ConnectionInfo(ip, ApplicationLayerProtocolStatus.Enabled);

        }


        private void HandleGlobalConnectionClosed(Connection connection)
        {
            OnConnectionStateChange(null, null);
        }

        // once connection established, setup target connection info
        private void HandleGlobalConnectionEstablished(Connection connection)
        {
            if (connection.ConnectionInfo.ServerSide)
            {
                // a connection established by client
                IPEndPoint ep = (IPEndPoint)connection.ConnectionInfo.LocalEndPoint;

                switch (ep.Port)
                {
                    case 20015: // UI

                        _targetUIClientConnectionInfo = connection.ConnectionInfo;

                        break;

                    case 20016: // Dashboard

                        _targetDashboardClientConnectionInfo = connection.ConnectionInfo;

                        break;

                    default:
                        break;
                }
            }
            else
            {
                // out going connection to server
                connection.AppendIncomingPacketHandler<VRCommand>("Command", HandleIncomingServer);
                _targetServerConnectionInfo = connection.ConnectionInfo;

            }

            OnConnectionStateChange(null, null);

        }


        private void SendPingToServer()
        {
            VRCommand vrc = new VRCommand(Enums.ControlMessage.NONE);

            SendCommandToServer(vrc);

        }

        // generic method to send command object to server
        private Task SendCommandToServer(VRCommand cmdObj)
        {
            return Task.Run(() =>
            {
                try
                {
                    cmdObj.MachineName = System.Environment.MachineName;
                    cmdObj.LiveClientStatus = _internalCurrentClientStatus;
                    cmdObj.AdditionalInfo = _internalAdditionalInfo;
                    TCPConnection conn = TCPConnection.GetConnection(_targetServerConnectionInfo);

                    conn.SendObject("Command", cmdObj);


                }
                catch (Exception ex)
                {
                    logger.Info("SendCommandToServer" + ex.ToString());
                }


            });

        }

        // generic method to send command object to client (UI)
        private Task SendCommandToUIClient(VRCommand cmdObj)
        {
            return Task.Run(() =>
            {
                try
                {
                    TCPConnection conn = TCPConnection.GetConnection(_targetUIClientConnectionInfo);

                    conn.SendObject("Command", cmdObj);


                }
                catch (Exception ex)
                {
                    logger.Info("SendCommandToUIClient" + ex.ToString());
                }


            });

        }

        // generic method to send command object to client (Dashboard)
        private Task SendCommandToDashboardClient(VRCommand cmdObj)
        {
            return Task.Run(() =>
            {
                try
                {
                    TCPConnection conn = TCPConnection.GetConnection(_targetDashboardClientConnectionInfo);

                    conn.SendObject("Command", cmdObj);


                }
                catch (Exception ex)
                {
                    logger.Info("SendCommandToDashboardClient" + ex.ToString());
                }


            });

        }

    }
}
