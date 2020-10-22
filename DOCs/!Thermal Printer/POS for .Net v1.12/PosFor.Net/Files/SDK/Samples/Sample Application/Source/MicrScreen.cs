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
    public partial class MicrScreen : TestApplication.DeviceScreenBase
    {
        Micr _micr;
        public MicrScreen()
        {
            InitializeComponent();
        }

        public override void SetOpened(bool opened)
        {
            if (_micr == null)
            {
                _micr = (Micr)PosCommon;
                _micr.DataEvent += new DataEventHandler(micr_DataEvent);
            }

        }


        void micr_DataEvent(object sender, DataEventArgs e)
        {
            string str = "Account Number: " + _micr.AccountNumber + "\r\n";
            str += "Amount: " + _micr.Amount + "\r\n";
            str += "Bank Number: " + _micr.BankNumber + "\r\n";
            str += "Check Type: " + _micr.CheckType.ToString() + "\r\n";
            str += "Country Code: " + _micr.CountryCode.ToString() + "\r\n";
            str += "EPC: " + _micr.Epc + "\r\n";
            str += "Serial Number: " + _micr.SerialNumber + "\r\n";
            str += "Transit Number: " + _micr.TransitNumber + "\r\n";
            str += "Raw Data: " + _micr.RawData + "\r\n";

            DisplayMessage(str);
        }

        #region Micr
        private void btnMicrBeginInsertion_Click(object sender, System.EventArgs e)
        {
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _micr.BeginInsertion(Int32.Parse(textBox5.Text));
                
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


        private void btnMicrEndInsertion_Click(object sender, System.EventArgs e)
        {
            try
            {
                _micr.EndInsertion();
                
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }

        }

        private void btnMicrBeginRemoval_Click(object sender, System.EventArgs e)
        {
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _micr.BeginRemoval(Int32.Parse(textBox5.Text));
                
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

        private void btnMicrEndRemoval_Click(object sender, System.EventArgs e)
        {
            try
            {
                _micr.EndRemoval();
                
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        #endregion

      
    }
}

