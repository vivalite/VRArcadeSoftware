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
using System.Text;
using System.Globalization;
using System.Resources;
using System.Reflection;
using System.ComponentModel;
#if !CF_BUILD
using Microsoft.Win32.SafeHandles;
#endif

namespace Microsoft.PointOfService.ExampleServiceObjects
{

	#region ExampleMsr Class
	[ServiceObject(	DeviceType.Msr, 
					"ExampleMsr", 
					"Service object for Example MSR", 1, 12)]

	public class ExampleMsr : MsrBase
	{
		private HidReader hidReader;
		private const string PollingStatistic = "Polling Interval";
		private ResourceManager	rm;

		public ExampleMsr()
		{
			// Initialize ResourceManager for loading localizable strings
			rm = new ResourceManager("Strings",  Assembly.GetExecutingAssembly() );

			// Initialize device properties
			Properties.CapIso = true;
			Properties.CapTransmitSentinels = true;
			Properties.DeviceDescription = rm.GetString("IDS_MSR_DEVICE_DESCRIPTION");
		}


		// Finalizer
		~ExampleMsr()
		{
			Dispose(false);
		}

		
		// We must override dispose so we can close and release our reference 
		// to the ReadThread when the device is closed.  
		//
		// The Base/Basic class implementation of Close() calls the virtual
		// Dispose(bool) method so we don't need to override Close().
		protected override void Dispose(bool disposing)
		{
			try
			{
				//if (disposing)
				{
					// Release managed resources
					if (hidReader != null)
					{
                        hidReader.CloseDevice();
						hidReader.Dispose();
						hidReader = null;
					}
				}
			}
			finally
			{
				// Must call base class Dispose
				base.Dispose (disposing);
			}
		}

		protected override MsrFieldData ParseMsrFieldData(byte[] track1Data, byte[] track2Data, byte[] track3Data, byte[] track4Data, CardType cardType)
		{
			string Track1Data = ByteArrayToString(RemoveSentinels(track1Data, '%', '?'));
			string Track2Data = ByteArrayToString(RemoveSentinels(track2Data, ';', '?'));

			// Parse Iso data
			return MsrDataParser.ParseIsoData(Track1Data, Track2Data);
		}

		protected override MsrTrackData ParseMsrTrackData(byte[] track1Data, byte[] track2Data, byte[] track3Data, byte[] track4Data, CardType cardType)
		{
			MsrTrackData data = new MsrTrackData();

			if (TransmitSentinels)
			{
				// Raw data contains sentinels so just pass it through
				data.Track1Data = (byte[]) track1Data.Clone();
				data.Track2Data = (byte[]) track2Data.Clone();
				data.Track3Data = (byte[]) track3Data.Clone();
			}
			else
			{
				/// remove sentinels
				data.Track1Data = RemoveSentinels(track1Data, '%', '?');
				data.Track2Data = RemoveSentinels(track2Data, ';', '?');
				data.Track3Data = RemoveSentinels(track3Data, ';', '?');;
			}
			data.Track4Data = null;

			return data;
		}


		static private string ByteArrayToString(byte[] data)
		{
            if (data == null || data.Length == 0)
                return "";
            return ASCIIEncoding.ASCII.GetString(data, 0, data.Length);
		}

		static private byte[] RemoveSentinels(byte [] trackData, char startSentinel, char endSentinel)
		{
			if (trackData == null || trackData.Length == 0)
				return new byte[0];

			byte [] ReturnArray ;
			if (trackData[0] == Convert.ToByte(startSentinel) && trackData[trackData.Length-1] == Convert.ToByte(endSentinel))
			{
				ReturnArray = new byte[trackData.Length-2];
				for (int i=0; i<trackData.Length-2; i++)
					ReturnArray[i] = trackData[i+1];
			}
			else
			{
				ReturnArray = (byte[]) trackData.Clone();
			}

			return ReturnArray;
		}

		private string GetHardwareInfo(string name)
		{
            if (null != hidReader)
            {
                if (name == StatisticFirmwareRevision)
                    return ByteArrayToString(hidReader.GetUSBProperty(0));
                if (name == StatisticSerialNumber)
                    return ByteArrayToString(hidReader.GetUSBProperty(1));
                if (name == PollingStatistic)
                {
                    byte[] data = hidReader.GetUSBProperty(2);
                    if (data != null && data.Length == 1)
                        return ((int)data[0]).ToString(CultureInfo.CurrentCulture);
                }
            }
	
			return "";
		}


