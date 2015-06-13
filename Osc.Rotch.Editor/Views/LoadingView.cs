using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Osc.Rotch.Editor.Views
{
    public partial class LoadingView : Form
    {
        public LoadingView()
        {
            InitializeComponent();

            progressIndicator1.CircleSize = 1.0f;
            progressIndicator1.Start();
        }
    }
}
