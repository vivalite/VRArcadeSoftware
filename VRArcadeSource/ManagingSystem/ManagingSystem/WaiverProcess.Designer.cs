namespace ManagingSystem
{
    partial class WaiverProcess
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
            this.radListViewClientList = new Telerik.WinControls.UI.RadListView();
            this.radButtonSelectNone = new Telerik.WinControls.UI.RadButton();
            this.radButtonSelectAll = new Telerik.WinControls.UI.RadButton();
            this.radButtonSelectReverse = new Telerik.WinControls.UI.RadButton();
            this.radButtonPrintTicket = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radButtonDeleteWaiver = new Telerik.WinControls.UI.RadButton();
            this.radButtonClose = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radListViewClientList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonSelectNone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonSelectAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonSelectReverse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonPrintTicket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonDeleteWaiver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radListViewClientList
            // 
            this.radListViewClientList.ItemSpacing = -1;
            this.radListViewClientList.Location = new System.Drawing.Point(12, 12);
            this.radListViewClientList.Name = "radListViewClientList";
            this.radListViewClientList.Size = new System.Drawing.Size(931, 422);
            this.radListViewClientList.TabIndex = 1;
            this.radListViewClientList.Text = "radListView1";
            this.radListViewClientList.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.radListViewClientList.ItemMouseClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.radListViewClientList_ItemMouseClick);
            this.radListViewClientList.VisualItemFormatting += new Telerik.WinControls.UI.ListViewVisualItemEventHandler(this.radListViewClientList_VisualItemFormatting);
            this.radListViewClientList.CellFormatting += new Telerik.WinControls.UI.ListViewCellFormattingEventHandler(this.radListViewClientList_CellFormatting);
            this.radListViewClientList.ColumnCreating += new Telerik.WinControls.UI.ListViewColumnCreatingEventHandler(this.radListViewClientList_ColumnCreating);
            this.radListViewClientList.CellCreating += new Telerik.WinControls.UI.ListViewCellElementCreatingEventHandler(this.radListViewClientList_CellCreating);
            // 
            // radButtonSelectNone
            // 
            this.radButtonSelectNone.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonSelectNone.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButtonSelectNone.Location = new System.Drawing.Point(12, 448);
            this.radButtonSelectNone.Name = "radButtonSelectNone";
            this.radButtonSelectNone.Size = new System.Drawing.Size(82, 38);
            this.radButtonSelectNone.TabIndex = 2;
            this.radButtonSelectNone.Text = "Select None";
            this.radButtonSelectNone.Click += new System.EventHandler(this.radButtonSelectNone_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectNone.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectNone.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectNone.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectNone.GetChildAt(0))).Text = "Select None";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectNone.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectNone.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectNone.GetChildAt(0).GetChildAt(1).GetChildAt(0))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectNone.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(30, 30);
            // 
            // radButtonSelectAll
            // 
            this.radButtonSelectAll.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonSelectAll.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButtonSelectAll.Location = new System.Drawing.Point(100, 448);
            this.radButtonSelectAll.Name = "radButtonSelectAll";
            this.radButtonSelectAll.Size = new System.Drawing.Size(82, 38);
            this.radButtonSelectAll.TabIndex = 3;
            this.radButtonSelectAll.Text = "Select All";
            this.radButtonSelectAll.Click += new System.EventHandler(this.radButtonSelectAll_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectAll.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectAll.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectAll.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectAll.GetChildAt(0))).Text = "Select All";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectAll.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectAll.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectAll.GetChildAt(0).GetChildAt(1).GetChildAt(0))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectAll.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(30, 30);
            // 
            // radButtonSelectReverse
            // 
            this.radButtonSelectReverse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonSelectReverse.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButtonSelectReverse.Location = new System.Drawing.Point(188, 448);
            this.radButtonSelectReverse.Name = "radButtonSelectReverse";
            this.radButtonSelectReverse.Size = new System.Drawing.Size(106, 38);
            this.radButtonSelectReverse.TabIndex = 4;
            this.radButtonSelectReverse.Text = "Select Reverse";
            this.radButtonSelectReverse.Click += new System.EventHandler(this.radButtonSelectReverse_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectReverse.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectReverse.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectReverse.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonSelectReverse.GetChildAt(0))).Text = "Select Reverse";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectReverse.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectReverse.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectReverse.GetChildAt(0).GetChildAt(1).GetChildAt(0))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonSelectReverse.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(30, 30);
            // 
            // radButtonPrintTicket
            // 
            this.radButtonPrintTicket.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonPrintTicket.Image = global::ManagingSystem.Properties.Resources.Barcode;
            this.radButtonPrintTicket.Location = new System.Drawing.Point(707, 448);
            this.radButtonPrintTicket.Name = "radButtonPrintTicket";
            this.radButtonPrintTicket.Size = new System.Drawing.Size(236, 38);
            this.radButtonPrintTicket.TabIndex = 7;
            this.radButtonPrintTicket.Text = "Print Ticket For Selected Clients";
            this.radButtonPrintTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButtonPrintTicket.Click += new System.EventHandler(this.radButtonPrintTicket_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonPrintTicket.GetChildAt(0))).Image = global::ManagingSystem.Properties.Resources.Barcode;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonPrintTicket.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonPrintTicket.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonPrintTicket.GetChildAt(0))).Text = "Print Ticket For Selected Clients";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonPrintTicket.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonPrintTicket.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonPrintTicket.GetChildAt(0).GetChildAt(1).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonPrintTicket.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonPrintTicket.GetChildAt(0).GetChildAt(1).GetChildAt(0))).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.Auto;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonPrintTicket.GetChildAt(0).GetChildAt(1).GetChildAt(0))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonPrintTicket.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(25, 25);
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.radLabel2.Location = new System.Drawing.Point(12, 498);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(931, 68);
            this.radLabel2.TabIndex = 44;
            this.radLabel2.Text = "<html><span style=\"font-size: 12pt\">Please Note: <br />You are responsible to che" +
    "ck whether the client is paid. Only issue ticket to the paid clients.</span></ht" +
    "ml>";
            // 
            // radButtonDeleteWaiver
            // 
            this.radButtonDeleteWaiver.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonDeleteWaiver.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButtonDeleteWaiver.Location = new System.Drawing.Point(335, 448);
            this.radButtonDeleteWaiver.Name = "radButtonDeleteWaiver";
            this.radButtonDeleteWaiver.Size = new System.Drawing.Size(106, 38);
            this.radButtonDeleteWaiver.TabIndex = 45;
            this.radButtonDeleteWaiver.Text = "Archive Record";
            this.radButtonDeleteWaiver.Click += new System.EventHandler(this.radButtonDeleteWaiver_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonDeleteWaiver.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonDeleteWaiver.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonDeleteWaiver.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButtonDeleteWaiver.GetChildAt(0))).Text = "Archive Record";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonDeleteWaiver.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonDeleteWaiver.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonDeleteWaiver.GetChildAt(0).GetChildAt(1).GetChildAt(0))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButtonDeleteWaiver.GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(30, 30);
            // 
            // radButtonClose
            // 
            this.radButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.radButtonClose.Location = new System.Drawing.Point(833, 0);
            this.radButtonClose.Name = "radButtonClose";
            this.radButtonClose.Size = new System.Drawing.Size(110, 24);
            this.radButtonClose.TabIndex = 46;
            this.radButtonClose.Text = "Close";
            this.radButtonClose.Visible = false;
            this.radButtonClose.Click += new System.EventHandler(this.radButtonClose_Click);
            // 
            // WaiverProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.radButtonClose;
            this.ClientSize = new System.Drawing.Size(955, 578);
            this.Controls.Add(this.radButtonClose);
            this.Controls.Add(this.radButtonDeleteWaiver);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radButtonPrintTicket);
            this.Controls.Add(this.radButtonSelectReverse);
            this.Controls.Add(this.radButtonSelectAll);
            this.Controls.Add(this.radButtonSelectNone);
            this.Controls.Add(this.radListViewClientList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaiverProcess";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Process Waiver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WaiverProcess_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManagerFeatures_FormClosed);
            this.Load += new System.EventHandler(this.ManagerFeatures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radListViewClientList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonSelectNone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonSelectAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonSelectReverse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonPrintTicket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonDeleteWaiver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadListView radListViewClientList;
        private Telerik.WinControls.UI.RadButton radButtonSelectNone;
        private Telerik.WinControls.UI.RadButton radButtonSelectAll;
        private Telerik.WinControls.UI.RadButton radButtonSelectReverse;
        private Telerik.WinControls.UI.RadButton radButtonPrintTicket;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton radButtonDeleteWaiver;
        private Telerik.WinControls.UI.RadButton radButtonClose;
    }
}
