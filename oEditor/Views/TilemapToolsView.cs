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
    public partial class TilemapToolsView : RadForm, ITilemapToolsView
    {        
        public RadPageViewPageCollection Pages
        {
            get { return radPageView.Pages; }
        }

        public event Action AddTilesetClicked;
        public event Action DeleteTilesetClicked;
        public event Action AddLayerClicked;
        public event Action DeleteLayerClicked;
        public event Action MoveLayerUpClicked;
        public event Action MoveLayerDownClicked;

        public TilemapToolsView()
        {
            InitializeComponent();

        }

        private void btnAddTileset_Click(object sender, EventArgs e)
        {
            if (AddTilesetClicked != null)
                AddTilesetClicked();
        }

        private void btnDeleteTileset_Click(object sender, EventArgs e)
        {
            if (DeleteTilesetClicked != null)
                DeleteTilesetClicked();
        }

        private void btnAddLayer_Click(object sender, EventArgs e)
        {
            if (AddLayerClicked != null)
                AddLayerClicked();
        }

        private void btnDeleteLayer_Click(object sender, EventArgs e)
        {
            if (DeleteLayerClicked != null)
                DeleteLayerClicked();
        }

        private void btnMoveLayerUp_Click(object sender, EventArgs e)
        {
            if (MoveLayerUpClicked != null)
                MoveLayerUpClicked();
        }

        private void btnMoveLayerDown_Click(object sender, EventArgs e)
        {
            if (MoveLayerDownClicked != null)
                MoveLayerDownClicked();
        }
    }
}
