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
    public partial class MsrScreen : TestApplication.DeviceScreenBase
    {
        Msr _msr;
        public MsrScreen()
        {
            InitializeComponent();

            comboBoxTracksToRead.Items.Clear();
            comboBoxTracksToRead.Items.AddRange(Enum.GetNames(typeof(MsrTracks)));
            comboBoxTracksToRead.Items.RemoveAt(0);  // remove "None"

            comboBoxErrorReportingType.Items.Clear();
            comboBoxErrorReportingType.Items.AddRange(Enum.GetNames(typeof(MsrErrorReporting)));
        }

        public override void SetOpened(bool opened)
        {
            if (_msr == null)
            {
                _msr = (Msr)PosCommon;
                _msr.DataEvent += new DataEventHandler(_msr_DataEvent);
                _msr.ErrorEvent += new DeviceErrorEventHandler(_msr_ErrorEvent);
            }

            if (opened)
                UpdateUI();
        }

        void _msr_ErrorEvent(object sender, DeviceErrorEventArgs e)
        {
            if (_msr.ErrorReportingType == MsrErrorReporting.Track)
                DisplayMessage(GetMsrData(e.ErrorCodeExtended));
        }

        void _msr_DataEvent(object sender, DataEventArgs e)
        {
            DisplayMessage(GetMsrData(e.Status));
        }

        static private string GetString(byte[] b)
        {
            return GetString(b, false);
        }

        static private string GetString(byte[] b, bool hex)
        {
            if (b == null)
                return "";

            StringBuilder sb = new StringBuilder(b.Length);

            for (int i = 0; i < b.Length; i++)
                if (hex)
                    sb.Append(b[i].ToString("X2"));
                else
                    sb.Append((char)b[i]);

            return sb.ToString();

        }

        string GetMsrData(int trackStatus)
        {
            bool EncryptionIsSupported = false;
            StringBuilder sb = new StringBuilder();

            if (_msr.ServiceObjectVersion.Major >= 1 && _msr.ServiceObjectVersion.Minor >= 12)
            {
                EncryptionIsSupported = (_msr.CapDataEncryption != EncryptionAlgorithm.None);

                string cardtype = _msr.CardType;
                if (string.IsNullOrEmpty(cardtype))
                    cardtype = "Unknown";
                sb.AppendLine("CardType: " + cardtype);
            }

            sb.AppendLine("Raw Track data:");
            sb.AppendLine("   TrackStatus: " + (trackStatus & 0xFF) + "," + ((trackStatus & 0xFF00) >> 8) + "," + ((trackStatus & 0xFF0000) >> 16) + "," + ((trackStatus & 0xFF000000) >> 24));
            sb.AppendLine("   Track1Data	: " + GetString(_msr.Track1Data, false));
            sb.AppendLine("   Track1DiscData	: " + GetString(_msr.Track1DiscretionaryData, false));
            sb.AppendLine("   Track2Data	: " + GetString(_msr.Track2Data, false));
            sb.AppendLine("   Track2DiscData	: " + GetString(_msr.Track2DiscretionaryData, false));
            sb.AppendLine("   Track3Data	: " + GetString(_msr.Track3Data, false));
            sb.AppendLine("   Track4Data	: " + GetString(_msr.Track4Data, false));

            if (EncryptionIsSupported)
            {
                sb.AppendLine("Encrypted Track data:");
                sb.AppendLine("   Track1EncryptedData	: " + GetString(_msr.Track1EncryptedData, true));
                sb.AppendLine("   Track2EncryptedData	: " + GetString(_msr.Track2EncryptedData, true));
                sb.AppendLine("   Track3EncryptedData	: " + GetString(_msr.Track3EncryptedData, true));
                sb.AppendLine("   Track4EncryptedData	: " + GetString(_msr.Track4EncryptedData, true));
            }

            sb.AppendLine("Formatted data:");

            try
            {
                if (_msr.ServiceObjectVersion.Major >= 1 && _msr.ServiceObjectVersion.Minor >= 12 && _msr.CardPropertyList != null && _msr.CardPropertyList.Count > 0)
                {
                    sb.AppendLine("  CardPropertyList:");
                    foreach (string property in _msr.CardPropertyList)
                    {
                        string value = "";
                        try
                        {
                            value = _msr.RetrieveCardProperty(property);
                        }
                        catch (Exception ex)
                        {
                            value = ex.Message;
                        }
                        sb.AppendLine("   " + property + " : " + value);
                    }
                }
            }
            catch (Exception) { }

            sb.AppendLine(" Card Properties:");
            sb.AppendLine("   Account		: " + _msr.AccountNumber);
            sb.AppendLine("   Exp Date		: " + _msr.ExpirationDate);
            sb.AppendLine("   Title		: " + _msr.Title);
            sb.AppendLine("   First Name	: " + _msr.FirstName);
            sb.AppendLine("   MI			: " + _msr.MiddleInitial);
            sb.AppendLine("   Last Name	: " + _msr.Surname);
            sb.AppendLine("   Service Code	: " + _msr.ServiceCode);
            sb.AppendLine("   Suffix		: " + _msr.Suffix);
        

            try
            {
                sb.AppendLine("CapEncryptionSystem              : " + _msr.CapDataEncryption.ToString());
                if (_msr.CapDataEncryption != EncryptionAlgorithm.None)
                    sb.AppendLine("AdditionalSecurityInformation    : " + GetString(_msr.AdditionalSecurityInformation, true));

                if (_msr.CapCardAuthentication != null)
                {
                    sb.AppendLine("CapAuthenticationData            : " + _msr.CapCardAuthentication);
                    if (_msr.CapCardAuthentication.Length > 0)
                        sb.AppendLine("Authentication Data              : " + GetString(_msr.CardAuthenticationData, true));
                }
            }
            catch (Exception) { }


            return sb.ToString();
        }

        public override void Refresh()
        {
            base.Refresh();
            UpdateUI();
        }

        

        private void cbDecodeData_CheckedChanged(object sender, EventArgs e)
        {
            _msr.DecodeData = cbDecodeData.Checked;
            UpdateUI();
        }

        private void cbParseDecodeData_CheckedChanged(object sender, EventArgs e)
        {
            _msr.ParseDecodeData = cbParseDecodeData.Checked;
            UpdateUI();
        }

        private void cbTransmitSentinels_CheckedChanged(object sender, EventArgs e)
        {
            if (_msr.ServiceObjectVersion.Minor >= 5)
                _msr.TransmitSentinels = cbTransmitSentinels.Checked;
            UpdateUI();
        }

        private void comboBoxTracksToRead_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            MsrTracks tracks2read = (MsrTracks)0;
            while (i < comboBoxTracksToRead.Text.Length)
            {
                if (comboBoxTracksToRead.Text[i] == '1')
                    tracks2read |= MsrTracks.Track1;
                if (comboBoxTracksToRead.Text[i] == '2')
                    tracks2read |= MsrTracks.Track2;
                if (comboBoxTracksToRead.Text[i] == '3')
                    tracks2read |= MsrTracks.Track3;
                if (comboBoxTracksToRead.Text[i] == '4')
                    tracks2read |= MsrTracks.Track4;
                i++;
            }

            _msr.TracksToRead = tracks2read;
    
        }

        private void comboBoxErrorReportingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxErrorReportingType.Text == "Card")
                _msr.ErrorReportingType = MsrErrorReporting.Card;
            else
                _msr.ErrorReportingType = MsrErrorReporting.Track;
        }

        private void UpdateUI()
        {
            if (_msr.State != ControlState.Closed)
            {
                cbParseDecodeData.Checked = _msr.ParseDecodeData;
                cbDecodeData.Checked = _msr.DecodeData;
                if (_msr.ServiceObjectVersion.Minor >= 5)
                {
                    cbTransmitSentinels.Enabled = true;
                    cbTransmitSentinels.Checked = _msr.TransmitSentinels;
                }
                else
                {
                    cbTransmitSentinels.Enabled = false;
                }

                comboBoxTracksToRead.Text = _msr.TracksToRead.ToString();
                comboBoxErrorReportingType.Text = _msr.ErrorReportingType.ToString();
            }
        }
    }
}

