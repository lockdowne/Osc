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
using Telerik.WinControls.UI.Docking;

namespace oEditor.Views
{
    public partial class MainView : Form, IMainView
    {
        public DockWindowCancelEventHandler DockWindowClosing;

        public MainView()
        {
            InitializeComponent();

            AddSceneView(new SceneView());

            radDock.DockWindowClosing += (sender, e) =>
            {
                if (DockWindowClosing != null)
                    DockWindowClosing(sender, e);

                e.Cancel = false;

                if (e.NewWindow is DocumentWindow)
                { 
                    DialogResult result = MessageBox.Show("Do you want to save your changes?", "Save changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

                    switch (result)
                    {
                        case System.Windows.Forms.DialogResult.Yes:

                            break;
                        case System.Windows.Forms.DialogResult.No:

                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                    }
                }
            };
        }

        public DialogResult ShowMessageBox(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(message, caption, buttons, icon, defaultButton);
        }

        public void ConsoleWriteLine(string message)
        {
            listboxConsole.Items.Insert(0, new Telerik.WinControls.UI.RadListDataItem(message));

            if(listboxConsole.Items.Count > Configuration.Settings.MaxNumberOfConsoleMessage)
            {
                listboxConsole.Items.RemoveAt(listboxConsole.Items.Count - 1);
            }
        }

        public void AddSceneView(SceneView sceneView)
        {
            radDock.AddDocument(sceneView, Telerik.WinControls.UI.Docking.DockPosition.Fill);            
        }
    }
}
