using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BarcodeLCDDashboardMono
{
    public static class Utility
    {
        private static Dictionary<string, string> _systemXMLConfigs;

        public static void RunCommand(string cmd, string arg)
        {
            //return Task.Run(() =>
            //{
            ProcessStartInfo ps = new ProcessStartInfo(cmd, arg);
            ps.UseShellExecute = false;
            ps.RedirectStandardOutput = true;

            try
            {
                using (Process p = Process.Start(ps))
                {
                    string output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //});

        }

        public static void RunVideo()
        {
            int iVol = 75;

            int.TryParse(GetCoreConfig("Volume"), out iVol);

            int spVol = (100 - iVol) * -60;


            RunCommand("omxplayer", "--aspect-mode fill -b -ww --vol " + spVol.ToString() + " -o local " + System.AppDomain.CurrentDomain.BaseDirectory + "Video.mp4");
        }

        public static void PlayTestAudio()
        {
            RunCommand("aplay", "-t wav " + System.AppDomain.CurrentDomain.BaseDirectory + "TestSound.wav");
        }




        public static void GetIPInfo(out string ip, out string mac)
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            mac = ""; ip = "";

            foreach (NetworkInterface adapter in nics)
            {
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet && !adapter.Description.Contains("VMware"))
                {
                    PhysicalAddress address = adapter.GetPhysicalAddress();
                    byte[] bytes = address.GetAddressBytes();

                    for (int i = 0; i < bytes.Length; i++)
                    {
                        mac += bytes[i].ToString("X2");
                        if (i != bytes.Length - 1)
                        {
                            mac += "-";
                        }
                    }

                }
            }

            foreach (IPAddress address in Dns.GetHostEntry(Environment.MachineName).AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ip = address.ToString();
                    break;
                }

            }

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

        public static void InitCoreConfig()
        {
            InitCoreConfigInternal(System.AppDomain.CurrentDomain.BaseDirectory + @"config.xml");
        }

        private static bool InitCoreConfigInternal(string cfgPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            bool result = false;

            try
            {
                xmlDoc.Load(cfgPath);
                XmlNodeList systemList = xmlDoc.GetElementsByTagName("System");

                _systemXMLConfigs = new Dictionary<string, string>();

                foreach (XmlNode systemNode in systemList)
                {
                    foreach (XmlNode configNode in systemNode.ChildNodes)
                    {
                        _systemXMLConfigs.Add(configNode.Name, configNode.InnerText);
                        result = true;
                    }

                }
            }
            catch
            {

            }
            return result;
        }

        public static string GetCoreConfig(string key)
        {
            string value = "";
            _systemXMLConfigs.TryGetValue(key, out value);

            return value;
        }

    }
}
