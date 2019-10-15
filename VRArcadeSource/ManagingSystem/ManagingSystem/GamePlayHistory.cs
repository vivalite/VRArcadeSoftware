using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VRGameSelectorServerDTO;

namespace ManagingSystem
{
    public partial class GamePlayHistory : Telerik.WinControls.UI.RadForm
    {
        int _clientID = 0;

        public GamePlayHistory()
        {
            InitializeComponent();

            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        public GamePlayHistory(int clientID) : this()
        {
            NetworkFunction.OnIncommingGamePlayHistory += NetworkFunction_OnIncommingGamePlayHistory;
            _clientID = clientID;

        }

        private void NetworkFunction_OnIncommingGamePlayHistory(object sender, EventArgs e)
        {
            List<VRGameSelectorServerDTO.GamePlayHistory> lgph = ((GamePlayHistoryEvent)e).ListGamePlayHistory;

            this.InvokeUI(() =>
            {
                listViewHistory.BeginUpdate();
                listViewHistory.Items.Clear();

                foreach (VRGameSelectorServerDTO.GamePlayHistory gph in lgph)
                {
                    ListViewItem lvi = new ListViewItem(new string[] { gph.TileName, (gph.StartTime != DateTime.MinValue) ? gph.StartTime.ToString() : "-", (gph.EndTime != DateTime.MinValue) ? gph.EndTime.ToString() : "-" });
                    lvi.Name = gph.TileName;

                    listViewHistory.Items.Add(lvi);
                }
                listViewHistory.EndUpdate();
            });


        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GamePlayHistory_Load(object sender, EventArgs e)
        {
            NetworkFunction.GetGamePlayHistory(_clientID);
        }

        private void GamePlayHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            NetworkFunction.OnIncommingGamePlayHistory -= NetworkFunction_OnIncommingGamePlayHistory;
        }
    }
}
