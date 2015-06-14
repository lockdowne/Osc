using Osc.Rotch.Engine.Aggregators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Osc.Rotch.Editor.Events;

namespace Osc.Rotch.Editor.Views
{
    public partial class TilemapPropertiesView : RadForm, ITilemapPropertiesView
    {
        private readonly IEventAggregator eventAggregator;

        public Guid ID { get; set; }

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

        public TilemapPropertiesView(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            DialogResult = System.Windows.Forms.DialogResult.Cancel;

            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;

            eventAggregator.Publish(new OnTilemapPropertiesSaved() { ID = ID, TilemapDescription = TilemapDescription, TilemapName = TilemapName,  });
       
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
