using ProtoBuf;
using System.Collections.Generic;

namespace VRGameSelectorServerDTO
{
    [ProtoContract]
    public class VRCommandServer
    {
        public VRCommandServer()
        {
            ControlMessage = Enums.ControlMessage.NONE;
        }

        public VRCommandServer(Enums.ControlMessage controlMessage)
        {
            ControlMessage = controlMessage;
        }

        public VRCommandServer(Enums.ControlMessage controlMessage, List<Client> listClients)
        {
            ControlMessage = controlMessage;
            ListClients = listClients;
        }

        public VRCommandServer(Enums.ControlMessage controlMessage, Client client)
        {
            ControlMessage = controlMessage;
            Client = client;
        }

        public VRCommandServer(Enums.ControlMessage controlMessage, List<ConfigSet> listConfigSet)
        {
            ControlMessage = controlMessage;
            ListConfigSet = listConfigSet;
        }

        public VRCommandServer(Enums.ControlMessage controlMessage, ConfigSet configSet)
        {
            ControlMessage = controlMessage;
            ConfigSet = configSet;
        }

        public VRCommandServer(Enums.ControlMessage controlMessage, List<TileConfig> listTileConfig)
        {
            ControlMessage = controlMessage;
            ListTileConfig = listTileConfig;
        }

        public VRCommandServer(Enums.ControlMessage controlMessage, TileConfig tileConfig)
        {
            ControlMessage = controlMessage;
            TileConfig = tileConfig;
        }
        public VRCommandServer(Enums.ControlMessage controlMessage, LiveSystemInfo liveSystemInfo)
        {
            ControlMessage = controlMessage;
            LiveSystemInfo = liveSystemInfo;
        }

        public VRCommandServer(Enums.ControlMessage controlMessage, List<SystemConfig> systemConfig)
        {
            ControlMessage = controlMessage;
            SystemConfig = systemConfig;
        }

        public VRCommandServer(Enums.ControlMessage controlMessage, List<ClientParm> clientParm)
        {
            ControlMessage = controlMessage;
            ClientParm = clientParm;
        }

        public VRCommandServer(Enums.ControlMessage controlMessage, List<GamePlayHistory> gamePlayHistory)
        {
            ControlMessage = controlMessage;
            GamePlayHistory = gamePlayHistory;
        }

        public VRCommandServer(Enums.ControlMessage controlMessage, BarcodeInfo barcodeInfo)
        {
            ControlMessage = controlMessage;
            BarcodeInfo = barcodeInfo;
        }

        public VRCommandServer(Enums.ControlMessage controlMessage, List<KeyInfo> keyInfo)
        {
            ControlMessage = controlMessage;
            ListKeyInfo = keyInfo;
        }

        public VRCommandServer(Enums.ControlMessage controlMessage, List<KeyTypeInfo> keyTypeInfo)
        {
            ControlMessage = controlMessage;
            ListKeyTypeInfo = keyTypeInfo;
        }

        public VRCommandServer(Enums.ControlMessage controlMessage, List<WaiverInfo> waiverInfo)
        {
            ControlMessage = controlMessage;
            ListWaiverInfo = waiverInfo;
        }

        public VRCommandServer(Enums.ControlMessage controlMessage, BookingReference bookingReference)
        {
            ControlMessage = controlMessage;
            BookingReference = bookingReference;
        }

        [ProtoMember(1)]
        public Enums.ControlMessage ControlMessage { get; set; }
        [ProtoMember(2)]
        public List<Client> ListClients { get; set; }
        [ProtoMember(3)]
        public Client Client { get; set; }
        [ProtoMember(4)]
        public List<ConfigSet> ListConfigSet { get; set; }
        [ProtoMember(5)]
        public ConfigSet ConfigSet { get; set; }
        [ProtoMember(6)]
        public List<TileConfig> ListTileConfig { get; set; }
        [ProtoMember(7)]
        public TileConfig TileConfig { get; set; }
        [ProtoMember(8)]
        public LiveSystemInfo LiveSystemInfo { get; set; }
        [ProtoMember(9)]
        public List<SystemConfig> SystemConfig { get; set; }
        [ProtoMember(10)]
        public List<ClientParm> ClientParm { get; set; }
        [ProtoMember(11)]
        public List<GamePlayHistory> GamePlayHistory { get; set; }
        [ProtoMember(12)]
        public BarcodeInfo BarcodeInfo { get; set; }
        [ProtoMember(13)]
        public List<KeyInfo> ListKeyInfo { get; set; }
        [ProtoMember(14)]
        public List<KeyTypeInfo> ListKeyTypeInfo { get; set; }
        [ProtoMember(15)]
        public List<WaiverInfo> ListWaiverInfo { get; set; }
        [ProtoMember(16)]
        public BookingReference BookingReference { get; set; }
    }
}
