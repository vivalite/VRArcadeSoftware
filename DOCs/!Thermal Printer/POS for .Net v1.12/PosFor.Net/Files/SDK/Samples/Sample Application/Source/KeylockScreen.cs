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
    public partial class KeylockScreen : TestApplication.DeviceScreenBase
    {
        Keylock keylock;
        public KeylockScreen()
        {
            InitializeComponent();
        }

        public override void SetOpened(bool opened)
        {
            if (keylock == null)
            {
                keylock = (Keylock)PosCommon;
                keylock.StatusUpdateEvent += new StatusUpdateEventHandler(keylock_StatusUpdateEvent);
            }

            if (opened)
                UpdateUI();
        }

        void keylock_StatusUpdateEvent(object sender, StatusUpdateEventArgs e)
        {
            tbKeyPosition.Text = GetKeylockPosition();
        }

        public override void SetDeviceEnabled(bool enabled)
        {
            if (enabled)
            {
                tbKeyPosition.Text = GetKeylockPosition();
            }
        }

        private void UpdateUI()
        {
            cbWaitPosition.Items.Clear();
            cbWaitPosition.Items.Add("Any");
            cbWaitPosition.Items.Add("Locked");
            cbWaitPosition.Items.Add("Normal");
            cbWaitPosition.Items.Add("Supervisor");

            for (int i = 3; i < keylock.PositionCount; i++)
                cbWaitPosition.Items.Add((i + 1).ToString());

            cbWaitPosition.SelectedIndex = 0;
            cbWaitPosition.Refresh();
        }

        private void btnWaitForKeylockChange_Click(object sender, System.EventArgs e)
        {
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Position = cbWaitPosition.SelectedIndex;

                try
                {
                    keylock.WaitForKeylockChange(Position, Int32.Parse(tbKeylockTimeout.Text));

                    string pos = GetKeylockPosition();

                    tbKeyPosition.Text = pos;

                    DisplayMessage("Keylock position changed to: " + pos + ".");

                }
                catch (PosControlException pe)
                {
                    if (pe.ErrorCode == ErrorCode.Timeout)
                    {
                        DisplayMessage("WaitForKeylockChange timed out.");
                    }
                    else
                    {
                        throw;
                    }
                }
            
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

        private string GetKeylockPosition()
        {
            if (keylock.KeyPosition == Keylock.PositionLocked)
                return "Locked";
            else if (keylock.KeyPosition == Keylock.PositionNormal)
                return "Normal";
            else if (keylock.KeyPosition == Keylock.PositionSupervisor)
                return "Supervisor";
            else
                return keylock.KeyPosition.ToString();
        }

    }
}

