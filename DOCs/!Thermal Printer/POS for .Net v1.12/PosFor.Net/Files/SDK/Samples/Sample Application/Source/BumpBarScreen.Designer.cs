namespace TestApplication
{
    partial class BumpBarScreen
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
            this.tbScanCodes = new System.Windows.Forms.TextBox();
            this.tbLogicalKey = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.tbDuration = new System.Windows.Forms.TextBox();
            this.tbCycles = new System.Windows.Forms.TextBox();
            this.tbInterSoundWait = new System.Windows.Forms.TextBox();
            this.tbFrequency = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.cbDeviceUnits = new System.Windows.Forms.ComboBox();
            this.label50 = new System.Windows.Forms.Label();
            this.btnSetKeyTranslation = new System.Windows.Forms.Button();
            this.btnBumpBarSound = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbScanCodes
            // 
            this.tbScanCodes.Location = new System.Drawing.Point(302, 156);
            this.tbScanCodes.Name = "tbScanCodes";
            this.tbScanCodes.Size = new System.Drawing.Size(100, 20);
            this.tbScanCodes.TabIndex = 33;
            // 
            // tbLogicalKey
            // 
            this.tbLogicalKey.Location = new System.Drawing.Point(302, 176);
            this.tbLogicalKey.Name = "tbLogicalKey";
            this.tbLogicalKey.Size = new System.Drawing.Size(100, 20);
            this.tbLogicalKey.TabIndex = 32;
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(188, 182);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(85, 23);
            this.label55.TabIndex = 31;
            this.label55.Text = "LogicalKey";
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(188, 158);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(85, 23);
            this.label56.TabIndex = 30;
            this.label56.Text = "ScanCodes";
            // 
            // tbDuration
            // 
            this.tbDuration.Location = new System.Drawing.Point(303, 73);
            this.tbDuration.Name = "tbDuration";
            this.tbDuration.Size = new System.Drawing.Size(100, 20);
            this.tbDuration.TabIndex = 29;
            this.tbDuration.Text = "1000";
            // 
            // tbCycles
            // 
            this.tbCycles.Location = new System.Drawing.Point(303, 95);
            this.tbCycles.Name = "tbCycles";
            this.tbCycles.Size = new System.Drawing.Size(100, 20);
            this.tbCycles.TabIndex = 28;
            this.tbCycles.Text = "10";
            // 
            // tbInterSoundWait
            // 
            this.tbInterSoundWait.Location = new System.Drawing.Point(303, 115);
            this.tbInterSoundWait.Name = "tbInterSoundWait";
            this.tbInterSoundWait.Size = new System.Drawing.Size(100, 20);
            this.tbInterSoundWait.TabIndex = 27;
            this.tbInterSoundWait.Text = "200";
            // 
            // tbFrequency
            // 
            this.tbFrequency.Location = new System.Drawing.Point(303, 52);
            this.tbFrequency.Name = "tbFrequency";
            this.tbFrequency.Size = new System.Drawing.Size(100, 20);
            this.tbFrequency.TabIndex = 26;
            this.tbFrequency.Text = "1000";
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(189, 121);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(85, 23);
            this.label54.TabIndex = 25;
            this.label54.Text = "InterSoundWait";
            // 
            // label53
            // 
            this.label53.Location = new System.Drawing.Point(189, 97);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(85, 23);
            this.label53.TabIndex = 24;
            this.label53.Text = "NumCycles";
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(189, 73);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(85, 23);
            this.label52.TabIndex = 23;
            this.label52.Text = "Duration";
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(189, 49);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(85, 23);
            this.label51.TabIndex = 22;
            this.label51.Text = "Frequency";
            // 
            // cbDeviceUnits
            // 
            this.cbDeviceUnits.Location = new System.Drawing.Point(303, 27);
            this.cbDeviceUnits.Name = "cbDeviceUnits";
            this.cbDeviceUnits.Size = new System.Drawing.Size(121, 21);
            this.cbDeviceUnits.TabIndex = 21;
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(189, 25);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(85, 23);
            this.label50.TabIndex = 20;
            this.label50.Text = "DeviceUnits";
            // 
            // btnSetKeyTranslation
            // 
            this.btnSetKeyTranslation.Location = new System.Drawing.Point(26, 154);
            this.btnSetKeyTranslation.Name = "btnSetKeyTranslation";
            this.btnSetKeyTranslation.Size = new System.Drawing.Size(122, 23);
            this.btnSetKeyTranslation.TabIndex = 19;
            this.btnSetKeyTranslation.Text = "SetKeyTranslation";
            this.btnSetKeyTranslation.Click += new System.EventHandler(this.btnSetKeyTranslation_Click);
            // 
            // btnBumpBarSound
            // 
            this.btnBumpBarSound.Location = new System.Drawing.Point(23, 23);
            this.btnBumpBarSound.Name = "btnBumpBarSound";
            this.btnBumpBarSound.Size = new System.Drawing.Size(123, 23);
            this.btnBumpBarSound.TabIndex = 18;
            this.btnBumpBarSound.Text = "BumpBarSound";
            this.btnBumpBarSound.Click += new System.EventHandler(this.btnBumpBarSound_Click);
            // 
            // BumpBarScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tbScanCodes);
            this.Controls.Add(this.tbLogicalKey);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.tbDuration);
            this.Controls.Add(this.tbCycles);
            this.Controls.Add(this.tbInterSoundWait);
            this.Controls.Add(this.tbFrequency);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.cbDeviceUnits);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.btnSetKeyTranslation);
            this.Controls.Add(this.btnBumpBarSound);
            this.Name = "BumpBarScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbScanCodes;
        private System.Windows.Forms.TextBox tbLogicalKey;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox tbDuration;
        private System.Windows.Forms.TextBox tbCycles;
        private System.Windows.Forms.TextBox tbInterSoundWait;
        private System.Windows.Forms.TextBox tbFrequency;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.ComboBox cbDeviceUnits;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Button btnSetKeyTranslation;
        private System.Windows.Forms.Button btnBumpBarSound;
    }
}
