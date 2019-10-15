using NLog;
using System;
using System.ServiceProcess;
using System.Threading;
using VRArcadeServer;

namespace VRArcadeServerService
{
    public partial class VRArcadeServerService : ServiceBase
    {
        VRGameSelectorServer server;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public VRArcadeServerService()
        {
            InitializeComponent();
        }

#if DEBUG
        public void VROnStart(string[] args)
        {
            OnStart(args);
        }

        public void VROnStop()
        {
            OnStop();
        }
#endif

        protected override void OnStart(string[] args)
        {
            try
            {
#if !DEBUG
                Thread.Sleep(10000);
#endif
                server = VRGameSelectorServer.Instance;
            }
            catch (Exception ex)
            {
                logger.Fatal("Fatal Error! " + ex.ToString());
                throw;
            }

        }

        protected override void OnStop()
        {
        }

    }
}
