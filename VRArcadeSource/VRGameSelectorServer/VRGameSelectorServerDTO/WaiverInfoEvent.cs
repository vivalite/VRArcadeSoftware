using System;
using System.Collections.Generic;

namespace VRGameSelectorServerDTO
{
    public class WaiverInfoEvent : EventArgs
    {

        public WaiverInfoEvent()
        {
            ListWaiverInfo = new List<WaiverInfo>();
        }

        public List<WaiverInfo> ListWaiverInfo { get; set; }
    }
}
