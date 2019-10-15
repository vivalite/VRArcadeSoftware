using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using VRGameSelectorServerDTO;

namespace ManagingSystem
{
    public partial class ClientInfo : Telerik.WinControls.UI.RadForm
    {
        private bool _moreConfigTrigged;
        private LiveClientStatus _liveClientStatus;

        public ClientInfo()
        {
            InitializeComponent();

            this.Height = 300;

            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

        }

        public ClientInfo(LiveClientStatus liveClientStatus) : this()
        {
            _liveClientStatus = liveClientStatus;
        }

        private void NetworkFunction_OnIncommingSystemConfig(object sender, EventArgs e)
        {
            List<SystemConfig> lsc = ((SystemConfigEvent)e).SystemConfig;

            foreach (SystemConfig sc in lsc)
            {
                switch (sc.Type)
                {
                    case Enums.SysConfigType.MANAGER_PASSWORD:

                        if (_moreConfigTrigged)
                        {
                            _moreConfigTrigged = false;
                            if (sc.Value != "")
                            {
                                this.InvokeUI(() =>
                                {
                                    tsNumericKeypad keyboard = new tsNumericKeypad("Enter Manager Password");
                                    keyboard.IsPassword = true;

                                    DialogResult dr = keyboard.ShowDialog();

                                    if (dr == DialogResult.OK)
                                    {
                                        if (keyboard.Data == sc.Value)
                                        {
                                            radButtonMoreConfig.Enabled = false;

                                            int tmpAddHeight = 160;
                                            this.Height += tmpAddHeight;
                                            if (this.Location.Y - tmpAddHeight / 2 > 0)
                                            {
                                                this.Location = new Point(this.Location.X, this.Location.Y - tmpAddHeight / 2);
                                            }

                                            //this.ShowAlertBox("Client Info", "Please becareful with these powerful features!");

                                        }
                                        else
                                        {
                                            this.ShowAlertBox("Manager Features", "Password is incorrect!");
                                        }

                                    }

                                });
                            }
                            else
                            {
                                this.InvokeUI(() =>
                                {
                                    radButtonMoreConfig.Enabled = false;

                                    int tmpAddHeight = 160;
                                    this.Height += tmpAddHeight;
                                    if (this.Location.Y - tmpAddHeight / 2 > 0)
                                    {
                                        this.Location = new Point(this.Location.X, this.Location.Y - tmpAddHeight / 2);
                                    }
                                });
                            }
                        }

                        break;
                    case Enums.SysConfigType.DEFAULT_TIMED_SESSION_LENGTH:

                        this.InvokeUI(() =>
                        {
                            int tmpMin = 50;

                            int.TryParse(sc.Value, out tmpMin);

                            radSpinEditorSessionTime.Value = tmpMin == 0 ? 50 : tmpMin;

                        });

                        break;
                }
            }

        }

        private void ClientInfo_Load(object sender, EventArgs e)
        {
            NetworkFunction.OnIncommingSystemConfig += NetworkFunction_OnIncommingSystemConfig;

            if (_liveClientStatus != null)
            {
                string status = "";
                bool isOnline = false;

                Utility.TranslateOnlineStatus(_liveClientStatus.ClientStatus, out status, out isOnline);

                radTextBoxName.Text = _liveClientStatus.ClientName;
                radTextBoxIP.Text = _liveClientStatus.ClientIP;
                radTextBoxPlayTimeRemain.Text = _liveClientStatus.TimeLeft.ToString(@"hh\:mm\:ss");
                radTextBoxStatus.Text = status + Environment.NewLine + _liveClientStatus.AdditionalInfo;

                switch (_liveClientStatus.ClientStatus)
                {
                    case Enums.LiveClientStatus.GAMEOVER_FOR_CLEANING:
                        radButtonHelpMarkProvided.Text = "Mark As Cleaned";
                        radButtonHelpMarkProvided.Enabled = true;
                        break;
                    case Enums.LiveClientStatus.CLEANING_DONE:
                        radButtonHelpMarkProvided.Text = "Mark As Cleaned";
                        radButtonHelpMarkProvided.Enabled = false;
                        break;
                    case Enums.LiveClientStatus.NONE:
                    case Enums.LiveClientStatus.OFFLINE:
                    case Enums.LiveClientStatus.ONLINE:
                    case Enums.LiveClientStatus.IN_GAME_SELECTOR:
                    case Enums.LiveClientStatus.IN_GAME:
                    case Enums.LiveClientStatus.ERROR:
                        radButtonHelpMarkProvided.Text = "Mark Help Provided";
                        radButtonHelpMarkProvided.Enabled = _liveClientStatus.IsAssistanceRequested;
                        break;
                    default:
                        break;
                }


            }


        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            GamePlayHistory gph = new GamePlayHistory(_liveClientStatus.ClientID);
            gph.ShowDialog();
        }

        private void radButtonMoreConfig_Click(object sender, EventArgs e)
        {
            NetworkFunction.GetSystemConfig(new List<SystemConfig>()
            {
                new SystemConfig(Enums.SysConfigType.MANAGER_PASSWORD),
                new SystemConfig(Enums.SysConfigType.DEFAULT_TIMED_SESSION_LENGTH)
            });
            _moreConfigTrigged = true;
        }

