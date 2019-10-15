namespace VRGameSelectorTestServer
{
    partial class TestServer
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
            this.components = new System.ComponentModel.Container();
            this.btnGetClientStatus = new System.Windows.Forms.Button();
            this.btnStartTiming = new System.Windows.Forms.Button();
            this.btnStartNow = new System.Windows.Forms.Button();
            this.btnEndNow = new System.Windows.Forms.Button();
            this.btnTurnOff = new System.Windows.Forms.Button();
            this.lblConnCnt = new System.Windows.Forms.Label();
            this.testTimer = new System.Windows.Forms.Timer(this.components);
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.buttonSendTileConfig = new System.Windows.Forms.Button();
            this.buttonShowQuickHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetClientStatus
            // 
            this.btnGetClientStatus.Location = new System.Drawing.Point(64, 12);
            this.btnGetClientStatus.Name = "btnGetClientStatus";
            this.btnGetClientStatus.Size = new System.Drawing.Size(201, 35);
            this.btnGetClientStatus.TabIndex = 0;
            this.btnGetClientStatus.Text = "Get Client Status (LOAD CONFIG)";
            this.btnGetClientStatus.UseVisualStyleBackColor = true;
            this.btnGetClientStatus.Click += new System.EventHandler(this.btnGetClientStatus_Click);
            // 
            // btnStartTiming
            // 
            this.btnStartTiming.Location = new System.Drawing.Point(64, 74);
            this.btnStartTiming.Name = "btnStartTiming";
            this.btnStartTiming.Size = new System.Drawing.Size(201, 35);
            this.btnStartTiming.TabIndex = 1;
            this.btnStartTiming.Text = "Start Timing Session (START TIMING)";
            this.btnStartTiming.UseVisualStyleBackColor = true;
            this.btnStartTiming.Click += new System.EventHandler(this.btnStartTiming_Click);
            // 
            // btnStartNow
            // 
            this.btnStartNow.Location = new System.Drawing.Point(64, 136);
            this.btnStartNow.Name = "btnStartNow";
            this.btnStartNow.Size = new System.Drawing.Size(201, 35);
            this.btnStartNow.TabIndex = 2;
            this.btnStartNow.Text = "Start Non-Timing Session \r\n(START NOW)";
            this.btnStartNow.UseVisualStyleBackColor = true;
            this.btnStartNow.Click += new System.EventHandler(this.btnStartNow_Click);
            // 
            // btnEndNow
            // 
            this.btnEndNow.Location = new System.Drawing.Point(64, 198);
            this.btnEndNow.Name = "btnEndNow";
            this.btnEndNow.Size = new System.Drawing.Size(201, 35);
            this.btnEndNow.TabIndex = 3;
            this.btnEndNow.Text = "End Timing / Non-Timing Session\r\n(END NOW)";
            this.btnEndNow.UseVisualStyleBackColor = true;
            this.btnEndNow.Click += new System.EventHandler(this.btnEndNow_Click);
            // 
            // btnTurnOff
            // 
            this.btnTurnOff.Location = new System.Drawing.Point(64, 398);
            this.btnTurnOff.Name = "btnTurnOff";
            this.btnTurnOff.Size = new System.Drawing.Size(201, 35);
            this.btnTurnOff.TabIndex = 4;
            this.btnTurnOff.Text = "Turn Off Client Computer (TURN OFF)";
            this.btnTurnOff.UseVisualStyleBackColor = true;
            this.btnTurnOff.Click += new System.EventHandler(this.btnTurnOff_Click);
            // 
            // lblConnCnt
            // 
            this.lblConnCnt.AutoSize = true;
            this.lblConnCnt.Location = new System.Drawing.Point(108, 451);
            this.lblConnCnt.Name = "lblConnCnt";
            this.lblConnCnt.Size = new System.Drawing.Size(105, 13);
            this.lblConnCnt.TabIndex = 5;
            this.lblConnCnt.Text = "Connected Clients: 0";
            // 
            // testTimer
            // 
            this.testTimer.Enabled = true;
            this.testTimer.Interval = 200;
            this.testTimer.Tick += new System.EventHandler(this.testTimer_Tick);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(13, 484);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(317, 105);
            this.txtInfo.TabIndex = 6;
            // 
            // buttonSendTileConfig
            // 
            this.buttonSendTileConfig.Location = new System.Drawing.Point(64, 263);
            this.buttonSendTileConfig.Name = "buttonSendTileConfig";
            this.buttonSendTileConfig.Size = new System.Drawing.Size(201, 35);
            this.buttonSendTileConfig.TabIndex = 7;
            this.buttonSendTileConfig.Text = "Send Tile Config";
            this.buttonSendTileConfig.UseVisualStyleBackColor = true;
            this.buttonSendTileConfig.Click += new System.EventHandler(this.buttonSendTileConfig_Click);
            // 
            // buttonShowQuickHelp
            // 
            this.buttonShowQuickHelp.Location = new System.Drawing.Point(64, 330);
            this.buttonShowQuickHelp.Name = "buttonShowQuickHelp";
            this.buttonShowQuickHelp.Size = new System.Drawing.Size(201, 35);
            this.buttonShowQuickHelp.TabIndex = 8;
            this.buttonShowQuickHelp.Text = "Show Quick Help";
            this.buttonShowQuickHelp.UseVisualStyleBackColor = true;
            this.buttonShowQuickHelp.Click += new System.EventHandler(this.buttonShowQuickHelp_Click);
            // 
            // TestServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 606);
            this.Controls.Add(this.buttonShowQuickHelp);
            this.Controls.Add(this.buttonSendTileConfig);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.lblConnCnt);
            this.Controls.Add(this.btnTurnOff);
            this.Controls.Add(this.btnEndNow);
            this.Controls.Add(this.btnStartNow);
            this.Controls.Add(this.btnStartTiming);
            this.Controls.Add(this.btnGetClientStatus);
            this.DoubleBuffered = true;
            this.Name = "TestServer";
            this.Text = "Server Simulation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetClientStatus;
        private System.Windows.Forms.Button btnStartTiming;
        private System.Windows.Forms.Button btnStartNow;
        private System.Windows.Forms.Button btnEndNow;
        private System.Windows.Forms.Button btnTurnOff;
        private System.Windows.Forms.Label lblConnCnt;
        private System.Windows.Forms.Timer testTimer;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button buttonSendTileConfig;
        private System.Windows.Forms.Button buttonShowQuickHelp;
    }
}

