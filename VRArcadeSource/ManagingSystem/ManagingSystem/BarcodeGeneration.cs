using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;
using VRGameSelectorServerDTO;

namespace ManagingSystem
{
    public partial class BarcodeGeneration : Telerik.WinControls.UI.RadForm
    {
        public BarcodeGeneration()
        {
            InitializeComponent();

            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void BarcodeGeneration_Load(object sender, EventArgs e)
        {
            NetworkFunction.OnIncommingSystemConfig += NetworkFunction_OnIncommingSystemConfig;
            NetworkFunction.GetSystemConfig(new List<SystemConfig>()
            {
                new SystemConfig(Enums.SysConfigType.DEFAULT_TIMED_SESSION_LENGTH)
            });
        }

        private void NetworkFunction_OnIncommingSystemConfig(object sender, EventArgs e)
        {
            List<SystemConfig> lsc = ((SystemConfigEvent)e).SystemConfig;

            foreach (SystemConfig sc in lsc)
            {
                switch (sc.Type)
                {
                    case Enums.SysConfigType.DEFAULT_TIMED_SESSION_LENGTH:

                        this.InvokeUI(() =>
                        {
                            int tmpMin = 50;

                            int.TryParse(sc.Value, out tmpMin);

                            radSpinEditorSessionTime.Value = tmpMin == 0 ? 50 : tmpMin;

                        });

                        break;
                }
            }
        }

        private void radSpinEditorNumPrint_MouseDown(object sender, MouseEventArgs e)
        {
            tsNumericKeypad keyboard = new tsNumericKeypad("Enter The Number Of Ticket To Print");

            DialogResult dr = keyboard.ShowDialog();

            if (dr == DialogResult.OK)
            {
                int tmpNum = 0;

                int.TryParse(keyboard.Data, out tmpNum);

                radSpinEditorNumPrint.Value = (decimal)((tmpNum == 0 || tmpNum > radSpinEditorNumPrint.Maximum || tmpNum < radSpinEditorNumPrint.Minimum) ? 0 : tmpNum);
            }
        }

        private void radTrackBarNumPrint_ValueChanged(object sender, EventArgs e)
        {
            radSpinEditorNumPrint.Value = (decimal)radTrackBarNumPrint.Value;
        }

        private void radSpinEditorNumPrint_ValueChanged(object sender, EventArgs e)
        {
            radTrackBarNumPrint.Value = (float)radSpinEditorNumPrint.Value;
        }

        private void radRadioButtonTimed_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            radSpinEditorSessionTime.Enabled = true;
            radLabelMin.Enabled = true;
        }

        private void radRadioButtonNonTimed_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            radSpinEditorSessionTime.Enabled = false;
            radLabelMin.Enabled = false;
        }

        private void radButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radButtonPrintNow_Click(object sender, EventArgs e)
        {
            string question = "Are you sure you want to print (" + radSpinEditorNumPrint.Value.ToString() + ") "
                + (radRadioButtonTimed.CheckState == CheckState.Checked ? "TIMED" : "NON-TIMED")
                + " session ticket?";

            if (radRadioButtonTimed.CheckState == radRadioButtonNonTimed.CheckState || radSpinEditorNumPrint.Value == 0)
            {
                this.ShowAlertBox("Barcode Generation", "Please make your choice!");
            }
            else
            {
                DialogResult dr = RadMessageBox.Show(this, string.Format(question), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    BarcodeInfo bInfo = new BarcodeInfo();

                    for (int i = 0; i < radSpinEditorNumPrint.Value; i++)
                    {
                        BarcodeItem bItem = new BarcodeItem()
                        {
                            IsPrintingTicket = true,
                            Minutes = (radRadioButtonTimed.CheckState == CheckState.Checked ? (int)radSpinEditorSessionTime.Value : 0),
                            CustomerName = ""
                        };

                        bInfo.BarcodeItems.Add(bItem);
                    }

                    NetworkFunction.GenerateBarcode(bInfo);

                    Close();
                }
            }
        }

        private void BarcodeGeneration_FormClosed(object sender, FormClosedEventArgs e)
        {
            NetworkFunction.OnIncommingSystemConfig -= NetworkFunction_OnIncommingSystemConfig;
        }
    }
}
