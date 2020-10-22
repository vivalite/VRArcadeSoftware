// This is a part of the Microsoft POS for .NET SDK
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This sample source code is only intended as a 
// supplement to the POS for .NET SDK and related 
// electronic documentation provided with the library.

using System;
using System.Windows.Forms;
using System.Threading;
using System.Text;
using Microsoft.PointOfService.BaseServiceObjects;
using System.Drawing;
using System.Collections;
using System.Globalization;

namespace Microsoft.PointOfService.DeviceSimulators
{
	#region PosPrinterSimulatorWindow Class
	internal class PosPrinterSimulatorWindow : SimulatorBase
	{
		private System.Windows.Forms.TextBox PrinterOutput;
		private System.Windows.Forms.Button Clear;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.CheckBox CoverOpenCheckBox;
		private System.Windows.Forms.CheckBox ReceiptCoverOpenCheckBox;
		private System.Windows.Forms.CheckBox SlipCoverOpenCheckBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbPrintDelay;
		private System.Windows.Forms.Label PrintRequestLabel;
		private System.Windows.Forms.CheckBox cbPoweredOn;

		
		internal PosPrinterSimulatorWindow(PosPrinterSimulator serviceObject) : base(serviceObject)
		{
			Invoke(new MethodDelegate(InitializeComponent));
			Invoke(new MethodDelegate(InitializeUI));
			Invoke(new MethodDelegate(SetPowerState));
		}

