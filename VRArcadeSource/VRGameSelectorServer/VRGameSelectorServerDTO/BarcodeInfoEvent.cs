using System;

namespace VRGameSelectorServerDTO
{
    public class BarcodeInfoEvent : EventArgs
    {

        public BarcodeInfoEvent()
        {
            BarcodeInfo = new BarcodeInfo();
        }
        public BarcodeInfo BarcodeInfo { get; set; }
    }
}
