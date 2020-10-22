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
    public partial class SignatureCaptureScreen : TestApplication.DeviceScreenBase
    {
        SignatureCapture _signaturecapture;
        public SignatureCaptureScreen()
        {
            InitializeComponent();
        }

        public override void SetOpened(bool opened)
        {
            if (_signaturecapture == null)
            {
                _signaturecapture = (SignatureCapture)PosCommon;
            }

        }

        private void btnBeginCapture_Click(object sender, System.EventArgs e)
        {
            try
            {
                _signaturecapture.BeginCapture(tbFormName.Text);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnEndCapture_Click(object sender, System.EventArgs e)
        {
            try
            {
                _signaturecapture.EndCapture();
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }


    }
}

