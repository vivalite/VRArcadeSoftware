using ProtoBuf;


namespace VRGameSelectorDTO
{
    [ProtoContract]
    public class SysConfig
    {
        public SysConfig()
        {
            Type = Enums.SysConfigType.NONE;
            Value = "";
        }

        public SysConfig(Enums.SysConfigType type)
        {
            Type = type;
            Value = "";
        }

        public SysConfig(Enums.SysConfigType type, string value)
        {
            Type = type;
            Value = value;
        }

        [ProtoMember(1)]
        public Enums.SysConfigType Type
        {
            get;
            set;
        }
        [ProtoMember(2)]
        public string Value
        {
            get;
            set;
        }

    }
}
