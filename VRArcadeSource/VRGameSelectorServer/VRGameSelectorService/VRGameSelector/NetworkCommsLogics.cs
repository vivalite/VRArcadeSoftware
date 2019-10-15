using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.Connections.UDP;
using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Tools;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using VRGameSelectorDTO;
using VRGameSelectorServerDTO;

namespace VRArcadeServer
{
    public partial class VRGameSelectorServer
    {
        private void InitNetworkComms()
        {
            _targetClientDaemonConnection = new List<ConnectionInfo>();
            _targetManagingSystemConnection = new List<ConnectionInfo>();

            DataSerializer dataSerializer = DPSManager.GetDataSerializer<ProtobufSerializer>();
            List<DataProcessor> dataProcessors = new List<DataProcessor>();
            Dictionary<string, string> dataProcessorOptions = new Dictionary<string, string>();

            SendReceiveOptions noCompressionSRO = new SendReceiveOptions(dataSerializer, new List<DataProcessor>(), dataProcessorOptions);

            //dataProcessors.Add(DPSManager.GetDataProcessor<QuickLZCompressor.QuickLZ>());
            dataProcessors.Add(DPSManager.GetDataProcessor<SharpZipLibCompressor.SharpZipLibGzipCompressor>());
            NetworkComms.DefaultSendReceiveOptions = new SendReceiveOptions(dataSerializer, dataProcessors, dataProcessorOptions);
            NetworkComms.DefaultSendReceiveOptions.IncludePacketConstructionTime = true;
            NetworkComms.DefaultSendReceiveOptions.ReceiveHandlePriority = QueueItemPriority.AboveNormal;

            List<ConnectionListenerBase> ClientDaemonListenList = Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Any, 20018)); // listen on 20018 for client daemon
            List<ConnectionListenerBase> ManagingSystemListenList = Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Any, 20019)); // listen on 20019 for managing system

            ClientDaemonListenList.ForEach(x => x.AppendIncomingPacketHandler<VRCommand>("Command", HandleIncomingCommandClientDaemon));
            ManagingSystemListenList.ForEach(x => x.AppendIncomingPacketHandler<VRCommandServer>("Command", HandleIncomingCommandManagingSystem));


            NetworkComms.AppendGlobalConnectionEstablishHandler(HandleClientConnectionEstablished);
            NetworkComms.AppendGlobalConnectionCloseHandler(HandleClientConnectionClosed);

            NetworkComms.ConnectionListenModeUseSync = true;


        }

        private void HandleClientConnectionEstablished(Connection connection)
        {
            IPEndPoint ep = (IPEndPoint)connection.ConnectionInfo.LocalEndPoint;

            switch (ep.Port)
            {

                case 20018: // Client Daemon

                    if (_targetClientDaemonConnection.Find(x => ((IPEndPoint)x.LocalEndPoint).Address == ep.Address) == null)
                    {
                        _targetClientDaemonConnection.Add(connection.ConnectionInfo);
                    }


                    break;

                case 20019: // Managing System

                    if (_targetManagingSystemConnection.Find(x => ((IPEndPoint)x.LocalEndPoint).Address == ep.Address) == null)
                    {
                        _targetManagingSystemConnection.Add(connection.ConnectionInfo);
                    }
                    break;

                default:
                    break;
            }

            isManageSystemPushRequired = true;
        }

        private void HandleClientConnectionClosed(Connection connection)
        {
            IPEndPoint ep = (IPEndPoint)connection.ConnectionInfo.LocalEndPoint;

            switch (ep.Port)
            {

                case 20018: // Client Daemon

                    string ipAdd = ep.Address.MapToIPv4().ToString();

                    _targetClientDaemonConnection.Remove(connection.ConnectionInfo);
                    UpdateInternalClientStatus(ipAdd, VRGameSelectorDTO.Enums.LiveClientStatus.OFFLINE);

                    isManageSystemPushRequired = true;

                    break;

                case 20019: // ManagingSystem

                    _targetManagingSystemConnection.Remove(connection.ConnectionInfo);

                    break;

                default:
                    break;
            }
        }

        // generic method to send command object to ManageSystem
        private Task SendCommandToPeer(ConnectionInfo connectionInfo, object cmdObj)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (connectionInfo.ConnectionType == ConnectionType.TCP)
                    {
                        TCPConnection conn = TCPConnection.GetConnection(connectionInfo);
                        conn.SendObject("Command", cmdObj);
                    }
                    else if (connectionInfo.ConnectionType == ConnectionType.UDP)
                    {
                        UDPConnection conn = UDPConnection.GetConnection(connectionInfo, UDPOptions.None);
                        conn.SendObject("Command", cmdObj);
                    }


                }
                catch (Exception ex)
                {
                    logger.Info("SendCommandToPeer: Remote[" + connectionInfo.RemoteEndPoint.ToString() + "] Local[" + connectionInfo.LocalEndPoint.ToString() + "] TypeofcmdObj[" + cmdObj.GetType().ToString() + "] Error:" + ex.ToString());
                }
            });
        }



    }
}
