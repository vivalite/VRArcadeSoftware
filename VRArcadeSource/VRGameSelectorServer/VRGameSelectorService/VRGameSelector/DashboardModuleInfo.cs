
using System;
using System.Runtime.Serialization;
using VRGameSelectorServerDTO;

namespace VRArcadeServer
{
    [DataContract]
    public class DashboardModuleInfo
    {
        public DashboardModuleInfo()
        {
            CurrentRunningMode = Enums.ClientRunningMode.NONE;
            CurrentRunningTitle = "";
            IsRequireAssistant = false;
            LiveClientStatus = Enums.LiveClientStatus.NONE;
            TimeStamp = DateTime.Now;
        }

        public DashboardModuleInfo(Enums.ClientRunningMode currentClientRunningMode, string curTitle, bool assist, Enums.LiveClientStatus liveClientStatus) : base()
        {
            CurrentRunningMode = currentClientRunningMode;
            CurrentRunningTitle = curTitle;
            IsRequireAssistant = assist;
            LiveClientStatus = liveClientStatus;
        }

        [DataMember]
        public Enums.ClientRunningMode CurrentRunningMode { get; set; }

        [DataMember]
        public string CurrentRunningTitle { get; set; }

        [DataMember]
        public bool IsRequireAssistant { get; set; }

        [DataMember]
        public Enums.LiveClientStatus LiveClientStatus { get; set; }

        [DataMember]
        public DateTime TimeStamp { get; set; }


    }
}
