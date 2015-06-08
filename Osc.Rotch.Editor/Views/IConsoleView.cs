using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace Osc.Rotch.Editor.Views
{
    public interface IConsoleView
    {
        RadGridView Grid { get; set; }
        RadTextBox RadTextBox { get; set; }
    }
}
