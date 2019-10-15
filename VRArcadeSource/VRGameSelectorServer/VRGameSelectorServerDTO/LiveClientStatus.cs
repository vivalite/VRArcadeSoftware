using ProtoBuf;
using System;

namespace VRGameSelectorServerDTO
{
    [Serializable]
    [ProtoContract]
    public class LiveClientStatus
    {
        public LiveClientStatus()
        {

        }

        [ProtoMember(1)]
        public int ClientID { get; set; }
        [ProtoMember(2)]
        public string ClientName { get; set; }
        [ProtoMember(3)]
        public Enums.LiveClientStatus ClientStatus { get; set; }
        [ProtoMember(4)]
        public string AdditionalInfo { get; set; }
        [ProtoMember(5)]
        public TimeSpan TimeLeft { get; set; }
        [ProtoMember(6)]
        public bool IsAssistanceRequested { get; set; }
        [ProtoMember(7)]
        public string ClientIP { get; set; }
        [ProtoMember(8)]
        public string Mode { get; set; }

    }
}
