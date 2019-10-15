using ProtoBuf;
using System;
using System.Collections.Generic;


namespace VRGameSelectorServerDTO
{
    [Serializable]
    [ProtoContract]
    public class TileConfig
    {
        public TileConfig()
        {
            ID = 0;
            TileGUID = Guid.NewGuid().ToString();
            TileTitle = "";
            TileHeight = 100;
            TileWidth = 100;
            TileDesc = "";
            Command = "";
            Arguments = "";
            WorkingPath = "";
            Order = 0;
            TileRowNumber = 1;
            TileConfigSetID = 0;
            TileconfigID = 0;
            ChildTiles = new List<TileConfig>();
            TileImage = new ImageInfo();
            AgeRequire = 0;
            VideoURL = "";
        }

        public TileConfig(int id, string tileGUID, string tileTitle, int tileHeight, int tileWidth, string tileDesc, string command, string arguments, string workingPath, int order, int tileRowNumber, int tileConfigSetID, int tileConfigID, ImageInfo imageInfo, int ageRequire, string videoURL)
        {
            ID = id;
            TileGUID = tileGUID;
            TileTitle = tileTitle;
            TileHeight = tileHeight;
            TileWidth = tileWidth;
            TileDesc = tileDesc;
            Command = command;
            Arguments = arguments;
            WorkingPath = workingPath;
            Order = order;
            TileRowNumber = tileRowNumber;
            TileConfigSetID = tileConfigSetID;
            TileconfigID = tileConfigID;
            ChildTiles = new List<TileConfig>();
            TileImage = imageInfo;
            AgeRequire = ageRequire;
            VideoURL = videoURL;
        }

        [ProtoMember(1)]
        public int ID
        {
            get;
            set;
        }
        [ProtoMember(2)]
        public string TileGUID
        {
            get;
            set;
        }
        [ProtoMember(3)]
        public string TileTitle
        {
            get;
            set;
        }
        [ProtoMember(4)]
        public int TileHeight
        {
            get;
            set;
        }
        [ProtoMember(5)]
        public int TileWidth
        {
            get;
            set;
        }
        [ProtoMember(6)]
        public string TileDesc
        {
            get;
            set;
        }
        [ProtoMember(7)]
        public string Command
        {
            get;
            set;
        }
        [ProtoMember(8)]
        public string Arguments
        {
            get;
            set;
        }
        [ProtoMember(9)]
        public string WorkingPath
        {
            get;
            set;
        }
        [ProtoMember(10)]
        public int Order
        {
            get;
            set;
        }
        [ProtoMember(11)]
        public int TileRowNumber
        {
            get;
            set;
        }
        [ProtoMember(12)]
        public int TileConfigSetID
        {
            get;
            set;
        }
        [ProtoMember(13)]
        public int TileconfigID
        {
            get;
            set;
        }
        [ProtoMember(14)]
        public List<TileConfig> ChildTiles
        {
            get;
            set;
        }
        [ProtoMember(15)]
        public ImageInfo TileImage { get; set; }

        [ProtoMember(16)]
        public int AgeRequire { get; set; }

        [ProtoMember(17)]
        public string VideoURL { get; set; }

    }
}
