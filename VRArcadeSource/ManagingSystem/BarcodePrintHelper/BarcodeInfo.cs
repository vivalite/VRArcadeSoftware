using System;
using System.Collections.Generic;

namespace BarcodePrintHelper
{
    [Serializable()]
    public class BarcodeInfo
    {

        /*
         * 
         *     This file must be same as the one in VRGameSelectorServerDTO
         * 
         */

        public BarcodeInfo()
        {
            BarcodeItems = new List<BarcodeItem>();
        }

        public List<BarcodeItem> BarcodeItems;

    }

    [Serializable()]
    public class BarcodeItem
    {
        public BarcodeItem()
        {
            GUID = Guid.Empty;
            Minutes = 0;
            IsPrintingKey = false;
            IsPrintingTicket = false;
            KeyName = "";
            DateStampCreate = DateTime.MinValue;
            DateStampDelete = DateTime.MinValue;
            CustomerName = "";
            BookingReference = "";
            WaiverLogID = 0;
        }

        public Guid GUID { get; set; }
        public int Minutes { get; set; }
        public bool IsPrintingTicket { get; set; }
        public bool IsPrintingKey { get; set; }
        public string KeyName { get; set; }
        public DateTime DateStampCreate { get; set; }
        public DateTime DateStampDelete { get; set; }
        public string CustomerName { get; set; }
        public string BookingReference { get; set; }
        public int WaiverLogID { get; set; }
    }
}
