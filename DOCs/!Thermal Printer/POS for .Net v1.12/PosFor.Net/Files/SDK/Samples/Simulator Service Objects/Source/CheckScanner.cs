// This is a part of the Microsoft POS for .NET SDK
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This sample source code is only intended as a 
// supplement to the POS for .NET SDK and related 
// electronic documentation provided with the library.

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Microsoft.PointOfService.BaseServiceObjects;
using System.Globalization;

namespace Microsoft.PointOfService.DeviceSimulators
{
	#region CheckScannerSimulatorWindow Class
	internal class CheckScannerSimulatorWindow : SimulatorBase
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox1;
		
		public CheckScannerSimulatorWindow(CheckScannerSimulator serviceObject) : base(serviceObject)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckScannerSimulatorWindow));
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // CheckScannerSimulatorWindow
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Name = "CheckScannerSimulatorWindow";
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			CheckScannerSimulator s = ServiceObjectReference.Target as CheckScannerSimulator;
			if (s != null)
			{
				if (button1.Text == "Insert Check")
				{
					//CheckInserted = true;
					s.CheckInserted = true;
					button1.Text = "Remove Check";
				}
				else
				{
					//CheckInserted = false;
					s.CheckInserted = false;
					button1.Text = "Insert Check";
				}
			}
		}

        private void button3_Click(object sender, System.EventArgs e)
        {
            CheckScannerSimulator s = ServiceObjectReference.Target as CheckScannerSimulator;
            if (s != null)
            {
                try
                {
                    s.WorkingStorage = new Bitmap(textBox1.Text);
                    if (s.WorkingStorage == null)
                    {
                        MessageBox.Show(this, string.Format("Unable to load image file: {0}", textBox1.Text), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show(this, "Image file loaded", this.Text);
                    }

                }
                catch (ArgumentException)
                {
                    MessageBox.Show(this, string.Format("Unable to load image file: {0}", textBox1.Text), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

	}

	#endregion


	#region CheckScannerSimulator Class
	[ServiceObjectAttribute(DeviceType.CheckScanner, 
		 "Microsoft CheckScanner Simulator",
        "Microsoft Check Scanner Simulator", 1, 12)]
	public class CheckScannerSimulator : CheckScannerBase
	{
		private CheckScannerSimulatorWindow Window;

		private string ImageDirectory;

				
		public CheckScannerSimulator()
		{
			// This is a non-Pnp device so we must set its device path here
			DevicePath = "Microsoft CheckScanner Simulator";
			Properties.DeviceDescription = "Microsoft CheckScanner Simulator";
			
			Properties.CapDefineCropArea = true;
			Properties.MaxCropAreas = 10;
			int [] QualityList = { 200, 400 };
			Properties.QualityList = QualityList;
			Properties.Quality = 200;

			Properties.CapStoreImageFiles = true;

			// create image storeage directory in temp
			ImageDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			ImageDirectory += @"\MSCheckScannerSimulatorData";

			if(!Directory.Exists(ImageDirectory))
				Directory.CreateDirectory(ImageDirectory);

		}

		~CheckScannerSimulator()
		{
			Dispose(false);
		}

		private Bitmap workingStorage;
		internal protected Bitmap WorkingStorage
		{
			get
			{
				return workingStorage;
			}
			set
			{
				workingStorage = value;
			}
		}

		private bool checkInserted;
		internal protected bool CheckInserted
		{
			get
			{
				return checkInserted;
			}
			set
			{
				checkInserted = value;
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
			SetStatisticValue(StatisticModelName, "Check Scanner Simulator");
			SetStatisticValue(StatisticMechanicalRevision, "1.0");
			SetStatisticValue(StatisticInterface, "Other");

			Window = new CheckScannerSimulatorWindow(this);

			// assume that we are dealing with MapMode.English (the base default) in order to set something reasonable in thousandths of an inch. 
			Properties.DocumentHeight = 12000;
			Properties.DocumentWidth = 4000;

		}

		protected override void	BeginInsertionImpl(int timeout)
		{
			Cursor old = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				DateTime stoptime;
				if (timeout == WaitForever)
					stoptime = DateTime.MaxValue;
				else
					stoptime = DateTime.Now.AddMilliseconds(timeout);

				while (DateTime.Now.CompareTo(stoptime) < 0 && CheckInserted == false)
				{
					Thread.Sleep(50);
				}

				if (CheckInserted == false)
					throw new PosControlException("Timeout occurred", ErrorCode.Timeout);
			}
			finally
			{
				Cursor.Current = old;
			}
		}
		protected override void	BeginRemovalImpl(int timeout)
		{
			Cursor old = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				DateTime stoptime;
				if (timeout == WaitForever)
					stoptime = DateTime.MaxValue;
				else
					stoptime = DateTime.Now.AddMilliseconds(timeout);
				
				while (DateTime.Now.CompareTo(stoptime) < 0 && CheckInserted == true)
				{
					Thread.Sleep(50);
				}

				if (CheckInserted == true)
					throw new PosControlException("Timeout occurred", ErrorCode.Timeout);
			}
			finally
			{
				Cursor.Current = old;
			}
		}
		protected override bool	EndInsertionImpl()
		{
			return CheckInserted;
		}
		protected override bool	EndRemovalImpl()
		{
			return !CheckInserted;
		}
		protected override Bitmap	ScanCheck()
		{
			return WorkingStorage;
		}

		protected override bool ClearImageImpl(CheckImageClear by)
		{
			string filter = "";
			if (by == CheckImageClear.FileId)
				filter = "*@" + FileId + "@*.bmp";
			else if (by == CheckImageClear.FileIndex)
				filter = FileIndex.ToString(CultureInfo.InvariantCulture) + "@*.bmp";
			else if (by == CheckImageClear.ImageTagData)
				filter = "*@" + ImageTagData + ".bmp";
			else if (by == CheckImageClear.All)
				filter = "*@*@*.bmp";

			string [] files = Directory.GetFiles(ImageDirectory, filter);

			if (files.Length == 0 && by != CheckImageClear.All)
				//throw new PosControlException("File not found with filter: " + filter, ErrorCode.Illegal, 0);
				return false;

			if (files.Length != 1 && by != CheckImageClear.All)
				throw new PosControlException("More than 1 file was found with filter: " + filter, ErrorCode.Failure, 0);

			foreach (string file in files)
			{
				File.Delete(ImageDirectory + @"\" + file);
			}

			return true;
		}


		protected override CheckScannerImage RetrieveMemoryImpl(CheckImageLocate by)
		{
			string filter = "";
			if (by == CheckImageLocate.FileId)
				filter = "*@" + FileId + "@*.bmp";
			else if (by == CheckImageLocate.FileIndex)
				filter = FileIndex.ToString(CultureInfo.InvariantCulture) + "@*.bmp";
			else if (by == CheckImageLocate.ImageTagData)
				filter = "*@" + ImageTagData + ".bmp";

			string [] files = Directory.GetFiles(ImageDirectory, filter);

			if (files.Length == 0)
				throw new PosControlException("File not found with filter: " + filter, ErrorCode.Illegal, 0);

			if (files.Length != 1)
				throw new PosControlException("More than 1 file was found with filter: " + filter, ErrorCode.Failure, 0);

			WorkingStorage = new Bitmap(files[0]);

			FileInfo f = new FileInfo(files[0]);
			string [] props = f.Name.Split("@.".ToCharArray());
			
			return new CheckScannerImage(WorkingStorage, props[1], Int32.Parse(props[0], CultureInfo.InvariantCulture), props[2]);
		}

		protected override void StoreImageImpl(Bitmap image)
		{
			// look for existing files with the same index, id or tag data
			string [] files = Directory.GetFiles(ImageDirectory, "*@*@*.bmp");
			foreach (string file in files)
			{
				FileInfo f = new FileInfo(file);
				string [] props = f.Name.Split("@.".ToCharArray());

				if (String.Compare(props[1], FileId, StringComparison.OrdinalIgnoreCase) == 0 ||
					props[0].Trim() == FileIndex.ToString(CultureInfo.InvariantCulture) ||
					(CapImageTagData && String.Compare(props[2], ImageTagData, StringComparison.OrdinalIgnoreCase) == 0))
				{
					throw new PosControlException("File already exists", ErrorCode.Exists, 0);
				}
			}
			
			// build file name
			string FileName = FileIndex.ToString(CultureInfo.InvariantCulture) + "@";
			if (FileId != null && FileId.Length > 0)
				FileName += FileId;
			FileName += "@";
			if (ImageTagData != null && ImageTagData.Length > 0)			
				FileName += ImageTagData;
			FileName += ".bmp";

			image.Save(ImageDirectory + @"\" + FileName);
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				if(disposing)
				{
					Logger.Info("CheckScannerSimulator", "Disposing class: " + this.ToString());
					// Release the managed resources you added in
					// this derived class here.
				}
				// Release the native unmanaged resources
				// Window needs to be treated as an unmanaged resource because
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
				// Call Dispose on your base class.
				base.Dispose(disposing);
			}
		}

	}
	
	#endregion
}
