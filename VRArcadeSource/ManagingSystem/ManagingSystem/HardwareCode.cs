using IntelliLock.Licensing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ManagingSystem
{
    [IntelliLock.DialogBoxAttribute]
    public partial class HardwareCode : Telerik.WinControls.UI.RadForm
    {
        public HardwareCode()
        {
            InitializeComponent();

            radTextBoxMachineID.Text = Utility.GetHardwareID();

            radLabelCurrent.Text += Utility.GetLicenseExpirationDate();

            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void radButtonOpenAppFolder_Click(object sender, EventArgs e)
        {
            string cb = Assembly.GetExecutingAssembly().CodeBase.Substring(8);
            string path = Path.GetDirectoryName(cb);

            Process.Start(path);

            this.Close();
        }
    }
}
