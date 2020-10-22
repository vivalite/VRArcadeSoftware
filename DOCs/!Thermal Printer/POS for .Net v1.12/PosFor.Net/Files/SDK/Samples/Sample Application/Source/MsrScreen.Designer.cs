namespace TestApplication
{
    partial class MsrScreen
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
            this.comboBoxErrorReportingType = new System.Windows.Forms.ComboBox();
            this.comboBoxTracksToRead = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.cbTransmitSentinels = new System.Windows.Forms.CheckBox();
            this.cbParseDecodeData = new System.Windows.Forms.CheckBox();
            this.cbDecodeData = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comboBoxErrorReportingType
            // 
            this.comboBoxErrorReportingType.Location = new System.Drawing.Point(140, 141);
            this.comboBoxErrorReportingType.Name = "comboBoxErrorReportingType";
            this.comboBoxErrorReportingType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxErrorReportingType.TabIndex = 13;
            this.comboBoxErrorReportingType.SelectedIndexChanged += new System.EventHandler(this.comboBoxErrorReportingType_SelectedIndexChanged);
            // 
            // comboBoxTracksToRead
            // 
            this.comboBoxTracksToRead.Location = new System.Drawing.Point(139, 107);
            this.comboBoxTracksToRead.Name = "comboBoxTracksToRead";
            this.comboBoxTracksToRead.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTracksToRead.Sorted = true;
            this.comboBoxTracksToRead.TabIndex = 12;
            this.comboBoxTracksToRead.SelectedIndexChanged += new System.EventHandler(this.comboBoxTracksToRead_SelectedIndexChanged);
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(18, 143);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(115, 23);
            this.label35.TabIndex = 11;
            this.label35.Text = "Error Reporting Type";
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(17, 109);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(100, 23);
            this.label34.TabIndex = 10;
            this.label34.Text = "Tracks to Read";
            // 
            // cbTransmitSentinels
            // 
            this.cbTransmitSentinels.Location = new System.Drawing.Point(20, 69);
            this.cbTransmitSentinels.Name = "cbTransmitSentinels";
            this.cbTransmitSentinels.Size = new System.Drawing.Size(126, 24);
            this.cbTransmitSentinels.TabIndex = 9;
            this.cbTransmitSentinels.Text = "Transmit Sentinels";
            this.cbTransmitSentinels.CheckedChanged += new System.EventHandler(this.cbTransmitSentinels_CheckedChanged);
            // 
            // cbParseDecodeData
            // 
            this.cbParseDecodeData.Location = new System.Drawing.Point(20, 42);
            this.cbParseDecodeData.Name = "cbParseDecodeData";
            this.cbParseDecodeData.Size = new System.Drawing.Size(127, 24);
            this.cbParseDecodeData.TabIndex = 8;
            this.cbParseDecodeData.Text = "Parse Decode Data";
            this.cbParseDecodeData.CheckedChanged += new System.EventHandler(this.cbParseDecodeData_CheckedChanged);
            // 
            // cbDecodeData
            // 
            this.cbDecodeData.Location = new System.Drawing.Point(20, 17);
            this.cbDecodeData.Name = "cbDecodeData";
            this.cbDecodeData.Size = new System.Drawing.Size(104, 24);
            this.cbDecodeData.TabIndex = 7;
            this.cbDecodeData.Text = "Decode Data";
            this.cbDecodeData.CheckedChanged += new System.EventHandler(this.cbDecodeData_CheckedChanged);
            // 
            // MsrScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.comboBoxErrorReportingType);
            this.Controls.Add(this.comboBoxTracksToRead);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.cbTransmitSentinels);
            this.Controls.Add(this.cbParseDecodeData);
            this.Controls.Add(this.cbDecodeData);
            this.Name = "MsrScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxErrorReportingType;
        private System.Windows.Forms.ComboBox comboBoxTracksToRead;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.CheckBox cbTransmitSentinels;
        private System.Windows.Forms.CheckBox cbParseDecodeData;
        private System.Windows.Forms.CheckBox cbDecodeData;
    }
}
