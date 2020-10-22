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
using System.Reflection;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Threading;
using System.Text;
using System.Globalization;         
using Microsoft.PointOfService;
using Microsoft.PointOfService.BaseServiceObjects;

namespace Microsoft.PointOfService.DeviceSimulators
{
	#region ScannerSimulatorWindow
	/// <summary>
	/// Summary description for ScannerSimulator.
	/// </summary>
	public class ScannerSimulatorWindow : SimulatorBase
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button GoodScan;
		private System.Windows.Forms.Button BadScan;
		private System.Windows.Forms.TextBox BarCode;
		private System.Windows.Forms.ComboBox Symbology;
		private System.Windows.Forms.Label label4;



		public ScannerSimulatorWindow(ScannerSimulator serviceObject) : base(serviceObject)
		{
			Invoke(new MethodDelegate(InitializeComponent));
			Invoke(new MethodDelegate(InitializeUI));
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
			this.label3 = new System.Windows.Forms.Label();
			this.BarCode = new System.Windows.Forms.TextBox();
			this.GoodScan = new System.Windows.Forms.Button();
			this.BadScan = new System.Windows.Forms.Button();
			this.Symbology = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 26;
			this.label3.Text = "Barcode";
			// 
			// BarCode
			// 
			this.BarCode.Location = new System.Drawing.Point(176, 56);
			this.BarCode.Name = "BarCode";
			this.BarCode.Size = new System.Drawing.Size(304, 20);
			this.BarCode.TabIndex = 27;
			this.BarCode.Text = "";
			// 
			// GoodScan
			// 
			this.GoodScan.Location = new System.Drawing.Point(136, 96);
			this.GoodScan.Name = "GoodScan";
			this.GoodScan.TabIndex = 28;
			this.GoodScan.Text = "Good Scan";
			this.GoodScan.Click += new System.EventHandler(this.GoodScan_Click);
			// 
			// BadScan
			// 
			this.BadScan.Location = new System.Drawing.Point(248, 96);
			this.BadScan.Name = "BadScan";
			this.BadScan.TabIndex = 0;
			this.BadScan.Text = "Bad Scan";
			this.BadScan.Click += new System.EventHandler(this.BadScan_Click);
			// 
			// Symbology
			// 
			this.Symbology.Location = new System.Drawing.Point(176, 16);
			this.Symbology.Name = "Symbology";
			this.Symbology.Size = new System.Drawing.Size(104, 21);
			this.Symbology.TabIndex = 29;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 30;
			this.label4.Text = "Symbology";
			// 
			// ScannerSimulatorWindow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 151);
			this.Controls.Add(this.BarCode);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.Symbology);
			this.Controls.Add(this.BadScan);
			this.Controls.Add(this.GoodScan);
			this.Controls.Add(this.label3);
			this.Name = "ScannerSimulatorWindow";
			this.Text = "Microsoft Scanner Simulator";
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.GoodScan, 0);
			this.Controls.SetChildIndex(this.BadScan, 0);
			this.Controls.SetChildIndex(this.Symbology, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.BarCode, 0);
			this.ResumeLayout(false);

		}
		#endregion

		
		private void BadScan_Click(object sender, System.EventArgs e)
		{
			ScannerSimulator Sim = ServiceObjectReference.Target as ScannerSimulator;
			if (Sim != null)
				Sim.InputErrorEvent();
		}

		private void GoodScan_Click(object sender, System.EventArgs e)
		{
			// Queue up a data event
			BarCodeSymbology type = (BarCodeSymbology)Enum.Parse(typeof(BarCodeSymbology), Symbology.SelectedItem.ToString());
			ScannerSimulator Sim = ServiceObjectReference.Target as ScannerSimulator;
			if (Sim != null)
				Sim.InputDataEvent(BarCode.Text, type);
		}

		private void InitializeUI()
		{
			Symbology.Items.AddRange(Enum.GetNames(typeof(BarCodeSymbology)));
			Symbology.SelectedIndex = 0;
		}
	}

	
	#endregion ScannerSimulatorWindow

	#region ScannerSimulator Class
	[ServiceObjectAttribute(DeviceType.Scanner, 
		 "Microsoft Scanner Simulator",
        "Simulated service object for scanner", 1, 12)]
	/// <summary>
	/// Simulate a scanner by enabling a UI to manually trigger scan events. Additionally provide automated interface
	/// through an XML scan file.
	/// </summary>
	public class ScannerSimulator : ScannerBase
	{
		private ScannerSimulatorWindow Window;

		public ScannerSimulator()
		{
			// This is a non-Pnp device so we must set its device path here
			DevicePath = "Microsoft Scanner Simulator";
			Properties.DeviceDescription = "Microsoft Scanner Simulator";
		}

		~ScannerSimulator()
		{
			Dispose(false);
		}

	
		protected override void Dispose(bool disposing)
		{
			try
			{
				if(disposing)
				{
					Logger.Info("ScannerSimulator", "Disposing class: " + this.ToString());
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



		private string DataToHex(byte[] data)
		{
			StringBuilder sb = new StringBuilder(data.Length*4);
			// decode the byte array containing scan data back to a string.
			foreach (byte b in data)
			{
				sb.Append(b.ToString("X", CultureInfo.InvariantCulture));
				sb.Append(" ");
			}
			return sb.ToString();
		}

		/// <summary>
		/// A good scan event occurred: queue it and update the GoodScanCount statistic
		/// </summary>
		/// <param name="d">Scan event arguments</param>
		public void InputDataEvent(string data)
		{
			InputDataEvent(data, BarCodeSymbology.Unknown);
		}


		/// <summary>
		/// A good scan event occurred: queue it and update the GoodScanCount statistic
		/// </summary>
		/// <param name="d">Scan event arguments</param>
		public void InputDataEvent(string data, BarCodeSymbology type)
		{
			if (data == null)
				return;

			byte[] b = new byte[data.Length];
			for (int i=0; i< data.Length; i++)
				b[i] = (byte) data[i];

			Logger.Info("Scanner", "Scan event: " + DataToHex(b) + ", type=" + type);

			GoodScan(b, type, b);
		}

		/// <summary>
		/// A bad scan event occurred: queue it
		/// </summary>
		/// <param name="d">Error event arguments</param>
		public void InputErrorEvent()
		{
			Logger.Info("Scanner", "Bad Scan event. ");
			FailedScan();
		}

		#region Overrides
		override public void Open()
		{
			// Device State checking done in base class
			base.Open();

			// Set values for common statistics
			SetStatisticValue(StatisticManufacturerName, "Microsoft Corporation");
			SetStatisticValue(StatisticManufactureDate, "2004-05-23");
			SetStatisticValue(StatisticModelName, "Scanner Simulator");
			SetStatisticValue(StatisticMechanicalRevision, "1.0");
			SetStatisticValue(StatisticInterface, "Other");

			// Initialize the CheckHealthText property to an empty string
			checkhealthtext = "";

			// show simulation window
			Window = new ScannerSimulatorWindow(this);
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

		#endregion Overrides

	}
	#endregion
}


