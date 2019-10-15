using UnityEngine;
using System.Collections;
using RenderHeads.Media.AVProVideo;

public struct VideoInfo
{
    public string videoUrls;
    public float videoVolume;
    public bool videoLoop;
}

public class VideoPane : MonoBehaviour {

    private SteamVR_ControllerManager m_ControllerManager;
    private MediaPlayer mp;

    private bool hidePane = false;	

    /// <summary>
    /// initialize SteamVR_ControllerManager and MediaPlayer
    /// </summary>
    private void Initialize()
    {		
        m_ControllerManager = GameObject.FindObjectOfType<SteamVR_ControllerManager>();
		mp = GetComponent<MediaPlayer> ();
    }

    private void AddListner()
    {
        m_ControllerManager.right.GetComponent<SteamVR_ControllerEvents>().TriggerUnclicked += new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.right.GetComponent<SteamVR_ControllerEvents>().GripClicked += new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.right.GetComponent<SteamVR_ControllerEvents>().TouchpadClicked += new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.right.GetComponent<SteamVR_ControllerEvents>().ApplicationMenuClicked += new ControllerClickedEventHandler(DoAnyButtonClicked);

        m_ControllerManager.left.GetComponent<SteamVR_ControllerEvents>().TriggerUnclicked += new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.left.GetComponent<SteamVR_ControllerEvents>().GripClicked += new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.left.GetComponent<SteamVR_ControllerEvents>().TouchpadClicked += new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.left.GetComponent<SteamVR_ControllerEvents>().ApplicationMenuClicked += new ControllerClickedEventHandler(DoAnyButtonClicked);

		VRSelectorCore.Instance.ReceivedStartMessage += new ReceivedMessageEnventHandler(DoHideVideoPane);
		VRSelectorCore.Instance.ReceivedTileConfigMessage += new ReceivedMessageEnventHandler(DoHideVideoPane);
		VRSelectorCore.Instance.ReceivedHelpMessage += new ReceivedMessageEnventHandler(DoHideVideoPane);
		VRSelectorCore.Instance.ReceivedEndMessage += new ReceivedMessageEnventHandler(DoHideVideoPane);

		mp.Events.AddListener(OnVideoEvent);
    }
    public void RemoveListner()
    {
        m_ControllerManager.right.GetComponent<SteamVR_ControllerEvents>().TriggerUnclicked -= new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.right.GetComponent<SteamVR_ControllerEvents>().GripClicked -= new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.right.GetComponent<SteamVR_ControllerEvents>().TouchpadClicked -= new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.right.GetComponent<SteamVR_ControllerEvents>().ApplicationMenuClicked -= new ControllerClickedEventHandler(DoAnyButtonClicked);

        m_ControllerManager.left.GetComponent<SteamVR_ControllerEvents>().TriggerUnclicked -= new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.left.GetComponent<SteamVR_ControllerEvents>().GripClicked -= new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.left.GetComponent<SteamVR_ControllerEvents>().TouchpadClicked -= new ControllerClickedEventHandler(DoAnyButtonClicked);
        m_ControllerManager.left.GetComponent<SteamVR_ControllerEvents>().ApplicationMenuClicked -= new ControllerClickedEventHandler(DoAnyButtonClicked);

		VRSelectorCore.Instance.ReceivedStartMessage -= new ReceivedMessageEnventHandler(DoHideVideoPane);
		VRSelectorCore.Instance.ReceivedTileConfigMessage -= new ReceivedMessageEnventHandler(DoHideVideoPane);
		VRSelectorCore.Instance.ReceivedHelpMessage -= new ReceivedMessageEnventHandler(DoHideVideoPane);
		VRSelectorCore.Instance.ReceivedEndMessage -= new ReceivedMessageEnventHandler(DoHideVideoPane);

		mp.Events.RemoveAllListeners();
    }

	private void OnVideoEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode errorCode)
	{
		switch(et)
		{
		case MediaPlayerEvent.EventType.ReadyToPlay:
			Debug.Log("MediaPlayerEvent.EventType.ReadyToPlay:");
			break;
		case MediaPlayerEvent.EventType.FirstFrameReady:
			break;
		case MediaPlayerEvent.EventType.FinishedPlaying:
            DestroyVideoPane();
			break;
		}
	}

    // Use this for initialization
    void Start () {
        Initialize();
        AddListner();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (hidePane)
			DestroyVideoPane ();
	}

	#region Hide_Video_Pane

	public void DoHideVideoPane(object sender, ReceivedMessageEventArg e)
	{
		hidePane = true;
	}

    private void DoAnyButtonClicked(object sender, ControllerClickedEventArgs e)
    {
        DestroyVideoPane();
    }
    /// <summary>
    /// When finish playing video, any controller button event and recieve from server,
    /// destroy video pane
    /// </summary>
    public void DestroyVideoPane()
    {
		hidePane = false;
        RemoveListner();
        mp.Control.Stop();
        Destroy(this.gameObject);
    }

	#endregion
}
