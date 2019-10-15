using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using VRGameSelectorDTO;

namespace VRGameSelectorClientDaemon
{
    public static class Utility
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static Dictionary<string, string> _systemXMLConfigs;
        private static List<SysConfig> _cachedSystemConfig;
        private static DateTime dtClientUIStartTime = DateTime.MinValue;
        private static DateTime dtDashboardStartTime = DateTime.MinValue;
        private static DateTime dtSteamVRStartTime = DateTime.MinValue;

        private static DateTime dtLastDashboardStartTime = DateTime.MinValue;
        private static DateTime dtLastClientUIStartTime = DateTime.MinValue;

        public static int iShortClientUIRestartEvent = 0;
        public static int iShortDashboardRestartEvent = 0;

        public const int cShortClientUIRestartEventThreshold = 20;
        public const int cShortDashboardRestartEventThreshold = 20;


        public static void InvokeUI(this Form frm, Action a)
        {
            try
            {
                frm.BeginInvoke(new MethodInvoker(a));
            }
            catch (Exception ex)
            {
                logger.Info("InvokeUI: " + ex.ToString());
            }
        }

        public static void InitCoreConfig(string appFolder)
        {
            if (!InitCoreConfigInternal(GetGameSelectorDataFolder() + @"config.xml"))
            {
                InitCoreConfigInternal(appFolder + @"\config.xml");
            }
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

        public static string GetGameSelectorDataFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\VRArcade\Client\";
        }

        public static string GetGameSelectorBaseFolder()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static string GetGameSelectorUIDataFolder()
        {
            string baseFolder = GetGameSelectorBaseFolder();

            if (baseFolder.Length > 0)
            {
                return baseFolder + @"VRGameSelector_Data";
            }
            else
            {
                return "";
            }
        }

