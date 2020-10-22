using ManagingSystem.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using VRGameSelectorServerDTO;
using Microsoft.Office.Interop.Excel;

namespace ManagingSystem
{
    public partial class MainWindow : Telerik.WinControls.UI.RadForm
    {
        System.Data.DataTable _dtClientList = new System.Data.DataTable();
        private bool _flipStatus = false;
        //private System.Threading.Timer _timerFlip;
        private System.Timers.Timer _timer1s;
        private bool _optionButtonTrigged;
        private bool _managerButtonTrigged;
        private bool _barcodeButtonTrigged;
        private bool _waiverProceesButtonTrigged;
        private bool _uiInitNeeded;
        private readonly object _lockCardView = new object();

        public MainWindow()
        {
            InitializeComponent();

            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);

        }

        private void InitData()
        {
            NetworkFunction.OnIncommingSystemConfig += NetworkFunction_OnIncommingSystemConfig;
            NetworkFunction.OnIncommingLiveSystemInfo += NetworkFunction_OnIncommingLiveSystemInfo;
            NetworkFunction.OnIncommingBarcodeInfo += NetworkFunction_OnIncommingBarcodeInfo;

            radCardViewMain.AllowEdit = false;
            radCardViewMain.AllowArbitraryItemHeight = false;
            radCardViewMain.AllowShowFocusCues = true;
            radCardViewMain.AutoScroll = true;
            radCardViewMain.Focusable = true;
            radCardViewMain.AllowRemove = false;
            radCardViewMain.CardTemplate.AllowCustomize = false;
            radCardViewMain.CardViewElement.ViewElement.Orientation = Orientation.Vertical;
            radCardViewMain.CardViewElement.ViewElement.Font = new System.Drawing.Font(radCardViewMain.CardViewElement.ViewElement.Font.FontFamily, radCardViewMain.CardViewElement.ViewElement.Font.Size, FontStyle.Bold);


            _dtClientList.Columns.Add("Column 0", typeof(bool));
            _dtClientList.Columns.Add("Column 1", typeof(LiveClientStatus));
            _dtClientList.Columns.Add("Column 2", typeof(string));
            _dtClientList.Columns.Add("Column 3", typeof(string));
            _dtClientList.Columns.Add("Column 4", typeof(string));
            _dtClientList.Columns.Add("Column 5", typeof(string));

            radCardViewMain.CardViewElement.CardTemplate.SaveLayout(Path.GetTempPath() + "VRZMgLayout.xml");
            radCardViewMain.DataSource = _dtClientList;
            radCardViewMain.CardViewElement.CardTemplate.LoadLayout(Path.GetTempPath() + "VRZMgLayout.xml");

            //if (Utility.IsValidLicenseAvailable())
            //{
            //    //this.Text += " (Licensed Version. Will Expire On " + Utility.GetLicenseExpirationDate() + " )";
            //}

            //_timerFlip = new System.Threading.Timer((e) =>
            //{
            //    FlipAssistantRow();
            //}, null, 200, (int)TimeSpan.FromMilliseconds(700).TotalMilliseconds);


            _timer1s = new System.Timers.Timer();
            _timer1s.Elapsed += new ElapsedEventHandler(OnTimer1sEvent);
            _timer1s.Interval = 1000;
            _timer1s.Enabled = true;

        }

        private void OnTimer1sEvent(object sender, ElapsedEventArgs e)
        {
            this.InvokeUI(() =>
            {
                radLabelElementCurrTime.Text = DateTime.Now.ToString("MMMM dd, yyyy - HH:mm:ss");

                if (NetworkFunction.GetSecondsSinceLastRefresh() >= 0)
                {
                    radCardViewMain.Enabled = true;
                    radLabelElementRefresh.Text = "Last Refreshed in " + NetworkFunction.GetSecondsSinceLastRefresh().ToString("0.0") + " Seconds";
                }
                else
                {
                    radCardViewMain.Enabled = false;
                    radLabelElementRefresh.Text = "Server is Not Connected";
                    radButtonPrintBarcode.Visible = false;
                    radButtonWaiverProcess.Visible = false;
                    _uiInitNeeded = true;
                }

                if (_uiInitNeeded)
                {
                    NetworkFunction.GetSystemConfig(new SystemConfig(Enums.SysConfigType.LCD_BARCODE_MODULE, ""));
                    _uiInitNeeded = false;
                }

            });

        }

