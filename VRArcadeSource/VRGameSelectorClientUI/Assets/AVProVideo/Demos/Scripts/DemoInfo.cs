using UnityEngine;
using System.Collections;

//-----------------------------------------------------------------------------
// Copyright 2015-2016 RenderHeads Ltd.  All rights reserverd.
//-----------------------------------------------------------------------------

namespace RenderHeads.Media.AVProVideo.Demos
{
	public class DemoInfo : MonoBehaviour 
	{
		public string _title;

		[Multiline]
		public string _description;
		public MediaPlayer	_media;
	}
}