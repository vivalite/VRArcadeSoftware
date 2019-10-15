using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.Layouts;
using Telerik.WinControls.UI;

namespace ManagingSystem
{
    public class CustomWaiverProcessListViewCellElementProcess : DetailListViewDataCellElement
    {
        private RadRadioButtonElement non_timed_option;
        private RadRadioButtonElement timed_option;
        private RadSpinEditorElement duration;
        private StackLayoutPanel stackLayout;

        public CustomWaiverProcessListViewCellElementProcess(DetailListViewVisualItem owner,
            ListViewDetailColumn column) : base(owner, column)
        {
        }

        protected override void CreateChildElements()
        {
            base.CreateChildElements();

            stackLayout = new StackLayoutPanel();
            stackLayout.Orientation = System.Windows.Forms.Orientation.Horizontal;

            non_timed_option = new RadRadioButtonElement();
            non_timed_option.Text = "Non-Timed Session";
            non_timed_option.Margin = new Padding(5, 3, 0, 0);
            non_timed_option.MouseUp += Non_timed_option_MouseUp;

            timed_option = new RadRadioButtonElement();
            timed_option.Text = "Timed Session";
            timed_option.Margin = new Padding(5, 3, 0, 0);
            timed_option.MouseUp += Timed_option_MouseUp;


            duration = new RadSpinEditorElement();
            duration.Value = 50;
            duration.MaxValue = 999;
            duration.MinValue = 1;
            duration.AutoSize = false;
            duration.Size = new Size(50, 30);
            duration.Margin = new Padding(5, 5, 0, 0);
            duration.Visibility = ElementVisibility.Hidden;
            duration.ValueChanged += Duration_ValueChanged;

            stackLayout.Children.Add(non_timed_option);
            stackLayout.Children.Add(timed_option);
            stackLayout.Children.Add(duration);

            this.Children.Add(this.stackLayout);
        }

        private void Duration_ValueChanged(object sender, EventArgs e)
        {
            DataRowView rowView = this.Row.DataBoundItem as DataRowView;

            ((ClientActionType)rowView.Row["Data"]).Duration = (int)duration.Value;
        }

        private void Timed_option_MouseUp(object sender, EventArgs e)
        {
            DataRowView rowView = this.Row.DataBoundItem as DataRowView;

            ((ClientActionType)rowView.Row["Data"]).StartType = ClientActionType.ClientStartType.TIMED_START;

            Synchronize();
        }

        private void Non_timed_option_MouseUp(object sender, EventArgs e)
        {
            DataRowView rowView = this.Row.DataBoundItem as DataRowView;

            ((ClientActionType)rowView.Row["Data"]).StartType = ClientActionType.ClientStartType.NON_TIMED_START;

            Synchronize();
        }


        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(DetailListViewHeaderCellElement);
            }
        }

        public override void Synchronize()
        {
            base.Synchronize();
            this.Text = "";
            if (this.Row != null)
            {
                DataRowView rowView = this.Row.DataBoundItem as DataRowView;

                ClientActionType cat = (ClientActionType)rowView.Row["Data"];

                if (cat.StartType == ClientActionType.ClientStartType.TIMED_START)
                {
                    non_timed_option.CheckState = CheckState.Unchecked;
                    timed_option.CheckState = CheckState.Checked;
                    duration.Value = cat.Duration;
                    duration.Visibility = ElementVisibility.Visible;
                }
                else if (cat.StartType == ClientActionType.ClientStartType.NON_TIMED_START)
                {
                    non_timed_option.CheckState = CheckState.Checked;
                    timed_option.CheckState = CheckState.Unchecked;
                    duration.Visibility = ElementVisibility.Hidden;
                }
                else
                {
                    non_timed_option.CheckState = CheckState.Unchecked;
                    timed_option.CheckState = CheckState.Unchecked;
                    duration.Visibility = ElementVisibility.Hidden;
                }

            }

        }



        public override bool IsCompatible(ListViewDetailColumn data, object context)
        {
            if (data.Name != "Operation")
            {
                return false;
            }
            return base.IsCompatible(data, context);
        }
    }
}
