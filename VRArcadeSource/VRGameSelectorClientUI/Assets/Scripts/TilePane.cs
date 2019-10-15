using UnityEngine;
using System.Collections;
using VRGameSelectorDTO;

public class TilePane : SteamVR_InteractableObject
{
    //	public Tile m_Tile;

    //private Renderer rend;
    //private Color baseColor;
    //private bool bFadeInOut = false;
    //private float fadeAngle = 0f;

    public override void StartUsing(GameObject usingObject)
    {
        base.StartUsing(usingObject);
        Debug.Log("Clciked Trigger Button");
        VRSelectorCore.Instance.RemovePlayGamePane();

        if (m_Tile.ChildTiles.Count > 0)
        {
            VRSelectorCore.Instance.GenerateTiles(m_Tile.ChildTiles);
            VRSelectorCore.Instance.ShowBackButton();
            SteamVR_SimplePointer pointer = VRSelectorCore.Instance.m_CameraRig.right.GetComponent<SteamVR_SimplePointer>();
            pointer.m_TileInfo.SetActive(false);
            fadeAngle = 0.4f;
            //InitializeColor();
        }
        else
        {
            //VRSelectorCore.Instance.SendPlayLog (m_Tile, this.transform);
            VRSelectorCore.Instance.ShowGamePlayPane(m_Tile, this.transform);

        }
    }

    public override void StopUsing(GameObject usingObject)
    {
        base.StopUsing(usingObject);
    }

    protected override void Start()
    {
        base.Start();

        //        if (m_Tile.ChildTiles.Count <= 0)
        //        {
        //            bFadeInOut = true;
        //            bfirstSelected = true;
        //            rend.material.color = new Color(baseColor.r, baseColor.g, baseColor.b, 0.3f);
        //            fadeAngle = rend.material.color.a;
        //            Invoke("InvokeInitFirstSelect", 0.5f);
        //        }
    }

    // Update is called once per frame
    void Update()
    {

        base.FadeInOut();

    }

    //	protected override void FadeIn ()
    //	{
    //		base.FadeIn ();
    //	}

    //    void InvokeInitFirstSelect()
    //    {
    //        bFadeInOut = false;
    //        bfirstSelected = false;
    //    }	
}