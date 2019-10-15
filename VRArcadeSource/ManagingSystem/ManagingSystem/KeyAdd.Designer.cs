namespace ManagingSystem
{
    partial class KeyAdd
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.comboBoxKeyType = new Telerik.WinControls.UI.RadDropDownList();
            this.buttonOK = new Telerik.WinControls.UI.RadButton();
            this.buttonCancel = new Telerik.WinControls.UI.RadButton();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.radSpinEditorSessionTime = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxKeyType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSpinEditorSessionTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(26, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Key Type";
            // 
            // comboBoxKeyType
            // 
            this.comboBoxKeyType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem2.Text = "Config Set 1";
            this.comboBoxKeyType.Items.Add(radListDataItem2);
            this.comboBoxKeyType.Location = new System.Drawing.Point(94, 28);
            this.comboBoxKeyType.Name = "comboBoxKeyType";
            this.comboBoxKeyType.Size = new System.Drawing.Size(218, 20);
            this.comboBoxKeyType.TabIndex = 8;
            this.comboBoxKeyType.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.comboBoxKeyType_SelectedIndexChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(67, 112);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(192, 112);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // radSpinEditorSessionTime
            // 
            this.radSpinEditorSessionTime.Enabled = false;
            this.radSpinEditorSessionTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSpinEditorSessionTime.Location = new System.Drawing.Point(94, 63);
            this.radSpinEditorSessionTime.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.radSpinEditorSessionTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.radSpinEditorSessionTime.Name = "radSpinEditorSessionTime";
            this.radSpinEditorSessionTime.Size = new System.Drawing.Size(48, 23);
            this.radSpinEditorSessionTime.TabIndex = 12;
            this.radSpinEditorSessionTime.TabStop = false;
            this.radSpinEditorSessionTime.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            ((Telerik.WinControls.UI.RadSpinElement)(this.radSpinEditorSessionTime.GetChildAt(0))).StretchVertically = true;
            ((Telerik.WinControls.UI.RadSpinElement)(this.radSpinEditorSessionTime.GetChildAt(0))).StretchHorizontally = true;
            ((Telerik.WinControls.UI.StackLayoutElement)(this.radSpinEditorSessionTime.GetChildAt(0).GetChildAt(2))).Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(26, 67);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(46, 18);
            this.radLabel1.TabIndex = 13;
            this.radLabel1.Text = "Minutes";
            // 
            // KeyAdd
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(342, 157);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radSpinEditorSessionTime);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxKeyType);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyAdd";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Key";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientDetail_FormClosed);
            this.Load += new System.EventHandler(this.ClientDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxKeyType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSpinEditorSessionTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel label3;
        private Telerik.WinControls.UI.RadDropDownList comboBoxKeyType;
        private Telerik.WinControls.UI.RadButton buttonOK;
        private Telerik.WinControls.UI.RadButton buttonCancel;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private Telerik.WinControls.UI.RadSpinEditor radSpinEditorSessionTime;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}