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
    public partial class CashDrawerScreen : TestApplication.DeviceScreenBase
    {
        CashDrawer drawer;
        public CashDrawerScreen()
        {
            InitializeComponent();
        }

        public override void SetOpened(bool opened)
        {
            if (drawer == null)
            {
                drawer = (CashDrawer)PosCommon;
            }
        }


        private void OpenDrawerButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                drawer.OpenDrawer();
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void WaitForDrawerCloseButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                Cursor old = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    drawer.WaitForDrawerClose(Int32.Parse(BeepTimeouttextBox.Text),
                        Int32.Parse(BeepFrequencytextBox.Text),
                        Int32.Parse(BeepDurationtextBox.Text),
                        Int32.Parse(BeepDelaytextBox.Text));
                }
                finally
                {
                    Cursor.Current = old;
                }

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

    }
}

