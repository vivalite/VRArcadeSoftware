// This is a part of the Microsoft POS for .NET SDK
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This sample source code is only intended as a 
// supplement to the POS for .NET SDK and related 
// electronic documentation provided with the library.

using System;
using System.Windows.Forms;
using System.Threading;
using Microsoft.PointOfService.BaseServiceObjects;

namespace Microsoft.PointOfService.DeviceSimulators
{
	#region PinPadSimulatorWindow Class
	internal class PinPadSimulatorWindow : SimulatorBase
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox PINtextBox;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button Cancelbutton;
		private System.Windows.Forms.Button Timeoutbutton;
		private System.Windows.Forms.Button BadKeybutton;
		private System.Windows.Forms.TextBox AdditionalInfotextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblPrompt;


		public PinPadSimulatorWindow(PinPadSimulator serviceObject) : base(serviceObject)
		{
			Invoke(new MethodDelegate(InitializeComponent));
		}

		private delegate void SetTextDelegate(string text);
		private void SetPrompt(string text)
		{
			lblPrompt.Text = text;
		}

		public void SetPromptText(string text)
		{
			if (InvokeRequired)
				Invoke(new SetTextDelegate(SetPrompt), new object[] {text});
			else
				SetPrompt(text);
		}

		private void UpdateButtonStateOnMainThread(Object stateInfo) 
		{
			Invoke(new MethodDelegate(SetButtonState));
		}

		public void UpdateButtonState()
		{
			if (InvokeRequired)
				ThreadPool.QueueUserWorkItem(new WaitCallback(UpdateButtonStateOnMainThread), this);
			else 
				SetButtonState();
		}

