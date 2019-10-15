using ProtoBuf;

namespace VRGameSelectorDTO
{
    [ProtoContract]
    public class PlayLog
    {
        public PlayLog()
        {

        }

        public PlayLog(string tileID, Enums.PlayLogSignalType signalType)
        {
            TileID = tileID;
            SignalType = signalType;
        }

        [ProtoMember(1)]
        public string TileID { get; set; }
        [ProtoMember(2)]
        public Enums.PlayLogSignalType SignalType { get; set; }
    }
}
