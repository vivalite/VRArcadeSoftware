// This is a part of the Microsoft POS for .NET SDK
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This sample source code is only intended as a 
// supplement to the POS for .NET SDK and related 
// electronic documentation provided with the library.

using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.PointOfService.BaseServiceObjects;
using System.Threading;

namespace Microsoft.PointOfService.DeviceSimulators
{
	#region LineDisplaySimulatorWindow Class
	internal class LineDisplaySimulatorWindow : SimulatorBase
	{
		internal class Cell : System.Windows.Forms.Control
		{
			private Microsoft.PointOfService.BaseServiceObjects.Cell data = null;
			private int CellWidth = 0;
			private int CellHeight = 0;
        	private Font f = null;
			private bool iscursor = false;
	
			public bool IsCursor
			{
				get { return iscursor; }
				set 
				{
					if (value != iscursor)
					{
						iscursor = value; 
						Graphics g = CreateGraphics();
						RedrawCell(g);
						g.Dispose();
					}
				}
			}
			public object Data
			{
				get 
				{
					if (data == null)
						return null;

					if (data.Type == CellType.Character)
						return data.Character;
					else
						return data.PixelData;
				}
			}

			public Cell(int x, int y, int height, int width, int cellHeight, int cellWidth)
			{
				this.Top = x;
				this.Left = y;
				this.Width = width;
				this.Height = height;
				this.CellWidth = cellWidth;
				this.CellHeight = cellHeight;
				f = new Font("Courier New", Height-2, System.Drawing.GraphicsUnit.Pixel);
			}

			protected override void OnPaint(PaintEventArgs pea)
			{
				RedrawCell(pea.Graphics);
			}
			
			private bool BlinkOn = true;
			public void Blink(bool blinkOn)
			{
				if (data != null && (data.Attribute & DisplayTextMode.Blink) > 0)
				{
					BlinkOn = blinkOn;
					Refresh();
				}
			}
			
			private void RedrawCell(Graphics g)
			{
				Pen pen = Pens.White;
				Brush brush = Brushes.White;
				lock (this)
				{
					if (data == null || data.Type == CellType.Empty)
					{
						g.Clear(Color.Black);
						g.DrawRectangle(Pens.Gray, 0, 0, Width, Height);
					}
					else
					{
						if ((data.Attribute & DisplayTextMode.Reverse) > 0)
						{
							pen = Pens.Black;
							brush = Brushes.Black;
							g.Clear(Color.White);
						}
						else
						{
							g.Clear(Color.Black);
						}
						
						g.DrawRectangle(Pens.Gray, 0, 0, Width, Height);
						

						if (BlinkOn || ((data.Attribute & DisplayTextMode.Blink) == 0))
						{
							if (data.Type == CellType.Bitmap || data.Type == CellType.Glyph)
							{
								float scalex = (float) Height / (float) CellHeight;
								float scaley = (float) Width / (float) CellWidth;

								int CurrentByte = data.PixelData.Length - 1;
								int CurrentBitMask = 1;
								byte [] pixelData = data.PixelData;
				
								for (int row=CellHeight-1; row>=0; row--)
								{
									for (int col=CellWidth-1; col>=0; col--)
									{
										if ((pixelData[CurrentByte] & CurrentBitMask) > 0)
											g.FillRectangle(brush, col*scaley, row*scalex, scaley, scalex);

										CurrentBitMask = CurrentBitMask << 1;
										if (CurrentBitMask > 128)
										{
											CurrentBitMask = 1;
											CurrentByte--;
										}
									}
									if (CurrentBitMask > 1)
									{
										CurrentBitMask = 1;
										CurrentByte--;
									}
								}
							}
							else
							{
								g.DrawString(((char)data.Character).ToString(), f, brush, 0, 0);
							}
						}
					}

					if (IsCursor)
						g.DrawLine(pen, 3, Height - 2, Width - 3, Height - 2);
				}

			}


