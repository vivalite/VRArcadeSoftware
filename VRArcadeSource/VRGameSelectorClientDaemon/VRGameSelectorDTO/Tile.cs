using ProtoBuf;
using System.Collections.Generic;

namespace VRGameSelectorDTO
{
    [ProtoContract]
    public class Tile
    {
        public Tile()
        {
            Height = 100;
            Width = 100;
            TileRowNumber = 1;
            TileID = "";
            TileTitle = "";
            ImagePath = "";
            ImageDesc = "";
            Command = "";
            Arguments = "";
            WorkingPath = "";
            ChildTiles = new List<Tile>();
            TileImage = new ImageInfo();
            AgeRequire = 0;
            VideoURL = "";
        }

        public Tile(int height, int width, int tileRowNumber, string tileID, string tileTitle, string imagePath, string imageDesc, string command, string arguments, string workingPath, ImageInfo imageInfo, int ageRequire, string videoURL)
        {
            Height = height;
            Width = width;
            TileRowNumber = tileRowNumber;
            TileID = tileID;
            TileTitle = tileTitle;
            ImagePath = imagePath;
            ImageDesc = imageDesc;
            Command = command;
            Arguments = arguments;
            WorkingPath = workingPath;
            TileImage = imageInfo;
            ChildTiles = new List<Tile>();
            VideoURL = videoURL;
            AgeRequire = ageRequire;
        }

        [ProtoMember(1)]
        public int Height { get; set; }
        [ProtoMember(2)]
        public int Width { get; set; }
        [ProtoMember(3)]
        public int TileRowNumber { get; set; }
        [ProtoMember(4)]
        public string TileID { get; set; }
        [ProtoMember(5)]
        public string TileTitle { get; set; }
        [ProtoMember(6)]
        public string ImagePath { get; set; }
        [ProtoMember(7)]
        public string ImageDesc { get; set; }
        [ProtoMember(8)]
        public string Command { get; set; }
        [ProtoMember(9)]
        public string Arguments { get; set; }
        [ProtoMember(10)]
        public string WorkingPath { get; set; }
        [ProtoMember(11)]
        public List<Tile> ChildTiles { get; set; }
        [ProtoMember(15)]
        public ImageInfo TileImage { get; set; }
        [ProtoMember(16)]
        public int AgeRequire { get; set; }
        [ProtoMember(17)]
        public string VideoURL { get; set; }



    }
}
