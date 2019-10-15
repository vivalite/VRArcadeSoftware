using ProtoBuf;
using System;

namespace VRGameSelectorServerDTO
{
    [ProtoContract]
    public class KeyInfo
    {
        public KeyInfo()
        {
            Key = "";
            KeyTypeID = 0;
            KeyTypeName = "";
            Minutes = 0;
            CreateDate = DateTime.MinValue;
        }

        [ProtoMember(1)]
        public string Key;

        [ProtoMember(2)]
        public int KeyTypeID;

        [ProtoMember(3)]
        public string KeyTypeName;

        [ProtoMember(4)]
        public int Minutes;

        [ProtoMember(5)]
        public DateTime CreateDate;
    }
}
