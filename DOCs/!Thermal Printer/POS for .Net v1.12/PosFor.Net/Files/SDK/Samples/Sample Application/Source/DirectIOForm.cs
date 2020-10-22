// This is a part of the Microsoft POS for .NET SDK
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This sample source code is only intended as a 
// supplement to the POS for .NET SDK and related 
// electronic documentation provided with the library.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.PointOfService;
using System.Globalization;

namespace TestApplication
{
    public partial class DirectIOForm : Form
    {
        PosCommon poscommon;
        public DirectIOForm(PosCommon posCommon)
        {
            poscommon = posCommon;
            InitializeComponent();
        }

        byte[] LastResult = null;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int command = 0, data = 0;
                try
                {
                    command = int.Parse(tbCommand.Text);
                }
                catch (Exception)
                {
                }
                try
                {
                    data = int.Parse(tbData.Text);
                }
                catch (Exception)
                {
                }

                LastResult = null;
                rbBytes.Enabled = rbHex.Enabled = rbString.Enabled = rbBits.Enabled = false;
                DirectIOData ret = poscommon.DirectIO(command, data, tbObject.Text);
                //MessageBox.Show(ret.ToString());
                //tbResult.Text = ret.ToString();

                if (ret == null)
                {
                    tbResultData.Text = "<null>";
                    tbResultObject.Text = "<null>";
                }
                else
                {
                    tbResultData.Text = ret.Data.ToString(CultureInfo.InvariantCulture);
                    
                    if (ret.Object == null)
                    {
                        tbResultObject.Text = "<null>";
                    }
                    else if (ret.Object is byte[])
                    {
                        rbBytes.Enabled = rbHex.Enabled = rbString.Enabled= rbBits.Enabled = true;
                        LastResult = ret.Object as byte[];
                        UpdateLastResult();
                    }
                    else
                    {
                        tbResultObject.Text = ret.Object.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void UpdateLastResult()
        {
            if (LastResult == null)
                return;

            if (rbString.Checked)
            {
                tbResultObject.Text = Encoding.ASCII.GetString(LastResult);
            }
            else if (rbBytes.Checked)
            {
                string s = "";
                foreach (byte b in LastResult)
                    s += Convert.ToString(b, 10) + " ";
                tbResultObject.Text = s;
            }
            else if (rbBits.Checked)
            {
                string s = "";
                foreach (byte b in LastResult)
                {
                    string x = Convert.ToString(b, 2);
                    for (int i = 0; i < 8 - x.Length; i++)
                        s += "0";
                    s += Convert.ToString(b, 2) + " ";
                }
                tbResultObject.Text = s;
            }
            else
            {
                string s = "";
                foreach (byte b in LastResult)
                    s += "0x" + b.ToString("X2") + " ";
                tbResultObject.Text = s;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rbString_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLastResult();
        }

        private void rbBits_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLastResult();
        }

        private void rbBytes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLastResult();
        }

        private void rbHex_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLastResult();
        }

    }
}