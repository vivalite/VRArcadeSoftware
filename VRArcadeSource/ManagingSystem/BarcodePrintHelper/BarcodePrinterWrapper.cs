using Microsoft.PointOfService;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BarcodePrintHelper
{
    public sealed class BarcodePrinterWrapper : IDisposable
    {
        private static BarcodePrinterWrapper _instance = new BarcodePrinterWrapper();

        private PosPrinter m_Printer = null;
        public bool PrinterReady = false;

        public bool IsReleased { get; private set; }
        public void Release()
        {
            IsReleased = true;
            BarcodePrinterWrapper._instance = null;
        }


        public static BarcodePrinterWrapper Instance
        {
            get
            {
                if (_instance == null) _instance = new BarcodePrinterWrapper();
                return _instance;
            }
        }
        BarcodePrinterWrapper()
        {
            // Initialize.
            InitPrinter();
        }

        private void InitPrinter()
        {
            string strLogicalName = "PosPrinter";
            try
            {
                //Create PosExplorer
                PosExplorer posExplorer = new PosExplorer();

                DeviceInfo deviceInfo = null;

                try
                {
                    deviceInfo = posExplorer.GetDevice(DeviceType.PosPrinter, strLogicalName);
                    m_Printer = (PosPrinter)posExplorer.CreateInstance(deviceInfo);
                }
                catch (Exception)
                {
                    PrinterReady = false;
                    return;
                }

                //Open the device
                m_Printer.Open();

                //Get the exclusive control right for the opened device.
                //Then the device is disable from other application.
                m_Printer.Claim(1000);

                //Enable the device.
                m_Printer.DeviceEnabled = true;

                m_Printer.RecLetterQuality = false;

                m_Printer.MapMode = MapMode.Metric;

                PrinterReady = true;
            }
            catch (PosControlException)
            {
                PrinterReady = false;
            }
        }

        public void Dispose()
        {
            if (m_Printer != null)
            {
                try
                {
                    //Cancel the device
                    m_Printer.DeviceEnabled = false;

                    //Release the device exclusive control right.
                    m_Printer.Release();

                }
                catch (PosControlException)
                {
                }
                finally
                {
                    //Finish using the device.
                    m_Printer.Close();
                }
            }
            Release();
        }

        private String MakePrintString(int iLineChars, String strBuf, String strPrice)
        {
            int iSpaces = 0;
            String tab = "";
            try
            {
                iSpaces = iLineChars - (strBuf.Length + strPrice.Length);
                for (int j = 0; j < iSpaces; j++)
                {
                    tab += " ";
                }
            }
            catch (Exception)
            {
            }
            return strBuf + tab + strPrice;
        }

        public void PrintTest()
        {
            m_Printer.PrintBarCode(PrinterStation.Receipt, "{BpoJ2Kav5gUmX6+m/9zTQSQ", BarCodeSymbology.Code128, 2400,
                       m_Printer.RecLineWidth, PosPrinter.PrinterBarCodeCenter, BarCodeTextPosition.None);

            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|fP");
        }

        public void PrintKeys(List<BarcodeItem> bItems)
        {
            //Batch processing mode
            m_Printer.TransactionPrint(PrinterStation.Receipt, PrinterTransactionControl.Transaction);

            foreach (BarcodeItem bItem in bItems)
            {
                PrintKey(bItem.GUID, bItem.KeyName, bItem.Minutes, false);
            }

            //print all the buffer data. and exit the batch processing mode.
            m_Printer.TransactionPrint(PrinterStation.Receipt, PrinterTransactionControl.Normal);
        }

        private void PrintKey(Guid guid, string keyName, int minutes, bool batch = true)
        {
            string strLine;
            string strDate = DateTime.Now.ToString("MMMM,dd,yyyy  HH:mm", new DateTimeFormatInfo());

            //Batch processing mode
            if (batch)
            {
                m_Printer.TransactionPrint(PrinterStation.Receipt, PrinterTransactionControl.Transaction);
            }

            string keyNametmp = keyName + (keyName == "KEY-START-TIMING" ? " MIN:" + minutes.ToString() : "");

            strLine = MakePrintString(m_Printer.RecLineChars, keyNametmp, "");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|bC" + "\u001b|2C" + "\u001b|cA" + strLine + "\n");

            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + strDate + "\n");

            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|200uF"); // 2mm

            strLine = MakePrintString(m_Printer.RecLineChars, "\u001b|cA" + "PLEASE KEEP THIS KEY SAFE!", "");
            m_Printer.PrintNormal(PrinterStation.Receipt, strLine + "\n");

            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|200uF"); // 2mm

            if (m_Printer.CapRecBarCode == true)
            {
                //Barcode printing
                Ascii85 a85 = new Ascii85();

                //m_Printer.PrintBarCode(PrinterStation.Receipt, "{B" + Convert.ToBase64String(guid.ToByteArray()).Replace("=", ""), BarCodeSymbology.Code128, 2000,
                m_Printer.PrintBarCode(PrinterStation.Receipt, "{B" + a85.Encode(guid.ToByteArray()), BarCodeSymbology.Code128, 2000,
                m_Printer.RecLineWidth, PosPrinter.PrinterBarCodeCenter, BarCodeTextPosition.None);
            }

            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|200uF"); // 2mm
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|fP");

            //print all the buffer data. and exit the batch processing mode.
            if (batch)
            {
                m_Printer.TransactionPrint(PrinterStation.Receipt, PrinterTransactionControl.Normal);
            }
        }

        public void PrintTickets(List<BarcodeItem> bItems)
        {
            //Batch processing mode
            m_Printer.TransactionPrint(PrinterStation.Receipt, PrinterTransactionControl.Transaction);

            foreach (BarcodeItem bItem in bItems)
            {
                PrintTicket(bItem.GUID, bItem.Minutes, bItem.CustomerName, bItem.BookingReference, false);
            }

            //print all the buffer data. and exit the batch processing mode.
            m_Printer.TransactionPrint(PrinterStation.Receipt, PrinterTransactionControl.Normal);
        }

        public bool PrintTicket(Guid guid, int minutes, string cusName, string bookingRef, bool batch = true)
        {
            try
            {
                string strLine;
                string strDate = DateTime.Now.ToString("MMMM,dd,yyyy  HH:mm", new DateTimeFormatInfo());



                //Batch processing mode
                if (batch)
                {
                    m_Printer.TransactionPrint(PrinterStation.Receipt, PrinterTransactionControl.Transaction);
                }

                strLine = MakePrintString(m_Printer.RecLineChars, "   Welcome to VR Arcade", "");
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|bC" + "\u001b|2C" + strLine + "\n");

                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + strDate + "\n");

                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|200uF"); // 2mm

                strLine = MakePrintString(m_Printer.RecLineChars, "Please take this ticket to one of the booth that", "");
                m_Printer.PrintNormal(PrinterStation.Receipt, strLine + "\n");

                strLine = MakePrintString(m_Printer.RecLineChars, "shows \"Ready\" on the screen and scan to activate", "");
                m_Printer.PrintNormal(PrinterStation.Receipt, strLine + "\n");

                strLine = MakePrintString(m_Printer.RecLineChars, "your session. Thank you!", "");
                m_Printer.PrintNormal(PrinterStation.Receipt, strLine + "\n");

                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|200uF"); // 2mm

                if (cusName.Length > 0)
                {
                    strLine = MakePrintString(m_Printer.RecLineChars, "Customer Name: " + cusName, "");
                    m_Printer.PrintNormal(PrinterStation.Receipt, strLine + "\n");
                }


                strLine = MakePrintString(m_Printer.RecLineChars, "Session Time: " + (minutes > 0 ? minutes.ToString() : "Unlimited") + " Minutes", "");
                m_Printer.PrintNormal(PrinterStation.Receipt, strLine + "\n");

                if (bookingRef.Length > 0)
                {
                    strLine = MakePrintString(m_Printer.RecLineChars, "Booking Reference: " + bookingRef, "");
                    m_Printer.PrintNormal(PrinterStation.Receipt, strLine + "\n");
                }

                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|200uF"); // 2mm

                if (m_Printer.CapRecBarCode == true)
                {
                    //Barcode printing
                    Ascii85 a85 = new Ascii85();

                    //m_Printer.PrintBarCode(PrinterStation.Receipt, "{B" + Convert.ToBase64String(guid.ToByteArray()).Replace("=", ""), BarCodeSymbology.Code128, 3000,
                    m_Printer.PrintBarCode(PrinterStation.Receipt, "{B" + a85.Encode(guid.ToByteArray()), BarCodeSymbology.Code128, 3000,
                        m_Printer.RecLineWidth, PosPrinter.PrinterBarCodeCenter, BarCodeTextPosition.None);
                }

                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|200uF"); // 2mm

                strLine = MakePrintString(m_Printer.RecLineChars, "Note: This ticket effective within 20 minutes", "");
                m_Printer.PrintNormal(PrinterStation.Receipt, strLine + "\n");

                strLine = MakePrintString(m_Printer.RecLineChars, "of issuring and can only activate one booth. If", "");
                m_Printer.PrintNormal(PrinterStation.Receipt, strLine + "\n");

                strLine = MakePrintString(m_Printer.RecLineChars, "you encounter any difficulty please let our", "");
                m_Printer.PrintNormal(PrinterStation.Receipt, strLine + "\n");

                strLine = MakePrintString(m_Printer.RecLineChars, "staff know.", "");
                m_Printer.PrintNormal(PrinterStation.Receipt, strLine + "\n");

                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|200uF"); // 2mm
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|fP");

                //print all the buffer data. and exit the batch processing mode.
                if (batch)
                {
                    m_Printer.TransactionPrint(PrinterStation.Receipt, PrinterTransactionControl.Normal);
                }

                return true;
            }
            catch (PosControlException)
            {
                return false;
            }


        }

    }

}
