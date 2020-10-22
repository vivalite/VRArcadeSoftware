namespace TestApplication
{
    partial class BiometricsScreen
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
            this.tbRate = new System.Windows.Forms.TextBox();
            this.rbUseFRR = new System.Windows.Forms.RadioButton();
            this.rbUseFAR = new System.Windows.Forms.RadioButton();
            this.pbImageData = new System.Windows.Forms.PictureBox();
            this.label60 = new System.Windows.Forms.Label();
            this.tbBioTimeout = new System.Windows.Forms.TextBox();
            this.btnDeleteBir = new System.Windows.Forms.Button();
            this.label59 = new System.Windows.Forms.Label();
            this.lbBirs = new System.Windows.Forms.ListBox();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.cbFinger = new System.Windows.Forms.ComboBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.btnEndCapt = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.btnBeginEnrollCapture = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBoxAdaptBir = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbRate
            // 
            this.tbRate.Location = new System.Drawing.Point(240, 150);
            this.tbRate.Name = "tbRate";
            this.tbRate.Size = new System.Drawing.Size(100, 20);
            this.tbRate.TabIndex = 47;
            this.tbRate.Text = "50";
            // 
            // rbUseFRR
            // 
            this.rbUseFRR.AutoSize = true;
            this.rbUseFRR.Location = new System.Drawing.Point(177, 128);
            this.rbUseFRR.Name = "rbUseFRR";
            this.rbUseFRR.Size = new System.Drawing.Size(118, 17);
            this.rbUseFRR.TabIndex = 46;
            this.rbUseFRR.TabStop = true;
            this.rbUseFRR.Text = "maxFRRRequested";
            this.rbUseFRR.UseVisualStyleBackColor = true;
            // 
            // rbUseFAR
            // 
            this.rbUseFAR.AutoSize = true;
            this.rbUseFAR.Checked = true;
            this.rbUseFAR.Location = new System.Drawing.Point(177, 109);
            this.rbUseFAR.Name = "rbUseFAR";
            this.rbUseFAR.Size = new System.Drawing.Size(117, 17);
            this.rbUseFAR.TabIndex = 45;
            this.rbUseFAR.TabStop = true;
            this.rbUseFAR.Text = "maxFARRequested";
            this.rbUseFAR.UseVisualStyleBackColor = true;
            // 
            // pbImageData
            // 
            this.pbImageData.Location = new System.Drawing.Point(409, 88);
            this.pbImageData.Name = "pbImageData";
            this.pbImageData.Size = new System.Drawing.Size(89, 108);
            this.pbImageData.TabIndex = 44;
            this.pbImageData.TabStop = false;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(175, 88);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(45, 13);
            this.label60.TabIndex = 43;
            this.label60.Text = "Timeout";
            // 
            // tbBioTimeout
            // 
            this.tbBioTimeout.Location = new System.Drawing.Point(241, 88);
            this.tbBioTimeout.Name = "tbBioTimeout";
            this.tbBioTimeout.Size = new System.Drawing.Size(100, 20);
            this.tbBioTimeout.TabIndex = 42;
            this.tbBioTimeout.Text = "5000";
            // 
            // btnDeleteBir
            // 
            this.btnDeleteBir.Location = new System.Drawing.Point(615, 170);
            this.btnDeleteBir.Name = "btnDeleteBir";
            this.btnDeleteBir.Size = new System.Drawing.Size(120, 23);
            this.btnDeleteBir.TabIndex = 41;
            this.btnDeleteBir.Text = "Delete BIR";
            this.btnDeleteBir.UseVisualStyleBackColor = true;
            this.btnDeleteBir.Click += new System.EventHandler(this.btnDeleteBir_Click);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(612, 20);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(66, 13);
            this.label59.TabIndex = 40;
            this.label59.Text = "Stored BIR\'s";
            // 
            // lbBirs
            // 
            this.lbBirs.FormattingEnabled = true;
            this.lbBirs.Location = new System.Drawing.Point(615, 46);
            this.lbBirs.Name = "lbBirs";
            this.lbBirs.Size = new System.Drawing.Size(120, 108);
            this.lbBirs.TabIndex = 39;
            // 
            // lblStatusText
            // 
            this.lblStatusText.AutoSize = true;
            this.lblStatusText.Location = new System.Drawing.Point(406, 66);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(0, 13);
            this.lblStatusText.TabIndex = 38;
            // 
            // cbFinger
            // 
            this.cbFinger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFinger.FormattingEnabled = true;
            this.cbFinger.Items.AddRange(new object[] {
            "Left Small",
            "Left Ring",
            "Left Middle",
            "Left Index",
            "Left Thumb",
            "Right Thumb",
            "Right Index",
            "Right Middle",
            "Right Ring",
            "Right Small"});
            this.cbFinger.Location = new System.Drawing.Point(424, 20);
            this.cbFinger.Name = "cbFinger";
            this.cbFinger.Size = new System.Drawing.Size(121, 21);
            this.cbFinger.TabIndex = 37;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(367, 25);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(36, 13);
            this.label58.TabIndex = 36;
            this.label58.Text = "Finger";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(174, 27);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(60, 13);
            this.label57.TabIndex = 35;
            this.label57.Text = "User Name";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(241, 22);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(100, 20);
            this.tbUserName.TabIndex = 34;
            // 
            // btnEndCapt
            // 
            this.btnEndCapt.Location = new System.Drawing.Point(23, 50);
            this.btnEndCapt.Name = "btnEndCapt";
            this.btnEndCapt.Size = new System.Drawing.Size(134, 23);
            this.btnEndCapt.TabIndex = 33;
            this.btnEndCapt.Text = "EndCapture";
            this.btnEndCapt.UseVisualStyleBackColor = true;
            this.btnEndCapt.Click += new System.EventHandler(this.btnEndCapt_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(23, 146);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(134, 23);
            this.btnVerify.TabIndex = 32;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnIdentify
            // 
            this.btnIdentify.Location = new System.Drawing.Point(23, 117);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(134, 23);
            this.btnIdentify.TabIndex = 31;
            this.btnIdentify.Text = "Identify";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // btnBeginEnrollCapture
            // 
            this.btnBeginEnrollCapture.Location = new System.Drawing.Point(23, 22);
            this.btnBeginEnrollCapture.Name = "btnBeginEnrollCapture";
            this.btnBeginEnrollCapture.Size = new System.Drawing.Size(134, 23);
            this.btnBeginEnrollCapture.TabIndex = 30;
            this.btnBeginEnrollCapture.Text = "BeginEnrollCapture";
            this.btnBeginEnrollCapture.UseVisualStyleBackColor = true;
            this.btnBeginEnrollCapture.Click += new System.EventHandler(this.btnBeginEnrollCapture_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBoxAdaptBir);
            this.groupBox1.Location = new System.Drawing.Point(163, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 134);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Method Parameters";
            // 
            // chkBoxAdaptBir
            // 
            this.chkBoxAdaptBir.AutoSize = true;
            this.chkBoxAdaptBir.Checked = true;
            this.chkBoxAdaptBir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxAdaptBir.Location = new System.Drawing.Point(14, 110);
            this.chkBoxAdaptBir.Name = "chkBoxAdaptBir";
            this.chkBoxAdaptBir.Size = new System.Drawing.Size(75, 17);
            this.chkBoxAdaptBir.TabIndex = 0;
            this.chkBoxAdaptBir.Text = "Adapt BIR";
            this.chkBoxAdaptBir.UseVisualStyleBackColor = true;
            // 
            // BiometricsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tbRate);
            this.Controls.Add(this.rbUseFRR);
            this.Controls.Add(this.rbUseFAR);
            this.Controls.Add(this.pbImageData);
            this.Controls.Add(this.label60);
            this.Controls.Add(this.tbBioTimeout);
            this.Controls.Add(this.btnDeleteBir);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.lbBirs);
            this.Controls.Add(this.lblStatusText);
            this.Controls.Add(this.cbFinger);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.btnEndCapt);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.btnIdentify);
            this.Controls.Add(this.btnBeginEnrollCapture);
            this.Controls.Add(this.groupBox1);
            this.Name = "BiometricsScreen";
            ((System.ComponentModel.ISupportInitialize)(this.pbImageData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRate;
        private System.Windows.Forms.RadioButton rbUseFRR;
        private System.Windows.Forms.RadioButton rbUseFAR;
        private System.Windows.Forms.PictureBox pbImageData;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.TextBox tbBioTimeout;
        private System.Windows.Forms.Button btnDeleteBir;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.ListBox lbBirs;
        private System.Windows.Forms.Label lblStatusText;
        private System.Windows.Forms.ComboBox cbFinger;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Button btnEndCapt;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.Button btnBeginEnrollCapture;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBoxAdaptBir;
    }
}
