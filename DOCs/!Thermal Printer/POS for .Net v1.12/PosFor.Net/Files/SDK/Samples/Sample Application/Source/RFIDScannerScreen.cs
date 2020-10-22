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
    public partial class RFIDScannerScreen : TestApplication.DeviceScreenBase
    {
        RFIDScanner scanner;
        public RFIDScannerScreen()
        {
            InitializeComponent();
        }

        public override void SetOpened(bool opened)
        {
            if (scanner == null)
            {
                scanner = (RFIDScanner)PosCommon;
                scanner.DataEvent += new DataEventHandler(_rfidscanner_DataEvent);
            }
        }

        void _rfidscanner_DataEvent(object sender, DataEventArgs e)
        {
            string str = "Number of tags read: " + scanner.TagCount.ToString() + "\r\n";

            for (int i = 0; i < scanner.TagCount; i++)
            {
                if (i == 0)
                {
                    scanner.FirstTag();
                    UpdateRFIDData(scanner);
                }
                else
                    scanner.NextTag();

                str += "Tag: " + i.ToString() + "\r\n";
                str += "\tId:        " + BitConverter.ToString(scanner.CurrentTagId) + "\r\n";
                str += "\tProtocol:  " + scanner.CurrentTagProtocol.ToString() + "\r\n";
                str += "\tUser data: " + Encoding.ASCII.GetString(scanner.CurrentTagUserData).Trim('\0') + "\r\n";
            }
            if (scanner.TagCount > 0)
                scanner.FirstTag();

            DisplayMessage(str);

            if (scanner.ContinuousReadMode)
                scanner.DataEventEnabled = true;
        }


        private void UpdateRFIDData(RFIDScanner scanner)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            tbTagCount.Text = scanner.TagCount.ToString();
            tb_Tag_ID.Text = BitConverter.ToString(scanner.CurrentTagId);
            tb_User_Data.Text = Encoding.ASCII.GetString(scanner.CurrentTagUserData);

            // update write properties
            tbWriteTagID.Text = tb_Tag_ID.Text;
            tbWriteTagUserData.Text = tb_User_Data.Text;

        }

        private void btnReadtag_Click(object sender, EventArgs e)
        {
            try
            {
                scanner.ReadTags(RFIDReadOptions.IdAndFullUserData, null, null, 0, 0, int.Parse(tbReadTimeout.Text), null);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnConReadStart_Click(object sender, EventArgs e)
        {
            try
            {
                
                btnConReadStart.Enabled = false;
                btnConReadStop.Enabled = true;
                lbReadStatus.Text = "Reading...";

                if (scanner.CapReadTimer)
                    scanner.ReadTimerInterval = int.Parse(tbTimeInterval.Text, CultureInfo.InvariantCulture);

                scanner.StartReadTags(RFIDReadOptions.IdAndFullUserData, null, null, 0, 0, null);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnConReadStop_Click(object sender, EventArgs e)
        {
            try
            {
                scanner.StopReadTags(null);
                lbReadStatus.Text = "Stopped";
                btnConReadStart.Enabled = true;
                btnConReadStop.Enabled = false;
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnFirstTag_Click(object sender, EventArgs e)
        {
            try
            {
                scanner.FirstTag();
                UpdateRFIDData(scanner);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }


        private void btnNextTag_Click(object sender, EventArgs e)
        {
            try
            {
                scanner.NextTag();
                UpdateRFIDData(scanner);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnPreviousTag_Click(object sender, EventArgs e)
        {
            try
            {
                scanner.PreviousTag();
                UpdateRFIDData(scanner);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }


        byte[] HexStringToByteArray(string s)
        {
            string[] chars = s.Split('-');
            byte[] b = new byte[chars.Length];

            for (int i = 0; i < chars.Length; i++)
                b[i] = byte.Parse(chars[i], NumberStyles.HexNumber);

            return b;
        }


        private void btnWriteTag_Click(object sender, EventArgs e)
        {
            try
            {
                if ((scanner.CapWriteTag & WriteTagSections.UserData) > 0)
                {
                    byte[] tagId = HexStringToByteArray(tbWriteTagID.Text);
                    byte[] userData = Encoding.ASCII.GetBytes(tbWriteTagUserData.Text);

                    int start = int.Parse(tbStartPosition.Text);

                    int timeout = int.Parse(tbWriteTimeout.Text);
                    scanner.WriteTagData(tagId, userData, start, timeout, null);

                    DisplayMessage("Queued Tag write operation with Output Id: " + scanner.OutputId.ToString());
                }
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnLockTag_Click(object sender, EventArgs e)
        {
            try
            {
                if (scanner.CapLockTag)
                {
                    byte[] tagId = HexStringToByteArray(tbWriteTagID.Text);
                    scanner.LockTag(tagId, 1000, null);
                }
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }





        private void tbTimeInterval_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbTimeInterval.Text != string.Empty)
                    scanner.ReadTimerInterval = int.Parse(tbTimeInterval.Text);
                else
                    scanner.ReadTimerInterval = 0;
            }
            catch (Exception)
            {
            }

        }

    }
}

