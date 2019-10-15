using ProtoBuf;
using System;


namespace VRGameSelectorServerDTO
{
    [Serializable]
    [ProtoContract]
    public class Client
    {
        public Client()
        {
            ClientID = 0;
            MachineName = "";
            IPAddress = "0.0.0.0";
            DashboardModuleIP = "";
            TileConfigSetID = 0;
            TileConfigSetName = "";
        }

        public Client(int clientID, string ipAddress, string dashboardModuleIP, string machineName, int tileConfigSetID, string tileConfigSetName)
        {
            ClientID = clientID;
            MachineName = machineName;
            IPAddress = ipAddress;
            DashboardModuleIP = dashboardModuleIP ?? "";
            TileConfigSetID = tileConfigSetID;
            TileConfigSetName = tileConfigSetName;
        }

        [ProtoMember(1)]
        public string MachineName
        {
            get;
            set;
        }
        [ProtoMember(2)]
        public string IPAddress
        {
            get;
            set;
        }
        [ProtoMember(3)]
        public int TileConfigSetID
        {
            get;
            set;
        }
        [ProtoMember(4)]
        public string TileConfigSetName
        {
            get;
            set;
        }
        [ProtoMember(5)]
        public int ClientID
        {
            get;
            set;
        }
        [ProtoMember(6)]
        public string DashboardModuleIP
        {
            get;
            set;
        }
    }
}
