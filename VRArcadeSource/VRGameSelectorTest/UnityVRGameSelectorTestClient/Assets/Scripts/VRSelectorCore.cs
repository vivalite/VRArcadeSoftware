using UnityEngine;
using UnityEngine.UI;
using System;
using System.Xml;
using System.Net;
using System.Collections.Generic;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Tools;

using NetworkCommsDotNet.Connections.TCP;

using VRGameSelectorDTO;
using System.Collections;

public class VRSelectorCore : MonoBehaviour
{

    public TextAsset ConfigFile;
    private Dictionary<string, string> SystemConfigs;
    private static ConnectionInfo targetServerConnectionInfo;
    private string infoText;

    private SendToServerJob sendToServerJob;


    private void Awake()
    {
        InitCoreConfig();

        InitConnection();

        InvokeRepeating("SendPingToServer", 0, 4); // send ping to server every 4 seconds

        
    }


    private void InitConnection()
    {
        string serverAddress;

        DataSerializer dataSerializer = DPSManager.GetDataSerializer<ProtobufSerializer>();
        List<DataProcessor> dataProcessors = new List<DataProcessor>();
        Dictionary<string, string> dataProcessorOptions = new Dictionary<string, string>();
        dataProcessors.Add(DPSManager.GetDataProcessor<QuickLZCompressor.QuickLZ>());

        NetworkComms.DefaultSendReceiveOptions = new SendReceiveOptions(dataSerializer, dataProcessors, dataProcessorOptions);
        NetworkComms.DefaultSendReceiveOptions.IncludePacketConstructionTime = true;
        NetworkComms.DefaultSendReceiveOptions.ReceiveHandlePriority = QueueItemPriority.AboveNormal;

        NetworkComms.AppendGlobalIncomingPacketHandler<VRCommand>("Command", HandleIncomingCommand);

        SystemConfigs.TryGetValue("ServerIPPort", out serverAddress); // get IP:Port

        IPEndPoint ip = IPTools.ParseEndPointFromString(serverAddress);
        targetServerConnectionInfo = new ConnectionInfo(ip, ApplicationLayerProtocolStatus.Enabled);

    }

    private void SendPingToServer()
    {
        Text nettext = (Text)GameObject.Find("txtNetworkStatus").GetComponent(typeof(Text));

        sendToServerJob = new SendToServerJob();
        sendToServerJob.connectionInfo = targetServerConnectionInfo;
        sendToServerJob.isPingOnly = true;
        sendToServerJob.textComponent = nettext;
        sendToServerJob.Start();

        StartCoroutine(CheckSendToServerState());

    }

    IEnumerator CheckSendToServerState()
    {
        yield return StartCoroutine(sendToServerJob.WaitFor());
    }

    // all incoming command are handled here
    private void HandleIncomingCommand(PacketHeader packetHeader, Connection connection, VRCommand vrCommand)
    {
        switch (vrCommand.ControlMessage)
        {
            case Enums.ControlMessage.LOAD_CONFIG:

                infoText = "Received Tile Config from " + connection + Environment.NewLine +
                    "Length of tileConfig: " + vrCommand.TileConfig.MainScreenTiles.Count.ToString();

                break;

            case Enums.ControlMessage.START_NOW:

                infoText = "START NOW Command Received.";

                break;

            case Enums.ControlMessage.END_NOW:

                infoText = "END NOW Command Received, message: '" + vrCommand.EndNow.Message + "'";

                break;

            case Enums.ControlMessage.TURN_OFF:

                infoText = "TURN OFF Command Received.";

                break;

            default:
                break;
        }


    }

    // send client UI ready
    public void SendClientUIReady()
    {
        VRCommand cmd = new VRCommand(Enums.ControlMessage.CLIENT_UI_READY);
        SendCommandToServer(cmd);
    }

    // send play log
    public void SendPlayLog()
    {
        PlayLog playLog = new PlayLog("A2", Enums.PlayLogSignalType.Start);

        VRCommand cmd = new VRCommand(playLog);
        SendCommandToServer(cmd);
    }

    // get configuration from server
    public void GetConfiguration()
    {
        VRCommand cmd = new VRCommand(Enums.ControlMessage.LOAD_CONFIG);
        SendCommandToServer(cmd);

    }


    // generic method to send command object to server
    private void SendCommandToServer(VRCommand cmdObj)
    {

        SendToServerJob ssj = new SendToServerJob();
        ssj.connectionInfo = targetServerConnectionInfo;
        ssj.command = cmdObj;
        ssj.Start();

    }

    // this method reads the configuration file to SystemConfigs
    private void InitCoreConfig()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(ConfigFile.text);
        XmlNodeList systemList = xmlDoc.GetElementsByTagName("System");

        SystemConfigs = new Dictionary<string, string>();

        foreach (XmlNode systemNode in systemList)
        {
            foreach (XmlNode configNode in systemNode.ChildNodes)
            {
                SystemConfigs.Add(configNode.Name, configNode.InnerText);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

        Text nettext = (Text)GameObject.Find("txtInfo").GetComponent(typeof(Text));

        nettext.text = infoText;


        //if(sendToServerJob != null) // use Coroutine instead....
        //{
        //    if(sendToServerJob.Update())
        //    {
        //        sendToServerJob = null;
        //    }
        //}


    }

    

    // This function is called when the MonoBehaviour will be destroyed
    private void OnDestroy()
    {
        NetworkComms.Shutdown();
    }


}
