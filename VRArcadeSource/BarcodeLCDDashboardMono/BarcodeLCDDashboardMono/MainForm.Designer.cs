namespace BarcodeLCDDashboardMono
{
    partial class MainForm
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
            this.tableLayoutPanelInstVideo = new System.Windows.Forms.TableLayoutPanel();
            this.panelInstVideo = new System.Windows.Forms.Panel();
            this.buttonInstVideoYes = new GelButton();
            this.buttonInstVideoNo = new GelButton();
            this.panelInstVideoTop = new System.Windows.Forms.Panel();
            this.labelInstVideo = new System.Windows.Forms.Label();
            this.tableLayoutPanelReady = new System.Windows.Forms.TableLayoutPanel();
            this.labelReady = new System.Windows.Forms.Label();
            this.labelReady2 = new System.Windows.Forms.Label();
            this.tableLayoutPanelWaitingCleaning = new System.Windows.Forms.TableLayoutPanel();
            this.labelCleaning = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gelButtonCleaningDone = new GelButton();
            this.tableLayoutPanelUsing = new System.Windows.Forms.TableLayoutPanel();
            this.labelUsing = new System.Windows.Forms.Label();
            this.labelIPInfo = new System.Windows.Forms.Label();
            this.tableLayoutPanelHelpRequest = new System.Windows.Forms.TableLayoutPanel();
            this.panelHelpRequest = new System.Windows.Forms.Panel();
            this.gelButtonHelpProvided = new GelButton();
            this.labelHelpRequestCurrentPlaying = new System.Windows.Forms.Label();
            this.panelHelpRequestTop = new System.Windows.Forms.Panel();
            this.labelHelpRequested = new System.Windows.Forms.Label();
            this.tableLayoutPanelInstVideo.SuspendLayout();
            this.panelInstVideo.SuspendLayout();
            this.panelInstVideoTop.SuspendLayout();
            this.tableLayoutPanelReady.SuspendLayout();
            this.tableLayoutPanelWaitingCleaning.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanelUsing.SuspendLayout();
            this.tableLayoutPanelHelpRequest.SuspendLayout();
            this.panelHelpRequest.SuspendLayout();
            this.panelHelpRequestTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelInstVideo
            // 
            this.tableLayoutPanelInstVideo.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelInstVideo.ColumnCount = 3;
            this.tableLayoutPanelInstVideo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanelInstVideo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanelInstVideo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanelInstVideo.Controls.Add(this.panelInstVideo, 1, 1);
            this.tableLayoutPanelInstVideo.Controls.Add(this.panelInstVideoTop, 1, 0);
            this.tableLayoutPanelInstVideo.Font = new System.Drawing.Font("Eras Bold ITC", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanelInstVideo.Location = new System.Drawing.Point(30, 280);
            this.tableLayoutPanelInstVideo.Name = "tableLayoutPanelInstVideo";
            this.tableLayoutPanelInstVideo.RowCount = 3;
            this.tableLayoutPanelInstVideo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31F));
            this.tableLayoutPanelInstVideo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.25F));
            this.tableLayoutPanelInstVideo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.75F));
            this.tableLayoutPanelInstVideo.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanelInstVideo.TabIndex = 0;
            // 
            // panelInstVideo
            // 
            this.panelInstVideo.Controls.Add(this.buttonInstVideoYes);
            this.panelInstVideo.Controls.Add(this.buttonInstVideoNo);
            this.panelInstVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInstVideo.Location = new System.Drawing.Point(38, 34);
            this.panelInstVideo.MinimumSize = new System.Drawing.Size(437, 155);
            this.panelInstVideo.Name = "panelInstVideo";
            this.panelInstVideo.Size = new System.Drawing.Size(437, 155);
            this.panelInstVideo.TabIndex = 0;
            // 
            // buttonInstVideoYes
            // 
            this.buttonInstVideoYes.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonInstVideoYes.EnableFlashing = false;
            this.buttonInstVideoYes.Font = new System.Drawing.Font("Eras Bold ITC", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInstVideoYes.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonInstVideoYes.Location = new System.Drawing.Point(0, 0);
            this.buttonInstVideoYes.Name = "buttonInstVideoYes";
            this.buttonInstVideoYes.Size = new System.Drawing.Size(437, 91);
            this.buttonInstVideoYes.TabIndex = 1;
            this.buttonInstVideoYes.TabStop = false;
            this.buttonInstVideoYes.Text = "Yes";
            this.buttonInstVideoYes.UseVisualStyleBackColor = false;
            this.buttonInstVideoYes.Click += new System.EventHandler(this.buttonInstVideoYes_Click);
            // 
            // buttonInstVideoNo
            // 
            this.buttonInstVideoNo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonInstVideoNo.EnableFlashing = false;
            this.buttonInstVideoNo.Font = new System.Drawing.Font("Eras Bold ITC", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInstVideoNo.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonInstVideoNo.GradientBottom = System.Drawing.Color.GreenYellow;
            this.buttonInstVideoNo.GradientTop = System.Drawing.Color.SeaGreen;
            this.buttonInstVideoNo.Location = new System.Drawing.Point(0, 64);
            this.buttonInstVideoNo.Name = "buttonInstVideoNo";
            this.buttonInstVideoNo.Size = new System.Drawing.Size(437, 91);
            this.buttonInstVideoNo.TabIndex = 2;
            this.buttonInstVideoNo.Text = "No, Start Playing Now";
            this.buttonInstVideoNo.UseVisualStyleBackColor = false;
            this.buttonInstVideoNo.Click += new System.EventHandler(this.buttonInstVideoNo_Click);
            // 
            // panelInstVideoTop
            // 
            this.panelInstVideoTop.Controls.Add(this.labelInstVideo);
            this.panelInstVideoTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInstVideoTop.Location = new System.Drawing.Point(38, 3);
            this.panelInstVideoTop.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.panelInstVideoTop.Name = "panelInstVideoTop";
            this.panelInstVideoTop.Size = new System.Drawing.Size(124, 8);
            this.panelInstVideoTop.TabIndex = 1;
            // 
            // labelInstVideo
            // 
            this.labelInstVideo.BackColor = System.Drawing.Color.Transparent;
            this.labelInstVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInstVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelInstVideo.Font = new System.Drawing.Font("Eras Bold ITC", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstVideo.ForeColor = System.Drawing.Color.White;
            this.labelInstVideo.Location = new System.Drawing.Point(0, 0);
            this.labelInstVideo.Name = "labelInstVideo";
            this.labelInstVideo.Size = new System.Drawing.Size(124, 8);
            this.labelInstVideo.TabIndex = 2;
            this.labelInstVideo.Text = "Would You Like To See \r\nThe Instruction Video?";
            this.labelInstVideo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelInstVideo.UseCompatibleTextRendering = true;
            // 
            // tableLayoutPanelReady
            // 
            this.tableLayoutPanelReady.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelReady.ColumnCount = 3;
            this.tableLayoutPanelReady.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelReady.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelReady.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelReady.Controls.Add(this.labelReady, 1, 1);
            this.tableLayoutPanelReady.Controls.Add(this.labelReady2, 1, 2);
            this.tableLayoutPanelReady.Location = new System.Drawing.Point(255, 12);
            this.tableLayoutPanelReady.Name = "tableLayoutPanelReady";
            this.tableLayoutPanelReady.RowCount = 3;
            this.tableLayoutPanelReady.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelReady.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelReady.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelReady.Size = new System.Drawing.Size(214, 112);
            this.tableLayoutPanelReady.TabIndex = 1;
            // 
            // labelReady
            // 
            this.labelReady.AutoSize = true;
            this.labelReady.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelReady.Font = new System.Drawing.Font("Eras Bold ITC", 62.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReady.ForeColor = System.Drawing.Color.White;
            this.labelReady.Location = new System.Drawing.Point(45, 37);
            this.labelReady.Name = "labelReady";
            this.labelReady.Size = new System.Drawing.Size(122, 37);
            this.labelReady.TabIndex = 0;
            this.labelReady.Text = "READY!";
            this.labelReady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelReady2
            // 
            this.labelReady2.AutoSize = true;
            this.labelReady2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelReady2.Font = new System.Drawing.Font("Eras Bold ITC", 30F);
            this.labelReady2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.labelReady2.Location = new System.Drawing.Point(45, 74);
            this.labelReady2.Name = "labelReady2";
            this.labelReady2.Size = new System.Drawing.Size(122, 38);
            this.labelReady2.TabIndex = 1;
            this.labelReady2.Text = "Please scan your barcode below";
            this.labelReady2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelWaitingCleaning
            // 
            this.tableLayoutPanelWaitingCleaning.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelWaitingCleaning.ColumnCount = 3;
            this.tableLayoutPanelWaitingCleaning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelWaitingCleaning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelWaitingCleaning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelWaitingCleaning.Controls.Add(this.labelCleaning, 1, 1);
            this.tableLayoutPanelWaitingCleaning.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanelWaitingCleaning.Location = new System.Drawing.Point(515, 141);
            this.tableLayoutPanelWaitingCleaning.Name = "tableLayoutPanelWaitingCleaning";
            this.tableLayoutPanelWaitingCleaning.RowCount = 3;
            this.tableLayoutPanelWaitingCleaning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelWaitingCleaning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelWaitingCleaning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelWaitingCleaning.Size = new System.Drawing.Size(204, 115);
            this.tableLayoutPanelWaitingCleaning.TabIndex = 2;
            // 
            // labelCleaning
            // 
            this.labelCleaning.AutoSize = true;
            this.labelCleaning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCleaning.Font = new System.Drawing.Font("Eras Bold ITC", 48F);
            this.labelCleaning.ForeColor = System.Drawing.Color.LightYellow;
            this.labelCleaning.Location = new System.Drawing.Point(43, 38);
            this.labelCleaning.Name = "labelCleaning";
            this.labelCleaning.Size = new System.Drawing.Size(116, 38);
            this.labelCleaning.TabIndex = 0;
            this.labelCleaning.Text = "Waiting For Cleaning";
            this.labelCleaning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gelButtonCleaningDone);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(43, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(116, 33);
            this.panel1.TabIndex = 4;
            // 
            // gelButtonCleaningDone
            // 
            this.gelButtonCleaningDone.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gelButtonCleaningDone.EnableFlashing = false;
            this.gelButtonCleaningDone.Font = new System.Drawing.Font("Eras Bold ITC", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gelButtonCleaningDone.ForeColor = System.Drawing.Color.Transparent;
            this.gelButtonCleaningDone.GradientBottom = System.Drawing.Color.WhiteSmoke;
            this.gelButtonCleaningDone.GradientTop = System.Drawing.Color.Black;
            this.gelButtonCleaningDone.Location = new System.Drawing.Point(0, -47);
            this.gelButtonCleaningDone.Name = "gelButtonCleaningDone";
            this.gelButtonCleaningDone.Size = new System.Drawing.Size(116, 80);
            this.gelButtonCleaningDone.TabIndex = 3;
            this.gelButtonCleaningDone.Text = "Cleaning Done";
            this.gelButtonCleaningDone.UseVisualStyleBackColor = false;
            this.gelButtonCleaningDone.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gelButtonCleaningDone_MouseDown);
            this.gelButtonCleaningDone.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gelButtonCleaningDone_MouseUp);
            // 
            // tableLayoutPanelUsing
            // 
            this.tableLayoutPanelUsing.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelUsing.ColumnCount = 3;
            this.tableLayoutPanelUsing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelUsing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelUsing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelUsing.Controls.Add(this.labelUsing, 1, 1);
            this.tableLayoutPanelUsing.Location = new System.Drawing.Point(30, 141);
            this.tableLayoutPanelUsing.Name = "tableLayoutPanelUsing";
            this.tableLayoutPanelUsing.RowCount = 3;
            this.tableLayoutPanelUsing.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelUsing.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelUsing.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelUsing.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanelUsing.TabIndex = 3;
            // 
            // labelUsing
            // 
            this.labelUsing.AutoSize = true;
            this.labelUsing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUsing.Font = new System.Drawing.Font("Eras Bold ITC", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsing.ForeColor = System.Drawing.Color.LightYellow;
            this.labelUsing.Location = new System.Drawing.Point(43, 33);
            this.labelUsing.Name = "labelUsing";
            this.labelUsing.Size = new System.Drawing.Size(114, 33);
            this.labelUsing.TabIndex = 0;
            this.labelUsing.Text = "OCCUPIED";
            this.labelUsing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelIPInfo
            // 
            this.labelIPInfo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIPInfo.ForeColor = System.Drawing.Color.White;
            this.labelIPInfo.Location = new System.Drawing.Point(475, 12);
            this.labelIPInfo.Name = "labelIPInfo";
            this.labelIPInfo.Size = new System.Drawing.Size(62, 22);
            this.labelIPInfo.TabIndex = 4;
            this.labelIPInfo.Text = "IPInfo";
            this.labelIPInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelIPInfo.Click += new System.EventHandler(this.labelIPInfo_Click);
            this.labelIPInfo.DoubleClick += new System.EventHandler(this.labelIPInfo_DoubleClick);
            // 
            // tableLayoutPanelHelpRequest
            // 
            this.tableLayoutPanelHelpRequest.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelHelpRequest.ColumnCount = 3;
            this.tableLayoutPanelHelpRequest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanelHelpRequest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanelHelpRequest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanelHelpRequest.Controls.Add(this.panelHelpRequest, 1, 1);
            this.tableLayoutPanelHelpRequest.Controls.Add(this.panelHelpRequestTop, 1, 0);
            this.tableLayoutPanelHelpRequest.Font = new System.Drawing.Font("Eras Bold ITC", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanelHelpRequest.Location = new System.Drawing.Point(269, 283);
            this.tableLayoutPanelHelpRequest.Name = "tableLayoutPanelHelpRequest";
            this.tableLayoutPanelHelpRequest.RowCount = 3;
            this.tableLayoutPanelHelpRequest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31F));
            this.tableLayoutPanelHelpRequest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.25F));
            this.tableLayoutPanelHelpRequest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.75F));
            this.tableLayoutPanelHelpRequest.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanelHelpRequest.TabIndex = 5;
            // 
            // panelHelpRequest
            // 
            this.panelHelpRequest.Controls.Add(this.gelButtonHelpProvided);
            this.panelHelpRequest.Controls.Add(this.labelHelpRequestCurrentPlaying);
            this.panelHelpRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHelpRequest.Location = new System.Drawing.Point(38, 34);
            this.panelHelpRequest.MinimumSize = new System.Drawing.Size(437, 155);
            this.panelHelpRequest.Name = "panelHelpRequest";
            this.panelHelpRequest.Size = new System.Drawing.Size(437, 155);
            this.panelHelpRequest.TabIndex = 0;
            // 
            // gelButtonHelpProvided
            // 
            this.gelButtonHelpProvided.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gelButtonHelpProvided.EnableFlashing = false;
            this.gelButtonHelpProvided.Font = new System.Drawing.Font("Eras Bold ITC", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gelButtonHelpProvided.ForeColor = System.Drawing.Color.DarkBlue;
            this.gelButtonHelpProvided.GradientBottom = System.Drawing.Color.Yellow;
            this.gelButtonHelpProvided.GradientTop = System.Drawing.Color.SaddleBrown;
            this.gelButtonHelpProvided.Location = new System.Drawing.Point(0, 64);
            this.gelButtonHelpProvided.Name = "gelButtonHelpProvided";
            this.gelButtonHelpProvided.Size = new System.Drawing.Size(437, 91);
            this.gelButtonHelpProvided.TabIndex = 2;
            this.gelButtonHelpProvided.Text = "Help Provided";
            this.gelButtonHelpProvided.UseVisualStyleBackColor = false;
            this.gelButtonHelpProvided.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gelButtonHelpProvided_MouseDown);
            this.gelButtonHelpProvided.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gelButtonHelpProvided_MouseUp);
            // 
            // labelHelpRequestCurrentPlaying
            // 
            this.labelHelpRequestCurrentPlaying.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHelpRequestCurrentPlaying.Font = new System.Drawing.Font("Eras Bold ITC", 30F);
            this.labelHelpRequestCurrentPlaying.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelHelpRequestCurrentPlaying.Location = new System.Drawing.Point(0, 0);
            this.labelHelpRequestCurrentPlaying.Name = "labelHelpRequestCurrentPlaying";
            this.labelHelpRequestCurrentPlaying.Size = new System.Drawing.Size(437, 47);
            this.labelHelpRequestCurrentPlaying.TabIndex = 2;
            this.labelHelpRequestCurrentPlaying.Text = "Currently Playing";
            this.labelHelpRequestCurrentPlaying.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHelpRequestTop
            // 
            this.panelHelpRequestTop.Controls.Add(this.labelHelpRequested);
            this.panelHelpRequestTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHelpRequestTop.Location = new System.Drawing.Point(38, 3);
            this.panelHelpRequestTop.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.panelHelpRequestTop.Name = "panelHelpRequestTop";
            this.panelHelpRequestTop.Size = new System.Drawing.Size(124, 8);
            this.panelHelpRequestTop.TabIndex = 1;
            // 
            // labelHelpRequested
            // 
            this.labelHelpRequested.BackColor = System.Drawing.Color.Transparent;
            this.labelHelpRequested.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHelpRequested.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelHelpRequested.Font = new System.Drawing.Font("Eras Bold ITC", 48F);
            this.labelHelpRequested.ForeColor = System.Drawing.Color.White;
            this.labelHelpRequested.Location = new System.Drawing.Point(0, 0);
            this.labelHelpRequested.Name = "labelHelpRequested";
            this.labelHelpRequested.Size = new System.Drawing.Size(124, 8);
            this.labelHelpRequested.TabIndex = 2;
            this.labelHelpRequested.Text = "Client Request Help!";
            this.labelHelpRequested.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelHelpRequested.UseCompatibleTextRendering = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Navy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.tableLayoutPanelReady);
            this.Controls.Add(this.tableLayoutPanelWaitingCleaning);
            this.Controls.Add(this.tableLayoutPanelHelpRequest);
            this.Controls.Add(this.tableLayoutPanelInstVideo);
            this.Controls.Add(this.tableLayoutPanelUsing);
            this.Controls.Add(this.labelIPInfo);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.tableLayoutPanelInstVideo.ResumeLayout(false);
            this.panelInstVideo.ResumeLayout(false);
            this.panelInstVideoTop.ResumeLayout(false);
            this.tableLayoutPanelReady.ResumeLayout(false);
            this.tableLayoutPanelReady.PerformLayout();
            this.tableLayoutPanelWaitingCleaning.ResumeLayout(false);
            this.tableLayoutPanelWaitingCleaning.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanelUsing.ResumeLayout(false);
            this.tableLayoutPanelUsing.PerformLayout();
            this.tableLayoutPanelHelpRequest.ResumeLayout(false);
            this.panelHelpRequest.ResumeLayout(false);
            this.panelHelpRequestTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInstVideo;
        private System.Windows.Forms.Panel panelInstVideo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelReady;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelWaitingCleaning;
        private System.Windows.Forms.Panel panelInstVideoTop;
        private System.Windows.Forms.Label labelInstVideo;
        private GelButton buttonInstVideoYes;
        private GelButton buttonInstVideoNo;
        private System.Windows.Forms.Label labelReady;
        private System.Windows.Forms.Label labelReady2;
        private System.Windows.Forms.Label labelCleaning;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelUsing;
        private System.Windows.Forms.Label labelUsing;
        private System.Windows.Forms.Label labelIPInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHelpRequest;
        private System.Windows.Forms.Panel panelHelpRequest;
        private GelButton gelButtonHelpProvided;
        private System.Windows.Forms.Panel panelHelpRequestTop;
        private System.Windows.Forms.Label labelHelpRequested;
        private System.Windows.Forms.Label labelHelpRequestCurrentPlaying;
        private GelButton gelButtonCleaningDone;
        private System.Windows.Forms.Panel panel1;
    }
}

