using NetworkCommsDotNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.ServiceProcess;
using System.Xml;
using VRGameSelectorDTO;

namespace VRArcadeServer
{
    public static class Utility
    {
        [DllImport("rpcrt4.dll", SetLastError = true)]
        public static extern int UuidCreateSequential(out Guid guid);

        private static Dictionary<string, string> _systemXMLConfigs;

        public static Guid CreateGuid()
        {
            const int RPC_S_OK = 0;

            Guid guid;
            int result = UuidCreateSequential(out guid);
            if (result == RPC_S_OK)
                return guid;
            else
                return Guid.NewGuid();
        }

        public static void InitCoreConfig(string appFolder)
        {
            if (!InitCoreConfigInternal(GetServerDataFolder() + @"config.xml"))
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

        public static string GetServerDataFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\VRArcade\Server\";
        }

        public static void SyncClock()
        {
            RestartWindowsService("W32Time");
            RunCommand("w32tm", @"/resync");
        }

        public static string RunCommand(string commandLine, string args)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            //basePath = "";

            Process proc = new Process();

            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.FileName = basePath + commandLine;
            proc.StartInfo.Arguments = args;
            proc.StartInfo.CreateNoWindow = true;

            proc.Start();
            string output = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();

            proc.Close();

            return output;
        }


        public static void RestartWindowsService(string serviceName)
        {
            ServiceController serviceController = new ServiceController(serviceName);
            try
            {
                if ((serviceController.Status.Equals(ServiceControllerStatus.Running)) || (serviceController.Status.Equals(ServiceControllerStatus.StartPending)))
                {
                    serviceController.Stop();
                }
                serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                serviceController.Start();
                serviceController.WaitForStatus(ServiceControllerStatus.Running);
            }
            catch
            {

            }
        }


    }

    public class InternalClientStatus
    {
        public InternalClientStatus()
        {
        }

        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string ClientIP { get; set; }
        public string DashboardModuleIP { get; set; }
        public VRGameSelectorServerDTO.Enums.LiveClientStatus? ClientStatus { get; set; }
        public string AdditionalInfo { get; set; }
        public bool? IsRequireAssistance { get; set; }
        public DateTime LastPingTimeStamp { get; set; }
        public DateTime LastTileConfigDownloadTimestamp { get; set; }
        public ClientRunningMode ClientRunningModeSetup { get; set; }

    }

    public class ConnectionInfoEx
    {
        public ConnectionInfoEx(ConnectionInfo connectionInfo, DateTime connectionTime)
        {
            ConnectionInfo = connectionInfo;
            ConnectionTime = connectionTime;
        }

        public ConnectionInfo ConnectionInfo { get; set; }
        public DateTime ConnectionTime { get; set; }
    }

    public class OperationInfo
    {
        public OperationInfo()
        {

        }
        public ConnectionInfo ConnectionInfo { get; set; }
        public VRGameSelectorServerDTO.Enums.SourceType SourceType { get; set; }
        public VRGameSelectorServerDTO.Enums.OperationType OperationType { get; set; }
        public int? ClientID { get; set; }
        public int? TileID { get; set; }
        public string TicketGUID { get; set; }
        public string AdditionalInfo { get; set; }

    }


    public class BookingReferenceJson
    {
        public BookingReferenceJson()
        {

        }

        [JsonProperty]
        public string booking_id { get; set; }
        [JsonProperty]
        public string booking_start_time { get; set; }
        [JsonProperty]
        public string booking_end_time { get; set; }
        [JsonProperty]
        public string customer_id { get; set; }
        [JsonProperty]
        public string booking_num_total { get; set; }
        [JsonProperty]
        public string customer_name { get; set; }
        [JsonProperty]
        public string customer_email { get; set; }
        [JsonProperty]
        public string customer_phone { get; set; }
        [JsonProperty]
        public string booking_creation_time { get; set; }
        [JsonProperty]
        public string booking_prod_name { get; set; }
        [JsonProperty]
        public string booking_prod_id { get; set; }
        [JsonProperty]
        public string total_paid { get; set; }
        [JsonProperty]
        public string booking_updated { get; set; }
        [JsonProperty]
        public string booking_deleted { get; set; }


    }

    public class BookingReferenceJsonEvent : EventArgs
    {
        public BookingReferenceJsonEvent()
        {
            ListBookingReference = new List<BookingReferenceJson>();
        }

        public List<BookingReferenceJson> ListBookingReference { get; set; }
    }

}
