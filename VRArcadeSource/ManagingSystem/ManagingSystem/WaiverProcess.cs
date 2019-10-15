using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using VRGameSelectorServerDTO;

namespace ManagingSystem
{
    public partial class WaiverProcess : Telerik.WinControls.UI.RadForm
    {
        DataTable _dtClientList = new DataTable();
        private System.Timers.Timer _timerListRefresher;
        int _sessionLength = 50;

        public WaiverProcess()
        {
            InitializeComponent();

            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

        }

        private void InitData()
        {
            NetworkFunction.OnIncommingSystemConfig += NetworkFunction_OnIncommingSystemConfig;
            NetworkFunction.OnIncommingWaiverInfoList += NetworkFunction_OnIncommingWaiverInfoList;
            NetworkFunction.OnIncommingBookingReference += NetworkFunction_OnIncommingBookingReference;

            radListViewClientList.ShowCheckBoxes = true;
            radListViewClientList.ItemSpacing = 1;
            radListViewClientList.AllowEdit = false;
            radListViewClientList.AllowColumnReorder = false;
            radListViewClientList.AllowRemove = false;
            radListViewClientList.HotTracking = false;
            radListViewClientList.ItemSize = new Size(0, 40);

            _dtClientList.Columns.Add("Time", typeof(string));
            _dtClientList.Columns.Add("ClientName", typeof(string));
            _dtClientList.Columns.Add("Age", typeof(int));
            _dtClientList.Columns.Add("Reference", typeof(string));
            _dtClientList.Columns.Add("Operation", typeof(string));
            _dtClientList.Columns.Add("SessionStartTime", typeof(string));
            _dtClientList.Columns.Add("Data", typeof(ClientActionType));
            _dtClientList.Columns.Add("ID", typeof(int));
            _dtClientList.Columns.Add("UPD_REQ", typeof(bool));
            _dtClientList.RowChanged += _dtClientList_RowChanged;

            radListViewClientList.DataSource = _dtClientList;

        }





        private void OntimerListRefresher(object sender, ElapsedEventArgs e)
        {
            NetworkFunction.GetPendingWaiver();
        }

        private void NetworkFunction_OnIncommingBookingReference(object sender, EventArgs e)
        {
            BookingReference br = ((BookingReferenceEvent)e).BookingReference;

            this.InvokeUI(() =>
            {
                DataRow[] dr = _dtClientList.Select("ID = " + br.ID);

                dr[0]["UPD_REQ"] = false;

                if (br.Reference.Length > 0 && br.NumberOfBookingLeft > 0)
                {
                    DataRow[] dr2 = _dtClientList.Select("Reference = '" + br.Reference + "'");

                    if (dr2.Length <= br.NumberOfBookingLeft)
                    {
                        if (br.IsNonTimedTiming)
                        {
                            ((ClientActionType)dr[0]["Data"]).StartType = ClientActionType.ClientStartType.NON_TIMED_START;
                        }
                        else if (br.IsTimedTiming)
                        {
                            ((ClientActionType)dr[0]["Data"]).StartType = ClientActionType.ClientStartType.TIMED_START;
                            ((ClientActionType)dr[0]["Data"]).Duration = br.Duration;
                        }
                        dr[0]["SessionStartTime"] = br.BookingStartTime.ToString("G");
                    }
                    else
                    {
                        br.Reference = "";
                        ((ClientActionType)dr[0]["Data"]).StartType = ClientActionType.ClientStartType.NONE;
                        dr[0]["SessionStartTime"] = "";
                        this.ShowAlertBox("Waiver Process", "Over Booking Limit!");
                    }
                }
                else
                {
                    br.Reference = "";
                    ((ClientActionType)dr[0]["Data"]).StartType = ClientActionType.ClientStartType.NONE;
                    dr[0]["SessionStartTime"] = "";
                    this.ShowAlertBox("Waiver Process", "Invalid Reference Number!");
                }

                dr[0]["Reference"] = br.Reference;

            });
        }

        private void _dtClientList_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if ((bool)e.Row["UPD_REQ"] == true)
            {
                BookingReference br = new BookingReference()
                {
                    ID = (int)e.Row["ID"],
                    Reference = (string)e.Row["Reference"],
                    Duration = _sessionLength
                };

                NetworkFunction.GetBookingReferenceSetting(br);
            }


        }

