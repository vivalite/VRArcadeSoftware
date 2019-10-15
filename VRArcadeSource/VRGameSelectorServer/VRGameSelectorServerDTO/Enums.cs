namespace VRGameSelectorServerDTO
{
    public static class Enums
    {
        public enum ControlMessage
        {
            NONE,
            GET_SYSCONFIG,
            SET_SYSCONFIG,
            GET_CONFIGED_CLIENT_LIST,
            MODIFY_CLIENT_CONFIG,
            ADD_CLIENT_CONFIG,
            DELETE_CLIENT_CONFIG,
            GET_CONFIG_SET_LIST,
            MODIFY_CONFIG_SET,
            ADD_CONFIG_SET,
            DELETE_CONFIG_SET,
            GET_TILE_CONFIG,
            MODIFY_TILE_CONFIG,
            ADD_TILE_CONFIG,
            DELETE_TILE_CONFIG,
            REORDER_UP_TILE_CONFIG,
            REORDER_DOWN_TILE_CONFIG,
            GET_LIVE_SYSTEM_INFO,
            GET_GAME_PLAY_HISTORY,
            START_TIMING,
            START_NOW,
            END_NOW,
            TURN_OFF,
            REBOOT,
            TURN_OFF_KMU,
            TURN_ON_KMU,
            HELP_PROVIDED,
            CLEANING_PROVIDED,
            GENERATE_BARCODE,
            GET_KEY,
            GET_KEY_TYPE,
            ADD_KEY,
            DELETE_KEY,
            GET_PENDING_WAIVER,
            GET_BOOKING_REF_SETTING,
            DELETE_PENDING_WAIVER,
            MARK_WAIVER_RECEIVED,
            SYNC_TILE_CONFIG,
            REINIT_CLIENT_SETTING
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

        public enum OperationType
        {
            NONE,
            START_TIMING,
            START_NON_TIMING,
            MANUAL_END,
            TURN_OFF,
            REBOOT,
            TURN_OFF_KMU,
            TURN_ON_KMU,
            HELP_REQUESTED,
            HELP_REQUEST_CLEARED,
            CLEAN_REQUESTED,
            CLEAN_REQUEST_CLEARED
        }

        public enum SourceType
        {
            NONE,
            MANAGEMENT_SYSTEM,
            LCD_BARCODE_MODULE,
            CLIENT
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
    }
}
