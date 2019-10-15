using ProtoBuf;
using System;


namespace VRGameSelectorServerDTO
{
    [Serializable]
    [ProtoContract]
    public class SystemConfig
    {
        public SystemConfig()
        {
            Type = Enums.SysConfigType.NONE;
            Value = "";
        }

        public SystemConfig(Enums.SysConfigType type)
        {
            Type = type;
            Value = "";
        }

        public SystemConfig(Enums.SysConfigType type, string value)
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
