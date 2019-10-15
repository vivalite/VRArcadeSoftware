using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//-----------------------------------------------------------------------------
// Copyright 2015-2016 RenderHeads Ltd.  All rights reserverd.
//-----------------------------------------------------------------------------

using RenderHeads.Media.AVProVideo;

namespace RenderHeads.Media.AVProVideo.Demos
{
	/// <summary>
	/// Simple GUI built using IMGUI to show scripting examples
	/// </summary>
	public class SimpleController : MonoBehaviour
	{
		public string[] _filenames = new string[] { "SampleSphere.mp4", "BigBuckBunny_360p30.mp3", "BigBuckBunny_720p30.mp4" };
		public string[] _streams;
		public MediaPlayer _mediaPlayer;
		public DisplayIMGUI _display;
		public GUISkin _guiSkin;

		private int _width;
		private int _height;
		private float _duration;
		public bool _useFading = true;
		private Queue<string> _eventLog = new Queue<string>(8);
        private float _eventTimer = 1f;
		private MediaPlayer.FileLocation _nextVideoLocation;
		private string _nextVideoPath;
		//private bool _seekDragStarted;
        //private bool _seekDragWasPlaying;

        void Start()
		{
			_mediaPlayer.Events.AddListener(OnMediaPlayerEvent);
		}

		// Callback function to handle events
		public void OnMediaPlayerEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode errorCode)
		{
			switch (et)
			{
				case MediaPlayerEvent.EventType.ReadyToPlay:
					break;
				case MediaPlayerEvent.EventType.Started:
					break;
				case MediaPlayerEvent.EventType.FirstFrameReady:
					break;
				case MediaPlayerEvent.EventType.MetaDataReady:
					GatherProperties();
					break;
				case MediaPlayerEvent.EventType.FinishedPlaying:
					break;
			}

            AddEvent(et);
		}

        private void AddEvent(MediaPlayerEvent.EventType et)
        {
			Debug.Log("[SimpleController] Event: " + et.ToString());
            _eventLog.Enqueue(et.ToString());
            if (_eventLog.Count > 5)
            {
                _eventLog.Dequeue();
                _eventTimer = 1f;
            }
        }

        private void GatherProperties()
		{
			_width = _mediaPlayer.Info.GetVideoWidth();
			_height = _mediaPlayer.Info.GetVideoHeight();
			_duration = _mediaPlayer.Info.GetDurationMs() / 1000f;
		}

		void Update()
		{
			if (!_useFading)
			{
				_display._color = Color.white;
				_display._mediaPlayer.Control.SetVolume(1f);
			}

            if (_eventLog != null && _eventLog.Count > 0)
            {
                _eventTimer -= Time.deltaTime;
                if (_eventTimer < 0f)
                {
                    _eventLog.Dequeue();
                    _eventTimer = 1f;
                }
            }
		}

		private void LoadVideo(string filePath, bool url = false)
		{
			// Set the video file name and to load. 
			if (!url)
				_nextVideoLocation = MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder;
			else
				_nextVideoLocation = MediaPlayer.FileLocation.AbsolutePathOrURL;
			_nextVideoPath = filePath;

			// IF we're not using fading then load the video immediately
			if (!_useFading)
			{
				// Load the video
				if (!_mediaPlayer.OpenVideoFromFile(_nextVideoLocation, _nextVideoPath, _mediaPlayer.m_AutoStart))
				{
					Debug.LogError("Failed to open video!");
				}
			}
			else
			{
				StartCoroutine("LoadVideoWithFading");
			}
		}

		private IEnumerator LoadVideoWithFading()
		{
			const float FadeDuration = 0.25f;
			float fade = FadeDuration;

			// Fade down
			while (fade > 0f && Application.isPlaying)
			{
				fade -= Time.deltaTime;
				fade = Mathf.Clamp(fade, 0f, FadeDuration);

				_display._color = new Color(1f, 1f, 1f, fade / FadeDuration);
				_display._mediaPlayer.Control.SetVolume(fade / FadeDuration);

				yield return null;
			}

			// Wait 3 frames for display object to update
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();

			// Load the video
			if (Application.isPlaying)
			{
				if (!_mediaPlayer.OpenVideoFromFile(_nextVideoLocation, _nextVideoPath, _mediaPlayer.m_AutoStart))
				{
					Debug.LogError("Failed to open video!");
				}
				else
				{
					// Wait for the first frame to come through (could also use events for this)
					while (Application.isPlaying && !_mediaPlayer.Control.IsPlaying() && _mediaPlayer.TextureProducer.GetTextureFrameCount() <= 0)
					{
						yield return null;
					}

					// Wait 3 frames for display object to update
					yield return new WaitForEndOfFrame();
					yield return new WaitForEndOfFrame();
					yield return new WaitForEndOfFrame();
				}
			}

			// Fade up
			while (fade < FadeDuration && Application.isPlaying)
			{
				fade += Time.deltaTime;
				fade = Mathf.Clamp(fade, 0f, FadeDuration);

				_display._color = new Color(1f, 1f, 1f, fade / FadeDuration);
				_display._mediaPlayer.Control.SetVolume(fade / FadeDuration);

				yield return null;
			}
		}

