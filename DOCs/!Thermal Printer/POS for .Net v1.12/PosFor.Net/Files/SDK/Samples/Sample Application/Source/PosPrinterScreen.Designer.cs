namespace TestApplication
{
    partial class PosPrinterScreen
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
            this.btnValidateData = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.btnPrintBitmap = new System.Windows.Forms.Button();
            this.cbTextPosition = new System.Windows.Forms.ComboBox();
            this.cbAlignment = new System.Windows.Forms.ComboBox();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.cbSymbology = new System.Windows.Forms.ComboBox();
            this.btnPrintBarcode = new System.Windows.Forms.Button();
            this.btnPrintTwoNormal = new System.Windows.Forms.Button();
            this.Timeout = new System.Windows.Forms.Label();
            this.tbTimeout = new System.Windows.Forms.TextBox();
            this.btnEndRemoval = new System.Windows.Forms.Button();
            this.btnBeginRemoval = new System.Windows.Forms.Button();
            this.btnEndInsertion = new System.Windows.Forms.Button();
            this.btnBeginInsertion = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnPrintImmediate = new System.Windows.Forms.Button();
            this.TransactionCB = new System.Windows.Forms.ComboBox();
            this.TransactionPrintButton = new System.Windows.Forms.Button();
            this.CurrentStationCB = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Rotation = new System.Windows.Forms.ComboBox();
            this.btnRotatePrint = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.TextToPrint = new System.Windows.Forms.TextBox();
            this.CutReceipt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnValidateData
            // 
            this.btnValidateData.Location = new System.Drawing.Point(443, 42);
            this.btnValidateData.Name = "btnValidateData";
            this.btnValidateData.Size = new System.Drawing.Size(82, 23);
            this.btnValidateData.TabIndex = 70;
            this.btnValidateData.Text = "ValidateData";
            this.btnValidateData.Click += new System.EventHandler(this.btnValidateData_Click);
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(525, 79);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(82, 16);
            this.label43.TabIndex = 69;
            this.label43.Text = "Text Position";
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(434, 79);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(60, 16);
            this.label42.TabIndex = 68;
            this.label42.Text = "Alignment";
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(368, 79);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(53, 16);
            this.label41.TabIndex = 67;
            this.label41.Text = "Width";
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(320, 78);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(53, 18);
            this.label40.TabIndex = 66;
            this.label40.Text = "Height";
            // 
            // btnPrintBitmap
            // 
            this.btnPrintBitmap.Location = new System.Drawing.Point(67, 102);
            this.btnPrintBitmap.Name = "btnPrintBitmap";
            this.btnPrintBitmap.Size = new System.Drawing.Size(112, 23);
            this.btnPrintBitmap.TabIndex = 65;
            this.btnPrintBitmap.Text = "Print Bitmap";
            this.btnPrintBitmap.Click += new System.EventHandler(this.btnPrintBitmap_Click);
            // 
            // cbTextPosition
            // 
            this.cbTextPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTextPosition.ItemHeight = 13;
            this.cbTextPosition.Location = new System.Drawing.Point(518, 98);
            this.cbTextPosition.Name = "cbTextPosition";
            this.cbTextPosition.Size = new System.Drawing.Size(91, 21);
            this.cbTextPosition.TabIndex = 64;
            // 
            // cbAlignment
            // 
            this.cbAlignment.ItemHeight = 13;
            this.cbAlignment.Items.AddRange(new object[] {
            "Left",
            "Center",
            "Right"});
            this.cbAlignment.Location = new System.Drawing.Point(422, 99);
            this.cbAlignment.Name = "cbAlignment";
            this.cbAlignment.Size = new System.Drawing.Size(91, 21);
            this.cbAlignment.TabIndex = 63;
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(370, 100);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(40, 20);
            this.tbWidth.TabIndex = 62;
            this.tbWidth.Text = "10";
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(321, 100);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(39, 20);
            this.tbHeight.TabIndex = 61;
            this.tbHeight.Text = "10";
            // 
            // cbSymbology
            // 
            this.cbSymbology.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSymbology.ItemHeight = 13;
            this.cbSymbology.Location = new System.Drawing.Point(190, 77);
            this.cbSymbology.Name = "cbSymbology";
            this.cbSymbology.Size = new System.Drawing.Size(120, 21);
            this.cbSymbology.TabIndex = 60;
            // 
            // btnPrintBarcode
            // 
            this.btnPrintBarcode.Location = new System.Drawing.Point(67, 76);
            this.btnPrintBarcode.Name = "btnPrintBarcode";
            this.btnPrintBarcode.Size = new System.Drawing.Size(112, 23);
            this.btnPrintBarcode.TabIndex = 59;
            this.btnPrintBarcode.Text = "Print Barcode";
            this.btnPrintBarcode.Click += new System.EventHandler(this.btnPrintBarcode_Click);
            // 
            // btnPrintTwoNormal
            // 
            this.btnPrintTwoNormal.Location = new System.Drawing.Point(542, 13);
            this.btnPrintTwoNormal.Name = "btnPrintTwoNormal";
            this.btnPrintTwoNormal.Size = new System.Drawing.Size(112, 24);
            this.btnPrintTwoNormal.TabIndex = 58;
            this.btnPrintTwoNormal.Text = "Print Two Normal";
            this.btnPrintTwoNormal.Click += new System.EventHandler(this.btnPrintTwoNormal_Click);
            // 
            // Timeout
            // 
            this.Timeout.Location = new System.Drawing.Point(593, 154);
            this.Timeout.Name = "Timeout";
            this.Timeout.Size = new System.Drawing.Size(53, 23);
            this.Timeout.TabIndex = 57;
            this.Timeout.Text = "Timeout:";
            // 
            // tbTimeout
            // 
            this.tbTimeout.Location = new System.Drawing.Point(593, 182);
            this.tbTimeout.Name = "tbTimeout";
            this.tbTimeout.Size = new System.Drawing.Size(100, 20);
            this.tbTimeout.TabIndex = 56;
            this.tbTimeout.Text = "5000";
            // 
            // btnEndRemoval
            // 
            this.btnEndRemoval.Location = new System.Drawing.Point(477, 180);
            this.btnEndRemoval.Name = "btnEndRemoval";
            this.btnEndRemoval.Size = new System.Drawing.Size(105, 23);
            this.btnEndRemoval.TabIndex = 55;
            this.btnEndRemoval.Text = "EndRemoval";
            this.btnEndRemoval.Click += new System.EventHandler(this.btnEndRemoval_Click);
            // 
            // btnBeginRemoval
            // 
            this.btnBeginRemoval.Location = new System.Drawing.Point(355, 181);
            this.btnBeginRemoval.Name = "btnBeginRemoval";
            this.btnBeginRemoval.Size = new System.Drawing.Size(105, 23);
            this.btnBeginRemoval.TabIndex = 54;
            this.btnBeginRemoval.Text = "BeginRemoval";
            this.btnBeginRemoval.Click += new System.EventHandler(this.btnBeginRemoval_Click);
            // 
            // btnEndInsertion
            // 
            this.btnEndInsertion.Location = new System.Drawing.Point(477, 152);
            this.btnEndInsertion.Name = "btnEndInsertion";
            this.btnEndInsertion.Size = new System.Drawing.Size(105, 23);
            this.btnEndInsertion.TabIndex = 53;
            this.btnEndInsertion.Text = "EndInsertion";
            this.btnEndInsertion.Click += new System.EventHandler(this.btnEndInsertion_Click);
            // 
            // btnBeginInsertion
            // 
            this.btnBeginInsertion.Location = new System.Drawing.Point(355, 152);
            this.btnBeginInsertion.Name = "btnBeginInsertion";
            this.btnBeginInsertion.Size = new System.Drawing.Size(105, 23);
            this.btnBeginInsertion.TabIndex = 52;
            this.btnBeginInsertion.Text = "BeginInsertion";
            this.btnBeginInsertion.Click += new System.EventHandler(this.btnBeginInsertion_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(555, 45);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 24);
            this.checkBox1.TabIndex = 51;
            this.checkBox1.Text = "FlagWhenIdle";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnPrintImmediate
            // 
            this.btnPrintImmediate.Location = new System.Drawing.Point(66, 46);
            this.btnPrintImmediate.Name = "btnPrintImmediate";
            this.btnPrintImmediate.Size = new System.Drawing.Size(112, 23);
            this.btnPrintImmediate.TabIndex = 50;
            this.btnPrintImmediate.Text = "Print Immediate";
            this.btnPrintImmediate.Click += new System.EventHandler(this.btnPrintImmediate_Click);
            // 
            // TransactionCB
            // 
            this.TransactionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TransactionCB.ItemHeight = 13;
            this.TransactionCB.Items.AddRange(new object[] {
            "Transaction",
            "Normal"});
            this.TransactionCB.Location = new System.Drawing.Point(186, 184);
            this.TransactionCB.Name = "TransactionCB";
            this.TransactionCB.Size = new System.Drawing.Size(121, 21);
            this.TransactionCB.TabIndex = 49;
            this.TransactionCB.SelectedIndexChanged += new System.EventHandler(this.TransactionCB_SelectedIndexChanged);
            // 
            // TransactionPrintButton
            // 
            this.TransactionPrintButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TransactionPrintButton.Location = new System.Drawing.Point(74, 184);
            this.TransactionPrintButton.Name = "TransactionPrintButton";
            this.TransactionPrintButton.Size = new System.Drawing.Size(104, 23);
            this.TransactionPrintButton.TabIndex = 48;
            this.TransactionPrintButton.Text = "TransactionPrint";
            this.TransactionPrintButton.Click += new System.EventHandler(this.TransactionPrintButton_Click);
            // 
            // CurrentStationCB
            // 
            this.CurrentStationCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CurrentStationCB.ItemHeight = 13;
            this.CurrentStationCB.Items.AddRange(new object[] {
            "Journal",
            "Receipt",
            "Slip",
            "SlipJournal",
            "ReceiptJournal",
            "SlipReceipt"});
            this.CurrentStationCB.Location = new System.Drawing.Point(186, 128);
            this.CurrentStationCB.Name = "CurrentStationCB";
            this.CurrentStationCB.Size = new System.Drawing.Size(120, 21);
            this.CurrentStationCB.TabIndex = 47;
            this.CurrentStationCB.SelectedIndexChanged += new System.EventHandler(this.CurrentStationCB_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(90, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 23);
            this.label7.TabIndex = 46;
            this.label7.Text = "Current station";
            // 
            // Rotation
            // 
            this.Rotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Rotation.ItemHeight = 13;
            this.Rotation.Items.AddRange(new object[] {
            "Normal",
            "Right90",
            "Left90",
            "Rotate180",
            "BitmapRight90",
            "BitmapLeft90",
            "BitmapRotate180",
            "BarcodeRight90",
            "BarcodeLeft90",
            "BarcodeRotate180",
            "BitmapBarcodeRight90",
            "BitmapBarcodeLeft90",
            "BitmapBarcodeRotate180"});
            this.Rotation.Location = new System.Drawing.Point(186, 152);
            this.Rotation.Name = "Rotation";
            this.Rotation.Size = new System.Drawing.Size(121, 21);
            this.Rotation.TabIndex = 45;
            this.Rotation.SelectedIndexChanged += new System.EventHandler(this.Rotation_SelectedIndexChanged);
            // 
            // btnRotatePrint
            // 
            this.btnRotatePrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRotatePrint.Location = new System.Drawing.Point(74, 152);
            this.btnRotatePrint.Name = "btnRotatePrint";
            this.btnRotatePrint.Size = new System.Drawing.Size(104, 23);
            this.btnRotatePrint.TabIndex = 44;
            this.btnRotatePrint.Text = "RotatePrint";
            this.btnRotatePrint.Click += new System.EventHandler(this.btnRotatePrint_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(66, 14);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(112, 24);
            this.PrintButton.TabIndex = 41;
            this.PrintButton.Text = "Print Normal";
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // TextToPrint
            // 
            this.TextToPrint.Location = new System.Drawing.Point(186, 14);
            this.TextToPrint.Multiline = true;
            this.TextToPrint.Name = "TextToPrint";
            this.TextToPrint.Size = new System.Drawing.Size(248, 56);
            this.TextToPrint.TabIndex = 42;
            this.TextToPrint.Text = "Type some text to print here.";
            // 
            // CutReceipt
            // 
            this.CutReceipt.Location = new System.Drawing.Point(443, 13);
            this.CutReceipt.Name = "CutReceipt";
            this.CutReceipt.Size = new System.Drawing.Size(81, 23);
            this.CutReceipt.TabIndex = 43;
            this.CutReceipt.Text = "Cut receipt";
            this.CutReceipt.Click += new System.EventHandler(this.CutReceipt_Click);
            // 
            // PosPrinterScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnValidateData);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.btnPrintBitmap);
            this.Controls.Add(this.cbTextPosition);
            this.Controls.Add(this.cbAlignment);
            this.Controls.Add(this.tbWidth);
            this.Controls.Add(this.tbHeight);
            this.Controls.Add(this.cbSymbology);
            this.Controls.Add(this.btnPrintBarcode);
            this.Controls.Add(this.btnPrintTwoNormal);
            this.Controls.Add(this.Timeout);
            this.Controls.Add(this.tbTimeout);
            this.Controls.Add(this.btnEndRemoval);
            this.Controls.Add(this.btnBeginRemoval);
            this.Controls.Add(this.btnEndInsertion);
            this.Controls.Add(this.btnBeginInsertion);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnPrintImmediate);
            this.Controls.Add(this.TransactionCB);
            this.Controls.Add(this.TransactionPrintButton);
            this.Controls.Add(this.CurrentStationCB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Rotation);
            this.Controls.Add(this.btnRotatePrint);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.TextToPrint);
            this.Controls.Add(this.CutReceipt);
            this.Name = "PosPrinterScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnValidateData;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Button btnPrintBitmap;
        private System.Windows.Forms.ComboBox cbTextPosition;
        private System.Windows.Forms.ComboBox cbAlignment;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.ComboBox cbSymbology;
        private System.Windows.Forms.Button btnPrintBarcode;
        private System.Windows.Forms.Button btnPrintTwoNormal;
        private System.Windows.Forms.Label Timeout;
        private System.Windows.Forms.TextBox tbTimeout;
        private System.Windows.Forms.Button btnEndRemoval;
        private System.Windows.Forms.Button btnBeginRemoval;
        private System.Windows.Forms.Button btnEndInsertion;
        private System.Windows.Forms.Button btnBeginInsertion;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnPrintImmediate;
        private System.Windows.Forms.ComboBox TransactionCB;
        private System.Windows.Forms.Button TransactionPrintButton;
        private System.Windows.Forms.ComboBox CurrentStationCB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Rotation;
        private System.Windows.Forms.Button btnRotatePrint;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.TextBox TextToPrint;
        private System.Windows.Forms.Button CutReceipt;
    }
}
