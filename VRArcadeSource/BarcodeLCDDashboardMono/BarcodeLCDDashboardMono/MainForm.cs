using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Linq;
using BarcodeLCDDashboardMono.VRArcadeServer;
using System.Globalization;

namespace BarcodeLCDDashboardMono
{
    public sealed partial class MainForm : Form
    {
        private System.Timers.Timer _timer1s;
        private System.Timers.Timer _timerDelayRun;
        private System.Timers.Timer _timerCleanDoneButtonDelayRun;
        private System.Timers.Timer _timerHelpProvidedButtonDelayRun;
        VRArcadeServer.DashboardService _dashboardClient;
        private bool _tutorialShowed = false;
        private string _ip = "";
        private string _mac = "";
        private DateTime _lastConnectionTime = DateTime.MinValue;
        private string _lastBarcode = "";
        private CurrentWindowState _currWindowState = CurrentWindowState.None;

        DashboardModuleInfo dashInfoDbg;

        public MainForm()
        {
            Utility.InitCoreConfig();
            Utility.GetIPInfo(out _ip, out _mac);
            if (Utility.GetCoreConfig("FullScreen").ToLower() == "true")
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }

            InitializeComponent();
            HideAll();

            InitSerial();

            InitWebService();

            _timer1s = new System.Timers.Timer();
            _timer1s.Elapsed += new ElapsedEventHandler(OnTimer2sEvent);
            _timer1s.Interval = 2000;
            _timer1s.Enabled = false;

            _timerDelayRun = new System.Timers.Timer();
            _timerDelayRun.Elapsed += new ElapsedEventHandler(OnTimerDelayRunEvent);
            _timerDelayRun.Interval = 2000;
            _timerDelayRun.Enabled = true;

            _timerCleanDoneButtonDelayRun = new System.Timers.Timer();
            _timerCleanDoneButtonDelayRun.Elapsed += new ElapsedEventHandler(OnTimerCleanDoneButtonDelayRunEvent);
            _timerCleanDoneButtonDelayRun.Interval = 1000;
            _timerCleanDoneButtonDelayRun.Enabled = false;

            _timerHelpProvidedButtonDelayRun = new System.Timers.Timer();
            _timerHelpProvidedButtonDelayRun.Elapsed += new ElapsedEventHandler(OnTimerHelpProvidedButtonDelayRunEvent);
            _timerHelpProvidedButtonDelayRun.Interval = 1000;
            _timerHelpProvidedButtonDelayRun.Enabled = false;


            SetDefaultLable();
        }



        private void OnTimerDelayRunEvent(object sender, ElapsedEventArgs e)
        {
            this.InvokeUI(() =>
            {
                //ShowHelpRequested(); // test
                //ShowWaitingCleaning(); // test
            });

            _timerDelayRun.Enabled = false;
            _timerDelayRun.Dispose();

            _timer1s.Enabled = true;

            OnTimer2sEvent(null, null);
        }

        private void OnTimer2sEvent(object sender, ElapsedEventArgs e)
        {
            PopulateCurrentStatus();

            if (_currWindowState != CurrentWindowState.None)
            {
                if (DateTime.Now.Subtract(_lastConnectionTime).Seconds > 10)
                {
                    this.InvokeUI(() =>
                    {
                        HideAll();
                        _currWindowState = CurrentWindowState.None;
                    });
                }
            }
            else
            {
                this.InvokeUI(() =>
                {
                    SetDefaultLable();
                });
            }

        }

        private void InitSerial()
        {
            SerialPortHelper.OnSerialPort_MessageReceived += SerialPortHelper_OnSerialPort_MessageReceived;
            SerialPortHelper.InitSerialPort("/dev/ttyAMA0", false);
        }

        private void InitWebService()
        {
            _dashboardClient = new VRArcadeServer.DashboardService();
            _dashboardClient.Timeout = 3000;
            _dashboardClient.Url = "http://" + Utility.GetCoreConfig("ServerIPPort") + "/VRArcadeDashboardService/";

        }


