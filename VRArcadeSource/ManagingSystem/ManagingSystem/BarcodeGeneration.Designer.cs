namespace ManagingSystem
{
    partial class BarcodeGeneration
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
            this.radSpinEditorSessionTime = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabelMin = new Telerik.WinControls.UI.RadLabel();
            this.radButtonPrintNow = new Telerik.WinControls.UI.RadButton();
            this.radGroupBoxQ1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radTrackBarNumPrint = new Telerik.WinControls.UI.RadTrackBar();
            this.radSpinEditorNumPrint = new Telerik.WinControls.UI.RadSpinEditor();
            this.radGroupBoxQ2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radRadioButtonNonTimed = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioButtonTimed = new Telerik.WinControls.UI.RadRadioButton();
            this.radButtonCancel = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radSpinEditorSessionTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonPrintNow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBoxQ1)).BeginInit();
            this.radGroupBoxQ1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTrackBarNumPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSpinEditorNumPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBoxQ2)).BeginInit();
            this.radGroupBoxQ2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButtonNonTimed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButtonTimed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radSpinEditorSessionTime
            // 
            this.radSpinEditorSessionTime.Enabled = false;
            this.radSpinEditorSessionTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSpinEditorSessionTime.Location = new System.Drawing.Point(159, 50);
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
            this.radSpinEditorSessionTime.TabIndex = 4;
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
            // radLabelMin
            // 
            this.radLabelMin.BackColor = System.Drawing.Color.Transparent;
            this.radLabelMin.Enabled = false;
            this.radLabelMin.Location = new System.Drawing.Point(213, 53);
            this.radLabelMin.Name = "radLabelMin";
            this.radLabelMin.Size = new System.Drawing.Size(32, 18);
            this.radLabelMin.TabIndex = 48;
            this.radLabelMin.Text = "(Min)";
            // 
            // radButtonPrintNow
            // 
            this.radButtonPrintNow.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonPrintNow.Image = global::ManagingSystem.Properties.Resources.Barcode;
            this.radButtonPrintNow.Location = new System.Drawing.Point(79, 335);
            this.radButtonPrintNow.Name = "radButtonPrintNow";
            this.radButtonPrintNow.Size = new System.Drawing.Size(120, 38);
            this.radButtonPrintNow.TabIndex = 6;
            this.radButtonPrintNow.Text = "Print Now!";
            this.radButtonPrintNow.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radButtonPrintNow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButtonPrintNow.Click += new System.EventHandler(this.radButtonPrintNow_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonPrintNow.GetChildAt(0))).Image = global::ManagingSystem.Properties.Resources.Barcode;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonPrintNow.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonPrintNow.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonPrintNow.GetChildAt(0))).Text = "Print Now!";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonPrintNow.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonPrintNow.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonPrintNow.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonPrintNow.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(25, 25);
            // 
            // radGroupBoxQ1
            // 
            this.radGroupBoxQ1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBoxQ1.Controls.Add(this.radTrackBarNumPrint);
            this.radGroupBoxQ1.Controls.Add(this.radSpinEditorNumPrint);
            this.radGroupBoxQ1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radGroupBoxQ1.HeaderText = "1. How Many Tickets To Print";
            this.radGroupBoxQ1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBoxQ1.Name = "radGroupBoxQ1";
            this.radGroupBoxQ1.Size = new System.Drawing.Size(448, 123);
            this.radGroupBoxQ1.TabIndex = 49;
            this.radGroupBoxQ1.Text = "1. How Many Tickets To Print";
            // 
            // radTrackBarNumPrint
            // 
            this.radTrackBarNumPrint.LabelStyle = Telerik.WinControls.UI.TrackBarLabelStyle.Both;
            this.radTrackBarNumPrint.Location = new System.Drawing.Point(32, 33);
            this.radTrackBarNumPrint.Name = "radTrackBarNumPrint";
            this.radTrackBarNumPrint.ShowButtons = true;
            this.radTrackBarNumPrint.Size = new System.Drawing.Size(309, 70);
            this.radTrackBarNumPrint.TabIndex = 1;
            this.radTrackBarNumPrint.Text = "radTrackBarNumPrint";
            this.radTrackBarNumPrint.ValueChanged += new System.EventHandler(this.radTrackBarNumPrint_ValueChanged);
            // 
            // radSpinEditorNumPrint
            // 
            this.radSpinEditorNumPrint.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSpinEditorNumPrint.Location = new System.Drawing.Point(363, 57);
            this.radSpinEditorNumPrint.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.radSpinEditorNumPrint.Name = "radSpinEditorNumPrint";
            this.radSpinEditorNumPrint.Size = new System.Drawing.Size(47, 23);
            this.radSpinEditorNumPrint.TabIndex = 2;
            this.radSpinEditorNumPrint.TabStop = false;
            this.radSpinEditorNumPrint.ValueChanged += new System.EventHandler(this.radSpinEditorNumPrint_ValueChanged);
            this.radSpinEditorNumPrint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radSpinEditorNumPrint_MouseDown);
            ((Telerik.WinControls.UI.RadSpinElement)(this.radSpinEditorNumPrint.GetChildAt(0))).StretchVertically = true;
            ((Telerik.WinControls.UI.RadSpinElement)(this.radSpinEditorNumPrint.GetChildAt(0))).StretchHorizontally = true;
            ((Telerik.WinControls.UI.StackLayoutElement)(this.radSpinEditorNumPrint.GetChildAt(0).GetChildAt(2))).Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // radGroupBoxQ2
            // 
            this.radGroupBoxQ2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBoxQ2.Controls.Add(this.radRadioButtonNonTimed);
            this.radGroupBoxQ2.Controls.Add(this.radRadioButtonTimed);
            this.radGroupBoxQ2.Controls.Add(this.radSpinEditorSessionTime);
            this.radGroupBoxQ2.Controls.Add(this.radLabelMin);
            this.radGroupBoxQ2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radGroupBoxQ2.HeaderText = "2. Which Type of Ticket to Print";
            this.radGroupBoxQ2.Location = new System.Drawing.Point(12, 151);
            this.radGroupBoxQ2.Name = "radGroupBoxQ2";
            this.radGroupBoxQ2.Size = new System.Drawing.Size(448, 107);
            this.radGroupBoxQ2.TabIndex = 50;
            this.radGroupBoxQ2.Text = "2. Which Type of Ticket to Print";
            // 
            // radRadioButtonNonTimed
            // 
            this.radRadioButtonNonTimed.Location = new System.Drawing.Point(284, 54);
            this.radRadioButtonNonTimed.Name = "radRadioButtonNonTimed";
            this.radRadioButtonNonTimed.Size = new System.Drawing.Size(110, 18);
            this.radRadioButtonNonTimed.TabIndex = 5;
            this.radRadioButtonNonTimed.Text = "Non-Timed Ticket";
            this.radRadioButtonNonTimed.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButtonNonTimed_ToggleStateChanged);
            // 
            // radRadioButtonTimed
            // 
            this.radRadioButtonTimed.Location = new System.Drawing.Point(56, 54);
            this.radRadioButtonTimed.Name = "radRadioButtonTimed";
            this.radRadioButtonTimed.Size = new System.Drawing.Size(84, 18);
            this.radRadioButtonTimed.TabIndex = 3;
            this.radRadioButtonTimed.Text = "Timed Ticket";
            this.radRadioButtonTimed.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButtonTimed_ToggleStateChanged);
            // 
            // radButtonCancel
            // 
            this.radButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.radButtonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonCancel.Location = new System.Drawing.Point(264, 335);
            this.radButtonCancel.Name = "radButtonCancel";
            this.radButtonCancel.Size = new System.Drawing.Size(115, 38);
            this.radButtonCancel.TabIndex = 7;
            this.radButtonCancel.Text = "Cancel";
            this.radButtonCancel.Click += new System.EventHandler(this.radButtonCancel_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonCancel.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonCancel.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonCancel.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonCancel.GetChildAt(0))).Text = "Cancel";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonCancel.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonCancel.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonCancel.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonCancel.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(25, 25);
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.radLabel2.Location = new System.Drawing.Point(12, 264);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(448, 49);
            this.radLabel2.TabIndex = 51;
            this.radLabel2.Text = "<html><span style=\"font-size: 12pt\">Please Note: This feature is designed for pro" +
    "blem fixing. Use Process Waiver to issue tickets instetad.</span></html>";
            // 
            // BarcodeGeneration
            // 
            this.AcceptButton = this.radButtonPrintNow;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.radButtonCancel;
            this.ClientSize = new System.Drawing.Size(472, 395);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radButtonCancel);
            this.Controls.Add(this.radGroupBoxQ2);
            this.Controls.Add(this.radGroupBoxQ1);
            this.Controls.Add(this.radButtonPrintNow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BarcodeGeneration";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Barcode Generation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BarcodeGeneration_FormClosed);
            this.Load += new System.EventHandler(this.BarcodeGeneration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radSpinEditorSessionTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonPrintNow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBoxQ1)).EndInit();
            this.radGroupBoxQ1.ResumeLayout(false);
            this.radGroupBoxQ1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTrackBarNumPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSpinEditorNumPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBoxQ2)).EndInit();
            this.radGroupBoxQ2.ResumeLayout(false);
            this.radGroupBoxQ2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButtonNonTimed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButtonTimed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadSpinEditor radSpinEditorSessionTime;
        private Telerik.WinControls.UI.RadLabel radLabelMin;
        private Telerik.WinControls.UI.RadButton radButtonPrintNow;
        private Telerik.WinControls.UI.RadGroupBox radGroupBoxQ1;
        private Telerik.WinControls.UI.RadSpinEditor radSpinEditorNumPrint;
        private Telerik.WinControls.UI.RadGroupBox radGroupBoxQ2;
        private Telerik.WinControls.UI.RadButton radButtonCancel;
        private Telerik.WinControls.UI.RadTrackBar radTrackBarNumPrint;
        private Telerik.WinControls.UI.RadRadioButton radRadioButtonNonTimed;
        private Telerik.WinControls.UI.RadRadioButton radRadioButtonTimed;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}
