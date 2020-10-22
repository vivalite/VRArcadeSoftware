// This is a part of the Microsoft POS for .NET SDK
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This sample source code is only intended as a 
// supplement to the POS for .NET SDK and related 
// electronic documentation provided with the library.

using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.PointOfService;

namespace TestApplication
{

    public partial class MainForm : System.Windows.Forms.Form
    {

        delegate void SetTextCallback(string text);

        internal void SetOutputText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (Output.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetOutputText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                Output.Text = text + "\r\n" + Output.Text;
            }
        }


        #region Variables

        private System.Windows.Forms.TreeView DeviceTree;
        private TextBox Output;
        private System.Windows.Forms.Button btnCloseDevice;
        private System.Windows.Forms.Button btnOpenDevice;
        private System.Windows.Forms.Button btnClaimDevice;
        private System.Windows.Forms.Button btnReleaseDevice;
        private System.Windows.Forms.Button btnShowStats;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnProperties;
        private System.Windows.Forms.CheckBox chkFreezeEvents;
        private System.Windows.Forms.CheckBox chkDataEventEnabled;
        private System.Windows.Forms.CheckBox chkDeviceEnabled;
        private System.Windows.Forms.CheckBox chkAutoDisable;
        private System.Windows.Forms.CheckBox chkAsync;
        private System.Windows.Forms.Button btnClearInput;
        private System.Windows.Forms.Button btnClearOutput;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.ComboBox cbBinaryConversion;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox chkPowerNotify;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel sbpState;
        private System.Windows.Forms.StatusBarPanel sbpDataEventsEnabled;
        private System.Windows.Forms.StatusBarPanel sbpDataCount;
        private System.ComponentModel.Container components = null;
        
        private System.Windows.Forms.Timer stateTimer = new System.Windows.Forms.Timer();
        private ToolTip toolTip1 = new ToolTip();
        private PosExplorer posExplorer;
        private System.Windows.Forms.ComboBox cbCompatibilityLevel;
        private Button btnDirectIO;
        private Panel DevicePanel;
        private CheckBox cbKeepDataEventsEnabled;
        private Button btnCheckHealth;
        private Button btnClearResults;
        private Button btnClearInputProperties;
        
        #endregion
        
