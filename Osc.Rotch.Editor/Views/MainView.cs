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

namespace Osc.Rotch.Editor.Views
{
    public partial class MainView : RadForm, IMainView
    {
        public RadDock DockManager
        {
            get { return radDock; }
        }

        public MainView()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

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
    }
}
