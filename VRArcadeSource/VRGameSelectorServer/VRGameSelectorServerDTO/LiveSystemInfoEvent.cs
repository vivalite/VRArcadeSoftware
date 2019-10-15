using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRGameSelectorServerDTO;

namespace VRGameSelectorServerDTO
{
    public class LiveSystemInfoEvent : EventArgs
    {

        public LiveSystemInfoEvent()
        {
            LiveSystemInfo = new LiveSystemInfo();
        }
        public LiveSystemInfo LiveSystemInfo { get; set; }
    }
}
