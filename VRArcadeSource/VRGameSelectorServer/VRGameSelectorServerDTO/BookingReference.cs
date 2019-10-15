using ProtoBuf;
using System;


namespace VRGameSelectorServerDTO
{
    [Serializable]
    [ProtoContract]
    public class BookingReference
    {
        public BookingReference()
        {
            ID = 0;
            Reference = "";
            IsNonTimedTiming = false;
            IsTimedTiming = false;
            Duration = 0;
            NumberOfBookingTotal = 0;
            NumberOfBookingLeft = 0;
            TimeCreated = DateTime.MinValue;
            BookingStartTime = DateTime.MinValue;
            BookingEndTime = DateTime.MinValue;
        }


        [ProtoMember(1)]
        public int ID
        {
            get;
            set;
        }
        [ProtoMember(2)]
        public string Reference
        {
            get;
            set;
        }
        [ProtoMember(3)]
        public bool IsNonTimedTiming
        {
            get;
            set;
        }
        [ProtoMember(4)]
        public bool IsTimedTiming
        {
            get;
            set;
        }
        [ProtoMember(5)]
        public int Duration
        {
            get;
            set;
        }
        [ProtoMember(6)]
        public int NumberOfBookingTotal
        {
            get;
            set;
        }
        [ProtoMember(7)]
        public int NumberOfBookingLeft
        {
            get;
            set;
        }
        [ProtoMember(8)]
        public DateTime TimeCreated
        {
            get;
            set;
        }
        [ProtoMember(9)]
        public DateTime BookingStartTime
        {
            get;
            set;
        }
        [ProtoMember(10)]
        public DateTime BookingEndTime
        {
            get;
            set;
        }
    }
}
