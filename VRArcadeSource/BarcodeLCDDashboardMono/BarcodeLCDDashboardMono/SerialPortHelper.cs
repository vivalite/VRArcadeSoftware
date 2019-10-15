using SerialPortLib2;
using SerialPortLib2.Port;
using System;
using System.Text;
using System.Timers;

namespace BarcodeLCDDashboardMono
{
    public static class SerialPortHelper
    {
        private static SerialPortInput _serialPort;
        private static System.Timers.Timer _timerDataFlush;
        private static string _rcv_data = "";
        public static event EventHandler OnSerialPort_MessageReceived = delegate { };
        public static event EventHandler OnSerialPort_ConnectionStatusChanged = delegate { };

        public static void InitSerialPort(string device, bool isVirtual)
        {
            _serialPort = new SerialPortInput(isVirtual);

            //_serialPort.SetPort(device, 38400);
            _serialPort.SetPort(device, 9600);
            _serialPort.ConnectionStatusChanged += SerialPort_ConnectionStatusChanged;
            _serialPort.MessageReceived += SerialPort_MessageReceived;

            OpenConnection();

            _timerDataFlush = new System.Timers.Timer();
            _timerDataFlush.Elapsed += new ElapsedEventHandler(OnTimerDataFlushEvent);
            _timerDataFlush.Interval = 250;
            _timerDataFlush.Enabled = false;
        }

        public static bool OpenConnection()
        {
            if (!_serialPort.IsConnected)
            {
                return _serialPort.Connect();
            }
            else
                return false;
        }

        public static void CloseConnection()
        {
            if (_serialPort != null)
            {
                _serialPort.Disconnect();
            }
        }

        public static bool write(byte[] packet)
        {
            return _serialPort.SendMessage(packet);
        }

        private static void SerialPort_MessageReceived(object sender, MessageReceivedEventArgs args)
        {
            ReceiveMesageOps(Encoding.ASCII.GetString(args.Data).Replace("\r", "").Replace("\n", ""));
        }
        private static void SerialPort_ConnectionStatusChanged(object sender, ConnectionStatusChangedEventArgs args)
        {
            //if (OnConnecting != null)
            //    OnConnecting(this, new StateDeviceEventArgs(args.Connected));

            OnSerialPort_ConnectionStatusChanged(null, new SerialConnectionStatusChangedEvent(args));
        }

        private static void ReceiveMesageOps(string msg)
        {
            _rcv_data += msg;
            _timerDataFlush.Enabled = false;
            _timerDataFlush.Enabled = true;
        }

        private static void OnTimerDataFlushEvent(object sender, ElapsedEventArgs e)
        {
            _timerDataFlush.Enabled = false;

            SerialMessageReceivedEvent smre = new SerialMessageReceivedEvent(_rcv_data);

            _rcv_data = "";

            OnSerialPort_MessageReceived(null, smre);

        }
    }


    public class SerialMessageReceivedEvent : EventArgs
    {
        public SerialMessageReceivedEvent(string msg)
        {
            Message = msg;
        }
        public string Message { get; set; }
    }

    public class SerialConnectionStatusChangedEvent : EventArgs
    {
        public SerialConnectionStatusChangedEvent(ConnectionStatusChangedEventArgs args)
        {
            ARGS = args;
        }
        public ConnectionStatusChangedEventArgs ARGS { get; set; }
    }

}
