namespace TestApplication
{
    partial class RFIDScannerScreen
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.tbWriteTimeout = new System.Windows.Forms.TextBox();
            this.btnLockTag = new System.Windows.Forms.Button();
            this.label68 = new System.Windows.Forms.Label();
            this.tbStartPosition = new System.Windows.Forms.TextBox();
            this.tbWriteTagUserData = new System.Windows.Forms.TextBox();
            this.tbWriteTagID = new System.Windows.Forms.TextBox();
            this.btnWriteTag = new System.Windows.Forms.Button();
            this.GrpReadMethods = new System.Windows.Forms.GroupBox();
            this.label71 = new System.Windows.Forms.Label();
            this.tbReadTimeout = new System.Windows.Forms.TextBox();
            this.tbTimeInterval = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.lbReadStatus = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.btnConReadStart = new System.Windows.Forms.Button();
            this.btnConReadStop = new System.Windows.Forms.Button();
            this.btnReadtag = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.tbTagCount = new System.Windows.Forms.TextBox();
            this.tb_User_Data = new System.Windows.Forms.TextBox();
            this.tb_Tag_ID = new System.Windows.Forms.TextBox();
            this.btnPreviousTag = new System.Windows.Forms.Button();
            this.btnNextTag = new System.Windows.Forms.Button();
            this.btnFirstTag = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.GrpReadMethods.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label64);
            this.groupBox3.Controls.Add(this.label61);
            this.groupBox3.Controls.Add(this.label70);
            this.groupBox3.Controls.Add(this.tbWriteTimeout);
            this.groupBox3.Controls.Add(this.btnLockTag);
            this.groupBox3.Controls.Add(this.label68);
            this.groupBox3.Controls.Add(this.tbStartPosition);
            this.groupBox3.Controls.Add(this.tbWriteTagUserData);
            this.groupBox3.Controls.Add(this.tbWriteTagID);
            this.groupBox3.Controls.Add(this.btnWriteTag);
            this.groupBox3.Location = new System.Drawing.Point(7, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(145, 196);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Write Tags";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(13, 71);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(55, 13);
            this.label64.TabIndex = 61;
            this.label64.Text = "User Data";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(13, 20);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(40, 13);
            this.label61.TabIndex = 60;
            this.label61.Text = "Tag ID";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(10, 140);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(45, 13);
            this.label70.TabIndex = 59;
            this.label70.Text = "Timeout";
            // 
            // tbWriteTimeout
            // 
            this.tbWriteTimeout.Location = new System.Drawing.Point(70, 136);
            this.tbWriteTimeout.Name = "tbWriteTimeout";
            this.tbWriteTimeout.Size = new System.Drawing.Size(60, 20);
            this.tbWriteTimeout.TabIndex = 58;
            this.tbWriteTimeout.Text = "5000";
            // 
            // btnLockTag
            // 
            this.btnLockTag.Location = new System.Drawing.Point(77, 162);
            this.btnLockTag.Name = "btnLockTag";
            this.btnLockTag.Size = new System.Drawing.Size(59, 23);
            this.btnLockTag.TabIndex = 57;
            this.btnLockTag.Text = "LockTag";
            this.btnLockTag.UseVisualStyleBackColor = true;
            this.btnLockTag.Click += new System.EventHandler(this.btnLockTag_Click);
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(13, 115);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(53, 13);
            this.label68.TabIndex = 55;
            this.label68.Text = "Start Pos.";
            // 
            // tbStartPosition
            // 
            this.tbStartPosition.Location = new System.Drawing.Point(70, 113);
            this.tbStartPosition.Name = "tbStartPosition";
            this.tbStartPosition.Size = new System.Drawing.Size(60, 20);
            this.tbStartPosition.TabIndex = 52;
            this.tbStartPosition.Text = "0";
            // 
            // tbWriteTagUserData
            // 
            this.tbWriteTagUserData.Location = new System.Drawing.Point(16, 88);
            this.tbWriteTagUserData.Name = "tbWriteTagUserData";
            this.tbWriteTagUserData.Size = new System.Drawing.Size(114, 20);
            this.tbWriteTagUserData.TabIndex = 4;
            // 
            // tbWriteTagID
            // 
            this.tbWriteTagID.Location = new System.Drawing.Point(16, 41);
            this.tbWriteTagID.Name = "tbWriteTagID";
            this.tbWriteTagID.Size = new System.Drawing.Size(114, 20);
            this.tbWriteTagID.TabIndex = 2;
            // 
            // btnWriteTag
            // 
            this.btnWriteTag.Location = new System.Drawing.Point(6, 162);
            this.btnWriteTag.Name = "btnWriteTag";
            this.btnWriteTag.Size = new System.Drawing.Size(65, 23);
            this.btnWriteTag.TabIndex = 1;
            this.btnWriteTag.Text = "WriteTag";
            this.btnWriteTag.UseVisualStyleBackColor = true;
            this.btnWriteTag.Click += new System.EventHandler(this.btnWriteTag_Click);
            // 
            // GrpReadMethods
            // 
            this.GrpReadMethods.Controls.Add(this.label71);
            this.GrpReadMethods.Controls.Add(this.tbReadTimeout);
            this.GrpReadMethods.Controls.Add(this.tbTimeInterval);
            this.GrpReadMethods.Controls.Add(this.label62);
            this.GrpReadMethods.Controls.Add(this.lbReadStatus);
            this.GrpReadMethods.Controls.Add(this.label63);
            this.GrpReadMethods.Controls.Add(this.btnConReadStart);
            this.GrpReadMethods.Controls.Add(this.btnConReadStop);
            this.GrpReadMethods.Controls.Add(this.btnReadtag);
            this.GrpReadMethods.Location = new System.Drawing.Point(163, 12);
            this.GrpReadMethods.Name = "GrpReadMethods";
            this.GrpReadMethods.Size = new System.Drawing.Size(216, 196);
            this.GrpReadMethods.TabIndex = 26;
            this.GrpReadMethods.TabStop = false;
            this.GrpReadMethods.Text = "Reading Methods";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(23, 53);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(45, 13);
            this.label71.TabIndex = 61;
            this.label71.Text = "Timeout";
            // 
            // tbReadTimeout
            // 
            this.tbReadTimeout.Location = new System.Drawing.Point(119, 50);
            this.tbReadTimeout.Name = "tbReadTimeout";
            this.tbReadTimeout.Size = new System.Drawing.Size(76, 20);
            this.tbReadTimeout.TabIndex = 60;
            this.tbReadTimeout.Text = "5000";
            // 
            // tbTimeInterval
            // 
            this.tbTimeInterval.Location = new System.Drawing.Point(115, 144);
            this.tbTimeInterval.Name = "tbTimeInterval";
            this.tbTimeInterval.Size = new System.Drawing.Size(76, 20);
            this.tbTimeInterval.TabIndex = 20;
            this.tbTimeInterval.Text = "1000";
            this.tbTimeInterval.TextChanged += new System.EventHandler(this.tbTimeInterval_TextChanged);
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(18, 147);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(94, 13);
            this.label62.TabIndex = 18;
            this.label62.Text = "ReadTimerInterval";
            // 
            // lbReadStatus
            // 
            this.lbReadStatus.AutoSize = true;
            this.lbReadStatus.Location = new System.Drawing.Point(109, 175);
            this.lbReadStatus.Name = "lbReadStatus";
            this.lbReadStatus.Size = new System.Drawing.Size(47, 13);
            this.lbReadStatus.TabIndex = 13;
            this.lbReadStatus.Text = "Stopped";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(63, 175);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(40, 13);
            this.label63.TabIndex = 12;
            this.label63.Text = "Status:";
            // 
            // btnConReadStart
            // 
            this.btnConReadStart.Location = new System.Drawing.Point(6, 111);
            this.btnConReadStart.Name = "btnConReadStart";
            this.btnConReadStart.Size = new System.Drawing.Size(100, 23);
            this.btnConReadStart.TabIndex = 16;
            this.btnConReadStart.Text = "StartReadTags";
            this.btnConReadStart.UseVisualStyleBackColor = true;
            this.btnConReadStart.Click += new System.EventHandler(this.btnConReadStart_Click);
            // 
            // btnConReadStop
            // 
            this.btnConReadStop.Enabled = false;
            this.btnConReadStop.Location = new System.Drawing.Point(112, 111);
            this.btnConReadStop.Name = "btnConReadStop";
            this.btnConReadStop.Size = new System.Drawing.Size(98, 23);
            this.btnConReadStop.TabIndex = 17;
            this.btnConReadStop.Text = "StopReadTags";
            this.btnConReadStop.UseVisualStyleBackColor = true;
            this.btnConReadStop.Click += new System.EventHandler(this.btnConReadStop_Click);
            // 
            // btnReadtag
            // 
            this.btnReadtag.Location = new System.Drawing.Point(68, 20);
            this.btnReadtag.Name = "btnReadtag";
            this.btnReadtag.Size = new System.Drawing.Size(98, 23);
            this.btnReadtag.TabIndex = 0;
            this.btnReadtag.Text = "ReadTags";
            this.btnReadtag.UseVisualStyleBackColor = true;
            this.btnReadtag.Click += new System.EventHandler(this.btnReadtag_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label65);
            this.groupBox2.Controls.Add(this.label66);
            this.groupBox2.Controls.Add(this.label67);
            this.groupBox2.Controls.Add(this.tbTagCount);
            this.groupBox2.Controls.Add(this.tb_User_Data);
            this.groupBox2.Controls.Add(this.tb_Tag_ID);
            this.groupBox2.Controls.Add(this.btnPreviousTag);
            this.groupBox2.Controls.Add(this.btnNextTag);
            this.groupBox2.Controls.Add(this.btnFirstTag);
            this.groupBox2.Location = new System.Drawing.Point(386, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 196);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(128, 100);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(52, 13);
            this.label65.TabIndex = 5;
            this.label65.Text = "UserData";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(128, 74);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(35, 13);
            this.label66.TabIndex = 4;
            this.label66.Text = "TagId";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(128, 47);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(57, 13);
            this.label67.TabIndex = 6;
            this.label67.Text = "Tag Count";
            // 
            // tbTagCount
            // 
            this.tbTagCount.Location = new System.Drawing.Point(191, 44);
            this.tbTagCount.Name = "tbTagCount";
            this.tbTagCount.ReadOnly = true;
            this.tbTagCount.Size = new System.Drawing.Size(37, 20);
            this.tbTagCount.TabIndex = 7;
            // 
            // tb_User_Data
            // 
            this.tb_User_Data.Location = new System.Drawing.Point(190, 97);
            this.tb_User_Data.Name = "tb_User_Data";
            this.tb_User_Data.Size = new System.Drawing.Size(169, 20);
            this.tb_User_Data.TabIndex = 8;
            // 
            // tb_Tag_ID
            // 
            this.tb_Tag_ID.Location = new System.Drawing.Point(190, 71);
            this.tb_Tag_ID.Name = "tb_Tag_ID";
            this.tb_Tag_ID.Size = new System.Drawing.Size(169, 20);
            this.tb_Tag_ID.TabIndex = 9;
            // 
            // btnPreviousTag
            // 
            this.btnPreviousTag.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnPreviousTag.Location = new System.Drawing.Point(15, 100);
            this.btnPreviousTag.Name = "btnPreviousTag";
            this.btnPreviousTag.Size = new System.Drawing.Size(105, 23);
            this.btnPreviousTag.TabIndex = 3;
            this.btnPreviousTag.Text = "PreviousTag";
            this.btnPreviousTag.UseVisualStyleBackColor = true;
            this.btnPreviousTag.Click += new System.EventHandler(this.btnPreviousTag_Click);
            // 
            // btnNextTag
            // 
            this.btnNextTag.Location = new System.Drawing.Point(15, 71);
            this.btnNextTag.Name = "btnNextTag";
            this.btnNextTag.Size = new System.Drawing.Size(105, 23);
            this.btnNextTag.TabIndex = 2;
            this.btnNextTag.Text = "NextTag";
            this.btnNextTag.UseVisualStyleBackColor = true;
            this.btnNextTag.Click += new System.EventHandler(this.btnNextTag_Click);
            // 
            // btnFirstTag
            // 
            this.btnFirstTag.Location = new System.Drawing.Point(15, 42);
            this.btnFirstTag.Name = "btnFirstTag";
            this.btnFirstTag.Size = new System.Drawing.Size(105, 23);
            this.btnFirstTag.TabIndex = 1;
            this.btnFirstTag.Text = "FirstTag";
            this.btnFirstTag.UseVisualStyleBackColor = true;
            this.btnFirstTag.Click += new System.EventHandler(this.btnFirstTag_Click);
            // 
            // RFIDScannerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.GrpReadMethods);
            this.Controls.Add(this.groupBox2);
            this.Name = "RFIDScannerScreen";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.GrpReadMethods.ResumeLayout(false);
            this.GrpReadMethods.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.TextBox tbWriteTimeout;
        private System.Windows.Forms.Button btnLockTag;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.TextBox tbStartPosition;
        private System.Windows.Forms.TextBox tbWriteTagUserData;
        private System.Windows.Forms.TextBox tbWriteTagID;
        private System.Windows.Forms.Button btnWriteTag;
        private System.Windows.Forms.GroupBox GrpReadMethods;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.TextBox tbReadTimeout;
        private System.Windows.Forms.TextBox tbTimeInterval;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label lbReadStatus;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Button btnConReadStart;
        private System.Windows.Forms.Button btnConReadStop;
        private System.Windows.Forms.Button btnReadtag;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox tbTagCount;
        private System.Windows.Forms.TextBox tb_User_Data;
        private System.Windows.Forms.TextBox tb_Tag_ID;
        private System.Windows.Forms.Button btnPreviousTag;
        private System.Windows.Forms.Button btnNextTag;
        private System.Windows.Forms.Button btnFirstTag;
    }
}
