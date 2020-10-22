// This is a part of the Microsoft POS for .NET SDK
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This sample source code is only intended as a 
// supplement to the POS for .NET SDK and related 
// electronic documentation provided with the library.

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.PointOfService;
using System.Xml;

namespace TestApplication
{
	/// <summary>
	/// Summary description for StatisticsForm.
	/// </summary>
	public class StatisticsForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public StatisticsForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		private PosCommon co;
		public StatisticsForm(PosCommon co)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			UpdateState();

			this.co = co;

            RetrieveStatistics(new string[] { "" });
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
				co = null;
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
			this.label1 = new System.Windows.Forms.Label();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name(s):";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(16, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(72, 24);
			this.radioButton1.TabIndex = 1;
			this.radioButton1.Text = "Reset";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.Checked = true;
			this.radioButton2.Location = new System.Drawing.Point(96, 16);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(72, 24);
			this.radioButton2.TabIndex = 2;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Retrieve";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(192, 16);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(80, 24);
			this.radioButton3.TabIndex = 3;
			this.radioButton3.Text = "Update";
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(96, 48);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(424, 20);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Value(s):";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(96, 80);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(424, 20);
			this.textBox2.TabIndex = 6;
			this.textBox2.Text = "";
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(16, 120);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox3.Size = new System.Drawing.Size(504, 168);
			this.textBox3.TabIndex = 7;
			this.textBox3.Text = "";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(448, 16);
			this.button1.Name = "button1";
			this.button1.TabIndex = 8;
			this.button1.Text = "Go";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// StatisticsForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 309);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.radioButton3);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.label1);
			this.Name = "StatisticsForm";
			this.Text = "Statistics Viewer";
			this.ResumeLayout(false);

		}
		#endregion

		private void ShowException(Exception e)
		{
			Exception inner = e.InnerException;
			if (inner != null)
			{
				ShowException(inner);
			}

			string str = textBox3.Text;
			if (e is PosControlException)
			{
				PosControlException pe = (PosControlException) e;

				textBox3.Text = "POSControlException ErrorCode(" + pe.ErrorCode.ToString() + ") ExtendedErrorCode(" + pe.ErrorCodeExtended.ToString() + ") occurred: " + pe.Message + "\r\n" + str;
			}
			else
			{
				textBox3.Text = e.ToString() + "\r\n" + str;
			}
		}

        void RetrieveStatistics(string [] stats)
        {
            try
            {
                string str = "";
                XmlDocument xml = new XmlDocument();
                string xmlString = "";
                xmlString = co.RetrieveStatistics(stats);
                if (xmlString.Length == 0)
                {
                    textBox3.Text = "No Statistics are defined for this device.\r\n" + str;
                    return;
                }
                xml.LoadXml(xmlString);


                XmlNode root = xml.DocumentElement;

                // find the Equipment node
                foreach (XmlNode Node in root.ChildNodes)
                {
                    if (Node.Name == "Equipment")
                    {
                        str += "Device information statistics:\r\n";
                        foreach (XmlElement xe in Node.ChildNodes)
                        {
                            if (xe.Name == "DeviceCategory")
                                str += "   " + xe.Name + " = " + xe.GetAttribute("UPOS") + "\r\n";
                            else
                                str += "   " + xe.Name + " = " + xe.InnerText + "\r\n";
                        }
                    }

                    if (Node.Name == "Event")
                    {
                        str += "Device statistics:\r\n";
                        foreach (XmlNode EventNode in Node.ChildNodes)
                        {
                            if (EventNode.Name == "Parameter")
                            {
                                string Name = "", Value = "";
                                foreach (XmlNode x in EventNode.ChildNodes)
                                {
                                    if (x.Name == "Name")
                                        Name = x.InnerText;

                                    if (x.Name == "Value")
                                        Value = x.InnerText;
                                }
                                str += "   " + Name + " = " + Value + "\r\n";
                            }
                        }

                        str += "Manufacturer specific device statistics:\r\n";
                        foreach (XmlNode EventNode in Node.ChildNodes)
                        {
                            if (EventNode.Name == "ManufacturerSpecific")
                            {
                                string Name = "", Value = "", UnitOfMeasure = "";
                                foreach (XmlNode x in EventNode.ChildNodes)
                                {
                                    if (x.Name == "Name")
                                        Name = x.InnerText;

                                    if (x.Name == "Value")
                                        Value = x.InnerText;

                                    if (x.Name == "unitofmeasure")
                                        UnitOfMeasure = x.InnerText;
                                }
                                str += "   " + Name + " = " + Value + " " + UnitOfMeasure + "\r\n";
                            }
                        }
                    }
                }
                textBox3.Text = str;// + str2;
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

		private void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				string [] stats = textBox1.Text.Split(",".ToCharArray());

				if (radioButton1.Checked)
				{
					co.ResetStatistics(stats);
				}
				else if (radioButton3.Checked)
				{
					string [] vals = textBox2.Text.Split(",".ToCharArray());

					if (vals.Length != stats.Length)
					{
						MessageBox.Show("The number of statistics does not match the number of values.");
						return;
					}

					Statistic [] statistics = new Statistic[stats.Length];
					for (int i=0; i<stats.Length; i++)
					{
						statistics[i] = new Statistic(stats[i], vals[i]);
					}
					co.UpdateStatistics(statistics);
				}

                RetrieveStatistics(stats);
			}
			catch (Exception ae)
			{
				ShowException(ae);
			}
		}

		private void UpdateState()
		{
			textBox2.Enabled = radioButton3.Checked;
			label2.Enabled = radioButton3.Checked;
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateState();
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateState();
		}

		private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateState();
		}
	}
}
