using oEditor.Aggregators;
using oEditor.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Views
{
    public partial class MainView : RadForm, IMainView
    {
        private readonly IEventAggregator eventAggregator;

        public RadDock DockManager
        {
            get { return radDock; }
        }

        public MainView(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            InitializeComponent();

            TilemapToolboxView v = new TilemapToolboxView(eventAggregator);
            v.Show();
            
         
            this.Load += (sender, e) =>
            {
                eventAggregator.Publish(new OnMainLoaded() { View = this });                
            };
        }

        private void radDock_DockWindowAdded(object sender, DockWindowEventArgs e)
        {
            eventAggregator.Publish(new OnMainDockWindowAdded() { Args = e });
        }

        private void radDock_DockWindowClosed(object sender, DockWindowEventArgs e)
        {
            eventAggregator.Publish(new OnMainDockWindowClosed() { Args = e });
        }

        private void radDock_DockWindowClosing(object sender, DockWindowCancelEventArgs e)
        {
            eventAggregator.Publish(new OnMainDockWindowClosing() { Args = e });
        }
    }
}
