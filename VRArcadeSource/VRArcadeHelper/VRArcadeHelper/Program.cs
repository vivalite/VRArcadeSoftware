using System.Reflection;
using System.ServiceProcess;

namespace VRArcadeHelper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            ServiceBase[] ServicesToRun;

            if (args.Length > 0)
            {
                if (args[0] == "/i")
                {
                    System.Configuration.Install.ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
                }
                else if (args[0] == "/u")
                {
                    System.Configuration.Install.ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
                }
            }
            else
            {
                ServicesToRun = new ServiceBase[]
                    {
                        new VRArcadeHelperService()
                    };
                ServiceBase.Run(ServicesToRun);

            }

        }
    }
}