        private void NetworkFunction_OnIncommingSystemConfig(object sender, EventArgs e)
        {
            List<SystemConfig> lsc = ((SystemConfigEvent)e).SystemConfig;

            foreach (SystemConfig sc in lsc)
            {
                switch (sc.Type)
                {
                    case Enums.SysConfigType.ADMIN_PASSWORD:

                        if (_optionButtonTrigged)
                        {
                            _optionButtonTrigged = false;

                            if (sc.Value != "")
                            {
                                this.InvokeUI(() =>
                                {
                                    tsNumericKeypad keyboard = new tsNumericKeypad("Enter Admin Password");
                                    keyboard.IsPassword = true;

                                    DialogResult dr = keyboard.ShowDialog();

                                    if (dr == DialogResult.OK)
                                    {
                                        if (keyboard.Data == sc.Value)
                                        {
                                            try
                                            {
                                                Options op = new Options();
                                                op.ShowDialog();
                                            }
                                            catch
                                            {
                                                // eat radcontrol error
                                            }
                                        }
                                        else
                                        {
                                            this.ShowAlertBox("System Options", "Password is incorrect!");
                                        }
                                    }

                                });
                            }
                            else
                            {
                                this.InvokeUI(() =>
                                {
                                    try
                                    {
                                        Options op = new Options();
                                        op.ShowDialog();
                                    }
                                    catch
                                    {
                                        // eat radcontrol error
                                    }
                                });
                            }
                        }
                        break;

                    case Enums.SysConfigType.MANAGER_PASSWORD:

                        if (_managerButtonTrigged)
                        {
                            _managerButtonTrigged = false;

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
                                            ManagerFeatures mf = new ManagerFeatures();
                                            mf.ShowDialog();
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
                                    ManagerFeatures mf = new ManagerFeatures();
                                    mf.ShowDialog();
                                });
                            }
                        }
                        else if (_barcodeButtonTrigged)
                        {
                            _barcodeButtonTrigged = false;
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
                                            BarcodeGeneration bg = new BarcodeGeneration();
                                            bg.ShowDialog();
                                        }
                                        else
                                        {
                                            this.ShowAlertBox("Barcode Generation", "Password is incorrect!");
                                        }

                                    }

                                });
                            }
                            else
                            {
                                this.InvokeUI(() =>
                                {
                                    BarcodeGeneration bg = new BarcodeGeneration();
                                    bg.ShowDialog();
                                });
                            }
                        }
                        else if (_waiverProceesButtonTrigged)
                        {
                            _waiverProceesButtonTrigged = false;

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
                                            try
                                            {
                                                WaiverProcess wp = new WaiverProcess();
                                                wp.ShowDialog();
                                            }
                                            catch (ExternalException)
                                            {

                                            }
                                        }
                                        else
                                        {
                                            this.ShowAlertBox("Waiver Process", "Password is incorrect!");
                                        }

                                    }

                                });
                            }
                            else
                            {
                                this.InvokeUI(() =>
                                {
                                    try
                                    {
                                        WaiverProcess wp = new WaiverProcess();
                                        wp.ShowDialog();
                                    }
                                    catch (ExternalException)
                                    {

                                    }

                                });
                            }
                        }

                        break;
                    case Enums.SysConfigType.LCD_BARCODE_MODULE:

                        this.InvokeUI(() =>
                        {
                            if (sc.Value == "True")
                            {
                                radButtonPrintBarcode.Visible = true;
                                radButtonWaiverProcess.Visible = true;
                            }
                            else
                            {
                                radButtonPrintBarcode.Visible = false;
                                radButtonWaiverProcess.Visible = false;
                            }
                        });

                        break;
                    default:
                        break;
                }
            }

        }

        private void NetworkFunction_OnIncommingLiveSystemInfo(object sender, EventArgs e)
        {
            LiveSystemInfo lsi = ((LiveSystemInfoEvent)e).LiveSystemInfo;

            this.InvokeUI(() =>
            {
                PopulateMainCardView(lsi.LiveClientStatus);
            });

        }

        private void PopulateMainCardView(List<LiveClientStatus> liveClientStatus)
        {
            string status = "";
            bool isOnline = false;
            string timeLeft = "";
            string assist = "";
            string mode = "";

            lock (_lockCardView)
            {

                if (liveClientStatus.Count > 0)
                {
                    //radCardViewMain.SelectedItem = null;

                    radCardViewMain.BeginUpdate();

                    // delete non-exist
                    List<DataRow> removeClientListItem = new List<DataRow>();

                    foreach (DataRow dr in _dtClientList.Rows)
                    {
                        LiveClientStatus lcsCurr = ((LiveClientStatus)dr["Column 1"]);

                        LiveClientStatus lcs = liveClientStatus.Where(x => x.ClientID == lcsCurr.ClientID).FirstOrDefault();

                        if (lcs == null)
                        {
                            // item is deleted
                            removeClientListItem.Add(dr);
                        }
                    }

                    foreach (DataRow dr in removeClientListItem)
                    {
                        _dtClientList.Rows.Remove(dr);
                    }

                    // sort liveClientStatus

                    liveClientStatus = liveClientStatus.OrderBy(x => x.ClientName).ToList();

                    // add new or change existing
                    foreach (LiveClientStatus lcs in liveClientStatus)
                    {
                        Utility.TranslateOnlineStatus(lcs.ClientStatus, out status, out isOnline);

                        timeLeft = lcs.TimeLeft.ToString(@"hh\:mm\:ss");
                        assist = lcs.IsAssistanceRequested ? "Yes" : "No";

                        switch (lcs.Mode)
                        {
                            case "TIMING_ON":

                                mode = "Timing";

                                break;
                            case "NO_TIMING_ON":

                                mode = "Manual";

                                break;
                            default:

                                if (status != "ERROR" && isOnline)
                                {
                                    mode = "-";
                                }
                                else
                                {
                                    mode = "-";
                                }

                                break;
                        }

                        bool bFoundlcsItem = false;

                        foreach (DataRow dr in _dtClientList.Rows)
                        {
                            LiveClientStatus lcsCurr = ((LiveClientStatus)dr["Column 1"]);

                            if (lcsCurr.ClientID == lcs.ClientID)
                            {
                                if ((bool)dr["Column 0"] != isOnline || lcsCurr.ClientName != lcs.ClientName || (string)dr["Column 2"] != mode
                                    || (string)dr["Column 3"] != status || (string)dr["Column 4"] != timeLeft || (string)dr["Column 5"] != assist)
                                {
                                    dr["Column 0"] = isOnline;
                                    dr["Column 1"] = lcs;
                                    dr["Column 2"] = mode;
                                    dr["Column 3"] = status;
                                    dr["Column 4"] = timeLeft;
                                    dr["Column 5"] = assist;
                                    _dtClientList.AcceptChanges();
                                }

                                bFoundlcsItem = true;
                            }

                        }

                        if (!bFoundlcsItem)
                        {
                            _dtClientList.Rows.Add(isOnline, lcs, mode, status, timeLeft, assist);
                            _dtClientList.AcceptChanges();
                        }

                    }



                    radCardViewMain.EndUpdate();

                }

            }
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {
            NetworkFunction.Init();

            InitData();

            _uiInitNeeded = true;

        }



        private void radButtonOptions_Click(object sender, EventArgs e)
        {
            NetworkFunction.GetSystemConfig(new SystemConfig(Enums.SysConfigType.ADMIN_PASSWORD, ""));
            _optionButtonTrigged = true;
        }

        private void radButtonManager_Click(object sender, EventArgs e)
        {
            NetworkFunction.GetSystemConfig(new SystemConfig(Enums.SysConfigType.MANAGER_PASSWORD, ""));
            _managerButtonTrigged = true;

        }

        private void radCardViewMain_VisualItemFormatting(object sender, Telerik.WinControls.UI.ListViewVisualItemEventArgs e)
        {
            e.VisualItem.ClipDrawing = false;
            e.VisualItem.Padding = new Padding(5);
        }

        private void radCardViewMain_CardViewItemFormatting(object sender, Telerik.WinControls.UI.CardViewItemFormattingEventArgs e)
        {
            DataRowView dr = (DataRowView)e.VisualItem.Data.DataBoundItem;

            CardViewItem cardItem = e.Item as CardViewItem;

            if (cardItem != null)
            {
                LiveClientStatus lcs = ((LiveClientStatus)dr.Row["Column 1"]);

                switch (cardItem.FieldName)
                {
                    case "Column 0":

                        cardItem.EditorItem.DrawText = false;
                        Image image;
                        string status = "";
                        bool isOnline = false;

                        Utility.TranslateOnlineStatus(lcs.ClientStatus, out status, out isOnline);

                        if (((bool)dr.Row["Column 0"]) == true)
                        {
                            switch (lcs.Mode)
                            {
                                case "TIMING_ON":

                                    image = Resources.ComputerOnTiming.ScaleImage(100, 100);

                                    break;
                                case "NO_TIMING_ON":

                                    image = Resources.ComputerOnNonTiming.ScaleImage(100, 100);

                                    break;
                                default:

                                    if (status != "ERROR" && isOnline)
                                    {
                                        if (lcs.ClientStatus == Enums.LiveClientStatus.GAMEOVER_FOR_CLEANING)
                                        {
                                            image = Resources.ComputerCleaning.ScaleImage(100, 100);
                                        }
                                        else if (lcs.ClientStatus == Enums.LiveClientStatus.ONLINE)
                                        {
                                            image = Resources.ComputerOnError.ScaleImage(100, 100);
                                        }
                                        else
                                        {
                                            image = Resources.ComputerOnReady.ScaleImage(100, 100);
                                        }
                                    }
                                    else
                                    {
                                        image = Resources.ComputerOnError.ScaleImage(100, 100);
                                    }

                                    break;
                            }

                        }
                        else
                        {
                            image = Resources.ComputerOff.ScaleImage(100, 100);
                        }

                        cardItem.EditorItem.Image = image;
                        cardItem.EditorItem.ImageLayout = ImageLayout.Center;
                        cardItem.EditorItem.NotifyParentOnMouseInput = false;
                        cardItem.EditorItem.ShouldHandleMouseInput = false;
                        cardItem.Padding = new Padding(-5, -5, -5, 0);
                        return;

                    case "Column 1":
                        cardItem.Text = "Name";
                        cardItem.EditorItem.Text = lcs.ClientName;

                        break;
                    case "Column 2":
                        cardItem.Text = "Mode";

                        break;
                    case "Column 3":
                        cardItem.Text = "Status";
                        if (lcs.ClientStatus == Enums.LiveClientStatus.GAMEOVER_FOR_CLEANING)
                        {
                            cardItem.DrawFill = true;
                            cardItem.BackColor = Color.Lavender;
                            cardItem.BackColor2 = Color.MediumBlue;
                            cardItem.ForeColor = Color.White;
                        }
                        else
                        {
                            cardItem.DrawFill = false;
                            cardItem.ForeColor = Color.Black;
                        }
                        cardItem.BorderBoxStyle = BorderBoxStyle.SingleBorder;
                        cardItem.BorderGradientStyle = GradientStyles.Solid;
                        cardItem.BorderColor = Color.Blue;
                        cardItem.BorderWidth = 1;

                        break;
                    case "Column 4":
                        cardItem.Text = "Left / Pass";

                        break;
                    case "Column 5":
                        cardItem.Text = "Help Needed";
                        if (cardItem.EditorItem.Text == "Yes")
                        {
                            cardItem.DrawFill = true;
                            cardItem.BackColor = Color.Pink;
                            cardItem.BackColor2 = Color.Red;
                            cardItem.ForeColor = Color.White;
                        }
                        else
                        {
                            cardItem.DrawFill = false;
                            cardItem.ForeColor = Color.Black;
                        }
                        cardItem.BorderBoxStyle = BorderBoxStyle.SingleBorder;
                        cardItem.BorderGradientStyle = GradientStyles.Solid;
                        cardItem.BorderColor = Color.Red;
                        cardItem.BorderWidth = 1;

                        break;
                    default:
                        break;
                }


                System.Drawing.Font editorFont = new System.Drawing.Font(cardItem.Font.FontFamily, cardItem.Font.Size, FontStyle.Regular);

                cardItem.EditorItem.Font = editorFont;

            }
        }


        private void FlipAssistantRow()
        {
            try
            {
                IEnumerable<RadElement> raditem = radCardViewMain.CardViewElement.ViewElement.GetChildren(ChildrenListOptions.Normal).FirstOrDefault().GetChildren(ChildrenListOptions.Normal);

                foreach (RadElement re in raditem)
                {
                    CardListViewVisualItem clvvi = (CardListViewVisualItem)re;

                    List<RadElement> re2 = clvvi.CardContainer.GetChildren(ChildrenListOptions.Normal).ToList();

                    CardViewItem cvi = (CardViewItem)re2.Where(x => ((CardViewItem)x).FieldName == "Assist").FirstOrDefault();

                    LiveClientStatus lcs = (LiveClientStatus)clvvi.Data.Value;

                    if (cvi != null && lcs.IsAssistanceRequested)
                    {
                        cvi.DrawBorder = _flipStatus;
                    }

                }

                _flipStatus = !_flipStatus;
            }
            catch { }


        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            NetworkFunction.OnIncommingSystemConfig -= NetworkFunction_OnIncommingSystemConfig;
            NetworkFunction.OnIncommingLiveSystemInfo -= NetworkFunction_OnIncommingLiveSystemInfo;
            NetworkFunction.OnIncommingBarcodeInfo -= NetworkFunction_OnIncommingBarcodeInfo;
        }

        private void MainWindow_ResizeEnd(object sender, EventArgs e)
        {
            //NetworkFunction.GetLiveSystemInfo();
        }

        private void radCardViewMain_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        {

        }

        private void radCardViewMain_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            LiveClientStatus lcs = ((DataRowView)e.Item.DataBoundItem).Row["Column 1"] as LiveClientStatus;
            ClientInfo ci = new ClientInfo(lcs);
            ci.ShowDialog();
        }

        private void radButtonAbout_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void radButtonEmergency_Click(object sender, EventArgs e)
        {
            DialogResult dr = RadMessageBox.Show(this, string.Format("Are you sure you want to put system in emergency mode? All sessions will be FORCED TO EXIT!"), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

            if (dr == DialogResult.Yes)
            {
                List<ClientParm> clientParm = new List<ClientParm>();

                foreach (ListViewDataItem lv in radCardViewMain.Items)
                {
                    LiveClientStatus lcs = (LiveClientStatus)lv.Value;
                    Dictionary<string, string> dParm = new Dictionary<string, string>();


                    dParm.Add("EndMode", "Emergency");

                    clientParm.Add(new ClientParm(lcs.ClientID, dParm));
                }

                NetworkFunction.SendEndNow(clientParm);
            }
        }

        private void radButtonPrintBarcode_Click(object sender, EventArgs e)
        {
            NetworkFunction.GetSystemConfig(new SystemConfig(Enums.SysConfigType.MANAGER_PASSWORD, ""));
            _barcodeButtonTrigged = true;
        }

        private void radButtonWaiverProcess_Click(object sender, EventArgs e)
        {
            NetworkFunction.GetSystemConfig(new SystemConfig(Enums.SysConfigType.MANAGER_PASSWORD, ""));
            _waiverProceesButtonTrigged = true;
        }

        private void NetworkFunction_OnIncommingBarcodeInfo(object sender, EventArgs e)
        {
            BarcodeInfo bInfo = ((BarcodeInfoEvent)e).BarcodeInfo;

            Utility.DoPrintBarcode(bInfo.BarcodeItems);

            this.InvokeUI(() =>
            {
                this.ShowAlertBox("Barcode Generation", "Ticket is send to the printer.");
            });


        }

        private string[] GetRange(string range, Worksheet excelWorksheet)
        {
            Microsoft.Office.Interop.Excel.Range workingRangeCells =
              excelWorksheet.get_Range(range, Type.Missing);
            //workingRangeCells.Select();

            System.Array array = (System.Array)workingRangeCells.Cells.Value2;
            string[] arrayS = this.ConvertToStringArray(array);

            return arrayS;
        }

        string[] ConvertToStringArray(System.Array values)
        {
            string[] theArray = new string[values.Length];

            for (int i = 1; i <= values.Length; i++)
            {
                if (values.GetValue(1, i) == null)
                    theArray[i - 1] = "";
                else
                    theArray[i - 1] = (
                    string)values.GetValue(1, i).ToString();
            }

            return theArray;
        }

    }
}
