//====================================================================================
//
// Purpose: Provide basic laser pointer to VR Controller
//
// This script must be attached to a Controller within the [CameraRig] Prefab
//
// The SteamVR_ControllerEvents script must also be attached to the Controller
//
// Press the default 'Grip' button on the controller to activate the beam
// Released the default 'Grip' button on the controller to deactivate the beam
//
// This script is an implementation of the SteamVR_WorldPointer.
//
//====================================================================================

using UnityEngine;
using System.Collections;
using TMPro;

public class SteamVR_SimplePointer : SteamVR_WorldPointer
{
    public float pointerThickness = 0.002f;    
    public float pointerLength = 100f;
    public bool showPointerTip = true;
	public GameObject m_TileInfo;
	public PopupText m_TxtInfo;
	public Vector3 m_InitPos;

    private GameObject pointerHolder;
    private GameObject pointer;
    private GameObject pointerTip;
    private Vector3 pointerTipScale = new Vector3(0.05f, 0.05f, 0.05f);
	private bool firstFocus = false;

	public Vector3 pointerTipPosition = Vector3.zero;

    // Use this for initialization
    protected override void Start () {
        base.Start();
        InitPointer();

		if (m_TileInfo)
			m_TileInfo.SetActive (false);

		GetComponent<SteamVR_ControllerEvents>().TouchpadClicked += new ControllerClickedEventHandler(DoTouchpadClicked);
        GetComponent<SteamVR_ControllerEvents>().TriggerUnclicked += new ControllerClickedEventHandler(DoTriggerClicked);
    }

    protected override void InitPointer()
    {
        pointerHolder = new GameObject("PlayerObject_WorldPointer_SimplePointer_Holder");
        pointerHolder.transform.parent = this.transform;
        pointerHolder.transform.localPosition = Vector3.zero;

        pointer = GameObject.CreatePrimitive(PrimitiveType.Cube);
        pointer.transform.name = "PlayerObject_WorldPointer_SimplePointer_Pointer";
        pointer.transform.parent = pointerHolder.transform;

        pointer.GetComponent<BoxCollider>().isTrigger = true;
        pointer.AddComponent<Rigidbody>().isKinematic = true;
        pointer.layer = 2;

        pointerTip = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        pointerTip.transform.name = "PlayerObject_WorldPointer_SimplePointer_PointerTip";
        pointerTip.transform.parent = pointerHolder.transform;
        pointerTip.transform.localScale = pointerTipScale;

        pointerTip.GetComponent<SphereCollider>().isTrigger = true;
        pointerTip.AddComponent<Rigidbody>().isKinematic = true;
        pointerTip.layer = 2;

        base.InitPointer();

        SetPointerTransform(pointerLength, pointerThickness);

		if(GetComponentInParent<SteamVR_ControllerManager>().left == gameObject)
        	TogglePointer(false);
    }

    protected override void SetPointerMaterial()
    {
        base.SetPointerMaterial();
        pointer.GetComponent<MeshRenderer>().material = pointerMaterial;
        pointerTip.GetComponent<MeshRenderer>().material = pointerMaterial;
    }

    protected override void TogglePointer(bool state)
    {
        base.TogglePointer(state);
        pointer.gameObject.SetActive(state);
        bool tipState = (showPointerTip ? state : false);
        pointerTip.gameObject.SetActive(tipState);
    }

    protected override void DisablePointerBeam(object sender, ControllerClickedEventArgs e)
    {
        PointerSet();
        base.DisablePointerBeam(sender, e);
    }

	protected override void PointerSet()
	{
		if (!pointerContactTarget)
		{
			return;
		}

		SteamVR_InteractableObject interactableObject = pointerContactTarget.GetComponent<SteamVR_InteractableObject>();
		if (interactableObject && interactableObject.pointerActivatesUseAction)
		{			
			Debug.Log ("interactableObject.StartUsing(this.gameObject);");
			interactableObject.StartUsing(this.gameObject);
		}

		if (!playAreaCursorCollided && (interactableObject == null || !interactableObject.pointerActivatesUseAction))
		{
			OnWorldPointerDestinationSet(SetPointerEvent(controllerIndex, pointerContactDistance, pointerContactTarget, destinationPosition));
		}
	}

    private void SetPointerTransform(float setLength, float setThicknes)
    {
        //if the additional decimal isn't added then the beam position glitches
        float beamPosition = setLength / (2 + 0.00001f);

        pointer.transform.localScale = new Vector3(setThicknes, setThicknes, setLength);
        pointer.transform.localPosition = new Vector3(0f, 0f, beamPosition);
        pointerTip.transform.localPosition = new Vector3(0f, 0f, setLength - (pointerTip.transform.localScale.z / 2));
        pointerHolder.transform.localRotation = Quaternion.identity;
        base.SetPlayAreaCursorTransform(pointerTip.transform.position);
    }