			public void Draw(Microsoft.PointOfService.BaseServiceObjects.Cell cell, bool blinkOn)
			{
				data = cell;
				BlinkOn = blinkOn;
				Graphics g = CreateGraphics();
				RedrawCell(g);
				g.Dispose();
			}
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public LineDisplaySimulatorWindow(LineDisplaySimulator serviceObject) : base(serviceObject)
		{
			Invoke(new MethodDelegate(InitializeComponent));
		}
		
		internal Cell[,] Display = null; 
		public void DrawLineDisplay(int rows, int columns, int StartX, int StartY, int CellHeight, int CellWidth, int PixelsY, int PixelsX)
		{
			if (InvokeRequired)
			{
				object [] args = new object[8];
				args[0] = rows;
				args[1] = columns;
				args[2] = StartX;
				args[3] = StartY;
				args[4] = CellHeight;
				args[5] = CellWidth;
				args[6] = PixelsY;
				args[7] = PixelsX;

				// Invoke will marshal this call so it is made on the main thread for the simulator window
				// If we don't do this an exception will occur because this function call creates child windows
				// which must be done on the same thread as the parent window.
				Invoke(new DrawLineDisplayInternalDelegate(DrawLineDisplayInternal), args);
			}
			else
			{
				DrawLineDisplayInternal(rows, columns, StartX, StartY, CellHeight, CellWidth, PixelsY, PixelsX);
			}
		}

		

		private delegate void DrawLineDisplayInternalDelegate(int rows, int columns, int StartX, int StartY, int CellHeight, int CellWidth, int PixelsY, int PixelsX);

		public void DrawLineDisplayInternal(int rows, int columns, int StartX, int StartY, int CellHeight, int CellWidth, int PixelsY, int PixelsX)
		{
			Display = new Cell[rows, columns];
			this.SuspendLayout();

			for (int i = Controls.Count-1; i>=0; i--)
			{
				if (Controls[i] is Cell)
				{
					Controls.RemoveAt(i);
				}
			}

			for (int x=0; x<rows; x++)
			{
				for (int y=0; y<columns; y++)
				{
					Display[x,y] = new Cell(StartX + CellHeight*x, StartY + CellWidth*y, CellHeight, CellWidth, PixelsY, PixelsX);
					this.Controls.Add(this.Display[x,y]);
				}
			}
			this.ResumeLayout(true);
		}

		public void Blink(bool blinkOn)
		{
			for (int i = 0; i<Display.GetLength(0); i++)
				for (int j = 0; j<Display.GetLength(1); j++)
					Display[i,j].Blink(blinkOn);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(LineDisplaySimulatorWindow));
			// 
			// LineDisplaySimulatorWindow
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.ControlBox = false;
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "LineDisplaySimulatorWindow";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");

		}
		#endregion
		
	}


	
	#endregion
	
	#region LineDisplaySimulatorSimulator Class
	[ServiceObjectAttribute(DeviceType.LineDisplay, 
		 "Microsoft LineDisplay Simulator",
        "Microsoft Line Display Simulator", 1, 12)]
	public class LineDisplaySimulator : LineDisplayBase
	{
	
		private int [] DisplayHeights = {2, 10, 5, 2, 20, 15, 5, 25, 15, 43, 5, 4, 20, 7, 57};
		private int [] DisplayWidths = {20, 20, 15, 10, 15, 20, 20, 30, 25, 80, 32, 32, 30, 20, 72};
		private const int StartX = 20;
		private const int StartY = 20;
		private const int CellHeightOnForm = 25;
		private const int CellWidthOnForm = 25;
		private const int PosCellHeight = 9;
		private const int PosCellWidth = 9;
		private LineDisplaySimulatorWindow Window;
		private LineDisplayScreenMode [] ScreenModes = null;
		private bool blinkon = false;
		private BlinkTimerClass bt;
		
