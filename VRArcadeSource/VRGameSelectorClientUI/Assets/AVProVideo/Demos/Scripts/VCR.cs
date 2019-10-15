#if UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_5
#define UNITY_FEATURE_UGUI
#endif

using UnityEngine;
#if UNITY_FEATURE_UGUI
using UnityEngine.UI;
using System.Collections;
using RenderHeads.Media.AVProVideo;

//-----------------------------------------------------------------------------
// Copyright 2015-2016 RenderHeads Ltd.  All rights reserverd.
//-----------------------------------------------------------------------------

namespace RenderHeads.Media.AVProVideo.Demos
{
	public class VCR : MonoBehaviour 
	{
		public MediaPlayer	_mediaPlayer;

		public Slider		_videoSeekSlider;
		private float		_setVideoSeekSliderValue;
		private bool		_wasPlayingOnScrub;

		public Slider		_audioVolumeSlider;
		private float		_setAudioVolumeSliderValue;

		public Toggle		_AutoStartToggle;
		public Toggle		_MuteToggle;

		public string[] _videoFiles = { "BigBuckBunny_720p30.mp4", "SampleSphere.mp4" };

#if false
		public void OnOpenVideoFile()
 		{
			_mediaPlayer.OpenVideoFromFile();

			RemoveOpenVideoButton();

//			SetButtonEnabled( "PlayButton", !_mediaPlayer.m_AutoStart );
//			SetButtonEnabled( "PauseButton", _mediaPlayer.m_AutoStart );
		}
#else
		private int _VideoIndex = 0;

		public void OnOpenVideoFile()
 		{
			_mediaPlayer.m_VideoPath = string.Empty;
			_mediaPlayer.m_VideoPath = _videoFiles[_VideoIndex];
			_VideoIndex = (_VideoIndex + 1) % (_videoFiles.Length);
			if (string.IsNullOrEmpty(_mediaPlayer.m_VideoPath))
			{
				_mediaPlayer.CloseVideo();
				_VideoIndex = 0;
			}
			else
			{
				_mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, _mediaPlayer.m_VideoPath, _AutoStartToggle.isOn);
//				SetButtonEnabled( "PlayButton", !_mediaPlayer.m_AutoStart );
//				SetButtonEnabled( "PauseButton", _mediaPlayer.m_AutoStart );
			}
		}
#endif

		public void OnAutoStartChange()
		{
			if( _mediaPlayer && 
				_AutoStartToggle && _AutoStartToggle.enabled && 
				_mediaPlayer.m_AutoStart != _AutoStartToggle.isOn )
			{
				_mediaPlayer.m_AutoStart = _AutoStartToggle.isOn;
			}
		}
		
		public void OnMuteChange()
		{
			if (_mediaPlayer)
			{
				_mediaPlayer.Control.MuteAudio(_MuteToggle.isOn);
			}
		}

		public void OnPlayButton()
		{
			if( _mediaPlayer )
			{
				_mediaPlayer.Control.Play();
//				SetButtonEnabled( "PlayButton", false );
//				SetButtonEnabled( "PauseButton", true );
			}
		}
		public void OnPauseButton()
		{
			if( _mediaPlayer )
			{
				_mediaPlayer.Control.Pause();
//				SetButtonEnabled( "PauseButton", false );
//				SetButtonEnabled( "PlayButton", true );
			}
		}

		public void OnVideoSeekSlider()
		{
			if (_mediaPlayer && _videoSeekSlider && _videoSeekSlider.value != _setVideoSeekSliderValue)
			{
				_mediaPlayer.Control.Seek(_videoSeekSlider.value * _mediaPlayer.Info.GetDurationMs());
			}
		}
		public void OnVideoSliderDown()
		{
			if( _mediaPlayer )
			{
				_wasPlayingOnScrub = _mediaPlayer.Control.IsPlaying();
				if( _wasPlayingOnScrub )
				{
					_mediaPlayer.Control.Pause();
//					SetButtonEnabled( "PauseButton", false );
//					SetButtonEnabled( "PlayButton", true );
				}
				OnVideoSeekSlider();
			}
		}
		public void OnVideoSliderUp()
		{
			if( _mediaPlayer && _wasPlayingOnScrub )
			{
				_mediaPlayer.Control.Play();
				_wasPlayingOnScrub = false;

//				SetButtonEnabled( "PlayButton", false );
//				SetButtonEnabled( "PauseButton", true );
			}			
		}

