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
    public partial class SmartCardRWScreen : TestApplication.DeviceScreenBase
    {

        SmartCardRW _smartCard;
        public SmartCardRWScreen()
        {
            InitializeComponent();

            cbSmartCardReadAction.Items.Clear();
            cbSmartCardReadAction.Items.AddRange(Enum.GetNames(typeof(SmartCardReadAction)));
            cbSmartCardReadAction.SelectedIndex = 0;

            cbSmartCardWriteAction.Items.Clear();
            cbSmartCardWriteAction.Items.AddRange(Enum.GetNames(typeof(SmartCardWriteAction)));
            cbSmartCardWriteAction.SelectedIndex = 0;

            tbInputData.Leave += new EventHandler(tbInputData_Leave);
        }

        byte[] inputData;
        
        void tbInputData_Leave(object sender, EventArgs e)
        {
            try
            {
                inputData = GetBytes(tbInputData.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                tbInputData.Focus(); 
                tbInputData.SelectAll();
            }
        }

        public override void SetOpened(bool opened)
        {
            if (_smartCard == null)
            {
                _smartCard = (SmartCardRW)PosCommon;

                
                cbInterfaceMode.Items.Clear();
                foreach (SmartCardInterfaceModes val in Enum.GetValues(typeof(SmartCardInterfaceModes)))
                {
                    if (((int)_smartCard.CapInterfaceMode & (int)val) > 0)
                        cbInterfaceMode.Items.Add(val.ToString());
                }

                cbIsoEmvMode.Items.Clear();
                foreach (SmartCardIsoEmvModes val in Enum.GetValues(typeof(SmartCardIsoEmvModes)))
                {
                    if (((int)_smartCard.CapIsoEmvMode & (int)val) > 0)
                        cbIsoEmvMode.Items.Add(val.ToString());
                }

                cbSCSlot.Items.Clear();
                for (int i=0; i<32; i++)
                {
                    if ((_smartCard.CapSCSlots & (1<<i)) > 0)
                        cbSCSlot.Items.Add(i.ToString());
                }
            }
        }

        public override void SetDeviceEnabled(bool enabled)
        {
            if (enabled)
            {
                cbInterfaceMode.Text = _smartCard.InterfaceMode.ToString();
                cbIsoEmvMode.Text = _smartCard.IsoEmvMode.ToString();
                cbSCSlot.Text = _smartCard.SCSlot.ToString();
            }
        }

        private void btnBeginInsertion_Click(object sender, System.EventArgs e)
        {
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _smartCard.BeginInsertion(Int32.Parse(tbTimeout.Text));

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
            finally
            {
                Cursor.Current = old;
            }
        }


        private void btnEndInsertion_Click(object sender, System.EventArgs e)
        {
            try
            {
                _smartCard.EndInsertion();

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }

        }

        private void btnBeginRemoval_Click(object sender, System.EventArgs e)
        {
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _smartCard.BeginRemoval(Int32.Parse(tbTimeout.Text));

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
            finally
            {
                Cursor.Current = old;
            }
        }

        private void btnEndRemoval_Click(object sender, System.EventArgs e)
        {
            try
            {
                _smartCard.EndRemoval();
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnReadData_Click(object sender, EventArgs e)
        {
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                SmartCardReadAction action = (SmartCardReadAction)Enum.Parse(typeof(SmartCardReadAction), cbSmartCardReadAction.Text);

                byte [] outputData = _smartCard.ReadData(action, inputData);

                if (_smartCard.CapInterfaceMode == SmartCardInterfaceModes.Apdu)
                    tbResultData.Text = DisplayRapdu(outputData);
                else 
                    tbResultData.Text = GetString(outputData);

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
            finally
            {
                Cursor.Current = old;
            }
        }

        private void btnWriteData_Click(object sender, EventArgs e)
        {
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                SmartCardWriteAction action = (SmartCardWriteAction)Enum.Parse(typeof(SmartCardWriteAction), cbSmartCardWriteAction.Text);
                _smartCard.WriteData(action, inputData);
                tbResultData.Text = "";
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
            finally
            {
                Cursor.Current = old;
            }
        }

        byte[] GetBytes(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new byte[0];

            List<byte> bytes = new List<byte>();

            foreach (string s in input.Split(' '))
            {
                string s1 = s.TrimEnd(',', ' ', 'x', 'X', 'h', 'H');
                s1 = s1.TrimStart(',', ' ', 'x', 'X', 'h', 'H', '0');
                if (s1.Length == 0)
                    bytes.Add((byte)0);
                else
                    bytes.Add(byte.Parse(s1, NumberStyles.HexNumber));
            }
            
            return bytes.ToArray();
        }

        private string GetString(byte[] outputData)
        {
            if (outputData == null)
                return "";

            string res = "";
            foreach (byte b in outputData)
            {
                if (res.Length != 0)
                    res += ", ";
                res += "0x" + b.ToString("X2");
            }
            return res;
        }



        private static string DisplayRapdu(byte[] ResponseApdu)
        {
            StringBuilder res = new StringBuilder();

            // buffer always ends with ... sw1 sw2
            byte sw1 = Buffer.GetByte(ResponseApdu, ResponseApdu.Length - 2);
            byte sw2 = Buffer.GetByte(ResponseApdu, ResponseApdu.Length - 1);
            res.AppendLine("---- Response..: " + ShowErrorString(sw1, sw2));

            if (ResponseApdu.Length > 2)
            {
                res.AppendLine("---- data......: ");
                res.Append(DumpHex(ResponseApdu, ResponseApdu.Length - 2));
            }

            return res.ToString();
        }

        private static string DumpHex(byte[] pb, int icb)
        {
            StringBuilder result = new StringBuilder();

            int i, j, k = 0;
            while (true)
            {
                // how many to print on this row
                j = (icb <= 16) ? icb : 16;

                // exit if none to print
                if (j <= 0)
                    return result.ToString();
                icb -= j;

                // print up to 16 Hex on a row
                result.Append("             ");
                for (i = 0; i < j; i++)
                    result.AppendFormat("{0:X2} ", pb[k + i]);

                // now print up to 16 asci on same row
                for (i = 16 - j; i > 0; i--)
                    result.Append("   ");

                result.Append("  | ");
                for (i = 0; i < j; i++)
                    result.AppendFormat("{0}", ((pb[k + i] < 32) ? (char)'.' : (char)pb[k + i]));

                result.AppendLine(" |");
                k += i;
            }
        }

        private static string ShowErrorString(byte b1, byte b2)
        {
            string str = "";

            switch (b1)
            {
                case 0x61:
                    str = String.Format("Operation successful - {0} bytes additional data", b2);
                    break;
                case 0x62:
                    {
                        switch (b2)
                        {
                            case 0x81:
                                str = "Operation failed - returned data may be erroneous";
                                break;
                            case 0x82:
                                str = "Operation failed - EOF encountered on file";
                                break;
                            case 0x83:
                                str = "Operation failed - file irreversibly blocked";
                                break;
                            case 0x84:
                                str = "Operation failed - File control info improperly structured";
                                break;
                            default:
                                str = "Warning - state of non-volatile memory not changed";
                                break;
                        }
                        break;
                    }
                case 0x63:
                    {
                        if ((b2 & 0xc0) == 0xc0)
                        {
                            str = String.Format("Operation failed - counter now is {0}\n", b2 & 0x3f);
                            break;
                        }
                        str = "Warning - state of non-volatile memory not changed";
                        break;
                    }
                case 0x64:
                    str = "Operation failed - execution error - state of non-volatile memory not changed";
                    break;
                case 0x65:
                    if (b2 == 0x81)
                    {
                        str = "Operation failed - memory error";
                        break;
                    }
                    str = "Operation failed - execution error - state of non-volatile memory not changed";
                    break;
                case 0x67:
                    if (b2 == 0x00)
                    {
                        str = "Operation failed - length incorrect";
                        break;
                    }
                    str = "Operation failed - check errors";
                    break;
                case 0x68:
                    {
                        switch (b2)
                        {
                            case 0x00:
                                str = "Operation failed - functions in class byte not supported";
                                break;
                            case 0x81:
                                str = "Operation failed - logical channels not supported";
                                break;
                            case 0x82:
                                str = "Operation failed - secure messaging not supported";
                                break;
                            default:
                                str = "Operation failed on card - unknown error";
                                break;
                        }
                        break;
                    }
                case 0x69:
                    {
                        switch (b2)
                        {
                            case 0x00:
                                str = "Operation failed - command not allowed";
                                break;
                            case 0x81:
                                str = "Operation failed - command incompatible with file structure";
                                break;
                            case 0x82:
                                str = "Operation failed - security state not satisfied";
                                break;
                            case 0x83:
                                str = "Operation failed - authentication method blocked";
                                break;
                            case 0x84:
                                str = "Operation failed - data reversibly blocked";
                                break;
                            case 0x85:
                                str = "Operation failed - usage conditions not satisfied";
                                break;
                            case 0x86:
                                str = "Operation failed - command not allowed (no EF selected)";
                                break;
                            case 0x87:
                                str = "Operation failed - expected secure messaging data objects missing";
                                break;
                            case 0x88:
                                str = "Operation failed - expected secure messaging data objects incorrect";
                                break;
                            default:
                                str = "Operation failed on card - unknown error";
                                break;
                        }
                        break;
                    }
                case 0x6a:
                    {
                        switch (b2)
                        {
                            case 0x00:
                                str = "Operation failed - Incorrect P1 or P2 parameters";
                                break;
                            case 0x80:
                                str = "Operation failed - Parameters in the data portion are incorrect";
                                break;
                            case 0x81:
                                str = "Operation failed - Function not supported";
                                break;
                            case 0x82:
                                str = "Operation failed - File Not found";
                                break;
                            case 0x83:
                                str = "Operation failed - Record not found";
                                break;
                            case 0x84:
                                str = "Operation failed - Insufficient memory";
                                break;
                            case 0x85:
                                str = "Operation failed - Lc inconsistent with TLV structure";
                                break;
                            case 0x86:
                                str = "Operation failed - Incorrect P1 or P2 parameter";
                                break;
                            case 0x87:
                                str = "Operation failed - Lc inconsistent with P1 or P2";
                                break;
                            case 0x88:
                                str = "Operation failed - Referenced data not found";
                                break;
                            default:
                                str = "Operation failed on card - unknown error";
                                break;
                        }
                        break;
                    }
                case 0x6b:
                    str = "Operation failed - parameter 1 or 2 is incorrect";
                    break;
                case 0x6c:
                    str = String.Format("Operation failed - bad length value - {0} is the correct length", b2);
                    break;
                case 0x6d:
                    str = "Operation failed - Command not supported";
                    break;
                case 0x6e:
                    str = "Operation failed - Class not supported";
                    break;
                case 0x6f:
                    str = "Operation failed - Command aborted - more exact info not available";
                    break;
                case 0x90:
                    str = "Operation succeeded";
                    break;
                case 0x92:
                    {
                        if ((b2 & 0x0f) == 0)
                        {
                            str = String.Format("Write to EEPROM successful after {0} attempts", b2);
                            break;
                        }
                        switch (b2)
                        {
                            case 0x10:
                                str = "Operation failed - insufficient memory";
                                break;
                            case 0x40:
                                str = "Operation failed - write to EEPROM failed";
                                break;
                            default:
                                str = "Operation failed on card - unknown error";
                                break;
                        }
                        break;
                    }
                case 0x94:
                    {
                        switch (b2)
                        {
                            case 0:
                                str = "Operation failed - no EF selected";
                                break;
                            case 0x02:
                                str = "Operation failed - address range exceeded";
                                break;
                            case 0x04:
                                str = "Operation failed - FID, record, or comparison pattern not found";
                                break;
                            case 0x08:
                                str = "Operation failed - selected file type does not match command";
                                break;
                            default:
                                str = "Operation failed on card - unknown error";
                                break;
                        }
                        break;
                    }
                case 0x98:
                    {
                        switch (b2)
                        {
                            case 0x02:
                                str = "Operation failed - no PIN defined";
                                break;
                            case 0x04:
                                str = "Operation failed - access conditions not satisfied";
                                break;
                            case 0x35:
                                str = "Operation failed - ask random or give random not executed";
                                break;
                            case 0x40:
                                str = "Operation failed - PIN verification not successful";
                                break;
                            case 0x50:
                                str = "Operation failed - increase or decreased failed - limit reached";
                                break;
                            default:
                                str = "Operation failed on card - unknown error";
                                break;
                        }
                        break;
                    }
                case 0x9f:
                    str = "Operation successful";
                    break;
                default:
                    str = "Operation failed on card - unknown error";
                    break;
            }

            str += String.Format(" [{0:x2} {1:X2}]", b1, b2);

            return str;
        }

        private void cbInterfaceMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _smartCard.InterfaceMode = (SmartCardInterfaceModes)Enum.Parse(typeof(SmartCardInterfaceModes), cbInterfaceMode.Text);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void cbIsoEmvMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _smartCard.IsoEmvMode = (SmartCardIsoEmvModes)Enum.Parse(typeof(SmartCardIsoEmvModes), cbIsoEmvMode.Text);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void cbSCSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _smartCard.SCSlot = int.Parse(cbSCSlot.Text);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        
    }
}

