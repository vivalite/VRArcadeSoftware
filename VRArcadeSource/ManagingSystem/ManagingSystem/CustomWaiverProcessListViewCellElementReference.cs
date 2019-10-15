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
    public class CustomWaiverProcessListViewCellElementReference : DetailListViewDataCellElement
    {
        private RadAutoCompleteBoxElement reference;
        private StackLayoutPanel stackLayout;

        public CustomWaiverProcessListViewCellElementReference(DetailListViewVisualItem owner,
            ListViewDetailColumn column) : base(owner, column)
        {
        }

        protected override void CreateChildElements()
        {
            base.CreateChildElements();

            stackLayout = new StackLayoutPanel();
            stackLayout.Orientation = System.Windows.Forms.Orientation.Horizontal;

            reference = new RadAutoCompleteBoxElement();
            reference.AutoSize = false;
            reference.Size = new Size(110, 30);
            reference.Margin = new Padding(5, 5, 0, 0);
            reference.Capture = false;
            reference.NullText = "Hit Enter To Search";
            reference.TextAlign = HorizontalAlignment.Center;
            reference.Padding = new Padding(0, 4, 0, 0);
            
            reference.KeyUp += Refrence_KeyUp;
            reference.KeyPress += Refrence_KeyPress;


            stackLayout.Children.Add(reference);

            this.Children.Add(this.stackLayout);
        }

        private void Refrence_KeyUp(object sender, KeyEventArgs e)
        {
            DataRowView rowView = this.Row.DataBoundItem as DataRowView;

            rowView.Row["Reference"] = reference.Text;
        }

        private void Refrence_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);

            if (e.KeyChar == (char)13)
            {
                DataRowView rowView = this.Row.DataBoundItem as DataRowView;
                rowView.Row["UPD_REQ"] = true;
            }

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

                reference.Text = (string)rowView.Row["Reference"];
            }

        }



        public override bool IsCompatible(ListViewDetailColumn data, object context)
        {
            if (data.Name != "Reference")
            {
                return false;
            }
            return base.IsCompatible(data, context);
        }
    }
}
