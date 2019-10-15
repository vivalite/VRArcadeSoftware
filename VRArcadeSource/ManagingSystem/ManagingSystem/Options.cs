using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using VRGameSelectorServerDTO;

namespace ManagingSystem
{
    public partial class Options : Telerik.WinControls.UI.RadForm
    {
        List<TileConfig> _lTileConfig;
        GridViewRowInfo _currentSelectedRow;
        TileConfig _tileConfigClipBoard;

        public Options()
        {
            InitializeComponent();


            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void InitData()
        {
            NetworkFunction.OnIncommingSystemConfig += NetworkFunction_OnIncommingSystemConfig;
            NetworkFunction.OnIncommingConfigSetList += NetworkFunction_OnIncommingConfigSetList;
            NetworkFunction.OnIncommingTileConfigList += NetworkFunction_OnIncommingTileConfigList;
            NetworkFunction.OnIncommingConfigerClientList += NetworkFunction_OnIncommingConfigerClientList;
            NetworkFunction.OnIncommingKeyInfoList += NetworkFunction_OnIncommingKeyInfoList;


            radGridViewTileConfig.Relations.AddSelfReference(radGridViewTileConfig.MasterTemplate, "ID", "TileconfigID");
            radGridViewTileConfig.AllowAddNewRow = false;
            radGridViewTileConfig.ReadOnly = true;
            radGridViewTileConfig.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            radGridViewTileConfig.ShowGroupPanel = false;
            radGridViewTileConfig.TableElement.ShowSelfReferenceLines = true;
            radGridViewTileConfig.AllowCellContextMenu = false;
            radGridViewTileConfig.MultiSelect = false;
            radGridViewTileConfig.AllowRowResize = false;
            radGridViewTileConfig.ShowRowHeaderColumn = false;


            radGridViewTileConfig.DataSource = new List<TileConfig>();
            radGridViewTileConfig.Columns["ID"].IsVisible = false;
            radGridViewTileConfig.Columns["TileGUID"].IsVisible = false;
            radGridViewTileConfig.Columns["TileDesc"].IsVisible = false;
            radGridViewTileConfig.Columns["TileImage"].IsVisible = false;
            radGridViewTileConfig.Columns["Command"].IsVisible = false;
            radGridViewTileConfig.Columns["Arguments"].IsVisible = false;
            radGridViewTileConfig.Columns["WorkingPath"].IsVisible = false;
            radGridViewTileConfig.Columns["TileConfigSetID"].IsVisible = false;
            radGridViewTileConfig.Columns["TileconfigID"].IsVisible = false;
            radGridViewTileConfig.Columns["ChildTiles"].IsVisible = false;
            radGridViewTileConfig.Columns["Order"].IsVisible = false;
            radGridViewTileConfig.Columns["VideoURL"].IsVisible = false;
            radGridViewTileConfig.Columns["AgeRequire"].IsVisible = false;
            radGridViewTileConfig.Columns["TileTitle"].HeaderText = "Title";
            radGridViewTileConfig.Columns["TileHeight"].HeaderText = "Height";
            radGridViewTileConfig.Columns["TileWidth"].HeaderText = "Width";
            radGridViewTileConfig.Columns["TileRowNumber"].HeaderText = "Row Number";
            radGridViewTileConfig.Columns["TileTitle"].Width = 200;
            radGridViewTileConfig.Columns["TileHeight"].TextAlignment = ContentAlignment.MiddleCenter;
            radGridViewTileConfig.Columns["TileWidth"].TextAlignment = ContentAlignment.MiddleCenter;
            radGridViewTileConfig.Columns["TileRowNumber"].TextAlignment = ContentAlignment.MiddleCenter;

            listViewClient.Columns[0].Width = 140;
            listViewClient.Columns[1].Width = 230;
            listViewClient.Columns[2].Width = 230;
        }


        private void Options_FormClosed(object sender, FormClosedEventArgs e)
        {
            NetworkFunction.OnIncommingSystemConfig -= NetworkFunction_OnIncommingSystemConfig;
            NetworkFunction.OnIncommingConfigSetList -= NetworkFunction_OnIncommingConfigSetList;
            NetworkFunction.OnIncommingTileConfigList -= NetworkFunction_OnIncommingTileConfigList;
            NetworkFunction.OnIncommingConfigerClientList -= NetworkFunction_OnIncommingConfigerClientList;
            NetworkFunction.OnIncommingKeyInfoList -= NetworkFunction_OnIncommingKeyInfoList;
        }

        private void NetworkFunction_OnIncommingSystemConfig(object sender, EventArgs e)
        {
            List<SystemConfig> lsc = ((SystemConfigEvent)e).SystemConfig;

            foreach (SystemConfig sc in lsc)
            {
                switch (sc.Type)
                {
                    case Enums.SysConfigType.NONE:
                        break;
                    case Enums.SysConfigType.TIMES_UP_MESSAGE:

                        this.InvokeUI(() =>
                        {
                            radTextBoxTimeUpMessage.Text = sc.Value;
                        });

                        break;
                    case Enums.SysConfigType.MANUAL_END_MESSAGE:

                        this.InvokeUI(() =>
                        {
                            radTextBoxEndGameMessage.Text = sc.Value;
                        });

                        break;
                    case Enums.SysConfigType.EMERGENCY_MESSAGE:

                        this.InvokeUI(() =>
                        {
                            radTextBoxEmergencyMessage.Text = sc.Value;
                        });

                        break;
                    case Enums.SysConfigType.DEFAULT_TIMED_SESSION_LENGTH:

                        this.InvokeUI(() =>
                        {
                            int sessionLength = 50;

                            int.TryParse(sc.Value, out sessionLength);

                            radSpinEditorTimedSessionLength.Value = sessionLength == 0 ? 50 : sessionLength;
                        });

                        break;
                    case Enums.SysConfigType.DISABLE_KMU_BY_DEFAULT:

                        this.InvokeUI(() =>
                        {
                            bool dkbd = false;
                            bool.TryParse(sc.Value, out dkbd);

                            radCheckBoxUSBOffByDefault.Checked = dkbd;

                        });

                        break;
                    case Enums.SysConfigType.RE_DISABLE_KMU_AFTER_20_MIN:

                        this.InvokeUI(() =>
                        {
                            bool reka2m = false;
                            bool.TryParse(sc.Value, out reka2m);

                            radCheckBoxUSBAutoReEnable.Checked = reka2m;

                        });

                        break;
                    case Enums.SysConfigType.LCD_BARCODE_MODULE:

                        this.InvokeUI(() =>
                        {
                            bool lbm = false;
                            bool.TryParse(sc.Value, out lbm);

                            radCheckBoxEnableBarcodeLCDModule.Checked = lbm;

                        });

                        break;
                    default:
                        break;
                }
            }

        }

        private void NetworkFunction_OnIncommingTileConfigList(object sender, EventArgs e)
        {
            List<TileConfig> ltc = ((TileConfigEvent)e).ListTileConfigs;
            _lTileConfig = ltc;

            this.InvokeUI(() =>
            {
                panelTileConfig.Enabled = true;
                radGridViewTileConfig.BeginUpdate();

                radGridViewTileConfig.DataSource = new List<TileConfig>();

                if (ltc != null)
                {

                    radGridViewTileConfig.AutoGenerateColumns = true;
                    radGridViewTileConfig.DataSource = ltc;

                    radGridViewTileConfig.MasterTemplate.SortDescriptors.Clear();
                    radGridViewTileConfig.MasterTemplate.SortDescriptors.Add(new SortDescriptor("Order", ListSortDirection.Ascending));

                    radGridViewTileConfig.EndUpdate();

                    radGridViewTileConfig.MasterTemplate.ExpandAll();

                    if (_currentSelectedRow != null)
                    {
                        GridViewRowInfo gvri = radGridViewTileConfig.Rows.Where(x => ((TileConfig)x.DataBoundItem).ID == ((TileConfig)_currentSelectedRow.DataBoundItem).ID).FirstOrDefault();

                        if (gvri != null)
                        {
                            gvri.IsCurrent = true;
                            gvri.IsSelected = true;
                        }
                        else
                        {
                            _currentSelectedRow = null;
                            radGridViewTileConfig.CurrentRow = null;
                        }

                    }

                    radButtonConfigModify.Enabled = true;
                    buttonConfigDelete.Enabled = false;

                }
                else
                {
                    radButtonConfigModify.Enabled = false;
                    buttonConfigDelete.Enabled = true;
                    radGridViewTileConfig.EndUpdate();

                }
            });
        }

        private void NetworkFunction_OnIncommingConfigSetList(object sender, EventArgs e)
        {

            this.InvokeUI(() =>
            {
                comboBoxTileConfig.Items.Clear();
                panelTileConfig.Enabled = false;
                buttonConfigDelete.Enabled = false;

                radGridViewTileConfig.DataSource = new List<TileConfig>();
                EnableRadPageViews();
            });

            List<ConfigSet> lConfigSet = ((ConfigSetEvent)e).ListConfigSets;

            if (lConfigSet != null)
            {

                foreach (ConfigSet cs in lConfigSet)
                {
                    this.InvokeUI(() =>
                    {
                        comboBoxTileConfig.Items.Add(new RadListDataItem(cs.Name, cs.ID));
                    });
                }

            }

        }

        private void NetworkFunction_OnIncommingConfigerClientList(object sender, EventArgs e)
        {
            this.InvokeUI(() =>
            {
                listViewClient.BeginUpdate();
                listViewClient.Items.Clear();

                List<Client> lClients = ((ClientEvent)e).ListClients;

                if (lClients != null)
                {

                    foreach (var client in lClients)
                    {
                        ListViewItem lvi = new ListViewItem(new string[] { client.IPAddress, client.MachineName, client.TileConfigSetName });
                        lvi.Name = client.ClientID.ToString();
                        lvi.Tag = client;
                        listViewClient.Items.Add(lvi);

                    }

                }

                listViewClient.EndUpdate();

                EnableRadPageViews();
            });
        }

        private void NetworkFunction_OnIncommingKeyInfoList(object sender, EventArgs e)
        {
            this.InvokeUI(() =>
            {
                listViewKeyGen.BeginUpdate();
                listViewKeyGen.Items.Clear();

                List<KeyInfo> lKeyInfo = ((KeyInfoEvent)e).ListKeyInfo;

                if (lKeyInfo != null)
                {

                    foreach (KeyInfo keyInfo in lKeyInfo)
                    {
                        ListViewItem lvi = new ListViewItem(new string[] { keyInfo.Key, keyInfo.KeyTypeName, keyInfo.CreateDate.ToString("g") });
                        lvi.Name = keyInfo.Key;
                        lvi.Tag = keyInfo.Key;
                        listViewKeyGen.Items.Add(lvi);
                    }

                }

                listViewKeyGen.EndUpdate();

                EnableRadPageViews();


            });

        }


        private void buttonConfigNew_Click(object sender, EventArgs e)
        {
            string sConfigSetName = "";
            this.InputBox("Create New Config Set", "Please enter the name of the new config set:", ref sConfigSetName);

            if (sConfigSetName.Length > 0)
            {
                ConfigSet cs = new ConfigSet(0, sConfigSetName);
                NetworkFunction.AddConfigSet(cs);
            }

        }

        private void buttonConfigDelete_Click(object sender, EventArgs e)
        {
            RadListDataItem ldi = comboBoxTileConfig.SelectedItem;

            if (ldi != null)
            {
                ConfigSet cs = new ConfigSet((int)ldi.Value, "");
                NetworkFunction.DeleteConfigSet(cs);
            }
        }

        private void radButtonConfigModify_Click(object sender, EventArgs e)
        {
            RadListDataItem ldi = comboBoxTileConfig.SelectedItem;

            if (ldi != null)
            {
                string sConfigSetName = ldi.Text;
                this.InputBox("Modify Config Set", "Please enter the new name of the config set:", ref sConfigSetName);

                ConfigSet cs = new ConfigSet((int)ldi.Value, sConfigSetName);
                NetworkFunction.ModifyConfigSet(cs);
            }
        }


        private void comboBoxTileConfig_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            RadDropDownList ddl = (RadDropDownList)sender;

            if (ddl.SelectedItem != null)
            {
                NetworkFunction.GetTileConfig((int)ddl.SelectedItem.Value);
                buttonConfigDelete.Enabled = false;
            }
            else
            {
                radButtonConfigModify.Enabled = false;
            }


        }

