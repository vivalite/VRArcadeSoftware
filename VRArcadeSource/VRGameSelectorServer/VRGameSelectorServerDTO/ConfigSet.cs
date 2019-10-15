using ProtoBuf;
using System;


namespace VRGameSelectorServerDTO
{
    [Serializable]
    [ProtoContract]
    public class ConfigSet
    {
        public ConfigSet()
        {
            ID = 0;
            Name = "";
        }

        public ConfigSet(int id, string name)
        {
            ID = id;
            Name = name;
        }

        [ProtoMember(1)]
        public int ID
        {
            get;
            set;
        }
        [ProtoMember(2)]
        public string Name
        {
            get;
            set;
        }

    }
}
