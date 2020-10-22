// This is a part of the Microsoft POS for .NET SDK
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This sample source code is only intended as a 
// supplement to the POS for .NET SDK and related 
// electronic documentation provided with the library.


using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Resources;
using System.Runtime.InteropServices;
using System.Reflection;
using System.ComponentModel;
using System.Globalization;
using System.IO;
#if !CF_BUILD
using Microsoft.Win32.SafeHandles;
#endif

namespace Microsoft.PointOfService.ExampleServiceObjects
{
    public delegate void DataReadCallback(byte[] data);
    public delegate void ThreadExceptionCallback(Exception e);
    
    internal class HidReader : IDisposable
    {
        private bool disposed = false;
        private HidThread hThread;

        // This class holds a weak reference to a delegate.
        // We don't want to hold a strong reference to the delegate
        // because doing so will create a circular reference to the
        // calling class and potentially prevent the garbage collector
        // from being able to collect the calling class.  The drawback 
        // of this class is that it uses reflection so it will be slower
        // than directly caching the delegate.  In many cases this isn't a 
        // deal-breaker but users should be aware of this.
        private class WeakDelegate : WeakReference
    {
        Type type;
        string methodname;

#if CF_BUILD
		public WeakDelegate(Delegate callback)
			: base(callback)
		{
			methodname = callback.ToString();
			type = callback.GetType();
		}

#else
        ResourceManager rm;
		public WeakDelegate(Delegate callback)
            : base(callback.Target)
        {
            methodname = callback.Method.Name;
            type = callback.GetType();
            rm = new ResourceManager("Strings", Assembly.GetExecutingAssembly());
        }

        public override object Target
        {
            get
            {
                object target = base.Target as object;
                if (target == null)
                    return null;

                return (Delegate)Delegate.CreateDelegate(type, target, methodname);
            }
            set
            {
                Delegate callback = value as Delegate;

                if (callback == null) 
                    throw new ArgumentException(rm.GetString("IDS_VALUE_MUST_BE_DELEGATE"));

                base.Target = callback.Target;
                methodname = callback.Method.Name;
                type = callback.GetType();
            }
        }
#endif
	}
        
        private class HidThread
        {
            private ManualResetEvent ThreadTerminating, ThreadStarted;
            private ResourceManager rm;
            private string devicename, devicepath;
            private WeakDelegate wdcallback;
			private WeakDelegate wdexcallback;
#if !CF_BUILD
			private Thread ReadThread;
			private int InputReportByteLength, FeatureReportByteLength;
			private SafeFileHandle HidHandle;				// file handle for a Hid devices
            private int threadId;
#endif
			private object syncRoot = new object();

            public  HidThread(string deviceName, string devicePath, DataReadCallback callback, ThreadExceptionCallback exceptionCallback)
            {
                devicename = deviceName;
                devicepath = devicePath;
                wdcallback = new WeakDelegate(callback);
                wdexcallback = new WeakDelegate(exceptionCallback);
                
                // Initialize ResourceManager for loading localizable strings
                rm = new ResourceManager("Strings", Assembly.GetExecutingAssembly());
                
                // Create an event to signal that the thread is up and running
                ThreadStarted = new ManualResetEvent(false);

                // Create a new event to signal the thread to terminate
                ThreadTerminating = new ManualResetEvent(false);
            }

#if CF_BUILD
			public void StartReading()
			{
			}

			public void StopReading()
			{
			}
			public byte[] GetUSBProperty(int propId)
			{
				switch (propId)
				{
					case 0:
						return new byte[] { (byte)'r', (byte)'e', (byte)'v' };
					case 1:
						return new byte[] { (byte)'s', (byte)'e', (byte)'r', (byte)'n', (byte)'o' };
					case 2:
					default:
						return null;
				}
			}

			
			private class NativeMethods
            {
                private NativeMethods() { }

				internal const uint GENERIC_READ = 0x80000000;
				internal const uint GENERIC_WRITE = 0x40000000;
				internal const uint FILE_SHARE_READ = 0x00000001;
				internal const uint FILE_SHARE_WRITE = 0x00000002;
				internal const int OPEN_EXISTING = 3;
				internal const uint FILE_FLAG_OVERLAPPED = 0x40000000;
				internal const uint ERROR_IO_INCOMPLETE = 996;
				internal const uint ERROR_IO_PENDING = 997;

