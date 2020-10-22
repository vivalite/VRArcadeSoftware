using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.PointOfService;
using System.Reflection;
using System.Globalization;

namespace TestApplication
{
    public partial class PinPadScreen : TestApplication.DeviceScreenBase
    {
        PinPad pinpad;
        public PinPadScreen()
        {
            InitializeComponent();

            cbTransactionType.Items.Clear();
            cbTransactionType.Items.AddRange(Enum.GetNames(typeof(EftTransactionType)));
            cbTransactionType.Text = EftTransactionType.Debit.ToString();

            cbPinPadSystem.Items.Clear();
            cbPinPadSystem.Items.AddRange(Enum.GetNames(typeof(PinPadSystem)));
            SetComboBoxTextWithoutUpdate(cbPinPadSystem, PinPadSystem.Dukpt.ToString());

            tbAccountNumber.Leave += new EventHandler(tbAccountNumber_Leave);
            tbMerchantId.Leave += new EventHandler(tbMerchantId_Leave);
            tbTerminalId.Leave += new EventHandler(tbTerminalId_Leave);
            tbAmount.Leave += new EventHandler(tbAmount_Leave);
            tbTrack1Data.Leave += new EventHandler(tbTrack1Data_Leave);
            tbTrack2Data.Leave += new EventHandler(tbTrack2Data_Leave);
            tbMaxPinLength.Leave += new EventHandler(tbMaxPinLength_Leave);
            tbMinPinLength.Leave += new EventHandler(tbMinPinLength_Leave);
        }

        void tbTrack2Data_Leave(object sender, EventArgs e)
        {
            try
            {
                pinpad.Track2Data = Encoding.ASCII.GetBytes(tbTrack2Data.Text);
            }
            catch (Exception ex)
            {
                ShowException(ex);
                tbTrack2Data.Text = Encoding.ASCII.GetString(pinpad.Track2Data);
            }
        }

        void tbTrack1Data_Leave(object sender, EventArgs e)
        {
            try
            {
                pinpad.Track1Data = Encoding.ASCII.GetBytes(tbTrack1Data.Text);
            }
            catch (Exception ex)
            {
                ShowException(ex);
                tbTrack1Data.Text = Encoding.ASCII.GetString(pinpad.Track1Data);
            }
        }

