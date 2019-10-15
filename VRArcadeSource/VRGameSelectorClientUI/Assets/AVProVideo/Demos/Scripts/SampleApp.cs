using UnityEngine;
using System.Collections;

//-----------------------------------------------------------------------------
// Copyright 2015-2016 RenderHeads Ltd.  All rights reserverd.
//-----------------------------------------------------------------------------

namespace RenderHeads.Media.AVProVideo.Demos
{
	public class SampleApp : MonoBehaviour
	{
		void Update()
		{
#if UNITY_ANDROID
			// To handle 'back' button on Android devices
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}
#endif
		}
	}
}