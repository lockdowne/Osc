using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI.Docking;

namespace Osc.Rotch.Editor.Events
{
    public class OnSyncClicked
    {

    }

    public class OnLocalClicked
    {

    }

    public class OnConsoleWindowVisibilityChanged
    {
        public bool IsVisible { get; set; }
    }

    public class OnProjectWindowVisibilityChanged
    {
        public bool IsVisible { get; set; }
    }

    public class OnEntitiesWindowVisibilityChanged
    {
        public bool IsVisible { get; set; }
    }

    public class OnDocumentWindowClosed
    {
        public DockWindow Window { get; set; }
    }

    public class OnSettingsClicked
    {

    }

    public class OnThemeClicked
    {

    }

    public class OnResetConfiguration
    {

    }
}
