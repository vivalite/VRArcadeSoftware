using CoreAudio;
using Crc32C;
using NetworkCommsDotNet;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows.Forms;
using VRGameSelectorDTO;

namespace VRGameSelectorClientDaemon
{
    public partial class ClientDaemon
    {
        static readonly ClientDaemon instance = new ClientDaemon();

        public event EventHandler OnConnectionStateChange = delegate { };

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ConnectionInfo _targetServerConnectionInfo;
        public ConnectionInfo _targetUIClientConnectionInfo;
        public ConnectionInfo _targetDashboardClientConnectionInfo;
        public DateTime _targetUIClientLastCommunicationTime = DateTime.MinValue;
        public DateTime _targetDashboardClientLastCommunicationTime = DateTime.MinValue;

        private System.Timers.Timer _timer1s;
        private readonly object _lockTimer1s = new object();
        private ClientRunningMode _internalClientRunningMode; // stores running mode such as timing-on non-timing-on or ends
        private Enums.LiveClientStatus _internalCurrentClientStatus; // detailed status of current client status
        private string _internalAdditionalInfo;

        private TileConfig _internalTileConfig;
        private Tile _internalCurrentPlayingTile;

        private bool _isRequestingTileWithImage = false;

        private Enums.SysConfigType _internalEndGameMessageConfigType;
        private DateTime _gameStartTime = DateTime.MinValue;
        private bool _isDisableKUMExecuted;
        private bool _isGameSelectorImageFolderPopulated = false;
        private bool _isGameSelectorInitDone = false;
        private int _gameNotRunningConfirmation = 0;

        private bool _exitGameFlag = false;


        static ClientDaemon()
        {

        }

        public static ClientDaemon Instance
        {
            get
            {
                return instance;
            }
        }


        public ClientDaemon()
        {
            Utility.InitCoreConfig(Application.StartupPath);

            InitNetworkComms();

            CheckSteamVRConfig();

            InitSystem();
        }

        private void CheckSteamVRConfig()
        {
            try
            {
                string configPath = @"C:\Program Files (x86)\Steam\config\steamvr.vrsettings";

                if (File.Exists(configPath))
                {
                    string svrConfig = File.ReadAllText(configPath);

                    JObject jObj = JObject.Parse(svrConfig);

                    var svr = jObj.Property("steamvr");

                    if (svr != null)
                    {
                        if (jObj["steamvr"]["sendSystemButtonToAllApps"] == null)
                        {
                            // sendSystemButtonToAllApps not exist
                            jObj["steamvr"]["sendSystemButtonToAllApps"] = true;
                            File.WriteAllText(configPath, jObj.ToString());
                        }

                        if (jObj["steamvr"]["enableHomeApp"] == null)
                        {
                            // sendSystemButtonToAllApps not exist
                            jObj["steamvr"]["enableHomeApp"] = false;
                            File.WriteAllText(configPath, jObj.ToString());
                        }

                        if (jObj["steamvr"]["startDashboardFromAppLaunch"] == null)
                        {
                            // startDashboardFromAppLaunch not exist
                            jObj["steamvr"]["startDashboardFromAppLaunch"] = true;
                            File.WriteAllText(configPath, jObj.ToString());
                        }

                        if (jObj["steamvr"]["startOverlayAppsFromDashboard"] == null)
                        {
                            // startOverlayAppsFromDashboard not exist
                            jObj["steamvr"]["startOverlayAppsFromDashboard"] = true;
                            File.WriteAllText(configPath, jObj.ToString());
                        }
                    }
                    else
                    {
                        // steamvr not found
                        jObj.Add("steamvr", JObject.FromObject(new { sendSystemButtonToAllApps = true, enableHomeApp = false }));
                        File.WriteAllText(configPath, jObj.ToString());
                    }

                    var dash = jObj.Property("dashboard");

                    if (dash != null)
                    {
                        if (jObj["dashboard"]["enableDashboard"] == null)
                        {
                            // enableDashboard not exist
                            jObj["dashboard"]["enableDashboard"] = false;
                            File.WriteAllText(configPath, jObj.ToString());
                        }
                    }
                    else
                    {
                        // dashboard not found
                        jObj.Add("dashboard", JObject.FromObject(new { enableDashboard = false }));
                        File.WriteAllText(configPath, jObj.ToString());

                    }

                    var coll = jObj.Property("collisionBounds");

                    if (coll != null)
                    {
                        if (jObj["collisionBounds"]["enableDashboard"] == null)
                        {
                            // CollisionBoundsColorGammaA not exist
                            jObj["collisionBounds"]["CollisionBoundsColorGammaA"] = 255;
                            File.WriteAllText(configPath, jObj.ToString());
                        }
                    }
                    else
                    {
                        // collisionBounds not found
                        jObj.Add("collisionBounds", JObject.FromObject(new { CollisionBoundsColorGammaA = 255 }));
                        File.WriteAllText(configPath, jObj.ToString());

                    }

                }
                else
                {
                    // config file not exist
                    MessageBox.Show("SteamVR config file not found. Please install SteamVR first then rerun the client! Existing now.");
                    Application.Exit();
                }

            }
            catch (Exception ex)
            {
                logger.Fatal("CheckSteamVRConfig: " + ex.ToString());
                throw;
            }
        }

