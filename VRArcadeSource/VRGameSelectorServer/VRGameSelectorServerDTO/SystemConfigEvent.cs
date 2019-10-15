using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRGameSelectorServerDTO;

namespace VRGameSelectorServerDTO
{
    public class SystemConfigEvent : EventArgs
    {

        public SystemConfigEvent()
        {
            SystemConfig = new List<SystemConfig>();
        }
        public List<SystemConfig> SystemConfig { get; set; }
    }
}