		internal void OnCardSwipe(byte[] data)
		{
			byte [] Track1Data = null;
			byte [] Track2Data = null;
			byte [] Track3Data = null;
			int Track1Status = 0, Track2Status = 0, Track3Status = 0;
			int Track1Length, Track2Length, Track3Length;
			int cardType;

			// Ignore input if we're in the Error state
			if (State == ControlState.Error)
			{
				Logger.Warn(DeviceName, "Input data ignored because device is in the Error state.");
				return;
			}

			// decode data
			if (data == null || data.Length != 338)
			{
				UnreadableCard(ErrorCode.Failure, 0);
				return;
			}
			
			cardType     = data[7];

			int i;
			if ((TracksToRead & MsrTracks.Track1) == MsrTracks.Track1)
			{
				Track1Status = data[1];
				Track1Length = data[4];
				Track1Data = new byte[Track1Length];
				for (i=0; i< Track1Length; i++)
					Track1Data[i] = data[i+8];
			}

			if ((TracksToRead & MsrTracks.Track2) == MsrTracks.Track2)
			{
				Track2Status = data[2];
				Track2Length = data[5];
				Track2Data = new byte[Track2Length];
				for (i=0; i< Track2Length; i++)
					Track2Data[i] = data[i+118];
			}

			if ((TracksToRead & MsrTracks.Track3) == MsrTracks.Track3)
			{
				Track3Status = data[3];
				Track3Length = data[6];
				Track3Data = new byte[Track3Length];
				for (i=0; i< Track3Length; i++)
					Track3Data[i] = data[i+228];
			}

			// If bit 0 is set an error occurred
			if ((Track1Status & 1) == 0 && (Track2Status & 1) == 0 && (Track3Status & 1) == 0)
			{
				// Success
                GoodRead(Track1Data, Track2Data, Track3Data, null, cardType == 0 ? 
                    Microsoft.PointOfService.BaseServiceObjects.CardType.Iso : 
                    Microsoft.PointOfService.BaseServiceObjects.CardType.Unknown);
				return;
			}
			else
			{
				// Failure decoding one or more tracks
				int ExtendedErrCode = 0;
				if (ErrorReportingType == MsrErrorReporting.Track)
				{
					byte b1, b2, b3;
					
					if ((Track1Status & 1) == 0)
						b1 = (byte) ExtendedErrorSuccess;
					else 
						b1 = (byte) ExtendedErrorFailure;

					if ((Track2Status & 1) == 0)
						b2 = (byte) ExtendedErrorSuccess;
					else 
						b2 = (byte) ExtendedErrorFailure;

					if ((Track3Status & 1) == 0)
						b3 = (byte) ExtendedErrorSuccess;
					else 
						b3 = (byte) ExtendedErrorFailure;

					ExtendedErrCode = b1 + (b2 << 8) + (b3 << 16);

					// Track-level error reporting should update the tracks that were read successfully
					FailedRead(Track1Data, Track2Data, Track3Data, null, cardType == 0 ?
                        Microsoft.PointOfService.BaseServiceObjects.CardType.Iso :
                        Microsoft.PointOfService.BaseServiceObjects.CardType.Unknown, ErrorCode.Extended, ExtendedErrCode);
				}
				else // card-level error reporting
				{
					// Card-level reporting does not update track data properties
					ExtendedErrCode = (int) ExtendedErrorFailure;
					UnreadableCard(ErrorCode.Failure, 0);
				}
			}
			return;
		}


		#region UPOS Members

		public override void Open()
		{
#if CF_BUILD
			DevicePath = "CF_Not_Implemented";
#endif
			// Device State checking done in base class
			base.Open();

			// Initialize the CheckHealthText property to an empty string
			checkhealthtext = "";

			// Set values for common statistics
			SetStatisticValue(StatisticManufacturerName, "Microsoft Corporation");
			SetStatisticValue(StatisticManufactureDate, "2004-10-23");
			SetStatisticValue(StatisticModelName, "Msr Simulator");
			SetStatisticValue(StatisticMechanicalRevision, "1.0");
			SetStatisticValue(StatisticInterface, "USB");

			// Create a new manufacturer statistic
			CreateStatistic(PollingStatistic, false, "milliseconds");

			// Set handlers for statistics stored in hardware
			SetStatisticHandlers(PollingStatistic, new GetStatistic(GetHardwareInfo), null);
			SetStatisticHandlers(StatisticSerialNumber, new GetStatistic(GetHardwareInfo), null);
			SetStatisticHandlers(StatisticFirmwareRevision, new GetStatistic(GetHardwareInfo), null);

			// Create instance of USB reader class
            hidReader = new HidReader(DeviceName, DevicePath, OnCardSwipe);
            hidReader.ThreadExceptionEvent += new HidReader.ThreadExceptionEventHandler(hidReader_ThreadExceptionEvent);
		}

        void hidReader_ThreadExceptionEvent(object sender, Exception e)
        {
            // BUGBUG: Handle thread exception here (Queue ErrorEvent?)
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
	
		#endregion
	}

	#endregion
	
}

