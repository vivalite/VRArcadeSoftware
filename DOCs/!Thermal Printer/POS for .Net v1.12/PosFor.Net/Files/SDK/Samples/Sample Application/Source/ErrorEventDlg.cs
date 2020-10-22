// This is a part of the Microsoft POS for .NET SDK
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This sample source code is only intended as a 
// supplement to the POS for .NET SDK and related 
// electronic documentation provided with the library.

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.PointOfService;

namespace TestApplication
{
	/// <summary>
	/// Summary description for ErrorEventDlg.
	/// </summary>
	public class ErrorEventDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Label ErrorText;
		private System.Windows.Forms.RadioButton RetryradioButton;
		private System.Windows.Forms.RadioButton ClearradioButton;
		private System.Windows.Forms.RadioButton ContinueInputradioButton;
		private System.Windows.Forms.GroupBox groupBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private DeviceErrorEventArgs deviceErrorArgs;
		public ErrorEventDlg(DeviceErrorEventArgs d, PosCommon co)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			deviceErrorArgs = d;

			ErrorText.Text = "An ErrorEvent occurred with the following parameters:\r\n" + 
				"\tError Code: " + d.ErrorCode.ToString() + "\r\n" + 
				"\tExtended Error Code: " + d.ErrorCodeExtended.ToString() + "\r\n" +
				"\tError Locus: " + d.ErrorLocus.ToString() + "\r\n" +
				"\tError Response: " + d.ErrorResponse.ToString(); 

			if (co is PosPrinter)
			{
				string s;
				s = "\r\n\r\nErrorLevel: " + ((PosPrinter) co).ErrorLevel.ToString() + "\r\n";
				s += "ErrorStation: " + ((PosPrinter) co).ErrorStation.ToString() + "\r\n";
				s += "ErrorString: " + ((PosPrinter) co).ErrorString.ToString();

				ErrorText.Text += s;
			}

			RetryradioButton.Checked = (d.ErrorResponse == ErrorResponse.Retry);
			ClearradioButton.Checked = (d.ErrorResponse == ErrorResponse.Clear);
			ContinueInputradioButton.Checked = (d.ErrorResponse == ErrorResponse.ContinueInput);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ErrorText = new System.Windows.Forms.Label();
			this.RetryradioButton = new System.Windows.Forms.RadioButton();
			this.ClearradioButton = new System.Windows.Forms.RadioButton();
			this.ContinueInputradioButton = new System.Windows.Forms.RadioButton();
			this.OKButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// ErrorText
			// 
			this.ErrorText.Location = new System.Drawing.Point(24, 16);
			this.ErrorText.Name = "ErrorText";
			this.ErrorText.Size = new System.Drawing.Size(312, 120);
			this.ErrorText.TabIndex = 1;
			// 
			// RetryradioButton
			// 
			this.RetryradioButton.Location = new System.Drawing.Point(48, 168);
			this.RetryradioButton.Name = "RetryradioButton";
			this.RetryradioButton.TabIndex = 2;
			this.RetryradioButton.Text = "Retry";
			this.RetryradioButton.CheckedChanged += new System.EventHandler(this.RetryradioButton_CheckedChanged);
			// 
			// ClearradioButton
			// 
			this.ClearradioButton.Location = new System.Drawing.Point(48, 192);
			this.ClearradioButton.Name = "ClearradioButton";
			this.ClearradioButton.TabIndex = 3;
			this.ClearradioButton.Text = "Clear";
			this.ClearradioButton.CheckedChanged += new System.EventHandler(this.ClearradioButton_CheckedChanged);
			// 
			// ContinueInputradioButton
			// 
			this.ContinueInputradioButton.Location = new System.Drawing.Point(48, 216);
			this.ContinueInputradioButton.Name = "ContinueInputradioButton";
			this.ContinueInputradioButton.TabIndex = 4;
			this.ContinueInputradioButton.Text = "Continue Input";
			this.ContinueInputradioButton.CheckedChanged += new System.EventHandler(this.ContinueInputradioButton_CheckedChanged);
			// 
			// OKButton
			// 
			this.OKButton.Location = new System.Drawing.Point(256, 272);
			this.OKButton.Name = "OKButton";
			this.OKButton.TabIndex = 5;
			this.OKButton.Text = "OK";
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(24, 144);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 104);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Error Response";
			// 
			// ErrorEventDlg
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 309);
			this.ControlBox = false;
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.ContinueInputradioButton);
			this.Controls.Add(this.ClearradioButton);
			this.Controls.Add(this.RetryradioButton);
			this.Controls.Add(this.ErrorText);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ErrorEventDlg";
			this.Text = "An Error Event Occurred";
			this.ResumeLayout(false);

		}
		#endregion

		private void RetryradioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			if (RetryradioButton.Checked)
				deviceErrorArgs.ErrorResponse = ErrorResponse.Retry;
		}

		private void ClearradioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ClearradioButton.Checked)
				deviceErrorArgs.ErrorResponse = ErrorResponse.Clear;
		}

		private void ContinueInputradioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ContinueInputradioButton.Checked)
				deviceErrorArgs.ErrorResponse = ErrorResponse.ContinueInput;
		}

		private void OKButton_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
