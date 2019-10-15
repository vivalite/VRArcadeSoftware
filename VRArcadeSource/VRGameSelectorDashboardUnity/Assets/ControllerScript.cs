using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using VRGameSelectorDTO;

public class ControllerScript : MonoBehaviour
{
    private HOTK_TrackedDevice _trackedObj;

    public HOTK_Overlay Overlay;
    public HOTK_Overlay OverlayTiming;
    public GameObject Canvas;
    public Sprite CursorSprite;
    public GameObject HMD;
    public ControllerScript OtherController;
    public bool IsMainThread = false;

    private Dictionary<string, string> SystemConfigs;
    private GameObject _cursor;
    private bool _hasOverlay;


    private float _canvasWidth;
    private float _canvasHeight;
    private float _x;
    private float _y;

    private static ConnectionInfo targetServerConnectionInfo;
    private SendRunningGameJob sendRunningGameJob;
    private DashboardInfo dashboardInfo;



    #region ExitGame button setup
    internal bool InExitGame { get; private set; }
    internal bool PressDownExitGame { get; private set; }
    public GameObject ExitGameButton
    {
        get { return _ExitGameButton ?? (_ExitGameButton = GameObject.Find("ExitGame")); }
    }
    private GameObject _ExitGameButton;

    public Button ExitGameComponent
    {
        get { return _ExitGameComponent ?? (_ExitGameComponent = ExitGameButton.GetComponent<Button>()); }
    }
    private Button _ExitGameComponent;

    public Vector3 ExitGameButtonPos
    {
        get { return ExitGameButton.transform.localPosition; }
    }

    public RectTransform ExitGameButtonRect
    {
        get { return _ExitGameButtonRect ?? (_ExitGameButtonRect = ExitGameButton.GetComponent<RectTransform>()); }
    }
    private RectTransform _ExitGameButtonRect;

    #endregion

    #region Help button setup
    internal bool InHelp { get; private set; }
    internal bool PressDownHelp { get; private set; }
    public GameObject HelpButton
    {
        get { return _HelpButton ?? (_HelpButton = GameObject.Find("Help")); }
    }
    private GameObject _HelpButton;

    public Button HelpComponent
    {
        get { return _HelpComponent ?? (_HelpComponent = HelpButton.GetComponent<Button>()); }
    }
    private Button _HelpComponent;

    public Vector3 HelpButtonPos
    {
        get { return HelpButton.transform.localPosition; }
    }

    public RectTransform HelpButtonRect
    {
        get { return _HelpButtonRect ?? (_HelpButtonRect = HelpButton.GetComponent<RectTransform>()); }
    }
    private RectTransform _HelpButtonRect;

    #endregion

    #region VolumeUp button setup
    internal bool InVolumeUp { get; private set; }
    internal bool PressDownVolumeUp { get; private set; }
    public GameObject VolumeUpButton
    {
        get { return _VolumeUpButton ?? (_VolumeUpButton = GameObject.Find("VolumeUp")); }
    }
    private GameObject _VolumeUpButton;

    public Button VolumeUpComponent
    {
        get { return _VolumeUpComponent ?? (_VolumeUpComponent = VolumeUpButton.GetComponent<Button>()); }
    }
    private Button _VolumeUpComponent;

    public Vector3 VolumeUpButtonPos
    {
        get { return VolumeUpButton.transform.localPosition; }
    }

    public RectTransform VolumeUpButtonRect
    {
        get { return _VolumeUpButtonRect ?? (_VolumeUpButtonRect = VolumeUpButton.GetComponent<RectTransform>()); }
    }
    private RectTransform _VolumeUpButtonRect;

    #endregion

    #region VolumeDown button setup
    internal bool InVolumeDown { get; private set; }
    internal bool PressDownVolumeDown { get; private set; }
    public GameObject VolumeDownButton
    {
        get { return _VolumeDownButton ?? (_VolumeDownButton = GameObject.Find("VolumeDown")); }
    }
    private GameObject _VolumeDownButton;

    public Button VolumeDownComponent
    {
        get { return _VolumeDownComponent ?? (_VolumeDownComponent = VolumeDownButton.GetComponent<Button>()); }
    }
    private Button _VolumeDownComponent;

    public Vector3 VolumeDownButtonPos
    {
        get { return VolumeDownButton.transform.localPosition; }
    }

