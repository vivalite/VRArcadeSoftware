using System;
using System.Collections.Generic;

namespace VRGameSelectorServerDTO
{
    public class KeyInfoEvent : EventArgs
    {

        public KeyInfoEvent()
        {
            ListKeyInfo = new List<KeyInfo>();
        }
        public List<KeyInfo> ListKeyInfo { get; set; }
    }
}
