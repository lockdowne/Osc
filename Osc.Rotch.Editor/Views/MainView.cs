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
using Osc.Rotch.Engine.Common;
using Osc.Rotch.Engine.Aggregators;
using Osc.Rotch.Editor.Events;
using System.Threading.Tasks;
using System.Threading;

namespace Osc.Rotch.Editor.Views
{
    public partial class MainView : RadRibbonForm, IMainView
    {
        private readonly IEventAggregator eventAggregator;

        public RadDock DockManager
        {
            get { return radDock; }
        }

        public MainView(IEventAggregator eventAggregator)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            this.eventAggregator = eventAggregator;


            chkConsoleWindow.CheckStateChanged += (sender, e) =>
            {
                eventAggregator.Publish(new OnConsoleWindowVisibilityChanged() { IsVisible = chkConsoleWindow.Checked });
            };

            chkEntitiesWindow.CheckStateChanged += (sender, e) =>
            {
                eventAggregator.Publish(new OnEntitiesWindowVisibilityChanged() { IsVisible = chkEntitiesWindow.Checked });
            };

            chkProjectWindow.CheckStateChanged += (sender, e) =>
            {
                eventAggregator.Publish(new OnProjectWindowVisibilityChanged() { IsVisible = chkProjectWindow.Checked });
            };

            radDock.DockWindowClosed += (sender, e) =>
            {
                eventAggregator.Publish(new OnDocumentWindowClosed() { Window = e.DockWindow });
            };
            
        }

        private void radDock_DockWindowAdded(object sender, DockWindowEventArgs e)
        {
            
        }

        private void radDock_DockWindowClosed(object sender, DockWindowEventArgs e)
        {
            
        }

        private void radDock_DockWindowClosing(object sender, DockWindowCancelEventArgs e)
        {
            
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            eventAggregator.Publish(new OnSyncClicked());
        }

        private void radRibbonBarGroup1_Click(object sender, EventArgs e)
        {

        }

        private void radRibbonBar1_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveLocal_Click(object sender, EventArgs e)
        {
            eventAggregator.Publish(new OnLocalClicked());
        }

        private void btnSaveSync_Click(object sender, EventArgs e)
        {

        }

        private void btnUndo_Click(object sender, EventArgs e)
        {

        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            eventAggregator.Publish(new OnSettingsClicked());
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            eventAggregator.Publish(new OnThemeClicked());
        }

        private void btnResetSettings_Click(object sender, EventArgs e)
        {
            eventAggregator.Publish(new OnResetConfiguration());
        }
    }
}
