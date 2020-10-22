// This is a part of the Microsoft POS for .NET SDK
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This sample source code is only intended as a 
// supplement to the POS for .NET SDK and related 
// electronic documentation provided with the library.

namespace TestApplication
{
    partial class DirectIOForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbObject = new System.Windows.Forms.TextBox();
            this.tbResultObject = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbResultData = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.rbBytes = new System.Windows.Forms.RadioButton();
            this.rbBits = new System.Windows.Forms.RadioButton();
            this.rbString = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(69, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "DirectIO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(173, 285);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbData
            // 
            this.tbData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbData.Location = new System.Drawing.Point(89, 53);
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(191, 20);
            this.tbData.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Command";
            // 
            // tbCommand
            // 
            this.tbCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCommand.Location = new System.Drawing.Point(89, 27);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(191, 20);
            this.tbCommand.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Object";
            // 
            // tbObject
            // 
            this.tbObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbObject.Location = new System.Drawing.Point(89, 79);
            this.tbObject.Name = "tbObject";
            this.tbObject.Size = new System.Drawing.Size(191, 20);
            this.tbObject.TabIndex = 6;
            // 
            // tbResultObject
            // 
            this.tbResultObject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResultObject.Location = new System.Drawing.Point(76, 54);
            this.tbResultObject.Multiline = true;
            this.tbResultObject.Name = "tbResultObject";
            this.tbResultObject.ReadOnly = true;
            this.tbResultObject.Size = new System.Drawing.Size(185, 104);
            this.tbResultObject.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Data:";
            // 
            // tbResultData
            // 
            this.tbResultData.Location = new System.Drawing.Point(76, 26);
            this.tbResultData.Multiline = true;
            this.tbResultData.Name = "tbResultData";
            this.tbResultData.ReadOnly = true;
            this.tbResultData.Size = new System.Drawing.Size(82, 20);
            this.tbResultData.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbHex);
            this.groupBox1.Controls.Add(this.rbBytes);
            this.groupBox1.Controls.Add(this.rbBits);
            this.groupBox1.Controls.Add(this.rbString);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbResultObject);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbResultData);
            this.groupBox1.Location = new System.Drawing.Point(13, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 164);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // rbHex
            // 
            this.rbHex.AutoSize = true;
            this.rbHex.Enabled = false;
            this.rbHex.Location = new System.Drawing.Point(17, 125);
            this.rbHex.Name = "rbHex";
            this.rbHex.Size = new System.Drawing.Size(42, 17);
            this.rbHex.TabIndex = 16;
            this.rbHex.Text = "hex";
            this.rbHex.UseVisualStyleBackColor = true;
            this.rbHex.CheckedChanged += new System.EventHandler(this.rbHex_CheckedChanged);
            // 
            // rbBytes
            // 
            this.rbBytes.AutoSize = true;
            this.rbBytes.Enabled = false;
            this.rbBytes.Location = new System.Drawing.Point(17, 108);
            this.rbBytes.Name = "rbBytes";
            this.rbBytes.Size = new System.Drawing.Size(50, 17);
            this.rbBytes.TabIndex = 15;
            this.rbBytes.Text = "bytes";
            this.rbBytes.UseVisualStyleBackColor = true;
            this.rbBytes.CheckedChanged += new System.EventHandler(this.rbBytes_CheckedChanged);
            // 
            // rbBits
            // 
            this.rbBits.AutoSize = true;
            this.rbBits.Enabled = false;
            this.rbBits.Location = new System.Drawing.Point(17, 91);
            this.rbBits.Name = "rbBits";
            this.rbBits.Size = new System.Drawing.Size(41, 17);
            this.rbBits.TabIndex = 14;
            this.rbBits.Text = "bits";
            this.rbBits.UseVisualStyleBackColor = true;
            this.rbBits.CheckedChanged += new System.EventHandler(this.rbBits_CheckedChanged);
            // 
            // rbString
            // 
            this.rbString.AutoSize = true;
            this.rbString.Checked = true;
            this.rbString.Enabled = false;
            this.rbString.Location = new System.Drawing.Point(17, 73);
            this.rbString.Name = "rbString";
            this.rbString.Size = new System.Drawing.Size(50, 17);
            this.rbString.TabIndex = 13;
            this.rbString.TabStop = true;
            this.rbString.Text = "string";
            this.rbString.UseVisualStyleBackColor = true;
            this.rbString.CheckedChanged += new System.EventHandler(this.rbString_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Object:";
            // 
            // DirectIOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 321);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbObject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCommand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbData);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "DirectIOForm";
            this.Text = "DirectIOForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbObject;
        private System.Windows.Forms.TextBox tbResultObject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbResultData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbHex;
        private System.Windows.Forms.RadioButton rbBytes;
        private System.Windows.Forms.RadioButton rbBits;
        private System.Windows.Forms.RadioButton rbString;
        private System.Windows.Forms.Label label4;
    }
}