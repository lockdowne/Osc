using oEditor.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Views
{
    public class ConsoleView : ToolWindow
    {
        private RadListControl radListControl;

        public ConsoleView()
        {
            radListControl = new RadListControl();
            radListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            radListControl.Name = "listControl";
            
            Caption = null;
            Controls.Add(radListControl);
            Name = "windowConsole";
            PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            Size = new System.Drawing.Size(570, 172);
            Text = "Console";
        }

        public void WriteLine(string message)
        {
            radListControl.Items.Insert(0, new Telerik.WinControls.UI.RadListDataItem(message));

            if (radListControl.Items.Count > Configuration.Settings.MaxNumberOfConsoleMessage)
            {
                radListControl.Items.RemoveAt(radListControl.Items.Count - 1);
            }
        }
    }
}
