using UnityEngine;
using System.Collections;

namespace util.constants
{
    public static class Constants
    {
        #region Help_Tile
        public static string CONSTANTS_HELPBUTTON_PREFAB_PATH = "Prefabs/Help";
        public static string CONSTANTS_HELPBUTTON_IMAGE_PATH = "/Images/HelpButton.png";
        public static Vector3 CONSTANTS_HELPBUTTON_LOCALPOSITION = new Vector3(-1.8f, -0.4f, 0.5f);
        public static Vector3 CONSTANTS_HELPBUTTON_LOCALROTATION = new Vector3(90f, 134f, 0);
        #endregion

        #region Introduction_Image
        public static string CONSTANTS_INTROHELP_PREFAB_PATH = "Prefabs/IntroHelp";
        public static string CONSTANTS_INTROHELP_IMAGE_PATH = "/Images/Instructions.png";
        public static Vector3 CONSTANTS_INTROHELP_LOCALPOSITION = new Vector3(0f, 1.5f, 1.5f);
        public static Vector3 CONSTANTS_INTROHELP_LOCALROTATION = new Vector3(90f, 180f, 0f);
        #endregion

        #region PLAY_GAME_PANE
        public static string CONSTANTS_PLAYGAME_PREFAB_PATH = "Prefabs/PlayGamePane";
        public static string CONSTANTS_PLAYGAME_IMAGE_PATH = "/Images/PlayGamePane.png";
        public static Vector3 CONSTANTS_PLAYGAME_LOCALPOSITION = new Vector3(0f, 2f, 1.5f);
        public static Vector3 CONSTANTS_PLAYGAME_LOCALROTATION = new Vector3(0f, 0f, 0f);
        #endregion

        #region TRAILER_PLAYGAME
        public static string CONSTANTS_PLAYGAMEPANE_NAME = "PlayGamePane";
        public static string CONSTANTS_TRAILER_NAME = "trailer";
        public static string CONSTANTS_PLAYGAME_NAME = "playgame";
        #endregion

        #region PLAY_VIDEO_PANE
        public static string CONSTANTS_PLAY_VIDEO_PANE_PATH = "Prefabs/PlayVideoPane";
        public static Vector3 CONSTANTS_PlAY_VIDEO_LOCALPOSITION = new Vector3(0, 1.5f, 1.5f);
        public static Vector3 CONSTANTS_PlAY_VIDEO_LOACLROTATION = new Vector3(0, 180f, 0f);
        #endregion

        #region PLAY_GAME_LOADING
        public static string CONSTANTS_LOADING_GAME_PANE_PATH = "Prefabs/LoadingGameText";
        public static Vector3 CONSTANTS_LOADING_GAME_PANE_LOCALPOSITION = new Vector3(0f, 0f, 1.2f);
        public static Vector3 CONSTANTS_LOADING_GAME_PANE_LOCALROTATION = Vector3.zero;
        #endregion
    }
}