		void OnGUI()
		{
			// Make sure we're set to render after the background IMGUI
			GUI.depth = -10;

			// Apply skin
			if (_guiSkin != null)
			{
				GUI.skin = _guiSkin;
			}

			// Make sure the UI scales with screen resolution
			const float UIWidth = 1920f / 2.0f;
			const float UIHeight = 1080f / 2.0f;
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / UIWidth, Screen.height / UIHeight, 1f));

			GUILayout.BeginVertical("box");

			if (_mediaPlayer.Control != null)
			{
				// Display properties
				GUILayout.Label("Loaded: " + _mediaPlayer.m_VideoPath);
				GUILayout.Label("Size: " + _width + "x" + _height + "   Duration: " + Helper.GetTimeString(_duration));
				GUILayout.Label("Updates: " + _mediaPlayer.TextureProducer.GetTextureFrameCount() + "    Rate: " + _mediaPlayer.Info.GetVideoPlaybackRate().ToString("F1"));

				GUILayout.BeginHorizontal();

				// Fade option
				_useFading = GUILayout.Toggle(_useFading, "Fade to Black During Loading");

				// Auto play
				_mediaPlayer.m_AutoStart = GUILayout.Toggle(_mediaPlayer.m_AutoStart, "Auto Play After Load");

				// Looping
				bool loopStatus = _mediaPlayer.m_Loop;
				bool newLoopStatus = GUILayout.Toggle(loopStatus, "Loop");
				if (newLoopStatus != loopStatus)
				{
					_mediaPlayer.m_Loop = newLoopStatus;
					_mediaPlayer.Control.SetLooping(newLoopStatus);
				}

				GUILayout.EndHorizontal();

				// Timeline scrubbing
				float currentTime = _mediaPlayer.Control.GetCurrentTimeMs() / 1000f;
				float newTime = GUILayout.HorizontalSlider(currentTime, 0f, _duration);
				if (newTime != currentTime)
				{
					/*if (Event.current.type == EventType.MouseDown)
					{
						_seekDragStarted = true;
						_seekDragWasPlaying = _mediaPlayer.Control.IsPlaying();
						_mediaPlayer.Control.Pause();
					}*/
					_mediaPlayer.Control.Seek(newTime * 1000f);
				}

				/*if (_seekDragWasPlaying && Event.current.type == EventType.MouseUp)
				{
					Debug.Log("up!");
					_seekDragWasPlaying = false;
					if (_seekDragWasPlaying)
						_mediaPlayer.Control.Play();
				}*/


				if (!_mediaPlayer.Control.IsPlaying())
				{
					if (GUILayout.Button("Play"))
					{
						_mediaPlayer.Control.Play();
					}
				}
				else
				{
					if (GUILayout.Button("Pause"))
					{
						_mediaPlayer.Control.Pause();
					}
				}
			}		

			GUILayout.Label("Select a new file to play:");

			// Display a grid of buttons containing the file names of videos to play
			int newSelection = GUILayout.SelectionGrid(-1, _filenames, 3);
			if (newSelection >= 0)
			{
				LoadVideo(_filenames[newSelection]);
			}

			GUILayout.Space(8f);

			GUILayout.Label("Select a new stream to play:");

			// Display a grid of buttons containing the file names of videos to play
			int newSteam = GUILayout.SelectionGrid(-1, _streams, 1);
			if (newSteam >= 0)
			{
				LoadVideo(_streams[newSteam], true);
			}

			GUILayout.Space(8f);

			GUILayout.Label("Recent Events: ");
            GUILayout.BeginVertical("box");
            int eventIndex = 0;
            foreach (string eventString in _eventLog)
            {
                GUI.color = Color.white;
                if (eventIndex == 0)
                {
                    GUI.color = new Color(1f, 1f, 1f, _eventTimer);
                }
                GUILayout.Label(eventString);
                eventIndex++;
            }
            GUILayout.EndVertical();
            GUI.color = Color.white;


            GUILayout.EndVertical();
		}
	}
}
