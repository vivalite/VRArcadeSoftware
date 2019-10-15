using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;
using VRGameSelectorDTO;

namespace VRArcadeHelper
{
    public partial class VRArcadeHelperService : ServiceBase
    {

        System.Timers.Timer _timer5s;
        System.Timers.Timer _timer20min;

        System.Timers.Timer _timerRandomStartDelay;
        System.Timers.Timer _timer24h;

        public VRArcadeHelperService()
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
            Random rnd = new Random();

            EnableKUM();

            _timer5s = new System.Timers.Timer();
            _timer5s.Elapsed += new ElapsedEventHandler(OnTimer5sEvent);
            _timer5s.Interval = 5000;
            _timer5s.Enabled = false;

            _timer20min = new System.Timers.Timer();
            _timer20min.Elapsed += new ElapsedEventHandler(OnTimer20minEvent);
            _timer20min.Interval = 1200000;
            _timer20min.Enabled = false;


            _timerRandomStartDelay = new System.Timers.Timer();
            _timerRandomStartDelay.Elapsed += _timerRandomStartDelay_Elapsed;
            _timerRandomStartDelay.Interval = rnd.Next(10000, 60000);
            _timerRandomStartDelay.Enabled = true;
            _timerRandomStartDelay.AutoReset = false;

            _timer24h = new System.Timers.Timer();
            _timer24h.Elapsed += _timer24h_Elapsed;
            _timer24h.Interval = 86400000;
            _timer24h.Enabled = false;

        }

        private void _timer24h_Elapsed(object sender, ElapsedEventArgs e)
        {
            SyncClock();
        }

        private void _timerRandomStartDelay_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timerRandomStartDelay.Enabled = false;
            _timer24h.Enabled = true;

            SyncClock();
        }

        protected override void OnStop()
        {

        }


        protected override void OnCustomCommand(int command)
        {
            base.OnCustomCommand(command);

            Enums.KUMMessageType mType = (Enums.KUMMessageType)command;

            switch (mType)
            {
                case Enums.KUMMessageType.DISABLE:

                    OnTimer5sEvent(null, null);
                    _timer5s.Enabled = true;

                    break;
                case Enums.KUMMessageType.ENABLE:

                    _timer5s.Enabled = false;
                    EnableKUM();

                    break;
                case Enums.KUMMessageType.ENABLE_ONLY_20_MIN:

                    _timer5s.Enabled = false;
                    _timer20min.Enabled = true;
                    EnableKUM();

                    break;
                default:
                    break;
            }



        }


        private void OnTimer5sEvent(object sender, ElapsedEventArgs e)
        {
            DisableKUM();
        }

        private void OnTimer20minEvent(object sender, ElapsedEventArgs e)
        {
            _timer20min.Enabled = false;
            DisableKUM();
        }

        private void DisableKUM()
        {
            DisableMouse();
            DisableKeyboard();
            DisableUSBStorage();
        }

        private void EnableKUM()
        {
            EnableKeyboard();
            EnableMouse();
            EnableUSBStorage();
        }


        private void EnableMouse()
        {
            RunCommand("VRArcadeHelperEx.exe", "enable =Mouse");
        }

        private void DisableMouse()
        {
            RunCommand("VRArcadeHelperEx.exe", "disable =Mouse");
        }

        private void EnableKeyboard()
        {
            RunCommand("VRArcadeHelperEx.exe", "enable =Keyboard");
        }

        private void DisableKeyboard()
        {
            RunCommand("VRArcadeHelperEx.exe", "disable =Keyboard");
        }

        private void EnableUSBStorage()
        {
            RunCommand("VRArcadeHelperEx.exe", @"enable USBSTOR\*");
        }

        private void DisableUSBStorage()
        {
            RunCommand("VRArcadeHelperEx.exe", @"disable USBSTOR\*");
        }

        private void SyncClock()
        {
            RestartWindowsService("W32Time");
            RunCommand("w32tm", @"/resync");
        }

        private string RunCommand(string commandLine, string args)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            //basePath = "";

            Process proc = new Process();

            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.FileName = basePath + commandLine;
            proc.StartInfo.Arguments = args;
            proc.StartInfo.CreateNoWindow = true;

            proc.Start();
            string output = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();

            proc.Close();

            return output;
        }


        private void RestartWindowsService(string serviceName)
        {
            ServiceController serviceController = new ServiceController(serviceName);
            try
            {
                if ((serviceController.Status.Equals(ServiceControllerStatus.Running)) || (serviceController.Status.Equals(ServiceControllerStatus.StartPending)))
                {
                    serviceController.Stop();
                }
                serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                serviceController.Start();
                serviceController.WaitForStatus(ServiceControllerStatus.Running);
            }
            catch
            {

            }
        }

    }
}
