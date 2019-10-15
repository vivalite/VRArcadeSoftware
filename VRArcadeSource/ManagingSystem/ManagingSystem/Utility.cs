using IntelliLock.Licensing;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Telerik.WinControls.UI;
using VRGameSelectorServerDTO;

namespace ManagingSystem
{
    public static class Utility
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Dictionary<string, string> _systemConfigs;

        public static DialogResult InputBox(this Form f, string title, string promptText, ref string value)
        {
            RadForm form = new RadForm();
            RadLabel label = new RadLabel();
            RadTextBox textBox = new RadTextBox();
            RadButton buttonOk = new RadButton();
            RadButton buttonCancel = new RadButton();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 18, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private static void InitCoreConfig()
        {
            if (!InitCoreConfigInternal(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\VRArcade\ManagingSystem\config.xml"))
            {
                InitCoreConfigInternal(Application.StartupPath + @"\config.xml");
            }
        }

        private static bool InitCoreConfigInternal(string cfgPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            bool ret = false;

            try
            {
                xmlDoc.Load(cfgPath);
                XmlNodeList systemList = xmlDoc.GetElementsByTagName("System");

                _systemConfigs = new Dictionary<string, string>();

                foreach (XmlNode systemNode in systemList)
                {
                    foreach (XmlNode configNode in systemNode.ChildNodes)
                    {
                        _systemConfigs.Add(configNode.Name, configNode.InnerText);
                        ret = true;
                    }

                }
            }
            catch
            {

            }
            return ret;
        }


        public static string GetCoreConfig(string key)
        {
            string value = "";

            if (_systemConfigs == null)
            {
                InitCoreConfig();
            }

            _systemConfigs.TryGetValue(key, out value);

            return value;
        }

        public static void InvokeUI(this Form frm, Action a)
        {
            try
            {
                frm.BeginInvoke(new MethodInvoker(a));
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        public static void DelayAction(int millisecond, Action action)
        {
            var timer = new Telerik.WinControls.RichTextEditor.UI.DispatcherTimer();
            timer.Tick += delegate
            {
                action.Invoke();
                timer.Stop();
            };

            timer.Interval = TimeSpan.FromMilliseconds(millisecond);
            timer.Start();
        }


        public static Image ScaleImage(this Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

        public static void TranslateOnlineStatus(Enums.LiveClientStatus lcs, out string status, out bool isOnline)
        {
            switch (lcs)
            {
                case Enums.LiveClientStatus.NONE:
                    status = "";
                    isOnline = false;
                    break;
                case Enums.LiveClientStatus.ONLINE:
                    status = "Starting";
                    isOnline = true;
                    break;
                case Enums.LiveClientStatus.OFFLINE:
                    status = "Offline";
                    isOnline = false;
                    break;
                case Enums.LiveClientStatus.GAMEOVER_FOR_CLEANING:
                    status = "For Cleaning";
                    isOnline = true;
                    break;
                case Enums.LiveClientStatus.CLEANING_DONE:
                    status = "Ready";
                    isOnline = true;
                    break;
                case Enums.LiveClientStatus.IN_GAME_SELECTOR:
                    status = "In Selector";
                    isOnline = true;
                    break;
                case Enums.LiveClientStatus.IN_GAME_STARTING:
                    status = "Starting Game";
                    isOnline = true;
                    break;
                case Enums.LiveClientStatus.IN_GAME:
                    status = "In Game";
                    isOnline = true;
                    break;
                case Enums.LiveClientStatus.GAME_EXITING:
                    status = "Exiting Game";
                    isOnline = true;
                    break;
                case Enums.LiveClientStatus.ERROR:
                    status = "ERROR";
                    isOnline = false;
                    break;
                default:
                    status = "";
                    isOnline = false;
                    break;
            }
        }


        public static void ShowAlertBox(this Form frm, string caption, string content)
        {
            RadDesktopAlert rda = new RadDesktopAlert();

            rda.CaptionText = caption;
            rda.ContentText = content;
            rda.ShowPinButton = false;
            rda.ShowOptionsButton = false;
            rda.PopupAnimationDirection = RadDirection.Up;
            rda.FadeAnimationType = FadeAnimationType.FadeOut;
            rda.Opacity = 1;
            rda.PopupAnimationFrames = 10;

            rda.Show();
        }


        public static bool IsValidLicenseAvailable()
        {
            bool isValidLicense = false;
            try
            {
                isValidLicense = (EvaluationMonitor.CurrentLicense.LicenseStatus == IntelliLock.Licensing.LicenseStatus.Licensed);
            }
            finally
            {

            }
            // disable license protection
            return true;
        }

        public static string GetHardwareID()
        {
            return HardwareID.GetHardwareID(true, false, true, true, false, false);
        }

        public static string GetLicenseExpirationDate()
        {
            string licenseExpDate = "No Valid License File Found!";

            try
            {
                licenseExpDate = EvaluationMonitor.CurrentLicense.ExpirationDate.ToString("d");
            }
            finally
            {

            }

            return licenseExpDate;
        }

        public static T Clone<T>(this T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static Process IsProcessOpenByName(string name)
        {
            Process[] proc = Process.GetProcessesByName(name);

            if (proc.Length > 0)
            {
                return proc[0];
            }

            return null;

        }

        public static Process RunCommand(string command, string arguments, string workingPath, ProcessWindowStyle winStyle)
        {
            logger.Trace("RunCommand command = {0}", command);

            Process p = null;

            try
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.FileName = command;
                if (arguments.Length > 0)
                {
                    proc.Arguments = arguments;
                }
                if (workingPath.Length > 0)
                {
                    proc.WorkingDirectory = workingPath;
                }
                proc.WindowStyle = winStyle;

                p = Process.Start(proc);
            }
            catch (Exception ex)
            {
                logger.Error("RunCommand command = {0}, Error: {1}", command, ex.ToString());
            }

            return p;

        }

        public static void DoPrintBarcode(List<BarcodeItem> barcodeItems)
        {
            TextWriter writeFileStream = null;
            string fName = Path.GetTempFileName();

            BarcodeInfo bInfo = new BarcodeInfo();
            bInfo.BarcodeItems = barcodeItems;

            try
            {
                XmlSerializer SerializerObj = new XmlSerializer(typeof(BarcodeInfo));
                writeFileStream = new StreamWriter(fName);
                SerializerObj.Serialize(writeFileStream, bInfo);

                logger.Debug("DO PRINT BARCODE. File Name: " + fName);

                Process proc = Utility.IsProcessOpenByName("BarcodePrintHelper");

                if (proc == null)
                {
                    RunCommand(AppDomain.CurrentDomain.BaseDirectory + "BarcodePrintHelper.exe", fName, AppDomain.CurrentDomain.BaseDirectory, ProcessWindowStyle.Hidden);
                }
            }
            catch (Exception ex)
            {
                logger.Error("DoPrintBarcode: " + ex.ToString());
            }
            finally
            {
                if (writeFileStream != null)
                {
                    writeFileStream.Close();
                }
            }

        }

    }

}
