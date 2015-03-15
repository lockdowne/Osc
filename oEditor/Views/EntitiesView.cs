using oEngine.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Views
{
    public partial class EntitiesView : ToolWindow, IEntitiesView
    {
        /// <summary>
        /// Gets or sets the selected node
        /// </summary>
        public RadTreeNode SelectedNode
        {
            get { return radTreeView.SelectedNode; }
            set { radTreeView.SelectedNode = value; }
        }

        public event Action AddEntityClicked;
        public event Action DeleteEntityClicked;
        public event Action EditEntityClicked;

        public EntitiesView()
        {
            InitializeComponent();

            this.Controls.Add(radTreeView);

            //this.toolWindow1.Caption = null;
            //this.toolWindow1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.toolWindow1.Location = new System.Drawing.Point(4, 24);
            //this.toolWindow1.Name = "toolWindow1";
            //this.toolWindow1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            //this.toolWindow1.Size = new System.Drawing.Size(192, 469);
            //this.toolWindow1.Text = "toolWindow1";

            this.Caption = null;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "entitiesWindow";
            this.Text = "Entities";
             
            

            // Dynamically create root folders in view
            AddRootNode(Enums.EditorEntities.Sprites);
            AddRootNode(Enums.EditorEntities.Items);
            AddRootNode(Enums.EditorEntities.Nodes);
            AddRootNode(Enums.EditorEntities.Quests);
            AddRootNode(Enums.EditorEntities.Scenes);  

            // Bind image to expand property
            radTreeView.NodeExpandedChanged += (s, e) =>
            {
                if (e.Node.RootNode != e.Node)
                    return;

                if (e.Node.Expanded)
                    e.Node.Image = global::oEditor.Properties.Resources.Folder_6221;
                else
                    e.Node.Image = global::oEditor.Properties.Resources.Folder_6222;
            };

            
            btnAddEntity.Click += (s, e) =>
            {
                if(AddEntityClicked != null)
                {
                    AddEntityClicked();
                }
            };

            btnDeleteEntity.Click += (s, e) =>
            {
                if(DeleteEntityClicked != null)
                {
                    DeleteEntityClicked();
                }
            };

            btnEditEntity.Click += (s, e) =>
            {
                if(EditEntityClicked != null)
                {
                    EditEntityClicked();
                }
            };
            
            // Collapse selected node
            btnCollapse.Click += (s, e) =>
            {
                if (radTreeView.SelectedNode != null)
                    radTreeView.SelectedNode.Collapse();
            };

            // Expand selected node
            btnExpand.Click += (s, e) =>
            {
                if (radTreeView.SelectedNode != null)
                    radTreeView.SelectedNode.Expand();
            };
        }

        private void AddRootNode(Enums.EditorEntities tag)
        {
            string name = Enum.GetName(typeof(Enums.EditorEntities), tag);

            radTreeView.Nodes.Add(new RadTreeNode(name)
            {
                Name = name,
                Tag = tag,
                //Value = ,
                //ContextMenu = radContextMenu,
                Image = global::oEditor.Properties.Resources.Folder_6222,
            });
        }
    }
}
