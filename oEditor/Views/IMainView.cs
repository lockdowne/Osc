using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Views
{
    public interface IMainView
    {
        event DockWindowCancelEventHandler DockWindowClosing;

        DialogResult ShowMessageBox(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton);

        void ConsoleWriteLine(string message);
        void AddSceneView(DockWindow dockWindow);
    }
}
