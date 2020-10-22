// This is a part of the Microsoft POS for .NET SDK
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This sample source code is only intended as a 
// supplement to the POS for .NET SDK and related 
// electronic documentation provided with the library.

using System;
using System.Threading;
using Microsoft.PointOfService.BasicServiceObjects;
using System.Globalization;

namespace Microsoft.PointOfService.DeviceSimulators
{
	public class KeylockSimulatorWindow : SimulatorBase
	{
		private System.Windows.Forms.ComboBox cbPosition;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.IContainer components = null;
		private int LastKeylockPosition;
		
		public KeylockSimulatorWindow(KeylockSimulator serviceObject) : base (serviceObject)
		{
			Invoke(new MethodDelegate(InitializeComponent));
			Invoke(new MethodDelegate(PopulateUI));
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

	
		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			
			this.cbPosition = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cbPosition
			// 
			this.cbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPosition.Location = new System.Drawing.Point(136, 32);
			this.cbPosition.Name = "cbPosition";
			this.cbPosition.Size = new System.Drawing.Size(121, 21);
			this.cbPosition.TabIndex = 3;
			this.cbPosition.SelectedIndexChanged += new System.EventHandler(this.cbPosition_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Current Key Position";
			// 
			// KeylockSimulatorWindow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(298, 95);
			this.Controls.Add(this.cbPosition);
			this.Controls.Add(this.label1);
			this.Name = "KeylockSimulatorWindow";
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.cbPosition, 0);
			this.ResumeLayout(false);

		}
		#endregion

		private void PopulateUI()
		{
			KeylockSimulator keylock = ServiceObjectReference.Target as KeylockSimulator;
			if (keylock != null)
			{
				cbPosition.Items.Clear();
				cbPosition.Items.Add("Locked");
				cbPosition.Items.Add("Normal");
				cbPosition.Items.Add("Supervisor");

				for (int i=3; i < keylock.positioncount; i++)
					cbPosition.Items.Add((i+1).ToString(CultureInfo.InvariantCulture));

				int keyposition = keylock.keyposition;
				if (keyposition == Keylock.PositionLocked)
					cbPosition.Text = "Locked";
				if (keyposition == Keylock.PositionNormal)
					cbPosition.Text = "Normal";
				if (keyposition == Keylock.PositionSupervisor)
					cbPosition.Text = "Supervisor";
				else
					cbPosition.Text = keyposition.ToString(CultureInfo.InvariantCulture);

				LastKeylockPosition = keyposition;
			}
		}

		private void cbPosition_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			KeylockSimulator keylock = ServiceObjectReference.Target as KeylockSimulator;
			if (keylock != null)
			{
				int Position = Keylock.PositionLocked;
				
				if (cbPosition.Text == "Locked")
					Position = Keylock.PositionLocked;
				else if (cbPosition.Text == "Normal")
					Position = Keylock.PositionNormal;
				else if (cbPosition.Text == "Any")
					Position = Keylock.PositionAny;
				else if (cbPosition.Text == "Supervisor")
					Position = Keylock.PositionSupervisor;
				else 
					Position = Int32.Parse(cbPosition.Text, CultureInfo.InvariantCulture);

				if (Position != LastKeylockPosition)
				{
					LastKeylockPosition = Position;
					keylock.SetKeyPosition(Position);
				}
			}
		}
	}


	[ServiceObject(	DeviceType.Keylock, 
		 "Microsoft Keylock Simulator",
        "Service object for Microsoft Keylock Simulator", 1, 12)]
	public class KeylockSimulator : KeylockBasic
	{
		internal int positioncount = 5;
		internal int keyposition = PositionLocked;
		private KeylockSimulatorWindow Window;

		public KeylockSimulator()
		{
			DevicePath = "Microsoft Keylock Simulator";
		}

		~KeylockSimulator()
		{
			Dispose(false);
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				if(disposing)
				{
					Logger.Info("KeylockSimulator", "Disposing class: " + this.ToString());
					// Release the managed resources you added in
					// this derived class here.
				}
				// Release the native unmanaged resources
				// WindowThread needs to be treated as an unmanaged resource because
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


		internal void SetKeyPosition(int keyPosition)
		{
			if (keyposition != keyPosition)
			{
				keyposition = keyPosition;

				if (KeyWaitPosition == keyPosition || KeyWaitPosition == Keylock.PositionAny)
					KeyChangeEvent.Set();

				IncrementStatistic(Keylock.StatisticLockPositionChangeCount);
				
				// TODO: this event should be sent to all service objects that have this
				// device opened
				QueueEvent(new StatusUpdateEventArgs(keyposition));
			}
		}

		protected override void PreFireEvent(StatusUpdateEventArgs posEvent)
		{
			
		}


		public override int KeyPosition
		{
			get
			{
				VerifyState(false, true);
				return keyposition;
			}
		}
		
		public override int PositionCount
		{
			get
			{
				VerifyState(false, false);
				return positioncount;
			}
		}

		private AutoResetEvent KeyChangeEvent = new AutoResetEvent(false);
		private int KeyWaitPosition;

		public override void WaitForKeylockChange(int keyPosition, int timeout)
		{
			VerifyState(false, true);

			if (keyPosition < 0)
				throw new PosControlException("Invalid KeyPosition value.", ErrorCode.Illegal);
			if (timeout < -1)
				throw new PosControlException("Invalid Timeout value.", ErrorCode.Illegal);
			
			if (keyPosition != KeyPosition)
			{
				if (timeout == Keylock.WaitForever)
					timeout = Timeout.Infinite;

				this.CommonProperties.State = ControlState.Busy;
				try
				{
					KeyWaitPosition = keyPosition;
					KeyChangeEvent.Reset();
					if (false == KeyChangeEvent.WaitOne(timeout, false))
						throw new PosControlException("The timeout period expired before the requested keylock positioning occurred.", ErrorCode.Timeout);
				}
				finally
				{
					this.CommonProperties.State = ControlState.Idle;
				}
			}
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

		public override DirectIOData DirectIO(int command, int data, object obj)
		{
			VerifyState(false, true);
			return new DirectIOData ();
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
			SetStatisticValue(StatisticModelName, "Keylock Simulator");
			SetStatisticValue(StatisticMechanicalRevision, "1.0");
			SetStatisticValue(StatisticInterface, "Other");

			// show simulation window
			Window = new KeylockSimulatorWindow(this);
		}
	
	}
}

