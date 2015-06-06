using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace Osc.Rotch.Editor.Views
{
    public interface IEntitiesView
    {
        RadTreeView TreeView { get; }

        RadTreeNode SelectedNode { get; }

        RadContextMenu ContextMenuRoot { get; }
        RadContextMenu ContextMenuChild { get; }
    }
}
