using oEngine.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Views
{
    public partial class MainView : RadForm, IMainView
    {
        public RadDock DockManager
        {
            get { return radDock; }
        }

        public ToolWindow Toolbox
        {
            get { return windowToolbox; }
            set
            {
                if (value == null)
                    windowToolbox = new ToolWindow() { Name = "windowToolbox", Text = "Toolbox" };
                else
                    windowToolbox = value;
               
            }
        }

        public event DockWindowCancelEventHandler WindowClosing;

        public MainView()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            RadMessageBox.SetThemeName("VisualStudio2012Dark");

            // Testing

            //TilemapToolbox t = new TilemapToolbox();
           // radDock.DockWindow(t, )
            this.MouseWheel += (sender, e) =>
            {
                oEngine.Factories.CommandFactory.Undo();
            };

            // End Testing
            radDock.DockWindowClosing += (sender, e) =>
            {
                if (WindowClosing != null)
                    WindowClosing(sender, e);

                // While this should be in presenter I have it in view due to a shitty binding, the menu item checked property should be tied to visibilty to tool windows
                try
                {
                    if (e.NewWindow.Text == Enums.EditorWindows.Console.ToString())
                    {
                        btnConsoleWindow.IsChecked = false;
                    }
                    else if (e.NewWindow.Text == Enums.EditorWindows.Entities.ToString())
                    {
                        btnEntitiesWindow.IsChecked = false;
                    }
                    else if (e.NewWindow.Text == Enums.EditorWindows.Project.ToString())
                    {
                        btnProjectWindow.IsChecked = false;
                    }
                    else if (e.NewWindow.Text == Enums.EditorWindows.Toolbox.ToString())
                    {
                        btnToolboxWindow.IsChecked = false;
                    }
                }
                catch(Exception exception)
                {
                    Logger.Log("MainView", "DockWindowClosing", exception);
                    ConsoleView.WriteLine("Error - " + exception.ToString());
                }
                
                    
            };

            btnConsoleWindow.Click += (sender, e) =>
            {               
                DockWindow window = radDock.DockWindows.FirstOrDefault(w => w.Text == Enums.EditorWindows.Console.ToString());

                if (window == null)
                    return;

                if (btnConsoleWindow.IsChecked)
                    window.Show();
                else
                    window.Hide();
            };

            btnEntitiesWindow.Click += (sender, e) =>
            {
                DockWindow window = radDock.DockWindows.FirstOrDefault(w => w.Text == Enums.EditorWindows.Entities.ToString());

                if (window == null)
                    return;

                if (btnEntitiesWindow.IsChecked)
                    window.Show();
                else
                    window.Hide();
            };

            btnProjectWindow.Click += (sender, e) =>
            {
                DockWindow window = radDock.DockWindows.FirstOrDefault(w => w.Text == Enums.EditorWindows.Project.ToString());

                if (window == null)
                    return;

                if (btnProjectWindow.IsChecked)
                    window.Show();
                else
                    window.Hide();
            };

            btnToolboxWindow.Click += (sender, e) =>
            {
                DockWindow window = radDock.DockWindows.FirstOrDefault(w => w.Text == Enums.EditorWindows.Toolbox.ToString());

                if (window == null)
                    return;

                if (btnToolboxWindow.IsChecked)
                    window.Show();
                else
                    window.Hide();
            };
        }

        public static DialogResult ShowMessageBox(string message, string caption, MessageBoxButtons buttons, RadMessageIcon icon, MessageBoxDefaultButton defaultButton)
        {  
            return RadMessageBox.Show(MainView.ActiveForm, message, caption, buttons, icon, defaultButton);
        }
    }
}
