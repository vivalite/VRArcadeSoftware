using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using VRGameSelectorDTO;

namespace VRGameSelectorTestServer
{
    public partial class TestServer : Form
    {
        private string infoText;
        private const bool INTERNAL_TEST = true;

        public TestServer()
        {
            InitializeComponent();
            InitNetworkComms();

            if (INTERNAL_TEST) //This is for internal middle ware testing. For Game Selector UI testing following 3 buttons are not used.
            {
                btnGetClientStatus.Enabled = false;
                btnStartTiming.Enabled = false;
                btnTurnOff.Enabled = false;
            }

        }

        private void InitNetworkComms()
        {
            int port = (INTERNAL_TEST) ? 20015 : 20018; // This is for internal middle ware testing. For Game Selector UI testing port should be 20015


            DataSerializer dataSerializer = DPSManager.GetDataSerializer<ProtobufSerializer>();
            List<DataProcessor> dataProcessors = new List<DataProcessor>();
            Dictionary<string, string> dataProcessorOptions = new Dictionary<string, string>();

            dataProcessors.Add(DPSManager.GetDataProcessor<SharpZipLibCompressor.SharpZipLibGzipCompressor>());
            NetworkComms.DefaultSendReceiveOptions = new SendReceiveOptions(dataSerializer, dataProcessors, dataProcessorOptions);
            NetworkComms.DefaultSendReceiveOptions.IncludePacketConstructionTime = true;
            NetworkComms.DefaultSendReceiveOptions.ReceiveHandlePriority = QueueItemPriority.AboveNormal;

            NetworkComms.AppendGlobalIncomingPacketHandler<VRCommand>("Command", HandleIncomingCommand);

            Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Any, port));

