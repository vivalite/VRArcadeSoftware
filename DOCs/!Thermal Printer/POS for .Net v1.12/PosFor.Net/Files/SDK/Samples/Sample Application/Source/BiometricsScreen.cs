using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.PointOfService;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace TestApplication
{
    public partial class BiometricsScreen : TestApplication.DeviceScreenBase
    {
        Biometrics _biometrics;
        public BiometricsScreen()
        {
            InitializeComponent();

            pbImageData.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public override void SetOpened(bool opened)
        {
            if (_biometrics == null)
            {
                _biometrics = (Biometrics)PosCommon;
                _biometrics.DataEvent += new DataEventHandler(_biometrics_DataEvent);
                _biometrics.StatusUpdateEvent += new StatusUpdateEventHandler(_biometrics_StatusUpdateEvent);
            }

            if (opened)
                UpdateUI();
        }

        void _biometrics_StatusUpdateEvent(object sender, StatusUpdateEventArgs e)
        {
            string text = "unknown";
            switch (e.Status)
            {
                case Biometrics.StatusMoveAway:
                    text = "Move away";
                    break;
                case Biometrics.StatusMoveBackward:
                    text = "Move backward";
                    break;
                case Biometrics.StatusMoveCloser:
                    text = "Move closer";
                    break;
                case Biometrics.StatusMoveDown:
                    text = "Move down";
                    break;
                case Biometrics.StatusMoveForward:
                    text = "Move forward";
                    break;
                case Biometrics.StatusMoveLeft:
                    text = "Move left";
                    break;
                case Biometrics.StatusMoveRight:
                    text = "Move right";
                    break;
                case Biometrics.StatusMoveUp:
                    text = "Move up";
                    break;
                case Biometrics.StatusRawData:
                    text = "Raw Data Available";
                    pbImageData.Image = _biometrics.RawSensorData;
                    break;

                case Biometrics.StatusMoveFaster:
                    text = "Move Faster";
                    break;

                case Biometrics.StatusMoveSlower:
                    text = "Move Slower";
                    break;

                case Biometrics.StatusSensorDirty:
                    text = "The sensor is dirty and should be cleaned";
                    break;

                case Biometrics.StatusUnspecifiedReadFailure:
                    text = "Unable to capture data from the sensor, please retry the operation.";
                    break;

                case Biometrics.StatusSensorReady:
                    text = "Please swipe finger now.";
                    break;

                case Biometrics.StatusSensorComplete:
                    text = "Scan complete.";
                    break;


                default:
                    throw new ArgumentException("Unexpected status code: " + e.Status.ToString());

            }
            if (e.Status != Biometrics.StatusRawData)
                lblStatusText.Text = text;


            DisplayMessage("Status: " + text);
        }

        void _biometrics_DataEvent(object sender, DataEventArgs e)
        {
            if (e.Status == Biometrics.DataEventEnroll)
            {
                string str = "Bir stored for user: " + tbUserName.Text + " Finger: " + cbFinger.Text + "\r\n";
                AddBir(tbUserName.Text, cbFinger.Text, _biometrics.ToString(), _biometrics.BiometricsInformationRecord);
                lblStatusText.Text = "Bir stored for user: " + tbUserName.Text + " Finger: " + cbFinger.Text;
            }
        }

        private void UpdateUI()
        {
            
            if (_biometrics.CapRealTimeData)
                _biometrics.RealTimeDataEnabled = true;

            LoadBirs();
            pbImageData.Image = null;

            chkBoxAdaptBir.Enabled = _biometrics.CapTemplateAdaptation;
            if (!_biometrics.CapTemplateAdaptation)
                chkBoxAdaptBir.Checked = false;

            if (cbFinger.SelectedIndex == -1)
                cbFinger.SelectedIndex = 6;
        }

        List<StoredBir> Birs = new List<StoredBir>();
        [Serializable()]
        public class StoredBir : BiometricsInformationRecord, IXmlSerializable
        {
            private string _name;
            private string _finger;
            private string _ServiceObject;

            // For Xml Serialization
            private StoredBir() { }

            public StoredBir(string name, string finger, string serviceObject, BiometricsInformationRecord bir)
                : base(bir)
            {
                _name = name;
                _finger = finger;
                _ServiceObject = serviceObject;
            }

            public string Name
            {
                get { return _name; }
            }
            public string Finger
            {
                get { return _finger; }
            }
            public string ServiceObject
            {
                get { return _ServiceObject; }
            }

            public override string ToString()
            {
                return _name + "_" + _finger;
            }

            public new void ReadXml(System.Xml.XmlReader reader)
            {
                if (null == reader)
                    throw new ArgumentNullException("reader");

                reader.ReadStartElement();

                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    switch (reader.LocalName)
                    {
                        case "Finger":
                            _finger = reader.ReadElementContentAsString();
                            break;
                        case "Name":
                            _name = reader.ReadElementContentAsString();
                            break;
                        case "ServiceObject":
                            _ServiceObject = reader.ReadElementContentAsString();
                            break;
                        case "BaseClassData":
                            base.ReadXml(reader);
                            break;
                        default:
                            throw new Exception("Unexpected element in xml");
                    }
                }
                reader.ReadEndElement();
            }

            public new void WriteXml(System.Xml.XmlWriter writer)
            {
                if (null == writer)
                    return;

                writer.WriteElementString("Finger", _finger);
                writer.WriteElementString("Name", _name);
                writer.WriteElementString("ServiceObject", _ServiceObject);

                // Serialize the base class into its own element
                writer.WriteStartElement("BaseClassData");
                base.WriteXml(writer);
                writer.WriteEndElement();
            }
        }




        private void btnBeginEnrollCapture_Click(object sender, EventArgs e)
        {
            try
            {
                _biometrics.BeginEnrollCapture(null, null);
                //lblStatusText.Text = "Please swipe finger";
                pbImageData.Image = null;
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnEndCapt_Click(object sender, EventArgs e)
        {
            try
            {
                _biometrics.EndCapture();

                pbImageData.Image = null;
                lblStatusText.Text = "Capture cancelled.";
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private IEnumerable<BiometricsInformationRecord> BirIterator(string serviceObject)
        {
            foreach (StoredBir bir in Birs)
            {
                if (bir.ServiceObject == serviceObject)
                    yield return bir;
            }
        }


        private void btnIdentify_Click(object sender, EventArgs e)
        {
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                
                //lblStatusText.Text = "Please swipe finger";
                pbImageData.Image = null;

                lblStatusText.Update();
                pbImageData.Update();


                // get a list of the birs for this service object
                List<BiometricsInformationRecord> birs = new List<BiometricsInformationRecord>(BirIterator(_biometrics.ToString()));
                int maxFAR = 0;
                int maxFRR = 0;
                if (rbUseFAR.Checked)
                    maxFAR = int.Parse(tbRate.Text);
                else
                    maxFRR = int.Parse(tbRate.Text);

                int[] order = _biometrics.Identify(maxFAR, maxFRR, rbUseFAR.Checked, birs, int.Parse(tbBioTimeout.Text));

                string identifiedAs = "No Match found.";
                if (order != null && order.Length > 0)
                {
                    identifiedAs = birs[order[0]].ToString();
                }

                lblStatusText.Text = "Identified as: " + identifiedAs;
                DisplayMessage("Identified as: " + identifiedAs);
                
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

        private void btnVerify_Click(object sender, EventArgs e)
        {
            Cursor old = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                
                //lblStatusText.Text = "Please swipe finger";
                pbImageData.Image = null;

                StoredBir sb = (StoredBir)lbBirs.SelectedItem;
                bool adaptBIR = chkBoxAdaptBir.Checked;

                int maxFAR = 0;
                int maxFRR = 0;
                if (rbUseFAR.Checked)
                    maxFAR = int.Parse(tbRate.Text);
                else
                    maxFRR = int.Parse(tbRate.Text);
                BiometricsVerifyResult result = _biometrics.Verify(maxFAR, maxFRR, rbUseFAR.Checked, sb, adaptBIR, int.Parse(tbBioTimeout.Text));

                string status = "Verification failed for: " + sb.ToString();
                if (result.Result == true)
                {
                    lblStatusText.Text = "Verified as: " + sb.ToString();
                    DisplayMessage("Verification succeeded for: " + sb.ToString() + "\r\n" +
                        "FalseAcceptRateAchieved: " + result.FalseAcceptRateAchieved + "\r\n" +
                        "FalseRejectRateAchieved: " + result.FalseRejectRateAchieved);

                    // save updated bir
                    if (adaptBIR && result.AdaptedBir != null)
                    {
                        StoredBir newBir = new StoredBir(sb.Name, sb.Finger, _biometrics.ToString(), result.AdaptedBir);

                        Birs.Remove(sb);
                        lbBirs.Items.Remove(sb);

                        Birs.Add(newBir);
                        lbBirs.SelectedIndex = lbBirs.Items.Add(newBir);

                        SaveBirs();

                        DisplayMessage("Saved adapted BIR.");
                    }
                }
                else
                {
                    lblStatusText.Text = "Verification failed for: " + sb.ToString();
                    if (result == null)
                    {
                        DisplayMessage("Verification failed for: " + sb.ToString());
                    }
                    else
                    {
                        DisplayMessage("Verification failed for: " + sb.ToString() + "\r\n" +
                        "FalseAcceptRateAchieved: " + result.FalseAcceptRateAchieved + "\r\n" +
                        "FalseRejectRateAchieved: " + result.FalseRejectRateAchieved);
                    }
                }
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

        private void AddBir(string userName, string finger, string serviceObject, BiometricsInformationRecord bir)
        {
            try
            {
                StoredBir sb = new StoredBir(userName, finger, serviceObject, bir);
                Birs.Add(sb);
                lbBirs.Items.Add(sb);
                SaveBirs();
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnDeleteBir_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbBirs.SelectedIndex >= 0)
                {
                    StoredBir sb = (StoredBir)lbBirs.SelectedItem;
                    lbBirs.Items.Remove(sb);
                    Birs.Remove(sb);

                    SaveBirs();
                }
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private const string SaveBirsFileName = "SavedBirs.xml";

        private void SaveBirs()
        {
            if (File.Exists(SaveBirsFileName))
                File.Delete(SaveBirsFileName);


            using (FileStream fs = File.OpenWrite(SaveBirsFileName))
            {

                XmlSerializer serializer = new XmlSerializer(Birs.GetType());
                serializer.Serialize(fs, Birs);
            }
        }

        private void LoadBirs()
        {
            
            try
            {
                lbBirs.SuspendLayout();
                lbBirs.Items.Clear();
                using (FileStream fs = File.OpenRead(SaveBirsFileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<StoredBir>));

                    Birs = serializer.Deserialize(fs) as List<StoredBir>;

                    foreach (StoredBir bir in Birs)
                    {
                        if (bir.ServiceObject == _biometrics.ToString())
                            lbBirs.Items.Add(bir);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                // eat these
                Birs = new List<StoredBir>();
            }
            finally
            {
                lbBirs.ResumeLayout(true);
            }
        
        }



    }
}

