namespace TestApplication
{
    partial class PinPadScreen
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
            this.cbPrompt = new System.Windows.Forms.ComboBox();
            this.label80 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbTransactionHost = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.cbPinPadSystem = new System.Windows.Forms.ComboBox();
            this.label78 = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.btnBeginEftTransaction = new System.Windows.Forms.Button();
            this.label76 = new System.Windows.Forms.Label();
            this.btnEndEftTransaction = new System.Windows.Forms.Button();
            this.tbTrack2Data = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.tbAccountNumber = new System.Windows.Forms.TextBox();
            this.tbTrack1Data = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.cbTransactionType = new System.Windows.Forms.ComboBox();
            this.tbMerchantId = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.tbTerminalId = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.btnEnablePinEntry = new System.Windows.Forms.Button();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMinPinLength = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMaxPinLength = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPrompt
            // 
            this.cbPrompt.FormattingEnabled = true;
            this.cbPrompt.Location = new System.Drawing.Point(588, 156);
            this.cbPrompt.Name = "cbPrompt";
            this.cbPrompt.Size = new System.Drawing.Size(136, 21);
            this.cbPrompt.TabIndex = 74;
            this.cbPrompt.SelectedIndexChanged += new System.EventHandler(this.cbPrompt_SelectedIndexChanged);
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(522, 160);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(40, 13);
            this.label80.TabIndex = 73;
            this.label80.Text = "Prompt";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbTransactionHost);
            this.groupBox4.Controls.Add(this.label79);
            this.groupBox4.Controls.Add(this.cbPinPadSystem);
            this.groupBox4.Controls.Add(this.label78);
            this.groupBox4.Controls.Add(this.tbAmount);
            this.groupBox4.Controls.Add(this.label77);
            this.groupBox4.Controls.Add(this.btnBeginEftTransaction);
            this.groupBox4.Controls.Add(this.label76);
            this.groupBox4.Controls.Add(this.btnEndEftTransaction);
            this.groupBox4.Controls.Add(this.tbTrack2Data);
            this.groupBox4.Controls.Add(this.label72);
            this.groupBox4.Controls.Add(this.label75);
            this.groupBox4.Controls.Add(this.tbAccountNumber);
            this.groupBox4.Controls.Add(this.tbTrack1Data);
            this.groupBox4.Controls.Add(this.label69);
            this.groupBox4.Controls.Add(this.cbTransactionType);
            this.groupBox4.Controls.Add(this.tbMerchantId);
            this.groupBox4.Controls.Add(this.label74);
            this.groupBox4.Controls.Add(this.tbTerminalId);
            this.groupBox4.Controls.Add(this.label73);
            this.groupBox4.Location = new System.Drawing.Point(33, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(470, 209);
            this.groupBox4.TabIndex = 72;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "EFT Transaction";
            // 
            // tbTransactionHost
            // 
            this.tbTransactionHost.AllowDrop = true;
            this.tbTransactionHost.Location = new System.Drawing.Point(358, 97);
            this.tbTransactionHost.Name = "tbTransactionHost";
            this.tbTransactionHost.Size = new System.Drawing.Size(100, 20);
            this.tbTransactionHost.TabIndex = 69;
            this.tbTransactionHost.Text = "1";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(256, 100);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(85, 13);
            this.label79.TabIndex = 70;
            this.label79.Text = "TransactionHost";
            // 
            // cbPinPadSystem
            // 
            this.cbPinPadSystem.FormattingEnabled = true;
            this.cbPinPadSystem.Location = new System.Drawing.Point(358, 70);
            this.cbPinPadSystem.Name = "cbPinPadSystem";
            this.cbPinPadSystem.Size = new System.Drawing.Size(100, 21);
            this.cbPinPadSystem.TabIndex = 68;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(256, 74);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(78, 13);
            this.label78.TabIndex = 67;
            this.label78.Text = "PinPad System";
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(119, 96);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(124, 20);
            this.tbAmount.TabIndex = 65;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(17, 99);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(43, 13);
            this.label77.TabIndex = 66;
            this.label77.Text = "Amount";
            // 
            // btnBeginEftTransaction
            // 
            this.btnBeginEftTransaction.Location = new System.Drawing.Point(259, 38);
            this.btnBeginEftTransaction.Name = "btnBeginEftTransaction";
            this.btnBeginEftTransaction.Size = new System.Drawing.Size(135, 23);
            this.btnBeginEftTransaction.TabIndex = 50;
            this.btnBeginEftTransaction.Text = "BeginEftTransaction";
            this.btnBeginEftTransaction.Click += new System.EventHandler(this.btnBeginEftTransaction_Click);
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(17, 154);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(64, 13);
            this.label76.TabIndex = 64;
            this.label76.Text = "Track2Data";
            // 
            // btnEndEftTransaction
            // 
            this.btnEndEftTransaction.Location = new System.Drawing.Point(259, 123);
            this.btnEndEftTransaction.Name = "btnEndEftTransaction";
            this.btnEndEftTransaction.Size = new System.Drawing.Size(136, 23);
            this.btnEndEftTransaction.TabIndex = 52;
            this.btnEndEftTransaction.Text = "EndEftTransaction";
            this.btnEndEftTransaction.Click += new System.EventHandler(this.btnEndEftTransaction_Click);
            // 
            // tbTrack2Data
            // 
            this.tbTrack2Data.Location = new System.Drawing.Point(119, 151);
            this.tbTrack2Data.Name = "tbTrack2Data";
            this.tbTrack2Data.Size = new System.Drawing.Size(124, 20);
            this.tbTrack2Data.TabIndex = 63;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(17, 48);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(61, 13);
            this.label72.TabIndex = 56;
            this.label72.Text = "MerchantId";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(17, 126);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(64, 13);
            this.label75.TabIndex = 62;
            this.label75.Text = "Track1Data";
            // 
            // tbAccountNumber
            // 
            this.tbAccountNumber.AllowDrop = true;
            this.tbAccountNumber.Location = new System.Drawing.Point(119, 19);
            this.tbAccountNumber.Name = "tbAccountNumber";
            this.tbAccountNumber.Size = new System.Drawing.Size(124, 20);
            this.tbAccountNumber.TabIndex = 53;
            // 
            // tbTrack1Data
            // 
            this.tbTrack1Data.Location = new System.Drawing.Point(119, 123);
            this.tbTrack1Data.Name = "tbTrack1Data";
            this.tbTrack1Data.Size = new System.Drawing.Size(124, 20);
            this.tbTrack1Data.TabIndex = 61;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(17, 22);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(84, 13);
            this.label69.TabIndex = 54;
            this.label69.Text = "AccountNumber";
            // 
            // cbTransactionType
            // 
            this.cbTransactionType.FormattingEnabled = true;
            this.cbTransactionType.Location = new System.Drawing.Point(119, 177);
            this.cbTransactionType.Name = "cbTransactionType";
            this.cbTransactionType.Size = new System.Drawing.Size(124, 21);
            this.cbTransactionType.TabIndex = 60;
            // 
            // tbMerchantId
            // 
            this.tbMerchantId.Location = new System.Drawing.Point(119, 45);
            this.tbMerchantId.Name = "tbMerchantId";
            this.tbMerchantId.Size = new System.Drawing.Size(124, 20);
            this.tbMerchantId.TabIndex = 55;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(17, 181);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(87, 13);
            this.label74.TabIndex = 59;
            this.label74.Text = "TransactionType";
            // 
            // tbTerminalId
            // 
            this.tbTerminalId.Location = new System.Drawing.Point(119, 71);
            this.tbTerminalId.Name = "tbTerminalId";
            this.tbTerminalId.Size = new System.Drawing.Size(124, 20);
            this.tbTerminalId.TabIndex = 57;
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(17, 74);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(56, 13);
            this.label73.TabIndex = 58;
            this.label73.Text = "TerminalId";
            // 
            // btnEnablePinEntry
            // 
            this.btnEnablePinEntry.Location = new System.Drawing.Point(527, 19);
            this.btnEnablePinEntry.Name = "btnEnablePinEntry";
            this.btnEnablePinEntry.Size = new System.Drawing.Size(135, 23);
            this.btnEnablePinEntry.TabIndex = 71;
            this.btnEnablePinEntry.Text = "EnablePinEntry";
            this.btnEnablePinEntry.Click += new System.EventHandler(this.btnEnablePinEntry_Click);
            // 
            // cbLanguage
            // 
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Location = new System.Drawing.Point(588, 183);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(136, 21);
            this.cbLanguage.TabIndex = 76;
            this.cbLanguage.SelectedIndexChanged += new System.EventHandler(this.cbLanguage_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(522, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "Language";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(522, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "Maximum PIN length";
            // 
            // tbMinPinLength
            // 
            this.tbMinPinLength.AllowDrop = true;
            this.tbMinPinLength.Location = new System.Drawing.Point(655, 98);
            this.tbMinPinLength.Name = "tbMinPinLength";
            this.tbMinPinLength.Size = new System.Drawing.Size(57, 20);
            this.tbMinPinLength.TabIndex = 77;
            this.tbMinPinLength.Text = "4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(522, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 78;
            this.label3.Text = "Minimum PIN Length";
            // 
            // tbMaxPinLength
            // 
            this.tbMaxPinLength.Location = new System.Drawing.Point(655, 124);
            this.tbMaxPinLength.Name = "tbMaxPinLength";
            this.tbMaxPinLength.Size = new System.Drawing.Size(57, 20);
            this.tbMaxPinLength.TabIndex = 79;
            this.tbMaxPinLength.Text = "12";
            // 
            // PinPadScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMinPinLength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMaxPinLength);
            this.Controls.Add(this.cbLanguage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPrompt);
            this.Controls.Add(this.label80);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnEnablePinEntry);
            this.Name = "PinPadScreen";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPrompt;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbTransactionHost;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.ComboBox cbPinPadSystem;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Button btnBeginEftTransaction;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Button btnEndEftTransaction;
        private System.Windows.Forms.TextBox tbTrack2Data;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.TextBox tbAccountNumber;
        private System.Windows.Forms.TextBox tbTrack1Data;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.ComboBox cbTransactionType;
        private System.Windows.Forms.TextBox tbMerchantId;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.TextBox tbTerminalId;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Button btnEnablePinEntry;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMinPinLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMaxPinLength;
    }
}