        private void InitSystem()
        {
            _internalCurrentClientStatus = Enums.LiveClientStatus.ONLINE;

            _timer1s = new System.Timers.Timer();
            _timer1s.Elapsed += new ElapsedEventHandler(OnTimer1sEvent);
            _timer1s.Interval = 1000;
            _timer1s.Enabled = true;

        }

        private void OnTimer1sEvent(object sender, ElapsedEventArgs e)
        {
            lock (_lockTimer1s)
            {
                if (IsInitDone())
                {
                    ProcessClientRunningMode();
                    ClientUI_Dashboard_GameMonitoring();
                    VRArcadeHelper();
                }
                SendPingToServer();
            }
        }



        private void CheckInitRequests()
        {
            if (!Utility.IsSystemConfigLoaded())
            {
                GetAllSysConfigFromServer();
            }
            if (_internalClientRunningMode == null)
            {
                GetClientStatusFromServer();
            }
            if (_internalTileConfig == null && !_isRequestingTileWithImage)
            {
                GetTileConfigFromServer();
            }
            if (_internalTileConfig == null && _isRequestingTileWithImage)
            {
                GetTileConfigFromServerWithImage();
            }
            if (!Utility.IsSteamVRRunning())
            {
                Utility.StartSteamVR();
            }

        }

        private bool IsInitDone()
        {
            //var p = Process.GetProcesses(); // for debug

            bool result = Utility.IsSystemConfigLoaded() && _internalClientRunningMode != null &&
                _internalTileConfig != null && _isGameSelectorImageFolderPopulated && Utility.IsSteamVRRunning();

            if (!result)
            {
                CheckInitRequests();
            }

            return result;
        }



        private void EndSession()
        {
            _internalClientRunningMode.RunningMode = Enums.ClientRunningMode.ENDED_TIMING;

            EndSessionGeneric(Enums.SysConfigType.TIMES_UP_MESSAGE);
        }

        private void EndNonTimedSession()
        {
            EndSessionGeneric(Enums.SysConfigType.MANUAL_END_MESSAGE);
        }

        private void EndSessionEmergency()
        {
            EndSessionGeneric(Enums.SysConfigType.EMERGENCY_MESSAGE);
        }


        private void EndSessionGeneric(Enums.SysConfigType messageType)
        {
            if (_internalCurrentClientStatus != Enums.LiveClientStatus.CLEANING_DONE)
            {
                _internalCurrentClientStatus = Enums.LiveClientStatus.GAMEOVER_FOR_CLEANING;
                _internalClientRunningMode.Duration = 0;
                _internalClientRunningMode.StartTime = DateTime.MinValue;

                _internalEndGameMessageConfigType = messageType;

                _exitGameFlag = true;

                VRCommand cmd = new VRCommand(new EndNow(Utility.GetSystemConfig(_internalEndGameMessageConfigType) ?? "Your Time is up. Thanks for playing!"));
                SendCommandToUIClient(cmd);
            }

        }

        private void StartSession()
        {
            if (_internalCurrentClientStatus != Enums.LiveClientStatus.IN_GAME) // 
            {
                _internalCurrentClientStatus = Enums.LiveClientStatus.IN_GAME_SELECTOR;

                Debug.WriteLine("Start NOW");
                _exitGameFlag = false;

                VRCommand cmd = new VRCommand(Enums.ControlMessage.START_NOW);
                SendCommandToUIClient(cmd);
            }

        }


