namespace TestApplication
{
    partial class SignatureCaptureScreen
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
            this.label46 = new System.Windows.Forms.Label();
            this.tbFormName = new System.Windows.Forms.TextBox();
            this.btnEndCapture = new System.Windows.Forms.Button();
            this.btnBeginCapture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(155, 41);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(70, 20);
            this.label46.TabIndex = 7;
            this.label46.Text = "Form Name:";
            // 
            // tbFormName
            // 
            this.tbFormName.Location = new System.Drawing.Point(231, 38);
            this.tbFormName.Name = "tbFormName";
            this.tbFormName.Size = new System.Drawing.Size(100, 20);
            this.tbFormName.TabIndex = 6;
            // 
            // btnEndCapture
            // 
            this.btnEndCapture.Location = new System.Drawing.Point(45, 72);
            this.btnEndCapture.Name = "btnEndCapture";
            this.btnEndCapture.Size = new System.Drawing.Size(98, 23);
            this.btnEndCapture.TabIndex = 5;
            this.btnEndCapture.Text = "EndCapture";
            this.btnEndCapture.Click += new System.EventHandler(this.btnEndCapture_Click);
            // 
            // btnBeginCapture
            // 
            this.btnBeginCapture.Location = new System.Drawing.Point(45, 37);
            this.btnBeginCapture.Name = "btnBeginCapture";
            this.btnBeginCapture.Size = new System.Drawing.Size(98, 23);
            this.btnBeginCapture.TabIndex = 4;
            this.btnBeginCapture.Text = "BeginCapture";
            this.btnBeginCapture.Click += new System.EventHandler(this.btnBeginCapture_Click);
            // 
            // SignatureCaptureScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.tbFormName);
            this.Controls.Add(this.btnEndCapture);
            this.Controls.Add(this.btnBeginCapture);
            this.Name = "SignatureCaptureScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox tbFormName;
        private System.Windows.Forms.Button btnEndCapture;
        private System.Windows.Forms.Button btnBeginCapture;
    }
}
