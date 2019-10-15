using UnityEngine;

public class DisableOnStart : MonoBehaviour
{
	public void Start()
    {
	    gameObject.SetActive(false);
	}
}
