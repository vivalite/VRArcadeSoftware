namespace TestApplication
{
    partial class PosKeyboardScreen
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
            this.KeyDownUpradioButton = new System.Windows.Forms.RadioButton();
            this.KeyDownradioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // KeyDownUpradioButton
            // 
            this.KeyDownUpradioButton.Location = new System.Drawing.Point(33, 107);
            this.KeyDownUpradioButton.Name = "KeyDownUpradioButton";
            this.KeyDownUpradioButton.Size = new System.Drawing.Size(403, 24);
            this.KeyDownUpradioButton.TabIndex = 24;
            this.KeyDownUpradioButton.Text = "Generate _keyboard down and _keyboard up events";
            this.KeyDownUpradioButton.CheckedChanged += new System.EventHandler(this.KeyDownUpradioButton_CheckedChanged);
            // 
            // KeyDownradioButton
            // 
            this.KeyDownradioButton.Location = new System.Drawing.Point(33, 81);
            this.KeyDownradioButton.Name = "KeyDownradioButton";
            this.KeyDownradioButton.Size = new System.Drawing.Size(405, 24);
            this.KeyDownradioButton.TabIndex = 23;
            this.KeyDownradioButton.Text = "Generate _keyboard down events";
            this.KeyDownradioButton.CheckedChanged += new System.EventHandler(this.KeyDownUpradioButton_CheckedChanged);
            // 
            // PosKeyboardScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.KeyDownUpradioButton);
            this.Controls.Add(this.KeyDownradioButton);
            this.Name = "PosKeyboardScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton KeyDownUpradioButton;
        private System.Windows.Forms.RadioButton KeyDownradioButton;
    }
}
