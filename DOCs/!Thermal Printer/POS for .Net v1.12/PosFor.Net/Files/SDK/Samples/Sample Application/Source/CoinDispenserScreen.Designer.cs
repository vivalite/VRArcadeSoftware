namespace TestApplication
{
    partial class CoinDispenserScreen
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
            this.tbDispenseChange = new System.Windows.Forms.TextBox();
            this.btnDispenseChange = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbDispenseChange
            // 
            this.tbDispenseChange.Location = new System.Drawing.Point(138, 47);
            this.tbDispenseChange.Name = "tbDispenseChange";
            this.tbDispenseChange.Size = new System.Drawing.Size(100, 20);
            this.tbDispenseChange.TabIndex = 3;
            // 
            // btnDispenseChange
            // 
            this.btnDispenseChange.Location = new System.Drawing.Point(73, 87);
            this.btnDispenseChange.Name = "btnDispenseChange";
            this.btnDispenseChange.Size = new System.Drawing.Size(135, 23);
            this.btnDispenseChange.TabIndex = 2;
            this.btnDispenseChange.Text = "DispenseChange";
            this.btnDispenseChange.Click += new System.EventHandler(this.btnDispenseChange_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Amount to dispense:";
            // 
            // CoinDispenserScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDispenseChange);
            this.Controls.Add(this.btnDispenseChange);
            this.Name = "CoinDispenserScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDispenseChange;
        private System.Windows.Forms.Button btnDispenseChange;
        private System.Windows.Forms.Label label1;
    }
}
