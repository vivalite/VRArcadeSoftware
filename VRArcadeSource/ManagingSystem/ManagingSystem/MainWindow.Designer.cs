namespace ManagingSystem
{
    partial class MainWindow
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
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn1 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Icon");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn2 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Name");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn3 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Mode");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn4 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 3", "Status");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn5 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 4", "Left / Pass");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn6 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 5", "Help Needed");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.radButtonOptions = new Telerik.WinControls.UI.RadButton();
            this.radLayoutControl = new Telerik.WinControls.UI.RadLayoutControl();
            this.radCardViewMain = new Telerik.WinControls.UI.RadCardView();
            this.cardViewItem16 = new Telerik.WinControls.UI.CardViewItem();
            this.cardViewItem17 = new Telerik.WinControls.UI.CardViewItem();
            this.cardViewItem18 = new Telerik.WinControls.UI.CardViewItem();
            this.cardViewItem19 = new Telerik.WinControls.UI.CardViewItem();
            this.cardViewItem20 = new Telerik.WinControls.UI.CardViewItem();
            this.cardViewItem21 = new Telerik.WinControls.UI.CardViewItem();
            this.layoutControlItem1 = new Telerik.WinControls.UI.LayoutControlItem();
            this.radButtonManager = new Telerik.WinControls.UI.RadButton();
            this.radStatusStripMain = new Telerik.WinControls.UI.RadStatusStrip();
            this.radLabelElementCurrTime = new Telerik.WinControls.UI.RadLabelElement();
            this.radLabelElementSpacer = new Telerik.WinControls.UI.RadLabelElement();
            this.radLabelElementRefresh = new Telerik.WinControls.UI.RadLabelElement();
            this.radButtonAbout = new Telerik.WinControls.UI.RadButton();
            this.radButtonEmergency = new Telerik.WinControls.UI.RadButton();
            this.radButtonPrintBarcode = new Telerik.WinControls.UI.RadButton();
            this.radButtonWaiverProcess = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLayoutControl)).BeginInit();
            this.radLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCardViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCardViewMain.CardTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStripMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonAbout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonEmergency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonPrintBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonWaiverProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radButtonOptions
            // 
            this.radButtonOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radButtonOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonOptions.Image = global::ManagingSystem.Properties.Resources.Gear;
            this.radButtonOptions.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButtonOptions.Location = new System.Drawing.Point(136, 470);
            this.radButtonOptions.Name = "radButtonOptions";
            this.radButtonOptions.Size = new System.Drawing.Size(113, 41);
            this.radButtonOptions.TabIndex = 4;
            this.radButtonOptions.Text = "Options";
            this.radButtonOptions.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radButtonOptions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButtonOptions.Click += new System.EventHandler(this.radButtonOptions_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonOptions.GetChildAt(0))).Image = global::ManagingSystem.Properties.Resources.Gear;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonOptions.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonOptions.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonOptions.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonOptions.GetChildAt(0))).Text = "Options";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonOptions.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonOptions.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonOptions.GetChildAt(0).GetChildAt(1).GetChildAt(0))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonOptions.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(30, 30);
            // 
            // radLayoutControl
            // 
            this.radLayoutControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radLayoutControl.Controls.Add(this.radCardViewMain);
            this.radLayoutControl.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.layoutControlItem1});
            this.radLayoutControl.Location = new System.Drawing.Point(1, 4);
            this.radLayoutControl.Name = "radLayoutControl";
            this.radLayoutControl.Size = new System.Drawing.Size(1012, 459);
            this.radLayoutControl.TabIndex = 31;
            // 
            // radCardViewMain
            // 
            // 
            // 
            // 
            this.radCardViewMain.CardTemplate.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.cardViewItem16,
            this.cardViewItem17,
            this.cardViewItem18,
            this.cardViewItem19,
            this.cardViewItem20,
            this.cardViewItem21});
            this.radCardViewMain.CardTemplate.Location = new System.Drawing.Point(430, 113);
            this.radCardViewMain.CardTemplate.Name = "radCardViewMainTemplate";
            this.radCardViewMain.CardTemplate.Size = new System.Drawing.Size(150, 230);
            this.radCardViewMain.CardTemplate.TabIndex = 0;
            listViewDetailColumn1.HeaderText = "Icon";
            listViewDetailColumn2.HeaderText = "Name";
            listViewDetailColumn3.HeaderText = "Mode";
            listViewDetailColumn4.HeaderText = "Status";
            listViewDetailColumn5.HeaderText = "Left / Pass";
            listViewDetailColumn6.HeaderText = "Help Needed";
            this.radCardViewMain.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn1,
            listViewDetailColumn2,
            listViewDetailColumn3,
            listViewDetailColumn4,
            listViewDetailColumn5,
            listViewDetailColumn6});
            this.radCardViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radCardViewMain.Enabled = false;
            this.radCardViewMain.ItemSize = new System.Drawing.Size(150, 230);
            this.radCardViewMain.Location = new System.Drawing.Point(3, 3);
            this.radCardViewMain.Name = "radCardViewMain";
            this.radCardViewMain.Size = new System.Drawing.Size(1006, 453);
            this.radCardViewMain.TabIndex = 1;
            this.radCardViewMain.CardViewItemFormatting += new Telerik.WinControls.UI.CardViewItemFormattingEventHandler(this.radCardViewMain_CardViewItemFormatting);
            this.radCardViewMain.ItemMouseClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.radCardViewMain_ItemMouseClick);
            this.radCardViewMain.ItemMouseDoubleClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.radCardViewMain_ItemMouseDoubleClick);
            this.radCardViewMain.VisualItemFormatting += new Telerik.WinControls.UI.ListViewVisualItemEventHandler(this.radCardViewMain_VisualItemFormatting);
            // 
            // cardViewItem16
            // 
            this.cardViewItem16.Bounds = new System.Drawing.Rectangle(0, 0, 150, 96);
            this.cardViewItem16.FieldName = "Column 0";
            this.cardViewItem16.MinSize = new System.Drawing.Size(26, 96);
            this.cardViewItem16.Name = "cardViewItem16";
            this.cardViewItem16.Text = "Column 0";
            this.cardViewItem16.TextProportionalSize = 0F;
            // 
            // cardViewItem17
            // 
            this.cardViewItem17.Bounds = new System.Drawing.Rectangle(0, 96, 150, 26);
            this.cardViewItem17.FieldName = "Column 1";
            this.cardViewItem17.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cardViewItem17.Name = "cardViewItem17";
            this.cardViewItem17.Text = "Column 1";
            this.cardViewItem17.TextWrap = false;
            // 
            // cardViewItem18
            // 
            this.cardViewItem18.Bounds = new System.Drawing.Rectangle(0, 122, 150, 26);
            this.cardViewItem18.FieldName = "Column 2";
            this.cardViewItem18.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cardViewItem18.Name = "cardViewItem18";
            this.cardViewItem18.Text = "Column 2";
            this.cardViewItem18.TextWrap = false;
            // 
            // cardViewItem19
            // 
            this.cardViewItem19.Bounds = new System.Drawing.Rectangle(0, 148, 150, 26);
            this.cardViewItem19.FieldName = "Column 3";
            this.cardViewItem19.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cardViewItem19.Name = "cardViewItem19";
            this.cardViewItem19.Text = "Column 3";
            // 
            // cardViewItem20
            // 
            this.cardViewItem20.Bounds = new System.Drawing.Rectangle(0, 174, 150, 26);
            this.cardViewItem20.FieldName = "Column 4";
            this.cardViewItem20.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cardViewItem20.Name = "cardViewItem20";
            this.cardViewItem20.Text = "Column 4";
            // 
            // cardViewItem21
            // 
            this.cardViewItem21.Bounds = new System.Drawing.Rectangle(0, 200, 150, 30);
            this.cardViewItem21.FieldName = "Column 5";
            this.cardViewItem21.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cardViewItem21.Name = "cardViewItem21";
            this.cardViewItem21.Text = "Column 5";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AssociatedControl = this.radCardViewMain;
            this.layoutControlItem1.Bounds = new System.Drawing.Rectangle(0, 0, 1012, 459);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Text = "radCardView1";
            // 
            // radButtonManager
            // 
            this.radButtonManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radButtonManager.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonManager.Image = global::ManagingSystem.Properties.Resources.Admin;
            this.radButtonManager.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButtonManager.Location = new System.Drawing.Point(857, 470);
            this.radButtonManager.Name = "radButtonManager";
            this.radButtonManager.Size = new System.Drawing.Size(154, 41);
            this.radButtonManager.TabIndex = 6;
            this.radButtonManager.Text = "Manager Features";
            this.radButtonManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButtonManager.Click += new System.EventHandler(this.radButtonManager_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonManager.GetChildAt(0))).Image = global::ManagingSystem.Properties.Resources.Admin;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonManager.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonManager.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonManager.GetChildAt(0))).Text = "Manager Features";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonManager.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonManager.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonManager.GetChildAt(0).GetChildAt(1).GetChildAt(0))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonManager.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(30, 30);
            // 
            // radStatusStripMain
            // 
            this.radStatusStripMain.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radLabelElementCurrTime,
            this.radLabelElementSpacer,
            this.radLabelElementRefresh});
            this.radStatusStripMain.Location = new System.Drawing.Point(0, 515);
            this.radStatusStripMain.Name = "radStatusStripMain";
            this.radStatusStripMain.Size = new System.Drawing.Size(1016, 26);
            this.radStatusStripMain.TabIndex = 33;
            // 
            // radLabelElementCurrTime
            // 
            this.radLabelElementCurrTime.Name = "radLabelElementCurrTime";
            this.radStatusStripMain.SetSpring(this.radLabelElementCurrTime, false);
            this.radLabelElementCurrTime.Text = "Current Time";
            this.radLabelElementCurrTime.TextWrap = true;
            // 
            // radLabelElementSpacer
            // 
            this.radLabelElementSpacer.Alignment = System.Drawing.ContentAlignment.MiddleRight;
            this.radLabelElementSpacer.Name = "radLabelElementSpacer";
            this.radStatusStripMain.SetSpring(this.radLabelElementSpacer, true);
            this.radLabelElementSpacer.Text = "";
            this.radLabelElementSpacer.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.radLabelElementSpacer.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.radLabelElementSpacer.TextWrap = true;
            // 
            // radLabelElementRefresh
            // 
            this.radLabelElementRefresh.Name = "radLabelElementRefresh";
            this.radStatusStripMain.SetSpring(this.radLabelElementRefresh, false);
            this.radLabelElementRefresh.Text = "Last Refresh in -- Seconds";
            this.radLabelElementRefresh.TextWrap = true;
            // 
            // radButtonAbout
            // 
            this.radButtonAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radButtonAbout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonAbout.Image = ((System.Drawing.Image)(resources.GetObject("radButtonAbout.Image")));
            this.radButtonAbout.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButtonAbout.Location = new System.Drawing.Point(83, 470);
            this.radButtonAbout.Name = "radButtonAbout";
            this.radButtonAbout.Size = new System.Drawing.Size(47, 41);
            this.radButtonAbout.TabIndex = 3;
            this.radButtonAbout.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radButtonAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButtonAbout.Click += new System.EventHandler(this.radButtonAbout_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonAbout.GetChildAt(0))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonAbout.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonAbout.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonAbout.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonAbout.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonAbout.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonAbout.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonAbout.GetChildAt(0).GetChildAt(1).GetChildAt(0))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonAbout.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(30, 30);
            // 
            // radButtonEmergency
            // 
            this.radButtonEmergency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radButtonEmergency.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonEmergency.Image = global::ManagingSystem.Properties.Resources.Emergency;
            this.radButtonEmergency.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButtonEmergency.Location = new System.Drawing.Point(5, 470);
            this.radButtonEmergency.Name = "radButtonEmergency";
            this.radButtonEmergency.Size = new System.Drawing.Size(72, 41);
            this.radButtonEmergency.TabIndex = 2;
            this.radButtonEmergency.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radButtonEmergency.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButtonEmergency.Click += new System.EventHandler(this.radButtonEmergency_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonEmergency.GetChildAt(0))).Image = global::ManagingSystem.Properties.Resources.Emergency;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonEmergency.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonEmergency.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonEmergency.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonEmergency.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonEmergency.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonEmergency.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonEmergency.GetChildAt(0).GetChildAt(1).GetChildAt(0))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonEmergency.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(49, 30);
            // 
            // radButtonPrintBarcode
            // 
            this.radButtonPrintBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radButtonPrintBarcode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonPrintBarcode.Image = global::ManagingSystem.Properties.Resources.Barcode;
            this.radButtonPrintBarcode.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButtonPrintBarcode.Location = new System.Drawing.Point(708, 470);
            this.radButtonPrintBarcode.Name = "radButtonPrintBarcode";
            this.radButtonPrintBarcode.Size = new System.Drawing.Size(143, 41);
            this.radButtonPrintBarcode.TabIndex = 5;
            this.radButtonPrintBarcode.Text = "Print Ticket(s)";
            this.radButtonPrintBarcode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radButtonPrintBarcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButtonPrintBarcode.Visible = false;
            this.radButtonPrintBarcode.Click += new System.EventHandler(this.radButtonPrintBarcode_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonPrintBarcode.GetChildAt(0))).Image = global::ManagingSystem.Properties.Resources.Barcode;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonPrintBarcode.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonPrintBarcode.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonPrintBarcode.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonPrintBarcode.GetChildAt(0))).Text = "Print Ticket(s)";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonPrintBarcode.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonPrintBarcode.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonPrintBarcode.GetChildAt(0).GetChildAt(1).GetChildAt(0))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonPrintBarcode.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(30, 30);
            // 
            // radButtonWaiverProcess
            // 
            this.radButtonWaiverProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radButtonWaiverProcess.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonWaiverProcess.Image = global::ManagingSystem.Properties.Resources.Checklist;
            this.radButtonWaiverProcess.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButtonWaiverProcess.Location = new System.Drawing.Point(559, 470);
            this.radButtonWaiverProcess.Name = "radButtonWaiverProcess";
            this.radButtonWaiverProcess.Size = new System.Drawing.Size(143, 41);
            this.radButtonWaiverProcess.TabIndex = 34;
            this.radButtonWaiverProcess.Text = "Process Waiver";
            this.radButtonWaiverProcess.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radButtonWaiverProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButtonWaiverProcess.Visible = false;
            this.radButtonWaiverProcess.Click += new System.EventHandler(this.radButtonWaiverProcess_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonWaiverProcess.GetChildAt(0))).Image = global::ManagingSystem.Properties.Resources.Checklist;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonWaiverProcess.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonWaiverProcess.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonWaiverProcess.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonWaiverProcess.GetChildAt(0))).Text = "Process Waiver";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonWaiverProcess.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonWaiverProcess.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonWaiverProcess.GetChildAt(0).GetChildAt(1).GetChildAt(0))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonWaiverProcess.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(30, 30);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 541);
            this.Controls.Add(this.radLayoutControl);
            this.Controls.Add(this.radButtonWaiverProcess);
            this.Controls.Add(this.radButtonPrintBarcode);
            this.Controls.Add(this.radButtonEmergency);
            this.Controls.Add(this.radButtonAbout);
            this.Controls.Add(this.radStatusStripMain);
            this.Controls.Add(this.radButtonManager);
            this.Controls.Add(this.radButtonOptions);
            this.MinimumSize = new System.Drawing.Size(792, 550);
            this.Name = "MainWindow";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virtual Reality Arcade Managing System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResizeEnd += new System.EventHandler(this.MainWindow_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.radButtonOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLayoutControl)).EndInit();
            this.radLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radCardViewMain.CardTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCardViewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStripMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonAbout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonEmergency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonPrintBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonWaiverProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadButton radButtonOptions;
        private Telerik.WinControls.UI.RadLayoutControl radLayoutControl;
        private Telerik.WinControls.UI.RadCardView radCardViewMain;
        private Telerik.WinControls.UI.LayoutControlItem layoutControlItem1;
        private Telerik.WinControls.UI.CardViewItem cardViewItem16;
        private Telerik.WinControls.UI.CardViewItem cardViewItem17;
        private Telerik.WinControls.UI.CardViewItem cardViewItem18;
        private Telerik.WinControls.UI.CardViewItem cardViewItem19;
        private Telerik.WinControls.UI.CardViewItem cardViewItem20;
        private Telerik.WinControls.UI.CardViewItem cardViewItem21;
        private Telerik.WinControls.UI.RadButton radButtonManager;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStripMain;
        private Telerik.WinControls.UI.RadButton radButtonAbout;
        private Telerik.WinControls.UI.RadButton radButtonEmergency;
        private Telerik.WinControls.UI.RadLabelElement radLabelElementCurrTime;
        private Telerik.WinControls.UI.RadLabelElement radLabelElementSpacer;
        private Telerik.WinControls.UI.RadLabelElement radLabelElementRefresh;
        private Telerik.WinControls.UI.RadButton radButtonPrintBarcode;
        private Telerik.WinControls.UI.RadButton radButtonWaiverProcess;
    }
}