        void tbAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                pinpad.Amount = decimal.Parse(tbAmount.Text);
            }
            catch (Exception ex)
            {
                ShowException(ex);
                tbAmount.Text = pinpad.Amount.ToString();
            }
        }

        void tbTerminalId_Leave(object sender, EventArgs e)
        {
            try
            {
                pinpad.TerminalId = tbTerminalId.Text;
            }
            catch (Exception ex)
            {
                ShowException(ex);
                tbTerminalId.Text = pinpad.TerminalId;
            }
        }

        void tbMerchantId_Leave(object sender, EventArgs e)
        {
            try
            {
                pinpad.MerchantId = tbMerchantId.Text;
            }
            catch (Exception ex)
            {
                ShowException(ex);
                tbMerchantId.Text = pinpad.MerchantId;
            }
        }

        void tbAccountNumber_Leave(object sender, EventArgs e)
        {
            try
            {
                pinpad.AccountNumber = tbAccountNumber.Text;
            }
            catch (Exception ex)
            {
                ShowException(ex);
                tbAccountNumber.Text = pinpad.AccountNumber;
            }
        }

        public override void SetOpened(bool opened)
        {
            if (pinpad == null)
            {
                pinpad = (PinPad)PosCommon;
                pinpad.DataEvent += new DataEventHandler(pinpad_DataEvent);
                pinpad.ErrorEvent += new DeviceErrorEventHandler(pinpad_ErrorEvent);
            }

            if (opened)
                UpdateUI();
            
        }

        void UpdateUI()
        {
            if (pinpad.CapDisplay == PinPadDisplay.RestrictedList || 
                pinpad.CapDisplay == PinPadDisplay.RestrictedOrder)
            {
                cbPrompt.Enabled = true;
                cbPrompt.Items.Clear();

                foreach (PinPadMessage msg in pinpad.AvailablePromptsList)
                    cbPrompt.Items.Add(msg.ToString());

                //SetComboBoxTextWithoutUpdate(cbPrompt, pinpad.Prompt.ToString());
            }
            else
            {
                SetComboBoxTextWithoutUpdate(cbPrompt, pinpad.CapDisplay.ToString());
                cbPrompt.Enabled = false;
            }


            if (pinpad.CapLanguage != PinPadLanguage.None)
            {
                cbLanguage.Enabled = true;
                cbLanguage.Items.Clear();

                foreach (CultureInfo lang in pinpad.AvailableLanguagesList)
                    cbLanguage.Items.Add(lang.ToString());

                SetComboBoxTextWithoutUpdate(cbLanguage, pinpad.PromptLanguage.ToString());
            }
            else
            {
                SetComboBoxTextWithoutUpdate(cbLanguage, pinpad.CapLanguage.ToString());
                cbLanguage.Enabled = false;
            }
            
            tbAccountNumber.Text = pinpad.AccountNumber;
            tbMerchantId.Text = pinpad.MerchantId;
            tbTerminalId.Text = pinpad.TerminalId;
            tbAmount.Text = pinpad.Amount.ToString();
            tbTrack1Data.Text = Encoding.ASCII.GetString(pinpad.Track1Data);
            tbTrack2Data.Text = Encoding.ASCII.GetString(pinpad.Track2Data);

            EnabledEftControls(true);

            tbMinPinLength.Text = pinpad.MinimumPinLength.ToString();
            tbMaxPinLength.Text = pinpad.MaximumPinLength.ToString();
        }

        void EnabledEftControls(bool enabled)
        {
            tbAccountNumber.Enabled = enabled;
            tbMerchantId.Enabled = enabled;
            tbTerminalId.Enabled = enabled;
            tbAmount.Enabled = enabled;
            tbTrack1Data.Enabled = enabled;
            tbTrack2Data.Enabled = enabled;
            cbTransactionType.Enabled = enabled;
            cbPinPadSystem.Enabled = enabled;
            tbTransactionHost.Enabled = enabled;
        }

        void pinpad_DataEvent(object sender, DataEventArgs e)
        {
            if ((PinEntryStatus)e.Status == PinEntryStatus.Success)
                DisplayMessage("EncryptedPIN = " + pinpad.EncryptedPin + "\r\nAdditionalSecurityInformation = " + pinpad.AdditionalSecurityInformation);
            else if ((PinEntryStatus)e.Status == PinEntryStatus.Cancel)
                DisplayMessage("Pin entry was cancelled.");
            else if ((PinEntryStatus)e.Status == PinEntryStatus.Timeout)
                DisplayMessage("A timeout condition occured in the pinpad.");
            else
                DisplayMessage("Pinpad returned status code: " + e.Status.ToString());
        }

        void pinpad_ErrorEvent(object sender, DeviceErrorEventArgs e)
        {
            if (e.ErrorCode == ErrorCode.Extended || e.ErrorCodeExtended == PinPad.ExtendedErrorBadKey)
            {
                DisplayMessage("An encryption key is corrupted or missing.");
            }
        }

        private void btnBeginEftTransaction_Click(object sender, System.EventArgs e)
        {
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (tbTerminalId.Text.Length > 0)
                    pinpad.TerminalId = tbTerminalId.Text;
                if (tbMerchantId.Text.Length > 0)
                    pinpad.MerchantId = tbMerchantId.Text;
                if (tbAccountNumber.Text.Length > 0)
                    pinpad.AccountNumber = tbAccountNumber.Text;

                pinpad.TransactionType = (EftTransactionType)Enum.Parse(typeof(EftTransactionType), cbTransactionType.Text);

                if (tbAmount.Text.Length > 0)
                    pinpad.Amount = Decimal.Parse(tbAmount.Text);

                if (tbTrack1Data.Text.Length > 0)
                    pinpad.Track1Data = Encoding.ASCII.GetBytes(tbTrack1Data.Text);

                if (tbTrack2Data.Text.Length > 0)
                    pinpad.Track2Data = Encoding.ASCII.GetBytes(tbTrack2Data.Text);
                //c.Track3Data = null;
                //c.Track4Data = null;

                PinPadSystem pps = (PinPadSystem)Enum.Parse(typeof(PinPadSystem), cbPinPadSystem.Text);
                int th = int.Parse(tbTransactionHost.Text);
                pinpad.BeginEftTransaction(pps, th);
                
                EnabledEftControls(false);
                
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

        private void btnEnablePinEntry_Click(object sender, System.EventArgs e)
        {
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                pinpad.EnablePinEntry();
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

        private void btnEndEftTransaction_Click(object sender, System.EventArgs e)
        {
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                pinpad.EndEftTransaction(EftTransactionCompletion.Normal);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
            finally
            {
                Cursor.Current = old;
                EnabledEftControls(true);
            }
        }

        

        private void cbPrompt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPrompt.Tag != null)
                return;

            try
            {
                PinPadMessage msg = (PinPadMessage)Enum.Parse(typeof(PinPadMessage), cbPrompt.Text);
                pinpad.Prompt = msg;
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
            
        }

        void SetComboBoxTextWithoutUpdate(ComboBox cb, string text)
        {
            cb.Tag = cb;
            try
            {
                if (cb.Items.Contains(text))
                    cb.Text = text;
                else
                    cb.Text = "";
            }
            finally
            {
                cb.Tag = null;
            }
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLanguage.Tag != null)
                return;

            try
            {
                pinpad.PromptLanguage = new CultureInfo(cbLanguage.Text);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        void tbMinPinLength_Leave(object sender, EventArgs e)
        {
            try
            {
                pinpad.MinimumPinLength = int.Parse(tbMinPinLength.Text);
            }
            catch (Exception ae)
            {
                ShowException(ae);

                tbMinPinLength.Focus();
                tbMinPinLength.SelectAll();
            }
        }

        void tbMaxPinLength_Leave(object sender, EventArgs e)
        {
            try
            {
                pinpad.MaximumPinLength = int.Parse(tbMaxPinLength.Text);
            }
            catch (Exception ae)
            {
                ShowException(ae);

                tbMaxPinLength.Focus();
                tbMaxPinLength.SelectAll();
            }
        }


    }
}

