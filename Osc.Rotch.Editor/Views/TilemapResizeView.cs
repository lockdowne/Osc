using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Osc.Rotch.Editor.Views
{
    public partial class TilemapResizeView : Telerik.WinControls.UI.RadForm
    {
        public int TilemapWidth
        {
            get { return Convert.ToInt32(numericWidth.Value); }
            set { numericWidth.Value = value; }
        }

        public int TilemapHeight
        {
            get { return Convert.ToInt32(numericHeight.Value); }
            set { numericHeight.Value = value; }
        }

        public TilemapResizeView(int tilemapWidth = 0, int tilemapHeight = 0)
        {
            InitializeComponent();

            this.TilemapWidth = tilemapWidth;
            this.TilemapHeight = tilemapHeight;

            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
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