            foreach (IPEndPoint localEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.TCP))
            {
                infoText += localEndPoint.Address.ToString() + ":" + localEndPoint.Port.ToString() + Environment.NewLine;
            }
        }


        // incomming vr command
        private void HandleIncomingCommand(PacketHeader packetHeader, Connection connection, VRCommand vrCommand)
        {
            switch (vrCommand.ControlMessage)
            {
                case Enums.ControlMessage.PLAY_LOG:

                    infoText = connection.ToString() + " Play Log: '" + vrCommand.PlayLog.TileID.ToString() + "', '" + vrCommand.PlayLog.SignalType.ToString() + "'";

                    break;

                case Enums.ControlMessage.LOAD_CONFIG:

                    TileConfig tc = BuildMockTileData();
                    VRCommand cmd = new VRCommand(tc);
                    SendCommandToClientSpecific(connection, cmd);

                    break;

                case Enums.ControlMessage.STATUS:

                    infoText = connection.ToString() + " Client Status: '" + vrCommand.ClientStatus.ClientIP + "'";

                    break;
                case Enums.ControlMessage.CLIENT_UI_READY:

                    EndNow();

                    //Task.Delay(1000).ContinueWith(t => EndNow());

                    infoText = connection.ToString() + " Client UI Ready.";

                    break;
                default:
                    break;
            }


        }

        // generic method to send command object to client
        private bool SendCommandToClientSpecific(Connection connection, object cmdObj)
        {
            try
            {
                connection.SendObject("Command", cmdObj);
                return true;
            }
            catch (Exception ex)
            {
                infoText = ex.Message;
            }
            return false;
        }

        private void TurnOff()
        {
            List<Connection> currentConnections = NetworkComms.GetExistingConnection();

            foreach (Connection conn in currentConnections)
            {
                VRCommand cmd = new VRCommand(Enums.ControlMessage.TURN_OFF);
                SendCommandToClientSpecific(conn, cmd);
            }
        }

        private void EndNow()
        {
            List<Connection> currentConnections = NetworkComms.GetExistingConnection();

            foreach (Connection conn in currentConnections)
            {
                EndNow endNow = new EndNow("Your time is up!" + Environment.NewLine +
                                           "Thanks for playing!");
                VRCommand cmd = new VRCommand(endNow);
                SendCommandToClientSpecific(conn, cmd);
            }
        }

        private void StartNow()
        {
            List<Connection> currentConnections = NetworkComms.GetExistingConnection();

            foreach (Connection conn in currentConnections)
            {
                VRCommand cmd = new VRCommand(Enums.ControlMessage.START_NOW);
                SendCommandToClientSpecific(conn, cmd);
            }
        }

        private void StartTiming()
        {
            //Timing t = new Timing(2);

            //List<Connection> currentConnections = NetworkComms.GetExistingConnection();

            //foreach (Connection conn in currentConnections)
            //{
            //    VRCommand cmd = new VRCommand(t);
            //    SendCommandToClientSpecific(conn, cmd);
            //}
        }


        private void GetClientStatus()
        {
            List<Connection> currentConnections = NetworkComms.GetExistingConnection();

            foreach (Connection conn in currentConnections)
            {
                VRCommand cmd = new VRCommand(Enums.ControlMessage.STATUS);
                SendCommandToClientSpecific(conn, cmd);
            }

        }



        private static TileConfig BuildMockTileData()
        {
            TileConfig tc = new TileConfig();

            Tile t1 = new Tile(200, 200, 1, "A1", "Lightblade VR", @"Images\Lightblade-VR.jpg", "Lightblade VR is a virtual reality training simulation for self-illumintated plasma blades. This is a childhood dream come true! Get trained by your personal robot and deflect all incoming laser beams! Complete with speed, accuracy and precision training, you’ll find yourself slowly feeling like you should be in a movie.", @"D:\Games\Game1\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4");
            Tile t2 = new Tile(200, 200, 1, "A2", "Raw Data", @"Images\Rawdata.jpg", "Built from the ground up for VR, Raw Data’s action combat gameplay, intuitive controls, challenging enemies, and sci-fi atmosphere will immerse you within the surreal environments of Eden Corp. Go solo or team up and become the adrenaline-charged heroes of your own futuristic technothriller.", @"D:\Games\Game2\run.exe", "", "", new ImageInfo(), 0, "");
            Tile t3 = new Tile(200, 200, 1, "A3", "The Lab", @"Images\The-Lab.jpg", "Welcome to The Lab, a compilation of Valve’s room-scale VR experiments set in a pocket universe within Aperture Science. Fix a robot, defend a castle from an invading army, adopt a mechanical dog on a cliff in Washington state, fire a slingshot at a tower of boxes, control a spaceship from a third persons perspective, and many more.", @"D:\Games\Game3\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4");

            Tile cat1 = new Tile(100, 100, 2, "C1", "FPS Games", "", "Click for all FPS Games", "", "", "", new ImageInfo(), 0, "");

            Tile t4 = new Tile(100, 100, 1, "A4", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4");
            Tile t5 = new Tile(100, 100, 1, "A5", "ProtonWar", @"Images\PortonWar.jpg", "Multiplayer focused, Fast paced AFPS with an emphasis on quick and flowing movement. It features advanced strafe jumping, wall running, wall jumping, step up double jumps and sliding movement mechanics! Play as a normal FPS in VR.", @"D:\Games\Game5\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4");
            Tile t6 = new Tile(100, 100, 1, "A6", "A-10 VR", @"Images\A10.jpg", "A-10 VR combines stunning graphics with simplistic gameplay to introduce players of all ages and skill to the possibilities of virtual reality. A-10 VR has been geared towards users trying VR for the first time, although sharp shooters will be able to spend hours mastering their gun play. Try the “attack mode” to see if you can place on their leaderboard.", @"D:\Games\Game6\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4");
            Tile t7 = new Tile(100, 100, 1, "A7", "QuiVr", @"Images\QuiVR.jpg", "QuiVr is an Archery Castle Defense game for the HTC Vive. Play solo or with friends as you battle the hordes of monsters and siege engines that swarm in to destroy your castle!", @"D:\Games\Game7\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4");
            Tile t8 = new Tile(100, 100, 1, "A8", "Kittypocalypse", @"Images\Kittypocalypse.jpg", "Kittypocalypse is an in-depth, strategic tower defense game built exclusively for VR. Across a diverse range of environments, defeat the hordes of evil alien kitties and salvage what’s left of your home…", @"D:\Games\Game8\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4");

            Tile t9 = new Tile(100, 100, 2, "A9", "Snow Fortress", @"Images\SnowFortress.png", "Relive your childhood by building forts & waging epic snowball fights in VR! Unlock tools to protect your fort and deliver a fury of snowballs at your opponents!", @"D:\Games\Game9\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4");
            Tile t10 = new Tile(100, 100, 2, "A10", "Hoops VR", @"Images\HoopsVR.jpg", "Y’all ready for this? Hoops VR is specially designed for the HTC Vive so you can live out the ultimate basketball free-throw challenge. Use the motion controls and shoot hoops as naturally as you would out on the court in a real basketball game.", @"D:\Games\Game10\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4");

            Tile cat2 = new Tile(100, 100, 2, "C2", "Horror Games", "", "Click for all Horror Games", "", "", "", new ImageInfo(), 0, "");

            Tile t11 = new Tile(125, 125, 2, "A11", "Affected: The Manor", @"Images\Affected.png", "AFFECTED has been commended as one of the best Virtual Reality experiences to date and thus far has received over 100 million views on youtube, generating interest from all over the world along the way. Make your way through a haunted manor, but be careful because around every corner there is a slamming door, a flashing light, and all of your fears coming to life.", @"D:\Games\Game11\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4");
            Tile t12 = new Tile(125, 125, 2, "A12", "Sophie’s Guardian", @"Images\SophieGuardian.jpg", "A little girl’s nightmares and fears represented on this VR title will take you to a mysterious room trying to break the scoreboards and playing with other friends locally… using just one VR headset! Attention: This video game is modding friendly.", @"D:\Games\Game12\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4");
            Tile t13 = new Tile(125, 125, 2, "A13", "Brookhaven Experiment", @"Images\Brookhaven.jpg", "Brookhaven is a VR survival shooter for the HTC Vive. Players will have to use the weapons and tools provided to survive ever more terrifying waves of horrific monsters in an attempt to figure out what caused the beginning of the end of the world, and, if they’re strong enough, stop it from happening.", @"D:\Games\Game13\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4");
            Tile t14 = new Tile(125, 125, 2, "A14", "The Bellows", @"Images\TheBellows.jpg", "The Bellows brings you to an estate where you are awoken in the middle of the night by a violent storm. Unfortunately, it is not a normal night as things soon start to go awry…", @"D:\Games\Game14\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4");

            Tile cat3 = new Tile(100, 100, 2, "C2", "test", "", "Testing 4 x 6", "", "", "", new ImageInfo(), 0, "")
            {
                ChildTiles = new List<Tile>()
                 {
                     new Tile(100, 100, 1, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 1, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 1, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 1, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 1, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 1, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),

                     new Tile(100, 100, 2, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 2, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 2, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 2, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 2, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 2, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),

                     new Tile(100, 100, 3, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 3, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 3, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 3, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 3, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 3, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),

                     new Tile(100, 100, 4, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 4, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 4, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 4, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 4, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 4, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4")

                }

            };

            Tile cat4 = new Tile(100, 100, 2, "C2", "test", "", "Testing 3 x 6", "", "", "", new ImageInfo(), 0, "")
            {
                ChildTiles = new List<Tile>()
                 {
                     new Tile(100, 100, 1, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 1, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 1, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 1, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 1, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 1, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),

                     new Tile(100, 100, 2, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 2, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 2, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 2, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 2, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 2, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),

                     new Tile(100, 100, 3, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 3, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 3, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 3, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 3, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4"),
                     new Tile(100, 100, 3, "T", "Hover Junkers", @"Images\HoverJunkers.jpg", "Engage in multiplayer VR gunfights that capture real gun play like no FPS you’ve played before. Pilot and fortify Hover Junkers as you physically walk, duck, dodge and aim in cross ship combat.", @"D:\Games\Game4\run.exe", "", "", new ImageInfo(), 0, "http://127.0.0.1/video.mp4")

                }

            };

            cat1.ChildTiles.Add(t4);
            cat1.ChildTiles.Add(t5);
            cat1.ChildTiles.Add(t6);
            cat1.ChildTiles.Add(t7);
            cat1.ChildTiles.Add(t8);
            cat1.ChildTiles.Add(t9);
            cat1.ChildTiles.Add(t10);

            cat2.ChildTiles.Add(t11);
            cat2.ChildTiles.Add(t12);
            cat2.ChildTiles.Add(t13);
            cat2.ChildTiles.Add(t14);

            tc.MainScreenTiles.Add(t1);
            tc.MainScreenTiles.Add(t2);
            tc.MainScreenTiles.Add(t3);
            tc.MainScreenTiles.Add(cat1);
            tc.MainScreenTiles.Add(cat2);
            tc.MainScreenTiles.Add(cat3);
            tc.MainScreenTiles.Add(cat4);

            return tc;

        }




        #region Form control related

        private void TestClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            NetworkComms.Shutdown();
        }

        private void btnGetClientStatus_Click(object sender, EventArgs e)
        {
            GetClientStatus();
        }

        private void btnStartTiming_Click(object sender, EventArgs e)
        {
            StartTiming();
        }

        private void btnStartNow_Click(object sender, EventArgs e)
        {
            StartNow();
        }

        private void btnEndNow_Click(object sender, EventArgs e)
        {
            EndNow();
        }

        private void btnTurnOff_Click(object sender, EventArgs e)
        {
            TurnOff();
        }

        private void testTimer_Tick(object sender, EventArgs e)
        {
            List<Connection> currentConnections = NetworkComms.GetExistingConnection();

            lblConnCnt.Text = "Connected Clients: " + currentConnections.Count.ToString();

            txtInfo.Text = infoText;
        }

        #endregion

        private void buttonSendTileConfig_Click(object sender, EventArgs e)
        {

            List<Connection> currentConnections = NetworkComms.GetExistingConnection();
            TileConfig tc = BuildMockTileData();

            foreach (Connection conn in currentConnections)
            {
                VRCommand cmd = new VRCommand(tc);

                SendCommandToClientSpecific(conn, cmd);
            }

        }

        private void buttonShowQuickHelp_Click(object sender, EventArgs e)
        {
            List<Connection> currentConnections = NetworkComms.GetExistingConnection();

            foreach (Connection conn in currentConnections)
            {
                VRCommand cmd = new VRCommand(Enums.ControlMessage.SHOW_QUICK_HELP);
                SendCommandToClientSpecific(conn, cmd);
            }
        }
    }
}
