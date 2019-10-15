using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using UnityEngine;
using VGS;
using VRGameSelectorDTO;
using util.commom;
using util.constants;
using Valve.VR;

public struct ReceivedMessageEventArg
{
    public string message;
}

public enum Game_State
{
    None = 0,
    Start,
    LoadConfig,
    ConfigLoaded,
    LoadingGame,
    PlayGame,
    HelpState,
    EndGame,
}
public delegate void ReceivedMessageEnventHandler(object sender, ReceivedMessageEventArg message);

public class VRSelectorCore : MonoBehaviour
{
    public static VRSelectorCore Instance;

    public Transform m_View;
    public TextAsset ConfigFile;
    public GameObject m_TilePrefab;
    public Transform m_TileParent;
    public BackButton m_BtnBack;
    public GameObject m_TxtEnd;
    public SteamVR_ControllerManager m_CameraRig;

    private List<TilePane>[] tilePanes = new List<TilePane>[4];
    private List<Tile>[] rowTiles = new List<Tile>[4];
    private Dictionary<string, string> SystemConfigs;
    private static ConnectionInfo targetServerConnectionInfo;
    private SendToServerJob sendToServerJob;
    private int[] rowHeight = new int[4];
    private bool m_bGameEnded = false;
    private bool isCoroutineExecuting = false;
    private TextMesh mTxtEndComponent;
    private string s_endMessage;

    const float TileSpace = 0.05f;
    const float TileRate = 0.002f;

    /// <summary>
    /// ///////////////////    
    public bool bCurrentSelectedAnyTile = false;
    private GameObject m_helpTile;
    private bool m_bHelp = false;

    private GameObject m_playGamePane;
    public GameObject m_playVideoPane;

    public GameObject m_loadingPane;

    private Game_State m_gameState = Game_State.None;

    #region EVENT_HANDLER   

    public event ReceivedMessageEnventHandler ReceivedStartMessage;
    public event ReceivedMessageEnventHandler ReceivedTileConfigMessage;
    public event ReceivedMessageEnventHandler ReceivedEndMessage;
    public event ReceivedMessageEnventHandler ReceivedHelpMessage;

    #endregion

    private void Awake()
    {
        InitCoreConfig();
        InitConnection();
        //InvokeRepeating("SendPingToServer", 0, 4); // send ping to server every 4 seconds
        StartCoroutine(Timing4SCoroutine());

        for (int i = 0; i < 4; i++)
        {
            rowTiles[i] = new List<Tile>();
            tilePanes[i] = new List<TilePane>();
        }

        Instance = this;
        m_BtnBack.gameObject.SetActive(false);
        m_TxtEnd.SetActive(false);

        mTxtEndComponent = m_TxtEnd.GetComponent<TextMesh>();

        m_View = GameObject.Find("Camera (head)").transform;
    }

