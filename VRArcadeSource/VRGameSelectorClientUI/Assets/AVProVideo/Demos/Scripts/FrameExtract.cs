#if !UNITY_WEBPLAYER
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR
	#define AVPRO_FILESYSTEM_SUPPORT
#endif
#endif
using UnityEngine;
using System.Collections;

namespace RenderHeads.Media.AVProVideo.Demos
{
	public class FrameExtract : MonoBehaviour
	{
		private const int NumFrames = 8;
		public MediaPlayer _mediaPlayer;
		public bool _accurateSeek = false;
		public int _timeoutMs = 250;
		public GUISkin _skin;

#if AVPRO_FILESYSTEM_SUPPORT
		public bool _saveToJPG = false;
		private string _filenamePrefix;
#endif
		private float _timeStepSeconds;
		private int _frameIndex = -1;
		private Texture2D _texture;
		private RenderTexture _displaySheet;

		void Start()
		{
			_mediaPlayer.Events.AddListener(OnMediaPlayerEvent);

			// Create a texture to draw the thumbnails on
			_displaySheet = RenderTexture.GetTemporary(Screen.width, Screen.height, 0);
			_displaySheet.useMipMap = false;
			_displaySheet.generateMips = false;
			_displaySheet.antiAliasing = 1;
			_displaySheet.Create();

			// Clear the texture
			RenderTexture.active = _displaySheet;
			GL.Clear(false, true, Color.black, 0f);
			RenderTexture.active = null;
		}

		public void OnMediaPlayerEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode errorCode)
		{
			switch (et)
			{
				case MediaPlayerEvent.EventType.MetaDataReady:
					// Android platform doesn't display its first frame until poked
					mp.Play();
					mp.Pause();
					break;
				case MediaPlayerEvent.EventType.FirstFrameReady:
					OnNewMediaReady();
					break;
			}
		}

		private void OnNewMediaReady()
		{
			IMediaInfo info = _mediaPlayer.Info;

			// Create a texture the same resolution as our video
			if (_texture != null)
			{
				Texture2D.Destroy(_texture);
				_texture = null;
			}
			_texture = new Texture2D(info.GetVideoWidth(), info.GetVideoHeight(), TextureFormat.ARGB32, false);

			_timeStepSeconds = (_mediaPlayer.Info.GetDurationMs() / 1000f) / (float)NumFrames;
#if AVPRO_FILESYSTEM_SUPPORT
			_filenamePrefix = _mediaPlayer.m_VideoPath;
#endif
		}

		void OnDestroy()
		{
			if (_texture != null)
			{
				Texture2D.Destroy(_texture);
				_texture = null;
			}

			if (_displaySheet != null)
			{
				RenderTexture.ReleaseTemporary(_displaySheet);
				_displaySheet = null;
			}
		}

		void Update()
		{
			if (_texture != null && _frameIndex >=0 && _frameIndex < NumFrames)
			{
				ExtractNextFrame();
				_frameIndex++;
			}
		}

		private void ExtractNextFrame()
		{
			// Extract the frame to Texture2D
			float timeSeconds = _frameIndex * _timeStepSeconds;
			_texture = _mediaPlayer.ExtractFrame(_texture, timeSeconds, _accurateSeek, _timeoutMs);

#if AVPRO_FILESYSTEM_SUPPORT
			// Save frame to JPG
			if (_saveToJPG)
			{
				string filePath = _filenamePrefix + "-" + _frameIndex + ".jpg";
				System.IO.File.WriteAllBytes(filePath, _texture.EncodeToJPG());
			}
#endif

			// Draw frame to the thumbnail sheet texture
			GL.PushMatrix();
			RenderTexture.active = _displaySheet;
			GL.LoadPixelMatrix(0f, _displaySheet.width, _displaySheet.height, 0f);
			Rect sourceRect = new Rect(0f, 0f, 1f, 1f);

			float thumbSpace = 8f;
			float thumbWidth = ((float)_displaySheet.width / (float)NumFrames) - thumbSpace;
			float thumbHeight = thumbWidth / ((float)_texture.width / (float)_texture.height);
			float thumbPos = ((thumbWidth + thumbSpace) * (float)_frameIndex);

			Rect destRect = new Rect(thumbPos, (_displaySheet.height / 2f) - (thumbHeight / 2f), thumbWidth, thumbHeight);

			Graphics.DrawTexture(destRect, _texture, sourceRect, 0, 0, 0, 0);
			RenderTexture.active = null;
			GL.PopMatrix();
			GL.InvalidateState();
		}

		void OnGUI()
		{
			GUI.skin = _skin;

			if (_displaySheet != null)
			{
				GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), _displaySheet, ScaleMode.ScaleToFit, false);
			}

			float debugGuiScale = 4f * (Screen.height / 1080f);
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(debugGuiScale, debugGuiScale, 1.0f));

			GUILayout.Space(16f);
			GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true), GUILayout.Width(Screen.width / debugGuiScale));
			GUILayout.FlexibleSpace();
			if (GUILayout.Button("Start Extracting Frames"))
			{
				_frameIndex = 0;
				RenderTexture.active = _displaySheet;
				GL.Clear(false, true, Color.black, 0f);
				RenderTexture.active = null;
			}
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
		}
	}
}