        // calling each second
        private void ProcessClientRunningMode()
        {
            if (_internalClientRunningMode != null)
            {
                switch (_internalClientRunningMode.RunningMode) // this is the retrived setup (should be state)
                {
                    case Enums.ClientRunningMode.TIMING_ON: // should be in timing mode

                        switch (_internalCurrentClientStatus) // this is the current client running mode
                        {
                            case Enums.LiveClientStatus.NONE:
                                break;
                            case Enums.LiveClientStatus.OFFLINE:
                                break;
                            case Enums.LiveClientStatus.ONLINE:
                            case Enums.LiveClientStatus.CLEANING_DONE:
                            case Enums.LiveClientStatus.GAMEOVER_FOR_CLEANING:

                                StartSession();

                                break;
                            case Enums.LiveClientStatus.IN_GAME_SELECTOR:
                            case Enums.LiveClientStatus.IN_GAME:
                            case Enums.LiveClientStatus.IN_GAME_STARTING:
                            case Enums.LiveClientStatus.GAME_EXITING:

                                double diff = (DateTime.Now - _internalClientRunningMode.StartTime).TotalMinutes;

                                if (diff > _internalClientRunningMode.Duration &&
                                    (_internalCurrentClientStatus != Enums.LiveClientStatus.GAMEOVER_FOR_CLEANING ||
                                    _internalCurrentClientStatus != Enums.LiveClientStatus.CLEANING_DONE))
                                {
                                    EndSession();
                                }

                                break;
                            case Enums.LiveClientStatus.ERROR:
                                break;
                            default:
                                break;
                        }

                        break;
                    case Enums.ClientRunningMode.NO_TIMING_ON: // should be in non-timing mode

                        switch (_internalCurrentClientStatus)
                        {
                            case Enums.LiveClientStatus.NONE:
                                break;
                            case Enums.LiveClientStatus.OFFLINE:
                                break;
                            case Enums.LiveClientStatus.ONLINE:
                            case Enums.LiveClientStatus.CLEANING_DONE:
                            case Enums.LiveClientStatus.GAMEOVER_FOR_CLEANING:

                                StartSession();

                                break;
                            case Enums.LiveClientStatus.IN_GAME_SELECTOR:
                                break;
                            case Enums.LiveClientStatus.IN_GAME:
                                break;
                            case Enums.LiveClientStatus.ERROR:
                                break;
                            default:
                                break;
                        }

                        break;
                    case Enums.ClientRunningMode.ENDED_TIMING: // should be timing game over

                        if (_internalCurrentClientStatus != Enums.LiveClientStatus.GAMEOVER_FOR_CLEANING && _internalCurrentClientStatus != Enums.LiveClientStatus.CLEANING_DONE)
                        {
                            EndSession();
                        }

                        break;
                    case Enums.ClientRunningMode.ENDED_MANUAL: // should be manual game over

                        if (_internalCurrentClientStatus != Enums.LiveClientStatus.GAMEOVER_FOR_CLEANING && _internalCurrentClientStatus != Enums.LiveClientStatus.CLEANING_DONE)
                        {
                            EndNonTimedSession();
                        }

                        break;
                    case Enums.ClientRunningMode.ENDED_EMERGENCY: // should be emergency game over

                        //if (_internalCurrentClientStatus != Enums.LiveClientStatus.GAMEOVER_FOR_CLEANING && _internalCurrentClientStatus != Enums.LiveClientStatus.CLEANING_DONE)
                        //{
                        //    EndSessionEmergency();
                        //}

                        EndSessionEmergency();

                        break;
                    default:
                        break;
                }



            }
        }

        /*
         
         To play a game: 
         
            1) Selector is running
            2) Run the game - now both game and selector is running, but game haven't take VR server yet.
            3) Wait 10 seconds and test again, if game still not taking VR server, shutdown the Selector.
            4) Wait another 30 seconds, if game still failed to take VR server, kill the game. (NOT POSSIBLE NOW)
            5) Start the Selector.

         To exit a game:
            
            1) If the game process dies, clear the _internalCurrentPlayingTile, set status and start the Selector.
             
        */