        private void NetworkFunction_OnIncommingWaiverInfoList(object sender, EventArgs e)
        {
            List<WaiverInfo> lwi = ((WaiverInfoEvent)e).ListWaiverInfo;
            List<WaiverInfo> updateWaivers = new List<WaiverInfo>();

            this.InvokeUI(() =>
            {
                // determin if update is needed
                if (lwi != null)
                {
                    foreach (WaiverInfo wi in lwi)
                    {
                        if (_dtClientList.Select("ID = " + wi.ID).Length == 0)
                        {
                            updateWaivers.Add(wi);
                        }

                    }
                }

                // update
                if (updateWaivers.Count > 0)
                {
                    _dtClientList.BeginLoadData();
                    foreach (WaiverInfo wi in updateWaivers)
                    {
                        string cName = wi.FirstName + " " + wi.LastName;
                        int age = Math.Abs((int)Math.Floor(DateTime.Now.Subtract(wi.DOB).TotalDays / 365));
                        string reference = "";

                        ClientActionType cat = new ClientActionType(ClientActionType.ClientStartType.NONE, _sessionLength);

                        if (wi.BookingReference != null)
                        {
                            reference = wi.BookingReference.Reference;

                            if (wi.BookingReference.IsTimedTiming)
                            {
                                cat.StartType = ClientActionType.ClientStartType.TIMED_START;
                                cat.Duration = wi.BookingReference.Duration;
                            }
                            else if (wi.BookingReference.IsNonTimedTiming)
                            {
                                cat.StartType = ClientActionType.ClientStartType.NON_TIMED_START;
                            }
                        }

                        _dtClientList.Rows.Add(wi.TimeCreated.ToString("G"), cName, age, reference, "", (wi.BookingReference != null) ? wi.BookingReference.BookingStartTime.ToString("G") : "", cat, wi.ID, false);
                    }
                    _dtClientList.AcceptChanges();
                    _dtClientList.EndLoadData();
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
                    case Enums.SysConfigType.DEFAULT_TIMED_SESSION_LENGTH:

                        int.TryParse(sc.Value, out _sessionLength);

                        break;
                }
            }
        }




        private void ManagerFeatures_FormClosed(object sender, FormClosedEventArgs e)
        {
            NetworkFunction.OnIncommingSystemConfig -= NetworkFunction_OnIncommingSystemConfig;
            NetworkFunction.OnIncommingWaiverInfoList -= NetworkFunction_OnIncommingWaiverInfoList;
            NetworkFunction.OnIncommingBookingReference -= NetworkFunction_OnIncommingBookingReference;

        }

        private void ManagerFeatures_Load(object sender, EventArgs e)
        {
            InitData();

            NetworkFunction.GetSystemConfig(new SystemConfig(Enums.SysConfigType.DEFAULT_TIMED_SESSION_LENGTH));

            NetworkFunction.GetPendingWaiver();

            _timerListRefresher = new System.Timers.Timer();
            _timerListRefresher.Elapsed += new ElapsedEventHandler(OntimerListRefresher);
            _timerListRefresher.Interval = 4000;
            _timerListRefresher.Enabled = true;

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



        private void radButtonPrintTicket_Click(object sender, EventArgs e)
        {
            DialogResult dr = DialogResult.None;

            if (radListViewClientList.CheckedItems.Count > 0)
            {
                if (OptionSelectedValidate())
                {

                    if (!OptionTimeValidate())
                    {
                        dr = RadMessageBox.Show(this, string.Format("One or more check-ins failed appointment time validation. Is the customer late or too early (e.g. Earlier than 60 minutes to game start)? " + Environment.NewLine + Environment.NewLine + " Do you want to override this error?", radListViewClientList.CheckedItems.Count), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                    }

                    if (dr == DialogResult.None || dr == DialogResult.Yes)
                    {

                        dr = RadMessageBox.Show(this, string.Format("Are you sure you want to print ({0}) tickets?", radListViewClientList.CheckedItems.Count), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                        if (dr == DialogResult.Yes)
                        {
                            BarcodeInfo bInfo = new BarcodeInfo();
                            //List<WaiverInfo> listWaiverInfo = new List<WaiverInfo>();

                            foreach (ListViewDataItem item in radListViewClientList.CheckedItems)
                            {
                                ClientActionType cat = ((DataRowView)item.DataBoundItem)["Data"] as ClientActionType;

                                string clientName = ((DataRowView)item.DataBoundItem)["ClientName"].ToString();

                                BarcodeItem bItem = new BarcodeItem()
                                {
                                    IsPrintingTicket = true,
                                    Minutes = (cat.StartType == ClientActionType.ClientStartType.TIMED_START ? cat.Duration : 0),
                                    CustomerName = clientName,
                                    BookingReference = (string)((DataRowView)item.DataBoundItem)["Reference"],
                                    WaiverLogID = (int)((DataRowView)item.DataBoundItem)["ID"]
                                };

                                bInfo.BarcodeItems.Add(bItem);

                                /*listWaiverInfo.Add(new WaiverInfo()
                                {
                                    ID = (int)((DataRowView)item.DataBoundItem)["ID"],
                                    BookingReference = new BookingReference()
                                    {
                                        Reference = (string)((DataRowView)item.DataBoundItem)["Reference"]
                                    }

                                });*/
                            }

                            //NetworkFunction.MarkWaiverReceived(listWaiverInfo);

                            NetworkFunction.GenerateBarcode(bInfo);

                            Close();
                        }
                    }

                }
                else
                {
                    this.ShowAlertBox("Waiver Process", "One or more selected item does not have option picked! Booking reference not found!");
                }
            }
            else
            {
                this.ShowAlertBox("Waiver Process", "Please select at least one client to continue!");
            }
        }

        private void radButtonDeleteWaiver_Click(object sender, EventArgs e)
        {
            if (radListViewClientList.CheckedItems.Count > 0)
            {
                DialogResult dr = RadMessageBox.Show(this, string.Format("Are you sure you want to archive ({0}) pending waiver? (Normally this is done for friends of the participant)", radListViewClientList.CheckedItems.Count), "Confirm", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    List<WaiverInfo> listWaiverInfo = new List<WaiverInfo>();

                    foreach (ListViewDataItem item in radListViewClientList.CheckedItems)
                    {
                        DataRowView drv = (DataRowView)item.DataBoundItem;

                        listWaiverInfo.Add(new WaiverInfo() { ID = (int)drv["ID"] });

                    }

                    NetworkFunction.DeletePendingWaiver(listWaiverInfo);
                    this.Close();
                }

            }
            else
            {
                this.ShowAlertBox("Waiver Process", "Please select at least one client to continue!");
            }

        }

        private bool OptionSelectedValidate()
        {
            foreach (ListViewDataItem item in radListViewClientList.CheckedItems)
            {
                if (((ClientActionType)((DataRowView)item.DataBoundItem).Row["Data"]).StartType == ClientActionType.ClientStartType.NONE)
                {
                    return false;
                }
            }

            return true;
        }

        private bool OptionTimeValidate()
        {
            foreach (ListViewDataItem item in radListViewClientList.CheckedItems)
            {
                DateTime dsStartTime = DateTime.MinValue;

                string ssStartTime = ((DataRowView)item.DataBoundItem).Row["SessionStartTime"].ToString();

                DateTime.TryParse(ssStartTime, out dsStartTime);

                if (dsStartTime != DateTime.MinValue && (DateTime.Now.Subtract(dsStartTime).TotalMinutes < -60 || DateTime.Now.Subtract(dsStartTime).TotalMinutes > 0))
                {
                    return false;
                }
            }

            return true;
        }

        private void radListViewClientList_CellCreating(object sender, ListViewCellElementCreatingEventArgs e)
        {

            DetailListViewDataCellElement cell = e.CellElement as DetailListViewDataCellElement;
            if (cell != null && cell.Data.Name == "Operation")
            {
                e.CellElement = new CustomWaiverProcessListViewCellElementProcess(cell.RowElement, e.CellElement.Data);
            }
            else if (cell != null && cell.Data.Name == "Reference")
            {
                e.CellElement = new CustomWaiverProcessListViewCellElementReference(cell.RowElement, e.CellElement.Data);
            }


        }

        private void radListViewClientList_ColumnCreating(object sender, ListViewColumnCreatingEventArgs e)
        {
            if (e.Column.FieldName == "Time")
            {
                e.Column.HeaderText = "Time";
                e.Column.Width = 120;
                e.Column.Visible = true;
            }
            if (e.Column.FieldName == "ClientName")
            {
                e.Column.HeaderText = "Client Name";
                e.Column.Width = 200;
                e.Column.Visible = true;
            }
            if (e.Column.FieldName == "Age")
            {
                e.Column.HeaderText = "Age";
                e.Column.Width = 50;
                e.Column.Visible = true;
            }
            if (e.Column.FieldName == "Reference")
            {
                e.Column.HeaderText = "Reference";
                e.Column.Width = 120;
                e.Column.Visible = true;
            }
            if (e.Column.FieldName == "Operation")
            {
                e.Column.HeaderText = "Operation";
                e.Column.Width = 300;
                e.Column.Visible = true;
            }
            if (e.Column.FieldName == "SessionStartTime")
            {
                e.Column.HeaderText = "Session Start Time";
                e.Column.Width = 120;
                e.Column.Visible = true;
            }
            if (e.Column.FieldName == "Data")
            {
                e.Column.HeaderText = "";
                e.Column.Visible = false;
            }
            if (e.Column.FieldName == "ID")
            {
                e.Column.HeaderText = "";
                e.Column.Visible = false;
            }
            if (e.Column.FieldName == "UPD_REQ")
            {
                e.Column.HeaderText = "";
                e.Column.Visible = false;
            }
        }

        private void radListViewClientList_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
        {
            e.VisualItem.DrawFill = false;
            e.VisualItem.ForeColor = Color.Black;
            e.VisualItem.DrawBorder = false;
        }

        private void radListViewClientList_CellFormatting(object sender, ListViewCellFormattingEventArgs e)
        {
            if ((e.CellElement).Data.HeaderText == "Time")
            {
                if ((e.CellElement is DetailListViewDataCellElement))
                {
                    e.CellElement.TextAlignment = ContentAlignment.MiddleCenter;
                }
            }
            if ((e.CellElement).Data.HeaderText == "Operation")
            {
                if ((e.CellElement is DetailListViewDataCellElement))
                {
                    e.CellElement.TextAlignment = ContentAlignment.MiddleCenter;

                    DetailListViewDataCellElement dCellElm = e.CellElement as DetailListViewDataCellElement;
                    if (((ClientActionType)((DataRowView)dCellElm.Row.DataBoundItem).Row["Data"]).StartType == ClientActionType.ClientStartType.NONE)
                    {
                        e.CellElement.DrawFill = true;
                        e.CellElement.BackColor = Color.Coral;
                        e.CellElement.BackColor2 = Color.Coral;
                    }
                    else
                    {
                        e.CellElement.DrawFill = false;
                    }

                }
            }
            if ((e.CellElement).Data.HeaderText == "Client Name")
            {
                if ((e.CellElement is DetailListViewDataCellElement))
                {
                    e.CellElement.TextAlignment = ContentAlignment.MiddleCenter;
                }
            }
            if ((e.CellElement).Data.HeaderText == "Age")
            {
                if ((e.CellElement is DetailListViewDataCellElement))
                {
                    e.CellElement.TextAlignment = ContentAlignment.MiddleCenter;
                }
            }
            if ((e.CellElement).Data.HeaderText == "Session Start Time")
            {
                if ((e.CellElement is DetailListViewDataCellElement))
                {
                    e.CellElement.TextAlignment = ContentAlignment.MiddleCenter;

                    DateTime dsStartTime = DateTime.MinValue;
                    DetailListViewDataCellElement dCellElm = e.CellElement as DetailListViewDataCellElement;
                    string ssStartTime = ((DataRowView)dCellElm.Row.DataBoundItem).Row["SessionStartTime"].ToString();

                    DateTime.TryParse(ssStartTime, out dsStartTime);

                    if (dsStartTime != DateTime.MinValue && DateTime.Now.Subtract(dsStartTime).TotalMinutes < -60)
                    {
                        e.CellElement.DrawFill = true;
                        e.CellElement.BackColor = Color.Coral;
                        e.CellElement.BackColor2 = Color.Coral;
                    }
                    else if (dsStartTime != DateTime.MinValue && DateTime.Now.Subtract(dsStartTime).TotalMinutes > 0)
                    {
                        e.CellElement.DrawFill = true;
                        e.CellElement.BackColor = Color.Red;
                        e.CellElement.BackColor2 = Color.Red;
                    }
                    else
                    {
                        e.CellElement.DrawFill = false;
                    }
                }
            }
        }

        private void radListViewClientList_ItemMouseClick(object sender, ListViewItemEventArgs e)
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

        private void radButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WaiverProcess_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timerListRefresher.Enabled = false;
        }
    }

    public class ClientActionType
    {
        public ClientActionType()
        {
            StartType = ClientStartType.NONE;
            Duration = 1;
        }

        public ClientActionType(ClientStartType actionType, int duration)
        {
            StartType = actionType;
            Duration = duration;
        }

        public ClientStartType StartType { get; set; }

        public int Duration { get; set; }


        public enum ClientStartType
        {
            NONE,
            NON_TIMED_START,
            TIMED_START
        }

    }
}
