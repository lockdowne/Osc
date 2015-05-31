using oEngine.Aggregators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace oEditor.Views
{
    public partial class TilemapPropertiesView : RadForm
    {
        public string TilemapName
        {
            get { return txtTilemapName.Text; }
            set { txtTilemapName.Text = value; }
        }

        public string TilemapDescription
        {
            get { return txtTilemapDescription.Text; }
            set { txtTilemapDescription.Text = value; }
        }

        public int TilemapWidth
        {
            get { return (int)txtTilemapWidth.Value; }
            set { txtTilemapWidth.Value = value; }
        }

        public int TilemapHeight
        {
            get { return (int)txtTilemapHeight.Value; }
            set { txtTilemapHeight.Value = value; }
        }

        public TilemapPropertiesView(string tilemapName, string tilemapDescription, int tilemapWidth, int tilemapHeight)
        {
            InitializeComponent();

            this.TilemapName = tilemapName;
            this.TilemapDescription = tilemapDescription;
            this.TilemapWidth = tilemapWidth;
            this.TilemapHeight = tilemapHeight;

            this.StartPosition = FormStartPosition.CenterScreen;

            DialogResult = System.Windows.Forms.DialogResult.Cancel;

            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
