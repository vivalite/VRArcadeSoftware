namespace TestApplication
{
    partial class KeylockScreen
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
            this.tbKeyPosition = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label81 = new System.Windows.Forms.Label();
            this.btnWaitForKeylockChange = new System.Windows.Forms.Button();
            this.cbWaitPosition = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.tbKeylockTimeout = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbKeyPosition
            // 
            this.tbKeyPosition.Location = new System.Drawing.Point(149, 19);
            this.tbKeyPosition.Name = "tbKeyPosition";
            this.tbKeyPosition.ReadOnly = true;
            this.tbKeyPosition.Size = new System.Drawing.Size(120, 20);
            this.tbKeyPosition.TabIndex = 13;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label81);
            this.groupBox5.Controls.Add(this.btnWaitForKeylockChange);
            this.groupBox5.Controls.Add(this.cbWaitPosition);
            this.groupBox5.Location = new System.Drawing.Point(53, 92);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(239, 100);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "WaitForKeylockChange";
            // 
            // label81
            // 
            this.label81.Location = new System.Drawing.Point(6, 31);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(79, 23);
            this.label81.TabIndex = 8;
            this.label81.Text = "KeyPosition";
            // 
            // btnWaitForKeylockChange
            // 
            this.btnWaitForKeylockChange.Location = new System.Drawing.Point(45, 64);
            this.btnWaitForKeylockChange.Name = "btnWaitForKeylockChange";
            this.btnWaitForKeylockChange.Size = new System.Drawing.Size(171, 23);
            this.btnWaitForKeylockChange.TabIndex = 6;
            this.btnWaitForKeylockChange.Text = "WaitForkeylockChange";
            this.btnWaitForKeylockChange.Click += new System.EventHandler(this.btnWaitForKeylockChange_Click);
            // 
            // cbWaitPosition
            // 
            this.cbWaitPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWaitPosition.ItemHeight = 13;
            this.cbWaitPosition.Location = new System.Drawing.Point(95, 28);
            this.cbWaitPosition.Name = "cbWaitPosition";
            this.cbWaitPosition.Size = new System.Drawing.Size(121, 21);
            this.cbWaitPosition.TabIndex = 2;
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(38, 22);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(100, 23);
            this.label37.TabIndex = 9;
            this.label37.Text = "Keylock Position";
            // 
            // tbKeylockTimeout
            // 
            this.tbKeylockTimeout.Location = new System.Drawing.Point(149, 53);
            this.tbKeylockTimeout.Name = "tbKeylockTimeout";
            this.tbKeylockTimeout.Size = new System.Drawing.Size(120, 20);
            this.tbKeylockTimeout.TabIndex = 11;
            this.tbKeylockTimeout.Text = "5000";
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(38, 52);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(100, 23);
            this.label38.TabIndex = 10;
            this.label38.Text = "Timeout";
            // 
            // KeylockScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tbKeyPosition);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.tbKeylockTimeout);
            this.Controls.Add(this.label38);
            this.Name = "KeylockScreen";
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbKeyPosition;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Button btnWaitForKeylockChange;
        private System.Windows.Forms.ComboBox cbWaitPosition;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox tbKeylockTimeout;
        private System.Windows.Forms.Label label38;
    }
}
