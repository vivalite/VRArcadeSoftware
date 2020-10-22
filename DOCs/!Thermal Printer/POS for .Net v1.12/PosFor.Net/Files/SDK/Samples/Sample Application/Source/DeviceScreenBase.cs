using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.PointOfService;

namespace TestApplication
{
    public partial class DeviceScreenBase : UserControl
    {
        PosCommon _posCommon;
        MainForm _mainForm;
        string _soName;

        public static DeviceScreenBase CreateDeviceScreen(PosCommon posCommon, string soName, MainForm mainForm)
        {
            DeviceScreenBase screen =null;
            if (posCommon is Msr)
                screen = new MsrScreen();
            else if (posCommon is Scanner)
                screen = new ScannerScreen();
            else if (posCommon is CheckScanner)
                screen = new CheckScannerScreen();
            else if (posCommon is PosPrinter)
                screen = new PosPrinterScreen();
            else if (posCommon is Scale)
                screen = new ScaleScreen();
            else if (posCommon is Micr)
                screen = new MicrScreen();
            else if (posCommon is LineDisplay)
                screen = new LineDisplayScreen();
            else if (posCommon is PinPad)
                screen = new PinPadScreen();
            else if (posCommon is CashDrawer)
                screen = new CashDrawerScreen();
            else if (posCommon is PosKeyboard)
                screen = new PosKeyboardScreen();
            else if (posCommon is CoinDispenser)
                screen = new CoinDispenserScreen();
            else if (posCommon is Keylock)
                screen = new KeylockScreen();
            else if (posCommon is SignatureCapture)
                screen = new SignatureCaptureScreen();
            else if (posCommon is SmartCardRW)
                screen = new SmartCardRWScreen();
            else if (posCommon is BumpBar)
                screen = new BumpBarScreen();
            else if (posCommon is Biometrics)
                screen = new BiometricsScreen();
            else if (posCommon is RFIDScanner)
                screen = new RFIDScannerScreen();


            if (screen != null)
            {
                screen._mainForm = mainForm;
                screen._posCommon = posCommon;
                screen._soName = soName;
            }

            return screen;
        }

        protected PosCommon PosCommon { get { return _posCommon; } }
        protected DeviceScreenBase()
        {
            InitializeComponent();
        }

        public virtual void SetOpened(bool opened) { throw new NotImplementedException(); }
        public virtual void SetDeviceClaimed(bool claimed) { }
        public virtual void SetDeviceEnabled(bool enabled) { }
        public virtual void ClearInputProperties() { }

        protected void DisplayMessage(string message)
        {
            _mainForm.SetOutputText("<" + _soName + ">\r\n" + message);
        }

        protected void ShowException(Exception e)
        {
            _mainForm.ShowException(e);
        }
        
    }
}
