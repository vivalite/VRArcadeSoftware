namespace TestApplication
{
    partial class LineDisplayScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbDescriptor = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.cbSetDescriptorAttribute = new System.Windows.Forms.ComboBox();
            this.btnSetDescriptor = new System.Windows.Forms.Button();
            this.btnClearDescriptors = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            this.cbCursorType = new System.Windows.Forms.ComboBox();
            this.cbCursorUpdate = new System.Windows.Forms.CheckBox();
            this.SetBitmapcomboBox = new System.Windows.Forms.ComboBox();
            this.SetBitmapbutton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.PosX = new System.Windows.Forms.TextBox();
            this.PosY = new System.Windows.Forms.TextBox();
            this.cbDisplayScreenModes = new System.Windows.Forms.ComboBox();
            this.cbMarqueeType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbMarqueeRepeatWait = new System.Windows.Forms.TextBox();
            this.tbMarqueeUnitWait = new System.Windows.Forms.TextBox();
            this.cbMarqueeFormat = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbBlinkRate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbInterCharacterWait = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbDisplayTextAttribute = new System.Windows.Forms.ComboBox();
            this.WindowComboBox = new System.Windows.Forms.ComboBox();
            this.btnRefreshWindow = new System.Windows.Forms.Button();
            this.DestroyWindowButton = new System.Windows.Forms.Button();
            this.WindowWidthTextBox = new System.Windows.Forms.TextBox();
            this.WindowHeightTextBox = new System.Windows.Forms.TextBox();
            this.ViewportWidthTextBox = new System.Windows.Forms.TextBox();
            this.ViewportHeightTextBox = new System.Windows.Forms.TextBox();
            this.ViewportColumnTextBox = new System.Windows.Forms.TextBox();
            this.ViewportRowTextBox = new System.Windows.Forms.TextBox();
            this.CreateWindowButton = new System.Windows.Forms.Button();
            this.WidthComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AlignYComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AlignXComboBox = new System.Windows.Forms.ComboBox();
            this.DisplayBitmapButton = new System.Windows.Forms.Button();
            this.ReadTextLabel = new System.Windows.Forms.Label();
            this.ReadTextButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Units = new System.Windows.Forms.TextBox();
            this.cbScrollTextDirection = new System.Windows.Forms.ComboBox();
            this.ScrollButton = new System.Windows.Forms.Button();
            this.ClearText = new System.Windows.Forms.Button();
            this.LDText = new System.Windows.Forms.TextBox();
            this.DisplayText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbDescriptor
            // 
            this.tbDescriptor.Location = new System.Drawing.Point(639, 157);
            this.tbDescriptor.Name = "tbDescriptor";
            this.tbDescriptor.Size = new System.Drawing.Size(78, 20);
            this.tbDescriptor.TabIndex = 126;
            this.tbDescriptor.Text = "1";
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(572, 188);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(56, 16);
            this.label45.TabIndex = 125;
            this.label45.Text = "Attribute";
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(572, 162);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(56, 16);
            this.label44.TabIndex = 124;
            this.label44.Text = "Descriptor";
            // 
            // cbSetDescriptorAttribute
            // 
            this.cbSetDescriptorAttribute.Location = new System.Drawing.Point(639, 180);
            this.cbSetDescriptorAttribute.Name = "cbSetDescriptorAttribute";
            this.cbSetDescriptorAttribute.Size = new System.Drawing.Size(79, 21);
            this.cbSetDescriptorAttribute.TabIndex = 123;
            // 
            // btnSetDescriptor
            // 
            this.btnSetDescriptor.Location = new System.Drawing.Point(571, 131);
            this.btnSetDescriptor.Name = "btnSetDescriptor";
            this.btnSetDescriptor.Size = new System.Drawing.Size(111, 23);
            this.btnSetDescriptor.TabIndex = 122;
            this.btnSetDescriptor.Text = "SetDescriptor";
            this.btnSetDescriptor.Click += new System.EventHandler(this.btnSetDescriptor_Click);
            // 
            // btnClearDescriptors
            // 
            this.btnClearDescriptors.Location = new System.Drawing.Point(570, 102);
            this.btnClearDescriptors.Name = "btnClearDescriptors";
            this.btnClearDescriptors.Size = new System.Drawing.Size(111, 23);
            this.btnClearDescriptors.TabIndex = 121;
            this.btnClearDescriptors.Text = "ClearDescriptors";
            this.btnClearDescriptors.Click += new System.EventHandler(this.btnClearDescriptors_Click);
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(572, 43);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(66, 23);
            this.label39.TabIndex = 120;
            this.label39.Text = "Cursor Type";
            // 
            // cbCursorType
            // 
            this.cbCursorType.Location = new System.Drawing.Point(572, 67);
            this.cbCursorType.Name = "cbCursorType";
            this.cbCursorType.Size = new System.Drawing.Size(72, 21);
            this.cbCursorType.TabIndex = 119;
            this.cbCursorType.SelectedIndexChanged += new System.EventHandler(this.cbCursorType_SelectedIndexChanged);
            // 
            // cbCursorUpdate
            // 
            this.cbCursorUpdate.Location = new System.Drawing.Point(444, 95);
            this.cbCursorUpdate.Name = "cbCursorUpdate";
            this.cbCursorUpdate.Size = new System.Drawing.Size(104, 24);
            this.cbCursorUpdate.TabIndex = 118;
            this.cbCursorUpdate.Text = "CursorUpdate";
            this.cbCursorUpdate.CheckedChanged += new System.EventHandler(this.cbCursorUpdate_CheckedChanged);
            // 
            // SetBitmapcomboBox
            // 
            this.SetBitmapcomboBox.Location = new System.Drawing.Point(465, 156);
            this.SetBitmapcomboBox.Name = "SetBitmapcomboBox";
            this.SetBitmapcomboBox.Size = new System.Drawing.Size(80, 21);
            this.SetBitmapcomboBox.TabIndex = 117;
            // 
            // SetBitmapbutton
            // 
            this.SetBitmapbutton.Location = new System.Drawing.Point(383, 155);
            this.SetBitmapbutton.Name = "SetBitmapbutton";
            this.SetBitmapbutton.Size = new System.Drawing.Size(75, 23);
            this.SetBitmapbutton.TabIndex = 116;
            this.SetBitmapbutton.Text = "Set Bitmap";
            this.SetBitmapbutton.Click += new System.EventHandler(this.SetBitmapbutton_Click);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(112, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 16);
            this.label14.TabIndex = 115;
            this.label14.Text = "Y";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(40, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 18);
            this.label13.TabIndex = 114;
            this.label13.Text = "X";
            // 
            // PosX
            // 
            this.PosX.Location = new System.Drawing.Point(61, 37);
            this.PosX.Name = "PosX";
            this.PosX.Size = new System.Drawing.Size(33, 20);
            this.PosX.TabIndex = 113;
            // 
            // PosY
            // 
            this.PosY.Location = new System.Drawing.Point(135, 37);
            this.PosY.Name = "PosY";
            this.PosY.Size = new System.Drawing.Size(42, 20);
            this.PosY.TabIndex = 112;
            // 
            // cbDisplayScreenModes
            // 
            this.cbDisplayScreenModes.Location = new System.Drawing.Point(341, 40);
            this.cbDisplayScreenModes.Name = "cbDisplayScreenModes";
            this.cbDisplayScreenModes.Size = new System.Drawing.Size(80, 21);
            this.cbDisplayScreenModes.TabIndex = 111;
            this.cbDisplayScreenModes.SelectedIndexChanged += new System.EventHandler(this.cbDisplayScreenModes_SelectedIndexChanged);
            // 
            // cbMarqueeType
            // 
            this.cbMarqueeType.Location = new System.Drawing.Point(152, 185);
            this.cbMarqueeType.Name = "cbMarqueeType";
            this.cbMarqueeType.Size = new System.Drawing.Size(72, 21);
            this.cbMarqueeType.TabIndex = 110;
            this.cbMarqueeType.SelectedIndexChanged += new System.EventHandler(this.cbMarqueeType_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(321, 190);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 19);
            this.label12.TabIndex = 109;
            this.label12.Text = "U wait";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(431, 190);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 19);
            this.label11.TabIndex = 108;
            this.label11.Text = "R wait";
            // 
            // tbMarqueeRepeatWait
            // 
            this.tbMarqueeRepeatWait.Location = new System.Drawing.Point(481, 187);
            this.tbMarqueeRepeatWait.Name = "tbMarqueeRepeatWait";
            this.tbMarqueeRepeatWait.Size = new System.Drawing.Size(56, 20);
            this.tbMarqueeRepeatWait.TabIndex = 107;
            this.tbMarqueeRepeatWait.Text = "0";
            this.tbMarqueeRepeatWait.TextChanged += new System.EventHandler(this.tbMarqueeRepeatWait_TextChanged);
            // 
            // tbMarqueeUnitWait
            // 
            this.tbMarqueeUnitWait.Location = new System.Drawing.Point(364, 187);
            this.tbMarqueeUnitWait.Name = "tbMarqueeUnitWait";
            this.tbMarqueeUnitWait.Size = new System.Drawing.Size(56, 20);
            this.tbMarqueeUnitWait.TabIndex = 106;
            this.tbMarqueeUnitWait.Text = "0";
            this.tbMarqueeUnitWait.TextChanged += new System.EventHandler(this.tbMarqueeUnitWait_TextChanged);
            // 
            // cbMarqueeFormat
            // 
            this.cbMarqueeFormat.Location = new System.Drawing.Point(238, 187);
            this.cbMarqueeFormat.Name = "cbMarqueeFormat";
            this.cbMarqueeFormat.Size = new System.Drawing.Size(72, 21);
            this.cbMarqueeFormat.TabIndex = 105;
            this.cbMarqueeFormat.SelectedIndexChanged += new System.EventHandler(this.cbMarqueeFormat_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(48, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 104;
            this.label10.Text = "Marquee     type";
            // 
            // tbBlinkRate
            // 
            this.tbBlinkRate.AcceptsReturn = true;
            this.tbBlinkRate.Location = new System.Drawing.Point(289, 36);
            this.tbBlinkRate.Name = "tbBlinkRate";
            this.tbBlinkRate.Size = new System.Drawing.Size(33, 20);
            this.tbBlinkRate.TabIndex = 103;
            this.tbBlinkRate.Text = "0";
            this.tbBlinkRate.TextChanged += new System.EventHandler(this.tbBlinkRate_TextChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(262, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 16);
            this.label9.TabIndex = 102;
            this.label9.Text = "BR";
            // 
            // tbInterCharacterWait
            // 
            this.tbInterCharacterWait.Location = new System.Drawing.Point(222, 36);
            this.tbInterCharacterWait.Name = "tbInterCharacterWait";
            this.tbInterCharacterWait.Size = new System.Drawing.Size(37, 20);
            this.tbInterCharacterWait.TabIndex = 101;
            this.tbInterCharacterWait.Text = "0";
            this.tbInterCharacterWait.TextChanged += new System.EventHandler(this.tbInterCharacterWait_TextChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(187, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 16);
            this.label8.TabIndex = 100;
            this.label8.Text = "ICW";
            // 
            // cbDisplayTextAttribute
            // 
            this.cbDisplayTextAttribute.Location = new System.Drawing.Point(245, 12);
            this.cbDisplayTextAttribute.Name = "cbDisplayTextAttribute";
            this.cbDisplayTextAttribute.Size = new System.Drawing.Size(80, 21);
            this.cbDisplayTextAttribute.TabIndex = 99;
            // 
            // WindowComboBox
            // 
            this.WindowComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WindowComboBox.Location = new System.Drawing.Point(277, 156);
            this.WindowComboBox.Name = "WindowComboBox";
            this.WindowComboBox.Size = new System.Drawing.Size(80, 21);
            this.WindowComboBox.TabIndex = 98;
            this.WindowComboBox.SelectedIndexChanged += new System.EventHandler(this.WindowComboBox_SelectedIndexChanged);
            // 
            // btnRefreshWindow
            // 
            this.btnRefreshWindow.Location = new System.Drawing.Point(157, 156);
            this.btnRefreshWindow.Name = "btnRefreshWindow";
            this.btnRefreshWindow.Size = new System.Drawing.Size(96, 23);
            this.btnRefreshWindow.TabIndex = 97;
            this.btnRefreshWindow.Text = "Refresh Window";
            this.btnRefreshWindow.Click += new System.EventHandler(this.btnRefreshWindow_Click);
            // 
            // DestroyWindowButton
            // 
            this.DestroyWindowButton.Location = new System.Drawing.Point(45, 156);
            this.DestroyWindowButton.Name = "DestroyWindowButton";
            this.DestroyWindowButton.Size = new System.Drawing.Size(96, 23);
            this.DestroyWindowButton.TabIndex = 96;
            this.DestroyWindowButton.Text = "Destroy Window";
            this.DestroyWindowButton.Click += new System.EventHandler(this.DestroyWindowButton_Click);
            // 
            // WindowWidthTextBox
            // 
            this.WindowWidthTextBox.Location = new System.Drawing.Point(485, 124);
            this.WindowWidthTextBox.Name = "WindowWidthTextBox";
            this.WindowWidthTextBox.Size = new System.Drawing.Size(56, 20);
            this.WindowWidthTextBox.TabIndex = 95;
            this.WindowWidthTextBox.Text = "5";
            // 
            // WindowHeightTextBox
            // 
            this.WindowHeightTextBox.Location = new System.Drawing.Point(421, 124);
            this.WindowHeightTextBox.Name = "WindowHeightTextBox";
            this.WindowHeightTextBox.Size = new System.Drawing.Size(56, 20);
            this.WindowHeightTextBox.TabIndex = 94;
            this.WindowHeightTextBox.Text = "2";
            // 
            // ViewportWidthTextBox
            // 
            this.ViewportWidthTextBox.Location = new System.Drawing.Point(357, 124);
            this.ViewportWidthTextBox.Name = "ViewportWidthTextBox";
            this.ViewportWidthTextBox.Size = new System.Drawing.Size(56, 20);
            this.ViewportWidthTextBox.TabIndex = 93;
            this.ViewportWidthTextBox.Text = "3";
            // 
            // ViewportHeightTextBox
            // 
            this.ViewportHeightTextBox.Location = new System.Drawing.Point(293, 124);
            this.ViewportHeightTextBox.Name = "ViewportHeightTextBox";
            this.ViewportHeightTextBox.Size = new System.Drawing.Size(56, 20);
            this.ViewportHeightTextBox.TabIndex = 92;
            this.ViewportHeightTextBox.Text = "2";
            // 
            // ViewportColumnTextBox
            // 
            this.ViewportColumnTextBox.Location = new System.Drawing.Point(229, 124);
            this.ViewportColumnTextBox.Name = "ViewportColumnTextBox";
            this.ViewportColumnTextBox.Size = new System.Drawing.Size(56, 20);
            this.ViewportColumnTextBox.TabIndex = 91;
            this.ViewportColumnTextBox.Text = "3";
            // 
            // ViewportRowTextBox
            // 
            this.ViewportRowTextBox.Location = new System.Drawing.Point(165, 124);
            this.ViewportRowTextBox.Name = "ViewportRowTextBox";
            this.ViewportRowTextBox.Size = new System.Drawing.Size(56, 20);
            this.ViewportRowTextBox.TabIndex = 90;
            this.ViewportRowTextBox.Text = "0";
            // 
            // CreateWindowButton
            // 
            this.CreateWindowButton.Location = new System.Drawing.Point(45, 124);
            this.CreateWindowButton.Name = "CreateWindowButton";
            this.CreateWindowButton.Size = new System.Drawing.Size(96, 23);
            this.CreateWindowButton.TabIndex = 89;
            this.CreateWindowButton.Text = "Create Window";
            this.CreateWindowButton.Click += new System.EventHandler(this.CreateWindowButton_Click);
            // 
            // WidthComboBox
            // 
            this.WidthComboBox.Items.AddRange(new object[] {
            "actual"});
            this.WidthComboBox.Location = new System.Drawing.Point(188, 66);
            this.WidthComboBox.Name = "WidthComboBox";
            this.WidthComboBox.Size = new System.Drawing.Size(72, 21);
            this.WidthComboBox.TabIndex = 88;
            this.WidthComboBox.Text = "actual";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(429, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 87;
            this.label6.Text = "AlignY";
            // 
            // AlignYComboBox
            // 
            this.AlignYComboBox.Items.AddRange(new object[] {
            "Top",
            "Center",
            "Bottom"});
            this.AlignYComboBox.Location = new System.Drawing.Point(477, 68);
            this.AlignYComboBox.Name = "AlignYComboBox";
            this.AlignYComboBox.Size = new System.Drawing.Size(72, 21);
            this.AlignYComboBox.TabIndex = 86;
            this.AlignYComboBox.Text = "Top";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(285, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 85;
            this.label4.Text = "AlignX";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(149, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 84;
            this.label5.Text = "Width";
            // 
            // AlignXComboBox
            // 
            this.AlignXComboBox.Items.AddRange(new object[] {
            "Left",
            "Center",
            "Right"});
            this.AlignXComboBox.Location = new System.Drawing.Point(341, 68);
            this.AlignXComboBox.Name = "AlignXComboBox";
            this.AlignXComboBox.Size = new System.Drawing.Size(80, 21);
            this.AlignXComboBox.TabIndex = 83;
            this.AlignXComboBox.Text = "Left";
            // 
            // DisplayBitmapButton
            // 
            this.DisplayBitmapButton.Location = new System.Drawing.Point(45, 60);
            this.DisplayBitmapButton.Name = "DisplayBitmapButton";
            this.DisplayBitmapButton.Size = new System.Drawing.Size(96, 23);
            this.DisplayBitmapButton.TabIndex = 82;
            this.DisplayBitmapButton.Text = "Display Bitmap";
            this.DisplayBitmapButton.Click += new System.EventHandler(this.DisplayBitmapButton_Click);
            // 
            // ReadTextLabel
            // 
            this.ReadTextLabel.Location = new System.Drawing.Point(552, 20);
            this.ReadTextLabel.Name = "ReadTextLabel";
            this.ReadTextLabel.Size = new System.Drawing.Size(24, 23);
            this.ReadTextLabel.TabIndex = 81;
            // 
            // ReadTextButton
            // 
            this.ReadTextButton.Location = new System.Drawing.Point(429, 12);
            this.ReadTextButton.Name = "ReadTextButton";
            this.ReadTextButton.Size = new System.Drawing.Size(111, 23);
            this.ReadTextButton.TabIndex = 80;
            this.ReadTextButton.Text = "ReadCharAtCursor";
            this.ReadTextButton.Click += new System.EventHandler(this.ReadTextButton_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(285, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 79;
            this.label3.Text = "Direction";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(149, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 78;
            this.label2.Text = "Units";
            // 
            // Units
            // 
            this.Units.Location = new System.Drawing.Point(197, 92);
            this.Units.Name = "Units";
            this.Units.Size = new System.Drawing.Size(40, 20);
            this.Units.TabIndex = 77;
            this.Units.Text = "1";
            // 
            // cbScrollTextDirection
            // 
            this.cbScrollTextDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScrollTextDirection.Location = new System.Drawing.Point(341, 92);
            this.cbScrollTextDirection.Name = "cbScrollTextDirection";
            this.cbScrollTextDirection.Size = new System.Drawing.Size(80, 21);
            this.cbScrollTextDirection.TabIndex = 76;
            // 
            // ScrollButton
            // 
            this.ScrollButton.Location = new System.Drawing.Point(45, 92);
            this.ScrollButton.Name = "ScrollButton";
            this.ScrollButton.Size = new System.Drawing.Size(96, 23);
            this.ScrollButton.TabIndex = 75;
            this.ScrollButton.Text = "Scroll Text";
            this.ScrollButton.Click += new System.EventHandler(this.ScrollButton_Click);
            // 
            // ClearText
            // 
            this.ClearText.Location = new System.Drawing.Point(341, 12);
            this.ClearText.Name = "ClearText";
            this.ClearText.Size = new System.Drawing.Size(80, 23);
            this.ClearText.TabIndex = 74;
            this.ClearText.Text = "ClearText";
            this.ClearText.Click += new System.EventHandler(this.ClearText_Click);
            // 
            // LDText
            // 
            this.LDText.Location = new System.Drawing.Point(157, 12);
            this.LDText.Name = "LDText";
            this.LDText.Size = new System.Drawing.Size(80, 20);
            this.LDText.TabIndex = 73;
            this.LDText.Text = "0123456789";
            // 
            // DisplayText
            // 
            this.DisplayText.Location = new System.Drawing.Point(45, 12);
            this.DisplayText.Name = "DisplayText";
            this.DisplayText.Size = new System.Drawing.Size(96, 23);
            this.DisplayText.TabIndex = 72;
            this.DisplayText.Text = "Display Text";
            this.DisplayText.Click += new System.EventHandler(this.DisplayText_Click);
            // 
            // LineDisplayScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tbDescriptor);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.cbSetDescriptorAttribute);
            this.Controls.Add(this.btnSetDescriptor);
            this.Controls.Add(this.btnClearDescriptors);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.cbCursorType);
            this.Controls.Add(this.cbCursorUpdate);
            this.Controls.Add(this.SetBitmapcomboBox);
            this.Controls.Add(this.SetBitmapbutton);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.PosX);
            this.Controls.Add(this.PosY);
            this.Controls.Add(this.cbDisplayScreenModes);
            this.Controls.Add(this.cbMarqueeType);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbMarqueeRepeatWait);
            this.Controls.Add(this.tbMarqueeUnitWait);
            this.Controls.Add(this.cbMarqueeFormat);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbBlinkRate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbInterCharacterWait);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbDisplayTextAttribute);
            this.Controls.Add(this.WindowComboBox);
            this.Controls.Add(this.btnRefreshWindow);
            this.Controls.Add(this.DestroyWindowButton);
            this.Controls.Add(this.WindowWidthTextBox);
            this.Controls.Add(this.WindowHeightTextBox);
            this.Controls.Add(this.ViewportWidthTextBox);
            this.Controls.Add(this.ViewportHeightTextBox);
            this.Controls.Add(this.ViewportColumnTextBox);
            this.Controls.Add(this.ViewportRowTextBox);
            this.Controls.Add(this.CreateWindowButton);
            this.Controls.Add(this.WidthComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AlignYComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AlignXComboBox);
            this.Controls.Add(this.DisplayBitmapButton);
            this.Controls.Add(this.ReadTextLabel);
            this.Controls.Add(this.ReadTextButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Units);
            this.Controls.Add(this.cbScrollTextDirection);
            this.Controls.Add(this.ScrollButton);
            this.Controls.Add(this.ClearText);
            this.Controls.Add(this.LDText);
            this.Controls.Add(this.DisplayText);
            this.Name = "LineDisplayScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDescriptor;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.ComboBox cbSetDescriptorAttribute;
        private System.Windows.Forms.Button btnSetDescriptor;
        private System.Windows.Forms.Button btnClearDescriptors;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.ComboBox cbCursorType;
        private System.Windows.Forms.CheckBox cbCursorUpdate;
        private System.Windows.Forms.ComboBox SetBitmapcomboBox;
        private System.Windows.Forms.Button SetBitmapbutton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox PosX;
        private System.Windows.Forms.TextBox PosY;
        private System.Windows.Forms.ComboBox cbDisplayScreenModes;
        private System.Windows.Forms.ComboBox cbMarqueeType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbMarqueeRepeatWait;
        private System.Windows.Forms.TextBox tbMarqueeUnitWait;
        private System.Windows.Forms.ComboBox cbMarqueeFormat;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbBlinkRate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbInterCharacterWait;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbDisplayTextAttribute;
        private System.Windows.Forms.ComboBox WindowComboBox;
        private System.Windows.Forms.Button btnRefreshWindow;
        private System.Windows.Forms.Button DestroyWindowButton;
        private System.Windows.Forms.TextBox WindowWidthTextBox;
        private System.Windows.Forms.TextBox WindowHeightTextBox;
        private System.Windows.Forms.TextBox ViewportWidthTextBox;
        private System.Windows.Forms.TextBox ViewportHeightTextBox;
        private System.Windows.Forms.TextBox ViewportColumnTextBox;
        private System.Windows.Forms.TextBox ViewportRowTextBox;
        private System.Windows.Forms.Button CreateWindowButton;
        private System.Windows.Forms.ComboBox WidthComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox AlignYComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox AlignXComboBox;
        private System.Windows.Forms.Button DisplayBitmapButton;
        private System.Windows.Forms.Label ReadTextLabel;
        private System.Windows.Forms.Button ReadTextButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Units;
        private System.Windows.Forms.ComboBox cbScrollTextDirection;
        private System.Windows.Forms.Button ScrollButton;
        private System.Windows.Forms.Button ClearText;
        private System.Windows.Forms.TextBox LDText;
        private System.Windows.Forms.Button DisplayText;
    }
}
