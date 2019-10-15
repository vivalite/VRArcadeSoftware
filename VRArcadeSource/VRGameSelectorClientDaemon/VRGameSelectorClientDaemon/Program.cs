using System;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace VRGameSelectorClientDaemon
{
    static class Program
    {

        static Mutex mutex = new Mutex(true, "{2AB5EE31-31ED-45DA-AF40-108A5CE99219}");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        //[PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        //[HostProtectionAttribute(SecurityAction.LinkDemand, SharedState = true, Synchronization = true, ExternalProcessMgmt = true, SelfAffectingProcessMgmt = true)]
        //[PermissionSetAttribute(SecurityAction.InheritanceDemand, Name = "FullTrust")]
        static void Main()
        {
            try
            {
                if (mutex.WaitOne(TimeSpan.Zero, true))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    if ((Control.ModifierKeys) == 0)
                    {
                        Application.Run(new ClientDaemonMain());
                    }
                    else
                    {
                        SystemSounds.Beep.Play();
                        Thread.Sleep(500);
                        SystemSounds.Beep.Play();
                        Thread.Sleep(500);
                        SystemSounds.Beep.Play();
                    }

                }
                else
                {
                    MessageBox.Show("Only one instance is allowed!");
                }
            }
            finally
            {

            }
        }
    }
}
