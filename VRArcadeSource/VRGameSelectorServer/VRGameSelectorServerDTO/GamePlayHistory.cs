using ProtoBuf;
using System;


namespace VRGameSelectorServerDTO
{
    [Serializable]
    [ProtoContract]
    public class GamePlayHistory
    {
        private int tileID;
        private string tileName;

        public GamePlayHistory()
        {
            TileID = 0;
            TileName = "";
            StartTime = DateTime.MinValue;
            EndTime = DateTime.MinValue;
        }


        [ProtoMember(1)]
        public int TileID
        {
            get { return tileID; }
            set { tileID = value; }
        }

        [ProtoMember(2)]
        public string TileName
        {
            get { return (tileID == -1) ? "Game Selector Interface" : tileName; ; }
            set { tileName = value; }
        }

        [ProtoMember(3)]
        public DateTime StartTime
        {
            get;
            set;
        }
        [ProtoMember(4)]
        public DateTime EndTime
        {
            get;
            set;
        }


    }
}
