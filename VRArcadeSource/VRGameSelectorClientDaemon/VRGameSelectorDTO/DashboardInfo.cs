using ProtoBuf;

namespace VRGameSelectorDTO
{
    [ProtoContract]
    public class DashboardInfo
    {
        public DashboardInfo()
        {
            CurrentRunningMode = new ClientRunningMode();
        }

        public DashboardInfo(ClientRunningMode currentRunningMode)
        {
            CurrentRunningMode = currentRunningMode;
        }

        [ProtoMember(1)]
        public ClientRunningMode CurrentRunningMode { get; set; }


    }
}
