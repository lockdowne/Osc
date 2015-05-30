using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace oEditor.Views
{
    public partial class ListItemRenameView : Telerik.WinControls.UI.RadForm
    {
        public string ItemValue
        {
            get { return txtRenameLayer.Text; }
            set { txtRenameLayer.Text = value; }
        }

        public ListItemRenameView(string itemValue = "")
        {
            InitializeComponent();

            this.ItemValue = itemValue;

            this.StartPosition = FormStartPosition.CenterScreen;

            DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.btnTilemapLayerCancel.Click += (sender, e) => { DialogResult = System.Windows.Forms.DialogResult.Cancel; Close(); };
            this.btnTilemapLayerOK.Click += (sender, e) => { DialogResult = System.Windows.Forms.DialogResult.OK; Close(); };
        }
    }
}
