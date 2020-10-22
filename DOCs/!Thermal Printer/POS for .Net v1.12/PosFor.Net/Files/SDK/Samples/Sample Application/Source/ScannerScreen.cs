using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.PointOfService;

namespace TestApplication
{
    public partial class ScannerScreen : TestApplication.DeviceScreenBase
    {
        Scanner _Scanner;
        public ScannerScreen()
        {
            InitializeComponent();
        }

        public override void SetOpened(bool opened)
        {
            if (_Scanner == null)
            {
                _Scanner = (Scanner)PosCommon;
                _Scanner.DataEvent +=new DataEventHandler(_Scanner_DataEvent);
            }

            if (opened)
                UpdateUI();
        }

        private void UpdateUI()
        {
            if (_Scanner.State != ControlState.Closed)
            {
                DecodeData.Checked = _Scanner.DecodeData;
            }
            
        }


        void _Scanner_DataEvent(object sender, DataEventArgs e)
        {

            byte[] b = _Scanner.ScanData;


            string str = "Raw Data: ";
            for (int i = 0; i < b.Length; i++)
                str += (b[i].ToString() + " ");
            str += "\r\n";

            str += "Formatted Data: ";
            b = _Scanner.ScanDataLabel;
            for (int i = 0; i < b.Length; i++)
                str += (char)b[i];
            str += "\r\n";

            str += "Symbology: " + _Scanner.ScanDataType + "\r\n";
            str += "\r\n";

            DisplayMessage(str);
        }

        private void DecodeData_CheckedChanged(object sender, System.EventArgs e)
        {
            if (_Scanner.State != ControlState.Closed)
                _Scanner.DecodeData = DecodeData.Checked;
            
        }
    }
}