		private void SetButtonState()
		{
			PinPadSimulator Sim = ServiceObjectReference.Target as PinPadSimulator;
			if (Sim != null && Sim.State != ControlState.Closed)
			{
				OKButton.Enabled = Sim.PinEntryEnabled;
				Cancelbutton.Enabled = OKButton.Enabled;
				BadKeybutton.Enabled = OKButton.Enabled;
				Timeoutbutton.Enabled = OKButton.Enabled;
			}
				
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PinPadSimulatorWindow));
			this.label2 = new System.Windows.Forms.Label();
			this.PINtextBox = new System.Windows.Forms.TextBox();
			this.OKButton = new System.Windows.Forms.Button();
			this.Cancelbutton = new System.Windows.Forms.Button();
			this.Timeoutbutton = new System.Windows.Forms.Button();
			this.BadKeybutton = new System.Windows.Forms.Button();
			this.AdditionalInfotextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lblPrompt = new System.Windows.Forms.Label();
			this.SuspendLayout();
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
			// PINtextBox
			// 
			this.PINtextBox.AccessibleDescription = resources.GetString("PINtextBox.AccessibleDescription");
			this.PINtextBox.AccessibleName = resources.GetString("PINtextBox.AccessibleName");
			this.PINtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("PINtextBox.Anchor")));
			this.PINtextBox.AutoSize = ((bool)(resources.GetObject("PINtextBox.AutoSize")));
			this.PINtextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PINtextBox.BackgroundImage")));
			this.PINtextBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("PINtextBox.Dock")));
			this.PINtextBox.Enabled = ((bool)(resources.GetObject("PINtextBox.Enabled")));
			this.PINtextBox.Font = ((System.Drawing.Font)(resources.GetObject("PINtextBox.Font")));
			this.PINtextBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("PINtextBox.ImeMode")));
			this.PINtextBox.Location = ((System.Drawing.Point)(resources.GetObject("PINtextBox.Location")));
			this.PINtextBox.MaxLength = ((int)(resources.GetObject("PINtextBox.MaxLength")));
			this.PINtextBox.Multiline = ((bool)(resources.GetObject("PINtextBox.Multiline")));
			this.PINtextBox.Name = "PINtextBox";
			this.PINtextBox.PasswordChar = ((char)(resources.GetObject("PINtextBox.PasswordChar")));
			this.PINtextBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("PINtextBox.RightToLeft")));
			this.PINtextBox.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("PINtextBox.ScrollBars")));
			this.PINtextBox.Size = ((System.Drawing.Size)(resources.GetObject("PINtextBox.Size")));
			this.PINtextBox.TabIndex = ((int)(resources.GetObject("PINtextBox.TabIndex")));
			this.PINtextBox.Text = resources.GetString("PINtextBox.Text");
			this.PINtextBox.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("PINtextBox.TextAlign")));
			this.PINtextBox.Visible = ((bool)(resources.GetObject("PINtextBox.Visible")));
			this.PINtextBox.WordWrap = ((bool)(resources.GetObject("PINtextBox.WordWrap")));
			// 
			// OKButton
			// 
			this.OKButton.AccessibleDescription = resources.GetString("OKButton.AccessibleDescription");
			this.OKButton.AccessibleName = resources.GetString("OKButton.AccessibleName");
			this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("OKButton.Anchor")));
			this.OKButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OKButton.BackgroundImage")));
			this.OKButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("OKButton.Dock")));
			this.OKButton.Enabled = ((bool)(resources.GetObject("OKButton.Enabled")));
			this.OKButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("OKButton.FlatStyle")));
			this.OKButton.Font = ((System.Drawing.Font)(resources.GetObject("OKButton.Font")));
			this.OKButton.Image = ((System.Drawing.Image)(resources.GetObject("OKButton.Image")));
			this.OKButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("OKButton.ImageAlign")));
			this.OKButton.ImageIndex = ((int)(resources.GetObject("OKButton.ImageIndex")));
			this.OKButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("OKButton.ImeMode")));
			this.OKButton.Location = ((System.Drawing.Point)(resources.GetObject("OKButton.Location")));
			this.OKButton.Name = "OKButton";
			this.OKButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("OKButton.RightToLeft")));
			this.OKButton.Size = ((System.Drawing.Size)(resources.GetObject("OKButton.Size")));
			this.OKButton.TabIndex = ((int)(resources.GetObject("OKButton.TabIndex")));
			this.OKButton.Text = resources.GetString("OKButton.Text");
			this.OKButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("OKButton.TextAlign")));
			this.OKButton.Visible = ((bool)(resources.GetObject("OKButton.Visible")));
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// Cancelbutton
			// 
			this.Cancelbutton.AccessibleDescription = resources.GetString("Cancelbutton.AccessibleDescription");
			this.Cancelbutton.AccessibleName = resources.GetString("Cancelbutton.AccessibleName");
			this.Cancelbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Cancelbutton.Anchor")));
			this.Cancelbutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Cancelbutton.BackgroundImage")));
			this.Cancelbutton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Cancelbutton.Dock")));
			this.Cancelbutton.Enabled = ((bool)(resources.GetObject("Cancelbutton.Enabled")));
			this.Cancelbutton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("Cancelbutton.FlatStyle")));
			this.Cancelbutton.Font = ((System.Drawing.Font)(resources.GetObject("Cancelbutton.Font")));
			this.Cancelbutton.Image = ((System.Drawing.Image)(resources.GetObject("Cancelbutton.Image")));
			this.Cancelbutton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Cancelbutton.ImageAlign")));
			this.Cancelbutton.ImageIndex = ((int)(resources.GetObject("Cancelbutton.ImageIndex")));
			this.Cancelbutton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Cancelbutton.ImeMode")));
			this.Cancelbutton.Location = ((System.Drawing.Point)(resources.GetObject("Cancelbutton.Location")));
			this.Cancelbutton.Name = "Cancelbutton";
			this.Cancelbutton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Cancelbutton.RightToLeft")));
			this.Cancelbutton.Size = ((System.Drawing.Size)(resources.GetObject("Cancelbutton.Size")));
			this.Cancelbutton.TabIndex = ((int)(resources.GetObject("Cancelbutton.TabIndex")));
			this.Cancelbutton.Text = resources.GetString("Cancelbutton.Text");
			this.Cancelbutton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Cancelbutton.TextAlign")));
			this.Cancelbutton.Visible = ((bool)(resources.GetObject("Cancelbutton.Visible")));
			this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
			// 
			// Timeoutbutton
			// 
			this.Timeoutbutton.AccessibleDescription = resources.GetString("Timeoutbutton.AccessibleDescription");
			this.Timeoutbutton.AccessibleName = resources.GetString("Timeoutbutton.AccessibleName");
			this.Timeoutbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Timeoutbutton.Anchor")));
			this.Timeoutbutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Timeoutbutton.BackgroundImage")));
			this.Timeoutbutton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Timeoutbutton.Dock")));
			this.Timeoutbutton.Enabled = ((bool)(resources.GetObject("Timeoutbutton.Enabled")));
			this.Timeoutbutton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("Timeoutbutton.FlatStyle")));
			this.Timeoutbutton.Font = ((System.Drawing.Font)(resources.GetObject("Timeoutbutton.Font")));
			this.Timeoutbutton.Image = ((System.Drawing.Image)(resources.GetObject("Timeoutbutton.Image")));
			this.Timeoutbutton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Timeoutbutton.ImageAlign")));
			this.Timeoutbutton.ImageIndex = ((int)(resources.GetObject("Timeoutbutton.ImageIndex")));
			this.Timeoutbutton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Timeoutbutton.ImeMode")));
			this.Timeoutbutton.Location = ((System.Drawing.Point)(resources.GetObject("Timeoutbutton.Location")));
			this.Timeoutbutton.Name = "Timeoutbutton";
			this.Timeoutbutton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Timeoutbutton.RightToLeft")));
			this.Timeoutbutton.Size = ((System.Drawing.Size)(resources.GetObject("Timeoutbutton.Size")));
			this.Timeoutbutton.TabIndex = ((int)(resources.GetObject("Timeoutbutton.TabIndex")));
			this.Timeoutbutton.Text = resources.GetString("Timeoutbutton.Text");
			this.Timeoutbutton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Timeoutbutton.TextAlign")));
			this.Timeoutbutton.Visible = ((bool)(resources.GetObject("Timeoutbutton.Visible")));
			this.Timeoutbutton.Click += new System.EventHandler(this.Timeoutbutton_Click);
			// 
			// BadKeybutton
			// 
			this.BadKeybutton.AccessibleDescription = resources.GetString("BadKeybutton.AccessibleDescription");
			this.BadKeybutton.AccessibleName = resources.GetString("BadKeybutton.AccessibleName");
			this.BadKeybutton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("BadKeybutton.Anchor")));
			this.BadKeybutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BadKeybutton.BackgroundImage")));
			this.BadKeybutton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("BadKeybutton.Dock")));
			this.BadKeybutton.Enabled = ((bool)(resources.GetObject("BadKeybutton.Enabled")));
			this.BadKeybutton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("BadKeybutton.FlatStyle")));
			this.BadKeybutton.Font = ((System.Drawing.Font)(resources.GetObject("BadKeybutton.Font")));
			this.BadKeybutton.Image = ((System.Drawing.Image)(resources.GetObject("BadKeybutton.Image")));
			this.BadKeybutton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BadKeybutton.ImageAlign")));
			this.BadKeybutton.ImageIndex = ((int)(resources.GetObject("BadKeybutton.ImageIndex")));
			this.BadKeybutton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("BadKeybutton.ImeMode")));
			this.BadKeybutton.Location = ((System.Drawing.Point)(resources.GetObject("BadKeybutton.Location")));
			this.BadKeybutton.Name = "BadKeybutton";
			this.BadKeybutton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("BadKeybutton.RightToLeft")));
			this.BadKeybutton.Size = ((System.Drawing.Size)(resources.GetObject("BadKeybutton.Size")));
			this.BadKeybutton.TabIndex = ((int)(resources.GetObject("BadKeybutton.TabIndex")));
			this.BadKeybutton.Text = resources.GetString("BadKeybutton.Text");
			this.BadKeybutton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BadKeybutton.TextAlign")));
			this.BadKeybutton.Visible = ((bool)(resources.GetObject("BadKeybutton.Visible")));
			this.BadKeybutton.Click += new System.EventHandler(this.BadKeybutton_Click);
			// 
			// AdditionalInfotextBox
			// 
			this.AdditionalInfotextBox.AccessibleDescription = resources.GetString("AdditionalInfotextBox.AccessibleDescription");
			this.AdditionalInfotextBox.AccessibleName = resources.GetString("AdditionalInfotextBox.AccessibleName");
			this.AdditionalInfotextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("AdditionalInfotextBox.Anchor")));
			this.AdditionalInfotextBox.AutoSize = ((bool)(resources.GetObject("AdditionalInfotextBox.AutoSize")));
			this.AdditionalInfotextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AdditionalInfotextBox.BackgroundImage")));
			this.AdditionalInfotextBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("AdditionalInfotextBox.Dock")));
			this.AdditionalInfotextBox.Enabled = ((bool)(resources.GetObject("AdditionalInfotextBox.Enabled")));
			this.AdditionalInfotextBox.Font = ((System.Drawing.Font)(resources.GetObject("AdditionalInfotextBox.Font")));
			this.AdditionalInfotextBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("AdditionalInfotextBox.ImeMode")));
			this.AdditionalInfotextBox.Location = ((System.Drawing.Point)(resources.GetObject("AdditionalInfotextBox.Location")));
			this.AdditionalInfotextBox.MaxLength = ((int)(resources.GetObject("AdditionalInfotextBox.MaxLength")));
			this.AdditionalInfotextBox.Multiline = ((bool)(resources.GetObject("AdditionalInfotextBox.Multiline")));
			this.AdditionalInfotextBox.Name = "AdditionalInfotextBox";
			this.AdditionalInfotextBox.PasswordChar = ((char)(resources.GetObject("AdditionalInfotextBox.PasswordChar")));
			this.AdditionalInfotextBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("AdditionalInfotextBox.RightToLeft")));
			this.AdditionalInfotextBox.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("AdditionalInfotextBox.ScrollBars")));
			this.AdditionalInfotextBox.Size = ((System.Drawing.Size)(resources.GetObject("AdditionalInfotextBox.Size")));
			this.AdditionalInfotextBox.TabIndex = ((int)(resources.GetObject("AdditionalInfotextBox.TabIndex")));
			this.AdditionalInfotextBox.Text = resources.GetString("AdditionalInfotextBox.Text");
			this.AdditionalInfotextBox.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("AdditionalInfotextBox.TextAlign")));
			this.AdditionalInfotextBox.Visible = ((bool)(resources.GetObject("AdditionalInfotextBox.Visible")));
			this.AdditionalInfotextBox.WordWrap = ((bool)(resources.GetObject("AdditionalInfotextBox.WordWrap")));
			// 
			// label3
			// 
			this.label3.AccessibleDescription = resources.GetString("label3.AccessibleDescription");
			this.label3.AccessibleName = resources.GetString("label3.AccessibleName");
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label3.Anchor")));
			this.label3.AutoSize = ((bool)(resources.GetObject("label3.AutoSize")));
			this.label3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label3.Dock")));
			this.label3.Enabled = ((bool)(resources.GetObject("label3.Enabled")));
			this.label3.Font = ((System.Drawing.Font)(resources.GetObject("label3.Font")));
			this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
			this.label3.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.ImageAlign")));
			this.label3.ImageIndex = ((int)(resources.GetObject("label3.ImageIndex")));
			this.label3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label3.ImeMode")));
			this.label3.Location = ((System.Drawing.Point)(resources.GetObject("label3.Location")));
			this.label3.Name = "label3";
			this.label3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label3.RightToLeft")));
			this.label3.Size = ((System.Drawing.Size)(resources.GetObject("label3.Size")));
			this.label3.TabIndex = ((int)(resources.GetObject("label3.TabIndex")));
			this.label3.Text = resources.GetString("label3.Text");
			this.label3.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.TextAlign")));
			this.label3.Visible = ((bool)(resources.GetObject("label3.Visible")));
			// 
			// lblPrompt
			// 
			this.lblPrompt.AccessibleDescription = resources.GetString("lblPrompt.AccessibleDescription");
			this.lblPrompt.AccessibleName = resources.GetString("lblPrompt.AccessibleName");
			this.lblPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblPrompt.Anchor")));
			this.lblPrompt.AutoSize = ((bool)(resources.GetObject("lblPrompt.AutoSize")));
			this.lblPrompt.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblPrompt.Dock")));
			this.lblPrompt.Enabled = ((bool)(resources.GetObject("lblPrompt.Enabled")));
			this.lblPrompt.Font = ((System.Drawing.Font)(resources.GetObject("lblPrompt.Font")));
			this.lblPrompt.Image = ((System.Drawing.Image)(resources.GetObject("lblPrompt.Image")));
			this.lblPrompt.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblPrompt.ImageAlign")));
			this.lblPrompt.ImageIndex = ((int)(resources.GetObject("lblPrompt.ImageIndex")));
			this.lblPrompt.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblPrompt.ImeMode")));
			this.lblPrompt.Location = ((System.Drawing.Point)(resources.GetObject("lblPrompt.Location")));
			this.lblPrompt.Name = "lblPrompt";
			this.lblPrompt.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblPrompt.RightToLeft")));
			this.lblPrompt.Size = ((System.Drawing.Size)(resources.GetObject("lblPrompt.Size")));
			this.lblPrompt.TabIndex = ((int)(resources.GetObject("lblPrompt.TabIndex")));
			this.lblPrompt.Text = resources.GetString("lblPrompt.Text");
			this.lblPrompt.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblPrompt.TextAlign")));
			this.lblPrompt.Visible = ((bool)(resources.GetObject("lblPrompt.Visible")));
			// 
			// PinPadSimulatorWindow
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.AdditionalInfotextBox);
			this.Controls.Add(this.PINtextBox);
			this.Controls.Add(this.lblPrompt);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.BadKeybutton);
			this.Controls.Add(this.Timeoutbutton);
			this.Controls.Add(this.Cancelbutton);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.label2);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "PinPadSimulatorWindow";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.OKButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.Timeoutbutton, 0);
			this.Controls.SetChildIndex(this.BadKeybutton, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.lblPrompt, 0);
			this.Controls.SetChildIndex(this.PINtextBox, 0);
			this.Controls.SetChildIndex(this.AdditionalInfotextBox, 0);
			this.ResumeLayout(false);

		}
		#endregion

		private void OKButton_Click(object sender, System.EventArgs e)
		{
			PinPadSimulator Sim = ServiceObjectReference.Target as PinPadSimulator;

			if (Sim != null)
			{
				Sim.OnOK(PINtextBox.Text, AdditionalInfotextBox.Text);
			}
		}

		private void Cancelbutton_Click(object sender, System.EventArgs e)
		{
			PinPadSimulator Sim = ServiceObjectReference.Target as PinPadSimulator;

			if (Sim != null)
			{
				Sim.OnCancel();
			}
		}

		private void Timeoutbutton_Click(object sender, System.EventArgs e)
		{
			PinPadSimulator Sim = ServiceObjectReference.Target as PinPadSimulator;

			if (Sim != null)
			{
				Sim.OnTimeout();
			}
		}

		private void BadKeybutton_Click(object sender, System.EventArgs e)
		{
			PinPadSimulator Sim = ServiceObjectReference.Target as PinPadSimulator;

			if (Sim != null)
			{
				Sim.OnBadKey();
			}
		}

		
		
		
	}

	#endregion

	#region PinPadSimulator Class
	[ServiceObjectAttribute(DeviceType.PinPad, 
		 "Microsoft PinPad Simulator",
        "Microsoft PinPad Simulator", 1, 12)]
	public class PinPadSimulator : PinPadBase
	{
		private PinPadSimulatorWindow Window;
				
		public PinPadSimulator()
		{
			// This is a non-Pnp device so we must set its device path here
			DevicePath = "Microsoft PinPad Simulator";
			Properties.DeviceDescription = "Microsoft PIN Pad Simulator";
		}

		~PinPadSimulator()
		{
			Dispose(false);
		}

		


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


		public override void Open()
		{
			// Device State checking done in base class
			base.Open();

			// Set values for common statistics
			SetStatisticValue(StatisticManufacturerName, "Microsoft Corporation");
			SetStatisticValue(StatisticManufactureDate, "2004-05-23");
			SetStatisticValue(StatisticModelName, "PinPad Simulator");
			SetStatisticValue(StatisticMechanicalRevision, "1.0");
			SetStatisticValue(StatisticInterface, "Other");

			// Initialize the CheckHealthText property to an empty string
			checkhealthtext = "";

			// Set capabilities
			Properties.CapDisplay = PinPadDisplay.PinRestricted;
			Properties.CapKeyboard = false;
			Properties.CapLanguage = PinPadLanguage.None;
			Properties.CapMacCalculation = false;
			Properties.CapTone = false;

			Properties.AvailablePromptsList = new PinPadMessage[] {PinPadMessage.EnterPin};
			

			// show simulation window
			Window = new PinPadSimulatorWindow(this);
		}

		private void UpdateButtonState()
		{
			if (Window != null)
			{
				Window.UpdateButtonState();
			}
		}


		protected override void	BeginEftTransactionImpl ( PinPadSystem pinpadSystem, int transactionHost )
		{
			UpdateButtonState();
		}
		protected override string	ComputeMacImpl ( string inMsg )
		{
			return inMsg;
		}
		protected override void	EnablePinEntryImpl()
		{
			UpdateButtonState();
		}
		protected override void	EndEftTransactionImpl ( EftTransactionCompletion completionCode )
		{
			UpdateButtonState();
		}
		protected override void	UpdateKeyImpl ( int keyNumber, string key )
		{
		}
		protected override void	VerifyMacImpl ( string message )
		{
		}

		public override PinPadMessage Prompt
		{
			get
			{
				return base.Prompt;
			}
			set
			{
				base.Prompt = value;

				string text = "";
				switch (value)
				{
					case PinPadMessage.EnterPin:
						text = "Enter Pin number on PIN pad.";  // should be stored in resource
						break;
				}

				if (Window != null)
					Window.SetPromptText(text);
			}
		}


		

		public void OnOK(string pin, string additionalInfo)
		{
			ExitPinEntryMode(PinEntryStatus.Success, pin, additionalInfo);
			UpdateButtonState();
		}
		public void OnCancel()
		{
			ExitPinEntryMode(PinEntryStatus.Cancel, null, null);
			UpdateButtonState();
		}
		public void OnTimeout()
		{
			ExitPinEntryMode(PinEntryStatus.Timeout, null, null);
			UpdateButtonState();
		}
		public void OnBadKey()
		{
			ExitPinEntryMode(PinEntryStatus.BadKey, null, null);
			UpdateButtonState();
		}


		protected override void Dispose(bool disposing)
		{
			try
			{
				if(disposing)
				{
					Logger.Info("PinpadSimulator", "Disposing class: " + this.ToString());
					// Release the managed resources you added in
					// this derived class here.

				}
				// Release the native unmanaged resources
				// WindowThread needs to be treated as an unmanaged resource because
				// it is a class that contain threads and windows and won't get collected
				// by the GC
				if (Window != null)
					Window.Close();
				Window = null;
				
			}
			finally
			{
				// Call Dispose on your base class.
				base.Dispose(disposing);
			}
		}
	}
	
	#endregion
}