    public RectTransform VolumeDownButtonRect
    {
        get { return _VolumeDownButtonRect ?? (_VolumeDownButtonRect = VolumeDownButton.GetComponent<RectTransform>()); }
    }
    private RectTransform _VolumeDownButtonRect;

    #endregion

    #region TimeLeft text setup

    public GameObject TimeLeftText
    {
        get { return _TimeLeftText ?? (_TimeLeftText = GameObject.Find("TimeLeft")); }
    }
    private GameObject _TimeLeftText;

    public Text TimeLeftComponent
    {
        get { return _TimeLeftComponent ?? (_TimeLeftComponent = TimeLeftText.GetComponent<Text>()); }
    }
    private Text _TimeLeftComponent;

    #endregion

    #region TimeLeftTiming text setup

    public GameObject TimeLeftTimingText
    {
        get { return _TimeLeftTimingText ?? (_TimeLeftTimingText = GameObject.Find("TimeLeftTiming")); }
    }
    private GameObject _TimeLeftTimingText;

    public Text TimeLeftTimingComponent
    {
        get { return _TimeLeftTimingComponent ?? (_TimeLeftTimingComponent = TimeLeftTimingText.GetComponent<Text>()); }
    }
    private Text _TimeLeftTimingComponent;

    #endregion

    public void Awake()
    {
        _trackedObj = GetComponent<HOTK_TrackedDevice>();

        InitCoreConfig();

        InitConnection();


        if (IsMainThread)
        {
            InvokeRepeating("SendPingToServer", 0, 4); // send ping to server every 4 seconds
        }

        HelpComponent.transition = Selectable.Transition.None;
        ExitGameComponent.transition = Selectable.Transition.None;
        VolumeUpComponent.transition = Selectable.Transition.None;
        VolumeDownComponent.transition = Selectable.Transition.None;

    }



    public void Start()
    {
        InstantiateCursor();

        _hasOverlay = false;


        _canvasWidth = Canvas.GetComponent<RectTransform>().rect.width;
        _canvasHeight = Canvas.GetComponent<RectTransform>().rect.height;
        InExitGame = false;
        InHelp = false;
        InVolumeUp = false;
        InVolumeDown = false;
        PressDownExitGame = false;
        PressDownHelp = false;
        PressDownVolumeDown = false;
        PressDownVolumeUp = false;




    }



