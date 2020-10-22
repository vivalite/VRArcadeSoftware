using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.PointOfService;


namespace TestApplication
{
    public partial class PosPrinterScreen : TestApplication.DeviceScreenBase
    {
        PosPrinter _printer;

        public PosPrinterScreen()
        {
            InitializeComponent();

            CurrentStation = PrinterStation.Receipt;
            CurrentStationCB.Text = "Receipt";

            CurrentRotation = PrintRotation.Normal;
            Rotation.Text = "Normal";

            CurrentTransaction = PrinterTransactionControl.Normal;
            TransactionCB.Text = "Normal";

            cbSymbology.Items.Clear();
            cbSymbology.Items.AddRange(Enum.GetNames(typeof(BarCodeSymbology)));

            cbTextPosition.Items.Clear();
            cbTextPosition.Items.AddRange(Enum.GetNames(typeof(BarCodeTextPosition)));
        }

        public override void SetOpened(bool opened)
        {
            if (_printer == null)
            {
                _printer = (PosPrinter)PosCommon;
            }
        }

        public override void SetDeviceClaimed(bool claimed)
        {
            if (claimed)
            {
                checkBox1.Checked = _printer.FlagWhenIdle;
            }
        }


        #region PosPrinter

        private PrinterStation CurrentStation = PrinterStation.Receipt;
        private PrintRotation CurrentRotation = PrintRotation.Normal;
        private PrinterTransactionControl CurrentTransaction = PrinterTransactionControl.Normal;