        public static void MakeSureFolderExist(string folderPath)
        {

            if (!Directory.Exists(folderPath)) // create folder if not exist
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        public static string GetSystemConfig(Enums.SysConfigType configType)
        {
            SysConfig sysConfig = _cachedSystemConfig.Where(x => x.Type == configType).FirstOrDefault();

            return sysConfig.Value;
        }

        public static void SetSystemConfig(List<SysConfig> sysConfig)
        {
            _cachedSystemConfig = sysConfig;
        }

        public static bool IsSystemConfigLoaded()
        {
            return _cachedSystemConfig != null;
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

        public static Process IsProcessOpenByName(string name)
        {
            Process[] proc = Process.GetProcessesByName(name);

            if (proc.Length > 0)
            {
                return proc[0];
            }

            return null;

        }

        public static Process IsProcessOpenWithFullPath(string name)
        {
            //foreach (Process clsProcess in Process.GetProcesses())
            //{
            //    try
            //    {
            //        if (clsProcess.MainModule.FileName.Contains(name))
            //        {
            //            return clsProcess;
            //        }
            //    }
            //    catch
            //    {
            //    }

            //}

            logger.Trace("IsProcessOpenWithFullPath file path = " + name);

            string wmiQueryString = "SELECT ProcessId, ExecutablePath FROM Win32_Process WHERE ExecutablePath ='" + name.Replace("\\", "\\\\") + "'";
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            {
                using (var results = searcher.Get())
                {
                    ManagementObject mo = results.Cast<ManagementObject>().FirstOrDefault();
                    if (mo != null)
                    {
                        int procId = 0;

                        int.TryParse(mo["ProcessId"].ToString(), out procId);

                        if (procId != 0)
                        {
                            try
                            {
                                return Process.GetProcessById(procId);
                            }
                            catch
                            {
                                return null;
                            }
                        }

                    }
                }
            }

            return null;
        }

        public static bool StartDashboard()
        {
            string dashboardEXE = GetGameSelectorBaseFolder() + "VRGameSelectorDashboard.exe";

            if (!IsDashboardRunning() && DateTime.Now.Subtract(dtDashboardStartTime).TotalSeconds > 5)
            {
                RunCommand(dashboardEXE, "-logFile \"" + GetGameSelectorDataFolder() + "Dashboard.log\"", "", ProcessWindowStyle.Normal);

                // check if this is restart follow too close
                if (DateTime.Now.Subtract(dtDashboardStartTime).TotalSeconds < 10 && dtDashboardStartTime.Subtract(dtLastDashboardStartTime).TotalSeconds < 10)
                {
                    iShortDashboardRestartEvent++;
                }
                dtLastDashboardStartTime = dtDashboardStartTime;
                dtDashboardStartTime = DateTime.Now;

                logger.Info("Start the Dashboard!");
                Debug.WriteLine("Start the Dashboard!");

                return true;
            }
            return false;
        }

        public static bool StartClientUI()
        {
            string clientUIEXE = GetGameSelectorBaseFolder() + "VRGameSelector.exe";

            if (!IsClientUIRunning() && DateTime.Now.Subtract(dtClientUIStartTime).TotalSeconds > 5)
            {
                var p = RunCommand(clientUIEXE, "-logFile \"" + GetGameSelectorDataFolder() + "ClientUI.log\" -screen-fullscreen 1", "", ProcessWindowStyle.Maximized);

                // check if this is restart follow too close
                if (DateTime.Now.Subtract(dtClientUIStartTime).TotalSeconds < 10 && dtClientUIStartTime.Subtract(dtLastClientUIStartTime).TotalSeconds < 10)
                {
                    iShortClientUIRestartEvent++;
                }
                dtLastClientUIStartTime = dtClientUIStartTime;
                dtClientUIStartTime = DateTime.Now;

                logger.Info("Start the ClientUI!");
                Debug.WriteLine("Start the ClientUI!");

                return true;
            }
            return false;
        }

        public static bool IsProgramRepeatRestartProblmeFound()
        {
            Debug.WriteLine(Utility.iShortClientUIRestartEvent.ToString() + "    " + Utility.iShortDashboardRestartEvent.ToString());

            if (iShortClientUIRestartEvent > cShortClientUIRestartEventThreshold || iShortDashboardRestartEvent > cShortDashboardRestartEventThreshold)
            {
                return true;
            }
            return false;
        }

        public static bool IsDashboardRunning()
        {
            string dashboardEXE = GetGameSelectorBaseFolder() + "VRGameSelectorDashboard.exe";

            if (IsProcessOpenWithFullPath(dashboardEXE) != null)
            {
                ClientDaemon cd = ClientDaemon.Instance;

                if (cd._targetDashboardClientLastCommunicationTime != DateTime.MinValue && DateTime.Now.Subtract(cd._targetDashboardClientLastCommunicationTime).TotalSeconds > 12)
                {
                    return false; // not responding ClientUIExe
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static void KillDashboard()
        {
            KillProcess("VRGameSelectorDashboard");
        }

        public static bool IsClientUIRunning()
        {
            string clientUIEXE = GetGameSelectorBaseFolder() + "VRGameSelector.exe";

            ClientDaemon cd = ClientDaemon.Instance;

            if (IsProcessOpenWithFullPath(clientUIEXE) != null)
            {
                if (cd._targetUIClientLastCommunicationTime != DateTime.MinValue && DateTime.Now.Subtract(cd._targetUIClientLastCommunicationTime).TotalSeconds > 12)
                {
                    return false; // not responding ClientUIExe
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static void KillClientUI()
        {
            KillProcess("VRGameSelector");
        }

        public static bool IsTileGameRunning(Tile internalPlayingTile)
        {
            if (internalPlayingTile != null)
            {
                Regex regex = new Regex(@"\[(.*)\]");
                Match m = regex.Match(internalPlayingTile.Command);
                if (m.Groups.Count == 2)
                {
                    if (m.Groups[1].Value.Contains(","))
                    {
                        List<string> lIdvExePath = m.Groups[1].Value.Split(',').ToList();

                        foreach (string idvExePath in lIdvExePath)
                        {
                            if (IsProcessOpenWithFullPath(idvExePath) != null)
                            {
                                return true;
                            }
                        }

                    }
                    else
                    {
                        if (IsProcessOpenWithFullPath(m.Groups[1].Value) != null)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (IsProcessOpenWithFullPath(internalPlayingTile.Command) != null)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool StartSteamVR()
        {
            string clientUIEXE = @"steam://rungameid/250820";

            Process proc = Utility.IsProcessOpenByName("vrmonitor");

            if (proc == null && DateTime.Now.Subtract(dtSteamVRStartTime).Seconds > 10)
            {
                var p = RunCommand(clientUIEXE, "", "", ProcessWindowStyle.Normal);
                dtSteamVRStartTime = DateTime.Now;
                return true;
            }
            return false;
        }

        public static bool IsSteamVRRunning()
        {
            Process proc = Utility.IsProcessOpenByName("vrmonitor");

            if (proc != null && DateTime.Now.Subtract(proc.StartTime).TotalSeconds > 20)
            {
                return true;
            }

            return false;

        }

        public static void KillProcess(string procName)
        {
            foreach (var process in Process.GetProcessesByName(procName))
            {
                process.Kill();
            }
        }

        public static void Restart()
        {
            StartShutDown("-f -r -t 5");
        }

        public static void LogOff()
        {
            StartShutDown("-l");
        }

        public static void ShutDown()
        {
            StartShutDown("-f -s -t 5");
        }

        private static void StartShutDown(string param)
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.FileName = "cmd";
            proc.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Arguments = "/C shutdown " + param;
            Process.Start(proc);
        }

        public static void GetIPInfo(out string ip, out string mac)
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            mac = ""; ip = "";

            foreach (NetworkInterface adapter in nics)
            {
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet && !adapter.Description.Contains("VMware") && !adapter.Description.Contains("Virtual"))
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
                    mac += Environment.NewLine;
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




    }
}
