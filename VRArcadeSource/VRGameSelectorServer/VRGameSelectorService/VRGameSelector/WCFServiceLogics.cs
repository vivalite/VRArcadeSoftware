using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace VRArcadeServer
{
    public partial class VRGameSelectorServer
    {
        private void InitWCFService()
        {
            _webServiceHostDashboardModule = new ServiceHost(typeof(VRArcadeServer.DashboardService));
            _webServiceHostDashboardModule.Open();

            foreach (var ea in _webServiceHostDashboardModule.Description.Endpoints)
            {
                logger.Debug("Logger is running at {0}", ea.Address);
            }

        }

    }
}