        private void btnValidateData_Click(object sender, System.EventArgs e)
        {
            try
            {
                // replace ESC with Char(27) and add a CRLF to the end
                string text = TextToPrint.Text.Replace("ESC", ((char)27).ToString()) + "\x1B|1lF";
                _printer.ValidateData(CurrentStation, text);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void PrintButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                // replace ESC with Char(27) and add a CRLF to the end
                string text = TextToPrint.Text.Replace("ESC", ((char)27).ToString()) + "\x1B|1lF";
                _printer.PrintNormal(CurrentStation, text);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnPrintBarcode_Click(object sender, System.EventArgs e)
        {
            try
            {
                int alignment;
                if (cbAlignment.Text == "Left")
                    alignment = PosPrinter.PrinterBarCodeLeft;
                else if (cbAlignment.Text == "Center")
                    alignment = PosPrinter.PrinterBarCodeCenter;
                else if (cbAlignment.Text == "Right")
                    alignment = PosPrinter.PrinterBarCodeRight;
                else
                    alignment = int.Parse(cbAlignment.Text);

                _printer.PrintBarCode(CurrentStation, TextToPrint.Text, (BarCodeSymbology)Enum.Parse(typeof(BarCodeSymbology), cbSymbology.Text), int.Parse(tbHeight.Text), int.Parse(tbWidth.Text), alignment, (BarCodeTextPosition)Enum.Parse(typeof(BarCodeTextPosition), cbTextPosition.Text));
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnPrintBitmap_Click(object sender, System.EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Image files|*.bmp;*.gif;*.jpg";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    int alignment;
                    if (cbAlignment.Text == "Left")
                        alignment = PosPrinter.PrinterBarCodeLeft;
                    else if (cbAlignment.Text == "Center")
                        alignment = PosPrinter.PrinterBarCodeCenter;
                    else if (cbAlignment.Text == "Right")
                        alignment = PosPrinter.PrinterBarCodeRight;
                    else
                        alignment = int.Parse(cbAlignment.Text);

                    _printer.PrintBitmap(CurrentStation, dlg.FileName, int.Parse(tbWidth.Text), alignment);
                }
               
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnPrintTwoNormal_Click(object sender, System.EventArgs e)
        {
            try
            {
                // replace ESC with Char(27) and add a CRLF to the end
                string text = TextToPrint.Text.Replace("ESC", ((char)27).ToString()) + "\x1B|1lF";

                _printer.PrintTwoNormal(CurrentStation, text, "");
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                _printer.FlagWhenIdle = checkBox1.Checked;
                checkBox1.Checked = _printer.FlagWhenIdle;
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void CutReceipt_Click(object sender, System.EventArgs e)
        {
            try
            {
                _printer.CutPaper(95);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }

        }

        private void CurrentStationCB_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (CurrentStationCB.Text == "Receipt")
                CurrentStation = PrinterStation.Receipt;
            else if (CurrentStationCB.Text == "Slip")
                CurrentStation = PrinterStation.Slip;
            else if (CurrentStationCB.Text == "Journal")
                CurrentStation = PrinterStation.Journal;
            else if (CurrentStationCB.Text == "SlipJournal")
                CurrentStation = PrinterStation.TwoSlipJournal;
            else if (CurrentStationCB.Text == "SlipReceipt")
                CurrentStation = PrinterStation.TwoSlipReceipt;
            else if (CurrentStationCB.Text == "ReceiptJournal")
                CurrentStation = PrinterStation.TwoReceiptJournal;

        }

        private void Rotation_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (Rotation.Text == "Normal")
                CurrentRotation = PrintRotation.Normal;
            else if (Rotation.Text == "Right90")
                CurrentRotation = PrintRotation.Right90;
            else if (Rotation.Text == "Left90")
                CurrentRotation = PrintRotation.Left90;
            else if (Rotation.Text == "Rotate180")
                CurrentRotation = PrintRotation.Rotate180;
            else if (Rotation.Text == "BitmapRight90")
                CurrentRotation = PrintRotation.Bitmap | PrintRotation.Right90;
            else if (Rotation.Text == "BitmapLeft90")
                CurrentRotation = PrintRotation.Bitmap | PrintRotation.Left90;
            else if (Rotation.Text == "BitmapRotate180")
                CurrentRotation = PrintRotation.Bitmap | PrintRotation.Rotate180;
            else if (Rotation.Text == "BarcodeRight90")
                CurrentRotation = PrintRotation.Barcode | PrintRotation.Right90;
            else if (Rotation.Text == "BarcodeLeft90")
                CurrentRotation = PrintRotation.Barcode | PrintRotation.Left90;
            else if (Rotation.Text == "BarcodeRotate180")
                CurrentRotation = PrintRotation.Barcode | PrintRotation.Rotate180;
            else if (Rotation.Text == "BitmapBarcodeRight90")
                CurrentRotation = PrintRotation.Bitmap | PrintRotation.Barcode | PrintRotation.Right90;
            else if (Rotation.Text == "BitmapBarcodeLeft90")
                CurrentRotation = PrintRotation.Bitmap | PrintRotation.Barcode | PrintRotation.Left90;
            else if (Rotation.Text == "BitmapBarcodeRotate180")
                CurrentRotation = PrintRotation.Bitmap | PrintRotation.Barcode | PrintRotation.Rotate180;
        }

        private void btnRotatePrint_Click(object sender, System.EventArgs e)
        {
            try
            {
                _printer.RotatePrint(CurrentStation, CurrentRotation);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void TransactionPrintButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                _printer.TransactionPrint(CurrentStation, CurrentTransaction);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void TransactionCB_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (TransactionCB.Text == "Normal")
                CurrentTransaction = PrinterTransactionControl.Normal;
            else
                CurrentTransaction = PrinterTransactionControl.Transaction;
        }

        private void btnPrintImmediate_Click(object sender, System.EventArgs e)
        {
            try
            {
                // replace ESC with Char(27) and add a CRLF to the end
                string text = TextToPrint.Text.Replace("ESC", ((char)27).ToString()) + "\x1B|1lF";

                _printer.PrintImmediate(CurrentStation, text);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }

        }

        private void btnBeginInsertion_Click(object sender, System.EventArgs e)
        {
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _printer.BeginInsertion(Int32.Parse(tbTimeout.Text));
                
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
            finally
            {
                Cursor.Current = old;
            }
        }

        private void btnEndInsertion_Click(object sender, System.EventArgs e)
        {
            try
            {
                _printer.EndInsertion();
                
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }

        }

        private void btnBeginRemoval_Click(object sender, System.EventArgs e)
        {
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _printer.BeginRemoval(Int32.Parse(tbTimeout.Text));
                
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
            finally
            {
                Cursor.Current = old;
            }
        }

        private void btnEndRemoval_Click(object sender, System.EventArgs e)
        {
            try
            {
               _printer.EndRemoval();
                
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }


        #endregion

       

      
        




    }
}