        // calling each second
        private void ClientUI_Dashboard_GameMonitoring()
        {
            // a game is waiting to start. This is a one off event.
            if (_internalCurrentPlayingTile != null && _gameStartTime == DateTime.MinValue)
            {
                _gameStartTime = DateTime.Now;
                _internalCurrentClientStatus = Enums.LiveClientStatus.IN_GAME_STARTING;

                string gameExePath = _internalCurrentPlayingTile.Command;

                if (gameExePath.Contains("[") && gameExePath.Contains("]"))
                {
                    Regex regex = new Regex(@"(.*)\[");
                    Match m = regex.Match(gameExePath);

                    gameExePath = m.Groups.Count == 2 ? m.Groups[1].Value : gameExePath;
                }

                Process proc = Utility.RunCommand(gameExePath, _internalCurrentPlayingTile.Arguments, _internalCurrentPlayingTile.WorkingPath, ProcessWindowStyle.Maximized);

                _internalAdditionalInfo = _internalCurrentPlayingTile.TileTitle;
                SendPlayLogToServer("-1", Enums.PlayLogSignalType.End);
                SendPlayLogToServer(_internalCurrentPlayingTile.TileID, Enums.PlayLogSignalType.Start);
                SendDashboardInfo();

                logger.Info("Running Game: {0}", _internalCurrentPlayingTile.Command);
                Debug.WriteLine("Running Game: " + _internalCurrentPlayingTile.Command);
            }


            //
            if (_internalCurrentPlayingTile != null && Utility.IsTileGameRunning(_internalCurrentPlayingTile) && !Utility.IsClientUIRunning())
            {
                // game is running and game selector is not and game is registed.
                _internalCurrentClientStatus = Enums.LiveClientStatus.IN_GAME;
                //logger.Info("In Game!");
                Debug.WriteLine("In Game!");
            }
            else if (_internalCurrentPlayingTile != null && Utility.IsClientUIRunning() && DateTime.Now.Subtract(_gameStartTime).TotalSeconds > 20)
            {
                // the selector is running while game should be running
                // after 50 seconds, kill the selector
                Utility.KillClientUI();
                logger.Info("Selector Killed!");
                Debug.WriteLine("Selector Killed!");
            }
            else if (_internalCurrentPlayingTile != null && _internalCurrentClientStatus == Enums.LiveClientStatus.IN_GAME_STARTING && DateTime.Now.Subtract(_gameStartTime).TotalSeconds > 50)
            {
                // if the game failed to run after 50 seconds, start client ui (Failed to execute game!)

                _exitGameFlag = true;
                logger.Info("Game Failed to Run witin 50 seconds!");
                Debug.WriteLine("Game Failed to Run witin 50 seconds!");
            }
            else if (_internalCurrentPlayingTile == null && _internalCurrentClientStatus == Enums.LiveClientStatus.IN_GAME && Utility.IsClientUIRunning())
            {
                // game selector is running
                _internalCurrentClientStatus = Enums.LiveClientStatus.IN_GAME_SELECTOR;
                logger.Info("Fix State #1");
                Debug.WriteLine("Fix State #1");
            }


            // check if game exit while in IN_GAME status
            if (_internalCurrentClientStatus == Enums.LiveClientStatus.IN_GAME || _exitGameFlag)
            {
                bool delay = DateTime.Now.Subtract(_gameStartTime).TotalSeconds > 10;
                bool isGameRunning = Utility.IsTileGameRunning(_internalCurrentPlayingTile);

                if (_internalCurrentPlayingTile != null && ((delay && !isGameRunning) || _exitGameFlag))
                {

                    logger.Info("Game Exited. _exitGameFlag:{0}, delay:{1}, _gameNotRunningConfirmation:{2}", _exitGameFlag.ToString(), delay.ToString(), _gameNotRunningConfirmation.ToString());
                    Debug.WriteLine("Game Exited " + _exitGameFlag.ToString() + " " + delay.ToString() + " " + _gameNotRunningConfirmation.ToString());

                    if (_gameNotRunningConfirmation++ >= 2)
                    {
                        // game is registered, de-register it if 1) game exit itself  2) user exit it through dashboard

                        logger.Info("De-Register Game Now");
                        Debug.WriteLine("De-Register Game Now");

                        _gameStartTime = DateTime.MinValue;

                        _internalAdditionalInfo = "";
                        SendPlayLogToServer(_internalCurrentPlayingTile.TileID, Enums.PlayLogSignalType.End);
                        _internalCurrentPlayingTile = null;
                        SendDashboardInfo();
                        _internalCurrentClientStatus = Enums.LiveClientStatus.GAME_EXITING;
                        _exitGameFlag = false;
                        _gameNotRunningConfirmation = 0;

                    }

                }
                else
                {
                    _gameNotRunningConfirmation = 0;
                }

            }


            if (_internalCurrentPlayingTile == null &&
                (_internalCurrentClientStatus == Enums.LiveClientStatus.GAMEOVER_FOR_CLEANING ||
                _internalCurrentClientStatus == Enums.LiveClientStatus.CLEANING_DONE ||
                _internalCurrentClientStatus == Enums.LiveClientStatus.GAME_EXITING ||
                _internalCurrentClientStatus == Enums.LiveClientStatus.IN_GAME_SELECTOR))
            {
                //logger.Info("Game Exit Check Point. Current Status: {0}", _internalCurrentClientStatus.ToString());
                Debug.WriteLine("Game Exit Check Point " + _internalCurrentClientStatus.ToString());

                if (!Utility.IsClientUIRunning())
                {
                    // game selector is not running

                    _isGameSelectorInitDone = false;

                    if (Utility.StartClientUI())
                    {
                        if (_internalCurrentClientStatus == Enums.LiveClientStatus.GAME_EXITING)
                        {
                            logger.Info("Was GAME_EXITING, Now IN_GAME_SELECTOR");
                            Debug.WriteLine("Was GAME_EXITING, Now IN_GAME_SELECTOR");
                            _internalCurrentClientStatus = Enums.LiveClientStatus.IN_GAME_SELECTOR;
                        }

                        logger.Info("Game Selector is started.");
                        Debug.WriteLine("Game Selector is started.");

                        SendPlayLogToServer("-1", Enums.PlayLogSignalType.Start);
                    }
                }
            }


            Utility.StartDashboard();


            // check SteamVR problem
            if (Utility.IsProgramRepeatRestartProblmeFound())
            {
                RebootComputer();
            }


        }


