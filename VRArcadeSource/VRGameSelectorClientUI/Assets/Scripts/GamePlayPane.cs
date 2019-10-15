using UnityEngine;
using System;
using System.Collections;
using util.commom;
using util.constants;
using VRGameSelectorDTO;
using RenderHeads.Media.AVProVideo;

public struct COLOR_VALUE
{
    public Color selectedColor;
    public Color unSelectedColor;
}

public class GamePlayPane : SteamVR_InteractableObject
{
    public GameObject m_parent;
    public Tile tile;
    public Color m_initColor;
    public Color m_highlightColor;
    public Color m_initFontColor;
    public Color m_selectFontColor;

    public GameObject txtObject;

    //public Color m_initColor = Color.white;
    //public Color m_color = Color.white;

    //public Renderer rend;

    #region VIDEO_URL
    private VideoInfo m_videoInfo;
    public VideoInfo videoInfo { set { m_videoInfo = value; } }
    #endregion

    #region derivation classes
    public override void StartUsing(GameObject usingObject)
    {
        base.StartUsing(usingObject);
    }
    public override void StopUsing(GameObject usingObject)
    {
        base.StopUsing(usingObject);
    }

    public override void SelectTile(bool bSelected)
    {
        if (bSelected)
        {
            GetComponent<Renderer>().material.color = m_highlightColor;
            txtObject.GetComponent<Renderer>().material.color = m_selectFontColor;
        }
        else
        {
            GetComponent<Renderer>().material.color = m_initColor;
            txtObject.GetComponent<Renderer>().material.color = m_initFontColor;
        }
    }

    protected override void Start()
    {
        base.Start();
        //Initialize();
    }
    #endregion


    //    private void Initialize()
    //    {
    //        rend = GetComponent<Renderer>();
    //        m_initColor = rend.material.color;
    //		m_initFontColor = txtObject.GetComponent<Renderer> ().material.color;

    //		if (gameObject.name == "playgame") {
    //			rend.material.color = m_highlightColor;
    //			txtObject.GetComponent<Renderer> ().material.color = m_selectFontColor;
    //		}
    //    }
    // Update is called once per frame
    void Update()
    {

    }
    #region Trailer and Game Play Pane
    /// <summary>
    /// when click trigger button on game tile, show up trailer and play game pane
    /// show up "Introduction image".
    /// </summary>
    public override void DoShowSubPanel(object sender, ReceivedMessageEventArg e)
    {
        base.DoShowSubPanel(sender, e);

        if (e.message.Equals("This Square is intend to show basic instructions."))
            return;

        PlayVideoEvent();
    }
    /// <summary>
    /// Create video pane or game loading pane and play specified video
    /// And then destroy this gameobject
    /// </summary>
    void PlayVideoEvent()
    {
        if (this.gameObject.name.Equals(Constants.CONSTANTS_TRAILER_NAME))
        {
            GenerateTrailerPane();
        }
        else if (this.gameObject.name.Equals(Constants.CONSTANTS_PLAYGAME_NAME))
        {
            GenerateGameLoadingPane();
        }

        Destroy(m_parent);
    }

    /// <summary>
    /// generate trailer(video) pane
    /// </summary>
    private void GenerateTrailerPane()
    {
        GameObject trailerPane = Util.GenerateObject(Constants.CONSTANTS_PLAY_VIDEO_PANE_PATH, Constants.CONSTANTS_PlAY_VIDEO_LOCALPOSITION,
                Constants.CONSTANTS_PlAY_VIDEO_LOACLROTATION, null);

        if (string.IsNullOrEmpty(m_videoInfo.videoUrls))
        {

            Debug.LogError("Sorry, To play video, you have to set Video Urls.");
            return;
        }

        MediaPlayer mp = trailerPane.GetComponent<MediaPlayer>();
        mp.m_VideoPath = m_videoInfo.videoUrls;
        mp.m_Volume = m_videoInfo.videoVolume;
        mp.m_Loop = m_videoInfo.videoLoop;

        trailerPane.GetComponent<TextMesh>().text = "";
    }
    /// <summary>
    /// While loading game from server, 
    /// show up game loading pane(Text and Camera fade effect)
    /// </summary>
    private void GenerateGameLoadingPane()
    {
        //        SteamVR_Camera camera = GameObject.FindObjectOfType<SteamVR_Camera>();
        //        GameObject loadingPane = Util.GenerateObject(Constants.CONSTANTS_LOADING_GAME_PANE_PATH, Constants.CONSTANTS_LOADING_GAME_PANE_LOCALPOSITION,
        //                                           Constants.CONSTANTS_LOADING_GAME_PANE_LOCALROTATION, camera.transform);

        //		SteamVR_Fade.Start(new Color(0f, 0f, 0f, 0.7f), 0);

        //        VRSelectorCore.Instance.m_loadingPane = loadingPane;
        VRSelectorCore.Instance.m_loadingPane.SetActive(true);
        VRSelectorCore.Instance.GameState = Game_State.LoadingGame;
        VRSelectorCore.Instance.SendPlayLog(tile, this.transform);
    }
    #endregion
}
