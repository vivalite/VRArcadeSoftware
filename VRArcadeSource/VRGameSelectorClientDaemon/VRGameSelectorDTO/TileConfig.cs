using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace VRGameSelectorDTO
{
    [ProtoContract]
    public class TileConfig
    {
        public TileConfig()
        {
            MainScreenTiles = new List<Tile>();
        }

        [ProtoMember(1)]
        public List<Tile> MainScreenTiles { get; set; }

    }
}