				[DllImport("coredll.dll", SetLastError=true)]
				private static extern UInt32 CreateFile(
					string lpFileName,
					UInt32 dwDesiredAccess,
					UInt32 dwSharedMode,
					IntPtr lpSecurityAttributes,
					UInt32 dwCreationDisposition,
					UInt32 dwFlagsAndAttributes,
					IntPtr hTemplateFile);

				[DllImport("coredll.dll", SetLastError=true)]
				[return: MarshalAs(UnmanagedType.Bool)]
				private static extern bool ReadFile(
					UInt32 hFile,
					IntPtr Buffer,
					UInt32 nNumberOfBytesToRead,
					out UInt32 lpNumberOfBytesRead,
					UInt32 Overlapped);
			}
#else

            void AsyncCallback(IAsyncResult ar)
            {
            }

            public void ThreadMethod()
            {
                threadId = Thread.CurrentThread.ManagedThreadId;

                try
                {
                    // Signal the openning thread that we're up and running.
                    if (ThreadStarted != null)
                        ThreadStarted.Set();

                    using (FileStream fs = new FileStream(HidHandle, FileAccess.Read, InputReportByteLength, true))
                    {
                        byte[] buffer = new byte[InputReportByteLength];

                        while (true)
                        {
                           IAsyncResult res = fs.BeginRead(buffer, 0, InputReportByteLength, AsyncCallback, null);

                            // We need to wait for either IO to complete or the read to be signaled
                            WaitHandle[] IOCompleteOrThreadTerminating = { res.AsyncWaitHandle, ThreadTerminating };

                            // Wait for data or thread termination
                            if (1 == WaitHandle.WaitAny(IOCompleteOrThreadTerminating))
                                break;

                            
                            // Call endRead to get the # of bytes actually read.  This will throw an exception
                            // if the read was not successfull (i.e. the device was removed, etc).
                            int bytesRead = fs.EndRead(res);
                            Logger.Info(devicename, "read " + bytesRead.ToString(CultureInfo.InvariantCulture) + " bytes from device.");

                            // Make sure we got the correct # of bytes
                            if (bytesRead == InputReportByteLength)
                            {
                                // Get strong ref to callback delegate
                                DataReadCallback callback = wdcallback.Target as DataReadCallback;
                                if (callback == null)
                                    break;
                                
                                // report data to caller
                                callback(buffer);

                                callback = null;
                            }
                            else
                            {
                                // Unexpected data size - we'll thrown an exception for now.
                                // This may need to change for devices that report variable length data.
                                throw new PosControlException(rm.GetString("IDS_UNEXPECTED_NUMBER_BYTES"), ErrorCode.Failure);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    // We must eat this exception and marshal it back to the calling thread or else the 
                    // CLR will terminate the process
                    Logger.Error(devicename, "Exception occurred in HID read thread.", e);

					//if (e.Message.CompareTo("The device is not connected.\r\n") == 0)
					if (e is IOException)
					{
						lock (syncRoot)
						{
							if (null != HidHandle)
							{
								if (!HidHandle.IsClosed)
									HidHandle.Close();
								HidHandle.Dispose();
								HidHandle = null;
							}
						}
					}
					ThreadExceptionCallback excallback = wdexcallback.Target as ThreadExceptionCallback;
                    if (excallback != null)
                        excallback(e);  // report exception to caller
					excallback=null;
                }
            }

           

            public void StartReading()
            {
                IntPtr PtrToPreparsedData = IntPtr.Zero;

                try
                {
                    // close the device (OK to call if it's already closed)
                    StopReading();


                    lock (syncRoot)
                    {
                        // (Re)Open the device
                        HidHandle = NativeMethods.CreateFile(
                            devicepath,
                            NativeMethods.GENERIC_READ | NativeMethods.GENERIC_WRITE,
                            0,  // No sharing
                            IntPtr.Zero,
                            NativeMethods.OPEN_EXISTING,
                            NativeMethods.FILE_FLAG_OVERLAPPED,
                            IntPtr.Zero);
                        int LastErr = Marshal.GetLastWin32Error();
                        if (HidHandle.IsInvalid)
                        {
                            Logger.Error(devicename, "Error opening path: " + devicepath);
                            throw new Win32Exception(LastErr);
                        }

                        if (NativeMethods.HidD_GetPreparsedData(HidHandle, ref PtrToPreparsedData) == (byte)0)
                        {
                            Logger.Error(devicename, "Error reading HID preparsed data.");
                            throw new PosControlException(rm.GetString("IDS_DEVICE_COMMUNICATION_FAILURE"), ErrorCode.Failure);
                        }
                    }

                    NativeMethods.HIDP_CAPS DeviceCaps = new NativeMethods.HIDP_CAPS();
                    int retVal = NativeMethods.HidP_GetCaps(PtrToPreparsedData, ref DeviceCaps);
                    if (retVal < 0)
                    {
                        Logger.Error(devicename, "Error reading HID capabilities: " + retVal.ToString(CultureInfo.InvariantCulture));
                        throw new PosControlException(rm.GetString("IDS_DEVICE_COMMUNICATION_FAILURE"), ErrorCode.Failure);
                    }

                    InputReportByteLength = DeviceCaps.InputReportByteLength;
                    FeatureReportByteLength = DeviceCaps.FeatureReportByteLength;

                    Logger.Info(devicename, "InputReportByteLength = " + InputReportByteLength.ToString(CultureInfo.InvariantCulture));
                    Logger.Info(devicename, "FeatureReportByteLength = " + FeatureReportByteLength.ToString(CultureInfo.InvariantCulture));

                    // Reset events
                    ThreadTerminating.Reset();
                    ThreadStarted.Reset();

                    // start thread for getting input
                    ReadThread = new Thread(new ThreadStart(ThreadMethod));
                    ReadThread.Name = "HidThread: " + devicename;
                    ReadThread.IsBackground = true;
                    ReadThread.Start();

                    // If the thread doesn't start in 30 seconds throw an exception
                    if (!ThreadStarted.WaitOne(30000, false))
                    {
                        Logger.Error(devicename, "HidThread - thread failed to start in 30 seconds.");
                        throw new PosControlException(rm.GetString("IDS_THREAD_FAILED_TO_START"), ErrorCode.Failure);
                    }

                    Logger.Info(devicename, "HidThread - thread started successfully.");
                }
                catch (Exception e)
                {
                    Logger.Error(devicename, "An exception occurred while attempting to open the device.", e);
                    StopReading();
                    throw;
                }
                finally
                {
                    // Free Preparsed Data
                    if (PtrToPreparsedData != IntPtr.Zero)
                        NativeMethods.HidD_FreePreparsedData(PtrToPreparsedData);
                }
            }

            public byte[] GetUSBProperty(int propId)
            {
				lock (syncRoot)
				{
					if (null == HidHandle)
                    return null;

					byte[] FtrRptTrxBfr = new byte[FeatureReportByteLength];

					FtrRptTrxBfr[1] = (byte)0;			// 0 = get
					FtrRptTrxBfr[2] = (byte)1;			// data size = 1 byte
					FtrRptTrxBfr[3] = (byte)propId;	// property to fetch

					if (NativeMethods.HidD_SetFeature(HidHandle, FtrRptTrxBfr, FeatureReportByteLength) != (byte)0)
					{
						byte[] FtrRptRcvBfr = new byte[FeatureReportByteLength];
						if ((int)NativeMethods.HidD_GetFeature(HidHandle, FtrRptRcvBfr, FeatureReportByteLength) > 0 && (int)FtrRptRcvBfr[1] == 0)
						{
							byte[] result = new byte[(int)FtrRptRcvBfr[2]];
							for (int i = 0; i < (int)FtrRptRcvBfr[2]; i++)
								result[i] = FtrRptRcvBfr[i + 3];

							return result;
						}
					}
				}

                Logger.Warn(devicename, "Unable to read USB property: " + propId.ToString(CultureInfo.InvariantCulture));

                return null;
            }
            private void StopReading(object state)
            {
                StopReading();
            }

            public void StopReading()
            {
                if (Thread.CurrentThread.ManagedThreadId == threadId)
                {
					if (null != ReadThread)
					{
                        ThreadTerminating.Set(); // signal thread to exit
                        ThreadPool.QueueUserWorkItem(new WaitCallback(StopReading));
                    }
                }
                else
                {
                    // Kill thread
					if (null != ReadThread)
					{
                        ThreadTerminating.Set(); // signal thread to exit
                        ReadThread.Join();  // wait for thread to terminate
                        ReadThread = null;
                    }

					lock (syncRoot)
					{
						// close device
						if (null != HidHandle)
						{
                			if (!HidHandle.IsClosed)
								HidHandle.Close();
							HidHandle.Dispose();
							HidHandle = null;
						}
					}
                }
            }

            #region Win32 Interop

            private class NativeMethods
            {
                private NativeMethods() { }

                [DllImport("kernel32.dll", SetLastError = true)]
                internal static extern SafeFileHandle CreateFile(
                    string lpFileName,							// file name
                    uint dwDesiredAccess,						// access mode
                    uint dwShareMode,							// share mode
                    IntPtr lpSecurityAttributes,				// SD
                    uint dwCreationDisposition,					// how to create
                    uint dwFlagsAndAttributes,					// file attributes
                    IntPtr hTemplateFile						// handle to template file
                    );

              
                [DllImport("hid.dll", SetLastError = true)]
                internal static extern byte HidD_GetPreparsedData(
                    SafeFileHandle hObject,								// IN HANDLE  HidDeviceObject,
                    ref IntPtr pPHIDP_PREPARSED_DATA);					// OUT PHIDP_PREPARSED_DATA  *PreparsedData

                [DllImport("hid.dll", SetLastError = true)]
                internal static extern byte HidD_FreePreparsedData(
                    IntPtr pPHIDP_PREPARSED_DATA);					// IN PHIDP_PREPARSED_DATA  PreparsedData

                [DllImport("hid.dll", SetLastError = true)]
                internal static extern int HidP_GetCaps(
                    IntPtr pPHIDP_PREPARSED_DATA,						// IN PHIDP_PREPARSED_DATA  PreparsedData,
                    ref HIDP_CAPS myPHIDP_CAPS);						// OUT PHIDP_CAPS  Capabilities

                [DllImport("hid.dll", SetLastError = true)]
                internal static extern byte HidD_SetFeature(
                    SafeFileHandle HidDeviceObject,
                    byte[] ReportBuffer,
                    int ReportBufferLength);

                [DllImport("hid.dll", SetLastError = true)]
                internal static extern byte HidD_GetFeature(
                    SafeFileHandle HidDeviceObject,
                    byte[] ReportBuffer,
                    int ReportBufferLength
                    );

                [StructLayout(LayoutKind.Sequential)]
                internal struct HIDP_CAPS
                {
                    public System.UInt16 Usage;					// USHORT
                    public System.UInt16 UsagePage;				// USHORT
                    public System.UInt16 InputReportByteLength;
                    public System.UInt16 OutputReportByteLength;
                    public System.UInt16 FeatureReportByteLength;
                    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
                    public System.UInt16[] Reserved;				// USHORT  Reserved[17];			
                    public System.UInt16 NumberLinkCollectionNodes;
                    public System.UInt16 NumberInputButtonCaps;
                    public System.UInt16 NumberInputValueCaps;
                    public System.UInt16 NumberInputDataIndices;
                    public System.UInt16 NumberOutputButtonCaps;
                    public System.UInt16 NumberOutputValueCaps;
                    public System.UInt16 NumberOutputDataIndices;
                    public System.UInt16 NumberFeatureButtonCaps;
                    public System.UInt16 NumberFeatureValueCaps;
                    public System.UInt16 NumberFeatureDataIndices;
                }

                internal const uint GENERIC_READ = 0x80000000;
                internal const uint GENERIC_WRITE = 0x40000000;
                internal const uint FILE_SHARE_READ = 0x00000001;
                internal const uint FILE_SHARE_WRITE = 0x00000002;
                internal const int OPEN_EXISTING = 3;
                internal const uint FILE_FLAG_OVERLAPPED = 0x40000000;
				//internal const uint ERROR_IO_INCOMPLETE = 996;
				//internal const uint ERROR_IO_PENDING = 997;
				//internal const uint ERROR_DEVICE_NOT_CONNECTED = 1167;
			}


            #endregion
#endif

		}

        public event ThreadExceptionEventHandler ThreadExceptionEvent;
        public delegate void ThreadExceptionEventHandler(object sender, Exception e);

        public HidReader(string deviceName, string devicePath, DataReadCallback callback)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");

            // Create an instance of HidThread that will manage async reading from the device
            hThread = new HidThread(deviceName, devicePath, callback, OnThreadException);
        }

        private void OnThreadException(Exception e)
        {
            if (ThreadExceptionEvent != null)
                ThreadExceptionEvent(this, e);
        }

        ~HidReader()
        {
            Dispose(false);
        }


        public void OpenDevice()
        {
            if (disposed)
                throw new ObjectDisposedException("HidReader");

            hThread.StartReading();
        }

        public void CloseDevice()
        {
            if (!disposed)
            {
                hThread.StopReading();
            }
        }

        public byte[] GetUSBProperty(int propId)
        {
            if (disposed)
                throw new ObjectDisposedException("HidReader");

            return hThread.GetUSBProperty(propId);
        }

        #region IDisposable Members
                
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                CloseDevice();
                hThread = null;
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }

	
}
