using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
