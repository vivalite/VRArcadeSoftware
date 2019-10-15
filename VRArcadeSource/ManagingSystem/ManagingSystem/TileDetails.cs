using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;
using VRGameSelectorServerDTO;

namespace ManagingSystem
{
    public partial class TileDetails : Telerik.WinControls.UI.RadForm
    {
        int _parentTileConfigID = 0;
        int _order = 0;
        int _configSetID = 0;
        TileConfig _tileConfig = new TileConfig();
        bool IsEdit = false;

        public TileDetails()
        {
            InitializeComponent();

            ((OpenFileDialog)radBrowseEditorImagePath.Dialog).Filter = "All Files|*.*|*.jpg|*.jpg|*.jpeg|*.jpeg|*.png|*.png|*.gif|*.gif";

            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        public TileDetails(int parentTileConfigID, int order, int configSetID) : this()
        {
            // add new tile
            PopulateControls();

            _parentTileConfigID = parentTileConfigID;
            _order = order;
            _configSetID = configSetID;
        }


        public TileDetails(TileConfig tc) : this()
        {
            _tileConfig = tc;
            IsEdit = true;

            PopulateControls();

        }

        private void radButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radButtonOK_Click(object sender, EventArgs e)
        {
            PopulateTileConfig();

            if (IsEdit)
            {
                NetworkFunction.ModifyTileConfig(_tileConfig);
            }
            else
            {
                _tileConfig.TileconfigID = _parentTileConfigID;
                _tileConfig.Order = _order;
                _tileConfig.TileConfigSetID = _configSetID;

                NetworkFunction.AddTileConfig(_tileConfig);
            }

            this.Close();
        }

        private void PopulateControls()
        {
            radTextBoxTitle.Text = _tileConfig.TileTitle;
            radSpinEditorHeight.Value = _tileConfig.TileHeight;
            radSpinEditorWidth.Value = _tileConfig.TileWidth;
            radSpinEditorRowNumber.Value = _tileConfig.TileRowNumber;
            radBrowseEditorImagePath.Value = "";
            radTextBoxCommand.Text = _tileConfig.Command;
            radTextBoxArguments.Text = _tileConfig.Arguments;
            radTextBoxWorkingPath.Text = _tileConfig.WorkingPath;
            radTextBoxTileDesc.Text = _tileConfig.TileDesc;
            if (_tileConfig.TileImage.Image != null)
            {
                pictureBoxPreview.Image = _tileConfig.TileImage.Image;
            }
            radSpinEditorAgeRequire.Value = _tileConfig.AgeRequire;
            radTextBoxVideoURL.Text = _tileConfig.VideoURL;
        }


        private void PopulateTileConfig()
        {
            _tileConfig.TileTitle = radTextBoxTitle.Text;
            _tileConfig.TileHeight = (int)radSpinEditorHeight.Value;
            _tileConfig.TileWidth = (int)radSpinEditorWidth.Value;
            _tileConfig.TileRowNumber = (int)radSpinEditorRowNumber.Value;
            _tileConfig.Command = radTextBoxCommand.Text;
            _tileConfig.Arguments = radTextBoxArguments.Text;
            _tileConfig.WorkingPath = radTextBoxWorkingPath.Text;
            _tileConfig.TileDesc = radTextBoxTileDesc.Text;
            _tileConfig.AgeRequire = (int)radSpinEditorAgeRequire.Value;
            _tileConfig.VideoURL = radTextBoxVideoURL.Text;
        }



        private void radBrowseEditorImagePath_ValueChanged(object sender, EventArgs e)
        {
            if (radBrowseEditorImagePath.Value == null)
            {
                radBrowseEditorImagePath.Value = " ";
            }
            else if (radBrowseEditorImagePath.Value.Length > 1)
            {
                try
                {
                    FileInfo fi = new FileInfo(radBrowseEditorImagePath.Value);

                    if (fi.Length > 1024000) throw (new Exception());

                    _tileConfig.TileImage.Image = Image.FromFile(radBrowseEditorImagePath.Value);
                    _tileConfig.TileImage.ImageData = new byte[] { 0x00 }; // temp bug fix. 
                    _tileConfig.TileImage.IsImageChanged = true;

                    pictureBoxPreview.Image = _tileConfig.TileImage.Image;

                }
                catch (Exception)
                {
                    RadMessageBox.Show(this, "Wrong image format or image size > 1MB ! Supported format are *.jpg/*.gif/*.png", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                }


            }

        }
    }
}
