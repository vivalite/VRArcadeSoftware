namespace VRGameSelectorClientDaemon
{
    partial class ClientDaemonMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientDaemonMain));
            this.lblConnS = new System.Windows.Forms.Label();
            this.lblConnUI = new System.Windows.Forms.Label();
            this.lblConnDashboard = new System.Windows.Forms.Label();
            this.labelMachineName = new System.Windows.Forms.Label();
            this.labelIP = new System.Windows.Forms.Label();
            this.labelMAC = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblConnS
            // 
            this.lblConnS.AutoSize = true;
            this.lblConnS.Location = new System.Drawing.Point(22, 21);
            this.lblConnS.Name = "lblConnS";
            this.lblConnS.Size = new System.Drawing.Size(113, 13);
            this.lblConnS.TabIndex = 0;
            this.lblConnS.Text = "Server Connected: No";
            // 
            // lblConnUI
            // 
            this.lblConnUI.AutoSize = true;
            this.lblConnUI.Location = new System.Drawing.Point(22, 46);
            this.lblConnUI.Name = "lblConnUI";
            this.lblConnUI.Size = new System.Drawing.Size(124, 13);
            this.lblConnUI.TabIndex = 1;
            this.lblConnUI.Text = "Client UI Connection: No";
            // 
            // lblConnDashboard
            // 
            this.lblConnDashboard.AutoSize = true;
            this.lblConnDashboard.Location = new System.Drawing.Point(22, 71);
            this.lblConnDashboard.Name = "lblConnDashboard";
            this.lblConnDashboard.Size = new System.Drawing.Size(165, 13);
            this.lblConnDashboard.TabIndex = 2;
            this.lblConnDashboard.Text = "Client Dashboard Connection: No";
            // 
            // labelMachineName
            // 
            this.labelMachineName.AutoSize = true;
            this.labelMachineName.Location = new System.Drawing.Point(242, 21);
            this.labelMachineName.Name = "labelMachineName";
            this.labelMachineName.Size = new System.Drawing.Size(82, 13);
            this.labelMachineName.TabIndex = 3;
            this.labelMachineName.Text = "Machine Name:";
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(242, 46);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(20, 13);
            this.labelIP.TabIndex = 4;
            this.labelIP.Text = "IP:";
            // 
            // labelMAC
            // 
            this.labelMAC.AutoSize = true;
            this.labelMAC.Location = new System.Drawing.Point(242, 71);
            this.labelMAC.Name = "labelMAC";
            this.labelMAC.Size = new System.Drawing.Size(33, 13);
            this.labelMAC.TabIndex = 5;
            this.labelMAC.Text = "MAC:";
            // 
            // ClientDaemonMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 103);
            this.Controls.Add(this.labelMAC);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.labelMachineName);
            this.Controls.Add(this.lblConnDashboard);
            this.Controls.Add(this.lblConnUI);
            this.Controls.Add(this.lblConnS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ClientDaemonMain";
            this.Text = "Client Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientDaemonMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientDaemonMain_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConnS;
        private System.Windows.Forms.Label lblConnUI;
        private System.Windows.Forms.Label lblConnDashboard;
        private System.Windows.Forms.Label labelMachineName;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelMAC;
    }
}