    public void Update()
    {
        if (HOTK_TrackedDeviceManager.Instance.GetPressUp(_trackedObj, EVRButtonId.k_EButton_System))
        {
            var processes = Process.GetProcessesByName("VRGameSelector");
            if (processes.Length == 0)
            {
                if (!Overlay.gameObject.activeSelf)
                {
                    bool rtn = OpenVR.System.CaptureInputFocus();
                    //Debug.Log("CaptureInputFocus " + rtn.ToString());


                    SpawnOverlay(Overlay);
                    //SpawnOverlay(OverlayTiming);
                    _hasOverlay = true;

                }
                else
                {
                    Overlay.gameObject.SetActive(false);
                    _hasOverlay = false;

                    InExitGame = false;
                    InHelp = false;
                    InVolumeUp = false;
                    InVolumeDown = false;

                    OpenVR.System.ReleaseInputFocus();

                    ResetAllPressDown();
                }
            }
            else if (_hasOverlay)
            {
                Overlay.gameObject.SetActive(false);
                _hasOverlay = false;

                InExitGame = false;
                InHelp = false;
                InVolumeUp = false;
                InVolumeDown = false;

                OpenVR.System.ReleaseInputFocus();

                ResetAllPressDown();
            }

        }
        if (HOTK_TrackedDeviceManager.Instance.GetPressDown(_trackedObj, EVRButtonId.k_EButton_SteamVR_Trigger))
        {
            if (InExitGame)
            {
                PressDownExitGame = true;
                ApplyPressedColor(ExitGameComponent);
                //Debug.Log("pressed ExitGame");

                SendExitGames();

                ResetAllPressDown();

                Overlay.gameObject.SetActive(false);
                _hasOverlay = false;

                InExitGame = false;
                InHelp = false;
                InVolumeUp = false;
                InVolumeDown = false;

                OpenVR.System.ReleaseInputFocus();
            }
            else if (InHelp)
            {
                PressDownHelp = true;
                ApplyPressedColor(HelpComponent);
                //Debug.Log("pressed Help");

                SendHelpRequest();

                ResetAllPressDown();

                Overlay.gameObject.SetActive(false);
                _hasOverlay = false;

                InExitGame = false;
                InHelp = false;
                InVolumeUp = false;
                InVolumeDown = false;

                OpenVR.System.ReleaseInputFocus();

            }
            else if (InVolumeUp)
            {
                PressDownVolumeUp = true;
                ApplyPressedColor(VolumeUpComponent);
                //Debug.Log("pressed VolumeUp");

                SendVolumeUpRequest();

                //Overlay.gameObject.SetActive(false);
            }
            else if (InVolumeDown)
            {
                PressDownVolumeDown = true;
                ApplyPressedColor(_VolumeDownComponent);
                //Debug.Log("pressed VolumeDown");

                SendVolumeDownRequest();

                //Overlay.gameObject.SetActive(false);
            }


        }

        if (HOTK_TrackedDeviceManager.Instance.GetPressUp(_trackedObj, EVRButtonId.k_EButton_SteamVR_Trigger))
        {
            ResetAllPressDown();
        }


        if (_hasOverlay)
        {
            var result = Overlay.getUVs(gameObject.transform.position, gameObject.transform.forward);
            if (_trackedObj.IsValid && result.Hit)
            {
                var uvs = result.Result.UVs;
                _x = uvs.x * _canvasWidth;
                _y = (1 - uvs.y) * _canvasHeight;

                var halfWidth = (_canvasWidth / 2);
                var halfHeight = (_canvasHeight / 2);

                _x -= halfWidth;
                _y -= halfHeight;

                var pos = new Vector2(_x, _y);

                if (_x <= -halfWidth || _y <= -halfHeight || _x >= halfWidth || _y >= halfHeight)
                {
                    InExitGame = false;
                    InHelp = false;
                    InVolumeUp = false;
                    InVolumeDown = false;

                    _cursor.gameObject.SetActive(false);
                }
                else
                {
                    _cursor.gameObject.SetActive(true);
                    _cursor.transform.localPosition = pos;

                    InExitGame = CalculateCursorIn(ref _x, ref _y, ExitGameComponent, ExitGameButtonPos, ExitGameButtonRect);

                    InHelp = CalculateCursorIn(ref _x, ref _y, HelpComponent, HelpButtonPos, HelpButtonRect);

                    InVolumeUp = CalculateCursorIn(ref _x, ref _y, VolumeUpComponent, VolumeUpButtonPos, VolumeUpButtonRect);

                    InVolumeDown = CalculateCursorIn(ref _x, ref _y, VolumeDownComponent, VolumeDownButtonPos, VolumeDownButtonRect);

                }
            }
            else
            {
                InExitGame = false;
                InHelp = false;
                InVolumeUp = false;
                InVolumeDown = false;

                _cursor.gameObject.SetActive(false);
            }

            if (!InExitGame && !OtherController.InExitGame)
            {
                ResetExitGame();
            }
            if (!InHelp && !OtherController.InHelp)
            {
                ResetHelp();
            }
            if (!InVolumeUp && !OtherController.InVolumeUp)
            {
                ResetVolumeUp();
            }
            if (!InVolumeDown && !OtherController.InVolumeDown)
            {
                ResetVolumeDown();
            }

        }
    }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    private void FixedUpdate()
    {
        if (sendRunningGameJob != null)
        {
            if (sendRunningGameJob.Update())
            {
                sendRunningGameJob = null;
            }
        }

        if (dashboardInfo != null)
        {
            if (dashboardInfo.CurrentRunningMode.RunningMode == Enums.ClientRunningMode.TIMING_ON)
            {
                TimeSpan tsTimeLeft = dashboardInfo.CurrentRunningMode.StartTime.AddMinutes((double)dashboardInfo.CurrentRunningMode.Duration).Subtract(DateTime.Now);

                tsTimeLeft = (tsTimeLeft > TimeSpan.Zero) ? tsTimeLeft : new TimeSpan(0, 0, 0);

                TimeLeftComponent.text = "PLAY TIME" + Environment.NewLine + "LEFT: " + tsTimeLeft.TotalMinutes.ToString("00");

                TimeLeftTimingComponent.text = "PLAY TIME LEFT: " + tsTimeLeft.Minutes + ":" + tsTimeLeft.Seconds;
            }
        }
        else
        {
            TimeLeftComponent.text = "";
        }
    }



