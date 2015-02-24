using oEditor.Common;
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
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Views
{
    public partial class MainView : Form, IMainView
    {
        #region Properties

        public ToolWindow ConsoleWindow
        {
            get { return windowConsole; }
        }

        public ToolWindow ToolboxWindow
        {
            get { return windowToolbox; }
        }

        public ToolWindow ProjectWindow
        {
            get { return windowProject; }
        }

        public ToolWindow EntitiesWindow
        {
            get { return windowEntities; }
        }

        public RadMenuItem MenuViewConsole
        {
            get { return menuViewConsole; }
        }

        public RadMenuItem MenuViewEntities
        {
            get { return menuViewEntities; }
        }

        public RadMenuItem MenuViewProject
        {
            get { return menuViewProject; }
        }

        public RadMenuItem MenuViewToolbox
        {
            get { return menuViewToolbox; }
        }

        public RadTreeView EntitiesTreeView
        {
            get { return treeViewEntities; }
        }

        public RadMenuItem ContextAddEntity
        {
            get { return contextAddEntity; }
        }

        public RadMenuItem ContextAddExpand
        {
            get { return contextAddExpand; }
        }

        public RadMenuItem ContextAddCollapse
        {
            get { return contextAddCollapse; }
        }

        public RadMenuItem ContextEditEntity
        {
            get { return contextEditEntity; }
        }

        public RadMenuItem ContextEditDelete
        {
            get { return contextEditDelete; }
        }

        public RadMenuItem ContextEditExpand
        {
            get { return contextEditExpand; }
        }

        public RadMenuItem ContextEditCollapse
        {
            get { return contextEditCollapse; }
        }

        public RadDock RadDock
        {
            get { return radDock; }
        }

        public RadListControl ConsoleListBox
        {
            get { return listboxConsole; }
        }


        public event DockWindowCancelEventHandler DockWindowClosing;
        public event Telerik.WinControls.UI.RadTreeView.TreeViewMouseEventHandler EntitiesTreeviewNodeClicked;

        public event Action MenuViewConsoleClicked;
        public event Action MenuViewProjectClicked;
        public event Action MenuViewEntitiesClicked;
        public event Action MenuViewToolboxClicked;
        public event Action ContextAddEntityClicked;
        public event Action ContextAddExpandClicked;
        public event Action ContextAddCollapseClicked;
        public event Action ContextEditEntityClicked;
        public event Action ContextEditDeleteClicked;
        public event Action ContextEditExpandClicked;
        public event Action ContextEditCollapseClicked;

        #endregion

        public MainView()
        {
            InitializeComponent();
            
            // Populate Entities View
            AddParentNodeToEntitiesTree(Enum.GetName(typeof(Enums.EditorEntities), Enums.EditorEntities.Characters), Enums.EditorEntities.Characters);
            AddParentNodeToEntitiesTree(Enum.GetName(typeof(Enums.EditorEntities), Enums.EditorEntities.Items), Enums.EditorEntities.Items);
            AddParentNodeToEntitiesTree(Enum.GetName(typeof(Enums.EditorEntities), Enums.EditorEntities.Nodes), Enums.EditorEntities.Nodes);
            AddParentNodeToEntitiesTree(Enum.GetName(typeof(Enums.EditorEntities), Enums.EditorEntities.Quests), Enums.EditorEntities.Quests);
            AddParentNodeToEntitiesTree(Enum.GetName(typeof(Enums.EditorEntities), Enums.EditorEntities.Scenes), Enums.EditorEntities.Scenes);                        
        }

        public DialogResult ShowMessageBox(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(message, caption, buttons, icon, defaultButton);
        }     

        private void AddParentNodeToEntitiesTree(string text, Enums.EditorEntities tag)
        {
           
            treeViewEntities.Nodes.Add(new RadTreeNode(text)
            {
                Name = text,
                Tag = tag,
                //Value = ,
                ContextMenu = contextAdd,
            });
        }

        // Beware, events beyond this point

        private void MainView_Load(object sender, EventArgs e)
        {

        }

        private void menuViewConsole_Click(object sender, EventArgs e)
        {            
            if(MenuViewConsoleClicked != null)
            {
                MenuViewConsoleClicked();
            }
        }

        private void menuViewEntities_Click(object sender, EventArgs e)
        {
            if(MenuViewEntitiesClicked != null)
            {
                MenuViewEntitiesClicked();
            }
        }

        private void menuViewProject_Click(object sender, EventArgs e)
        {
            if(MenuViewProjectClicked != null)
            {
                MenuViewProjectClicked();
            }
        }

        private void menuViewToolbox_Click(object sender, EventArgs e)
        {
            if(MenuViewToolboxClicked != null)
            {
                MenuViewToolboxClicked();
            }
        }
        
        private void treeViewEntities_NodeMouseDown(object sender, RadTreeViewMouseEventArgs e)
        {
            if (EntitiesTreeviewNodeClicked != null)
            {
                EntitiesTreeviewNodeClicked(sender, e);
            }
        }

        private void radDock_DockWindowClosing(object sender, DockWindowCancelEventArgs e)
        {
            if (DockWindowClosing != null)
            {
                DockWindowClosing(sender, e);
            }
        }

        private void contextAddEntity_Click(object sender, EventArgs e)
        {
            if(ContextAddEntityClicked != null)
            {
                ContextAddEntityClicked();
            }
        }

        private void contextAddCollapse_Click(object sender, EventArgs e)
        {
            if(ContextAddCollapseClicked != null)
            {
                ContextAddCollapseClicked();
            }
        }

        private void contextAddExpand_Click(object sender, EventArgs e)
        {
            if(ContextAddExpandClicked != null)
            {
                ContextAddExpandClicked();
            }
        }

        private void contextEditCollapse_Click(object sender, EventArgs e)
        {
            if(ContextEditCollapseClicked != null)
            {
                ContextEditCollapseClicked();
            }
        }

        private void contextEditDelete_Click(object sender, EventArgs e)
        {
            if(ContextEditDeleteClicked != null)
            {
                ContextEditDeleteClicked();
            }
        }

        private void contextEditEntity_Click(object sender, EventArgs e)
        {
            if(ContextEditEntityClicked != null)
            {
                ContextEditEntityClicked();
            }
        }

        private void contextEditExpand_Click(object sender, EventArgs e)
        {
            if(ContextEditExpandClicked != null)
            {
                ContextEditExpandClicked();
            }
        }
    }
}