        private void VRArcadeHelper()
        {
            bool isDisableByDefault = false;

            bool.TryParse(Utility.GetSystemConfig(Enums.SysConfigType.DISABLE_KMU_BY_DEFAULT), out isDisableByDefault);

            if (isDisableByDefault && !_isDisableKUMExecuted)
            {
                var service = new ServiceController("VRArcadeHelperService");
                service.ExecuteCommand((int)Enums.KUMMessageType.DISABLE);
                _isDisableKUMExecuted = true;
            }

        }

        private void SendPlayLogToServer(string tileID, Enums.PlayLogSignalType signalType)
        {
            PlayLog playLog = new PlayLog(tileID, signalType);

            VRCommand cmd = new VRCommand(playLog);
            SendCommandToServer(cmd);
        }

        private void SetAllTileConfigFromServer(TileConfig tileConfig)
        {
            string dataFolder = Utility.GetGameSelectorDataFolder();

            Utility.MakeSureFolderExist(dataFolder + @"Images");

            _internalTileConfig = null;

            if (PopulateImageFolder(tileConfig.MainScreenTiles, dataFolder))
            {
                _internalTileConfig = tileConfig;

                if (_internalClientRunningMode != null && (_internalClientRunningMode.RunningMode == Enums.ClientRunningMode.TIMING_ON || _internalClientRunningMode.RunningMode == Enums.ClientRunningMode.NO_TIMING_ON))
                {
                    Tile playTile = _internalTileConfig.MainScreenTiles.Where(x => x.TileID == _internalClientRunningMode.CurrentRunningTileID.ToString()).FirstOrDefault();

                    if (playTile != null)
                    {
                        _internalCurrentPlayingTile = playTile;
                    }
                }

                _isRequestingTileWithImage = false;

                Debug.WriteLine("========IMAGE GOOD");
            }
            else
            {
                // some image not exist / not match
                _isRequestingTileWithImage = true;

                Debug.WriteLine("========IMAGE NOT GOOD");
            }


        }

