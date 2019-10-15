using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRGameSelectorServerDTO;

namespace VRGameSelectorServerDTO
{
    public class ConfigSetEvent : EventArgs
    {

        public ConfigSetEvent()
        {
            ListConfigSets = new List<ConfigSet>();
        }
        public List<ConfigSet> ListConfigSets { get; set; }
    }
}