		private void InitializeUI()
		{
			PosPrinterSimulator p = ServiceObjectReference.Target as PosPrinterSimulator;
			if (p != null)
				SlipCoverOpenCheckBox.Enabled = p.PrinterProperties.CapSlpPresent;
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


		#region Thread safe public methods

		// These public methods call methods on the Form that must be done on
		// the same thread that the form was created on therefore we must marshal
		// the calls.  
		// We'll do this by using Form.Invoke (which is OK to call from another thread).
		
		
		public void DisplayText(string str)
		{
			if (InvokeRequired)
			{
				Delegate setTextDelegate = new SetTextDelegate(SetPrinterOutputText);
				object[] args = new object[1];
				args[0] = ProcessEscapes(str);
				this.Invoke(setTextDelegate, args);
			}
			else
			{
				SetPrinterOutputText(ProcessEscapes(str));
			}
		}



		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PosPrinterSimulatorWindow));
			this.PrinterOutput = new System.Windows.Forms.TextBox();
			this.Clear = new System.Windows.Forms.Button();
			this.CoverOpenCheckBox = new System.Windows.Forms.CheckBox();
			this.ReceiptCoverOpenCheckBox = new System.Windows.Forms.CheckBox();
			this.SlipCoverOpenCheckBox = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbPrintDelay = new System.Windows.Forms.TextBox();
			this.PrintRequestLabel = new System.Windows.Forms.Label();
			this.cbPoweredOn = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// PrinterOutput
			// 
			this.PrinterOutput.AccessibleDescription = resources.GetString("PrinterOutput.AccessibleDescription");
			this.PrinterOutput.AccessibleName = resources.GetString("PrinterOutput.AccessibleName");
			this.PrinterOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("PrinterOutput.Anchor")));
			this.PrinterOutput.AutoSize = ((bool)(resources.GetObject("PrinterOutput.AutoSize")));
			this.PrinterOutput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PrinterOutput.BackgroundImage")));
			this.PrinterOutput.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("PrinterOutput.Dock")));
			this.PrinterOutput.Enabled = ((bool)(resources.GetObject("PrinterOutput.Enabled")));
			this.PrinterOutput.Font = ((System.Drawing.Font)(resources.GetObject("PrinterOutput.Font")));
			this.PrinterOutput.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("PrinterOutput.ImeMode")));
			this.PrinterOutput.Location = ((System.Drawing.Point)(resources.GetObject("PrinterOutput.Location")));
			this.PrinterOutput.MaxLength = ((int)(resources.GetObject("PrinterOutput.MaxLength")));
			this.PrinterOutput.Multiline = ((bool)(resources.GetObject("PrinterOutput.Multiline")));
			this.PrinterOutput.Name = "PrinterOutput";
			this.PrinterOutput.PasswordChar = ((char)(resources.GetObject("PrinterOutput.PasswordChar")));
			this.PrinterOutput.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("PrinterOutput.RightToLeft")));
			this.PrinterOutput.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("PrinterOutput.ScrollBars")));
			this.PrinterOutput.Size = ((System.Drawing.Size)(resources.GetObject("PrinterOutput.Size")));
			this.PrinterOutput.TabIndex = ((int)(resources.GetObject("PrinterOutput.TabIndex")));
			this.PrinterOutput.Text = resources.GetString("PrinterOutput.Text");
			this.PrinterOutput.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("PrinterOutput.TextAlign")));
			this.PrinterOutput.Visible = ((bool)(resources.GetObject("PrinterOutput.Visible")));
			this.PrinterOutput.WordWrap = ((bool)(resources.GetObject("PrinterOutput.WordWrap")));
			// 
			// Clear
			// 
			this.Clear.AccessibleDescription = resources.GetString("Clear.AccessibleDescription");
			this.Clear.AccessibleName = resources.GetString("Clear.AccessibleName");
			this.Clear.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Clear.Anchor")));
			this.Clear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Clear.BackgroundImage")));
			this.Clear.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Clear.Dock")));
			this.Clear.Enabled = ((bool)(resources.GetObject("Clear.Enabled")));
			this.Clear.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("Clear.FlatStyle")));
			this.Clear.Font = ((System.Drawing.Font)(resources.GetObject("Clear.Font")));
			this.Clear.Image = ((System.Drawing.Image)(resources.GetObject("Clear.Image")));
			this.Clear.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Clear.ImageAlign")));
			this.Clear.ImageIndex = ((int)(resources.GetObject("Clear.ImageIndex")));
			this.Clear.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Clear.ImeMode")));
			this.Clear.Location = ((System.Drawing.Point)(resources.GetObject("Clear.Location")));
			this.Clear.Name = "Clear";
			this.Clear.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Clear.RightToLeft")));
			this.Clear.Size = ((System.Drawing.Size)(resources.GetObject("Clear.Size")));
			this.Clear.TabIndex = ((int)(resources.GetObject("Clear.TabIndex")));
			this.Clear.Text = resources.GetString("Clear.Text");
			this.Clear.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Clear.TextAlign")));
			this.Clear.Visible = ((bool)(resources.GetObject("Clear.Visible")));
			this.Clear.Click += new System.EventHandler(this.Clear_Click);
			// 
			// CoverOpenCheckBox
			// 
			this.CoverOpenCheckBox.AccessibleDescription = resources.GetString("CoverOpenCheckBox.AccessibleDescription");
			this.CoverOpenCheckBox.AccessibleName = resources.GetString("CoverOpenCheckBox.AccessibleName");
			this.CoverOpenCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("CoverOpenCheckBox.Anchor")));
			this.CoverOpenCheckBox.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("CoverOpenCheckBox.Appearance")));
			this.CoverOpenCheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CoverOpenCheckBox.BackgroundImage")));
			this.CoverOpenCheckBox.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("CoverOpenCheckBox.CheckAlign")));
			this.CoverOpenCheckBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("CoverOpenCheckBox.Dock")));
			this.CoverOpenCheckBox.Enabled = ((bool)(resources.GetObject("CoverOpenCheckBox.Enabled")));
			this.CoverOpenCheckBox.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("CoverOpenCheckBox.FlatStyle")));
			this.CoverOpenCheckBox.Font = ((System.Drawing.Font)(resources.GetObject("CoverOpenCheckBox.Font")));
			this.CoverOpenCheckBox.Image = ((System.Drawing.Image)(resources.GetObject("CoverOpenCheckBox.Image")));
			this.CoverOpenCheckBox.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("CoverOpenCheckBox.ImageAlign")));
			this.CoverOpenCheckBox.ImageIndex = ((int)(resources.GetObject("CoverOpenCheckBox.ImageIndex")));
			this.CoverOpenCheckBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("CoverOpenCheckBox.ImeMode")));
			this.CoverOpenCheckBox.Location = ((System.Drawing.Point)(resources.GetObject("CoverOpenCheckBox.Location")));
			this.CoverOpenCheckBox.Name = "CoverOpenCheckBox";
			this.CoverOpenCheckBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("CoverOpenCheckBox.RightToLeft")));
			this.CoverOpenCheckBox.Size = ((System.Drawing.Size)(resources.GetObject("CoverOpenCheckBox.Size")));
			this.CoverOpenCheckBox.TabIndex = ((int)(resources.GetObject("CoverOpenCheckBox.TabIndex")));
			this.CoverOpenCheckBox.Text = resources.GetString("CoverOpenCheckBox.Text");
			this.CoverOpenCheckBox.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("CoverOpenCheckBox.TextAlign")));
			this.CoverOpenCheckBox.Visible = ((bool)(resources.GetObject("CoverOpenCheckBox.Visible")));
			this.CoverOpenCheckBox.CheckedChanged += new System.EventHandler(this.CoverOpenCheckBox_CheckedChanged);
			// 
			// ReceiptCoverOpenCheckBox
			// 
			this.ReceiptCoverOpenCheckBox.AccessibleDescription = resources.GetString("ReceiptCoverOpenCheckBox.AccessibleDescription");
			this.ReceiptCoverOpenCheckBox.AccessibleName = resources.GetString("ReceiptCoverOpenCheckBox.AccessibleName");
			this.ReceiptCoverOpenCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("ReceiptCoverOpenCheckBox.Anchor")));
			this.ReceiptCoverOpenCheckBox.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("ReceiptCoverOpenCheckBox.Appearance")));
			this.ReceiptCoverOpenCheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ReceiptCoverOpenCheckBox.BackgroundImage")));
			this.ReceiptCoverOpenCheckBox.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("ReceiptCoverOpenCheckBox.CheckAlign")));
			this.ReceiptCoverOpenCheckBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("ReceiptCoverOpenCheckBox.Dock")));
			this.ReceiptCoverOpenCheckBox.Enabled = ((bool)(resources.GetObject("ReceiptCoverOpenCheckBox.Enabled")));
			this.ReceiptCoverOpenCheckBox.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("ReceiptCoverOpenCheckBox.FlatStyle")));
			this.ReceiptCoverOpenCheckBox.Font = ((System.Drawing.Font)(resources.GetObject("ReceiptCoverOpenCheckBox.Font")));
			this.ReceiptCoverOpenCheckBox.Image = ((System.Drawing.Image)(resources.GetObject("ReceiptCoverOpenCheckBox.Image")));
			this.ReceiptCoverOpenCheckBox.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("ReceiptCoverOpenCheckBox.ImageAlign")));
			this.ReceiptCoverOpenCheckBox.ImageIndex = ((int)(resources.GetObject("ReceiptCoverOpenCheckBox.ImageIndex")));
			this.ReceiptCoverOpenCheckBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("ReceiptCoverOpenCheckBox.ImeMode")));
			this.ReceiptCoverOpenCheckBox.Location = ((System.Drawing.Point)(resources.GetObject("ReceiptCoverOpenCheckBox.Location")));
			this.ReceiptCoverOpenCheckBox.Name = "ReceiptCoverOpenCheckBox";
			this.ReceiptCoverOpenCheckBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("ReceiptCoverOpenCheckBox.RightToLeft")));
			this.ReceiptCoverOpenCheckBox.Size = ((System.Drawing.Size)(resources.GetObject("ReceiptCoverOpenCheckBox.Size")));
			this.ReceiptCoverOpenCheckBox.TabIndex = ((int)(resources.GetObject("ReceiptCoverOpenCheckBox.TabIndex")));
			this.ReceiptCoverOpenCheckBox.Text = resources.GetString("ReceiptCoverOpenCheckBox.Text");
			this.ReceiptCoverOpenCheckBox.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("ReceiptCoverOpenCheckBox.TextAlign")));
			this.ReceiptCoverOpenCheckBox.Visible = ((bool)(resources.GetObject("ReceiptCoverOpenCheckBox.Visible")));
			this.ReceiptCoverOpenCheckBox.CheckedChanged += new System.EventHandler(this.ReceiptCoverOpenCheckBox_CheckedChanged);
			// 
			// SlipCoverOpenCheckBox
			// 
			this.SlipCoverOpenCheckBox.AccessibleDescription = resources.GetString("SlipCoverOpenCheckBox.AccessibleDescription");
			this.SlipCoverOpenCheckBox.AccessibleName = resources.GetString("SlipCoverOpenCheckBox.AccessibleName");
			this.SlipCoverOpenCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("SlipCoverOpenCheckBox.Anchor")));
			this.SlipCoverOpenCheckBox.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("SlipCoverOpenCheckBox.Appearance")));
			this.SlipCoverOpenCheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SlipCoverOpenCheckBox.BackgroundImage")));
			this.SlipCoverOpenCheckBox.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("SlipCoverOpenCheckBox.CheckAlign")));
			this.SlipCoverOpenCheckBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("SlipCoverOpenCheckBox.Dock")));
			this.SlipCoverOpenCheckBox.Enabled = ((bool)(resources.GetObject("SlipCoverOpenCheckBox.Enabled")));
			this.SlipCoverOpenCheckBox.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("SlipCoverOpenCheckBox.FlatStyle")));
			this.SlipCoverOpenCheckBox.Font = ((System.Drawing.Font)(resources.GetObject("SlipCoverOpenCheckBox.Font")));
			this.SlipCoverOpenCheckBox.Image = ((System.Drawing.Image)(resources.GetObject("SlipCoverOpenCheckBox.Image")));
			this.SlipCoverOpenCheckBox.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("SlipCoverOpenCheckBox.ImageAlign")));
			this.SlipCoverOpenCheckBox.ImageIndex = ((int)(resources.GetObject("SlipCoverOpenCheckBox.ImageIndex")));
			this.SlipCoverOpenCheckBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("SlipCoverOpenCheckBox.ImeMode")));
			this.SlipCoverOpenCheckBox.Location = ((System.Drawing.Point)(resources.GetObject("SlipCoverOpenCheckBox.Location")));
			this.SlipCoverOpenCheckBox.Name = "SlipCoverOpenCheckBox";
			this.SlipCoverOpenCheckBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("SlipCoverOpenCheckBox.RightToLeft")));
			this.SlipCoverOpenCheckBox.Size = ((System.Drawing.Size)(resources.GetObject("SlipCoverOpenCheckBox.Size")));
			this.SlipCoverOpenCheckBox.TabIndex = ((int)(resources.GetObject("SlipCoverOpenCheckBox.TabIndex")));
			this.SlipCoverOpenCheckBox.Text = resources.GetString("SlipCoverOpenCheckBox.Text");
			this.SlipCoverOpenCheckBox.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("SlipCoverOpenCheckBox.TextAlign")));
			this.SlipCoverOpenCheckBox.Visible = ((bool)(resources.GetObject("SlipCoverOpenCheckBox.Visible")));
			this.SlipCoverOpenCheckBox.CheckedChanged += new System.EventHandler(this.SlipCoverOpenCheckBox_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AccessibleDescription = resources.GetString("label2.AccessibleDescription");
			this.label2.AccessibleName = resources.GetString("label2.AccessibleName");
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label2.Anchor")));
			this.label2.AutoSize = ((bool)(resources.GetObject("label2.AutoSize")));
			this.label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label2.Dock")));
			this.label2.Enabled = ((bool)(resources.GetObject("label2.Enabled")));
			this.label2.Font = ((System.Drawing.Font)(resources.GetObject("label2.Font")));
			this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
			this.label2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.ImageAlign")));
			this.label2.ImageIndex = ((int)(resources.GetObject("label2.ImageIndex")));
			this.label2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label2.ImeMode")));
			this.label2.Location = ((System.Drawing.Point)(resources.GetObject("label2.Location")));
			this.label2.Name = "label2";
			this.label2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label2.RightToLeft")));
			this.label2.Size = ((System.Drawing.Size)(resources.GetObject("label2.Size")));
			this.label2.TabIndex = ((int)(resources.GetObject("label2.TabIndex")));
			this.label2.Text = resources.GetString("label2.Text");
			this.label2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.TextAlign")));
			this.label2.Visible = ((bool)(resources.GetObject("label2.Visible")));
			// 
			// tbPrintDelay
			// 
			this.tbPrintDelay.AccessibleDescription = resources.GetString("tbPrintDelay.AccessibleDescription");
			this.tbPrintDelay.AccessibleName = resources.GetString("tbPrintDelay.AccessibleName");
			this.tbPrintDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tbPrintDelay.Anchor")));
			this.tbPrintDelay.AutoSize = ((bool)(resources.GetObject("tbPrintDelay.AutoSize")));
			this.tbPrintDelay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbPrintDelay.BackgroundImage")));
			this.tbPrintDelay.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tbPrintDelay.Dock")));
			this.tbPrintDelay.Enabled = ((bool)(resources.GetObject("tbPrintDelay.Enabled")));
			this.tbPrintDelay.Font = ((System.Drawing.Font)(resources.GetObject("tbPrintDelay.Font")));
			this.tbPrintDelay.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tbPrintDelay.ImeMode")));
			this.tbPrintDelay.Location = ((System.Drawing.Point)(resources.GetObject("tbPrintDelay.Location")));
			this.tbPrintDelay.MaxLength = ((int)(resources.GetObject("tbPrintDelay.MaxLength")));
			this.tbPrintDelay.Multiline = ((bool)(resources.GetObject("tbPrintDelay.Multiline")));
			this.tbPrintDelay.Name = "tbPrintDelay";
			this.tbPrintDelay.PasswordChar = ((char)(resources.GetObject("tbPrintDelay.PasswordChar")));
			this.tbPrintDelay.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tbPrintDelay.RightToLeft")));
			this.tbPrintDelay.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("tbPrintDelay.ScrollBars")));
			this.tbPrintDelay.Size = ((System.Drawing.Size)(resources.GetObject("tbPrintDelay.Size")));
			this.tbPrintDelay.TabIndex = ((int)(resources.GetObject("tbPrintDelay.TabIndex")));
			this.tbPrintDelay.Text = resources.GetString("tbPrintDelay.Text");
			this.tbPrintDelay.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("tbPrintDelay.TextAlign")));
			this.tbPrintDelay.Visible = ((bool)(resources.GetObject("tbPrintDelay.Visible")));
			this.tbPrintDelay.WordWrap = ((bool)(resources.GetObject("tbPrintDelay.WordWrap")));
			this.tbPrintDelay.TextChanged += new System.EventHandler(this.tbPrintDelay_TextChanged);
			// 
			// PrintRequestLabel
			// 
			this.PrintRequestLabel.AccessibleDescription = resources.GetString("PrintRequestLabel.AccessibleDescription");
			this.PrintRequestLabel.AccessibleName = resources.GetString("PrintRequestLabel.AccessibleName");
			this.PrintRequestLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("PrintRequestLabel.Anchor")));
			this.PrintRequestLabel.AutoSize = ((bool)(resources.GetObject("PrintRequestLabel.AutoSize")));
			this.PrintRequestLabel.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("PrintRequestLabel.Dock")));
			this.PrintRequestLabel.Enabled = ((bool)(resources.GetObject("PrintRequestLabel.Enabled")));
			this.PrintRequestLabel.Font = ((System.Drawing.Font)(resources.GetObject("PrintRequestLabel.Font")));
			this.PrintRequestLabel.Image = ((System.Drawing.Image)(resources.GetObject("PrintRequestLabel.Image")));
			this.PrintRequestLabel.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("PrintRequestLabel.ImageAlign")));
			this.PrintRequestLabel.ImageIndex = ((int)(resources.GetObject("PrintRequestLabel.ImageIndex")));
			this.PrintRequestLabel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("PrintRequestLabel.ImeMode")));
			this.PrintRequestLabel.Location = ((System.Drawing.Point)(resources.GetObject("PrintRequestLabel.Location")));
			this.PrintRequestLabel.Name = "PrintRequestLabel";
			this.PrintRequestLabel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("PrintRequestLabel.RightToLeft")));
			this.PrintRequestLabel.Size = ((System.Drawing.Size)(resources.GetObject("PrintRequestLabel.Size")));
			this.PrintRequestLabel.TabIndex = ((int)(resources.GetObject("PrintRequestLabel.TabIndex")));
			this.PrintRequestLabel.Text = resources.GetString("PrintRequestLabel.Text");
			this.PrintRequestLabel.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("PrintRequestLabel.TextAlign")));
			this.PrintRequestLabel.Visible = ((bool)(resources.GetObject("PrintRequestLabel.Visible")));
			// 
			// cbPoweredOn
			// 
			this.cbPoweredOn.AccessibleDescription = resources.GetString("cbPoweredOn.AccessibleDescription");
			this.cbPoweredOn.AccessibleName = resources.GetString("cbPoweredOn.AccessibleName");
			this.cbPoweredOn.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cbPoweredOn.Anchor")));
			this.cbPoweredOn.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("cbPoweredOn.Appearance")));
			this.cbPoweredOn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbPoweredOn.BackgroundImage")));
			this.cbPoweredOn.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cbPoweredOn.CheckAlign")));
			this.cbPoweredOn.Checked = true;
			this.cbPoweredOn.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbPoweredOn.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cbPoweredOn.Dock")));
			this.cbPoweredOn.Enabled = ((bool)(resources.GetObject("cbPoweredOn.Enabled")));
			this.cbPoweredOn.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cbPoweredOn.FlatStyle")));
			this.cbPoweredOn.Font = ((System.Drawing.Font)(resources.GetObject("cbPoweredOn.Font")));
			this.cbPoweredOn.Image = ((System.Drawing.Image)(resources.GetObject("cbPoweredOn.Image")));
			this.cbPoweredOn.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cbPoweredOn.ImageAlign")));
			this.cbPoweredOn.ImageIndex = ((int)(resources.GetObject("cbPoweredOn.ImageIndex")));
			this.cbPoweredOn.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cbPoweredOn.ImeMode")));
			this.cbPoweredOn.Location = ((System.Drawing.Point)(resources.GetObject("cbPoweredOn.Location")));
			this.cbPoweredOn.Name = "cbPoweredOn";
			this.cbPoweredOn.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cbPoweredOn.RightToLeft")));
			this.cbPoweredOn.Size = ((System.Drawing.Size)(resources.GetObject("cbPoweredOn.Size")));
			this.cbPoweredOn.TabIndex = ((int)(resources.GetObject("cbPoweredOn.TabIndex")));
			this.cbPoweredOn.Text = resources.GetString("cbPoweredOn.Text");
			this.cbPoweredOn.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cbPoweredOn.TextAlign")));
			this.cbPoweredOn.Visible = ((bool)(resources.GetObject("cbPoweredOn.Visible")));
			this.cbPoweredOn.CheckedChanged += new System.EventHandler(this.cbPoweredOn_CheckedChanged);
			// 
			// PosPrinterSimulatorWindow
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.cbPoweredOn);
			this.Controls.Add(this.tbPrintDelay);
			this.Controls.Add(this.PrinterOutput);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.SlipCoverOpenCheckBox);
			this.Controls.Add(this.ReceiptCoverOpenCheckBox);
			this.Controls.Add(this.CoverOpenCheckBox);
			this.Controls.Add(this.PrintRequestLabel);
			this.Controls.Add(this.Clear);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "PosPrinterSimulatorWindow";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Controls.SetChildIndex(this.Clear, 0);
			this.Controls.SetChildIndex(this.PrintRequestLabel, 0);
			this.Controls.SetChildIndex(this.CoverOpenCheckBox, 0);
			this.Controls.SetChildIndex(this.ReceiptCoverOpenCheckBox, 0);
			this.Controls.SetChildIndex(this.SlipCoverOpenCheckBox, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.PrinterOutput, 0);
			this.Controls.SetChildIndex(this.tbPrintDelay, 0);
			this.Controls.SetChildIndex(this.cbPoweredOn, 0);
			this.ResumeLayout(false);

		}
		#endregion
		
		#region Delegates for marshaling calls to the UI thread

		private delegate void SetTextDelegate( string text);
		private delegate void SetStateDelegate( string text, string outputCount);
		
		private void SetOutputCountText(string outputCount)
		{
			PrintRequestLabel.Text = outputCount;
		}
		
		private void SetPrinterOutputText(string text)
		{
			PrinterOutput.Text += text;
		}
		#endregion

		private string ProcessEscapes(string str)
		{
			StringBuilder res = new StringBuilder(str.Length);
			for (int i=0; i<str.Length; i++)
			{
				if ((i < str.Length-3) && 
					(str[i] == (char) 27) &&
					(str[i+1] == '|'))
				{
					// next parse out integers (if any)
					int j = i+2;
					string IntStr = "";
					while (j < str.Length && str[j] >= '0' && str[j] <= '9')
					{
						IntStr += str[j];
						j++;
					}

					// Get the ending char
					if (j < str.Length)
					{
						int Num = Int32.Parse(IntStr, CultureInfo.InvariantCulture);
						if (str[j] == 'P')
						{
							// Paper cut
							res.Append("\r\n<<" + IntStr + "% PaperCut>>\r\n");
							i = j;
							continue;
						}
						if (j < str.Length-1 && str[j] == 'l' && str[j+1] == 'F')
						{
							// Line feed
							do
							{
								res.Append("\r\n");
							}
							while(--Num > 0);

							i = j+1;
							continue;
						}
					}



				}
				
				res.Append(str[i]);
			}

			return res.ToString();
		}

		private void Clear_Click(object sender, System.EventArgs e)
		{
			PrinterOutput.Clear();
		}

		private void CoverOpenCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			PosPrinterSimulator p = ServiceObjectReference.Target as PosPrinterSimulator;

			if (p != null)
			{
				if (CoverOpenCheckBox.Checked)
					p.OnCoverOpened();
				else
					p.OnCoverClosed();

				CoverOpenCheckBox.Checked = p.PrinterProperties.CoverOpen;
			}
		}

		private void ReceiptCoverOpenCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			PosPrinterSimulator p = ServiceObjectReference.Target as PosPrinterSimulator;

			if (p != null)
			{
				if (ReceiptCoverOpenCheckBox.Checked)
					p.OnReceiptCoverOpened();
				else
					p.OnReceiptCoverClosed();

				CoverOpenCheckBox.Checked = p.PrinterProperties.CoverOpen;
			}
		}

		private void SlipCoverOpenCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			PosPrinterSimulator p = ServiceObjectReference.Target as PosPrinterSimulator;

			if (p != null)
			{
				if (SlipCoverOpenCheckBox.Checked)
					p.OnSlipCoverOpened();
				else
					p.OnSlipCoverClosed();

				CoverOpenCheckBox.Checked = p.PrinterProperties.CoverOpen;
			}
		}

		private void tbPrintDelay_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				PosPrinterSimulator p = ServiceObjectReference.Target as PosPrinterSimulator;
				if (p != null)
					p.PrintDelay = Int32.Parse(tbPrintDelay.Text, CultureInfo.CurrentCulture);
			}
			catch
			{
			}
		}

		private void cbPoweredOn_CheckedChanged(object sender, System.EventArgs e)
		{
			SetPowerState();
		}

		private void SetPowerState()
		{
			try
			{
				PosPrinterSimulator p = ServiceObjectReference.Target as PosPrinterSimulator;
				if (p != null)
					p.PrinterProperties.PowerState = cbPoweredOn.Checked ? PowerState.Online : PowerState.OffOffline;
			}
			catch
			{
			}
		}

		
	}

	
	#endregion

	#region PosPrinter Class
	[ServiceObject(	DeviceType.PosPrinter, 
		 "Microsoft PosPrinter Simulator",
        "Simulated service object for Pos Printer", 1, 12)]
	public class PosPrinterSimulator : PosPrinterBase
	{
		public PosPrinterSimulator()
		{
			// This is a non-Pnp device so we must set its device path here
			DevicePath = "Microsoft PosPrinter Simulator";
			Properties.DeviceDescription = "Microsoft PosPrinter Simulator";
			Properties.CapPowerReporting = PowerReporting.Standard;
		}

		internal PrinterProperties PrinterProperties
		{
			get { return Properties; }
		}

		private PosPrinterSimulatorWindow Window;
		~PosPrinterSimulator()
		{
			Dispose(false);
		}


		#region PosPrinter Methods

		

		public override void Open()
		{
			// Device State checking done in base class
			base.Open();

			// Initialize the CheckHealthText property to an empty string
			checkhealthtext = "";

			// Set values for common statistics
			SetStatisticValue(StatisticManufacturerName, "Microsoft Corporation");
			SetStatisticValue(StatisticManufactureDate, "2004-05-23");
			SetStatisticValue(StatisticModelName, "PosPrinter Simulator");
			SetStatisticValue(StatisticMechanicalRevision, "1.0");
			SetStatisticValue(StatisticInterface, "Other");

			Window = new PosPrinterSimulatorWindow(this);
			
			// set capabilities
			Properties.CapPowerReporting = PowerReporting.Standard;
			Properties.CapRecPresent = true;
			Properties.CapRecEmptySensor = true;
			Properties.CapRecNearEndSensor = true;
			Properties.RecEmpty = false;
			Properties.RecNearEnd = false;
			Properties.CapRecPaperCut = true;
			Properties.CapTransaction = true;
			Properties.CapRecRight90 = true;
			Properties.CapRecRotate180 = true;
			Properties.CapRecLeft90 = true;
			Properties.CapCoverSensor = true;
			Properties.CapSlpPresent = true;
			Properties.CapSlpEmptySensor = true;
			Properties.CapSlpNearEndSensor = true;
			Properties.SlpEmpty = false;
			Properties.SlpNearEnd = false;
			Properties.CapRecBarCode = true;
			Properties.RecBarCodeRotationList = new Rotation [] {Rotation.Normal, Rotation.Right90, Rotation.Left90, Rotation.Rotate180};
		}

		protected override PrintResults CutPaperImpl(int percentage)
		{
			Window.DisplayText("Paper cut: " + percentage.ToString(CultureInfo.CurrentCulture) + "%\r\n" );
			Thread.Sleep(printDelay);
			PrintResults pr = new PrintResults();
			pr.PaperCutCount = 1;
			return pr;
		}

		protected override PrintResults PrintNormalImpl(PrinterStation station, PrinterState printerState, string data)
		{
			if (station == PrinterStation.Receipt && (printerState.RecRotationMode & PrintRotation.Rotate180) == PrintRotation.Rotate180)
				Window.DisplayText("[Begin " + printerState.RecRotationMode.ToString() + " rotation]\r\n");
			else if (station == PrinterStation.Slip && (printerState.SlpRotationMode & PrintRotation.Rotate180) == PrintRotation.Rotate180)
				Window.DisplayText("[Begin " + printerState.SlpRotationMode.ToString() + " rotation]\r\n");

			Window.DisplayText(data );
			
			if (station == PrinterStation.Receipt && (printerState.RecRotationMode & PrintRotation.Rotate180) == PrintRotation.Rotate180)
				Window.DisplayText("[End " + printerState.RecRotationMode.ToString() + " rotation]\r\n");
			else if (station == PrinterStation.Slip && (printerState.SlpRotationMode & PrintRotation.Rotate180) == PrintRotation.Rotate180)
				Window.DisplayText("[End " + printerState.SlpRotationMode.ToString() + " rotation]\r\n");
			
			Thread.Sleep(printDelay);

			return GetPrintStats(station, data.Length);
		}

		private PrintResults GetPrintStats(PrinterStation station, int chars)
		{
			PrintResults pr = new PrintResults();
			if (station == PrinterStation.Journal)
			{
				pr.JournalLinePrintedCount = 1;
				pr.JournalCharacterPrintedCount = chars;
			}
			else if (station == PrinterStation.Receipt)
			{
				pr.ReceiptLinePrintedCount = 1;
				pr.ReceiptCharacterPrintedCount = chars;
			}
			else if (station == PrinterStation.Slip)
			{
				pr.SlipLinePrintedCount = 1;
				pr.SlipCharacterPrintedCount = chars;
			}
			return pr;
		}


		protected override PrintResults PrintImmediateImpl(PrinterStation station, string data, PrinterState state)
		{
			Window.DisplayText(data );
			Thread.Sleep(printDelay);
			return GetPrintStats(station, data.Length);
		}

		protected override void	ValidateDataImpl(PrinterStation station, string data)
		{
		}

		protected override void BeginInsertionImpl(int timeout)
		{
			
		}
		
		protected override bool EndInsertionImpl()
		{
			return true;
		}

		protected override void BeginRemovalImpl(int timeout)
		{
			
		}

		protected override bool EndRemovalImpl()
		{
			return true;
		}




		protected override PrintResults			RotatePrintImpl(RotatePrintCollection collection)
		{
			int chars = DisplayRotatePrintTransaction(collection);

			Thread.Sleep(printDelay);
			return GetPrintStats(collection.Station, chars);
		}

		private int DisplayRotatePrintTransaction(RotatePrintCollection collection)
		{
			int chars = 0;
			Rotation rotation = collection.Rotation;
			Window.DisplayText("[Begin " + rotation.ToString() + " rotation]\r\n");
			
			foreach (PrintOperation operation in collection)
			{
				string s = "";

				if (operation is PrintNormalOperation)
					s = ((PrintNormalOperation) operation).Data;
				else if (operation is PrintBitmapOperation)
					s = "Bitmap: " + ((PrintBitmapOperation) operation).FileName + "\r\n";
				else if (operation is PrintBarCodeOperation)
					s = "BarCode: " + ((PrintBarCodeOperation) operation).Data + "\r\n";
				else
					s = "Unexpected operation type.\r\n";

				Window.DisplayText(s);
				chars += s.Length;
			}
			Window.DisplayText("[End " + rotation.ToString() + " rotation]\r\n");
			
			return chars;
		}

		protected override PrintResults			TransactionPrintImpl(PrintOperationCollection collection)
		{
			int chars = 0;
			Window.DisplayText("[Begin transaction]\r\n");
			foreach (PrintOperation operation in collection)
			{
				string s = "";
				Rotation rotation = operation.Rotation;
				
				if (operation is PrintNormalOperation)
					s = ((PrintNormalOperation) operation).Data;
				else if (operation is CutPaperOperation)
					s = "Cut paper at: " + ((CutPaperOperation) operation).Percentage.ToString(CultureInfo.CurrentCulture) + "%";
				else if (operation is PrintBitmapOperation)
					s = "Bitmap: " + ((PrintBitmapOperation) operation).FileName + "\r\n";
				else if (operation is PrintBarCodeOperation)
					s = "BarCode: " + ((PrintBarCodeOperation) operation).Data + "\r\n";
				else if (operation is RotatePrintOperation)
					chars += DisplayRotatePrintTransaction(((RotatePrintOperation)operation).Collection);
				else
					s = "Unexpected operation type.\r\n";

				if (rotation == Rotation.Rotate180)
					Window.DisplayText("[Begin " + rotation.ToString() + " rotation]\r\n");
				
				Window.DisplayText(s);
				
				if (rotation == Rotation.Rotate180)
					Window.DisplayText("[End " + rotation.ToString() + " rotation]\r\n");

				chars += s.Length;
			}
			Window.DisplayText("[End transaction]\r\n");
			Thread.Sleep(printDelay);
			return GetPrintStats(collection[0].Station, chars);
		}
		
		#endregion
	
		
		
		#region UPOS Common Overrides

		private string checkhealthtext;
		public override string CheckHealthText
		{
			get
			{
				// Verify that device is open
				VerifyState(false, false);

				return checkhealthtext;
			}
		}


		public override string					CheckHealth( HealthCheckLevel level)
		{
			// Verify that device is open, claimed and enabled
			VerifyState(true, true);

			// TODO: check the health of the device and return a descriptive string 

			// Cache result in the CheckHealthText property
			checkhealthtext = "Ok";
			return checkhealthtext;
		}

		public override DirectIOData	DirectIO( int command, int data, object obj )
		{
			// Verify that device is open
			VerifyState(false, false);
			
			return new DirectIOData(data, obj);
		}


		private int printDelay = 0;
		protected internal int PrintDelay
		{
			get { return printDelay; }
			set { printDelay = value; }
		}

		public override bool DeviceEnabled
		{
			// Device State checking done in base class
			get
			{
				return base.DeviceEnabled;
			}
			set
			{
				if (base.DeviceEnabled != value)
				{
					base.DeviceEnabled = value;
					
					if (PowerNotify == PowerNotification.Enabled)
						QueueEvent(new StatusUpdateEventArgs((int) PowerState));
				}
			}
		}

		#endregion
		
		# region Private members
		
		
		
		internal void OnCoverOpened()
		{
			Properties.CoverOpen = true;
		}

		internal void OnCoverClosed()
		{
			Properties.CoverOpen = false;
		}

		internal void OnReceiptCoverOpened()
		{
			Properties.RecCoverOpen = true;
		}

		internal void OnReceiptCoverClosed()
		{
			Properties.RecCoverOpen = false;
		}

		internal void OnSlipCoverOpened()
		{
			Properties.SlpCoverOpen = true;
		}

		internal void OnSlipCoverClosed()
		{
			Properties.SlpCoverOpen = false;
		}
				
		
		#endregion
				
		#region Dispose pattern

		protected override void Dispose(bool disposing)
		{
			try
			{
				if(disposing)
				{
					Logger.Info("PosPrinterSimulator", "Disposing class: " + this.ToString());
					// Release the managed resources you added in
					// this derived class here.
				}
				// Release the native unmanaged resources
				// Win needs to be treated as an unmanaged resource because
				// it is a class that contain threads and windows and won't get collected
				// by the GC
				if (Window != null)
				{
					Window.Close();
					Window = null;
				} 
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

	
		#endregion

		protected override void PreQueuePrintData(PrintOperationCollection printCollection)
		{
			// This is a simple example of how to validate async operations before they are added
			// internal print queue.  It's the SO's responsibility to do any required validations
			// here and throw an appropriate exception if anything in the collection is invalid.
			// If an exception is not thrown the operation will be added to the internal print 
			// queue and processed in fifo order.
			RotatePrintCollection rpc = printCollection as RotatePrintCollection;
			if (rpc != null)
			{
				ValidationPrintRotation(rpc);
			}
			else
			{
				foreach (PrintOperation p in printCollection)
				{
					RotatePrintOperation rpo = p as RotatePrintOperation;
					if (rpo != null)
						ValidationPrintRotation(rpo.Collection);
				}
			}
		}

		private void ValidationPrintRotation(RotatePrintCollection rpc)
		{
			if (rpc != null && rpc.Count > 10)
			{
				// Assume we can print a max of 10 lines in a sideways rotation
				throw new PosControlException("Rotation print operation exceeds the page size.", ErrorCode.Illegal);
			}
		}
	}
	#endregion
}
