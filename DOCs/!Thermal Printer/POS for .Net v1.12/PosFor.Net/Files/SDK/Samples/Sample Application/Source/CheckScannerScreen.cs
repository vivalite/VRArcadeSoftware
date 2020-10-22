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
    public partial class CheckScannerScreen : TestApplication.DeviceScreenBase
    {
        CheckScanner _checkscanner;

        public CheckScannerScreen()
        {
            InitializeComponent();

            pbCheckImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public override void SetOpened(bool opened)
        {
            if (_checkscanner == null)
            {
                _checkscanner = (CheckScanner)PosCommon;
                _checkscanner.DataEvent += new DataEventHandler(_checkscanner_DataEvent);
                _checkscanner.StatusUpdateEvent += new StatusUpdateEventHandler(_checkscanner_StatusUpdateEvent);
            }

            if (opened)
                UpdateUI();
        }

        void _checkscanner_StatusUpdateEvent(object sender, StatusUpdateEventArgs e)
        {
            UpdateImageProps();
        }


        void _checkscanner_DataEvent(object sender, DataEventArgs e)
        {
            UpdateImageProps();
        }

        void UpdateUI()
        {
            UpdateImageProps();
            SetDeviceCaps();
            ResetCropAreaIds();
        }

        public override void ClearInputProperties() 
        {
            pbCheckImage.Image = null;
            pbCheckImage.Update();
        }

        public override void SetDeviceClaimed(bool claimed)
        {
            if (claimed)
            {
                SetDeviceCaps();
                ResetCropAreaIds();
            }
        }
        

       

        private void beginInsertionbutton_Click(object sender, System.EventArgs e)
        {
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _checkscanner.BeginInsertion(Int32.Parse(TimeouttextBox.Text));

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

        private void endInsertionbutton_Click(object sender, System.EventArgs e)
        {
            try
            {
                _checkscanner.EndInsertion();
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void SetDeviceCaps()
        {
            

            ImageFormatcomboBox.Items.Clear();

            CheckImageFormats format = _checkscanner.ImageFormat;
            CheckImageFormats formats = _checkscanner.CapImageFormat;
            if ((formats & CheckImageFormats.Bmp) == CheckImageFormats.Bmp)
            {
                ImageFormatcomboBox.Items.Add("Bmp");
                if (format == CheckImageFormats.Bmp)
                    ImageFormatcomboBox.Text = "Bmp";
            }
            if ((formats & CheckImageFormats.Gif) == CheckImageFormats.Gif)
            {
                ImageFormatcomboBox.Items.Add("Gif");
                if (format == CheckImageFormats.Gif)
                    ImageFormatcomboBox.Text = "Gif";
            }
            if ((formats & CheckImageFormats.Jpeg) == CheckImageFormats.Jpeg)
            {
                ImageFormatcomboBox.Items.Add("Jpeg");
                if (format == CheckImageFormats.Jpeg)
                    ImageFormatcomboBox.Text = "Jpeg";
            }
            if ((formats & CheckImageFormats.Native) == CheckImageFormats.Native)
            {
                ImageFormatcomboBox.Items.Add("Native");
                if (format == CheckImageFormats.Native)
                    ImageFormatcomboBox.Text = "Native";
            }
            if ((formats & CheckImageFormats.Tiff) == CheckImageFormats.Tiff)
            {
                ImageFormatcomboBox.Items.Add("Tiff");
                if (format == CheckImageFormats.Tiff)
                    ImageFormatcomboBox.Text = "Tiff";
            }


            RetrieveMemorycomboBox.Items.Clear();
            RetrieveMemorycomboBox.Items.Add("By File Id");
            RetrieveMemorycomboBox.Items.Add("By File Index");
            RetrieveMemorycomboBox.Text = "By File Index";

            if (_checkscanner.CapImageTagData == true)
            {
                RetrieveMemorycomboBox.Items.Add("By Image Tag Data");
                ImageTagDatatextBox.Enabled = true;
            }
            else
            {
                ImageTagDatatextBox.Enabled = false;
            }

            RetrieveMemorycomboBox.Items.Add("Clear All Images");

            SetMapModeAndQualityAndColor();

        }

        private void ResetCropAreaIds()
        {
            CropAreaIdcomboBox.Items.Clear();
            CropAreaIdcomboBox.Items.Add("-1, Entire image");
            //CropAreaIdcomboBox.Items.Add("-2, Reset All");

            CropAreaIdcomboBox.Text = "-1, Entire image";
        }

        private void retrieveImagebutton_Click(object sender, System.EventArgs e)
        {
            try
            {
                int cropAreaId = Int32.Parse(CropAreaIdcomboBox.Text.Split(',')[0]);
                _checkscanner.RetrieveImage(cropAreaId);
                UpdateImageProps();
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnDefineCropArea_Click(object sender, System.EventArgs e)
        {
            try
            {
                
                int cropAreaId = Int32.Parse(IdtextBox.Text);
                int x = Int32.Parse(xtextBox.Text);
                int y = Int32.Parse(ytextBox.Text);
                int width = Int32.Parse(widthtextBox.Text);
                int height = Int32.Parse(heighttextBox.Text);
                _checkscanner.DefineCropArea(cropAreaId, x, y, width, height);

                if (cropAreaId == CheckScanner.CropAreaResetAll)
                {
                    ResetCropAreaIds();
                }
                else
                {
                    string s = cropAreaId.ToString() + ", (" + x.ToString() + "," + y.ToString() + "), (" + width.ToString() + "," + height.ToString() + ")";

                    for (int i = 0; i < CropAreaIdcomboBox.Items.Count; i++)
                    {
                        if (Int32.Parse(((string)CropAreaIdcomboBox.Items[i]).Split(',')[0]) == cropAreaId)
                        {
                            CropAreaIdcomboBox.Items[i] = s;
                            return;
                        }
                    }
                    CropAreaIdcomboBox.Items.Add(s);
                }
            
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void ImageFormatcomboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                string format = ImageFormatcomboBox.Text;

                if (format == "Bmp")
                    _checkscanner.ImageFormat = CheckImageFormats.Bmp;
                else if (format == "Gif")
                    _checkscanner.ImageFormat = CheckImageFormats.Gif;
                else if (format == "Jpeg")
                    _checkscanner.ImageFormat = CheckImageFormats.Jpeg;
                else if (format == "Native")
                    _checkscanner.ImageFormat = CheckImageFormats.Native;
                else if (format == "Tiff")
                    _checkscanner.ImageFormat = CheckImageFormats.Tiff;

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void UpdateImageProps()
        {
            FileIdtextBox.Text = _checkscanner.FileId;
            FileIndextextBox.Text = _checkscanner.FileIndex.ToString();

            if (_checkscanner.CapImageTagData == true)
                ImageTagDatatextBox.Text = _checkscanner.ImageTagData;

            DocumentHeighttextBox.Text = _checkscanner.DocumentHeight.ToString();
            DocumentWidthtextBox.Text = _checkscanner.DocumentWidth.ToString();

            pbCheckImage.Image = _checkscanner.ImageData;
            pbCheckImage.Update();
        }

        private void storeImagebutton_Click(object sender, System.EventArgs e)
        {
            try
            {
                int cropAreaId = Int32.Parse(CropAreaIdcomboBox.Text.Split(',')[0]);
                _checkscanner.StoreImage(cropAreaId);

                UpdateImageProps();
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void RetrieveMemorybutton_Click(object sender, System.EventArgs e)
        {
            try
            {
                CheckImageLocate by = CheckImageLocate.FileId; ;

                if (RetrieveMemorycomboBox.Text == "By File Index")
                    by = CheckImageLocate.FileIndex;
                else if (RetrieveMemorycomboBox.Text == "By Image Tag Data")
                    by = CheckImageLocate.ImageTagData;

                _checkscanner.RetrieveMemory(by);

                UpdateImageProps();
            
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }

        }

        private void ClearImagebutton_Click(object sender, System.EventArgs e)
        {
            try
            {
                CheckImageClear by = CheckImageClear.FileId; ;

                if (RetrieveMemorycomboBox.Text == "By File Index")
                    by = CheckImageClear.FileIndex;
                else if (RetrieveMemorycomboBox.Text == "By Image Tag Data")
                    by = CheckImageClear.ImageTagData;
                else if (RetrieveMemorycomboBox.Text == "Clear All Images")
                    by = CheckImageClear.All;

                _checkscanner.ClearImage(by);

                UpdateImageProps();

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void FileIdtextBox_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                _checkscanner.FileId = FileIdtextBox.Text;
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void FileIndextextBox_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                _checkscanner.FileIndex = Int32.Parse(FileIndextextBox.Text);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void ImageTagDatatextBox_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                _checkscanner.ImageTagData = ImageTagDatatextBox.Text;
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void DocumentHeighttextBox_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                _checkscanner.DocumentHeight = Int32.Parse(DocumentHeighttextBox.Text);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void DocumentWidthtextBox_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                _checkscanner.DocumentWidth = Int32.Parse(DocumentWidthtextBox.Text);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void SetMapModeAndQualityAndColor()
        {
            try
            {
                if (_checkscanner.MapMode == MapMode.Dots)
                    MapModecomboBox.Text = "Dots";
                else if (_checkscanner.MapMode == MapMode.English)
                    MapModecomboBox.Text = "English";
                else if (_checkscanner.MapMode == MapMode.Metric)
                    MapModecomboBox.Text = "Metric";
                else
                    MapModecomboBox.Text = "Twips";

                QualitycomboBox.Items.Clear();
                foreach (int qual in _checkscanner.QualityList)
                {
                    QualitycomboBox.Items.Add(qual.ToString());
                }
                QualitycomboBox.Text = _checkscanner.Quality.ToString();

                ColorcomboBox.Items.Clear();
                if ((_checkscanner.CapColor & CheckColors.Mono) == CheckColors.Mono)
                    ColorcomboBox.Items.Add("Mono");
                if ((_checkscanner.CapColor & CheckColors.GrayScale) == CheckColors.GrayScale)
                    ColorcomboBox.Items.Add("GrayScale");
                if ((_checkscanner.CapColor & CheckColors.Full) == CheckColors.Full)
                    ColorcomboBox.Items.Add("Full");
                if ((_checkscanner.CapColor & CheckColors.Color256) == CheckColors.Color256)
                    ColorcomboBox.Items.Add("Color256");
                if ((_checkscanner.CapColor & CheckColors.Color16) == CheckColors.Color16)
                    ColorcomboBox.Items.Add("Color16");


                if (_checkscanner.Color == CheckColors.Mono)
                    ColorcomboBox.Text = "Mono";
                else if (_checkscanner.Color == CheckColors.GrayScale)
                    ColorcomboBox.Text = "GrayScale";
                else if (_checkscanner.Color == CheckColors.Full)
                    ColorcomboBox.Text = "Full";
                else if (_checkscanner.Color == CheckColors.Color256)
                    ColorcomboBox.Text = "Color256";
                else if (_checkscanner.Color == CheckColors.Color16)
                    ColorcomboBox.Text = "Color16";
            
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void MapModecomboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (MapModecomboBox.Text == "Dots")
                    _checkscanner.MapMode = MapMode.Dots;
                else if (MapModecomboBox.Text == "English")
                    _checkscanner.MapMode = MapMode.English;
                else if (MapModecomboBox.Text == "Metric")
                    _checkscanner.MapMode = MapMode.Metric;
                else
                    _checkscanner.MapMode = MapMode.Twips;

                UpdateImageProps();

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void QualitycomboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                _checkscanner.Quality = Int32.Parse(QualitycomboBox.Text);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void ColorcomboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (ColorcomboBox.Text == "Mono")
                    _checkscanner.Color = CheckColors.Mono;
                else if (ColorcomboBox.Text == "GrayScale")
                    _checkscanner.Color = CheckColors.GrayScale;
                else if (ColorcomboBox.Text == "Full")
                    _checkscanner.Color = CheckColors.Full;
                else if (ColorcomboBox.Text == "Color256")
                    _checkscanner.Color = CheckColors.Color256;
                else if (ColorcomboBox.Text == "Color16")
                    _checkscanner.Color = CheckColors.Color16;
                else
                    throw new Exception("Unknown color type.");
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }


                
    }
}

