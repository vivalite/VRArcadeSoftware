using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RenderHeads.Media.AVProVideo.Demos
{
	public class Mapping3D : MonoBehaviour
	{
		public GameObject _cubePrefab;
		private const int MaxCubes = 48;
		private const float SpawnTime = 0.25f;
		private float _timer = SpawnTime;
		private List<GameObject> _cubes = new List<GameObject>(32);

		void Update()
		{
			_timer -= Time.deltaTime;
			if (_timer <= 0f)
			{
				_timer = SpawnTime;
				SpawnCube();
				if (_cubes.Count > MaxCubes)
				{
					RemoveCube();
				}
			}
		}

		private void SpawnCube()
		{
			Quaternion rotation = Quaternion.Euler(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f));
			float scale = Random.Range(0.1f, 0.6f);

			GameObject go = (GameObject)GameObject.Instantiate(_cubePrefab, this.transform.position, rotation);
			Transform t = go.GetComponent<Transform>();
			t.localScale = new Vector3(scale, scale, scale);
			_cubes.Add(go);
		}

		private void RemoveCube()
		{
			GameObject go = _cubes[0];
			_cubes.RemoveAt(0);
			Destroy(go);
		}
	}
}