        public MainForm()
        {
            Panel panelParent = new Panel();
            panelParent.Parent = this;
            panelParent.Dock = DockStyle.Fill;

            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            stateTimer.Tick += new EventHandler(stateTimer_Tick);

            Output.Parent = panelParent;
            panel1.Parent = panelParent;
            panel1.Dock = DockStyle.Left;

            // Create the ToolTip and associate with the Form container.
            toolTip1.ShowAlways = true;
            toolTip1.InitialDelay = 300;
            toolTip1.ReshowDelay = 0;
            toolTip1.SetToolTip(DeviceTree, "");
            
            try
            {
                this.Closed += new System.EventHandler(this.Form1_Closed);
                
                cbCompatibilityLevel.Items.Clear();
                cbCompatibilityLevel.Items.AddRange(Enum.GetNames(typeof(DeviceCompatibilities)));
                cbCompatibilityLevel.Text = DeviceCompatibilities.OposAndCompatibilityLevel1.ToString();
                cbCompatibilityLevel.SelectedIndexChanged += new EventHandler(cbCompatibilityLevel_SelectedIndexChanged);

                cbBinaryConversion.Items.Clear();
                cbBinaryConversion.Items.AddRange(Enum.GetNames(typeof(BinaryConversion)));
               
                
                posExplorer = new PosExplorer(this);
                posExplorer.DeviceAddedEvent += new DeviceChangedEventHandler(root_OnDeviceAdded);
                posExplorer.DeviceRemovedEvent += new DeviceChangedEventHandler(root_OnDeviceRemoved);

                RefreshDeviceTree(false);
                DeviceTree.CollapseAll();
                SetButtonState();

                stateTimer.Interval = 500;
                stateTimer.Start();

                DeviceTree.AfterSelect += new TreeViewEventHandler(DeviceTree_AfterSelect);
                DeviceTree.MouseMove += new MouseEventHandler(DeviceTree_MouseMove);
            }
            catch(Exception ae)
            {
                ShowException(ae);
            }
        }

        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }


        [STAThread]
        static void Main() 
        {
            Application.Run(new MainForm());
        }

        
        

        
        

        private void Form1_Closed(object sender, System.EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }


        
        PosDeviceTag currentDevice = null;
        

        #region DeviceTree operations

        // Loop through all devices in the collection and add them to the tree if they don't already exist
        private void AddDevicesToTree(DeviceCollection devices, bool showAddedDevice)
        {
            foreach( DeviceInfo device in devices )
            {
                TreeNode deviceTypeNode = null;
                foreach (TreeNode t in DeviceTree.Nodes)
                {
                    if (string.Compare(t.Text, device.Type, true) == 0)
                    {
                        deviceTypeNode = t;
                        break;
                    }
                }

                if (deviceTypeNode == null)
                {
                    // Device type doesn't exist yet so create a node for it
                    deviceTypeNode = new TreeNode(device.Type);
                    deviceTypeNode.Tag = device.Type;
                    DeviceTree.Nodes.Add(deviceTypeNode);
                }

                TreeNode deviceNode = null;
                foreach (TreeNode dt in deviceTypeNode.Nodes)
                {
                    DeviceInfo d = ((PosDeviceTag) dt.Tag).DeviceInfo;
                    if (DeviceInfosAreEqual(d, device))
                    {
                        deviceNode = dt;
                        break;
                    }
               }

                if (deviceNode == null)
                {
                    TreeNode DeviceNode = new TreeNode( GetDeviceDisplayName(device) );
                    DeviceNode.Tag = new PosDeviceTag(device);
                    deviceTypeNode.Nodes.Add(DeviceNode);
                    DeviceNode.EnsureVisible();
                    if (showAddedDevice)
                        DeviceTree.SelectedNode = DeviceNode;
                }
            }
        }

        bool DeviceInfosAreEqual(DeviceInfo d1, DeviceInfo d2)
        {
            return (string.Compare(d1.HardwarePath,      d2.HardwarePath,      true) == 0 &&
                    string.Compare(d1.HardwareId,        d2.HardwareId,        true) == 0 &&
                    string.Compare(d1.ServiceObjectName, d2.ServiceObjectName, true) == 0);
        }

        // Loop through all devices in the tree and make sure they exist in the DeviceCollection.
        // If not remove them from the tree.
        private void RemoveDevicesFromTree(DeviceCollection devices)
        {
            for (int i = DeviceTree.Nodes.Count - 1; i >= 0; i--)
            {
                TreeNode deviceTypeNode = DeviceTree.Nodes[i];
                for (int j=deviceTypeNode.Nodes.Count-1; j>=0; j--)
                {
                    TreeNode deviceNode = deviceTypeNode.Nodes[j];
                    DeviceInfo d = ((PosDeviceTag)deviceNode.Tag).DeviceInfo;

                    bool IsInCollection = false;
                    foreach (DeviceInfo device in devices)
                    {
                        if (DeviceInfosAreEqual(d, device))
                        {
                            IsInCollection = true;
                            break;
                        }
                    }

                    if (!IsInCollection)
                    {
                        CloseDevice(deviceNode);
                        deviceNode.Remove();
                    }
                }
                

                if (deviceTypeNode.Nodes.Count == 0)
                    deviceTypeNode.Remove();
            }
        }

        private void RefreshDeviceTree(bool showAddedDevice)
        {
            try
            {
                DeviceCollection devices = posExplorer.GetDevices((DeviceCompatibilities)Enum.Parse(typeof(DeviceCompatibilities), cbCompatibilityLevel.Text, false));

                DeviceTree.SuspendLayout();
                try
                {
                    // First loop through all devices in the collection and add them to the 
                    // tree if they are not already there.
                    AddDevicesToTree(devices, showAddedDevice);

                    // Now remove any devices that are in the tree but not in the collection
                    RemoveDevicesFromTree(devices);

                    // Make sure the view position of the tree is correct
                    if (DeviceTree.SelectedNode != null)
                        DeviceTree.SelectedNode.EnsureVisible();
                    else if (DeviceTree.Nodes.Count > 0)
                        DeviceTree.Nodes[0].EnsureVisible();
                }
                finally
                {
                    DeviceTree.ResumeLayout();
                }

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        object lastTag = null;
        private void DeviceTree_MouseMove(object sender, MouseEventArgs e)
        {
            TreeNode tn = DeviceTree.GetNodeAt(e.X, e.Y);
            if (tn != null && tn.Tag != null)
            {
                if (tn.Tag == lastTag)
                    return;

                lastTag = tn.Tag;

                string tip = "";
                string deviceType = lastTag as string;
                if (deviceType != null)
                {
                    tip = deviceType;
                }
                else
                {
                    DeviceInfo di = ((PosDeviceTag)tn.Tag).DeviceInfo;
                    tip = "Service Object Name: " + di.ServiceObjectName +
                        "\r\nLogical Names: " + CombineNames(di.LogicalNames) +
                        "\r\nDescription: " + di.Description +
                        "\r\nManufacturer: " + di.ManufacturerName +
                        "\r\nType: " + di.Type +
                        "\r\nService Object Version: " + di.ServiceObjectVersion.ToString() +
                        "\r\nUPOS Version: " + di.UposVersion.ToString() +
                        "\r\nCompatibility: " + di.Compatibility +
                        "\r\nHardware Description: " + di.HardwareDescription +
                        "\r\nHardware Id: " + di.HardwareId +
                        "\r\nHardware Path: " + di.HardwarePath +
                        "\r\nDefault: " + di.IsDefault;
                }
                toolTip1.SetToolTip(DeviceTree, tip.Replace("&", "&&&"));
            }
            else
            {
                lastTag = null;
                toolTip1.SetToolTip(DeviceTree, "");
            }
        }

        #endregion


        #region Helper methods

        class PosDeviceTag
        {
            public PosDeviceTag(DeviceInfo deviceInfo)
            {
                DeviceInfo = deviceInfo;
            }

            public DeviceInfo DeviceInfo;
            public PosCommon posCommon;
            public DeviceScreenBase screen;
        }


        private void ShowDeviceScreen(PosDeviceTag tag)
        {
            if (tag != null && tag.posCommon != null)
            {
                // Show the Device panel
                if (tag.screen == null)
                    tag.screen = DeviceScreenBase.CreateDeviceScreen(tag.posCommon, GetDeviceDisplayName(tag.DeviceInfo), this);
                

                if (tag.screen != null && !DevicePanel.Controls.Contains(tag.screen))
                {
                    DevicePanel.SuspendLayout();
                    DevicePanel.Controls.Clear();
                    DevicePanel.Controls.Add(tag.screen);
                    DevicePanel.ResumeLayout(false);

                    currentDevice = tag;
                }
            }
            else if (DevicePanel.Controls.Count > 0)
            {
                DevicePanel.Controls.Clear();
            }
        }


        static string GetDeviceDisplayName(DeviceInfo device)
        {
            string name = CombineNames( device.LogicalNames );
            if (name.Length == 0)
            {
                name = device.ServiceObjectName;
                if (name.Length == 0)
                    name = device.Description;
            }
            return name;
        }

        bool ImplementsMethod(PosCommon pc, string methodName)
        {
            if (pc != null)
                return (pc.GetType().GetMethod(methodName) != null);
            return false;
        }

        bool ImplementsProperty(PosCommon pc, string PropertyName)
        {
            if (pc != null)
                return (pc.GetType().GetProperty(PropertyName) != null);
            return false;
        }

        void SetCheckState(PosCommon pc, CheckBox cb, string propertyName)
        {
            cb.Tag = cb; // Mark the tag so that we event handler is disabled
            try
            {
                if (pc == null)
                {
                    cb.Enabled = cb.Checked = false;
                }
                else
                {
                    PropertyInfo pi = pc.GetType().GetProperty(propertyName);
                    if (pi != null)
                    {
                        cb.Enabled = true;

                        if (pc.State != ControlState.Closed)
                        {
                            try
                            {
                                if (propertyName == "PowerNotify")
                                    cb.Checked = ((PowerNotification)pi.GetValue(pc, null)) == PowerNotification.Enabled;
                                else
                                    cb.Checked = (bool)pi.GetValue(pc, null);
                            }
                            catch (Exception)
                            {
                                cb.Checked = false;
                            }
                        }
                        else
                            cb.Checked = false;

                    }
                    else
                        cb.Enabled = cb.Checked = false;
                }
            }
            finally
            {
                cb.Tag = null;
            }
        }

        void SetButtonState()
        {
            PosCommon pc = null;
            PosDeviceTag tag = currentDevice;
            if (tag != null && tag.posCommon!=null && tag.posCommon.State != ControlState.Closed)
                pc = tag.posCommon;

            btnOpenDevice.Enabled = (tag != null && pc == null);
            btnCloseDevice.Enabled = (tag != null && pc != null);
            btnClaimDevice.Enabled = (tag != null && pc != null);
            btnReleaseDevice.Enabled = (tag != null && pc != null);
            btnCheckHealth.Enabled = (tag != null && pc != null);

            btnClearInput.Enabled = ImplementsMethod(pc, "ClearInput");
            btnClearOutput.Enabled = ImplementsMethod(pc, "ClearOutput");
            btnClearInputProperties.Enabled = ImplementsMethod(pc, "ClearInputProperties");
            btnShowStats.Enabled = (tag != null && pc != null);
            btnProperties.Enabled = (tag != null && pc != null);
            btnDirectIO.Enabled = (tag != null && pc != null);

            ILegacyControlObject co = pc as ILegacyControlObject;
            cbBinaryConversion.Enabled = (co != null);
            if (co != null && pc.State != ControlState.Closed)
            {
                try
                {
                    cbBinaryConversion.Text = co.BinaryConversion.ToString();
                }
                catch(Exception){}
            }
            else
            {
                cbBinaryConversion.Text = "";
            }



            SetCheckState(pc, chkDataEventEnabled, "DataEventEnabled");
            SetCheckState(pc, chkDeviceEnabled, "DeviceEnabled");
            SetCheckState(pc, chkFreezeEvents, "FreezeEvents");
            SetCheckState(pc, chkPowerNotify, "PowerNotify");
            SetCheckState(pc, chkAsync, "AsyncMode");
            SetCheckState(pc, chkAutoDisable, "AutoDisable");

        }

        void HookUpEvents(PosCommon pc, bool attach)
        {
            if (pc == null)
                return;

            if (attach)
            {
                pc.StatusUpdateEvent += new StatusUpdateEventHandler(co_OnStatusUpdateEvent);
                pc.DirectIOEvent += new DirectIOEventHandler(co_OnDirectIOEvent);
            }
            else
            {
                pc.StatusUpdateEvent -= new StatusUpdateEventHandler(co_OnStatusUpdateEvent);
                pc.DirectIOEvent -= new DirectIOEventHandler(co_OnDirectIOEvent);
            }

            EventInfo dataEvent = pc.GetType().GetEvent("DataEvent");
            if (dataEvent != null)
            {
                if (attach)
                    dataEvent.AddEventHandler(pc, new DataEventHandler(co_OnDataEvent));
                else
                    dataEvent.RemoveEventHandler(pc, new DataEventHandler(co_OnDataEvent));
            }

            EventInfo errorEvent = pc.GetType().GetEvent("ErrorEvent");
            if (errorEvent != null)
            {
                if (attach)
                    errorEvent.AddEventHandler(pc, new DeviceErrorEventHandler(co_OnErrorEvent));
                else
                    errorEvent.RemoveEventHandler(pc, new DeviceErrorEventHandler(co_OnErrorEvent));
            }

            EventInfo outputCompleteEvent = pc.GetType().GetEvent("OutputCompleteEvent");
            if (outputCompleteEvent != null)
            {
                if (attach)
                    outputCompleteEvent.AddEventHandler(pc, new OutputCompleteEventHandler(co_OnOutputCompleteEvent));
                else
                    outputCompleteEvent.RemoveEventHandler(pc, new OutputCompleteEventHandler(co_OnOutputCompleteEvent));
            }
        }

        private void OpenDevice(TreeNode node)
        {
            if (node == null || node.Tag == null)
                return;

            PosDeviceTag tag = (PosDeviceTag) node.Tag;

            if (tag == null)
                return;

            try
            {
                DeviceInfo device = tag.DeviceInfo;

                if (tag.posCommon == null)
                {
                    tag.posCommon = (PosCommon)posExplorer.CreateInstance(device);
                    Output.Text = "Created instance of device: " + device.ServiceObjectName + "\r\n" + Output.Text;
                }
                else
                {
                    Output.Text = "Using existing instance of device: " + device.ServiceObjectName + "\r\n" + Output.Text;
                }

                tag.posCommon.Open();
                Output.Text = "Opened device: " + device.ServiceObjectName + "\r\n" + Output.Text;

                // Display the screen for this device
                ShowDeviceScreen(tag);

                // Tell the device screen that it is now opened
                if (tag.screen != null)
                    tag.screen.SetOpened(true);

                // Update the common UI properties
                //SetDeviceProperties(node);

                // Bold the font for this device in the DeviceTree to indicate it's created
                node.NodeFont = new Font(DeviceTree.Font, FontStyle.Bold);
                node.Text = node.Text;

                // Hook up event handlers for device (only error event for now)
                HookUpEvents(tag.posCommon, true);
            }
            catch( Exception ae )
            {
                tag.posCommon = null;
                ShowException(ae);
            }
            finally
            {
                SetButtonState();
            }
        }

        private void CloseDevice(TreeNode node)
        {
            if (node == null)
                return;

            // Unbold the treenode
            node.NodeFont = new Font(DeviceTree.Font, FontStyle.Regular);

            PosDeviceTag tag = node.Tag as PosDeviceTag;
            try
            {
                if (tag == null || tag.posCommon == null || tag.posCommon.State == ControlState.Closed)
                    return;

                tag.posCommon.Close();

                // Tell the device screen that it is now Closed
                if (tag.screen != null)
                {
                    tag.screen.SetOpened(false);
                    if (DevicePanel.Controls.Contains(tag.screen))
                        DevicePanel.Controls.Remove(tag.screen);
                    tag.screen = null;
                }

                HookUpEvents(tag.posCommon, false);
                tag.posCommon = null;
                
            }
            catch(Exception ae)
            {
                tag.posCommon = null;
                ShowException(ae);
            }
            finally
            {
                SetButtonState();
            }

        }
        

        private void UpdateDeviceState()
        {
            PosDeviceTag tag = currentDevice;
                if (tag == null)
                    return;

            PosCommon pc = tag.posCommon;
            
            string state = "Closed";
            string datacount = "";
            string dataeventenabled = "";
            try
            {
                if (pc != null && pc.State != ControlState.Closed)
                {
                    try
                    {
                        string text = pc.State.ToString() + ", ";
                        if (pc.Claimed)
                            text += "Claimed, ";
                        else
                            text += "Unclaimed, ";

                        try
                        {
                            if (pc.DeviceEnabled)
                            {
                                chkDeviceEnabled.Checked = true;
                                text += "Enabled";
                            }
                            else
                            {
                                chkDeviceEnabled.Checked = false;
                                text += "Disabled";
                            }
                        }
                        catch
                        {
                            text += "Disabled";
                        }

                        state = text;
                    }
                    catch { }

                    try
                    {
                        PropertyInfo dataEventEnabled = pc.GetType().GetProperty("DataEventEnabled");
                        if (dataEventEnabled != null)
                        {
                            chkDataEventEnabled.Enabled = true;
                            chkDataEventEnabled.Checked = ((bool)dataEventEnabled.GetValue(pc, null)) == true;
                            dataeventenabled = "DataEventsEnabled: " + dataEventEnabled.GetValue(pc, null).ToString();
                        }
                        else
                        {
                            chkDataEventEnabled.Enabled = false;
                            chkDataEventEnabled.Checked = false;
                            dataeventenabled = "";
                        }
                    }
                    catch { }

                    try
                    {
                        PropertyInfo dataCount = pc.GetType().GetProperty("DataCount");
                        if (dataCount != null)
                            datacount = "DataCount: " + dataCount.GetValue(pc, null).ToString();
                        else
                            datacount = "";
                    }
                    catch { }

                    try
                    {
                        SetCheckState(pc, chkFreezeEvents, "FreezeEvents");
                        SetCheckState(pc, chkPowerNotify, "PowerNotify");
                        SetCheckState(pc, chkAsync, "AsyncMode");
                        SetCheckState(pc, chkAutoDisable, "AutoDisable");
                    }
                    catch { }
                }
                
            }
            catch {}
            finally
            {
                sbpState.Text = state;
                sbpDataCount.Text = datacount;
                sbpDataEventsEnabled.Text = dataeventenabled;
            }
        }

        internal void ShowException(Exception e)
        {
            Exception inner = e.InnerException;
            if (inner != null)
            {
                ShowException(inner);
            }

            string str = Output.Text;
            if (e is PosControlException)
            {
                PosControlException pe = (PosControlException) e;

                Output.Text = "POSControlException ErrorCode(" + pe.ErrorCode.ToString() + ") ExtendedErrorCode(" + pe.ErrorCodeExtended.ToString() + ") occurred: " + pe.Message + "\r\n" + str;
            }
            else
            {
                Output.Text = e.ToString() + "\r\n" + str;
            }
        }

        static string CombineNames( string[] names )
        {
            string s = "";
            foreach( string name in names )
            {
                if( s.Length > 0 )
                    s += ';';
                s += name;
            }

            return s;
        }

        #endregion

        

        #region Common Event handlers

        private void btnDirectIO_Click(object sender, EventArgs e)
        {
            PosDeviceTag tag = currentDevice;
            if (tag == null)
                return;

            PosCommon pc = tag.posCommon;
            if (pc != null)
            {
                DirectIOForm form = new DirectIOForm(pc);
                form.ShowDialog();
            }
        }

        private void cbCompatibilityLevel_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            RefreshDeviceTree(false);
        }

        private void btnClearInput_Click(object sender, System.EventArgs e)
        {
            try
            {
                PosDeviceTag tag = currentDevice;
                if (tag == null)
                    return;

                PosCommon posCommon = tag.posCommon;
                if (posCommon != null)
                {
                    MethodInfo clearInput = posCommon.GetType().GetMethod("ClearInput");
                    if (clearInput != null)
                        clearInput.Invoke(posCommon, null);
                }
            }
            catch(Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnClearInputProperties_Click(object sender, EventArgs e)
        {
            try
            {
                PosDeviceTag tag = currentDevice;
                if (tag == null)
                    return;

                PosCommon pc = tag.posCommon;

                if (pc != null)
                {
                    MethodInfo clearInputProperties = pc.GetType().GetMethod("ClearInputProperties");
                    if (clearInputProperties != null)
                    {
                        clearInputProperties.Invoke(pc, null);
                        currentDevice.screen.ClearInputProperties();
                    }
                }
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnClearOutput_Click(object sender, System.EventArgs e)
        {
            try
            {
                PosDeviceTag tag = currentDevice;
                if (tag == null)
                    return;

                PosCommon pc = tag.posCommon;

                if (pc != null)
                {
                    MethodInfo clearOutput = pc.GetType().GetMethod("ClearOutput");
                    if (clearOutput != null)
                        clearOutput.Invoke(pc, null);
                }
            }
            catch(Exception ae)
            {
                ShowException(ae);
            }
        }

        private void stateTimer_Tick(object sender, EventArgs e)
        {
            UpdateDeviceState();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                posExplorer.Refresh();
                RefreshDeviceTree(false);
            }
            finally
            {
                Cursor.Current = old;
            }
        }

        private void CloseDevice_Click(object sender, System.EventArgs e)
        {
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor; 
            try
            {
                CloseDevice(DeviceTree.SelectedNode);
            }
            finally
            {
                Cursor.Current = old;
            }
        }

        private void OpenDevice_Click(object sender, System.EventArgs e)
        {
            try
            {
                Cursor old = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (DeviceTree != null)
                        OpenDevice(DeviceTree.SelectedNode);
                }
                finally
                {
                    Cursor.Current = old;
                }
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }

        }

        private void chkDataEventEnabled_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkDataEventEnabled.Tag != null)
                return;

            PosDeviceTag tag = currentDevice as PosDeviceTag;
            if (tag == null || tag.posCommon == null)
                return;

            PosCommon pc = tag.posCommon;
            PropertyInfo dataEventEnabled = null;

            try
            {
                dataEventEnabled = pc.GetType().GetProperty("DataEventEnabled");
                if (dataEventEnabled != null)
                    dataEventEnabled.SetValue(pc, chkDataEventEnabled.Checked, null);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
            finally
            {
                try
                {
                    if (dataEventEnabled != null && pc.State != ControlState.Closed)
                    {
                        bool state = (bool)dataEventEnabled.GetValue(pc, null);
                        if (state != chkDataEventEnabled.Checked)
                        {
                            chkDataEventEnabled.Tag = chkDataEventEnabled;
                            try
                            {
                                chkDataEventEnabled.Checked = state;
                            }
                            finally
                            {
                                chkDataEventEnabled.Tag = null;
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private void chkDeviceEnabled_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkDeviceEnabled.Tag != null)
                return;

            PosDeviceTag tag = currentDevice as PosDeviceTag;
            if (tag == null || tag.posCommon == null)
                return;
            
            PosCommon pc = tag.posCommon;

            try
            {
                pc.DeviceEnabled = chkDeviceEnabled.Checked;

                // Inform screen of change
                tag.screen.SetDeviceEnabled(pc.DeviceEnabled);

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
            finally
            {
                try
                {
                    if (pc.State != ControlState.Closed)
                    {
                        bool state = pc.DeviceEnabled;
                        if (state != chkDeviceEnabled.Checked)
                        {
                            chkDeviceEnabled.Tag = chkDeviceEnabled;
                            try
                            {
                                chkDeviceEnabled.Checked = state;
                            }
                            finally
                            {
                                chkDeviceEnabled.Tag = null;
                            }
                        }
                    }
                }
                catch { }
            }
        
        }

        private void chkFreezeEvents_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkFreezeEvents.Tag != null)
                return;

            PosDeviceTag tag = currentDevice as PosDeviceTag;
            if (tag == null || tag.posCommon == null)
                return;

            PosCommon pc = tag.posCommon;

            try
            {
                pc.FreezeEvents = chkFreezeEvents.Checked;
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
            finally
            {
                try
                {
                    if (pc.State != ControlState.Closed)
                    {
                        bool state = pc.FreezeEvents;
                        if (state != chkFreezeEvents.Checked)
                        {
                            chkFreezeEvents.Tag = chkFreezeEvents;
                            try
                            {
                                chkFreezeEvents.Checked = state;
                            }
                            finally
                            {
                                chkFreezeEvents.Tag = null;
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private void chkPowerNotify_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkPowerNotify.Tag != null)
                return;

            PosDeviceTag tag = currentDevice as PosDeviceTag;
            if (tag == null || tag.posCommon == null)
                return;

            PosCommon pc = tag.posCommon;

            try
            {
                pc.PowerNotify = chkPowerNotify.Checked ? PowerNotification.Enabled : PowerNotification.Disabled;
            }
            catch(Exception ae)
            {
                ShowException(ae);
            }
            finally
            {
                try
                {
                    if (pc.State != ControlState.Closed)
                    {
                        bool state = (pc.PowerNotify == PowerNotification.Enabled);
                        if (state != chkPowerNotify.Checked)
                        {
                            chkPowerNotify.Tag = chkPowerNotify;
                            try
                            {
                                chkPowerNotify.Checked = state;
                            }
                            finally
                            {
                                chkPowerNotify.Tag = null;
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private void chkAutoDisable_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkAutoDisable.Tag != null)
                return;

            PosDeviceTag tag = currentDevice as PosDeviceTag;
            if (tag == null || tag.posCommon == null)
                return;

            PosCommon pc = tag.posCommon;
            PropertyInfo autoDisable = null;
            try
            {
                autoDisable = pc.GetType().GetProperty("AutoDisable");
                if( autoDisable != null)
                    autoDisable.SetValue( pc, chkAutoDisable.Checked, null );
            }
            catch(Exception ae)
            {
                ShowException(ae);
            }
            finally
            {
                try
                {
                    if (autoDisable != null && pc.State != ControlState.Closed)
                    {
                        bool state = (bool)autoDisable.GetValue(pc, null);
                        if (state != chkAutoDisable.Checked)
                        {
                            chkAutoDisable.Tag = chkAutoDisable;
                            try
                            {
                                chkAutoDisable.Checked = state;
                            }
                            finally
                            {
                                chkAutoDisable.Tag = null;
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private void btnCheckHealth_Click(object sender, EventArgs e)
        {
            PosDeviceTag tag = currentDevice;
            if (tag == null)
                return;

            try
            {
                Cursor old = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    string res = tag.posCommon.CheckHealth(HealthCheckLevel.Internal);
                    Output.Text = "CheckHealth(Internal) returned: " + res + "\r\n" + Output.Text;
                }
                finally
                {
                    Cursor.Current = old;
                }
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }


        private void ClaimDevice_Click(object sender, System.EventArgs e)
        {
            PosDeviceTag tag = currentDevice;
            if (tag == null)
                return;

            try
            {
                Cursor old = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    tag.posCommon.Claim(1000);
                }
                finally
                {
                    Cursor.Current = old;
                }

                // Tell the device screen that it is now Claimed
                tag.screen.SetDeviceClaimed(true);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
            finally
            {
                SetButtonState();
            }
            
        }

        private void ReleaseDevice_Click(object sender, System.EventArgs e)
        {
            PosDeviceTag tag = currentDevice;
            if (tag == null)
                return;
            
            try
            {
                Cursor old = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    tag.posCommon.Release();
                }
                finally
                {
                    Cursor.Current = old;
                }
                
                // Tell the device screen that it is now released
                tag.screen.SetDeviceClaimed(false);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
            finally
            {
                SetButtonState();
            }
        }


        private void btnShowStats_Click(object sender, System.EventArgs e)
        {
            try
            {
                PosDeviceTag tag = currentDevice as PosDeviceTag;
                if (tag == null)
                    return;
                PosCommon pc = tag.posCommon;
                if (pc == null)
                    return;

                StatisticsForm sf = new StatisticsForm(pc);
                sf.ShowDialog(this);
                sf.Dispose();
                sf = null;
            }
            catch(Exception ae)
            {
                ShowException(ae);
            }
        }
        private void btnProperties_Click(object sender, System.EventArgs e)
        {
            try
            {
                PosDeviceTag tag = currentDevice;
                if (tag == null)
                    return;

                PosCommon posCommon = tag.posCommon;
                if (posCommon == null)
                    return;

                PropertiesForm Form = new PropertiesForm(posCommon);
                Form.ShowDialog();
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void chkAsync_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkAsync.Tag != null)
                return;
            PosDeviceTag tag = currentDevice as PosDeviceTag;
            if (tag == null || tag.posCommon == null)
                return;

            PosCommon pc = tag.posCommon;
            PropertyInfo asyncMode = null;

            try
            {
                asyncMode = pc.GetType().GetProperty("AsyncMode");
                if( asyncMode != null)
                    asyncMode.SetValue( pc, chkAsync.Checked, null );

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
            finally
            {
                try
                {
                    if (asyncMode != null && pc.State != ControlState.Closed)
                    {
                        bool state = (bool)asyncMode.GetValue(pc, null);
                        if (state != chkAsync.Checked)
                        {
                            chkAsync.Tag = chkAsync;
                            try
                            {
                                chkAsync.Checked = state;
                            }
                            finally
                            {
                                chkAsync.Tag = null;
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private void DeviceTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag is PosDeviceTag)
                currentDevice = (PosDeviceTag)e.Node.Tag;
            else
                currentDevice = null;

            ShowDeviceScreen(currentDevice);
            SetButtonState();
        }


        private void cbBinaryConversion_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            PosDeviceTag tag = currentDevice;
            if (tag == null)
                return;

            try
            {
                PosCommon posCommon = tag.posCommon;
                if (posCommon is ILegacyControlObject)
                    ((ILegacyControlObject) posCommon).BinaryConversion = (BinaryConversion) Enum.Parse(typeof(BinaryConversion), cbBinaryConversion.Text);
            }
            catch(Exception ae)
            {
                ShowException(ae);
            }
        }

       
        #endregion




        #region POS Event handlers

        private void co_OnDataEvent(object source, DataEventArgs d)
        {
            PosCommon posCommon = source as PosCommon;
            Output.Text = d.ToString() + "\r\n" + Output.Text;
       
            PropertyInfo dataEventEnabled = posCommon.GetType().GetProperty("DataEventEnabled");
            if (dataEventEnabled != null)
            {
                if (cbKeepDataEventsEnabled.Checked)
                {
                    try
                    {
                        dataEventEnabled.SetValue(posCommon, true, null);
                    }
                    catch { }
                }
                chkDataEventEnabled.Checked = (bool)dataEventEnabled.GetValue(posCommon, null);
            }
       
            PropertyInfo autoDisable = posCommon.GetType().GetProperty("AutoDisable");
            if( autoDisable != null)
                chkAutoDisable.Checked = (bool) autoDisable.GetValue( posCommon, null );
       
            chkDeviceEnabled.Checked = posCommon.DeviceEnabled;
        }
        
        private void co_OnStatusUpdateEvent(object source, StatusUpdateEventArgs d)
        {
            try
            {
                Output.Text = d.ToString() + "\r\n" + Output.Text;
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void co_OnDirectIOEvent(object source, DirectIOEventArgs d)
        {
            Output.Text = d.ToString() + "\r\n" + Output.Text;
        }

        private void co_OnErrorEvent(object source, DeviceErrorEventArgs d)
        {
            PosCommon posCommon = source as PosCommon;
            if (posCommon == null)
                return;

            string str = d.ToString();
            
            ErrorEventDlg err = new ErrorEventDlg(d, posCommon);
            err.ShowDialog(this);


            str += "\r\nUser returned ErrorResponse(" + d.ErrorResponse + ")\r\n";

            
            Output.Text = str;
            

            PropertyInfo dataEventEnabled = posCommon.GetType().GetProperty("DataEventEnabled");
            if( dataEventEnabled != null)
            {
                chkDataEventEnabled.Checked = (bool) dataEventEnabled.GetValue( posCommon, null );
            }
        }

        private void co_OnOutputCompleteEvent(object source, OutputCompleteEventArgs d)
        {
            Output.Text = d.ToString() + "\r\n" + Output.Text;
        }

        private void root_OnDeviceAdded(object sender, DeviceChangedEventArgs e)
        {
            RefreshDeviceTree(true);
        }

        private void root_OnDeviceRemoved(object source, DeviceChangedEventArgs e)
        {
            RefreshDeviceTree(false);
        }

        #endregion

        


        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCloseDevice = new System.Windows.Forms.Button();
            this.DeviceTree = new System.Windows.Forms.TreeView();
            this.Output = new System.Windows.Forms.TextBox();
            this.btnOpenDevice = new System.Windows.Forms.Button();
            this.btnClaimDevice = new System.Windows.Forms.Button();
            this.btnReleaseDevice = new System.Windows.Forms.Button();
            this.btnShowStats = new System.Windows.Forms.Button();
            this.btnProperties = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCheckHealth = new System.Windows.Forms.Button();
            this.cbKeepDataEventsEnabled = new System.Windows.Forms.CheckBox();
            this.DevicePanel = new System.Windows.Forms.Panel();
            this.btnClearInputProperties = new System.Windows.Forms.Button();
            this.btnDirectIO = new System.Windows.Forms.Button();
            this.chkPowerNotify = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbBinaryConversion = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.chkAsync = new System.Windows.Forms.CheckBox();
            this.chkDeviceEnabled = new System.Windows.Forms.CheckBox();
            this.chkFreezeEvents = new System.Windows.Forms.CheckBox();
            this.chkAutoDisable = new System.Windows.Forms.CheckBox();
            this.chkDataEventEnabled = new System.Windows.Forms.CheckBox();
            this.btnClearInput = new System.Windows.Forms.Button();
            this.cbCompatibilityLevel = new System.Windows.Forms.ComboBox();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.sbpState = new System.Windows.Forms.StatusBarPanel();
            this.sbpDataEventsEnabled = new System.Windows.Forms.StatusBarPanel();
            this.sbpDataCount = new System.Windows.Forms.StatusBarPanel();
            this.btnClearResults = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbpState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpDataEventsEnabled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpDataCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCloseDevice
            // 
            this.btnCloseDevice.Location = new System.Drawing.Point(258, 31);
            this.btnCloseDevice.Name = "btnCloseDevice";
            this.btnCloseDevice.Size = new System.Drawing.Size(65, 23);
            this.btnCloseDevice.TabIndex = 1;
            this.btnCloseDevice.Text = "Close";
            this.btnCloseDevice.Click += new System.EventHandler(this.CloseDevice_Click);
            // 
            // DeviceTree
            // 
            this.DeviceTree.HideSelection = false;
            this.DeviceTree.Location = new System.Drawing.Point(5, 55);
            this.DeviceTree.Name = "DeviceTree";
            this.DeviceTree.Size = new System.Drawing.Size(248, 274);
            this.DeviceTree.TabIndex = 18;
            // 
            // Output
            // 
            this.Output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Output.Location = new System.Drawing.Point(1, 344);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Output.Size = new System.Drawing.Size(1024, 169);
            this.Output.TabIndex = 25;
            // 
            // btnOpenDevice
            // 
            this.btnOpenDevice.Location = new System.Drawing.Point(258, 5);
            this.btnOpenDevice.Name = "btnOpenDevice";
            this.btnOpenDevice.Size = new System.Drawing.Size(65, 23);
            this.btnOpenDevice.TabIndex = 21;
            this.btnOpenDevice.Text = "Open";
            this.btnOpenDevice.Click += new System.EventHandler(this.OpenDevice_Click);
            // 
            // btnClaimDevice
            // 
            this.btnClaimDevice.Location = new System.Drawing.Point(339, 6);
            this.btnClaimDevice.Name = "btnClaimDevice";
            this.btnClaimDevice.Size = new System.Drawing.Size(65, 23);
            this.btnClaimDevice.TabIndex = 8;
            this.btnClaimDevice.Text = "Claim";
            this.btnClaimDevice.Click += new System.EventHandler(this.ClaimDevice_Click);
            // 
            // btnReleaseDevice
            // 
            this.btnReleaseDevice.Location = new System.Drawing.Point(339, 31);
            this.btnReleaseDevice.Name = "btnReleaseDevice";
            this.btnReleaseDevice.Size = new System.Drawing.Size(65, 23);
            this.btnReleaseDevice.TabIndex = 9;
            this.btnReleaseDevice.Text = "Release";
            this.btnReleaseDevice.Click += new System.EventHandler(this.ReleaseDevice_Click);
            // 
            // btnShowStats
            // 
            this.btnShowStats.Location = new System.Drawing.Point(749, 6);
            this.btnShowStats.Name = "btnShowStats";
            this.btnShowStats.Size = new System.Drawing.Size(85, 23);
            this.btnShowStats.TabIndex = 13;
            this.btnShowStats.Text = "Show Stats";
            this.btnShowStats.Click += new System.EventHandler(this.btnShowStats_Click);
            // 
            // btnProperties
            // 
            this.btnProperties.Location = new System.Drawing.Point(749, 31);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Size = new System.Drawing.Size(85, 23);
            this.btnProperties.TabIndex = 48;
            this.btnProperties.Text = "Properties";
            this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClearResults);
            this.panel1.Controls.Add(this.btnCheckHealth);
            this.panel1.Controls.Add(this.cbKeepDataEventsEnabled);
            this.panel1.Controls.Add(this.DevicePanel);
            this.panel1.Controls.Add(this.btnClearInputProperties);
            this.panel1.Controls.Add(this.btnDirectIO);
            this.panel1.Controls.Add(this.chkPowerNotify);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.cbBinaryConversion);
            this.panel1.Controls.Add(this.label36);
            this.panel1.Controls.Add(this.btnClearOutput);
            this.panel1.Controls.Add(this.chkAsync);
            this.panel1.Controls.Add(this.chkDeviceEnabled);
            this.panel1.Controls.Add(this.chkFreezeEvents);
            this.panel1.Controls.Add(this.btnOpenDevice);
            this.panel1.Controls.Add(this.btnCloseDevice);
            this.panel1.Controls.Add(this.btnClaimDevice);
            this.panel1.Controls.Add(this.btnReleaseDevice);
            this.panel1.Controls.Add(this.btnShowStats);
            this.panel1.Controls.Add(this.chkAutoDisable);
            this.panel1.Controls.Add(this.chkDataEventEnabled);
            this.panel1.Controls.Add(this.btnClearInput);
            this.panel1.Controls.Add(this.btnProperties);
            this.panel1.Controls.Add(this.DeviceTree);
            this.panel1.Controls.Add(this.cbCompatibilityLevel);
            this.panel1.Location = new System.Drawing.Point(5, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 329);
            this.panel1.TabIndex = 21;
            // 
            // btnCheckHealth
            // 
            this.btnCheckHealth.Location = new System.Drawing.Point(658, 56);
            this.btnCheckHealth.Name = "btnCheckHealth";
            this.btnCheckHealth.Size = new System.Drawing.Size(85, 23);
            this.btnCheckHealth.TabIndex = 56;
            this.btnCheckHealth.Text = "CheckHealth";
            this.btnCheckHealth.Click += new System.EventHandler(this.btnCheckHealth_Click);
            // 
            // cbKeepDataEventsEnabled
            // 
            this.cbKeepDataEventsEnabled.Checked = true;
            this.cbKeepDataEventsEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbKeepDataEventsEnabled.Location = new System.Drawing.Point(843, 29);
            this.cbKeepDataEventsEnabled.Name = "cbKeepDataEventsEnabled";
            this.cbKeepDataEventsEnabled.Size = new System.Drawing.Size(161, 24);
            this.cbKeepDataEventsEnabled.TabIndex = 55;
            this.cbKeepDataEventsEnabled.Text = "Keep DataEvents Enabled";
            // 
            // DevicePanel
            // 
            this.DevicePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DevicePanel.Location = new System.Drawing.Point(259, 84);
            this.DevicePanel.Name = "DevicePanel";
            this.DevicePanel.Size = new System.Drawing.Size(763, 242);
            this.DevicePanel.TabIndex = 53;
            // 
            // btnClearInputProperties
            // 
            this.btnClearInputProperties.Location = new System.Drawing.Point(843, 55);
            this.btnClearInputProperties.Name = "btnClearInputProperties";
            this.btnClearInputProperties.Size = new System.Drawing.Size(127, 23);
            this.btnClearInputProperties.TabIndex = 52;
            this.btnClearInputProperties.Text = "ClearInputProperties";
            this.btnClearInputProperties.Click += new System.EventHandler(this.btnClearInputProperties_Click);
            // 
            // btnDirectIO
            // 
            this.btnDirectIO.Location = new System.Drawing.Point(749, 56);
            this.btnDirectIO.Name = "btnDirectIO";
            this.btnDirectIO.Size = new System.Drawing.Size(85, 23);
            this.btnDirectIO.TabIndex = 51;
            this.btnDirectIO.Text = "DirectIO";
            this.btnDirectIO.Click += new System.EventHandler(this.btnDirectIO_Click);
            // 
            // chkPowerNotify
            // 
            this.chkPowerNotify.Location = new System.Drawing.Point(412, 56);
            this.chkPowerNotify.Name = "chkPowerNotify";
            this.chkPowerNotify.Size = new System.Drawing.Size(93, 24);
            this.chkPowerNotify.TabIndex = 50;
            this.chkPowerNotify.Text = "PowerNotify";
            this.chkPowerNotify.CheckedChanged += new System.EventHandler(this.chkPowerNotify_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(8, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(63, 23);
            this.btnRefresh.TabIndex = 49;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbBinaryConversion
            // 
            this.cbBinaryConversion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBinaryConversion.ItemHeight = 13;
            this.cbBinaryConversion.Location = new System.Drawing.Point(917, 5);
            this.cbBinaryConversion.Name = "cbBinaryConversion";
            this.cbBinaryConversion.Size = new System.Drawing.Size(87, 21);
            this.cbBinaryConversion.TabIndex = 32;
            this.cbBinaryConversion.SelectedIndexChanged += new System.EventHandler(this.cbBinaryConversion_SelectedIndexChanged);
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(840, 7);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(80, 23);
            this.label36.TabIndex = 31;
            this.label36.Text = "BinConversion";
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Location = new System.Drawing.Point(658, 31);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(85, 23);
            this.btnClearOutput.TabIndex = 30;
            this.btnClearOutput.Text = "Clear Output";
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
            // 
            // chkAsync
            // 
            this.chkAsync.Location = new System.Drawing.Point(523, 56);
            this.chkAsync.Name = "chkAsync";
            this.chkAsync.Size = new System.Drawing.Size(92, 24);
            this.chkAsync.TabIndex = 27;
            this.chkAsync.Text = "Async Mode";
            this.chkAsync.CheckedChanged += new System.EventHandler(this.chkAsync_CheckedChanged);
            // 
            // chkDeviceEnabled
            // 
            this.chkDeviceEnabled.Location = new System.Drawing.Point(412, 8);
            this.chkDeviceEnabled.Name = "chkDeviceEnabled";
            this.chkDeviceEnabled.Size = new System.Drawing.Size(104, 24);
            this.chkDeviceEnabled.TabIndex = 25;
            this.chkDeviceEnabled.Text = "DeviceEnabled";
            this.chkDeviceEnabled.CheckedChanged += new System.EventHandler(this.chkDeviceEnabled_CheckedChanged);
            // 
            // chkFreezeEvents
            // 
            this.chkFreezeEvents.Location = new System.Drawing.Point(412, 32);
            this.chkFreezeEvents.Name = "chkFreezeEvents";
            this.chkFreezeEvents.Size = new System.Drawing.Size(93, 24);
            this.chkFreezeEvents.TabIndex = 23;
            this.chkFreezeEvents.Text = "FreezeEvents";
            this.chkFreezeEvents.CheckedChanged += new System.EventHandler(this.chkFreezeEvents_CheckedChanged);
            // 
            // chkAutoDisable
            // 
            this.chkAutoDisable.Location = new System.Drawing.Point(523, 32);
            this.chkAutoDisable.Name = "chkAutoDisable";
            this.chkAutoDisable.Size = new System.Drawing.Size(84, 24);
            this.chkAutoDisable.TabIndex = 26;
            this.chkAutoDisable.Text = "AutoDisable";
            this.chkAutoDisable.CheckedChanged += new System.EventHandler(this.chkAutoDisable_CheckedChanged);
            // 
            // chkDataEventEnabled
            // 
            this.chkDataEventEnabled.Location = new System.Drawing.Point(523, 8);
            this.chkDataEventEnabled.Name = "chkDataEventEnabled";
            this.chkDataEventEnabled.Size = new System.Drawing.Size(120, 24);
            this.chkDataEventEnabled.TabIndex = 24;
            this.chkDataEventEnabled.Text = "DataEventEnabled";
            this.chkDataEventEnabled.CheckedChanged += new System.EventHandler(this.chkDataEventEnabled_CheckedChanged);
            // 
            // btnClearInput
            // 
            this.btnClearInput.Location = new System.Drawing.Point(658, 6);
            this.btnClearInput.Name = "btnClearInput";
            this.btnClearInput.Size = new System.Drawing.Size(85, 23);
            this.btnClearInput.TabIndex = 22;
            this.btnClearInput.Text = "Clear Input";
            this.btnClearInput.Click += new System.EventHandler(this.btnClearInput_Click);
            // 
            // cbCompatibilityLevel
            // 
            this.cbCompatibilityLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompatibilityLevel.ItemHeight = 13;
            this.cbCompatibilityLevel.Location = new System.Drawing.Point(82, 14);
            this.cbCompatibilityLevel.Name = "cbCompatibilityLevel";
            this.cbCompatibilityLevel.Size = new System.Drawing.Size(171, 21);
            this.cbCompatibilityLevel.TabIndex = 41;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 503);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.sbpState,
            this.sbpDataEventsEnabled,
            this.sbpDataCount});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1037, 22);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 22;
            this.statusBar1.Text = "statusBar1";
            // 
            // sbpState
            // 
            this.sbpState.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.sbpState.Name = "sbpState";
            this.sbpState.Width = 345;
            // 
            // sbpDataEventsEnabled
            // 
            this.sbpDataEventsEnabled.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.sbpDataEventsEnabled.Name = "sbpDataEventsEnabled";
            this.sbpDataEventsEnabled.Width = 345;
            // 
            // sbpDataCount
            // 
            this.sbpDataCount.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.sbpDataCount.Name = "sbpDataCount";
            this.sbpDataCount.Width = 345;
            // 
            // btnClearResults
            // 
            this.btnClearResults.Location = new System.Drawing.Point(283, 57);
            this.btnClearResults.Name = "btnClearResults";
            this.btnClearResults.Size = new System.Drawing.Size(102, 23);
            this.btnClearResults.TabIndex = 57;
            this.btnClearResults.Text = "Clear Results";
            this.btnClearResults.Click += new System.EventHandler(this.btnClearResults_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1037, 525);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Output);
            this.Name = "MainForm";
            this.Text = "Microsoft POS Tester";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sbpState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpDataEventsEnabled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpDataCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void btnClearResults_Click(object sender, EventArgs e)
        {
            Output.Text = "";
        }

        

    }
}
