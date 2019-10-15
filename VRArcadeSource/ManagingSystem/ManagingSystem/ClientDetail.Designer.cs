namespace ManagingSystem
{
    partial class ClientDetail
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.textBoxIPAddress = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.textBoxMachineName = new Telerik.WinControls.UI.RadTextBox();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.comboBoxConfigSet = new Telerik.WinControls.UI.RadDropDownList();
            this.buttonOK = new Telerik.WinControls.UI.RadButton();
            this.buttonCancel = new Telerik.WinControls.UI.RadButton();
            this.textBoxDashboardModuleIP = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxIPAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxMachineName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxConfigSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxDashboardModuleIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(36, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address";
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(236, 30);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.Size = new System.Drawing.Size(200, 20);
            this.textBoxIPAddress.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(36, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Machine Name";
            // 
            // textBoxMachineName
            // 
            this.textBoxMachineName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBoxMachineName.Cursor = System.Windows.Forms.Cursors.No;
            this.textBoxMachineName.Enabled = false;
            this.textBoxMachineName.Location = new System.Drawing.Point(236, 67);
            this.textBoxMachineName.Name = "textBoxMachineName";
            this.textBoxMachineName.Size = new System.Drawing.Size(200, 20);
            this.textBoxMachineName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(36, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tile Configuration Set";
            // 
            // comboBoxConfigSet
            // 
            this.comboBoxConfigSet.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem1.Text = "Config Set 1";
            this.comboBoxConfigSet.Items.Add(radListDataItem1);
            this.comboBoxConfigSet.Location = new System.Drawing.Point(236, 141);
            this.comboBoxConfigSet.Name = "comboBoxConfigSet";
            this.comboBoxConfigSet.Size = new System.Drawing.Size(200, 20);
            this.comboBoxConfigSet.TabIndex = 8;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(122, 190);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(272, 190);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxDashboardModuleIP
            // 
            this.textBoxDashboardModuleIP.Location = new System.Drawing.Point(236, 104);
            this.textBoxDashboardModuleIP.Name = "textBoxDashboardModuleIP";
            this.textBoxDashboardModuleIP.Size = new System.Drawing.Size(200, 20);
            this.textBoxDashboardModuleIP.TabIndex = 12;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(36, 106);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(182, 18);
            this.radLabel1.TabIndex = 11;
            this.radLabel1.Text = "LCD Dashboard Module IP Address";
            this.toolTipInfo.SetToolTip(this.radLabel1, "If you don\'t have the LCD Dashboard module hardware please leave it empty.");
            // 
            // ClientDetail
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(479, 239);
            this.Controls.Add(this.textBoxDashboardModuleIP);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxConfigSet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMachineName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIPAddress);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Client Detail";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientDetail_FormClosed);
            this.Load += new System.EventHandler(this.ClientDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxIPAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxMachineName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxConfigSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxDashboardModuleIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadTextBox textBoxIPAddress;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadTextBox textBoxMachineName;
        private Telerik.WinControls.UI.RadLabel label3;
        private Telerik.WinControls.UI.RadDropDownList comboBoxConfigSet;
        private Telerik.WinControls.UI.RadButton buttonOK;
        private Telerik.WinControls.UI.RadButton buttonCancel;
        private Telerik.WinControls.UI.RadTextBox textBoxDashboardModuleIP;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.ToolTip toolTipInfo;
    }
}