        private bool PopulateImageFolder(List<Tile> lTile, string dataFolder)
        {
            try
            {

                List<Tile> lt = lTile.Where(x => x.ImagePath != "").ToList();

                foreach (Tile t in lt)
                {
                    if (t.ImagePath.Length > 0)
                    {
                        t.ImagePath = (!t.ImagePath.Contains(@"\")) ? @"Images\" + t.ImagePath : t.ImagePath;

                        string imgFilePath = dataFolder + t.ImagePath;

                        if (File.Exists(imgFilePath))
                        {
                            uint imgCrc = Crc32CAlgorithm.Compute(File.ReadAllBytes(imgFilePath));

                            if (imgCrc != t.TileImage.ImageCRC)
                            {
                                if (t.TileImage.IsOnlyCRC)
                                {
                                    // no image data, return
                                    return false;
                                }
                                else
                                {
                                    File.WriteAllBytes(imgFilePath, t.TileImage.ImageData);
                                }
                            }
                            else
                            {
                                this.GetType();
                            }

                        }
                        else
                        {
                            if (t.TileImage.IsOnlyCRC)
                            {
                                // no image data, return
                                return false;
                            }
                            else
                            {
                                File.WriteAllBytes(imgFilePath, t.TileImage.ImageData);
                            }
                        }
                    }

                    if (t.ChildTiles.Count > 0)
                    {
                        if (!PopulateImageFolder(t.ChildTiles, dataFolder))
                        {
                            return false;
                        }
                    }
                }

                /*lt = lTile.Where(x => x.ChildTiles != null && x.ChildTiles.Count > 0).ToList();

                foreach (Tile tile in lt)
                {
                    foreach (Tile t in tile.ChildTiles)
                    {
                        t.ImagePath = (!t.ImagePath.Contains(@"\")) ? @"Images\" + t.ImagePath : t.ImagePath;

                        string imgFilePath = dataFolder + t.ImagePath;
                        if (File.Exists(imgFilePath))
                        {
                            uint imgCrc = Crc32CAlgorithm.Compute(File.ReadAllBytes(imgFilePath));

                            if (imgCrc != t.TileImage.ImageCRC)
                            {
                                File.WriteAllBytes(imgFilePath, t.TileImage.ImageData);
                            }

                        }
                        else
                        {
                            File.WriteAllBytes(imgFilePath, t.TileImage.ImageData);
                        }

                        if (t.ChildTiles.Count > 0)
                        {
                            PopulateImageFolder(t.ChildTiles, dataFolder);
                        }
                    }
                }*/

                _isGameSelectorImageFolderPopulated = true;
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("PopulateImageFolder:" + ex.ToString());
                return false;
            }
        }



        private void SetAllSysConfigFromServer(List<SysConfig> systemConfig)
        {
            Utility.SetSystemConfig(systemConfig);
        }


        private void SetClientCurrentRunningMode(ClientRunningMode clientRunningMode)
        {
            _internalClientRunningMode = clientRunningMode;

        }

        private void GetClientStatusFromServer()
        {
            VRCommand vrc = new VRCommand(Enums.ControlMessage.STATUS);

            SendCommandToServer(vrc);
        }

        private void GetAllSysConfigFromServer()
        {
            VRCommand vrc = new VRCommand(Enums.ControlMessage.GET_ALL_SYSCONFIG);

            SendCommandToServer(vrc);
        }

        private void GetTileConfigFromServer()
        {
            VRCommand vrc = new VRCommand(Enums.ControlMessage.GET_ALL_TILE_CONFIG);

            SendCommandToServer(vrc);
        }

        private void GetTileConfigFromServerWithImage()
        {
            VRCommand vrc = new VRCommand(Enums.ControlMessage.GET_ALL_TILE_CONFIG_WITH_IMAGE);

            SendCommandToServer(vrc);
        }

        private void SetClientUITileConfig()
        {
            if (_internalTileConfig != null)
            {
                TileConfig tmpTileConfig = _internalTileConfig;

                if (_internalClientRunningMode != null && _internalClientRunningMode.CustomerAge > 0)
                {
                    tmpTileConfig.MainScreenTiles.RemoveAll(x => x.AgeRequire > _internalClientRunningMode.CustomerAge);
                }

                VRCommand cmd = new VRCommand(tmpTileConfig);
                SendCommandToUIClient(cmd);

            }
        }

        private void SendDashboardInfo()
        {
            VRCommand vrc = new VRCommand(new DashboardInfo(_internalClientRunningMode));

            SendCommandToDashboardClient(vrc);
        }

        private void SetCleaningProvided()
        {
            _internalCurrentClientStatus = Enums.LiveClientStatus.CLEANING_DONE;
        }

        private void TurnOffComputer()
        {
            if (_internalCurrentClientStatus == Enums.LiveClientStatus.IN_GAME)
            {
                SendPlayLogToServer(_internalCurrentPlayingTile.TileID, Enums.PlayLogSignalType.End);
            }
            else if (_internalCurrentClientStatus == Enums.LiveClientStatus.IN_GAME_SELECTOR)
            {
                SendPlayLogToServer("-1", Enums.PlayLogSignalType.End);
            }

            Utility.ShutDown();
        }

        private void RebootComputer()
        {
            if (_internalCurrentClientStatus == Enums.LiveClientStatus.IN_GAME)
            {
                SendPlayLogToServer(_internalCurrentPlayingTile.TileID, Enums.PlayLogSignalType.End);
            }
            else if (_internalCurrentClientStatus == Enums.LiveClientStatus.IN_GAME_SELECTOR)
            {
                SendPlayLogToServer("-1", Enums.PlayLogSignalType.End);
            }

            Utility.Restart();
        }

        private void TurnOnKUM()
        {
            var service = new ServiceController("VRArcadeHelperService");

            bool isReEnforceKUM = false;
            bool.TryParse(Utility.GetSystemConfig(Enums.SysConfigType.RE_DISABLE_KMU_AFTER_20_MIN), out isReEnforceKUM);

            if (isReEnforceKUM)
            {
                service.ExecuteCommand((int)Enums.KUMMessageType.ENABLE_ONLY_20_MIN);
            }
            else
            {
                service.ExecuteCommand((int)Enums.KUMMessageType.ENABLE);
            }

            //service.WaitForStatus(ServiceControllerStatus.Running, timeout);
        }

        private void TurnOffKUM()
        {
            var service = new ServiceController("VRArcadeHelperService");
            service.ExecuteCommand((int)Enums.KUMMessageType.DISABLE);
            //service.WaitForStatus(ServiceControllerStatus.Running, timeout);
        }

        private void VolumeControl(string command)
        {
            float mmVol;

            MMDeviceEnumerator mmDevEnum = new MMDeviceEnumerator();
            MMDevice mmdevice = mmDevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);

            mmVol = mmdevice.AudioEndpointVolume.MasterVolumeLevelScalar;

            switch (command.ToUpper())
            {
                case "UP":

                    mmVol += 0.1f;

                    if (mmVol > 1)
                    {
                        mmVol = 1;
                    }

                    break;

                case "DOWN":

                    mmVol -= 0.1f;

                    if (mmVol < 0)
                    {
                        mmVol = 0;
                    }

                    break;

                default:
                    break;
            }

            mmdevice.AudioEndpointVolume.MasterVolumeLevelScalar = mmVol;

        }


        //private void TerminateGameCombo(List<AppInfo> lAppInfo)
        //{
        //    System.Threading.Timer timer = null;
        //    timer = new System.Threading.Timer((obj) =>
        //    {
        //        SendCommandToDashboardClient(new VRCommand(Enums.ControlMessage.UNITY_DASHBOARD_GETRUNNINGGAMES, new RunningGameInfo(true)));
        //        timer.Dispose();
        //        timer = null;
        //    }, null, 500, Timeout.Infinite);
        //}

        //private void TerminateGame(List<AppInfo> lAppInfo, bool force = false)
        //{

        //    if (lAppInfo != null)
        //    {
        //        try
        //        {
        //            foreach (AppInfo appInfo in lAppInfo)
        //            {
        //                if (!force)
        //                {
        //                    Process.GetProcessById(appInfo.ProcessID).CloseMainWindow();
        //                    //Debug.WriteLine(">>>CloseMainWindow Called on Program (" + appInfo.ProcessID.ToString() + "): " + appInfo.Path);
        //                }
        //                else
        //                {
        //                    Process.GetProcessById(appInfo.ProcessID).Kill();
        //                    //Debug.WriteLine(">>>Kill Called on Program (" + appInfo.ProcessID.ToString() + "): " + appInfo.Path);

        //                    if (_internalCurrentPlayingTile != null)
        //                    {
        //                        Process proc = Utility.IsProcessOpenWithFullPath(_internalCurrentPlayingTile.Command);

        //                        if (proc != null)
        //                        {
        //                            proc.Kill();
        //                        }

        //                    }
        //                }
        //            }
        //        }
        //        catch
        //        {

        //        }
        //    }

        //}



    }
}
