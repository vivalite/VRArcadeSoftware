using ProtoBuf;

namespace VRGameSelectorServerDTO
{
    [ProtoContract]
    public class KeyTypeInfo
    {
        public KeyTypeInfo()
        {
            KeyTypeID = 0;
            KeyTypeName = "";
        }


        [ProtoMember(1)]
        public int KeyTypeID;
        [ProtoMember(2)]
        public string KeyTypeName;

    }
}
