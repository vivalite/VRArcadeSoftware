using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace VRGameSelectorDTO
{
    [ProtoContract]
    public class RunningGameInfo
    {
        public RunningGameInfo()
        {
            IsPostTerminationCheck = false;
        }

        public RunningGameInfo(List<AppInfo> runningGames)
        {
            RunningGames = runningGames;
        }

        public RunningGameInfo(bool isPostTerminationCheck)
        {
            IsPostTerminationCheck = isPostTerminationCheck;
        }

        [ProtoMember(1)]
        public List<AppInfo> RunningGames { get; set; }
        [ProtoMember(2)]
        public bool IsPostTerminationCheck { get; set; }
        
    }
}
