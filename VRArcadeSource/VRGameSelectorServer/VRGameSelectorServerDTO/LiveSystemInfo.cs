using ProtoBuf;
using System;
using System.Collections.Generic;

namespace VRGameSelectorServerDTO
{
    [Serializable]
    [ProtoContract]
    public class LiveSystemInfo
    {
        public LiveSystemInfo()
        {
            LiveClientStatus = new List<LiveClientStatus>();
        }

        [ProtoMember(1)]
        public List<LiveClientStatus> LiveClientStatus { get; set; }

    }
}