    private float GetPointerBeamLength(bool hasRayHit, RaycastHit collidedWith)
    {
        float actualLength = pointerLength;

        //reset if beam not hitting or hitting new target
        if (!hasRayHit || (pointerContactTarget && pointerContactTarget != collidedWith.transform))
        {
            if (pointerContactTarget != null)
            {
                PointerOut();
            }


            if (pointerContactTarget && pointerContactTarget.GetComponent<SteamVR_InteractableObject>() != null)
            {
                pointerContactTarget.GetComponent<SteamVR_InteractableObject>().SelectTile(false);
            }

			if (pointerContactTarget && pointerContactTarget.GetComponent<TilePane> () != null) {

				if (m_TileInfo && m_TileInfo.activeSelf)
					m_TileInfo.SetActive (false);
			}
			
            pointerContactDistance = 0f;
            pointerContactTarget = null;
            destinationPosition = Vector3.zero;

            UpdatePointerMaterial(pointerMissColor);
        }

        //check if beam has hit a new target
        if (hasRayHit)
        {
            if (collidedWith.transform.GetComponent<SteamVR_InteractableObject>() != null)
            {
                collidedWith.transform.GetComponent<SteamVR_InteractableObject>().SelectTile(true);
            }

			if (collidedWith.transform.GetComponent<TilePane> () != null) {
				PointerIn ();
				if (m_TileInfo && !m_TileInfo.activeSelf) {
					m_TxtInfo.SetContent (collidedWith.transform.GetComponent<TilePane> ().m_Tile.ImageDesc);
					m_TxtInfo.GetComponent<PopupText> ().SetOriginalPosition ();

					if (GameObject.FindObjectOfType<GamePlayPane> ()) {
						m_TileInfo.SetActive (false);
					} else {
						m_TileInfo.SetActive (true);
					}                    
				}
			} else {
				PointerOut();
			}
			
            pointerContactDistance = collidedWith.distance;
            pointerContactTarget = collidedWith.transform;
            destinationPosition = pointerTip.transform.position;
			pointerTipPosition = destinationPosition;

            UpdatePointerMaterial(pointerHitColor);            
        }

        //adjust beam length if something is blocking it
        if (hasRayHit && pointerContactDistance < pointerLength)
        {
            actualLength = pointerContactDistance;
        }

        return actualLength;
    }

	protected override void PointerIn()
	{
		if (!pointerContactTarget)
		{
			return;
		}

		OnWorldPointerIn(SetPointerEvent(controllerIndex, pointerContactDistance, pointerContactTarget, destinationPosition));

		SteamVR_InteractableObject interactableObject = pointerContactTarget.GetComponent<SteamVR_InteractableObject>();
		if (interactableObject && interactableObject.pointerActivatesUseAction && !firstFocus)
		{
			firstFocus = true;
			interactableObject.FadeIn();
		}
	}

	protected override void PointerOut()
	{
		if (!pointerContactTarget)
		{
			return;
		}

		OnWorldPointerOut(SetPointerEvent(controllerIndex, pointerContactDistance, pointerContactTarget, destinationPosition));

		SteamVR_InteractableObject interactableObject = pointerContactTarget.GetComponent<SteamVR_InteractableObject>();
		if (interactableObject && interactableObject.pointerActivatesUseAction && firstFocus)
		{
			firstFocus = false;
			interactableObject.FadeIn();
		}
	}

    // Update is called once per frame
    private void Update () {
        if (pointer.gameObject.activeSelf)
        {
            Ray pointerRaycast = new Ray(transform.position, transform.forward);
            RaycastHit pointerCollidedWith;
            bool rayHit = Physics.Raycast(pointerRaycast, out pointerCollidedWith);
            float pointerBeamLength = GetPointerBeamLength(rayHit, pointerCollidedWith);
            SetPointerTransform(pointerBeamLength, pointerThickness);
        }
    }

	void DoTouchpadClicked(object sender, ControllerClickedEventArgs e)
	{
		if (!pointerContactTarget || !pointerContactTarget.GetComponent<TilePane> ())
			return;

		if (m_TileInfo && m_TileInfo.activeSelf) {
			if (e.touchpadAxis.y > 0.4f)
				m_TxtInfo.Down ();
			else if (e.touchpadAxis.y < -0.4f)
				m_TxtInfo.Up ();
		}
	}

    void DoTriggerClicked(object sender, ControllerClickedEventArgs e)
    {
        if (!pointerContactTarget)
            return;

        if (pointerContactTarget.GetComponent<SteamVR_InteractableObject>())
        {
            ReceivedMessageEventArg msg;
			msg.message = "User Clicked Trigger button On the HelpTile";
            pointerContactTarget.GetComponent<SteamVR_InteractableObject>().DoShowSubPanel(this, msg);
        }
    }    
}