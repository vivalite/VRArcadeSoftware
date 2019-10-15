using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using VRGameSelectorServerDTO;

namespace ManagingSystem
{
    public partial class ClientDetail : Telerik.WinControls.UI.RadForm
    {
        private Client _client = new Client();
        private bool IsEdit;

        public ClientDetail()
        {
            InitializeComponent();

            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        public ClientDetail(Client client) : this()
        {
            _client = client;
            IsEdit = true;
        }

        private void InitData()
        {
            NetworkFunction.OnIncommingConfigSetList += NetworkFunction_OnIncommingConfigSetList;
        }

        private void NetworkFunction_OnIncommingConfigSetList(object sender, EventArgs e)
        {
            List<ConfigSet> lcs = ((ConfigSetEvent)e).ListConfigSets;

            this.InvokeUI(() =>
            {
                comboBoxConfigSet.Items.Clear();
            });

            if (lcs != null)
            {
                foreach (ConfigSet cs in lcs)
                {
                    this.InvokeUI(() =>
                    {
                        RadListDataItem rListItem = new RadListDataItem(cs.Name, cs.ID);

                        if (cs.ID == _client.TileConfigSetID)
                        {
                            rListItem.Selected = true;
                        }

                        comboBoxConfigSet.Items.Add(rListItem);


                    });
                }
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClientDetail_Load(object sender, EventArgs e)
        {
            InitData();
            NetworkFunction.GetConfigSet();

            if (_client != null)
            {
                textBoxIPAddress.Text = _client.IPAddress;
                textBoxDashboardModuleIP.Text = _client.DashboardModuleIP;
                textBoxMachineName.Text = _client.MachineName;
            }
            else
            {
                _client = new Client();
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _client.IPAddress = textBoxIPAddress.Text;
            _client.DashboardModuleIP = textBoxDashboardModuleIP.Text;
            _client.TileConfigSetID = (comboBoxConfigSet.SelectedItem != null) ? (int)comboBoxConfigSet.SelectedItem.Value : 0;

            if (IsEdit)
            {
                NetworkFunction.ModifyClientConfig(_client);
            }
            else
            {
                NetworkFunction.AddClientConfig(_client);
            }

            this.Close();
        }

        private void ClientDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            NetworkFunction.OnIncommingConfigSetList -= NetworkFunction_OnIncommingConfigSetList;
        }
    }
}
