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
        ToolWindow ConsoleWindow { get; }
        ToolWindow ToolboxWindow { get; }
        ToolWindow ProjectWindow { get; }
        ToolWindow EntitiesWindow { get; }

        RadMenuItem MenuViewConsole { get; }
        RadMenuItem MenuViewEntities { get; }
        RadMenuItem MenuViewProject { get; }
        RadMenuItem MenuViewToolbox { get; }
        RadMenuItem ContextAddEntity{ get; }
        RadMenuItem ContextAddExpand { get; }
        RadMenuItem ContextAddCollapse { get; }
        RadMenuItem ContextEditEntity { get; }
        RadMenuItem ContextEditDelete { get; }
        RadMenuItem ContextEditExpand { get; }
        RadMenuItem ContextEditCollapse { get; }

        RadTreeView EntitiesTreeView { get; }

        RadDock RadDock { get; }

        RadListControl ConsoleListBox { get; }

        event Telerik.WinControls.UI.RadTreeView.TreeViewMouseEventHandler EntitiesTreeviewNodeClicked;
        event DockWindowCancelEventHandler DockWindowClosing;
        event Action MenuViewConsoleClicked;
        event Action MenuViewProjectClicked;
        event Action MenuViewEntitiesClicked;
        event Action MenuViewToolboxClicked;
        event Action ContextAddEntityClicked;
        event Action ContextAddExpandClicked;
        event Action ContextAddCollapseClicked;
        event Action ContextEditEntityClicked;
        event Action ContextEditDeleteClicked;
        event Action ContextEditExpandClicked;
        event Action ContextEditCollapseClicked;
       

        DialogResult ShowMessageBox(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton);
    }
}