    private void ResetAllPressDown()
    {
        PressDownExitGame = false;
        PressDownHelp = false;
        PressDownVolumeDown = false;
        PressDownVolumeUp = false;
    }

    private void ResetExitGame()
    {
        ApplyNormalColor(ExitGameComponent);
    }

    private void ResetHelp()
    {
        ApplyNormalColor(HelpComponent);
    }

    private void ResetVolumeUp()
    {
        ApplyNormalColor(VolumeUpComponent);
    }

    private void ResetVolumeDown()
    {
        ApplyNormalColor(VolumeDownComponent);
    }

    private void ApplyNormalColor(Button btn)
    {
        btn.image.color = btn.colors.normalColor;
    }

    private void ApplyHighlightedColor(Button btn)
    {
        btn.image.color = btn.colors.highlightedColor;
    }

    private void ApplyPressedColor(Button btn)
    {
        btn.image.color = btn.colors.pressedColor;
    }

    private void InstantiateCursor()
    {
        _cursor = new GameObject("cursor");

        var image = _cursor.AddComponent<Image>();
        image.sprite = CursorSprite;

        _cursor.transform.SetParent(Canvas.transform);
        _cursor.transform.localPosition = new Vector2(-5000f, -5000f);
        _cursor.transform.localRotation = Quaternion.identity;
        _cursor.transform.localScale = Vector3.one / 2f;

        _cursor.SetActive(false);
    }

    private bool CalculateCursorIn(ref float _x, ref float _y, Button buttonComponent, Vector3 buttonPos, RectTransform buttonRect)
    {
        if ((_x > (buttonPos.x - (buttonRect.rect.width / 2)) && _x < (buttonPos.x + (buttonRect.rect.width / 2))) && (_y < (buttonPos.y + (buttonRect.rect.height / 2)) && _y > (buttonPos.y - (buttonRect.rect.height / 2))))
        {
            if (!PressDownExitGame && !PressDownHelp && !PressDownVolumeDown && !PressDownVolumeUp)
            {
                ApplyHighlightedColor(buttonComponent);
            }
            return true;
        }
        else return false;
    }

    public void SpawnOverlay(HOTK_Overlay overlay)
    {
        overlay.gameObject.SetActive(true);
    }


    private RunningGameInfo GetRunningGames()
    {
        RunningGameInfo runningGameInfo = new RunningGameInfo();

        List<AppInfo> lAppInfo = new List<AppInfo>();


        CVRApplications app = OpenVR.Applications;
        StringBuilder sbAppkey = new System.Text.StringBuilder((int)OpenVR.k_unMaxApplicationKeyLength);
        StringBuilder sbLaunchType = new System.Text.StringBuilder((Int32)OpenVR.k_unMaxPropertyStringSize);
        StringBuilder sbBinaryPath = new System.Text.StringBuilder((int)OpenVR.k_unMaxApplicationKeyLength);

        uint appCount = app.GetApplicationCount();

        for (uint i = 0; i < appCount; i++)
        {
            sbAppkey.Length = 0; sbAppkey.Capacity = 0;
            sbLaunchType.Length = 0; sbLaunchType.Capacity = 0;
            sbAppkey = new StringBuilder((int)OpenVR.k_unMaxApplicationKeyLength);
            sbLaunchType = new StringBuilder((Int32)OpenVR.k_unMaxPropertyStringSize);
            sbBinaryPath = new System.Text.StringBuilder((int)OpenVR.k_unMaxApplicationKeyLength);

            EVRApplicationError err = app.GetApplicationKeyByIndex(i, sbAppkey, OpenVR.k_unMaxApplicationKeyLength);

            string appkey = sbAppkey.ToString();

            uint procId = app.GetApplicationProcessId(appkey);

            app.GetApplicationPropertyString(appkey, EVRApplicationProperty.LaunchType_String, sbLaunchType, OpenVR.k_unMaxPropertyStringSize, ref err);
            app.GetApplicationPropertyString(appkey, EVRApplicationProperty.BinaryPath_String, sbBinaryPath, OpenVR.k_unMaxPropertyStringSize, ref err);

            bool isDashboard = app.GetApplicationPropertyBool(appkey, EVRApplicationProperty.IsDashboardOverlay_Bool, ref err);

            string selfName = Process.GetCurrentProcess().MainModule.FileName;

            if (sbLaunchType.ToString() == "binary" && !isDashboard && procId > 0 && sbBinaryPath.ToString() != selfName)
            {
                //fileN = Process.GetProcessById((int)procId).MainModule.FileName;
                //Debug.Log(appkey + "|||" + procId + "|||" + sbBinaryPath.ToString() + "|||" + fileN);

                AppInfo appInfo = new AppInfo((int)procId, sbBinaryPath.ToString());

                lAppInfo.Add(appInfo);
            }
        }

        runningGameInfo.RunningGames = lAppInfo;

        return runningGameInfo;

    }


