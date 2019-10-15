using UnityEngine;
using RenderHeads.Media.AVProVideo;

//-----------------------------------------------------------------------------
// Copyright 2015-2016 RenderHeads Ltd.  All rights reserverd.
//-----------------------------------------------------------------------------

namespace RenderHeads.Media.AVProVideo.Demos
{
	public class ChangeVideoExample : MonoBehaviour
	{
		public MediaPlayer mp;

		public void NewVideo(string filePath)
		{
			mp.m_AutoStart = true;
			mp.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, filePath, false);
		}

		void OnGUI()
		{
			if (GUILayout.Button("video1"))
			{
				NewVideo("video1.mp4");
			}

			if (GUILayout.Button("video2"))
			{
				NewVideo("video2.mp4");
			}
		}
	}
}