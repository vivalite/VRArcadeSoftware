using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRGameSelectorServerDTO;

namespace VRGameSelectorServerDTO
{
    public class TileConfigEvent : EventArgs
    {
        public TileConfigEvent()
        {
            ListTileConfigs = new List<TileConfig>();
        }
        public List<TileConfig> ListTileConfigs { get; set; }
    }
}
