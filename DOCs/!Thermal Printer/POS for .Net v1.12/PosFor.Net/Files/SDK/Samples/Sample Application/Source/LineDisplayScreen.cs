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
    public partial class LineDisplayScreen : TestApplication.DeviceScreenBase
    {
        LineDisplay display;
        public LineDisplayScreen()
        {
            InitializeComponent();

            cbMarqueeType.Items.Clear();
            cbMarqueeType.Items.AddRange(Enum.GetNames(typeof(DisplayMarqueeType)));
            cbMarqueeType.Text = DisplayMarqueeType.None.ToString();

            cbMarqueeFormat.Items.Clear();
            cbMarqueeFormat.Items.AddRange(Enum.GetNames(typeof(DisplayMarqueeFormat)));
            cbMarqueeFormat.SelectedIndex = 0;

            cbDisplayTextAttribute.Items.Clear();
            cbDisplayTextAttribute.Items.AddRange(Enum.GetNames(typeof(DisplayTextMode)));
            cbDisplayTextAttribute.SelectedIndex = 0;

            cbSetDescriptorAttribute.Items.Clear();
            cbSetDescriptorAttribute.Items.AddRange(Enum.GetNames(typeof(DisplaySetDescriptor)));
            cbSetDescriptorAttribute.SelectedIndex = 0;

            cbSetDescriptorAttribute.Items.Clear();
            cbSetDescriptorAttribute.Items.AddRange(Enum.GetNames(typeof(DisplaySetDescriptor)));
            cbSetDescriptorAttribute.SelectedIndex = 0;

            cbScrollTextDirection.Items.Clear();
            cbScrollTextDirection.Items.AddRange(Enum.GetNames(typeof(DisplayScrollText)));
            cbScrollTextDirection.SelectedIndex = 0;

            Units.Text = "1";
            cbScrollTextDirection.Text = "Right";

            WindowComboBox.Items.Clear();
            WindowComboBox.Items.Add("0");
            WindowComboBox.Text = "0";


            cbSetDescriptorAttribute.Text = "On";
           
        }
        public override void SetOpened(bool opened)
        {
            if (display == null)
            {
                display = (LineDisplay)PosCommon;
            }

            if (opened)
            {
                WindowComboBox.Text = display.CurrentWindow.ToString();
                
                if (display.ServiceObjectVersion.Minor >= 7)
                {
                    DisplayScreenMode[] sml = display.ScreenModeList;
                    cbDisplayScreenModes.Items.Clear();
                    if (sml != null && sml.Length > 0)
                    {
                        foreach (DisplayScreenMode d in sml)
                        {
                            cbDisplayScreenModes.Items.Add(d.Rows.ToString() + "x" + d.Columns.ToString());
                        }

                        DisplayScreenMode dd = display.ScreenModeList[0];

                        cbDisplayScreenModes.Enabled = true;
                        cbDisplayScreenModes.Text = dd.Rows.ToString() + "x" + dd.Columns.ToString();
                    }
                    else
                    {
                        cbDisplayScreenModes.Enabled = false;
                    }
                }
                else
                {
                    cbDisplayScreenModes.Enabled = false;
                }

                UpdateUI();


            }
        }

        private void UpdateUI()
        {
            if (display.State != ControlState.Closed)
            {
                
                tbInterCharacterWait.Text = display.InterCharacterWait.ToString();
                tbBlinkRate.Text = display.BlinkRate.ToString();
                tbMarqueeUnitWait.Text = display.MarqueeUnitWait.ToString();
                tbMarqueeRepeatWait.Text = display.MarqueeRepeatWait.ToString();


                cbMarqueeType.Text = display.MarqueeType.ToString();
                cbMarqueeFormat.Text = display.MarqueeFormat.ToString();


                cbCursorUpdate.Checked = display.CursorUpdate;

                btnClearDescriptors.Enabled = display.CapDescriptors;
                btnSetDescriptor.Enabled = display.CapDescriptors;
            

                cbCursorType.Items.Clear();
                cbCursorType.Items.Add(DisplayCursors.None.ToString());
                cbCursorType.Enabled = false;
                cbCursorUpdate.Checked = display.CursorUpdate;
                if (display.ServiceObjectVersion.Minor >= 8)
                {
                    if (display.CapCursorType == DisplayCursors.None)
                    {
                        cbCursorType.Enabled = false;
                    }
                    else
                    {
                        bool blink = false;
                        cbCursorType.Enabled = true;
                        if ((display.CapCursorType & DisplayCursors.Fixed) > 0)
                            cbCursorType.Enabled = false;

                        if ((display.CapCursorType & DisplayCursors.Blink) > 0)
                            blink = true;


                        if ((display.CapCursorType & DisplayCursors.Block) > 0)
                        {
                            cbCursorType.Items.Add(DisplayCursors.Block.ToString());
                            if (blink)
                                cbCursorType.Items.Add("Blink" + DisplayCursors.Block.ToString());
                        }
                        if ((display.CapCursorType & DisplayCursors.HalfBlock) > 0)
                        {
                            cbCursorType.Items.Add(DisplayCursors.HalfBlock.ToString());
                            if (blink)
                                cbCursorType.Items.Add("Blink" + DisplayCursors.HalfBlock.ToString());
                        }
                        if ((display.CapCursorType & DisplayCursors.Other) > 0)
                        {
                            cbCursorType.Items.Add(DisplayCursors.Other.ToString());
                            if (blink)
                                cbCursorType.Items.Add("Blink" + DisplayCursors.Other.ToString());
                        }
                        if ((display.CapCursorType & DisplayCursors.Reverse) > 0)
                        {
                            cbCursorType.Items.Add(DisplayCursors.Reverse.ToString());
                            if (blink)
                                cbCursorType.Items.Add("Blink" + DisplayCursors.Reverse.ToString());
                        }
                        if ((display.CapCursorType & DisplayCursors.Underline) > 0)
                        {
                            cbCursorType.Items.Add(DisplayCursors.Underline.ToString());
                            if (blink)
                                cbCursorType.Items.Add("Blink" + DisplayCursors.Underline.ToString());
                        }

                        cbCursorType.Text = display.CursorType.ToString();
                    }
                }
            }


        }

        


        private void DisplayText_Click(object sender, System.EventArgs e)
        {
            try
            {
                
                if (display.CapCustomGlyph)
                {
                    int GlyphBytes = display.GlyphWidth / 8;
                    if ((display.GlyphWidth % 8) > 0)
                        GlyphBytes++;
                    GlyphBytes *= display.GlyphHeight;
                    byte[] x = new byte[GlyphBytes];
                    //					Random rnd = new Random();
                    //					rnd.NextBytes(x);
                    for (int i = 0; i < GlyphBytes; i++)
                    {
                        x[i] = (byte)(i % 3 == 0 ? '*' : ' ');
                    }
                    display.DefineGlyph(0x4D, x);
                }

                DisplayTextMode dtm = (DisplayTextMode) Enum.Parse(typeof(DisplayTextMode), cbDisplayTextAttribute.Text); 

                string text = LDText.Text.Replace("ESC", ((char)27).ToString()).Replace("CRLF", ((char)10).ToString()).Replace("CR", ((char)13).ToString());

                if (PosX.Text.Length > 0 || PosY.Text.Length > 0)
                {
                    int x = 0, y = 0;

                    if (PosX.Text.Length > 0)
                    {
                        x = Int32.Parse(PosX.Text);
                    }
                    if (PosY.Text.Length > 0)
                    {
                        y = Int32.Parse(PosY.Text);
                    }
                    display.DisplayTextAt(y, x, text, dtm);
                }
                else
                {
                    display.DisplayText(text, dtm);
                }
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void ClearText_Click(object sender, System.EventArgs e)
        {
            try
            {
                display.ClearText();
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void ScrollButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                DisplayScrollText dir = (DisplayScrollText) Enum.Parse(typeof(DisplayScrollText), cbScrollTextDirection.Text);
                display.ScrollText(dir, Int32.Parse(Units.Text));
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void ReadTextButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                int charAtCursor = display.ReadCharacterAtCursor();
                string str = ((char)charAtCursor).ToString();
                ReadTextLabel.Text = str;
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void SetBitmapbutton_Click(object sender, System.EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Image files|*.bmp;*.gif;*.jpg";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string width = WidthComboBox.Text;
                    string AX = AlignXComboBox.Text;
                    string AY = AlignYComboBox.Text;

                    int AlignX, AlignY;
                    int Width;

                    if (width.ToLower() == "actual")
                        Width = LineDisplay.DisplayBitmapAsIs;
                    else
                        Width = Int32.Parse(width);

                    AX = AX.ToLower();
                    if (AX == "left")
                        AlignX = LineDisplay.DisplayBitmapLeft;
                    else if (AX == "center")
                        AlignX = LineDisplay.DisplayBitmapCenter;
                    else if (AX == "right")
                        AlignX = LineDisplay.DisplayBitmapRight;
                    else
                        AlignX = Int32.Parse(AX);

                    AY = AY.ToLower();
                    if (AY == "top")
                        AlignY = LineDisplay.DisplayBitmapTop;
                    else if (AY == "center")
                        AlignY = LineDisplay.DisplayBitmapCenter;
                    else if (AY == "bottom")
                        AlignY = LineDisplay.DisplayBitmapBottom;
                    else
                        AlignY = Int32.Parse(AY);

                    int bitmapnum = Int32.Parse(SetBitmapcomboBox.Text);
                    display.SetBitmap(bitmapnum, dlg.FileName, Width, AlignX, AlignY);

                    bool NeedtoAdd = true;
                    foreach (string s in SetBitmapcomboBox.Items)
                    {
                        if (s == SetBitmapcomboBox.Text)
                        {
                            NeedtoAdd = false;
                            break;
                        }
                    }
                    if (NeedtoAdd)
                        SetBitmapcomboBox.Items.Add(SetBitmapcomboBox.Text);
                }
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }
        
        private void DisplayBitmapButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Image files|*.bmp;*.gif;*.jpg";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string width = WidthComboBox.Text;
                    string AX = AlignXComboBox.Text;
                    string AY = AlignYComboBox.Text;

                    int AlignX, AlignY;
                    int Width;

                    if (width.ToLower() == "actual")
                        Width = LineDisplay.DisplayBitmapAsIs;
                    else
                        Width = Int32.Parse(width);

                    AX = AX.ToLower();
                    if (AX == "left")
                        AlignX = LineDisplay.DisplayBitmapLeft;
                    else if (AX == "center")
                        AlignX = LineDisplay.DisplayBitmapCenter;
                    else if (AX == "right")
                        AlignX = LineDisplay.DisplayBitmapRight;
                    else
                        AlignX = Int32.Parse(AX);

                    AY = AY.ToLower();
                    if (AY == "top")
                        AlignY = LineDisplay.DisplayBitmapTop;
                    else if (AY == "center")
                        AlignY = LineDisplay.DisplayBitmapCenter;
                    else if (AY == "bottom")
                        AlignY = LineDisplay.DisplayBitmapBottom;
                    else
                        AlignY = Int32.Parse(AY);

                    display.DisplayBitmap(dlg.FileName, Width, AlignX, AlignY);
                }
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void CreateWindowButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                int VR = Int32.Parse(ViewportRowTextBox.Text);
                int VC = Int32.Parse(ViewportColumnTextBox.Text);
                int VH = Int32.Parse(ViewportHeightTextBox.Text);
                int VW = Int32.Parse(ViewportWidthTextBox.Text);
                int WH = Int32.Parse(WindowHeightTextBox.Text);
                int WW = Int32.Parse(WindowWidthTextBox.Text);

                display.CreateWindow(VR, VC, VH, VW, WH, WW);

                WindowComboBox.Items.Add(display.CurrentWindow.ToString());

                UpdateUI();

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnRefreshWindow_Click(object sender, System.EventArgs e)
        {
            try
            {
                display.RefreshWindow(display.CurrentWindow);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void DestroyWindowButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                string currentwindow = display.CurrentWindow.ToString();
                display.DestroyWindow();

                WindowComboBox.Items.Remove(currentwindow);

                UpdateUI();
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void WindowComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (display == null || display.State == ControlState.Closed)
                    return;
                display.CurrentWindow = Int32.Parse(WindowComboBox.Text);

                UpdateUI();
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }

        }

        private void btnClearDescriptors_Click(object sender, System.EventArgs e)
        {
            try
            {
                display.ClearDescriptors();

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnSetDescriptor_Click(object sender, System.EventArgs e)
        {
            try
            {
                display.SetDescriptor(Int32.Parse(tbDescriptor.Text), (DisplaySetDescriptor)Enum.Parse(typeof(DisplaySetDescriptor), cbSetDescriptorAttribute.Text));

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void tbInterCharacterWait_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                display.InterCharacterWait = Int32.Parse(tbInterCharacterWait.Text);

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }
        
        private void cbCursorUpdate_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                display.CursorUpdate = cbCursorUpdate.Checked;

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void cbCursorType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (cbCursorType.Text == "None")
                    display.CursorType = DisplayCursors.None;
                else if (cbCursorType.Text == "Block")
                    display.CursorType = DisplayCursors.Block;
                else if (cbCursorType.Text == "HalfBlock")
                    display.CursorType = DisplayCursors.HalfBlock;
                else if (cbCursorType.Text == "Underline")
                    display.CursorType = DisplayCursors.Underline;
                else if (cbCursorType.Text == "Reverse")
                    display.CursorType = DisplayCursors.Reverse;
                else if (cbCursorType.Text == "Other")
                    display.CursorType = DisplayCursors.Other;
                else if (cbCursorType.Text == "BlinkBlock")
                    display.CursorType = DisplayCursors.Block | DisplayCursors.Blink;
                else if (cbCursorType.Text == "BlinkHalfBlock")
                    display.CursorType = DisplayCursors.HalfBlock | DisplayCursors.Blink;
                else if (cbCursorType.Text == "BlinkUnderline")
                    display.CursorType = DisplayCursors.Underline | DisplayCursors.Blink;
                else if (cbCursorType.Text == "BlinkReverse")
                    display.CursorType = DisplayCursors.Reverse | DisplayCursors.Blink;
                else if (cbCursorType.Text == "BlinkOther")
                    display.CursorType = DisplayCursors.Other | DisplayCursors.Blink;

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void tbBlinkRate_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                display.BlinkRate = Int32.Parse(tbBlinkRate.Text);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void cbMarqueeType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (display == null || display.State == ControlState.Closed)
                    return;
                display.MarqueeType = (DisplayMarqueeType)Enum.Parse(typeof(DisplayMarqueeType), cbMarqueeType.Text); 
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void cbMarqueeFormat_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (display == null || display.State == ControlState.Closed)
                    return;
                display.MarqueeFormat = (DisplayMarqueeFormat)Enum.Parse(typeof(DisplayMarqueeFormat), cbMarqueeFormat.Text); 
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void tbMarqueeUnitWait_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                display.MarqueeUnitWait = Int32.Parse(tbMarqueeUnitWait.Text);

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void tbMarqueeRepeatWait_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                display.MarqueeRepeatWait = Int32.Parse(tbMarqueeRepeatWait.Text);

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void cbDisplayScreenModes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cbDisplayScreenModes.Tag != null)
                return;

            try
            {
                int Mode = 0;
                for (Mode = 0; Mode < display.ScreenModeList.Length; Mode++)
                {
                    int r = display.ScreenModeList[Mode].Rows;
                    int c = display.ScreenModeList[Mode].Columns;

                    if (r + "x" + c == cbDisplayScreenModes.Text)
                    {
                        if (display.Claimed)
                            display.ScreenMode = Mode + 1;  // screenmode is 1-based
                        WindowComboBox.Items.Clear();
                        WindowComboBox.Items.Add("0");
                        UpdateUI();
                        return;
                    }
                }

            }
            catch (Exception ae)
            {
                ShowException(ae);
            }

        }



    }
}

