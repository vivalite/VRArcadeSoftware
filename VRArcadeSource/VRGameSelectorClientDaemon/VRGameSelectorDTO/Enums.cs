namespace VRGameSelectorDTO
{
    public static class Enums
    {
        public enum PlayLogSignalType
        {
            Start,
            End
        }

        public enum LiveClientStatus
        {
            NONE,
            OFFLINE,
            ONLINE,
            GAMEOVER_FOR_CLEANING,
            CLEANING_DONE,
            IN_GAME_SELECTOR,
            IN_GAME_STARTING,
            IN_GAME,
            GAME_EXITING,
            ERROR
        }

        public enum ControlMessage
        {
            NONE,
            GET_ALL_SYSCONFIG,
            GET_ALL_TILE_CONFIG,
            GET_ALL_TILE_CONFIG_WITH_IMAGE,
            START_TIMING,
            START_NOW,
            END_NOW,
            TURN_OFF,
            REBOOT,
            STATUS,
            LOAD_CONFIG,
            PLAY_LOG,
            CLIENT_UI_READY,
            REQUEST_HELP,
            SHOW_QUICK_HELP,
            CLEANING_PROVIDED,
            TURN_OFF_KMU,
            TURN_ON_KMU,
            UNITY_DASHBOARD_SETDASHINFO,
            UNITY_DASHBOARD_GETRUNNINGGAMES,
            UNITY_DASHBOARD_EXITGAME,
            UNITY_DASHBOARD_GETTIMELEFT,
            UNITY_DASHBOARD_VOLUMEUP,
            UNITY_DASHBOARD_VOLUMEDOWN,
            LCD_DASHBOARD_HELP_PROVIDED,
            LCD_DASHBOARD_CLEANING_PROVIDED,
            LCD_DASHBOARD_BARCODE_IN

        }

        public enum ClientRunningMode
        {
            NONE,
            TIMING_ON,
            NO_TIMING_ON,
            ENDED_MANUAL,
            ENDED_TIMING,
            ENDED_EMERGENCY
        }

        public enum SysConfigType
        {
            NONE,
            ADMIN_PASSWORD,
            MANAGER_PASSWORD,
            TIMES_UP_MESSAGE,
            MANUAL_END_MESSAGE,
            EMERGENCY_MESSAGE,
            DEFAULT_TIMED_SESSION_LENGTH,
            DISABLE_KMU_BY_DEFAULT,
            RE_DISABLE_KMU_AFTER_20_MIN,
            LCD_BARCODE_MODULE
        }

        public enum KUMMessageType
        {
            DISABLE = 150,
            ENABLE = 151,
            ENABLE_ONLY_20_MIN = 152
        }
    }
}
