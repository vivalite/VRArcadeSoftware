namespace ManagingSystem
{
    partial class ManagerFeatures
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn4 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Client Machine Name");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn5 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Status");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn6 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Time Left");
            this.radListViewClientList = new Telerik.WinControls.UI.RadListView();
            this.radButtonSelectNone = new Telerik.WinControls.UI.RadButton();
            this.radButtonSelectAll = new Telerik.WinControls.UI.RadButton();
            this.radButtonSelectReverse = new Telerik.WinControls.UI.RadButton();
            this.radButtonStartSessionNonTimed = new Telerik.WinControls.UI.RadButton();
            this.radButtonStartSessionTimed = new Telerik.WinControls.UI.RadButton();
            this.radSpinEditorSessionTime = new Telerik.WinControls.UI.RadSpinEditor();
            this.radButtonEndSession = new Telerik.WinControls.UI.RadButton();
            this.radButtonMore = new Telerik.WinControls.UI.RadButton();
            this.radPanelMore = new Telerik.WinControls.UI.RadPanel();
            this.radButtonComputerTurnOff = new Telerik.WinControls.UI.RadButton();
            this.radButtonUSBOn = new Telerik.WinControls.UI.RadButton();
            this.radButtonUSBOff = new Telerik.WinControls.UI.RadButton();
            this.radButtonComputerReboot = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radButtonMarkClean = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radButtonClose = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radListViewClientList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonSelectNone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonSelectAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonSelectReverse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonStartSessionNonTimed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonStartSessionTimed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSpinEditorSessionTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonEndSession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonMore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanelMore)).BeginInit();
            this.radPanelMore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonComputerTurnOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonUSBOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonUSBOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonComputerReboot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonMarkClean)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radListViewClientList
            // 
            listViewDetailColumn4.HeaderText = "Client Machine Name";
            listViewDetailColumn5.HeaderText = "Status";
            listViewDetailColumn6.HeaderText = "Time Left";
            this.radListViewClientList.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn4,
            listViewDetailColumn5,
            listViewDetailColumn6});
            this.radListViewClientList.ItemSpacing = -1;
            this.radListViewClientList.Location = new System.Drawing.Point(12, 12);
            this.radListViewClientList.Name = "radListViewClientList";
            this.radListViewClientList.Size = new System.Drawing.Size(730, 389);
            this.radListViewClientList.TabIndex = 1;
            this.radListViewClientList.Text = "radListView1";
            this.radListViewClientList.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.radListViewClientList.ItemMouseClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.radListViewClientList_ItemMouseClick);
            // 
            // radButtonSelectNone
            // 
            this.radButtonSelectNone.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonSelectNone.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButtonSelectNone.Location = new System.Drawing.Point(12, 442);
            this.radButtonSelectNone.Name = "radButtonSelectNone";
            this.radButtonSelectNone.Size = new System.Drawing.Size(82, 38);
            this.radButtonSelectNone.TabIndex = 2;
            this.radButtonSelectNone.Text = "Select None";
            this.radButtonSelectNone.Click += new System.EventHandler(this.radButtonSelectNone_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectNone.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectNone.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectNone.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectNone.GetChildAt(0))).Text = "Select None";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectNone.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectNone.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectNone.GetChildAt(0).GetChildAt(1).GetChildAt(0))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectNone.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(30, 30);
            // 
            // radButtonSelectAll
            // 
            this.radButtonSelectAll.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonSelectAll.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButtonSelectAll.Location = new System.Drawing.Point(100, 442);
            this.radButtonSelectAll.Name = "radButtonSelectAll";
            this.radButtonSelectAll.Size = new System.Drawing.Size(82, 38);
            this.radButtonSelectAll.TabIndex = 3;
            this.radButtonSelectAll.Text = "Select All";
            this.radButtonSelectAll.Click += new System.EventHandler(this.radButtonSelectAll_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectAll.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectAll.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectAll.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectAll.GetChildAt(0))).Text = "Select All";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectAll.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectAll.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectAll.GetChildAt(0).GetChildAt(1).GetChildAt(0))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectAll.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(30, 30);
            // 
            // radButtonSelectReverse
            // 
            this.radButtonSelectReverse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonSelectReverse.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButtonSelectReverse.Location = new System.Drawing.Point(188, 442);
            this.radButtonSelectReverse.Name = "radButtonSelectReverse";
            this.radButtonSelectReverse.Size = new System.Drawing.Size(106, 38);
            this.radButtonSelectReverse.TabIndex = 4;
            this.radButtonSelectReverse.Text = "Select Reverse";
            this.radButtonSelectReverse.Click += new System.EventHandler(this.radButtonSelectReverse_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectReverse.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectReverse.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectReverse.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectReverse.GetChildAt(0))).Text = "Select Reverse";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectReverse.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectReverse.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectReverse.GetChildAt(0).GetChildAt(1).GetChildAt(0))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectReverse.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(30, 30);
            // 
            // radButtonStartSessionNonTimed
            // 
            this.radButtonStartSessionNonTimed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonStartSessionNonTimed.Image = global::ManagingSystem.Properties.Resources.Renew;
            this.radButtonStartSessionNonTimed.Location = new System.Drawing.Point(521, 487);
            this.radButtonStartSessionNonTimed.Name = "radButtonStartSessionNonTimed";
            this.radButtonStartSessionNonTimed.Size = new System.Drawing.Size(221, 38);
            this.radButtonStartSessionNonTimed.TabIndex = 7;
            this.radButtonStartSessionNonTimed.Text = "Start Non-Timed Session(s)";
            this.radButtonStartSessionNonTimed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButtonStartSessionNonTimed.Click += new System.EventHandler(this.radButtonStartSessionNonTimed_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonStartSessionNonTimed.GetChildAt(0))).Image = global::ManagingSystem.Properties.Resources.Renew;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonStartSessionNonTimed.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonStartSessionNonTimed.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonStartSessionNonTimed.GetChildAt(0))).Text = "Start Non-Timed Session(s)";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonStartSessionNonTimed.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonStartSessionNonTimed.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonStartSessionNonTimed.GetChildAt(0).GetChildAt(1).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonStartSessionNonTimed.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonStartSessionNonTimed.GetChildAt(0).GetChildAt(1).GetChildAt(0))).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.Auto;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonStartSessionNonTimed.GetChildAt(0).GetChildAt(1).GetChildAt(0))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonStartSessionNonTimed.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(25, 25);
            // 
            // radButtonStartSessionTimed
            // 
            this.radButtonStartSessionTimed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonStartSessionTimed.Image = global::ManagingSystem.Properties.Resources.Alarm;
            this.radButtonStartSessionTimed.Location = new System.Drawing.Point(521, 442);
            this.radButtonStartSessionTimed.Name = "radButtonStartSessionTimed";
            this.radButtonStartSessionTimed.Size = new System.Drawing.Size(167, 38);
            this.radButtonStartSessionTimed.TabIndex = 5;
            this.radButtonStartSessionTimed.Text = "Start Timed Session(s)";
            this.radButtonStartSessionTimed.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radButtonStartSessionTimed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButtonStartSessionTimed.Click += new System.EventHandler(this.radButtonStartSessionTimed_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonStartSessionTimed.GetChildAt(0))).Image = global::ManagingSystem.Properties.Resources.Alarm;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonStartSessionTimed.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonStartSessionTimed.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonStartSessionTimed.GetChildAt(0))).Text = "Start Timed Session(s)";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonStartSessionTimed.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonStartSessionTimed.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonStartSessionTimed.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonStartSessionTimed.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(25, 25);
            // 
            // radSpinEditorSessionTime
            // 
            this.radSpinEditorSessionTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSpinEditorSessionTime.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.radSpinEditorSessionTime.Location = new System.Drawing.Point(694, 443);
            this.radSpinEditorSessionTime.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.radSpinEditorSessionTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.radSpinEditorSessionTime.Name = "radSpinEditorSessionTime";
            this.radSpinEditorSessionTime.Size = new System.Drawing.Size(48, 23);
            this.radSpinEditorSessionTime.TabIndex = 6;
            this.radSpinEditorSessionTime.TabStop = false;
            this.radSpinEditorSessionTime.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.radSpinEditorSessionTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radSpinEditorSessionTime_MouseDown);
            ((Telerik.WinControls.UI.RadSpinElement)(this.radSpinEditorSessionTime.GetChildAt(0))).StretchVertically = true;
            ((Telerik.WinControls.UI.RadSpinElement)(this.radSpinEditorSessionTime.GetChildAt(0))).StretchHorizontally = true;
            ((Telerik.WinControls.UI.StackLayoutElement)(this.radSpinEditorSessionTime.GetChildAt(0).GetChildAt(2))).Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // radButtonEndSession
            // 
            this.radButtonEndSession.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonEndSession.Image = global::ManagingSystem.Properties.Resources.Stop;
            this.radButtonEndSession.Location = new System.Drawing.Point(521, 532);
            this.radButtonEndSession.Name = "radButtonEndSession";
            this.radButtonEndSession.Size = new System.Drawing.Size(221, 38);
            this.radButtonEndSession.TabIndex = 8;
            this.radButtonEndSession.Text = "Manual End Session(s)   ";
            this.radButtonEndSession.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButtonEndSession.Click += new System.EventHandler(this.radButtonEndSession_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonEndSession.GetChildAt(0))).Image = global::ManagingSystem.Properties.Resources.Stop;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonEndSession.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonEndSession.GetChildAt(0))).Text = "Manual End Session(s)   ";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonEndSession.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonEndSession.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonEndSession.GetChildAt(0).GetChildAt(1).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonEndSession.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonEndSession.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(30, 30);
            // 
            // radButtonMore
            // 
            this.radButtonMore.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonMore.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButtonMore.Location = new System.Drawing.Point(12, 532);
            this.radButtonMore.Name = "radButtonMore";
            this.radButtonMore.Size = new System.Drawing.Size(111, 38);
            this.radButtonMore.TabIndex = 9;
            this.radButtonMore.Text = "More Features...";
            this.radButtonMore.Click += new System.EventHandler(this.radButtonMore_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonMore.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonMore.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonMore.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonMore.GetChildAt(0))).Text = "More Features...";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonMore.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonMore.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonMore.GetChildAt(0).GetChildAt(1).GetChildAt(0))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonMore.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(30, 30);
            // 
            // radPanelMore
            // 
            this.radPanelMore.AutoSize = true;
            this.radPanelMore.Controls.Add(this.radButtonComputerTurnOff);
            this.radPanelMore.Controls.Add(this.radButtonUSBOn);
            this.radPanelMore.Controls.Add(this.radButtonUSBOff);
            this.radPanelMore.Controls.Add(this.radButtonComputerReboot);
            this.radPanelMore.Location = new System.Drawing.Point(8, 485);
            this.radPanelMore.Name = "radPanelMore";
            this.radPanelMore.Size = new System.Drawing.Size(507, 97);
            this.radPanelMore.TabIndex = 42;
            this.radPanelMore.Visible = false;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanelMore.GetChildAt(0).GetChildAt(1))).Width = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanelMore.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanelMore.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanelMore.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanelMore.GetChildAt(0).GetChildAt(1))).BottomWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanelMore.GetChildAt(0).GetChildAt(1))).Enabled = true;
            // 
            // radButtonComputerTurnOff
            // 
            this.radButtonComputerTurnOff.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonComputerTurnOff.Image = global::ManagingSystem.Properties.Resources.Shutdown;
            this.radButtonComputerTurnOff.Location = new System.Drawing.Point(279, 47);
            this.radButtonComputerTurnOff.Name = "radButtonComputerTurnOff";
            this.radButtonComputerTurnOff.Size = new System.Drawing.Size(175, 38);
            this.radButtonComputerTurnOff.TabIndex = 13;
            this.radButtonComputerTurnOff.Text = "Turn Off Computer(s)";
            this.radButtonComputerTurnOff.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radButtonComputerTurnOff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButtonComputerTurnOff.Click += new System.EventHandler(this.radButtonComputerTurnOff_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonComputerTurnOff.GetChildAt(0))).Image = global::ManagingSystem.Properties.Resources.Shutdown;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonComputerTurnOff.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonComputerTurnOff.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonComputerTurnOff.GetChildAt(0))).Text = "Turn Off Computer(s)";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonComputerTurnOff.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonComputerTurnOff.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonComputerTurnOff.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonComputerTurnOff.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(30, 30);
            // 
            // radButtonUSBOn
            // 
            this.radButtonUSBOn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonUSBOn.Image = global::ManagingSystem.Properties.Resources.Computer_Hardware_Usb_Off;
            this.radButtonUSBOn.Location = new System.Drawing.Point(4, 3);
            this.radButtonUSBOn.Name = "radButtonUSBOn";
            this.radButtonUSBOn.Size = new System.Drawing.Size(218, 38);
            this.radButtonUSBOn.TabIndex = 10;
            this.radButtonUSBOn.Text = "Turn On KB/Mouse/USB Drive";
            this.radButtonUSBOn.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radButtonUSBOn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButtonUSBOn.Click += new System.EventHandler(this.radButtonUSBOn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonUSBOn.GetChildAt(0))).Image = global::ManagingSystem.Properties.Resources.Computer_Hardware_Usb_Off;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonUSBOn.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonUSBOn.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonUSBOn.GetChildAt(0))).Text = "Turn On KB/Mouse/USB Drive";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonUSBOn.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonUSBOn.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonUSBOn.GetChildAt(0).GetChildAt(1).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonUSBOn.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonUSBOn.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(26, 26);
            // 
            // radButtonUSBOff
            // 
            this.radButtonUSBOff.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonUSBOff.Image = global::ManagingSystem.Properties.Resources.Computer_Hardware_Usb_Disconnected;
            this.radButtonUSBOff.Location = new System.Drawing.Point(4, 47);
            this.radButtonUSBOff.Name = "radButtonUSBOff";
            this.radButtonUSBOff.Size = new System.Drawing.Size(218, 38);
            this.radButtonUSBOff.TabIndex = 11;
            this.radButtonUSBOff.Text = "Turn Off KB/Mouse/USB Drive";
            this.radButtonUSBOff.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radButtonUSBOff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButtonUSBOff.Click += new System.EventHandler(this.radButtonUSBOff_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonUSBOff.GetChildAt(0))).Image = global::ManagingSystem.Properties.Resources.Computer_Hardware_Usb_Disconnected;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonUSBOff.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonUSBOff.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonUSBOff.GetChildAt(0))).Text = "Turn Off KB/Mouse/USB Drive";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonUSBOff.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonUSBOff.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonUSBOff.GetChildAt(0).GetChildAt(1).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonUSBOff.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonUSBOff.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(26, 26);
            // 
            // radButtonComputerReboot
            // 
            this.radButtonComputerReboot.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonComputerReboot.Image = global::ManagingSystem.Properties.Resources.Reboot;
            this.radButtonComputerReboot.Location = new System.Drawing.Point(279, 3);
            this.radButtonComputerReboot.Name = "radButtonComputerReboot";
            this.radButtonComputerReboot.Size = new System.Drawing.Size(175, 38);
            this.radButtonComputerReboot.TabIndex = 12;
            this.radButtonComputerReboot.Text = "Reboot Computer(s)";
            this.radButtonComputerReboot.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radButtonComputerReboot.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButtonComputerReboot.Click += new System.EventHandler(this.radButtonComputerReboot_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonComputerReboot.GetChildAt(0))).Image = global::ManagingSystem.Properties.Resources.Reboot;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonComputerReboot.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonComputerReboot.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonComputerReboot.GetChildAt(0))).Text = "Reboot Computer(s)";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonComputerReboot.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonComputerReboot.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonComputerReboot.GetChildAt(0).GetChildAt(1).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonComputerReboot.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonComputerReboot.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(30, 30);
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Location = new System.Drawing.Point(701, 466);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(32, 18);
            this.radLabel1.TabIndex = 43;
            this.radLabel1.Text = "(Min)";
            // 
            // radButtonMarkClean
            // 
            this.radButtonMarkClean.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonMarkClean.Location = new System.Drawing.Point(333, 442);
            this.radButtonMarkClean.Name = "radButtonMarkClean";
            this.radButtonMarkClean.Size = new System.Drawing.Size(147, 38);
            this.radButtonMarkClean.TabIndex = 44;
            this.radButtonMarkClean.Text = "Mark As Cleaned";
            this.radButtonMarkClean.Click += new System.EventHandler(this.radButtonMarkClean_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonMarkClean.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonMarkClean.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonMarkClean.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonMarkClean.GetChildAt(0))).Text = "Mark As Cleaned";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonMarkClean.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonMarkClean.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonMarkClean.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonMarkClean.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(25, 25);
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.radLabel2.Location = new System.Drawing.Point(12, 407);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(730, 29);
            this.radLabel2.TabIndex = 45;
            this.radLabel2.Text = "<html><span style=\"font-size: 12pt\">Please Note: This feature is designed for pro" +
    "blem fixing. Use Process Waiver to issue tickets instetad.</span></html>";
            // 
            // radButtonClose
            // 
            this.radButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.radButtonClose.Location = new System.Drawing.Point(642, 0);
            this.radButtonClose.Name = "radButtonClose";
            this.radButtonClose.Size = new System.Drawing.Size(110, 24);
            this.radButtonClose.TabIndex = 46;
            this.radButtonClose.Text = "Close";
            this.radButtonClose.Visible = false;
            this.radButtonClose.Click += new System.EventHandler(this.radButtonClose_Click);
            // 
            // ManagerFeatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.radButtonClose;
            this.ClientSize = new System.Drawing.Size(754, 578);
            this.Controls.Add(this.radButtonClose);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radButtonMarkClean);
            this.Controls.Add(this.radSpinEditorSessionTime);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radPanelMore);
            this.Controls.Add(this.radButtonMore);
            this.Controls.Add(this.radButtonEndSession);
            this.Controls.Add(this.radButtonStartSessionNonTimed);
            this.Controls.Add(this.radButtonStartSessionTimed);
            this.Controls.Add(this.radButtonSelectReverse);
            this.Controls.Add(this.radButtonSelectAll);
            this.Controls.Add(this.radButtonSelectNone);
            this.Controls.Add(this.radListViewClientList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManagerFeatures";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manager Features";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManagerFeatures_FormClosed);
            this.Load += new System.EventHandler(this.ManagerFeatures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radListViewClientList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonSelectNone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonSelectAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonSelectReverse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonStartSessionNonTimed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonStartSessionTimed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSpinEditorSessionTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonEndSession)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonMore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanelMore)).EndInit();
            this.radPanelMore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButtonComputerTurnOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonUSBOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonUSBOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonComputerReboot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonMarkClean)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadListView radListViewClientList;
        private Telerik.WinControls.UI.RadButton radButtonSelectNone;
        private Telerik.WinControls.UI.RadButton radButtonSelectAll;
        private Telerik.WinControls.UI.RadButton radButtonSelectReverse;
        private Telerik.WinControls.UI.RadButton radButtonStartSessionNonTimed;
        private Telerik.WinControls.UI.RadButton radButtonStartSessionTimed;
        private Telerik.WinControls.UI.RadSpinEditor radSpinEditorSessionTime;
        private Telerik.WinControls.UI.RadButton radButtonEndSession;
        private Telerik.WinControls.UI.RadButton radButtonMore;
        private Telerik.WinControls.UI.RadPanel radPanelMore;
        private Telerik.WinControls.UI.RadButton radButtonUSBOff;
        private Telerik.WinControls.UI.RadButton radButtonComputerReboot;
        private Telerik.WinControls.UI.RadButton radButtonUSBOn;
        private Telerik.WinControls.UI.RadButton radButtonComputerTurnOff;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton radButtonMarkClean;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton radButtonClose;
    }
}
