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
using Telerik.WinControls.UI.Docking;

namespace Osc.Rotch.Editor.Views
{
    public partial class ProjectView : ToolWindow, IProjectView
    {
        private IEventAggregator eventAggregator;

        public ProjectView(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            InitializeComponent();
        }
    }
}
