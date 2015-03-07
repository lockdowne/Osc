using oEditor.Common;
using oEditor.Views;
using oEngine.Commands;
using oEngine.Common;
using oEngine.Entities;
using oEngine.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView mainView;

        public MainPresenter(IMainView mainView)
        {           
            // Main view initialization
            this.mainView = mainView;

            
            mainView.DockWindowClosing += (sender, e) =>
            {
                e.Cancel = false;

                if (e.NewWindow is SceneView)
                {
                    switch (mainView.ShowMessageBox("Do you want to save your changes?", "Save changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3))
                    {
                        case DialogResult.Yes:
                            // TODO: Save map
                            break;
                        case DialogResult.No:

                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                    }
                }
                else if(e.NewWindow is ToolWindow)
                {
                    if(e.NewWindow.Text == Enum.GetName(typeof(Enums.EditorWindows), Enums.EditorWindows.Console))
                    {
                        ConsoleWriteLine(CommandFactory.ExecuteCommand(new Command()
                        {
                            CanExecute = () => { return true; },
                            Execute = () =>
                            {
                                mainView.ConsoleWindow.Hide();
                                mainView.MenuViewConsole.IsChecked = false;

                            },
                            UnExecute = () =>
                            {
                                mainView.ConsoleWindow.Show();
                                mainView.MenuViewConsole.IsChecked = true;
                            },
                            Name = "Close Console Window",
                        }));
                    }
                    else if(e.NewWindow.Text == Enum.GetName(typeof(Enums.EditorWindows), Enums.EditorWindows.Entities))
                    {
                        ConsoleWriteLine(CommandFactory.ExecuteCommand(new Command()
                        {
                            CanExecute = () => { return true; },
                            Execute = () =>
                            {
                                mainView.EntitiesWindow.Hide();
                                mainView.MenuViewEntities.IsChecked = false;

                            },
                            UnExecute = () =>
                            {
                                mainView.EntitiesWindow.Show();
                                mainView.MenuViewEntities.IsChecked = true;
                            },
                            Name = "Close Entities Window",
                        }));
                    }
                    else if (e.NewWindow.Text == Enum.GetName(typeof(Enums.EditorWindows), Enums.EditorWindows.Project))
                    {
                        ConsoleWriteLine(CommandFactory.ExecuteCommand(new Command()
                        {
                            CanExecute = () => { return true; },
                            Execute = () =>
                            {
                                mainView.ProjectWindow.Hide();
                                mainView.MenuViewProject.IsChecked = false;

                            },
                            UnExecute = () =>
                            {
                                mainView.ProjectWindow.Show();
                                mainView.MenuViewProject.IsChecked = true;
                            },
                            Name = "Close Entities Window",
                        }));
                    }
                    else if (e.NewWindow.Text == Enum.GetName(typeof(Enums.EditorWindows), Enums.EditorWindows.Toolbox))
                    {
                        ConsoleWriteLine(CommandFactory.ExecuteCommand(new Command()
                        {
                            CanExecute = () => { return true; },
                            Execute = () =>
                            {
                                mainView.ToolboxWindow.Hide();
                                mainView.MenuViewToolbox.IsChecked = false;

                            },
                            UnExecute = () =>
                            {
                                mainView.ToolboxWindow.Show();
                                mainView.MenuViewToolbox.IsChecked = true;
                            },
                            Name = "Close Toolbox Window",
                        }));
                    }
                }
            };
           

            // <summary>
            // Menu clicked: View->Console
            // </summary>
            mainView.MenuViewConsoleClicked += () =>
            {
                if(mainView.MenuViewConsole.IsChecked)
                {
                    ConsoleWriteLine(CommandFactory.ExecuteCommand(new Command()
                    {
                        CanExecute = () => { return true; },
                        Execute = () =>
                        {
                            mainView.ConsoleWindow.Show();
                            mainView.MenuViewConsole.IsChecked = true;
                        },
                        UnExecute = () =>
                        {
                            mainView.ConsoleWindow.Hide();
                            mainView.MenuViewConsole.IsChecked = false;
                        },
                        Name = "Show Console Window",                       
                    }));
                }
                else
                {
                    ConsoleWriteLine(CommandFactory.ExecuteCommand(new Command()
                    {
                        CanExecute = () => { return true; },
                        Execute = () =>
                        {
                            mainView.ConsoleWindow.Hide();
                            mainView.MenuViewConsole.IsChecked = false;
                           
                        },
                        UnExecute = () =>
                        {
                            mainView.ConsoleWindow.Show();
                            mainView.MenuViewConsole.IsChecked = true;
                        },
                        //Name = "Close Console Window",
                    }));
                }
            };

            // <summary>
            // Menu clicked: View->Entities
            // </summary>
            mainView.MenuViewEntitiesClicked += () =>
            {
                if (mainView.MenuViewEntities.IsChecked)
                {
                    ConsoleWriteLine(CommandFactory.ExecuteCommand(new Command()
                    {
                        CanExecute = () => { return true; },
                        Execute = () =>
                        {
                            mainView.EntitiesWindow.Show();
                            mainView.MenuViewEntities.IsChecked = true;
                        },
                        UnExecute = () =>
                        {
                            mainView.EntitiesWindow.Hide();
                            mainView.MenuViewEntities.IsChecked = false;
                        },
                        Name = "Show Entities Window",
                    }));
                }
                else
                {
                    ConsoleWriteLine(CommandFactory.ExecuteCommand(new Command()
                    {
                        CanExecute = () => { return true; },
                        Execute = () =>
                        {
                            mainView.EntitiesWindow.Hide();
                            mainView.MenuViewEntities.IsChecked = false;

                        },
                        UnExecute = () =>
                        {
                            mainView.EntitiesWindow.Show();
                            mainView.MenuViewEntities.IsChecked = true;
                        },
                        //Name = "Close Entities Window",
                    }));
                }
            };

            // <summary>
            // Menu clicked: View->Project
            // </summary>
            mainView.MenuViewProjectClicked += () =>
            {
                if (mainView.MenuViewProject.IsChecked)
                {
                    ConsoleWriteLine(CommandFactory.ExecuteCommand(new Command()
                    {
                        CanExecute = () => { return true; },
                        Execute = () =>
                        {
                            mainView.ProjectWindow.Show();
                            mainView.MenuViewProject.IsChecked = true;
                        },
                        UnExecute = () =>
                        {
                            mainView.ProjectWindow.Hide();
                            mainView.MenuViewProject.IsChecked = false;
                        },
                        Name = "Show Project Window",
                    }));
                }
                else
                {
                    ConsoleWriteLine(CommandFactory.ExecuteCommand(new Command()
                    {
                        CanExecute = () => { return true; },
                        Execute = () =>
                        {
                            mainView.ProjectWindow.Hide();
                            mainView.MenuViewProject.IsChecked = false;

                        },
                        UnExecute = () =>
                        {
                            mainView.ProjectWindow.Show();
                            mainView.MenuViewProject.IsChecked = true;
                        },
                        //Name = "Close Project Window",
                    }));
                }
            };

            // <summary>
            // Menu clicked: View->Toolbox
            // </summary>
            mainView.MenuViewToolboxClicked += () =>
            {
                if (mainView.MenuViewToolbox.IsChecked)
                {
                    ConsoleWriteLine(CommandFactory.ExecuteCommand(new Command()
                    {  
                        CanExecute = () => { return true; },
                        Execute = () =>
                        {
                            mainView.ToolboxWindow.Show();
                            mainView.MenuViewToolbox.IsChecked = true;
                        },
                        UnExecute = () =>
                        {
                            mainView.ToolboxWindow.Hide();
                            mainView.MenuViewToolbox.IsChecked = false;
                        },
                        Name = "Show Toolbox Window",
                    }));
                }
                else
                {
                    ConsoleWriteLine(CommandFactory.ExecuteCommand(new Command()
                    {
                        CanExecute = () => { return true; },
                        Execute = () =>
                        {
                            mainView.ToolboxWindow.Hide();
                            mainView.MenuViewToolbox.IsChecked = false;

                        },
                        UnExecute = () =>
                        {
                            mainView.ToolboxWindow.Show();
                            mainView.MenuViewToolbox.IsChecked = true;
                        },
                        //Name = "Close Toolbox Window",
                    }));
                }
            };

            mainView.EntitiesNodeExpanded += (sender, e) =>
            {
                // Doesn't need to be a command
                if(e.Node.Expanded && e.Node.RootNode == e.Node)
                {
                    e.Node.Image = global::oEditor.Properties.Resources.Folder_6221;
                }
                else if(e.Node.RootNode == e.Node)
                {
                    e.Node.Image = global::oEditor.Properties.Resources.Folder_6222;
                }
            };

            mainView.ContextAddCollapseClicked += () =>
            {                
                if(mainView.SelectedEntityNode != null)
                {
                    mainView.SelectedEntityNode.Collapse();
                }
            };

            mainView.ContextAddExpandClicked += () =>
            {
                if(mainView.SelectedEntityNode != null)
                {
                    mainView.SelectedEntityNode.Expand();
                }
            };

            mainView.ContextAddEntityClicked += () =>
            {
                // Add entity object to tree
                if(mainView.SelectedEntityNode != null)
                {
                    // Get the type
                    switch((Enums.EditorEntities)mainView.SelectedEntityNode.Tag)
                    {
                        case Enums.EditorEntities.Sprites:

                            break;
                        case Enums.EditorEntities.Items:

                            break;
                        case Enums.EditorEntities.Nodes:

                            break;
                        case Enums.EditorEntities.Quests:

                            break;
                        case Enums.EditorEntities.Scenes:

                            break;                         
                    }
                }
            };
        }

        private void ConsoleWriteLine(string message)
        {
            mainView.ConsoleListBox.Items.Insert(0, new Telerik.WinControls.UI.RadListDataItem(message));

            if (mainView.ConsoleListBox.Items.Count > Configuration.Settings.MaxNumberOfConsoleMessage)
            {
                mainView.ConsoleListBox.Items.RemoveAt(mainView.ConsoleListBox.Items.Count - 1);
            }
        }

        private void AddEntityNode(string text, Enums.EditorEntities tag, IEntity value)        
        {

        }

        private void RemoveEntityNode(Guid id)
        {
            //mainView.EntitiesTreeView.Nodes.
        }
    }
}
