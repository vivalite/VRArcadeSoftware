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
    public partial class CoinDispenserScreen : TestApplication.DeviceScreenBase
    {
        CoinDispenser _dispenser;
        public CoinDispenserScreen()
        {
            InitializeComponent();
        }

        public override void SetOpened(bool opened)
        {
            if (_dispenser == null)
            {
                _dispenser = (CoinDispenser)PosCommon;
            }

        }


        private void btnDispenseChange_Click(object sender, System.EventArgs e)
        {
            try
            {
                _dispenser.DispenseChange(Int32.Parse(tbDispenseChange.Text));
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }
    }
}

