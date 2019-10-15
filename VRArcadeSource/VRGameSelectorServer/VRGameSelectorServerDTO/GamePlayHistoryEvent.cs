using System;
using System.Collections.Generic;

namespace VRGameSelectorServerDTO
{
    public class GamePlayHistoryEvent : EventArgs
    {

        public GamePlayHistoryEvent()
        {
            ListGamePlayHistory = new List<GamePlayHistory>();
        }
        public List<GamePlayHistory> ListGamePlayHistory { get; set; }
    }
}
