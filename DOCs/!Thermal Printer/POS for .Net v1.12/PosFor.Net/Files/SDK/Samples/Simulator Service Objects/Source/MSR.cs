// This is a part of the Microsoft POS for .NET SDK
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This sample source code is only intended as a 
// supplement to the POS for .NET SDK and related 
// electronic documentation provided with the library.

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Text;
using Microsoft.PointOfService.BaseServiceObjects;
using Microsoft.PointOfService.ExampleServiceObjects;
using System.Collections.Generic;

namespace Microsoft.PointOfService.DeviceSimulators
{
	
	#region MsrSimulatorWindow Class
	internal class MsrSimulatorWindow : SimulatorBase
    {
        private System.Windows.Forms.TextBox tb1;
		private System.Windows.Forms.TextBox tb2;
		private System.Windows.Forms.TextBox tb3;
		private System.Windows.Forms.TextBox tb4;
		private System.Windows.Forms.TextBox tb5;
		private System.Windows.Forms.TextBox tb6;
		private System.Windows.Forms.TextBox tb7;
		private System.Windows.Forms.TextBox tb8;
		private System.Windows.Forms.Button SwipeCardButton;
		private System.Windows.Forms.Button FailedSwipeButton;
        private TextBox tb9;
        private TextBox tb10;
        private TextBox tb11;
        private TextBox tb12;
        private TextBox tb13;
        private TextBox tb16;
        private TextBox tb15;
        private TextBox tb14;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private GroupBox groupBox1;
        private Label label17;
        private Label label18;
        private TextBox tb17;
        private TextBox tb18;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		

