namespace ManagingSystem
{
    partial class HardwareCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HardwareCode));
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabelCurrent = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radButtonOpenAppFolder = new Telerik.WinControls.UI.RadButton();
            this.radTextBoxMachineID = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonOpenAppFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxMachineID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(48, 29);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(336, 46);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = resources.GetString("radLabel1.Text");
            // 
            // radLabelCurrent
            // 
            this.radLabelCurrent.Location = new System.Drawing.Point(48, 91);
            this.radLabelCurrent.Name = "radLabelCurrent";
            this.radLabelCurrent.Size = new System.Drawing.Size(190, 18);
            this.radLabelCurrent.TabIndex = 1;
            this.radLabelCurrent.Text = "Your Current License Avaliable Until: ";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(48, 126);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(95, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Your Machine ID: ";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(48, 162);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(391, 18);
            this.radLabel3.TabIndex = 3;
            this.radLabel3.Text = "If you have obtained the license file, please drop it to the application\'s folder" +
    ".";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(48, 196);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(227, 18);
            this.radLabel4.TabIndex = 4;
            this.radLabel4.Text = "Click this button to open application\'s foler: ";
            // 
            // radButtonOpenAppFolder
            // 
            this.radButtonOpenAppFolder.Location = new System.Drawing.Point(281, 193);
            this.radButtonOpenAppFolder.Name = "radButtonOpenAppFolder";
            this.radButtonOpenAppFolder.Size = new System.Drawing.Size(158, 24);
            this.radButtonOpenAppFolder.TabIndex = 5;
            this.radButtonOpenAppFolder.Text = "Open Application Folder";
            this.radButtonOpenAppFolder.Click += new System.EventHandler(this.radButtonOpenAppFolder_Click);
            // 
            // radTextBoxMachineID
            // 
            this.radTextBoxMachineID.Location = new System.Drawing.Point(150, 125);
            this.radTextBoxMachineID.Name = "radTextBoxMachineID";
            this.radTextBoxMachineID.ReadOnly = true;
            this.radTextBoxMachineID.Size = new System.Drawing.Size(289, 20);
            this.radTextBoxMachineID.TabIndex = 6;
            this.radTextBoxMachineID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // HardwareCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 266);
            this.Controls.Add(this.radTextBoxMachineID);
            this.Controls.Add(this.radButtonOpenAppFolder);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabelCurrent);
            this.Controls.Add(this.radLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HardwareCode";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VR Arcade Registration Information";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonOpenAppFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxMachineID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabelCurrent;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadButton radButtonOpenAppFolder;
        private Telerik.WinControls.UI.RadTextBox radTextBoxMachineID;
    }
}