        private void radGridViewTileConfig_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Row is GridViewDataRowInfo)
            {
                e.CellElement.DrawBorder = false;

                GridDataCellElement cell = e.CellElement as GridDataCellElement;
                if (cell != null && cell.SelfReferenceLayout != null)
                {
                    foreach (RadElement element in cell.SelfReferenceLayout.StackLayoutElement.Children)
                    {
                        GridLinkItem linkItem = element as GridLinkItem;
                        if (linkItem != null)
                        {
                            linkItem.LineStyle = DashStyle.Dot;
                            linkItem.ForeColor = Color.Black;
                        }
                        GridExpanderItem expanderItem = element as GridExpanderItem;
                        if (expanderItem != null)
                        {
                            expanderItem.LinkLineStyle = DashStyle.Dot;
                            expanderItem.LinkLineColor = Color.Black;
                        }
                    }
                }
            }
        }

        private void radGridViewTileConfig_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.IsCurrent)
            {
                e.CellElement.DrawFill = false;
                e.CellElement.DrawBorder = false;
            }
            else
            {
                e.CellElement.ResetValue(LightVisualElement.DrawBorderProperty, Telerik.WinControls.ValueResetFlags.Local);
                e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, Telerik.WinControls.ValueResetFlags.Local);
            }
        }


        private void radButtonAddTile_Click(object sender, EventArgs e)
        {
            int lastOrder = 0;
            List<TileConfig> lTileConfig = _lTileConfig != null ? _lTileConfig : new List<TileConfig>();

            foreach (TileConfig tc in lTileConfig)
            {
                if (tc.TileconfigID == 0 && tc.Order > lastOrder)
                {
                    lastOrder = tc.Order;
                }
            }

            System.Diagnostics.Debug.WriteLine("lastOrder: {0}", lastOrder);

            SetCurrentSelectionIndex();

            TileDetails td = new TileDetails(0, lastOrder + 1, (int)comboBoxTileConfig.SelectedItem.Value);
            td.ShowDialog();

        }

        private void radButtonAddSubTile_Click(object sender, EventArgs e)
        {
            int parentTileConfigID = 0;
            int lastOrder = 0;
            List<TileConfig> lTileConfig = _lTileConfig != null ? _lTileConfig : new List<TileConfig>();

            if (this.radGridViewTileConfig.CurrentRow is GridViewDataRowInfo)
            {
                TileConfig targetTileConfig = (TileConfig)radGridViewTileConfig.CurrentRow.DataBoundItem;

                if (targetTileConfig.TileconfigID == 0)
                {
                    parentTileConfigID = targetTileConfig.ID; // selected tile will be the parent
                }
                else
                {
                    parentTileConfigID = targetTileConfig.TileconfigID; // set the parent tile
                }

            }


            foreach (TileConfig tc in lTileConfig)
            {
                if (tc.TileconfigID == parentTileConfigID && tc.Order > lastOrder)
                {
                    lastOrder = tc.Order;
                }

            }

            System.Diagnostics.Debug.WriteLine("parentTileConfigID: {0}  lastOrder: {1}", parentTileConfigID, lastOrder);

            SetCurrentSelectionIndex();

            TileDetails td = new TileDetails(parentTileConfigID, lastOrder + 1, (int)comboBoxTileConfig.SelectedItem.Value);
            td.ShowDialog();
        }

        private void radButtonDelete_Click(object sender, EventArgs e)
        {
            List<TileConfig> lTileConfig = _lTileConfig != null ? _lTileConfig : new List<TileConfig>();

            if (this.radGridViewTileConfig.CurrentRow is GridViewDataRowInfo)
            {
                TileConfig targetTileConfig = (TileConfig)radGridViewTileConfig.CurrentRow.DataBoundItem;

                if (lTileConfig.Count(x => x.TileconfigID == targetTileConfig.ID) > 0)
                {
                    System.Diagnostics.Debug.WriteLine("Cannot delete ID: {0}, since sub tiles exist", targetTileConfig.ID);

                    this.ShowAlertBox("Options", "Sub tiles exist under parent tile, cannot delete parent tile!");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Delete ID: {0}", targetTileConfig.ID);
                    DialogResult dr = RadMessageBox.Show(this, "Are you sure delete the tile? This operation cannot be undone!", "Delete Tile", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        SetCurrentSelectionIndex();
                        NetworkFunction.DeleteTileConfig(targetTileConfig);
                    }
                }



            }
        }

        private void radGridViewTileConfig_DoubleClick(object sender, EventArgs e)
        {
            if (this.radGridViewTileConfig.CurrentRow is GridViewDataRowInfo)
            {
                TileConfig targetTileConfig = (TileConfig)radGridViewTileConfig.CurrentRow.DataBoundItem;

                SetCurrentSelectionIndex();

                TileDetails td = new TileDetails(targetTileConfig);
                td.ShowDialog();
            }
        }

        private void radButtonModify_Click(object sender, EventArgs e)
        {
            radGridViewTileConfig_DoubleClick(sender, e);
        }


        private void SetCurrentSelectionIndex()
        {
            if (this.radGridViewTileConfig.CurrentRow is GridViewDataRowInfo)
            {
                _currentSelectedRow = radGridViewTileConfig.CurrentRow;
            }
        }

        private void buttonTileConfigUp_Click(object sender, EventArgs e)
        {
            if (this.radGridViewTileConfig.CurrentRow is GridViewDataRowInfo)
            {
                TileConfig targetTileConfig = (TileConfig)radGridViewTileConfig.CurrentRow.DataBoundItem;

                SetCurrentSelectionIndex();

                NetworkFunction.ReOrderUpTileConfig(targetTileConfig);
            }
        }

        private void buttonTileConfigDown_Click(object sender, EventArgs e)
        {
            if (this.radGridViewTileConfig.CurrentRow is GridViewDataRowInfo)
            {
                TileConfig targetTileConfig = (TileConfig)radGridViewTileConfig.CurrentRow.DataBoundItem;

                SetCurrentSelectionIndex();

                NetworkFunction.ReOrderDownTileConfig(targetTileConfig);
            }
        }



        private void buttonModifyClient_Click(object sender, EventArgs e)
        {
            if (listViewClient.SelectedItems.Count == 1)
            {
                ClientDetail cd = new ClientDetail((Client)listViewClient.SelectedItems[0].Tag);
                cd.ShowDialog();
            }
        }

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            ClientDetail cd = new ClientDetail();
            cd.ShowDialog();
        }

        private void buttonDeleteClient_Click(object sender, EventArgs e)
        {
            if (listViewClient.SelectedItems.Count == 1)
            {
                Client c = new Client();
                int cid = 0;

                Int32.TryParse(listViewClient.SelectedItems[0].Name, out cid);
                c.ClientID = cid;

                NetworkFunction.DeleteClientConfig(c);
            }
        }

        private void listViewClient_DoubleClick(object sender, EventArgs e)
        {
            buttonModifyClient_Click(sender, e);
        }

        private void radPageViewOptions_SelectedPageChanging(object sender, RadPageViewCancelEventArgs e)
        {

            switch (e.Page.Text)
            {
                case "Settings":

                    GetSettingPageConfig();

                    break;

                case "Client Configuration":

                    DisableRadPageViews();
                    NetworkFunction.GetClientConfig();

                    break;

                case "Tile Configuration":

                    DisableRadPageViews();
                    NetworkFunction.GetConfigSet();

                    break;
                case "Key Generation":

                    DisableRadPageViews();
                    NetworkFunction.GetKey();

                    break;

                default:
                    break;
            }
        }

        private void GetSettingPageConfig()
        {
            List<SystemConfig> lsc = new List<SystemConfig>() {
                new SystemConfig(Enums.SysConfigType.TIMES_UP_MESSAGE),
                new SystemConfig(Enums.SysConfigType.MANUAL_END_MESSAGE),
                new SystemConfig(Enums.SysConfigType.EMERGENCY_MESSAGE),
                new SystemConfig(Enums.SysConfigType.DEFAULT_TIMED_SESSION_LENGTH),
                new SystemConfig(Enums.SysConfigType.DISABLE_KMU_BY_DEFAULT),
                new SystemConfig(Enums.SysConfigType.RE_DISABLE_KMU_AFTER_20_MIN),
                new SystemConfig(Enums.SysConfigType.LCD_BARCODE_MODULE)
            };

            NetworkFunction.GetSystemConfig(lsc);
        }

        private void ApplySettingPageConfig()
        {
            List<SystemConfig> lsc = new List<SystemConfig>() {
                new SystemConfig(Enums.SysConfigType.TIMES_UP_MESSAGE, radTextBoxTimeUpMessage.Text),
                new SystemConfig(Enums.SysConfigType.MANUAL_END_MESSAGE, radTextBoxEndGameMessage.Text),
                new SystemConfig(Enums.SysConfigType.EMERGENCY_MESSAGE, radTextBoxEmergencyMessage.Text),
                new SystemConfig(Enums.SysConfigType.DEFAULT_TIMED_SESSION_LENGTH, radSpinEditorTimedSessionLength.Value.ToString()),
                new SystemConfig(Enums.SysConfigType.DISABLE_KMU_BY_DEFAULT, radCheckBoxUSBOffByDefault.Checked.ToString()),
                new SystemConfig(Enums.SysConfigType.RE_DISABLE_KMU_AFTER_20_MIN, radCheckBoxUSBAutoReEnable.Checked.ToString()),
                new SystemConfig(Enums.SysConfigType.LCD_BARCODE_MODULE, radCheckBoxEnableBarcodeLCDModule.Checked.ToString())
            };

            NetworkFunction.SetSystemConfig(lsc);

            this.ShowAlertBox("Options", "Setting saved!");
        }

        private void DisableRadPageViews()
        {
            radPageViewPageClientConfig.Enabled = false;
            radPageViewPageTileConfig.Enabled = false;
            radPageViewPageSettings.Enabled = false;
            radPageViewPageKeyGen.Enabled = false;

        }

        private void EnableRadPageViews()
        {
            radPageViewPageClientConfig.Enabled = true;
            radPageViewPageTileConfig.Enabled = true;
            radPageViewPageSettings.Enabled = true;
            radPageViewPageKeyGen.Enabled = true;

        }

        private void radButtonChangeAdminPassword_Click(object sender, EventArgs e)
        {
            string firstPassword;

            tsNumericKeypad keyboard = new tsNumericKeypad("Enter New Admin Password");
            keyboard.IsPassword = true;

            this.ShowAlertBox("Change Admin Password", "Please enter the new admin password.");

            DialogResult dr = keyboard.ShowDialog();

            if (dr == DialogResult.OK)
            {
                firstPassword = keyboard.Data;

                keyboard.Text = "Enter New Admin Password Again";
                keyboard.Data = "";

                this.ShowAlertBox("Change Admin Password", "Please re-enter the new admin password.");

                dr = keyboard.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    if (keyboard.Data == firstPassword)
                    {
                        this.ShowAlertBox("Change Admin Password", "New admin password is saved!");
                        NetworkFunction.SetSystemConfig(new SystemConfig(Enums.SysConfigType.ADMIN_PASSWORD, firstPassword));
                    }
                    else
                    {
                        this.ShowAlertBox("Change Admin Password", "First password unmatch to the second password. Please re-try!");
                    }
                }
            }
        }

        private void radButtonChangeManagerPassword_Click(object sender, EventArgs e)
        {
            string firstPassword;

            tsNumericKeypad keyboard = new tsNumericKeypad("Enter New Manager Password");
            keyboard.IsPassword = true;

            this.ShowAlertBox("Change Manager Password", "Please enter the new manager password.");

            DialogResult dr = keyboard.ShowDialog();

            if (dr == DialogResult.OK)
            {
                firstPassword = keyboard.Data;

                keyboard.Text = "Enter New Manager Password Again";
                keyboard.Data = "";

                this.ShowAlertBox("Change Manager Password", "Please re-enter the new manager password.");

                dr = keyboard.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    if (keyboard.Data == firstPassword)
                    {
                        this.ShowAlertBox("Change Manager Password", "New manager password is saved!");
                        NetworkFunction.SetSystemConfig(new SystemConfig(Enums.SysConfigType.MANAGER_PASSWORD, firstPassword));
                    }
                    else
                    {
                        this.ShowAlertBox("Change Manager Password", "First password unmatch to the second password. Please re-try!");
                    }
                }
            }
        }

        private void buttonSettingSave_Click(object sender, EventArgs e)
        {
            ApplySettingPageConfig();
        }

        private void radSpinEditorTimedSessionLength_MouseDown(object sender, MouseEventArgs e)
        {
            tsNumericKeypad keyboard = new tsNumericKeypad("Enter Minutes");

            DialogResult dr = keyboard.ShowDialog();

            if (dr == DialogResult.OK)
            {
                int tmpMin = 50;

                int.TryParse(keyboard.Data, out tmpMin);

                radSpinEditorTimedSessionLength.Value = tmpMin == 0 ? 50 : tmpMin;
            }
        }

        private void Options_Load(object sender, EventArgs e)
        {
            InitData();
            //NetworkFunction.GetConfigSet();
            //NetworkFunction.GetClientConfig();
            GetSettingPageConfig();
        }

        private void radButtonAddKey_Click(object sender, EventArgs e)
        {
            KeyAdd ka = new KeyAdd();
            ka.ShowDialog();
        }

        private void radButtonDeleteKey_Click(object sender, EventArgs e)
        {
            if (listViewKeyGen.SelectedItems.Count == 1)
            {
                List<KeyInfo> listKeyInfo = new List<KeyInfo>();

                listKeyInfo.Add(new KeyInfo()
                {
                    Key = (string)listViewKeyGen.SelectedItems[0].Tag
                });

                NetworkFunction.DeleteKey(listKeyInfo);

            }
        }

        private void radButtonSyncTileConfig_Click(object sender, EventArgs e)
        {
            DialogResult dr = RadMessageBox.Show(this, "Do you want to send tile config to all client? (Please do not send config more than once per minutes to avoid pipeline jamming)", "Info", MessageBoxButtons.YesNo, RadMessageIcon.Question);

            if (dr == DialogResult.Yes)
            {
                NetworkFunction.SyncTileConfig();
            }
        }

        private void radButtonReInitClientConfig_Click(object sender, EventArgs e)
        {
            DialogResult dr = RadMessageBox.Show(this, "Do you want to re-initialize client setting? Normally this only used to fix client sync issue. This will effectively terminate any current session!", "Warning!", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation);

            if (dr == DialogResult.Yes)
            {
                NetworkFunction.ReInitClientSetting();
            }
        }

        private void radGridViewTileConfig_Click(object sender, EventArgs e)
        {
            if (this.radGridViewTileConfig.CurrentRow is GridViewDataRowInfo)
            {
                SetCurrentSelectionIndex();

            }
        }

        private void radButtonCopyPasteTile_Click(object sender, EventArgs e)
        {
            if (this.radGridViewTileConfig.CurrentRow is GridViewDataRowInfo && _tileConfigClipBoard == null)
            {
                TileConfig targetTileConfig = (TileConfig)radGridViewTileConfig.CurrentRow.DataBoundItem;

                _tileConfigClipBoard = targetTileConfig;
                radButtonCopyPasteTile.Text = "Paste";

            }
            else if (_tileConfigClipBoard != null)
            {
                if (this.radGridViewTileConfig.CurrentRow is GridViewDataRowInfo)
                {
                    // selected row

                    int parentTileConfigID = 0;
                    int lastOrder = 0;
                    List<TileConfig> lTileConfig = _lTileConfig != null ? _lTileConfig : new List<TileConfig>();

                    TileConfig targetTileConfig = (TileConfig)radGridViewTileConfig.CurrentRow.DataBoundItem;

                    if (targetTileConfig.TileconfigID == 0)
                    {
                        DialogResult dr = RadMessageBox.Show(this, "Do you want to paste this tile in the sub level of selected tile?", "Create on root or sub level!", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                        if (dr == DialogResult.Yes)
                        {
                            parentTileConfigID = targetTileConfig.ID; // selected tile will be the parent
                        }
                    }
                    else
                    {
                        parentTileConfigID = targetTileConfig.TileconfigID; // set the parent tile
                    }

                    foreach (TileConfig tc in lTileConfig)
                    {
                        if (tc.TileconfigID == parentTileConfigID && tc.Order > lastOrder)
                        {
                            lastOrder = tc.Order;
                        }

                    }

                    System.Diagnostics.Debug.WriteLine("parentTileConfigID: {0}  lastOrder: {1}", parentTileConfigID, lastOrder);

                    SetCurrentSelectionIndex();

                    _tileConfigClipBoard.TileconfigID = parentTileConfigID;
                    _tileConfigClipBoard.TileConfigSetID = (int)comboBoxTileConfig.SelectedItem.Value;
                    _tileConfigClipBoard.Order = lastOrder + 1;

                }
                else
                {
                    // not selected a row
                    int lastOrder = 0;
                    List<TileConfig> lTileConfig = _lTileConfig != null ? _lTileConfig : new List<TileConfig>();

                    foreach (TileConfig tc in lTileConfig)
                    {
                        if (tc.TileconfigID == 0 && tc.Order > lastOrder)
                        {
                            lastOrder = tc.Order;
                        }
                    }

                    _tileConfigClipBoard.TileconfigID = 0;
                    _tileConfigClipBoard.TileConfigSetID = (int)comboBoxTileConfig.SelectedItem.Value;
                    _tileConfigClipBoard.Order = lastOrder + 1;

                }

                NetworkFunction.AddTileConfig(_tileConfigClipBoard);
                _tileConfigClipBoard = null;
                radButtonCopyPasteTile.Text = "Copy";
            }
        }

        private void radGridViewTileConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.C || e.KeyCode == Keys.V) && e.Modifiers == Keys.Control)
            {
                radButtonCopyPasteTile_Click(null, null);
            }
        }
    }
}
