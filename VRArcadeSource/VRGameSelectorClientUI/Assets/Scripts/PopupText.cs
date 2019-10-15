using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PopupText : MonoBehaviour {
	public GameObject m_Arrow;

	private string m_Content;
	//private TextMeshPro m_TxtMesh;
	public Text m_txt;
	private int m_nLine;

	const int LineCount = 10;

	private float textlineHeight = 0.015f;
	private float thresholdLineHeight = 0.16f;
	private float maxUptxtHeight;
	private float minDownHeight = -0.03f;
	private float scrollSpeed = 0.005f;
	private float baseY = 0f;

	public void Initilaize(){

		//TMP_TextInfo info = m_TxtMesh.GetTextInfo (m_TxtMesh.text);

		maxUptxtHeight = m_txt.cachedTextGenerator.lineCount * textlineHeight - thresholdLineHeight;
		minDownHeight = -thresholdLineHeight;
	}

	void Awake()
	{
		baseY = transform.localPosition.y;
	}
	// Use this for initialization
	void Start () {
		m_txt = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetContent(string sContent) {
		if (m_txt == null)
			m_txt = gameObject.GetComponent<Text> ();

		m_Content = sContent;
		m_txt.text = sContent;
		Initilaize ();
		//m_nLine = 0;
		//CheckMoreContent ();
	}

//	public void Up() {
//		m_TxtMesh.OverflowMode = TextOverflowModes.Overflow;
//		TMP_TextInfo info = m_TxtMesh.GetTextInfo (m_TxtMesh.text);
//		m_TxtMesh.OverflowMode = TextOverflowModes.Ellipsis;
//
//		if (info.lineCount <= LineCount)
//			return;
//		
//		m_nLine++;
//		m_TxtMesh.text = m_TxtMesh.text.Substring (info.lineInfo [0].characterCount);
//		CheckMoreContent ();
//	}
//
//	public void Down() {
//		if (m_nLine == 0)
//			return;
//
//		m_nLine--;
//		m_TxtMesh.text = m_Content;
//
//		for (int i = 0; i < m_nLine; i++) {
//			TMP_TextInfo info = m_TxtMesh.GetTextInfo (m_TxtMesh.text);
//			m_TxtMesh.text = m_TxtMesh.text.Substring (info.lineInfo [0].characterCount);
//		}
//
//		CheckMoreContent ();
//	}
	void CheckMoreContent() {
		Text txt = gameObject.GetComponent<Text> ();
		//txt.text = 
		//		m_TxtMesh.OverflowMode = TextOverflowModes.Overflow;
//		TMP_TextInfo info = m_TxtMesh.GetTextInfo (m_TxtMesh.text);
//		m_TxtMesh.OverflowMode = TextOverflowModes.Ellipsis;
		m_Arrow.SetActive(txt.cachedTextGenerator.lineCount > LineCount);
	}

	public void Up()
	{
		float y = this.transform.localPosition.y + scrollSpeed;
		Debug.Log ("y value" + y + "mndown Value" + minDownHeight);
		if (y > maxUptxtHeight) {
			m_Arrow.SetActive(false);
			return;
		}

		m_Arrow.SetActive(true);

		SetLocalPosition (y);

	}

	public void Down()
	{		
		float y = this.transform.localPosition.y - scrollSpeed;

		if (y < minDownHeight) {
			return;
		}

		m_Arrow.SetActive(true);

		SetLocalPosition (y);
	}

	void SetLocalPosition(float delta)
	{		
		Vector3 localPos = new Vector3 (transform.localPosition.x, delta, transform.localPosition.z);
		this.transform.localPosition = localPos;
	}

	public void SetOriginalPosition()
	{
		transform.localPosition = new Vector3 (transform.localPosition.x, baseY, transform.localPosition.z);
	}
}