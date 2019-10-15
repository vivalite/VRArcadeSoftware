using ProtoBuf;
using System.Collections.Generic;

namespace VRGameSelectorDTO
{
    [ProtoContract]
    public class VRCommand
    {
        public VRCommand()
        {
            ControlMessage = Enums.ControlMessage.NONE;
        }

        public VRCommand(Enums.ControlMessage controlMessage)
        {
            ControlMessage = controlMessage;
        }

        public VRCommand(TileConfig tileConfig)
        {
            ControlMessage = Enums.ControlMessage.LOAD_CONFIG;
            TileConfig = tileConfig;
        }

        public VRCommand(PlayLog playLog)
        {
            ControlMessage = Enums.ControlMessage.PLAY_LOG;
            PlayLog = playLog;
        }

        public VRCommand(ClientRunningMode clientStatus)
        {
            ControlMessage = Enums.ControlMessage.STATUS;
            ClientStatus = clientStatus;
        }

        public VRCommand(EndNow endNow)
        {
            ControlMessage = Enums.ControlMessage.END_NOW;
            EndNow = endNow;
        }

        public VRCommand(DashboardInfo dashboardInfo)
        {
            ControlMessage = Enums.ControlMessage.UNITY_DASHBOARD_SETDASHINFO;
            DashboardInfo = dashboardInfo;
        }

        public VRCommand(Barcode barcode)
        {
            ControlMessage = Enums.ControlMessage.LCD_DASHBOARD_BARCODE_IN;
            Barcode = barcode;
        }

        public VRCommand(Enums.ControlMessage controlMessage, RunningGameInfo runningGameInfo)
        {
            ControlMessage = controlMessage;
            RunningGameInfo = runningGameInfo;
        }
        public VRCommand(Enums.ControlMessage controlMessage, List<SysConfig> systemConfig)
        {
            ControlMessage = controlMessage;
            SystemConfig = systemConfig;
        }

        public VRCommand(Enums.ControlMessage controlMessage, TileConfig tileConfig)
        {
            ControlMessage = controlMessage;
            TileConfig = tileConfig;
        }

        public VRCommand(Enums.ControlMessage controlMessage, long packageSequenceEcho)
        {
            ControlMessage = controlMessage;
            PackageSequenceEcho = packageSequenceEcho;
        }

        [ProtoMember(1)]
        public Enums.ControlMessage ControlMessage { get; set; }
        [ProtoMember(2)]
        public TileConfig TileConfig { get; set; }
        [ProtoMember(3)]
        public PlayLog PlayLog { get; set; }
        [ProtoMember(4)]
        public ClientRunningMode ClientStatus { get; set; }
        [ProtoMember(5)]
        public EndNow EndNow { get; set; }
        [ProtoMember(6)]
        public RunningGameInfo RunningGameInfo { get; set; }
        [ProtoMember(7)]
        public string MachineName { get; set; }
        [ProtoMember(8)]
        public Enums.LiveClientStatus LiveClientStatus { get; set; }
        [ProtoMember(9)]
        public List<SysConfig> SystemConfig { get; set; }
        [ProtoMember(10)]
        public DashboardInfo DashboardInfo { get; set; }
        [ProtoMember(11)]
        public string AdditionalInfo { get; set; }
        [ProtoMember(12)]
        public Barcode Barcode { get; set; }
        [ProtoMember(13)]
        public long PackageSequenceEcho { get; set; }
    }
}
