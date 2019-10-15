using UnityEngine;
using System.Collections;

public class LoadConfig : SteamVR_InteractableObject {
	public override void StartUsing(GameObject usingObject)
	{
		base.StartUsing(usingObject);
		VRSelectorCore.Instance.GetConfiguration ();
		gameObject.SetActive (false);
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

	}
}