        private void PopulateCurrentStatus()
        {
            try
            {
                DashboardModuleInfo dashInfo = _dashboardClient.PopulateContent(_ip);
                dashInfoDbg = dashInfo;

                _lastConnectionTime = DateTime.Now;

                System.Diagnostics.Debug.WriteLine("New Status In " + _lastConnectionTime.ToString());


                if (dashInfo.LiveClientStatus == EnumsLiveClientStatus.GAMEOVER_FOR_CLEANING)
                {
                    this.InvokeUI(() =>
                    {
                        ShowWaitingCleaning();
                    });
                }
                else if (dashInfo.LiveClientStatus == EnumsLiveClientStatus.CLEANING_DONE)
                {
                    _tutorialShowed = false;
                    this.InvokeUI(() =>
                    {
                        ShowReady();
                    });
                }
                else if (dashInfo.LiveClientStatus == EnumsLiveClientStatus.IN_GAME || dashInfo.LiveClientStatus == EnumsLiveClientStatus.IN_GAME_SELECTOR)
                {
                    if (dashInfo.IsRequireAssistant)
                    {
                        this.InvokeUI(() =>
                        {
                            ShowHelpRequested(dashInfo.CurrentRunningTitle);
                        });
                    }
                    else
                    {
                        this.InvokeUI(() =>
                        {
                            ShowUsing();
                        });
                    }
                }
                else
                {
                    this.InvokeUI(() =>
                    {
                        HideAll();
                        _currWindowState = CurrentWindowState.None;
                    });
                }


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in PopulateCurrentStatus: " + ex.ToString());
            }
        }



        private void SerialPortHelper_OnSerialPort_MessageReceived(object sender, EventArgs e)
        {
            string recvTxt = ((SerialMessageReceivedEvent)e).Message;

            try
            {
                _dashboardClient.BarcodeInput(_ip, recvTxt);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in on serial port message in. [" + recvTxt + "]: " + ex.ToString());
            }

            _lastBarcode = recvTxt;

        }

        private void SetDefaultLable()
        {
            string decodedStr = "";

            if (_lastBarcode.Length > 0)
            {
                Ascii85 a85 = new Ascii85();

                try
                {
                    Guid guid = new Guid(a85.Decode(_lastBarcode));
                    decodedStr = guid.ToString();
                }
                catch (Exception)
                {

                }
            }

            string dbg = "";
            if (dashInfoDbg != null)
            {
                dbg = dashInfoDbg.LiveClientStatus.ToString();
            }

            string txtBuildDate = Properties.Resources.BuildDate.Trim();

            labelIPInfo.Dock = DockStyle.Fill;
            labelIPInfo.Text = "IP Address: " + _ip + Environment.NewLine + Environment.NewLine +
                "MAC Address: " + _mac + Environment.NewLine + Environment.NewLine +
                "Current Time: " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine +
                "Last Connected Time: " + _lastConnectionTime.ToString() + Environment.NewLine + Environment.NewLine +
                "Build Date: " + txtBuildDate + Environment.NewLine + Environment.NewLine +
                "Status: " + dbg + Environment.NewLine + Environment.NewLine +
                (_lastBarcode.Length > 0 ? "Barcode: " + _lastBarcode + Environment.NewLine + Environment.NewLine : "") +
                (decodedStr.Length > 0 ? "Decoded: " + decodedStr : "");
        }

        private void HideAll()
        {
            BackgroundImage = null;
            tableLayoutPanelInstVideo.Visible = false;
            tableLayoutPanelReady.Visible = false;
            tableLayoutPanelUsing.Visible = false;
            tableLayoutPanelWaitingCleaning.Visible = false;
            tableLayoutPanelHelpRequest.Visible = false;
        }

        private void ShowInstVideo()
        {
            if (_currWindowState != CurrentWindowState.InstVideo)
            {
                _currWindowState = CurrentWindowState.InstVideo;
                HideAll();
                tableLayoutPanelInstVideo.Dock = DockStyle.Fill;
                tableLayoutPanelInstVideo.Visible = true;
                BackgroundImage = Properties.Resources._2;
            }
        }

