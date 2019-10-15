using ProtoBuf;
using System;
using System.Collections.Generic;

namespace VRGameSelectorServerDTO
{
    [ProtoContract]
    public class BarcodeInfo
    {
        /*
         * 
         *     This file must be same as the one in BarcodePrintHelper
         * 
         */

        public BarcodeInfo()
        {
            BarcodeItems = new List<BarcodeItem>();
        }

        [ProtoMember(1)]
        public List<BarcodeItem> BarcodeItems;

    }

    [ProtoContract]
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

        [ProtoMember(1)]
        public Guid GUID { get; set; }
        [ProtoMember(2)]
        public int Minutes { get; set; }
        [ProtoMember(3)]
        public bool IsPrintingTicket { get; set; }
        [ProtoMember(4)]
        public bool IsPrintingKey { get; set; }
        [ProtoMember(5)]
        public string KeyName { get; set; }
        [ProtoMember(6)]
        public DateTime DateStampCreate { get; set; }
        [ProtoMember(7)]
        public DateTime DateStampDelete { get; set; }
        [ProtoMember(8)]
        public string CustomerName { get; set; }
        [ProtoMember(9)]
        public string BookingReference { get; set; }
        [ProtoMember(10)]
        public int WaiverLogID { get; set; }

    }
}