    // Sent to all game objects before the application is quit
    private void OnApplicationQuit()
    {
        NetworkComms.Shutdown();
    }


    private void InitCoreConfig()
    {
        TextAsset temp = Resources.Load("config") as TextAsset;
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(temp.text);
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

        if (IsMainThread)
        {
            NetworkComms.AppendGlobalIncomingPacketHandler<VRCommand>("Command", HandleIncomingCommand);
        }

        SystemConfigs.TryGetValue("ServerIPPort", out serverAddress); // get IP:Port

        IPEndPoint ip = IPTools.ParseEndPointFromString(serverAddress);
        targetServerConnectionInfo = new ConnectionInfo(ip, ApplicationLayerProtocolStatus.Enabled);
    }

    // all incoming command are handled here
    private void HandleIncomingCommand(PacketHeader packetHeader, Connection connection, VRCommand vrCommand)
    {
        switch (vrCommand.ControlMessage)
        {
            case Enums.ControlMessage.UNITY_DASHBOARD_GETRUNNINGGAMES:

                //Debug.Log(connection + Environment.NewLine + " Get Running Games");

                if (vrCommand.RunningGameInfo != null && vrCommand.RunningGameInfo.IsPostTerminationCheck)
                {
                    // post termination check
                    //SendRunningGames(true);

                }
                else
                {
                    //SendRunningGames(false);


                }

                break;
            case Enums.ControlMessage.UNITY_DASHBOARD_SETDASHINFO:

                dashboardInfo = vrCommand.DashboardInfo;

                break;

            default:
                break;
        }


    }

    private IEnumerator CheckSendRunningGameJobState()
    {
        yield return StartCoroutine(sendRunningGameJob.WaitFor());
    }

    public void SendVolumeUpRequest()
    {
        VRCommand cmd = new VRCommand(Enums.ControlMessage.UNITY_DASHBOARD_VOLUMEUP);
        SendCommandToServer(cmd);
    }

    public void SendVolumeDownRequest()
    {
        VRCommand cmd = new VRCommand(Enums.ControlMessage.UNITY_DASHBOARD_VOLUMEDOWN);
        SendCommandToServer(cmd);
    }

    public void SendHelpRequest()
    {
        VRCommand cmd = new VRCommand(Enums.ControlMessage.REQUEST_HELP);
        SendCommandToServer(cmd);
    }

    public void SendExitGames()
    {
        VRCommand cmd = new VRCommand(Enums.ControlMessage.UNITY_DASHBOARD_EXITGAME);
        SendCommandToServer(cmd);
    }

    public void SendRunningGames(bool isPostTermCheck = false)
    {
        sendRunningGameJob = new SendRunningGameJob();
        sendRunningGameJob.connectionInfo = targetServerConnectionInfo;
        sendRunningGameJob.Start();

        //Debug.Log("SendRunningGames(" + isPostTermCheck.ToString() + ")");
    }

    // generic method to send command object to server
    private void SendCommandToServer(VRCommand cmdObj)
    {
        SendToServerJob sendToServerJob = new SendToServerJob();
        sendToServerJob.connectionInfo = targetServerConnectionInfo;
        sendToServerJob.command = cmdObj;
        sendToServerJob.Start();
    }

    private void SendPingToServer()
    {
        SendToServerJob sendToServerJob = new SendToServerJob();
        sendToServerJob.connectionInfo = targetServerConnectionInfo;
        sendToServerJob.isPingOnly = true;
        sendToServerJob.Start();

    }
}