		public MsrSimulatorWindow(MsrSimulator serviceObject) : base(serviceObject)
		{
			Invoke(new MethodDelegate(InitializeComponent));
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsrSimulatorWindow));
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.tb5 = new System.Windows.Forms.TextBox();
            this.tb6 = new System.Windows.Forms.TextBox();
            this.tb7 = new System.Windows.Forms.TextBox();
            this.tb8 = new System.Windows.Forms.TextBox();
            this.SwipeCardButton = new System.Windows.Forms.Button();
            this.FailedSwipeButton = new System.Windows.Forms.Button();
            this.tb9 = new System.Windows.Forms.TextBox();
            this.tb10 = new System.Windows.Forms.TextBox();
            this.tb11 = new System.Windows.Forms.TextBox();
            this.tb12 = new System.Windows.Forms.TextBox();
            this.tb13 = new System.Windows.Forms.TextBox();
            this.tb16 = new System.Windows.Forms.TextBox();
            this.tb15 = new System.Windows.Forms.TextBox();
            this.tb14 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tb17 = new System.Windows.Forms.TextBox();
            this.tb18 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb1
            // 
            resources.ApplyResources(this.tb1, "tb1");
            this.tb1.Name = "tb1";
            // 
            // tb2
            // 
            resources.ApplyResources(this.tb2, "tb2");
            this.tb2.Name = "tb2";
            // 
            // tb3
            // 
            resources.ApplyResources(this.tb3, "tb3");
            this.tb3.Name = "tb3";
            // 
            // tb4
            // 
            resources.ApplyResources(this.tb4, "tb4");
            this.tb4.Name = "tb4";
            // 
            // tb5
            // 
            resources.ApplyResources(this.tb5, "tb5");
            this.tb5.Name = "tb5";
            // 
            // tb6
            // 
            resources.ApplyResources(this.tb6, "tb6");
            this.tb6.Name = "tb6";
            // 
            // tb7
            // 
            this.tb7.AcceptsReturn = true;
            resources.ApplyResources(this.tb7, "tb7");
            this.tb7.Name = "tb7";
            // 
            // tb8
            // 
            resources.ApplyResources(this.tb8, "tb8");
            this.tb8.Name = "tb8";
            // 
            // SwipeCardButton
            // 
            resources.ApplyResources(this.SwipeCardButton, "SwipeCardButton");
            this.SwipeCardButton.Name = "SwipeCardButton";
            this.SwipeCardButton.Click += new System.EventHandler(this.SwipeCardButton_Click);
            // 
            // FailedSwipeButton
            // 
            resources.ApplyResources(this.FailedSwipeButton, "FailedSwipeButton");
            this.FailedSwipeButton.Name = "FailedSwipeButton";
            this.FailedSwipeButton.Click += new System.EventHandler(this.FailedSwipeButton_Click);
            // 
            // tb9
            // 
            this.tb9.AcceptsTab = true;
            resources.ApplyResources(this.tb9, "tb9");
            this.tb9.Name = "tb9";
            // 
            // tb10
            // 
            this.tb10.AcceptsTab = true;
            resources.ApplyResources(this.tb10, "tb10");
            this.tb10.Name = "tb10";
            // 
            // tb11
            // 
            this.tb11.AcceptsTab = true;
            resources.ApplyResources(this.tb11, "tb11");
            this.tb11.Name = "tb11";
            // 
            // tb12
            // 
            this.tb12.AcceptsTab = true;
            resources.ApplyResources(this.tb12, "tb12");
            this.tb12.Name = "tb12";
            // 
            // tb13
            // 
            this.tb13.AcceptsReturn = true;
            resources.ApplyResources(this.tb13, "tb13");
            this.tb13.Name = "tb13";
            // 
            // tb16
            // 
            resources.ApplyResources(this.tb16, "tb16");
            this.tb16.Name = "tb16";
            // 
            // tb15
            // 
            resources.ApplyResources(this.tb15, "tb15");
            this.tb15.Name = "tb15";
            // 
            // tb14
            // 
            this.tb14.AcceptsReturn = true;
            resources.ApplyResources(this.tb14, "tb14");
            this.tb14.Name = "tb14";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Checked = true;
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // tb17
            // 
            resources.ApplyResources(this.tb17, "tb17");
            this.tb17.Name = "tb17";
            // 
            // tb18
            // 
            resources.ApplyResources(this.tb18, "tb18");
            this.tb18.Name = "tb18";
            // 
            // MsrSimulatorWindow
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tb17);
            this.Controls.Add(this.tb18);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb14);
            this.Controls.Add(this.tb15);
            this.Controls.Add(this.tb16);
            this.Controls.Add(this.tb13);
            this.Controls.Add(this.tb12);
            this.Controls.Add(this.tb11);
            this.Controls.Add(this.tb10);
            this.Controls.Add(this.tb9);
            this.Controls.Add(this.tb8);
            this.Controls.Add(this.tb7);
            this.Controls.Add(this.tb6);
            this.Controls.Add(this.tb5);
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.FailedSwipeButton);
            this.Controls.Add(this.SwipeCardButton);
            this.Name = "MsrSimulatorWindow";
            this.Shown += new System.EventHandler(this.MsrSimulatorWindow_Shown);
            this.Controls.SetChildIndex(this.SwipeCardButton, 0);
            this.Controls.SetChildIndex(this.FailedSwipeButton, 0);
            this.Controls.SetChildIndex(this.tb1, 0);
            this.Controls.SetChildIndex(this.tb2, 0);
            this.Controls.SetChildIndex(this.tb3, 0);
            this.Controls.SetChildIndex(this.tb4, 0);
            this.Controls.SetChildIndex(this.tb5, 0);
            this.Controls.SetChildIndex(this.tb6, 0);
            this.Controls.SetChildIndex(this.tb7, 0);
            this.Controls.SetChildIndex(this.tb8, 0);
            this.Controls.SetChildIndex(this.tb9, 0);
            this.Controls.SetChildIndex(this.tb10, 0);
            this.Controls.SetChildIndex(this.tb11, 0);
            this.Controls.SetChildIndex(this.tb12, 0);
            this.Controls.SetChildIndex(this.tb13, 0);
            this.Controls.SetChildIndex(this.tb16, 0);
            this.Controls.SetChildIndex(this.tb15, 0);
            this.Controls.SetChildIndex(this.tb14, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.tb18, 0);
            this.Controls.SetChildIndex(this.tb17, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        void MsrSimulatorWindow_Shown(object sender, EventArgs e)
        {
            UpdateCardProps();
        }
		#endregion
		

		private void SwipeCardButton_Click(object sender, System.EventArgs e)
		{
            MsrSimulator MSRSim = ServiceObjectReference.Target as MsrSimulator;
            if (MSRSim != null)
            {
                if (radioButton1.Checked)
                {
                    string Track1Data = "%" + FixedLength("B" + tb1.Text + "^" + tb7.Text + "/" + tb3.Text + " " + tb4.Text + "." + tb8.Text + "^" + tb2.Text + tb5.Text, 76, '0') + "?";
                    string Track2Data = ";" + FixedLength(tb1.Text + "=" + tb2.Text + tb5.Text, 37, '0') + "?";
                    MSRSim.OnCardSwipe(MSRSim.StringToByteArray(Track1Data), 
                        MSRSim.StringToByteArray(Track2Data), null, null, CardType.Iso);
                }
                else
                {
                    string city = VariableLength(tb17.Text, 15, '^');
                    string name = VariableLength(tb15.Text + '$' + tb6.Text + '$' + tb14.Text, 35, '^');
                    string address = FixedLength(tb1.Text, 77 - (city.Length + name.Length), ' ');

                    string Track1Data = "%" + FixedLength(tb13.Text, 2, ' ') + city + name + address + "?";

                    string licnum = tb10.Text;
                    string licnum1 = licnum, licnum2 = "=";
                    if (licnum.Length > 13)
                    {
                        licnum1 = licnum.Substring(0, 13);
                        licnum2 = licnum.Substring(13);
                        if (licnum2.Length > 5)
                            licnum2 = licnum2.Substring(0, 5);
                    }
                    string Track2Data = ";636010" + licnum1 + "=" + FixedLength(tb4.Text, 4, ' ') + FixedLength(tb2.Text, 8, ' ') + licnum2 + "?";
                    
                    
                    string Track3Data = "%00" + FixedLength(tb11.Text, 11, ' ') + FixedLength(tb18.Text, 2, ' ') + FixedLength(tb12.Text, 10, ' ') + FixedLength(tb3.Text, 4, ' ') + FixedLength(tb7.Text, 1, '1') + FixedLength(tb9.Text, 3, ' ') + FixedLength(tb16.Text, 3, ' ') + FixedLength(tb8.Text, 3, ' ') + FixedLength(tb5.Text, 3, ' ') + "?";


                    MSRSim.OnCardSwipe(MSRSim.StringToByteArray(Track1Data), 
                        MSRSim.StringToByteArray(Track2Data), 
                        MSRSim.StringToByteArray(Track3Data), 
                        null, CardType.Aamva);
                }
            }
		}

		private void FailedSwipeButton_Click(object sender, System.EventArgs e)
		{
			MsrSimulator MSRSim = ServiceObjectReference.Target as MsrSimulator;
			if (MSRSim != null)
				MSRSim.OnCardSwipeFailed();

		}


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCardProps();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCardProps();
        }

        void UpdateCardProps()
        {
            tb9.Visible = tb10.Visible = tb11.Visible = tb12.Visible = tb13.Visible = tb14.Visible = radioButton2.Checked;
            tb15.Visible = tb16.Visible = tb17.Visible = tb18.Visible = radioButton2.Checked;
            if (radioButton1.Checked)
            {
                label1.Text = "AccountNumber";
                label2.Text = "ExpirationDate";
                label3.Text = "FirstName";
                label4.Text = "MiddleInitial";
                label5.Text = "ServiceCode";
                label6.Text = "Suffix";
                label7.Text = "Surname";
                label8.Text = "Title";
                label9.Text = "";
                label10.Text = "";
                label11.Text = "";
                label12.Text = "";
                label13.Text = "";
                label14.Text = "";
                label15.Text = "";
                label16.Text = "";
                label17.Text = "";
                label18.Text = "";
            }
            else
            {
                label1.Text = "Address";
                label2.Text = "BirthDate";
                label3.Text = "Endorsements";
                label4.Text = "ExpirationDate";
                label5.Text = "EyeColor";
                label6.Text = "FirstName";
                label7.Text = "Gender";
                label8.Text = "HairColor";
                label9.Text = "Height";
                label10.Text = "LicenseNumber";
                label11.Text = "PostalCode";
                label12.Text = "Restrictions";
                label13.Text = "State";
                label14.Text = "Suffix";
                label15.Text = "Surname";
                label16.Text = "Weight";
                label17.Text = "City";
                label18.Text = "Class";
            }
        }


        static string FixedLength(string data, int len, char fillChar)
        {
            StringBuilder sb = new StringBuilder(len);
            sb.Append(fillChar, len);

            if (data!=null)
            {
                for (int i=0; i<data.Length&&i<len; i++)
                    sb[i] = data[i];
            }

            return sb.ToString();
        }

        static string VariableLength(string data, int maxLen, char truncChar)
        {
            if (String.IsNullOrEmpty(data))
                return truncChar.ToString();

            if (data.Length < maxLen)
                return data + truncChar.ToString();

            return data.Substring(0, maxLen);
        }

	}

	#endregion

	#region MsrSimulator Class
	[ServiceObjectAttribute(	DeviceType.Msr, 
								"Microsoft Msr Simulator",
                               "Simulated service object for magnetic stripe reader", 1, 12)]
	public class MsrSimulator : MsrBase
	{
		private MsrSimulatorWindow Window;
				
		public MsrSimulator()
		{
			// This is a non-Pnp device so we must set its device path here
			DevicePath = "Microsoft Msr Simulator";
			Properties.CapIso = true;
			Properties.CapTransmitSentinels = true;
			Properties.DeviceDescription = "Microsoft Msr Simulator";
            Properties.CardTypeList = new List<string>(new string[] { CardTypeAamva, CardTypeBank });
		}

		~MsrSimulator()
		{
			Dispose(false);
		}

        

		protected override MsrFieldData ParseMsrFieldData(byte[] track1Data, byte[] track2Data, byte[] track3Data, byte[] track4Data, CardType cardType)
		{
			string Track1Data = ByteArrayToString(RemoveSentinels(track1Data, '%', '?'));
			string Track2Data = ByteArrayToString(RemoveSentinels(track2Data, ';', '?'));
            string Track3Data = ByteArrayToString(RemoveSentinels(RemoveSentinels(track3Data, '%', '?'), ';', '?'));
            

			// Parse Iso data
            if (cardType == Microsoft.PointOfService.BaseServiceObjects.CardType.Iso)
                return MsrDataParser.ParseIsoData(Track1Data, Track2Data);
            else
                return MsrDataParser.ParseAamvaData(Track1Data, Track2Data, Track3Data);
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

                // ISO sentinels are differnt than AAMVA
    		    data.Track3Data = RemoveSentinels(RemoveSentinels(track3Data, ';', '?'), '%', '?'); ;
			}
			data.Track4Data = null;

			return data;

		}
		private byte[] RemoveSentinels(byte [] trackData, char startSentinel, char endSentinel)
		{
			if (trackData == null)
				return new byte[0];

			byte [] ReturnArray = null;
			if (trackData.Length > 2 && trackData[0] == Convert.ToByte(startSentinel) && trackData[trackData.Length-1] == Convert.ToByte(endSentinel))
			{
				ReturnArray = new byte[trackData.Length-2];
				Array.Copy(trackData, 1, ReturnArray, 0, ReturnArray.Length);
			}
			else
			{
				ReturnArray = (byte[]) trackData.Clone();
			}

			return ReturnArray;
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
			SetStatisticValue(StatisticModelName, "Msr Simulator");
			SetStatisticValue(StatisticMechanicalRevision, "1.0");
			SetStatisticValue(StatisticInterface, "Other");

			// show simulation window
			Window = new MsrSimulatorWindow(this);
		}

		private string ByteArrayToString(byte[] data)
		{
            return ASCIIEncoding.ASCII.GetString(data);
		}


		protected internal byte[] StringToByteArray(string source)
		{
            return ASCIIEncoding.ASCII.GetBytes(source);
		}



        public void OnCardSwipe(byte[] track1Data)
		{
            GoodRead(track1Data, null, null, null, Microsoft.PointOfService.BaseServiceObjects.CardType.Iso);
		}

        public void OnCardSwipe(byte[] track1Data, byte[] track2Data, byte[] track3Data, byte[] track4Data, Microsoft.PointOfService.BaseServiceObjects.CardType cardType)
        {
            GoodRead(track1Data, track2Data, track3Data, track4Data, cardType);
        }

		public void OnCardSwipeFailed()
		{
            FailedRead(null, null, null, null, Microsoft.PointOfService.BaseServiceObjects.CardType.Unknown, ErrorCode.Failure, 0);
		}


		protected override void Dispose(bool disposing)
		{
			try
			{
				if(disposing)
				{
					Logger.Info("MsrSimulator", "Disposing class: " + this.ToString());
					// Release the managed resources you added in
					// this derived class here.
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
	}
	
	#endregion
}
