using NetworkCommsDotNet;
using System;
using System.Windows.Forms;

namespace VRGameSelectorClientDaemon
{
    public partial class ClientDaemonMain : Form
    {
        public ClientDaemonMain()
        {
            InitializeComponent();

            ClientDaemon daemon = ClientDaemon.Instance;

            daemon.OnConnectionStateChange += Daemon_OnConnectionStateChange;

            string ip = "";
            string mac = "";

            Utility.GetIPInfo(out ip, out mac);

            labelMachineName.Text = "Machine Name: " + Environment.MachineName;
            labelIP.Text = "IP Address: " + ip;
            labelMAC.Text = "MAC Address: " + mac;

            Text += " (Build: " + Properties.Resources.BuildDate.Trim() + ")";

        }

        private void Daemon_OnConnectionStateChange(object sender, EventArgs e)
        {
            bool IsUIConnected = false;
            bool IsDashboardConnected = false;
            bool IsServerConnected = false;
            ClientDaemon daemon = ClientDaemon.Instance;

            if (daemon._targetUIClientConnectionInfo != null && daemon._targetUIClientConnectionInfo.ConnectionState == ConnectionState.Established)
            {
                IsUIConnected = true;
            }

            if (daemon._targetDashboardClientConnectionInfo != null && daemon._targetDashboardClientConnectionInfo.ConnectionState == ConnectionState.Established)
            {
                IsDashboardConnected = true;
            }

            if (daemon._targetServerConnectionInfo != null && daemon._targetServerConnectionInfo.ConnectionState == ConnectionState.Established)
            {
                IsServerConnected = true;
            }

            this.InvokeUI(() =>
            {
                lblConnS.Text = "Server Connected: " + (IsServerConnected ? "Yes" : "No");
                lblConnUI.Text = "Client UI Connection: " + (IsUIConnected ? "Yes" : "No");
                lblConnDashboard.Text = "Client Dashboard Connection: " + (IsDashboardConnected ? "Yes" : "No");
            });

        }


        private void ClientDaemonMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClientDaemon daemon = ClientDaemon.Instance;

            daemon.OnConnectionStateChange -= Daemon_OnConnectionStateChange;

            NetworkComms.Shutdown();
        }

        private void ClientDaemonMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utility.KillClientUI();

            Utility.KillDashboard();
        }
    }
}
