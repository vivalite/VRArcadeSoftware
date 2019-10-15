using ProtoBuf;
using System.Collections.Generic;

namespace VRGameSelectorServerDTO
{
    [ProtoContract]
    public class ClientParm
    {
        public ClientParm()
        {
            ClientID = 0;
            Parameters = new Dictionary<string, string>();
        }

        public ClientParm(int clientID, Dictionary<string, string> parm)
        {
            ClientID = clientID;
            Parameters = parm;
        }

        public ClientParm(int clientID) : this()
        {
            ClientID = clientID;
        }

        [ProtoMember(1)]
        public int ClientID { get; set; }
        [ProtoMember(2)]
        public Dictionary<string, string> Parameters { get; set; }
    }
}
