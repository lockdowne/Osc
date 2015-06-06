using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI.Docking;

namespace Osc.Rotch.Editor.Views
{
    public interface IMainView
    {
        RadDock DockManager { get; }
    }
}