    public static class CoroutineUtil
    {
        public static IEnumerator WaitForRealSeconds(float time)
        {
            float start = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup < start + time)
            {
                yield return null;
            }
        }
    }

    private IEnumerator Timing4SCoroutine()
    {

        while (true)
        {
            SendPingToServer();

            yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(4));
        }

    }

    IEnumerator UIReadyAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        SendClientUIReady();

        isCoroutineExecuting = false;
    }

    private void Start()
    {
        GetConfiguration();
    }

    private void InitConnection()
    {
        string serverAddress;

        DataSerializer dataSerializer = DPSManager.GetDataSerializer<ProtobufSerializer>();
        List<DataProcessor> dataProcessors = new List<DataProcessor>();
        Dictionary<string, string> dataProcessorOptions = new Dictionary<string, string>();
        dataProcessors.Add(DPSManager.GetDataProcessor<SharpZipLibCompressor.SharpZipLibGzipCompressor>());

        NetworkComms.DefaultSendReceiveOptions = new SendReceiveOptions(dataSerializer, dataProcessors, dataProcessorOptions);
        NetworkComms.DefaultSendReceiveOptions.IncludePacketConstructionTime = true;
        NetworkComms.DefaultSendReceiveOptions.ReceiveHandlePriority = QueueItemPriority.AboveNormal;
        NetworkComms.AppendGlobalIncomingPacketHandler<VRCommand>("Command", HandleIncomingCommand);

        SystemConfigs.TryGetValue("ServerIPPort", out serverAddress); // get IP:Port

        IPEndPoint ip = IPTools.ParseEndPointFromString(serverAddress);
        targetServerConnectionInfo = new ConnectionInfo(ip, ApplicationLayerProtocolStatus.Enabled);

        //Debug.Log(serverAddress);
    }

    private void SendPingToServer()
    {
        sendToServerJob = new SendToServerJob();
        sendToServerJob.connectionInfo = targetServerConnectionInfo;
        sendToServerJob.isPingOnly = true;
        sendToServerJob.Start();

        //Debug.Log("Ping Send!");

        //StartCoroutine(CheckSendToServerState());
    }

    //IEnumerator CheckSendToServerState()
    //{
    //    yield return StartCoroutine(sendToServerJob.WaitFor());
    //}

    // all incoming command are handled here
    private void HandleIncomingCommand(PacketHeader packetHeader, Connection connection, VRCommand vrCommand)
    {
        ReceivedMessageEventArg e;
        switch (vrCommand.ControlMessage)
        {
            case Enums.ControlMessage.LOAD_CONFIG:
                Debug.Log("Received Tile Config from " + connection + Environment.NewLine +
                "Length of tileConfig: " + vrCommand.TileConfig.MainScreenTiles.Count.ToString());

                VRWorld.mainTiles = vrCommand.TileConfig.MainScreenTiles;
                m_gameState = Game_State.LoadConfig;

                e.message = "This game is load config message";
                RecievedTileConfigMessageEvent(e);
                break;

            case Enums.ControlMessage.START_NOW:
                Debug.Log("START NOW Command Received.");

                //SteamVR_Fade.Start(Color.clear, 0.5f);
                m_gameState = Game_State.Start;

                e.message = "This game is start message";
                ReceivedStartMessageEvent(e);
                break;

            case Enums.ControlMessage.END_NOW:
                Debug.Log("END NOW Command Received, message: '" + vrCommand.EndNow.Message + "'");

                s_endMessage = vrCommand.EndNow.Message;

                //SteamVR_Fade.Start(new Color(0f, 0f, 0f, 0.7f), 0);
                m_gameState = Game_State.EndGame;

                e.message = "This game is end message";
                ReceivedEndMessageEvent(e);
                break;

            case Enums.ControlMessage.SHOW_QUICK_HELP:

                Debug.Log("SHOW_QUICK_HELP Command Received.");

                m_gameState = Game_State.HelpState;

                e.message = "This Square is intend to show basic instructions.";
                ReceivedHelpMessageEvent(e);
                break;
            default:
                m_gameState = Game_State.Start;

                e.message = "This game is start message";
                ReceivedStartMessageEvent(e);
                break;
        }
    }

    // send client UI ready
    public void SendClientUIReady()
    {
        VRCommand cmd = new VRCommand(Enums.ControlMessage.CLIENT_UI_READY);
        SendCommandToServer(cmd);
    }

    public void ShowGamePlayPane(Tile tile, Transform trans)
    {
        GeneratePlayGamePane(tile, trans);
    }

    /// <summary>
    /// send play log to server 
    /// </summary>
    public void SendPlayLog(Tile tile, Transform trans)
    {
        string tileID = tile.TileID;
        Debug.Log("send PLAY_LOG message to server.");
        PlayLog playLog = new PlayLog(tileID, Enums.PlayLogSignalType.Start);
        VRCommand cmd = new VRCommand(playLog);
        SendCommandToServer(cmd);
    }

    // get configuration from server
    public void GetConfiguration()
    {
        VRCommand cmd = new VRCommand(Enums.ControlMessage.LOAD_CONFIG);
        SendCommandToServer(cmd);
        GenerateHelpTile();
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
            foreach (XmlNode configNode in systemNode.ChildNodes)
                SystemConfigs.Add(configNode.Name, configNode.InnerText);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        var system = OpenVR.System;
        if (system == null)
        {
            Debug.Log("OpenVR System not found.");
            if (!Application.isEditor) System.Diagnostics.Process.GetCurrentProcess().Kill();
            return;
        }

        switch (m_gameState)
        {
            case Game_State.Start:
                GameStartState();
                break;
            case Game_State.LoadConfig:
                GameLoadConfigState();
                break;
            case Game_State.LoadingGame:
                GameLoadState();
                break;
            case Game_State.PlayGame:
                GamePlayState();
                break;
            case Game_State.EndGame:
                GameEndState();
                break;
            case Game_State.HelpState:
                GameHelpState();
                break;
        }

    }

    // This function is called when the MonoBehaviour will be destroyed
    private void OnDestroy()
    {
        NetworkComms.Shutdown();
    }

    #region GenerateTiles
    public void GenerateTiles(List<Tile> parent)
    {
        GetRowTiles(parent);

        for (int i = 0; i < 4; i++)
        {
            foreach (TilePane tilePane in tilePanes[i])
                DestroyImmediate(tilePane.gameObject);

            tilePanes[i].Clear();
            GenerateRowTiles(i);
        }

        //m_TileParent.position = m_View.position + Vector3.up * 0.5f; // position follow headset
        m_TileParent.position = m_CameraRig.transform.position + Vector3.up * 0.5f + new Vector3(0, m_View.position.y - 0.5f, 0.8f); // room center
        //m_TileParent.rotation = Quaternion.Euler(new Vector3(0, m_View.localRotation.eulerAngles.y, 0)); // facing follow headset
        m_TileParent.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // facing front
    }

    public void ShowBackButton()
    {
        float yPos = 0;

        for (int i = 0; i < 4; i++)
            yPos += (rowHeight[i] * TileRate + TileSpace) * 2;

        yPos -= rowHeight[0] * TileRate / 2;
        //Debug.Log(yPos.ToString());
        m_BtnBack.transform.localPosition = new Vector3(0, -yPos, 1.49f);
        m_BtnBack.gameObject.SetActive(true);
    }

    private void GetRowTiles(List<Tile> parent)
    {
        for (int i = 0; i < 4; i++)
        {
            rowTiles[i].Clear();
            rowHeight[i] = 0;
        }

        foreach (Tile tile in parent)
        {
            int rowNum = tile.TileRowNumber - 1;

            rowTiles[rowNum].Add(tile);

            if (rowHeight[rowNum] < tile.Height)
                rowHeight[rowNum] = tile.Height;
        }
    }

    private void GenerateRowTiles(int rowNum)
    {
        int count = rowTiles[rowNum].Count;
        float x = 0, y = 0, z = 1.5f, yRow = 0, rotAngle = 0;

        if (count == 0)
            return;

        for (int i = 0; i < rowNum; i++)
            yRow -= ((rowHeight[i] + rowHeight[i + 1]) * TileRate + TileSpace * 2);

        yRow -= rowHeight[rowNum] * TileRate / 2;

        Vector3 rot = new Vector3(90, 180, 0);
        int nIndex = 0;

        foreach (Tile tile in rowTiles[rowNum])
        {
            float angle = Mathf.Asin((tile.Width * TileRate + TileSpace) / Mathf.Sqrt(x * x + z * z));

            if (nIndex > 0)
            {
                rot += new Vector3(0, angle * Mathf.Rad2Deg, 0);
                x += (tile.Width * TileRate + TileSpace) * Mathf.Cos(Mathf.Deg2Rad * (rot.y - 180));
                z -= (tile.Width * TileRate + TileSpace) * Mathf.Sin(Mathf.Deg2Rad * (rot.y - 180));
            }

            y = yRow + tile.Height * TileRate / 2;

            GameObject tileObj = Instantiate(m_TilePrefab);
            tileObj.transform.SetParent(m_TileParent);
            tileObj.transform.localPosition = new Vector3(x, y, z);
            tileObj.transform.localRotation = Quaternion.Euler(rot);
            tileObj.GetComponent<TilePane>().m_Tile = tile;
            tileObj.transform.localScale = new Vector3(tile.Width * TileRate * 5, 1, tile.Height * TileRate * 5);

            if (tile.ImagePath != "")
                StartCoroutine(LoadTexture(tileObj.GetComponent<TilePane>()));

            tilePanes[rowNum].Add(tileObj.GetComponent<TilePane>());

            x += (tile.Width * TileRate + TileSpace) * Mathf.Cos(Mathf.Deg2Rad * (rot.y - 180));
            z -= (tile.Width * TileRate + TileSpace) * Mathf.Sin(Mathf.Deg2Rad * (rot.y - 180));
            angle = Mathf.Asin((tile.Width * TileRate + TileSpace) / Mathf.Sqrt(x * x + z * z));
            rotAngle = rot.y / 2;
            rot += new Vector3(0, angle * Mathf.Rad2Deg, 0);
            nIndex++;
        }

        foreach (TilePane tilePane in tilePanes[rowNum])
            tilePane.transform.RotateAround(m_TileParent.position, -m_TileParent.up, rotAngle - 90);
    }

    IEnumerator LoadTexture(TilePane tilePane)
    {
        // Note: image path is now changed to "C:\ProgramData\VRArcade\Client\Images\"

        string imagePath = tilePane.m_Tile.ImagePath.Replace('\\', '/');
        //imagePath = "file:///" + Application.dataPath + "/" + imagePath; // old
        imagePath = "file:///" + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\VRArcade\Client\" + imagePath.Replace('\\', '/');
        WWW www = new WWW(imagePath);

        //Debug.Log(imagePath);

        yield return www;

        if (www.error == null && tilePane)
            tilePane.GetComponent<Renderer>().material.mainTexture = www.texture;
    }
    #endregion

    /// <summary>
    /// generate help tile
    /// </summary>
    private void GenerateHelpTile()
    {
        if (m_helpTile)
            return;

        m_helpTile = Util.GenerateObject(Constants.CONSTANTS_HELPBUTTON_PREFAB_PATH, Constants.CONSTANTS_HELPBUTTON_LOCALPOSITION,
                                            Constants.CONSTANTS_HELPBUTTON_LOCALROTATION, m_TileParent);

    }

    /// <summary>
    /// generate trailer pane
    /// </summary>
    private void GeneratePlayGamePane(Tile tile, Transform m_tileTrans)
    {

        if (m_helpTile.GetComponent<HelpPane>().m_IntroScreen)
            return;

        VideoPane videopane = GameObject.FindObjectOfType<VideoPane>();
        if (videopane)
            return;


        //Vector3 pos = m_tileTrans.position + new Vector3(0f, 0.25f * m_tileTrans.localScale.x, -0.1f);
        Vector3 pos = m_CameraRig.right.GetComponent<SteamVR_SimplePointer>().pointerTipPosition + new Vector3(0, 0, -0.05f);
        Vector3 rot = m_tileTrans.rotation.eulerAngles + new Vector3(-90f, 180f, 0f);

        m_playGamePane = Util.GenerateObject(Constants.CONSTANTS_PLAYGAME_PREFAB_PATH, pos,
                                                rot, null);

        VideoInfo info;
        info.videoUrls = tile.VideoURL;
        info.videoVolume = 1f;
        info.videoLoop = false;

        if (tile.VideoURL.Length == 0)
        {
            Vector3 scale = m_playGamePane.transform.FindChild(Constants.CONSTANTS_TRAILER_NAME).GetComponent<Transform>().localScale;
            scale.x = 0F;
            m_playGamePane.transform.FindChild(Constants.CONSTANTS_TRAILER_NAME).GetComponent<Transform>().localScale = scale;

            m_playGamePane.transform.FindChild(Constants.CONSTANTS_TRAILER_NAME).GetComponent<Renderer>().enabled = false;
            m_playGamePane.transform.FindChild(Constants.CONSTANTS_TRAILER_NAME).transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        }

        GamePlayPane[] paneList = m_playGamePane.transform.GetComponentsInChildren<GamePlayPane>();
        foreach (GamePlayPane pane in paneList)
        {
            pane.videoInfo = info;
            pane.tile = tile;
        }

        //DoSelectedAnyTile(true);
        //Texture2D tex = Util.LoadTexture(Constants.CONSTANTS_PLAYGAME_IMAGE_PATH);
        //m_playGamePane.GetComponent<Renderer>().material.mainTexture = tex;
    }

    public void RemovePlayGamePane()
    {
        if (m_playGamePane)
            Destroy(m_playGamePane);
    }

    //public void DoSelectedAnyTile(bool bSelected)
    //{
    //    StartCoroutine("SetSelectedAnyTile", true);
    //}
    IEnumerator SetSelectedAnyTile(bool bSelected)
    {
        float time = 0f;
        if (!bSelected)
            time = 0.3f;

        yield return new WaitForSeconds(time);
        bCurrentSelectedAnyTile = bSelected;
    }

    #region Message_Event
    public virtual void ReceivedStartMessageEvent(ReceivedMessageEventArg e)
    {
        if (ReceivedStartMessage != null)
            ReceivedStartMessage(this, e);
    }

    public virtual void ReceivedEndMessageEvent(ReceivedMessageEventArg e)
    {
        if (ReceivedEndMessage != null)
            ReceivedEndMessage(this, e);
    }

    public virtual void ReceivedHelpMessageEvent(ReceivedMessageEventArg e)
    {
        if (ReceivedHelpMessage != null)
            ReceivedHelpMessage(this, e);
    }

    public virtual void RecievedTileConfigMessageEvent(ReceivedMessageEventArg e)
    {
        if (ReceivedTileConfigMessage != null)
            ReceivedTileConfigMessage(this, e);
    }
    #endregion

    #region GAME_STATE
    public Game_State GameState { set { m_gameState = value; } get { return m_gameState; } }
    private void GameNoneState()
    {
    }
    private void GameStartState()
    {
        m_CameraRig.right.SetActive(true);
        m_CameraRig.left.SetActive(true);
        m_TxtEnd.SetActive(false);
        m_loadingPane.SetActive(false);
    }
    private void GameLoadConfigState()
    {
        GenerateTiles(VRWorld.mainTiles);
        //SendClientUIReady();
        StartCoroutine(UIReadyAfterTime(1));
        m_gameState = Game_State.ConfigLoaded;
    }
    private void GameLoadState()
    {
        m_CameraRig.right.SetActive(false);
        m_CameraRig.left.SetActive(false);
    }
    private void GamePlayState()
    {

    }

    private void GameHelpState()
    {

    }
    private void GameEndState()
    {
        mTxtEndComponent.text = s_endMessage;
        m_CameraRig.right.SetActive(false);
        m_CameraRig.left.SetActive(false);
        m_TxtEnd.SetActive(true);
        m_loadingPane.SetActive(false);
    }

    #endregion
}