        private void ClientInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            NetworkFunction.OnIncommingSystemConfig -= NetworkFunction_OnIncommingSystemConfig;
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

        private void radButtonStartSessionNonTimed_Click(object sender, EventArgs e)
        {
            DialogResult dr = RadMessageBox.Show(this, string.Format("Are you sure you want to *MANUALLY* start session on this machines?"), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

            if (dr == DialogResult.Yes)
            {
                List<ClientParm> clientParm = new List<ClientParm>();

                clientParm.Add(new ClientParm(_liveClientStatus.ClientID));

                NetworkFunction.SendStartNow(clientParm);

                this.Close();
            }
        }

        private void radButtonStartSessionTimed_Click(object sender, EventArgs e)
        {
            DialogResult dr = RadMessageBox.Show(this, string.Format("Are you sure you want to start timed session on this machines for ({0}) minutes?", radSpinEditorSessionTime.Value), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

            if (dr == DialogResult.Yes)
            {
                List<ClientParm> clientParm = new List<ClientParm>();
                Dictionary<string, string> dParm = new Dictionary<string, string>();

                dParm.Add("Duration", radSpinEditorSessionTime.Value.ToString());
                clientParm.Add(new ClientParm(_liveClientStatus.ClientID, dParm));

                NetworkFunction.SendStartTiming(clientParm);

                this.Close();
            }

        }

        private void radButtonEndSession_Click(object sender, EventArgs e)
        {
            DialogResult dr = RadMessageBox.Show(this, string.Format("Are you sure you want to *MANUALLY* end session on this machines?"), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

            if (dr == DialogResult.Yes)
            {
                List<ClientParm> clientParm = new List<ClientParm>();
                Dictionary<string, string> dParm = new Dictionary<string, string>();

                dParm.Add("EndMode", "Manual");

                clientParm.Add(new ClientParm(_liveClientStatus.ClientID, dParm));

                NetworkFunction.SendEndNow(clientParm);

                this.Close();
            }
        }

        private void radButtonComputerReboot_Click(object sender, EventArgs e)
        {
            DialogResult dr = RadMessageBox.Show(this, string.Format("Are you sure you want to re-boot this machines?"), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

            if (dr == DialogResult.Yes)
            {
                List<ClientParm> clientParm = new List<ClientParm>();

                clientParm.Add(new ClientParm(_liveClientStatus.ClientID));

                NetworkFunction.SendReboot(clientParm);

                this.Close();
            }
        }

        private void radButtonComputerTurnOff_Click(object sender, EventArgs e)
        {
            DialogResult dr = RadMessageBox.Show(this, string.Format("Are you sure you want to turn off this machines?"), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

            if (dr == DialogResult.Yes)
            {
                List<ClientParm> clientParm = new List<ClientParm>();

                clientParm.Add(new ClientParm(_liveClientStatus.ClientID));

                NetworkFunction.SendTurnOff(clientParm);

                this.Close();
            }
        }

        private void radButtonUSBOff_Click(object sender, EventArgs e)
        {
            DialogResult dr = RadMessageBox.Show(this, string.Format("Are you sure you want to turn off Keyboard / Mouse / USB storage device on this machines?"), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

            if (dr == DialogResult.Yes)
            {
                List<ClientParm> clientParm = new List<ClientParm>();

                clientParm.Add(new ClientParm(_liveClientStatus.ClientID));

                NetworkFunction.SendTurnOffKMU(clientParm);

                this.Close();
            }
        }

        private void radButtonUSBOn_Click(object sender, EventArgs e)
        {
            DialogResult dr = RadMessageBox.Show(this, string.Format("Are you sure you want to turn on Keyboard / Mouse / USB storage device on this machines?"), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

            if (dr == DialogResult.Yes)
            {
                List<ClientParm> clientParm = new List<ClientParm>();

                clientParm.Add(new ClientParm(_liveClientStatus.ClientID));

                NetworkFunction.SendTurnOnKMU(clientParm);

                this.Close();
            }
        }

        private void radButtonHelpMarkProvided_Click(object sender, EventArgs e)
        {
            string msg;

            if (_liveClientStatus.ClientStatus == Enums.LiveClientStatus.GAMEOVER_FOR_CLEANING)
            {
                msg = "Are you sure you want to mark as \"Cleaned\"?";
            }
            else
            {
                msg = "Are you sure you want to mark as help provided?";
            }


            DialogResult dr = RadMessageBox.Show(this, string.Format(msg), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

            if (dr == DialogResult.Yes)
            {
                List<ClientParm> clientParm = new List<ClientParm>();

                clientParm.Add(new ClientParm(_liveClientStatus.ClientID));

                if (_liveClientStatus.ClientStatus == Enums.LiveClientStatus.GAMEOVER_FOR_CLEANING)
                {
                    NetworkFunction.TurnOffCleaningFlag(clientParm);
                }
                else
                {
                    NetworkFunction.TurnOffAssistingFlag(clientParm);
                }

                this.Close();
            }
        }
    }
}
