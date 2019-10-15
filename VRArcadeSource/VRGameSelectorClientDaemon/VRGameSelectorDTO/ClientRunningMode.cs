using ProtoBuf;
using System;

namespace VRGameSelectorDTO
{
    [ProtoContract]
    public class ClientRunningMode
    {
        public ClientRunningMode()
        {
            ClientID = 0;
            StartTime = DateTime.MinValue;
            CurrentRunningTileID = 0;
            RunningMode = Enums.ClientRunningMode.NONE;
            Duration = 0;
        }

        public ClientRunningMode(int clientID, string clientIP, DateTime startTime, int currentRunningTileID, int duration, Enums.ClientRunningMode runningMode, Tile tileConfig, int customerAge)
        {
            ClientID = clientID;
            ClientIP = clientIP;
            StartTime = startTime;
            CurrentRunningTileID = currentRunningTileID;
            Duration = duration;
            RunningMode = runningMode;
            TileConfig = tileConfig;
            CustomerAge = customerAge;
        }

        [ProtoMember(1)]
        public int ClientID { get; set; }
        [ProtoMember(2)]
        public string ClientIP { get; set; }
        [ProtoMember(3)]
        public DateTime StartTime { get; set; }
        [ProtoMember(4)]
        public int CurrentRunningTileID { get; set; }
        [ProtoMember(5)]
        public int Duration { get; set; }
        [ProtoMember(6)]
        public Enums.ClientRunningMode RunningMode { get; set; }
        [ProtoMember(7)]
        public Tile TileConfig { get; set; }
        [ProtoMember(8)]
        public bool IsRequiredAssistant { get; set; }
        [ProtoMember(9)]
        public int CustomerAge { get; set; }

    }
}
