using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using VRGameSelectorServerDTO;

namespace ManagingSystem
{
    public partial class KeyAdd : Telerik.WinControls.UI.RadForm
    {

        public KeyAdd()
        {
            InitializeComponent();

            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void InitData()
        {
            NetworkFunction.OnIncommingKeyTypeInfoList += NetworkFunction_OnIncommingKeyTypeInfoList;
        }

        private void NetworkFunction_OnIncommingKeyTypeInfoList(object sender, EventArgs e)
        {
            List<KeyTypeInfo> lKeyTypeInfo = ((KeyTypeInfoEvent)e).ListKeyTypeInfo;

            this.InvokeUI(() =>
            {
                comboBoxKeyType.Items.Clear();

                if (lKeyTypeInfo != null)
                {
                    foreach (KeyTypeInfo keyTypeInfo in lKeyTypeInfo)
                    {
                        RadListDataItem rListItem = new RadListDataItem(keyTypeInfo.KeyTypeName, keyTypeInfo.KeyTypeID);

                        comboBoxKeyType.Items.Add(rListItem);

                    }

                }

            });
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClientDetail_Load(object sender, EventArgs e)
        {
            InitData();
            NetworkFunction.GetKeyType();

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            List<KeyInfo> lKeyInfo = new List<KeyInfo>();

            lKeyInfo.Add(new KeyInfo()
            {
                KeyTypeName = (comboBoxKeyType.SelectedItem != null) ? comboBoxKeyType.SelectedItem.Text : "",
                KeyTypeID = (comboBoxKeyType.SelectedItem != null) ? (int)comboBoxKeyType.SelectedItem.Value : 0,
                Minutes = (int)radSpinEditorSessionTime.Value
            });

            NetworkFunction.AddKey(lKeyInfo);

            this.Close();
        }

        private void ClientDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            NetworkFunction.OnIncommingKeyTypeInfoList -= NetworkFunction_OnIncommingKeyTypeInfoList;
        }

        private void comboBoxKeyType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (comboBoxKeyType.SelectedItem != null && comboBoxKeyType.SelectedItem.Text == "KEY-START-TIMING")
            {
                radSpinEditorSessionTime.Enabled = true;
            }
            else
            {
                radSpinEditorSessionTime.Enabled = false;
            }
        }
    }
}
