using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace BarcodePrintHelper
{
    class Program
    {
        static Dictionary<string, string> _systemConfigs;
        static VRArcadeServer.DashboardService _dashboardClient;

        static void Main(string[] args)
        {
            string fContent = "";

            if (args == null || args.Length == 0)
            {
                Console.WriteLine("This EXE must run with the VRArcade Managing System!"); // Check for null array
            }
            else if (args.Length == 1)
            {
                InitCoreConfig();
                InitWebService();

                try
                {
                    fContent = File.ReadAllText(args[0]);
                }
                catch (Exception)
                {

                    throw;
                }



                if (fContent.Length > 10)
                {
                    XmlSerializer SerializerObj = new XmlSerializer(typeof(BarcodeInfo));
                    FileStream readFileStream = null;
                    BarcodeInfo bInfo = null;

                    try
                    {
                        readFileStream = new FileStream(args[0], FileMode.Open, FileAccess.Read, FileShare.Read);
                        bInfo = (BarcodeInfo)SerializerObj.Deserialize(readFileStream);
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        readFileStream.Close();
                    }

                    if (bInfo != null && bInfo.BarcodeItems != null && bInfo.BarcodeItems.Count > 0)
                    {
                        BarcodePrinterWrapper bPrint = null;

                        try
                        {
                            bPrint = BarcodePrinterWrapper.Instance;

                            if (bInfo.BarcodeItems[0].IsPrintingTicket)
                            {
                                bPrint.PrintTickets(bInfo.BarcodeItems);

                                foreach (var item in bInfo.BarcodeItems)
                                {
                                    _dashboardClient.BarcodeDonePrinting(item.WaiverLogID, true, item.BookingReference, true, true);
                                }
                            }
                            else if (bInfo.BarcodeItems[0].IsPrintingKey)
                            {
                                bPrint.PrintKeys(bInfo.BarcodeItems);
                            }

                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show("Error! " + ex.Message);
                        }
                        finally
                        {
                            if (bPrint != null)
                            {
                                bPrint.Dispose();
                            }
                        }

                    }
                }

            }

        }


        private static void InitCoreConfig()
        {
            if (!InitCoreConfigInternal(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\VRArcade\ManagingSystem\config.xml"))
            {
                InitCoreConfigInternal(AppDomain.CurrentDomain.BaseDirectory + @"\config.xml");
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


        private static string GetCoreConfig(string key)
        {
            string value = "";

            if (_systemConfigs == null)
            {
                InitCoreConfig();
            }

            _systemConfigs.TryGetValue(key, out value);

            return value;
        }


        private static void InitWebService()
        {
            _dashboardClient = new VRArcadeServer.DashboardService();
            _dashboardClient.Timeout = 3000;
            _dashboardClient.Url = "http://" + GetCoreConfig("ServerIPPortWS") + "/VRArcadeDashboardService/";

        }
    }
}