		public LineDisplaySimulator()
		{
			// This is a non-Pnp device so we must set its device path here
			DevicePath = "Microsoft LineDisplay Simulator";
			Properties.DeviceDescription = "Microsoft LineDisplay Simulator";
			
			// Custom Glyphs are supported
			Properties.CapCustomGlyph = true;

			// Bitmaps are supported
			Properties.CapBitmap = true;

			// Blinking is supported
			Properties.CapBlink = DisplayBlink.Each;
			Properties.CapBlinkRate = true;

			// Reverse video supported
			Properties.CapReverse = DisplayReverse.Each;
            			
			// Underline or no cursor supported
			Properties.CapCursorType = DisplayCursors.Underline;
			
			// Sign up for events
			ScreenModeChangedEvent += new ScreenModeChangedEventHandler(LineDisplaySimulator_ScreenModeChangedEvent);
			CurrentWindowChangedEvent += new CurrentWindowChangedEventHandler(LineDisplaySimulator_CurrentWindowChangedEvent);
			BlinkRateChangedEvent += new BlinkRateChangedEventHandler(LineDisplaySimulator_BlinkRateChangedEvent);
			CursorTypeChangedEvent += new CursorTypeChangedEventHandler(LineDisplaySimulator_CursorTypeChangedEvent);
		}

		~LineDisplaySimulator()
		{
			Dispose(false);
		}

		
		protected override LineDisplayScreenMode[] LineDisplayScreenModes
		{
			get
			{
				if (ScreenModes == null)
				{
					ScreenModes = new LineDisplayScreenMode[DisplayWidths.Length];
					for (int i=0; i<DisplayWidths.Length; i++)
						ScreenModes[i] = new LineDisplayScreenMode(DisplayWidths[i], DisplayHeights[i], PosCellWidth, PosCellHeight);
				}

				return ScreenModes;
			}
		}

		protected object GetCurrentDisplay()
		{
			int rows = Window.Display.GetLength(0);
			int columns = Window.Display.GetLength(1);

			object [] data = new object[rows*columns];

			int k=0;
			for (int x=0; x<rows; x++)
			{
				for (int y=0; y<columns; y++)
				{
					data[k++] = Window.Display[x,y].Data;
				}
			}

			return data;
		}

		private int GetScreenModeIndex()
		{
			int result = Properties.ScreenMode;

			// Index 0 designates the default, otherwise ScreenMode is 1-based so we need to decrement it
			if (result > 0)
				result--;

			return result;
		}
				
		
		private void DrawLineDisplay(int NewScreenMode)
		{
			int DisplayWidth = Properties.ScreenModeList[NewScreenMode].Columns;
			int DisplayHeight = Properties.ScreenModeList[NewScreenMode].Rows;

			PixelsX = Properties.MaximumX/Properties.DeviceColumns;
			PixelsY = Properties.MaximumY/Properties.DeviceRows;

			Window.DrawLineDisplay(DisplayHeight, DisplayWidth, StartX, StartY, CellHeightOnForm, CellWidthOnForm, PixelsY, PixelsX);
			UpdateCursor();
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
			SetStatisticValue(StatisticModelName, "LineDisplay Simulator");
			SetStatisticValue(StatisticMechanicalRevision, "1.0");
			SetStatisticValue(StatisticInterface, "Other");

			// show simulation window
			Window = new LineDisplaySimulatorWindow(this);
			
			Properties.BlinkRate = 1000;

			DrawLineDisplay(GetScreenModeIndex());

			// Create a timer for blinking
			bt = new BlinkTimerClass(this);
		}

		private class BlinkTimerClass : IDisposable
		{
			private WeakReference wr;
			private System.Threading.Timer blinkTimer = null;

			public BlinkTimerClass(LineDisplaySimulator sim)
			{
				wr = new WeakReference(sim);
				blinkTimer = 	new System.Threading.Timer(new TimerCallback(BlinkCallback), null, Timeout.Infinite, Timeout.Infinite);
			}

