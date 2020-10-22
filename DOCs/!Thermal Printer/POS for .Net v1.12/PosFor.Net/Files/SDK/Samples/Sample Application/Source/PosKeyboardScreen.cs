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
    
    public partial class PosKeyboardScreen : TestApplication.DeviceScreenBase
    {
        PosKeyboard _keyboard;
        public PosKeyboardScreen()
        {
            InitializeComponent();
        }

        public override void SetOpened(bool opened)
        {
            if (_keyboard == null)
            {
                _keyboard = (PosKeyboard)PosCommon;
                _keyboard.DataEvent += new DataEventHandler(key_DataEvent);
            }

            if (opened)
                UpdateUI();
        }

        void key_DataEvent(object sender, DataEventArgs e)
        {
            string str = "KeyData: " + ((Keys)_keyboard.PosKeyData).ToString() + " Type: " + _keyboard.PosKeyEventType.ToString() + "\r\n";

            DisplayMessage(str.Replace("\0", "?"));
        }

        private void UpdateUI()
        {
            KeyDownradioButton.Checked = (_keyboard.EventTypes == KeyboardEventType.Down);

            KeyDownUpradioButton.Enabled = _keyboard.CapKeyUp;
            KeyDownUpradioButton.Checked = (_keyboard.EventTypes == KeyboardEventType.DownUp);
        }

        private void KeyDownUpradioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                _keyboard.EventTypes = (KeyDownUpradioButton.Checked ? KeyboardEventType.DownUp : KeyboardEventType.Down);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }
    }
}