        private void ShowHelpRequested(string gameInfo)
        {
            if (_currWindowState != CurrentWindowState.HelpRequested)
            {
                _currWindowState = CurrentWindowState.HelpRequested;
                HideAll();
                tableLayoutPanelHelpRequest.Dock = DockStyle.Fill;
                tableLayoutPanelHelpRequest.Visible = true;
                BackgroundImage = Properties.Resources._0;
                labelHelpRequestCurrentPlaying.Text = gameInfo;
            }
        }

        private void ShowReady()
        {
            if (_currWindowState != CurrentWindowState.Ready)
            {
                _currWindowState = CurrentWindowState.Ready;
                HideAll();
                tableLayoutPanelReady.Dock = DockStyle.Fill;
                tableLayoutPanelReady.Visible = true;
                BackgroundImage = Properties.Resources.HTC;
            }
        }

        private void ShowUsing()
        {
            if (!_tutorialShowed)
            {
                ShowInstVideo();
            }
            else
            {
                if (_currWindowState != CurrentWindowState.Using)
                {
                    _currWindowState = CurrentWindowState.Using;
                    HideAll();
                    tableLayoutPanelUsing.Dock = DockStyle.Fill;
                    tableLayoutPanelUsing.Visible = true;
                    BackgroundImage = Properties.Resources._1;
                }
            }
        }

        private void ShowWaitingCleaning()
        {
            if (_currWindowState != CurrentWindowState.Cleaning)
            {
                _currWindowState = CurrentWindowState.Cleaning;
                HideAll();
                tableLayoutPanelWaitingCleaning.Dock = DockStyle.Fill;
                tableLayoutPanelWaitingCleaning.Visible = true;
                BackgroundImage = Properties.Resources._3;
            }
        }

        private void buttonInstVideoYes_Click(object sender, System.EventArgs e)
        {
            if (tableLayoutPanelInstVideo.Visible)
            {
                tableLayoutPanelInstVideo.Visible = false;
                Utility.RunVideo();
                tableLayoutPanelInstVideo.Visible = true;
            }
        }

        private void buttonInstVideoNo_Click(object sender, System.EventArgs e)
        {
            _tutorialShowed = true;
            ShowUsing();
        }

        private void gelButtonCleaningDone_MouseDown(object sender, MouseEventArgs e)
        {
            _timerCleanDoneButtonDelayRun.Enabled = true;
        }

        private void gelButtonCleaningDone_MouseUp(object sender, MouseEventArgs e)
        {
            _timerCleanDoneButtonDelayRun.Enabled = false;
        }

        private void OnTimerCleanDoneButtonDelayRunEvent(object sender, ElapsedEventArgs e)
        {
            _timerCleanDoneButtonDelayRun.Enabled = false;

            try
            {
                _dashboardClient.MarkCleanProvided(_ip);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in Clean Done: " + ex.ToString());
            }

        }

        private void gelButtonHelpProvided_MouseDown(object sender, MouseEventArgs e)
        {
            _timerHelpProvidedButtonDelayRun.Enabled = true;
        }

        private void gelButtonHelpProvided_MouseUp(object sender, MouseEventArgs e)
        {
            _timerHelpProvidedButtonDelayRun.Enabled = false;
        }

        private void OnTimerHelpProvidedButtonDelayRunEvent(object sender, ElapsedEventArgs e)
        {
            _timerHelpProvidedButtonDelayRun.Enabled = false;

            try
            {
                _dashboardClient.MarkHelpProvided(_ip);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in Help Provided: " + ex.ToString());
            }
        }



        private enum CurrentWindowState
        {
            None,
            InstVideo,
            HelpRequested,
            Ready,
            Using,
            Cleaning
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _timer1s.Enabled = false;

            SerialPortHelper.CloseConnection();

        }

        private void labelIPInfo_DoubleClick(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application

            //_timer1s.Enabled = false;

            //this.Close();

            Utility.RunVideo();

        }

        private void labelIPInfo_Click(object sender, EventArgs e)
        {
            //Utility.RunVideo();
            //Utility.PlayTestAudio();
        }
    }
}
