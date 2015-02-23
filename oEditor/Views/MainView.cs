using oEditor.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oEditor.Views
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        public void ConsoleWriteLine(string message)
        {
            listboxConsole.Items.Insert(0, new Telerik.WinControls.UI.RadListDataItem(message));

            if(listboxConsole.Items.Count > Configuration.Settings.MaxNumberOfConsoleMessage)
            {
                listboxConsole.Items.RemoveAt(listboxConsole.Items.Count - 1);
            }
        }
    }
}
