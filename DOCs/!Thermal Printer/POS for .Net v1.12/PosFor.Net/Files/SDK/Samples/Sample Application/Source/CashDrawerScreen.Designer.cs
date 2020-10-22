namespace TestApplication
{
    partial class CashDrawerScreen
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
            this.label18 = new System.Windows.Forms.Label();
            this.BeepDelaytextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.BeepDurationtextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.BeepFrequencytextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.BeepTimeouttextBox = new System.Windows.Forms.TextBox();
            this.WaitForDrawerCloseButton = new System.Windows.Forms.Button();
            this.OpenDrawerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(157, 144);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 23);
            this.label18.TabIndex = 19;
            this.label18.Text = "Beep Delay";
            // 
            // BeepDelaytextBox
            // 
            this.BeepDelaytextBox.Location = new System.Drawing.Point(271, 143);
            this.BeepDelaytextBox.Name = "BeepDelaytextBox";
            this.BeepDelaytextBox.Size = new System.Drawing.Size(100, 20);
            this.BeepDelaytextBox.TabIndex = 18;
            this.BeepDelaytextBox.Text = "1000";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(157, 117);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 23);
            this.label17.TabIndex = 17;
            this.label17.Text = "Beep Duration";
            // 
            // BeepDurationtextBox
            // 
            this.BeepDurationtextBox.Location = new System.Drawing.Point(271, 116);
            this.BeepDurationtextBox.Name = "BeepDurationtextBox";
            this.BeepDurationtextBox.Size = new System.Drawing.Size(100, 20);
            this.BeepDurationtextBox.TabIndex = 16;
            this.BeepDurationtextBox.Text = "100";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(157, 90);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 23);
            this.label16.TabIndex = 15;
            this.label16.Text = "Beep Frequency";
            // 
            // BeepFrequencytextBox
            // 
            this.BeepFrequencytextBox.Location = new System.Drawing.Point(271, 89);
            this.BeepFrequencytextBox.Name = "BeepFrequencytextBox";
            this.BeepFrequencytextBox.Size = new System.Drawing.Size(100, 20);
            this.BeepFrequencytextBox.TabIndex = 14;
            this.BeepFrequencytextBox.Text = "1000";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(157, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 23);
            this.label15.TabIndex = 13;
            this.label15.Text = "Beep Timeout";
            // 
            // BeepTimeouttextBox
            // 
            this.BeepTimeouttextBox.Location = new System.Drawing.Point(271, 61);
            this.BeepTimeouttextBox.Name = "BeepTimeouttextBox";
            this.BeepTimeouttextBox.Size = new System.Drawing.Size(100, 20);
            this.BeepTimeouttextBox.TabIndex = 12;
            this.BeepTimeouttextBox.Text = "5000";
            // 
            // WaitForDrawerCloseButton
            // 
            this.WaitForDrawerCloseButton.Location = new System.Drawing.Point(32, 59);
            this.WaitForDrawerCloseButton.Name = "WaitForDrawerCloseButton";
            this.WaitForDrawerCloseButton.Size = new System.Drawing.Size(117, 23);
            this.WaitForDrawerCloseButton.TabIndex = 11;
            this.WaitForDrawerCloseButton.Text = "WaitForDrawerClose";
            this.WaitForDrawerCloseButton.Click += new System.EventHandler(this.WaitForDrawerCloseButton_Click);
            // 
            // OpenDrawerButton
            // 
            this.OpenDrawerButton.Location = new System.Drawing.Point(31, 23);
            this.OpenDrawerButton.Name = "OpenDrawerButton";
            this.OpenDrawerButton.Size = new System.Drawing.Size(119, 23);
            this.OpenDrawerButton.TabIndex = 10;
            this.OpenDrawerButton.Text = "OpenDrawer";
            this.OpenDrawerButton.Click += new System.EventHandler(this.OpenDrawerButton_Click);
            // 
            // CashDrawerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.BeepDelaytextBox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.BeepDurationtextBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.BeepFrequencytextBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.BeepTimeouttextBox);
            this.Controls.Add(this.WaitForDrawerCloseButton);
            this.Controls.Add(this.OpenDrawerButton);
            this.Name = "CashDrawerScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox BeepDelaytextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox BeepDurationtextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox BeepFrequencytextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox BeepTimeouttextBox;
        private System.Windows.Forms.Button WaitForDrawerCloseButton;
        private System.Windows.Forms.Button OpenDrawerButton;
    }
}
