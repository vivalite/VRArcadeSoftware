using ProtoBuf;
using System;


namespace VRGameSelectorServerDTO
{
    [Serializable]
    [ProtoContract]
    public class WaiverInfo
    {
        public WaiverInfo()
        {
            ID = 0;
            FirstName = "";
            LastName = "";
            Address = "";
            City = "";
            Province = "";
            Postcode = "";
            Cell = "";
            DOB = DateTime.MinValue;
            Email = "";
            SignFileName = "";
            TimeCreated = DateTime.MinValue;
            BookingReference = null;
        }


        [ProtoMember(1)]
        public int ID
        {
            get;
            set;
        }
        [ProtoMember(2)]
        public string FirstName
        {
            get;
            set;
        }
        [ProtoMember(3)]
        public string LastName
        {
            get;
            set;
        }
        [ProtoMember(4)]
        public string Address
        {
            get;
            set;
        }
        [ProtoMember(5)]
        public string City
        {
            get;
            set;
        }
        [ProtoMember(6)]
        public string Province
        {
            get;
            set;
        }
        [ProtoMember(7)]
        public string Postcode
        {
            get;
            set;
        }
        [ProtoMember(8)]
        public string Cell
        {
            get;
            set;
        }
        [ProtoMember(9)]
        public DateTime DOB
        {
            get;
            set;
        }
        [ProtoMember(10)]
        public string Email
        {
            get;
            set;
        }
        [ProtoMember(11)]
        public string SignFileName
        {
            get;
            set;
        }
        [ProtoMember(12)]
        public DateTime TimeCreated
        {
            get;
            set;
        }
        [ProtoMember(13)]
        public BookingReference BookingReference
        {
            get;
            set;
        }

    }
}
