namespace TestApplication
{
    partial class MicrScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.btnMicrEndRemoval = new System.Windows.Forms.Button();
            this.btnMicrBeginRemoval = new System.Windows.Forms.Button();
            this.btnMicrEndInsertion = new System.Windows.Forms.Button();
            this.btnMicrBeginInsertion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(58, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 23);
            this.label1.TabIndex = 39;
            this.label1.Text = "Timeout:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(136, 119);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 38;
            this.textBox5.Text = "5000";
            // 
            // btnMicrEndRemoval
            // 
            this.btnMicrEndRemoval.Location = new System.Drawing.Point(176, 78);
            this.btnMicrEndRemoval.Name = "btnMicrEndRemoval";
            this.btnMicrEndRemoval.Size = new System.Drawing.Size(105, 23);
            this.btnMicrEndRemoval.TabIndex = 37;
            this.btnMicrEndRemoval.Text = "EndRemoval";
            this.btnMicrEndRemoval.Click += new System.EventHandler(this.btnMicrEndRemoval_Click);
            // 
            // btnMicrBeginRemoval
            // 
            this.btnMicrBeginRemoval.Location = new System.Drawing.Point(54, 79);
            this.btnMicrBeginRemoval.Name = "btnMicrBeginRemoval";
            this.btnMicrBeginRemoval.Size = new System.Drawing.Size(105, 23);
            this.btnMicrBeginRemoval.TabIndex = 36;
            this.btnMicrBeginRemoval.Text = "BeginRemoval";
            this.btnMicrBeginRemoval.Click += new System.EventHandler(this.btnMicrBeginRemoval_Click);
            // 
            // btnMicrEndInsertion
            // 
            this.btnMicrEndInsertion.Location = new System.Drawing.Point(176, 50);
            this.btnMicrEndInsertion.Name = "btnMicrEndInsertion";
            this.btnMicrEndInsertion.Size = new System.Drawing.Size(105, 23);
            this.btnMicrEndInsertion.TabIndex = 35;
            this.btnMicrEndInsertion.Text = "EndInsertion";
            this.btnMicrEndInsertion.Click += new System.EventHandler(this.btnMicrEndInsertion_Click);
            // 
            // btnMicrBeginInsertion
            // 
            this.btnMicrBeginInsertion.Location = new System.Drawing.Point(54, 50);
            this.btnMicrBeginInsertion.Name = "btnMicrBeginInsertion";
            this.btnMicrBeginInsertion.Size = new System.Drawing.Size(105, 23);
            this.btnMicrBeginInsertion.TabIndex = 34;
            this.btnMicrBeginInsertion.Text = "BeginInsertion";
            this.btnMicrBeginInsertion.Click += new System.EventHandler(this.btnMicrBeginInsertion_Click);
            // 
            // MicrScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.btnMicrEndRemoval);
            this.Controls.Add(this.btnMicrBeginRemoval);
            this.Controls.Add(this.btnMicrEndInsertion);
            this.Controls.Add(this.btnMicrBeginInsertion);
            this.Name = "MicrScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button btnMicrEndRemoval;
        private System.Windows.Forms.Button btnMicrBeginRemoval;
        private System.Windows.Forms.Button btnMicrEndInsertion;
        private System.Windows.Forms.Button btnMicrBeginInsertion;
    }
}
