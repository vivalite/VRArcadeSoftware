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
using System.IO;
using System.Threading;
using Microsoft.PointOfService.BaseServiceObjects;
using System.Globalization;
using System.Reflection;

namespace Microsoft.PointOfService.DeviceSimulators
{
	/// <summary>
	/// Summary description for SimulatorBase.
	/// </summary>
	public class SimulatorBase : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private WeakReference wr;
		private ManualResetEvent WindowVisible;
		private System.Windows.Forms.StatusBar statusBar1;
		private Thread UIThread;
		protected delegate void MethodDelegate();
		private bool closed = true;

		public SimulatorBase(PosCommon serviceObject)
		{
			HandleCreated += new EventHandler(SimulatorBase_HandleCreated);
			wr = new WeakReference(serviceObject);

			WindowVisible = new ManualResetEvent(false);
			
			UIThread = new Thread(new ThreadStart(UIThreadMethod));
            UIThread.IsBackground = true;
			UIThread.Start();
			
			WindowVisible.WaitOne();
			WindowVisible.Close();
			WindowVisible = null;

			closed = false;
			stateTimer.Tick +=new EventHandler(stateTimer_Tick);
			stateTimer.Interval = 200;
			stateTimer.Start();
		}

		protected WeakReference ServiceObjectReference
		{
			get { return wr; }
		}

		// replace the Close method to make it thread safe
		new public void Close()
		{
			stateTimer.Stop();
			closed = true;

			lock(syncRoot)
			{
				if (InvokeRequired && !IsDisposed)
					Invoke(new MethodDelegate(base.Close));
				else
					base.Close();
			}
		}

	
		static private object syncRoot = new object();
		private void DrawStatus()
		{
			try
			{
				// This will redraw the status bar in the correct place if it isn't already
				if (statusBar1.Bottom != ClientSize.Height)
                    PerformLayout();

				PosCommon so = wr.Target as PosCommon;
				if (so != null && so.State != ControlState.Closed)
				{
					string text = so.State.ToString() + ", ";
					if (so.Claimed)
						text += "Claimed, ";
					else
						text += "Unclaimed, ";

					if (so.DeviceEnabled)
						text += "Enabled";
					else
						text += "Disabled";

					sbpState.Text = text;

					if (piDataEventEnabled != null)
						sbpDataEventsEnabled.Text = "DataEventsEnabled: " + piDataEventEnabled.GetValue(so, null).ToString();

					if (piDataCount != null)
						sbpDataCount.Text = "DataCount: " + piDataCount.GetValue(so, null).ToString();
				}
			}
			catch 
			{
				// eat exceptions
			}
		}

		private System.Windows.Forms.Timer stateTimer = new System.Windows.Forms.Timer();
		private void stateTimer_Tick(object sender, EventArgs e)
		{
			if (closed == false)
			{
				lock(syncRoot)
				{
					if (closed == false)
					{
						Invoke(new MethodDelegate(DrawStatus));
					}
				}
			}
		}
		

		private SimulatorBase()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}



		private StatusBarPanel sbpState, sbpDataEventsEnabled, sbpDataCount;
		private PropertyInfo piDataEventEnabled, piDataCount;

		public void UIThreadMethod()
		{
			InitializeComponent();

			PosCommon so = wr.Target as PosCommon;
			if (so != null)
			{
				this.Text = so.DeviceName;
				
				// create status bar panels
				sbpState = new StatusBarPanel();
				sbpState.BorderStyle = StatusBarPanelBorderStyle.Sunken;
				sbpState.AutoSize = StatusBarPanelAutoSize.Spring;
				statusBar1.Panels.Add(sbpState);

				piDataCount = so.GetType().GetProperty("DataCount");
				if (piDataCount != null)
				{
					sbpDataCount = new StatusBarPanel();
					sbpDataCount.BorderStyle = StatusBarPanelBorderStyle.Sunken;
					sbpDataCount.AutoSize = StatusBarPanelAutoSize.Spring;
					statusBar1.Panels.Add(sbpDataCount);
				}

				piDataEventEnabled = so.GetType().GetProperty("DataEventEnabled");
				if (piDataEventEnabled != null)
				{
					sbpDataEventsEnabled = new StatusBarPanel();
					sbpDataEventsEnabled.BorderStyle = StatusBarPanelBorderStyle.Sunken;
					sbpDataEventsEnabled.AutoSize = StatusBarPanelAutoSize.Spring;
					statusBar1.Panels.Add(sbpDataEventsEnabled);
				}
			}

			so = null;
			Application.Run(this);
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
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.SuspendLayout();
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 33);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(338, 22);
			this.statusBar1.SizingGrip = false;
			this.statusBar1.TabIndex = 0;
			this.statusBar1.Text = "statusBar1";
			// 
			// SimulatorBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(338, 55);
			this.ControlBox = false;
			this.Controls.Add(this.statusBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "SimulatorBase";
			this.Text = "SimulatorBase";
			this.ResumeLayout(false);

		}
		#endregion

		private void SimulatorBase_HandleCreated(object sender, EventArgs e)
		{
			WindowVisible.Set();
		}

		
	}
}

	

