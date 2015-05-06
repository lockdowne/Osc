using oEditor.Aggregators;
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
    public partial class TilemapLayerRenameView : RadForm
    {
        private IEventAggregator eventAggregator;

        public string LayerName
        {
            get { return txtRenameLayer.Text; }
            set { txtRenameLayer.Text = value; }
        }

        public TilemapLayerRenameView(IEventAggregator eventAggregator, string layerName)
        {
            this.eventAggregator = eventAggregator;
    
            InitializeComponent();

            this.LayerName = layerName;

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnTilemapLayerOK_Click(object sender, EventArgs e)
        {
            eventAggregator.Publish(new OnRenameTilemapLayerOK() { LayerName = LayerName });
            Close();
        }

        private void btnTilemapLayerCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