		public void OnAudioVolumeSlider()
		{
			if (_mediaPlayer && _audioVolumeSlider && _audioVolumeSlider.value != _setAudioVolumeSliderValue)
			{
				_mediaPlayer.Control.SetVolume(_audioVolumeSlider.value);
			}
		}
//		public void OnMuteAudioButton()
//		{
//			if( _mediaPlayer )
//			{
//				_mediaPlayer.Control.MuteAudio( true );
//				SetButtonEnabled( "MuteButton", false );
//				SetButtonEnabled( "UnmuteButton", true );
//			}
//		}
//		public void OnUnmuteAudioButton()
//		{
//			if( _mediaPlayer )
//			{
//				_mediaPlayer.Control.MuteAudio( false );
//				SetButtonEnabled( "UnmuteButton", false );
//				SetButtonEnabled( "MuteButton", true );
//			}
//		}

		public void OnRewindButton()
		{
			if( _mediaPlayer )
			{
				_mediaPlayer.Control.Rewind();
			}
		}

		void Start()
		{
			if( _mediaPlayer )
			{
				_mediaPlayer.Events.AddListener(OnVideoEvent);

				if( _audioVolumeSlider )
				{
					// Volume
					float volume = _mediaPlayer.Control.GetVolume();
					_setAudioVolumeSliderValue = volume;
					_audioVolumeSlider.value = volume;
				}

				// Auto start toggle
				_AutoStartToggle.isOn = _mediaPlayer.m_AutoStart;

				if( _mediaPlayer.m_AutoOpen )
				{
//					RemoveOpenVideoButton();

//					SetButtonEnabled( "PlayButton", !_mediaPlayer.m_AutoStart );
//					SetButtonEnabled( "PauseButton", _mediaPlayer.m_AutoStart );
				}
				else
				{
//					SetButtonEnabled( "PlayButton", false );
//					SetButtonEnabled( "PauseButton", false );
				}

//				SetButtonEnabled( "MuteButton", !_mediaPlayer.m_Muted );
//				SetButtonEnabled( "UnmuteButton", _mediaPlayer.m_Muted );

				OnOpenVideoFile();
			}
		}

		void Update()
		{
			if (_mediaPlayer && _mediaPlayer.Info != null && _mediaPlayer.Info.GetDurationMs() > 0f)
			{
				float time = _mediaPlayer.Control.GetCurrentTimeMs();
				float d = time / _mediaPlayer.Info.GetDurationMs();
				_setVideoSeekSliderValue = d;
				_videoSeekSlider.value = d;
			}
		}

		// Callback function to handle events
		public void OnVideoEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode errorCode)
		{
			switch (et)
			{
				case MediaPlayerEvent.EventType.ReadyToPlay:
				break;
				case MediaPlayerEvent.EventType.Started:
				break;
				case MediaPlayerEvent.EventType.FirstFrameReady:
				break;
				case MediaPlayerEvent.EventType.FinishedPlaying:
				break;
			}

			Debug.Log("Event: " + et.ToString());
		}

//		private void SetButtonEnabled( string objectName, bool bEnabled )
//		{
//			Button button = GameObject.Find( objectName ).GetComponent<Button>();
//			if( button )
//			{
//				button.enabled = bEnabled;
//				button.GetComponentInChildren<CanvasRenderer>().SetAlpha( bEnabled ? 1.0f : 0.4f );
//				button.GetComponentInChildren<Text>().color = Color.clear;
//			}
//		}

//		private void RemoveOpenVideoButton()
//		{
//			Button openVideoButton = GameObject.Find( "OpenVideoButton" ).GetComponent<Button>();
//			if( openVideoButton )
//			{
//				openVideoButton.enabled = false;
//				openVideoButton.GetComponentInChildren<CanvasRenderer>().SetAlpha( 0.0f );
//				openVideoButton.GetComponentInChildren<Text>().color = Color.clear;
//			}
//
//			if( _AutoStartToggle )
//			{
//				_AutoStartToggle.enabled = false;
//				_AutoStartToggle.isOn = false;
//				_AutoStartToggle.GetComponentInChildren<CanvasRenderer>().SetAlpha( 0.0f );
//				_AutoStartToggle.GetComponentInChildren<Text>().color = Color.clear;
//				_AutoStartToggle.GetComponentInChildren<Image>().enabled = false;
//				_AutoStartToggle.GetComponentInChildren<Image>().color = Color.clear;
//			}
//		}
	}
}
#endif