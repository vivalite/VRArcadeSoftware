namespace TestApplication
{
    partial class ScaleScreen
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
            this.lblResult = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.btnZeroScale = new System.Windows.Forms.Button();
            this.btnReadWeight = new System.Windows.Forms.Button();
            this.tbDisplayText = new System.Windows.Forms.TextBox();
            this.btnDisplayText = new System.Windows.Forms.Button();
            this.tbUnitPrice = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.tbTareWeight = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(336, 137);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(170, 23);
            this.lblResult.TabIndex = 21;
            this.lblResult.Text = "Result:";
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(133, 139);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(65, 23);
            this.label49.TabIndex = 20;
            this.label49.Text = "Timeout";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(208, 135);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 19;
            this.textBox6.Text = "1000";
            // 
            // btnZeroScale
            // 
            this.btnZeroScale.Location = new System.Drawing.Point(23, 169);
            this.btnZeroScale.Name = "btnZeroScale";
            this.btnZeroScale.Size = new System.Drawing.Size(92, 23);
            this.btnZeroScale.TabIndex = 18;
            this.btnZeroScale.Text = "Zero Scale";
            this.btnZeroScale.Click += new System.EventHandler(this.btnZeroScale_Click);
            // 
            // btnReadWeight
            // 
            this.btnReadWeight.Location = new System.Drawing.Point(23, 135);
            this.btnReadWeight.Name = "btnReadWeight";
            this.btnReadWeight.Size = new System.Drawing.Size(92, 23);
            this.btnReadWeight.TabIndex = 17;
            this.btnReadWeight.Text = "Read Weight";
            this.btnReadWeight.Click += new System.EventHandler(this.btnReadWeight_Click);
            // 
            // tbDisplayText
            // 
            this.tbDisplayText.Location = new System.Drawing.Point(133, 100);
            this.tbDisplayText.Name = "tbDisplayText";
            this.tbDisplayText.Size = new System.Drawing.Size(333, 20);
            this.tbDisplayText.TabIndex = 16;
            this.tbDisplayText.Text = "Some text to display.";
            // 
            // btnDisplayText
            // 
            this.btnDisplayText.Location = new System.Drawing.Point(23, 99);
            this.btnDisplayText.Name = "btnDisplayText";
            this.btnDisplayText.Size = new System.Drawing.Size(92, 23);
            this.btnDisplayText.TabIndex = 15;
            this.btnDisplayText.Text = "Display Text";
            this.btnDisplayText.Click += new System.EventHandler(this.btnDisplayText_Click);
            // 
            // tbUnitPrice
            // 
            this.tbUnitPrice.Location = new System.Drawing.Point(133, 54);
            this.tbUnitPrice.Name = "tbUnitPrice";
            this.tbUnitPrice.Size = new System.Drawing.Size(100, 20);
            this.tbUnitPrice.TabIndex = 14;
            this.tbUnitPrice.Text = "1.00";
            this.tbUnitPrice.TextChanged += new System.EventHandler(this.tbUnitPrice_TextChanged);
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(23, 55);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(100, 23);
            this.label48.TabIndex = 13;
            this.label48.Text = "Unit Price";
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(23, 25);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(100, 23);
            this.label47.TabIndex = 12;
            this.label47.Text = "Tare Weight";
            // 
            // tbTareWeight
            // 
            this.tbTareWeight.Location = new System.Drawing.Point(133, 23);
            this.tbTareWeight.Name = "tbTareWeight";
            this.tbTareWeight.Size = new System.Drawing.Size(100, 20);
            this.tbTareWeight.TabIndex = 11;
            this.tbTareWeight.Text = "0.0";
            this.tbTareWeight.TextChanged += new System.EventHandler(this.tbTareWeight_TextChanged);
            // 
            // ScaleScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.btnZeroScale);
            this.Controls.Add(this.btnReadWeight);
            this.Controls.Add(this.tbDisplayText);
            this.Controls.Add(this.btnDisplayText);
            this.Controls.Add(this.tbUnitPrice);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.tbTareWeight);
            this.Name = "ScaleScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button btnZeroScale;
        private System.Windows.Forms.Button btnReadWeight;
        private System.Windows.Forms.TextBox tbDisplayText;
        private System.Windows.Forms.Button btnDisplayText;
        private System.Windows.Forms.TextBox tbUnitPrice;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox tbTareWeight;
    }
}
