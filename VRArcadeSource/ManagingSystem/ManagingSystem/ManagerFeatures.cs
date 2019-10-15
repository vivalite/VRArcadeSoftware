using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using VRGameSelectorServerDTO;

namespace ManagingSystem
{
    public partial class ManagerFeatures : Telerik.WinControls.UI.RadForm
    {
        bool _requireRefresh;
        public ManagerFeatures()
        {
            InitializeComponent();

            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

        }

        private void InitData()
        {
            NetworkFunction.OnIncommingSystemConfig += NetworkFunction_OnIncommingSystemConfig;
            NetworkFunction.OnIncommingLiveSystemInfo += NetworkFunction_OnIncommingLiveSystemInfo;

            radListViewClientList.ShowCheckBoxes = true;
            radListViewClientList.ItemSpacing = 1;
            radListViewClientList.AllowEdit = false;
            radListViewClientList.AllowColumnReorder = false;
            radListViewClientList.AllowRemove = false;

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
                            int sessionLength = 50;

                            int.TryParse(sc.Value, out sessionLength);

                            radSpinEditorSessionTime.Value = sessionLength == 0 ? 50 : sessionLength;
                        });

                        break;
                }
            }
        }

        private void NetworkFunction_OnIncommingLiveSystemInfo(object sender, EventArgs e)
        {
            if (_requireRefresh)
            {
                LiveSystemInfo lsi = ((LiveSystemInfoEvent)e).LiveSystemInfo;

                this.InvokeUI(() =>
                {
                    PopulateClientList(lsi.LiveClientStatus);
                });
                _requireRefresh = false;
            }
        }

        private void PopulateClientList(List<LiveClientStatus> liveClientStatus)
        {
            if (liveClientStatus.Count > 0)
            {
                string status = "";
                bool isOnline = false;
                string timeLeft = "";

                liveClientStatus = liveClientStatus.OrderBy(x => x.ClientName).ToList();

                radListViewClientList.BeginUpdate();
                radListViewClientList.Items.Clear();
                foreach (LiveClientStatus lcs in liveClientStatus)
                {
                    Utility.TranslateOnlineStatus(lcs.ClientStatus, out status, out isOnline);

                    timeLeft = lcs.TimeLeft.ToString(@"hh\:mm\:ss");

                    if (isOnline)
                    {
                        radListViewClientList.Items.Add(lcs.ClientName, status, timeLeft, lcs);

                    }

                }
                radListViewClientList.EndUpdate();
            }
        }

        private void radListViewClientList_ItemMouseClick(object sender, Telerik.WinControls.UI.ListViewItemEventArgs e)
        {
            if (radListViewClientList.CurrentItem.CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                radListViewClientList.CurrentItem.CheckState = Telerik.WinControls.Enumerations.ToggleState.Off;
            }
            else
            {
                radListViewClientList.CurrentItem.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
        }

        private void ManagerFeatures_FormClosed(object sender, FormClosedEventArgs e)
        {
            NetworkFunction.OnIncommingSystemConfig -= NetworkFunction_OnIncommingSystemConfig;
            NetworkFunction.OnIncommingLiveSystemInfo -= NetworkFunction_OnIncommingLiveSystemInfo;
        }

        private void ManagerFeatures_Load(object sender, EventArgs e)
        {
            InitData();

            _requireRefresh = true;
            NetworkFunction.GetLiveSystemInfo();
            NetworkFunction.GetSystemConfig(new SystemConfig(Enums.SysConfigType.DEFAULT_TIMED_SESSION_LENGTH));
        }

        private void radButtonMore_Click(object sender, EventArgs e)
        {
            radButtonMore.Visible = false;
            radPanelMore.Height = 1;
            radPanelMore.Visible = true;

            AnimatedPropertySetting setting = new AnimatedPropertySetting();
            setting.Property = RadElement.BoundsProperty;
            setting.StartValue = new Rectangle(radPanelMore.Location.X, radPanelMore.Location.Y + 79, radPanelMore.Width, 1);
            setting.EndValue = new Rectangle(radPanelMore.Location.X, radPanelMore.Location.Y, radPanelMore.Width, radPanelMore.Height);
            setting.Interval = 30;
            setting.NumFrames = 10;
            setting.ApplyValue(radPanelMore.RootElement);


            //this.ShowAlertBox("Manager Features", "Please becareful with these powerful features!");
        }

        private void radButtonSelectNone_Click(object sender, EventArgs e)
        {
            if (radListViewClientList.Items.Count > 0)
            {
                radListViewClientList.UncheckAllItems();
            }
        }

        private void radButtonSelectAll_Click(object sender, EventArgs e)
        {
            if (radListViewClientList.Items.Count > 0)
            {
                radListViewClientList.CheckAllItems();
            }
        }

        private void radButtonSelectReverse_Click(object sender, EventArgs e)
        {
            if (radListViewClientList.Items.Count > 0)
            {
                foreach (ListViewDataItem lvdi in radListViewClientList.Items)
                {
                    if (lvdi.CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
                    {
                        lvdi.CheckState = Telerik.WinControls.Enumerations.ToggleState.Off;
                    }
                    else
                    {
                        lvdi.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                    }
                }
            }
        }

        private void radSpinEditorSessionTime_MouseDown(object sender, MouseEventArgs e)
        {
            tsNumericKeypad keyboard = new tsNumericKeypad("Enter Minutes");

            DialogResult dr = keyboard.ShowDialog();

            if (dr == DialogResult.OK)
            {
                int tmpMin = 50;

                int.TryParse(keyboard.Data, out tmpMin);

                radSpinEditorSessionTime.Value = tmpMin == 0 ? 50 : tmpMin;
            }

        }

        private void radButtonStartSessionTimed_Click(object sender, EventArgs e)
        {
            if (radListViewClientList.CheckedItems.Count > 0)
            {
                DialogResult dr = RadMessageBox.Show(this, string.Format("Are you sure you want to start timed session on ({0}) machines for ({1}) minutes of each?", radListViewClientList.CheckedItems.Count, radSpinEditorSessionTime.Value), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    List<ClientParm> clientParm = new List<ClientParm>();

                    foreach (ListViewDataItem lv in radListViewClientList.CheckedItems)
                    {
                        LiveClientStatus lcs = (LiveClientStatus)lv.Value;
                        Dictionary<string, string> dParm = new Dictionary<string, string>();

                        dParm.Add("Duration", radSpinEditorSessionTime.Value.ToString());
                        clientParm.Add(new ClientParm(lcs.ClientID, dParm));
                    }

                    NetworkFunction.SendStartTiming(clientParm);

                    this.Close();
                }
            }
            else
            {
                this.ShowAlertBox("Manager Features", "Please select at least one client machine to continue!");
            }
        }

        private void radButtonStartSessionNonTimed_Click(object sender, EventArgs e)
        {
            if (radListViewClientList.CheckedItems.Count > 0)
            {
                DialogResult dr = RadMessageBox.Show(this, string.Format("Are you sure you want to *MANUALLY* start session on ({0}) machines?", radListViewClientList.CheckedItems.Count), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    List<ClientParm> clientParm = new List<ClientParm>();

                    foreach (ListViewDataItem lv in radListViewClientList.CheckedItems)
                    {
                        LiveClientStatus lcs = (LiveClientStatus)lv.Value;

                        clientParm.Add(new ClientParm(lcs.ClientID));
                    }

                    NetworkFunction.SendStartNow(clientParm);

                    this.Close();
                }
            }
            else
            {
                this.ShowAlertBox("Manager Features", "Please select at least one client machine to continue!");
            }
        }

        private void radButtonEndSession_Click(object sender, EventArgs e)
        {
            if (radListViewClientList.CheckedItems.Count > 0)
            {
                DialogResult dr = RadMessageBox.Show(this, string.Format("Are you sure you want to *MANUALLY* end session on ({0}) machines?", radListViewClientList.CheckedItems.Count), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    List<ClientParm> clientParm = new List<ClientParm>();

                    foreach (ListViewDataItem lv in radListViewClientList.CheckedItems)
                    {
                        LiveClientStatus lcs = (LiveClientStatus)lv.Value;
                        Dictionary<string, string> dParm = new Dictionary<string, string>();

                        dParm.Add("EndMode", "Manual");

                        clientParm.Add(new ClientParm(lcs.ClientID, dParm));
                    }

                    NetworkFunction.SendEndNow(clientParm);

                    this.Close();
                }
            }
            else
            {
                this.ShowAlertBox("Manager Features", "Please select at least one client machine to continue!");
            }
        }

        private void radButtonUSBOn_Click(object sender, EventArgs e)
        {
            if (radListViewClientList.CheckedItems.Count > 0)
            {
                DialogResult dr = RadMessageBox.Show(this, string.Format("Are you sure you want to turn on Keyboard / Mouse / USB storage device on ({0}) machines?", radListViewClientList.CheckedItems.Count), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    List<ClientParm> clientParm = new List<ClientParm>();

                    foreach (ListViewDataItem lv in radListViewClientList.CheckedItems)
                    {
                        LiveClientStatus lcs = (LiveClientStatus)lv.Value;

                        clientParm.Add(new ClientParm(lcs.ClientID));
                    }

                    NetworkFunction.SendTurnOnKMU(clientParm);

                    this.Close();
                }
            }
            else
            {
                this.ShowAlertBox("Manager Features", "Please select at least one client machine to continue!");
            }
        }

        private void radButtonUSBOff_Click(object sender, EventArgs e)
        {
            if (radListViewClientList.CheckedItems.Count > 0)
            {
                DialogResult dr = RadMessageBox.Show(this, string.Format("Are you sure you want to turn off Keyboard / Mouse / USB storage device on ({0}) machines?", radListViewClientList.CheckedItems.Count), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    List<ClientParm> clientParm = new List<ClientParm>();

                    foreach (ListViewDataItem lv in radListViewClientList.CheckedItems)
                    {
                        LiveClientStatus lcs = (LiveClientStatus)lv.Value;

                        clientParm.Add(new ClientParm(lcs.ClientID));
                    }

                    NetworkFunction.SendTurnOffKMU(clientParm);

                    this.Close();
                }
            }
            else
            {
                this.ShowAlertBox("Manager Features", "Please select at least one client machine to continue!");
            }
        }

        private void radButtonComputerReboot_Click(object sender, EventArgs e)
        {
            if (radListViewClientList.CheckedItems.Count > 0)
            {
                DialogResult dr = RadMessageBox.Show(this, string.Format("Are you sure you want to re-boot ({0}) machines?", radListViewClientList.CheckedItems.Count), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    List<ClientParm> clientParm = new List<ClientParm>();

                    foreach (ListViewDataItem lv in radListViewClientList.CheckedItems)
                    {
                        LiveClientStatus lcs = (LiveClientStatus)lv.Value;

                        clientParm.Add(new ClientParm(lcs.ClientID));
                    }

                    NetworkFunction.SendReboot(clientParm);

                    this.Close();
                }
            }
            else
            {
                this.ShowAlertBox("Manager Features", "Please select at least one client machine to continue!");
            }
        }

        private void radButtonComputerTurnOff_Click(object sender, EventArgs e)
        {
            if (radListViewClientList.CheckedItems.Count > 0)
            {
                DialogResult dr = RadMessageBox.Show(this, string.Format("Are you sure you want to turn off ({0}) machines?", radListViewClientList.CheckedItems.Count), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    List<ClientParm> clientParm = new List<ClientParm>();

                    foreach (ListViewDataItem lv in radListViewClientList.CheckedItems)
                    {
                        LiveClientStatus lcs = (LiveClientStatus)lv.Value;

                        clientParm.Add(new ClientParm(lcs.ClientID));
                    }

                    NetworkFunction.SendTurnOff(clientParm);

                    this.Close();
                }
            }
            else
            {
                this.ShowAlertBox("Manager Features", "Please select at least one client machine to continue!");
            }
        }

        private void radButtonMarkClean_Click(object sender, EventArgs e)
        {
            if (radListViewClientList.CheckedItems.Count > 0)
            {
                DialogResult dr = RadMessageBox.Show(this, string.Format("Are you sure you want to mark ({0}) machines as \"Cleaned\"?", radListViewClientList.CheckedItems.Count), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    List<ClientParm> clientParm = new List<ClientParm>();

                    foreach (ListViewDataItem lv in radListViewClientList.CheckedItems)
                    {
                        LiveClientStatus lcs = (LiveClientStatus)lv.Value;

                        clientParm.Add(new ClientParm(lcs.ClientID));
                    }

                    NetworkFunction.TurnOffCleaningFlag(clientParm);

                    this.Close();
                }
            }
            else
            {
                this.ShowAlertBox("Manager Features", "Please select at least one client machine to continue!");
            }
        }

        private void radButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
