using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Views
{
    public interface IMainView
    {
        RadDock DockManager { get; }

        ToolWindow Toolbox { get; set; }

        event DockWindowCancelEventHandler WindowClosing;
    }
}