			private void		BlinkCallback(object state)
			{
				try
				{
					LineDisplaySimulator sim = wr.Target as LineDisplaySimulator;
					if (sim != null)
					{
						if (sim.State != ControlState.Closed && sim.DeviceEnabled)
						{
							// toggle the BlinkOn variable and update the device
							sim.blinkon = !sim.blinkon;

							sim.Window.Blink(sim.blinkon);
						}
					}
				}
				catch
				{
					// Eat all exceptions here because the timer may get called while the device
					// is shutting down or when ScreenMode is changing and the simulator window is
					// be destroyed and recreated.
				}
			}
			

			public void Change(int timerBlinkRate)
			{
				blinkTimer.Change(0, timerBlinkRate);
			}

			#region IDisposable Members

			private bool disposed = false;
			protected void Dispose(bool disposing)
			{
				// Check to see if Dispose has already been called.
				if(!disposed)
				{
					this.disposed = true;        

					// If disposing equals true, dispose all managed 
					// and unmanaged resources.
					if (disposing)
					{
						// Dispose managed resources.
						if (blinkTimer != null)
						{
							blinkTimer.Dispose();
							blinkTimer = null;
						}
					}
					// Release unmanaged resources. 
				}
			}
			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}

			#endregion
		}
		public override bool DeviceEnabled
		{
			// Device State checking done in base class
			get { return base.DeviceEnabled;}
			set 
			{
				if (base.DeviceEnabled != value)
				{
					int TimerBlinkRate = Timeout.Infinite;

					if (value)
						TimerBlinkRate = BlinkRate == 0 ? Timeout.Infinite : BlinkRate < 50 ? 50 : BlinkRate;

					bt.Change(TimerBlinkRate);
				}
				base.DeviceEnabled = value;
			}

		}

		private int PixelsX;
		private int PixelsY;
		private int LastCursorRow = 0;
		private int LastCursorColumn = 0;
		protected override void DisplayData(Cell [] cells)
		{
			foreach (Cell c in cells)
				Window.Display[c.Row,c.Column].Draw(c, blinkon);

			UpdateCursor();
			
		}

		private void UpdateCursor()
		{
			if (Window != null)
			{
				if (LastCursorRow < Window.Display.GetLength(0) && LastCursorColumn < Window.Display.GetLength(1))
					Window.Display[LastCursorRow, LastCursorColumn].IsCursor = false;

				if(CursorType != DisplayCursors.None && CursorVisible)
				{
					LastCursorRow = CursorDeviceRow;
					LastCursorColumn = CursorDeviceColumn;

					if (LastCursorRow < Window.Display.GetLength(0) && LastCursorColumn < Window.Display.GetLength(1))
						Window.Display[LastCursorRow, LastCursorColumn].IsCursor = true;
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing)
				{
					Logger.Info("LineDisplaySimulator", "Disposing class: " + this.ToString());

					if (bt != null)
					{
						bt.Dispose();
						bt = null;
					}
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
				base.Dispose(disposing);
			}
		}



		// Event handlers 
		private void LineDisplaySimulator_ScreenModeChangedEvent(object sender, EventArgs e)
		{
			DrawLineDisplay(GetScreenModeIndex());
		}

		private void LineDisplaySimulator_BlinkRateChangedEvent(object sender, EventArgs e)
		{
			if (bt != null && DeviceEnabled)
			{
				int TimerBlinkRate = BlinkRate == 0 ? Timeout.Infinite : BlinkRate < 50 ? 50 : BlinkRate;
				bt.Change(TimerBlinkRate);
			}
		}

		private void LineDisplaySimulator_CurrentWindowChangedEvent(object sender, EventArgs e)
		{
			UpdateCursor();
		}

		private void LineDisplaySimulator_CursorTypeChangedEvent(object sender, EventArgs e)
		{
			UpdateCursor();
		}
	}
	
	#endregion
}