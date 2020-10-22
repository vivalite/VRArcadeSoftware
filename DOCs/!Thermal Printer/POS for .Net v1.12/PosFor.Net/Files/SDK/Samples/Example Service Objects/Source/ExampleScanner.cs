// This is a part of the Microsoft POS for .NET SDK
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This sample source code is only intended as a 
// supplement to the POS for .NET SDK and related 
// electronic documentation provided with the library.

using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.PointOfService;
using Microsoft.PointOfService.BaseServiceObjects;
using System.Resources;
using System.Reflection;
using System.ComponentModel;
using System.Globalization;
#if !CF_BUILD
using Microsoft.Win32.SafeHandles;
#endif

namespace Microsoft.PointOfService.ExampleServiceObjects
{
    #region ExampleScanner Class
	[ServiceObject(	DeviceType.Scanner, 
					"Example Scanner",
                   "Service object for Example scanner", 1, 12)]
	public class ExampleScanner : ScannerBase
	{
		private HidReader  hidReader;
		private ResourceManager	rm;

		public ExampleScanner()
		{
			// Initialize ResourceManager for loading localizable strings
			rm = new ResourceManager("Strings",  Assembly.GetExecutingAssembly() );

			// Initialize device properties
			Properties.DeviceDescription = rm.GetString("IDS_SCANNER_DEVICE_DESCRIPTION");
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
			SetStatisticValue(StatisticModelName, "Scanner Simulator");
			SetStatisticValue(StatisticMechanicalRevision, "1.0");
			SetStatisticValue(StatisticInterface, "USB");

			// Create instance of USB reader class
            hidReader = new HidReader(DeviceName, DevicePath, OnDataScanned);
            hidReader.ThreadExceptionEvent += new HidReader.ThreadExceptionEventHandler(hidReader_ThreadExceptionEvent);
		}

        void hidReader_ThreadExceptionEvent(object sender, Exception e)
        {
            // BUGBUG: Handle thread exception here
        }

		public override bool DeviceEnabled
		{
			// Device State checking done in base class
			get { return base.DeviceEnabled; }
			set 
			{
				if (value != base.DeviceEnabled)
				{
					// Call base class first because it will handle cases such as the
					// device isn't claimed etc.
					base.DeviceEnabled = value;

					// Start/Stop reading from the device
                    if (value == false)
                        hidReader.CloseDevice();
                    else
                    {
                        try
                        {
                            hidReader.OpenDevice();
                        }
                        catch (Exception e)
                        {
                            // disable device
                            base.DeviceEnabled = false;

                            // rethrow PosControlExceptions
                            if (e is PosControlException)
                                throw;

                            // Wrap other exceptions in PosControlExceptions
                            throw new PosControlException(rm.GetString("IDS_UNABLE_TO_ENABLE_DEVICE"), ErrorCode.Failure, e);
                        }
                    }
				}
			}
		}

		internal void OnDataScanned(byte[] data)
		{
			// Ignore input if we're in the Error state
			if (State == ControlState.Error)
			{
				Logger.Warn(DeviceName, "Input data ignored because device is in the Error state.");
				return;
			}

			if ((int) data[1] < 5)
			{
				FailedScan();
			}
			else
			{
				byte [] b = new byte[(int)data[1]+1];
				for (int i=0; i<=(int) data[1]; i++)
					b[i] = data[i];

				GoodScan(b);
			}
		}

		static private BarCodeSymbology GetSymbology(byte b1, byte b2, byte b3)
		{
			if (b1 == 0 && b3 == 11)
			{
				switch (b2)
				{
					case 10:
						return BarCodeSymbology.Code39;
					case 13:
						return BarCodeSymbology.Itf;
					case 14:
						return BarCodeSymbology.Codabar;
					case 24:
						return BarCodeSymbology.Code128;
					case 25:
						return BarCodeSymbology.Code93;
					case 37:
						return BarCodeSymbology.Ean128;
					case 255:
                        return BarCodeSymbology.Gs1DataBar;
					default:
						break;
				}
					
			}
			else if (b2 == 0 && b3 == 0)
			{
				switch (b1)
				{
					case  13:
						return BarCodeSymbology.Upca;
					case 22:
						return BarCodeSymbology.EanJan13;
					case 12:
						return BarCodeSymbology.EanJan8;
					default:
						break;
				}
			}

			return BarCodeSymbology.Other;

		}

		override protected byte[] DecodeScanDataLabel(byte [] scanData)
		{
			int i;
			int len = 0;
			
			// Get length of label data
			for(i = 5; i < (int)scanData[1] && (int) scanData[i] > 31; i++)
				len++;

			// Copy label data into buffer
			byte[] label = new byte[len];
			len=0;
			for(i = 5; i < (int)scanData[1] && (int) scanData[i] > 31; i++)
				label[len++] = scanData[i];

			return label;
		}

		override protected BarCodeSymbology DecodeScanDataType(byte [] scanData)
		{
			int i;
			for(i = 5; i < (int)scanData[1] && (int) scanData[i] > 31; i++){}
			
			// last 3 (or 1) bytes indicate symbology
			if (i+2 <= (int) ScanData[1])
				return GetSymbology(ScanData[i], ScanData[i+1], ScanData[i+2]);
			else
				return GetSymbology(ScanData[i], 0, 0);
		}
	}

	#endregion
}