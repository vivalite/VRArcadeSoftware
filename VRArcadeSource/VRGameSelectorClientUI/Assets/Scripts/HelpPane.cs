using UnityEngine;
using System.Collections;
using VRGameSelectorDTO;
using util.commom;
using util.constants;
using System;

public class HelpPane : SteamVR_InteractableObject
{

    private SteamVR_ControllerManager m_ControllerManager;

    public GameObject m_IntroScreen;
    private bool m_bReceivedHelpMsg = false;

    public override void StartUsing(GameObject usingObject)
    {
        base.StartUsing(usingObject);
    }
    public override void StopUsing(GameObject usingObject)
    {
        base.StopUsing(usingObject);
    }

    protected override void Initialize()
    {
        m_InitScale = transform.localScale;
        m_ControllerManager = GameObject.FindObjectOfType<SteamVR_ControllerManager>();
    }
    protected override void Start()
    {
        //base.Start();
        Initialize();
        AddEnventListner();
    }

    private void AddEnventListner()
    {
        m_ControllerManager.right.GetComponent<SteamVR_ControllerEvents>().TriggerUnclicked += new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.right.GetComponent<SteamVR_ControllerEvents>().GripClicked += new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.right.GetComponent<SteamVR_ControllerEvents>().TouchpadClicked += new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.right.GetComponent<SteamVR_ControllerEvents>().ApplicationMenuClicked += new ControllerClickedEventHandler(DoAnyButtonClicked);

        m_ControllerManager.left.GetComponent<SteamVR_ControllerEvents>().TriggerClicked += new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.left.GetComponent<SteamVR_ControllerEvents>().GripClicked += new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.left.GetComponent<SteamVR_ControllerEvents>().TouchpadClicked += new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.left.GetComponent<SteamVR_ControllerEvents>().ApplicationMenuClicked += new ControllerClickedEventHandler(DoAnyButtonClicked);

        VRSelectorCore.Instance.ReceivedHelpMessage += new ReceivedMessageEnventHandler(DoShowSubPanel);
        VRSelectorCore.Instance.ReceivedStartMessage += new ReceivedMessageEnventHandler(ReceivedStartMessageHandler);
        VRSelectorCore.Instance.ReceivedTileConfigMessage += new ReceivedMessageEnventHandler(ReceivedEndMessageHandler);
        VRSelectorCore.Instance.ReceivedEndMessage += new ReceivedMessageEnventHandler(ReceivedEndMessageHandler);

    }

    // Update is called once per frame
    void Update()
    {
        if (m_bReceivedHelpMsg)
        {
            GenerateHelpPanel();
        }
        else
        {
            HideHelpPanel();
        }
    }

    private void GenerateHelpPanel()
    {
        if (m_IntroScreen)
            return;

        Debug.Log("create Help tile");
        m_IntroScreen = Util.GenerateObject(Constants.CONSTANTS_INTROHELP_PREFAB_PATH, Constants.CONSTANTS_INTROHELP_LOCALPOSITION,
                                                Constants.CONSTANTS_INTROHELP_LOCALROTATION, null);


        m_IntroScreen.GetComponentInChildren<TextMesh>().text = "";

        //Texture2D tex = Util.LoadTexture(Constants.CONSTANTS_INTROHELP_IMAGE_PATH);
        Color color = m_IntroScreen.GetComponent<Renderer>().material.color;
        color.a = 1;
        color.b = 1;
        color.g = 1;
        color.r = 1;
        m_IntroScreen.GetComponent<Renderer>().material.color = color;

        //m_IntroScreen.GetComponent<Renderer>().material.mainTexture = tex;

        StartCoroutine(LoadTexture(m_IntroScreen, Constants.CONSTANTS_INTROHELP_IMAGE_PATH));


    }
    /// <summary>
    /// clicked any controller button
    /// </summary>
    private void DoAnyButtonClicked(object sender, ControllerClickedEventArgs e)
    {
        m_bReceivedHelpMsg = false;
    }
    #region Received message from server
    /// <summary>
    /// when click trigger button on help tile and receive "SHOW_QUICK_HELP" message from server,
    /// show up "Introduction image".
    /// </summary>
    public override void DoShowSubPanel(object sender, ReceivedMessageEventArg e)
    {
        Debug.Log("received help message");
        m_bReceivedHelpMsg = true;
    }
    private void ReceivedEndMessageHandler(object sender, ReceivedMessageEventArg e)
    {
        m_bReceivedHelpMsg = false;
    }
    private void ReceivedStartMessageHandler(object sender, ReceivedMessageEventArg e)
    {
        m_bReceivedHelpMsg = false;
    }
    private void ReceivedTileConfigMessageHandler(object sender, ReceivedMessageEventArg e)
    {
        m_bReceivedHelpMsg = false;
    }
    #endregion
    private void HideHelpPanel()
    {
        if (!m_IntroScreen)
            return;

        Destroy(m_IntroScreen);
    }

    IEnumerator LoadTexture(GameObject gameObj, string fileShortPath)
    {
        // Note: image path is now changed to "C:\ProgramData\VRArcade\Client\Images\"

        //string imagePath = tilePane.m_Tile.ImagePath.Replace('\\', '/');
        //imagePath = "file:///" + Application.dataPath + "/" + imagePath; // old
        string imagePath = "file:///" + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\VRArcade\Client\" + fileShortPath.Replace('\\', '/');
        WWW www = new WWW(imagePath);

        Debug.Log(imagePath);

        yield return www;

        if (www.error == null && gameObj)
        {
            gameObj.GetComponent<Renderer>().material.mainTexture = www.texture;
        }
    }

}
