using System;
using System.Collections.Generic;

namespace VRGameSelectorServerDTO
{
    public class KeyTypeInfoEvent : EventArgs
    {

        public KeyTypeInfoEvent()
        {
            ListKeyTypeInfo = new List<KeyTypeInfo>();
        }
        public List<KeyTypeInfo> ListKeyTypeInfo { get; set; }
    }
}
