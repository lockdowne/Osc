using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Views
{
    public partial class MainView : RadForm, IMainView
    {
        public RadDock DockManager
        {
            get { return radDock; }
            set { radDock = value; }
        }

        public MainView()
        {
            InitializeComponent();
        }

        public DialogResult ShowMessageBox(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(message, caption, buttons, icon, defaultButton);
        }
    }
}
