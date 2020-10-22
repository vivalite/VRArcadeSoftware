namespace TestApplication
{
    partial class SmartCardRWScreen
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
            this.btnEndRemoval = new System.Windows.Forms.Button();
            this.btnBeginRemoval = new System.Windows.Forms.Button();
            this.btnEndInsertion = new System.Windows.Forms.Button();
            this.btnBeginInsertion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTimeout = new System.Windows.Forms.TextBox();
            this.btnReadData = new System.Windows.Forms.Button();
            this.cbSmartCardReadAction = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbInputData = new System.Windows.Forms.TextBox();
            this.btnWriteData = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbSmartCardWriteAction = new System.Windows.Forms.ComboBox();
            this.tbResultData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbInterfaceMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbIsoEmvMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSCSlot = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEndRemoval
            // 
            this.btnEndRemoval.Location = new System.Drawing.Point(145, 48);
            this.btnEndRemoval.Name = "btnEndRemoval";
            this.btnEndRemoval.Size = new System.Drawing.Size(105, 23);
            this.btnEndRemoval.TabIndex = 41;
            this.btnEndRemoval.Text = "EndRemoval";
            this.btnEndRemoval.Click += new System.EventHandler(this.btnEndRemoval_Click);
            // 
            // btnBeginRemoval
            // 
            this.btnBeginRemoval.Location = new System.Drawing.Point(23, 49);
            this.btnBeginRemoval.Name = "btnBeginRemoval";
            this.btnBeginRemoval.Size = new System.Drawing.Size(105, 23);
            this.btnBeginRemoval.TabIndex = 40;
            this.btnBeginRemoval.Text = "BeginRemoval";
            this.btnBeginRemoval.Click += new System.EventHandler(this.btnBeginRemoval_Click);
            // 
            // btnEndInsertion
            // 
            this.btnEndInsertion.Location = new System.Drawing.Point(145, 20);
            this.btnEndInsertion.Name = "btnEndInsertion";
            this.btnEndInsertion.Size = new System.Drawing.Size(105, 23);
            this.btnEndInsertion.TabIndex = 39;
            this.btnEndInsertion.Text = "EndInsertion";
            this.btnEndInsertion.Click += new System.EventHandler(this.btnEndInsertion_Click);
            // 
            // btnBeginInsertion
            // 
            this.btnBeginInsertion.Location = new System.Drawing.Point(23, 20);
            this.btnBeginInsertion.Name = "btnBeginInsertion";
            this.btnBeginInsertion.Size = new System.Drawing.Size(105, 23);
            this.btnBeginInsertion.TabIndex = 38;
            this.btnBeginInsertion.Text = "BeginInsertion";
            this.btnBeginInsertion.Click += new System.EventHandler(this.btnBeginInsertion_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(48, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 23);
            this.label1.TabIndex = 43;
            this.label1.Text = "Timeout:";
            // 
            // tbTimeout
            // 
            this.tbTimeout.Location = new System.Drawing.Point(126, 93);
            this.tbTimeout.Name = "tbTimeout";
            this.tbTimeout.Size = new System.Drawing.Size(100, 20);
            this.tbTimeout.TabIndex = 42;
            this.tbTimeout.Text = "5000";
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(12, 17);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(105, 23);
            this.btnReadData.TabIndex = 44;
            this.btnReadData.Text = "ReadData";
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // cbSmartCardReadAction
            // 
            this.cbSmartCardReadAction.FormattingEnabled = true;
            this.cbSmartCardReadAction.Location = new System.Drawing.Point(208, 17);
            this.cbSmartCardReadAction.Name = "cbSmartCardReadAction";
            this.cbSmartCardReadAction.Size = new System.Drawing.Size(145, 21);
            this.cbSmartCardReadAction.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "Input:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Read Action:";
            // 
            // tbInputData
            // 
            this.tbInputData.Location = new System.Drawing.Point(60, 88);
            this.tbInputData.Name = "tbInputData";
            this.tbInputData.Size = new System.Drawing.Size(390, 20);
            this.tbInputData.TabIndex = 72;
            // 
            // btnWriteData
            // 
            this.btnWriteData.Location = new System.Drawing.Point(12, 50);
            this.btnWriteData.Name = "btnWriteData";
            this.btnWriteData.Size = new System.Drawing.Size(105, 23);
            this.btnWriteData.TabIndex = 73;
            this.btnWriteData.Text = "WriteData";
            this.btnWriteData.Click += new System.EventHandler(this.btnWriteData_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSmartCardWriteAction);
            this.groupBox1.Controls.Add(this.tbResultData);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnWriteData);
            this.groupBox1.Controls.Add(this.cbSmartCardReadAction);
            this.groupBox1.Controls.Add(this.btnReadData);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbInputData);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(292, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 229);
            this.groupBox1.TabIndex = 74;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "I/O";
            // 
            // cbSmartCardWriteAction
            // 
            this.cbSmartCardWriteAction.FormattingEnabled = true;
            this.cbSmartCardWriteAction.Location = new System.Drawing.Point(208, 50);
            this.cbSmartCardWriteAction.Name = "cbSmartCardWriteAction";
            this.cbSmartCardWriteAction.Size = new System.Drawing.Size(145, 21);
            this.cbSmartCardWriteAction.TabIndex = 69;
            // 
            // tbResultData
            // 
            this.tbResultData.Location = new System.Drawing.Point(59, 114);
            this.tbResultData.Multiline = true;
            this.tbResultData.Name = "tbResultData";
            this.tbResultData.ReadOnly = true;
            this.tbResultData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbResultData.Size = new System.Drawing.Size(391, 101);
            this.tbResultData.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 71;
            this.label4.Text = "Write Action:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 75;
            this.label6.Text = "Output:";
            // 
            // cbInterfaceMode
            // 
            this.cbInterfaceMode.FormattingEnabled = true;
            this.cbInterfaceMode.Location = new System.Drawing.Point(106, 149);
            this.cbInterfaceMode.Name = "cbInterfaceMode";
            this.cbInterfaceMode.Size = new System.Drawing.Size(145, 21);
            this.cbInterfaceMode.TabIndex = 75;
            this.cbInterfaceMode.SelectedIndexChanged += new System.EventHandler(this.cbInterfaceMode_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 76;
            this.label5.Text = "InterfaceMode:";
            // 
            // cbIsoEmvMode
            // 
            this.cbIsoEmvMode.FormattingEnabled = true;
            this.cbIsoEmvMode.Location = new System.Drawing.Point(106, 173);
            this.cbIsoEmvMode.Name = "cbIsoEmvMode";
            this.cbIsoEmvMode.Size = new System.Drawing.Size(145, 21);
            this.cbIsoEmvMode.TabIndex = 77;
            this.cbIsoEmvMode.SelectedIndexChanged += new System.EventHandler(this.cbIsoEmvMode_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 78;
            this.label7.Text = "IsoEmvMode:";
            // 
            // cbSCSlot
            // 
            this.cbSCSlot.FormattingEnabled = true;
            this.cbSCSlot.Location = new System.Drawing.Point(106, 198);
            this.cbSCSlot.Name = "cbSCSlot";
            this.cbSCSlot.Size = new System.Drawing.Size(145, 21);
            this.cbSCSlot.TabIndex = 79;
            this.cbSCSlot.SelectedIndexChanged += new System.EventHandler(this.cbSCSlot_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 80;
            this.label8.Text = "SCSlot:";
            // 
            // SmartCardRWScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.cbSCSlot);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbIsoEmvMode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbInterfaceMode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTimeout);
            this.Controls.Add(this.btnEndRemoval);
            this.Controls.Add(this.btnBeginRemoval);
            this.Controls.Add(this.btnEndInsertion);
            this.Controls.Add(this.btnBeginInsertion);
            this.Name = "SmartCardRWScreen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEndRemoval;
        private System.Windows.Forms.Button btnBeginRemoval;
        private System.Windows.Forms.Button btnEndInsertion;
        private System.Windows.Forms.Button btnBeginInsertion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTimeout;
        private System.Windows.Forms.Button btnReadData;
        private System.Windows.Forms.ComboBox cbSmartCardReadAction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbInputData;
        private System.Windows.Forms.Button btnWriteData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbSmartCardWriteAction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbResultData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbInterfaceMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbIsoEmvMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSCSlot;
        private System.Windows.Forms.Label label8;
    }
}
