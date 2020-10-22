namespace TestApplication
{
    partial class ScannerScreen
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
            this.DecodeData = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // DecodeData
            // 
            this.DecodeData.Location = new System.Drawing.Point(40, 41);
            this.DecodeData.Name = "DecodeData";
            this.DecodeData.Size = new System.Drawing.Size(104, 24);
            this.DecodeData.TabIndex = 1;
            this.DecodeData.Text = "Decode Data";
            this.DecodeData.CheckedChanged += new System.EventHandler(this.DecodeData_CheckedChanged);
            // 
            // ScannerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.DecodeData);
            this.Name = "ScannerScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox DecodeData;
    }
}
