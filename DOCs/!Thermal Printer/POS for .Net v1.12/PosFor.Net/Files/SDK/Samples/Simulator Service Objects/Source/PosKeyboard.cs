// This is a part of the Microsoft POS for .NET SDK
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This sample source code is only intended as a 
// supplement to the POS for .NET SDK and related 
// electronic documentation provided with the library.

using System;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using Microsoft.PointOfService.BaseServiceObjects;

namespace Microsoft.PointOfService.DeviceSimulators
{
	#region PosKeyboardWindow

	public class PosKeyboardWindow : SimulatorBase
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		

		public PosKeyboardWindow(KeyboardSimulator serviceObject) : base(serviceObject)
		{
			Invoke(new MethodDelegate(InitializeComponent));
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(24, 40);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 48);
			this.button1.TabIndex = 0;
			this.button1.Text = "PosKey1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(104, 40);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 48);
			this.button2.TabIndex = 1;
			this.button2.Text = "PosKey2";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(184, 40);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 48);
			this.button3.TabIndex = 2;
			this.button3.Text = "PosKey3";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(264, 40);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 48);
			this.button4.TabIndex = 3;
			this.button4.Text = "PosKey4";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(344, 40);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 48);
			this.button5.TabIndex = 4;
			this.button5.Text = "PosKey5";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// PosKeyboardWindow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 133);
			this.ControlBox = false;
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "PosKeyboardWindow";
			this.Text = "Microsoft PosKeyboard Simulator";
			this.ResumeLayout(false);

		}
		#endregion

		private void KeyPressed(char c)
		{
			KeyboardSimulator keyboard = ServiceObjectReference.Target as KeyboardSimulator;
			if (keyboard != null)
			{
				keyboard.KeyPressed((int) c);
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			KeyPressed('1');
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			KeyPressed('2');
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			KeyPressed('3');
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			KeyPressed('4');
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			KeyPressed('5');
		}
	}
	
	#endregion

	#region KeyboardSimulator Class
	[ServiceObject(	DeviceType.PosKeyboard, 
		 "Microsoft PosKeyboard Simulator",
        "Service object for KeyboardSimulator", 1, 12)]
	public class KeyboardSimulator : PosKeyboardBase
	{
		private PosKeyboardWindow Window;
		public KeyboardSimulator()
		{
			// This is a non-Pnp device so we must set its device path here
			DevicePath = "Microsoft PosKeyboard Simulator";
			Properties.DeviceDescription = "Microsoft Keyboard Simulator";
			Properties.CapKeyUp = true;
		}

		~KeyboardSimulator()
		{
			Dispose(false);
		}

	
		protected override void Dispose(bool disposing)
		{
			try
			{
				if(disposing)
				{
					Logger.Info("PosKeyboardSimulator", "Disposing class: " + this.ToString());
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


		#region UPOS Members

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

			// Initialize the CheckHealthText property to an empty string
			checkhealthtext = "";

			// Set values for common statistics
			SetStatisticValue(StatisticManufacturerName, "Microsoft Corporation");
			SetStatisticValue(StatisticManufactureDate, "2004-05-23");
			SetStatisticValue(StatisticModelName, "Keyboard Simulator");
			SetStatisticValue(StatisticMechanicalRevision, "1.0");
			SetStatisticValue(StatisticInterface, "Other");
		}

		
		public override bool DeviceEnabled
		{
			get
			{
				return base.DeviceEnabled;
			}
			set
			{
				if (value != base.DeviceEnabled)
				{
					base.DeviceEnabled = value;
					if (value)
					{
						Window = new PosKeyboardWindow(this);
					}
					else
					{
						if (Window != null)
						{
							Window.Close();
							Window = null;
						}
						
					}
				}
			}
		}

		#endregion

		public void KeyPressed(int key)
		{
			KeyDown(key);
			if (EventTypes == KeyboardEventType.DownUp)
				KeyUp(key);
		}

	}
	
	#endregion
}

