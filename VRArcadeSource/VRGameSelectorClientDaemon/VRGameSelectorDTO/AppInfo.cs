using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace VRGameSelectorDTO
{
    [ProtoContract]
    public class AppInfo
    {
        public AppInfo()
        {
            ProcessID = 0;
            Path = "";
        }

        public AppInfo(int processID, string path)
        {
            ProcessID = processID;
            Path = path;
        }

        [ProtoMember(1)]
        public int ProcessID { get; set; }
        [ProtoMember(2)]
        public string Path { get; set; }

    }
}
