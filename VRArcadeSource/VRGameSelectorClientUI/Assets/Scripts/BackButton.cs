using UnityEngine;
using System.Collections;
using VGS;

public class BackButton : SteamVR_InteractableObject {
	public override void StartUsing(GameObject usingObject)
	{
		base.StartUsing(usingObject);
		VRSelectorCore.Instance.GenerateTiles (VRWorld.mainTiles);
		gameObject.SetActive (false);
		StopUsing (gameObject);
        VRSelectorCore.Instance.RemovePlayGamePane();
		fadeAngle = 0.3f;
	}

	public override void StopUsing(GameObject usingObject)
	{
		base.StopUsing(usingObject);
	}

	protected override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		base.FadeInOut ();
	}
}