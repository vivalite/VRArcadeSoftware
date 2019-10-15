using UnityEngine;
using System.Collections;

//-----------------------------------------------------------------------------
// Copyright 2015-2016 RenderHeads Ltd.  All rights reserverd.
//-----------------------------------------------------------------------------

namespace RenderHeads.Media.AVProVideo.Demos
{
	[RequireComponent(typeof(Transform))]
	public class AutoRotate : MonoBehaviour
	{
		private float x, y, z;
		private float _timer;

		void Awake()
		{
			Randomise();
		}
		void Update()
		{
			this.transform.Rotate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
			_timer -= Time.deltaTime;
			if (_timer <= 0f)
			{
				Randomise();
			}
		}

		private void Randomise()
		{
			float s = 32f;
			x = Random.Range(-s, s);
			y = Random.Range(-s, s);
			z = Random.Range(-s, s);
			_timer = Random.Range(5f, 10f);
		}
	}
}