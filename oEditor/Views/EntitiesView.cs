using oEditor.Aggregators;
using oEditor.Controls;
using oEngine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Views
{
    public class EntitiesView : ToolWindow, IEntitiesView
    {
        private readonly IEventAggregator eventAggregator;

        private Telerik.WinControls.UI.RadContextMenu contextMenuRoot;
        private System.ComponentModel.IContainer components;
        private Telerik.WinControls.UI.RadMenuItem contextMenuRootAddEntity;
        private Telerik.WinControls.UI.RadContextMenu contextMenuTilemap;
        private Telerik.WinControls.UI.RadMenuItem contextMenuEditTilemap;
        private Telerik.WinControls.UI.RadMenuItem contextMenuDeleteTilemap;
        private Telerik.WinControls.UI.RadTreeView radTreeView;

        public RadTreeView TreeView
        {
            get { return radTreeView; }
        }

        public RadTreeNode SelectedNode
        {
            get { return radTreeView.SelectedNode; }
        }

        public RadContextMenu ContextMenuRoot
        {
            get { return contextMenuRoot; }
        }

        public RadContextMenu ContextMenuTilemap
        {
            get { return contextMenuTilemap; }
        }
    
        public EntitiesView(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            InitializeComponent();
            
            // Create fixed root nodes
            radTreeView.Nodes.Add(new EntitiesRootNode()
            {
                EntityType = Enums.EditorEntities.Tilemaps,
                Text = Enums.EditorEntities.Tilemaps.ToString(),
                ContextMenu = contextMenuRoot,                
            });

            this.contextMenuRootAddEntity.Click += (sender, e) =>
            { 
                // This shouldn't be possibru
                if (SelectedNode == null)
                    return;

                EntitiesRootNode root = (EntitiesRootNode)SelectedNode;

                switch (root.EntityType)
                {
                    case Enums.EditorEntities.Characters:
                        break;
                    case Enums.EditorEntities.Items:
                        break;
                    case Enums.EditorEntities.Quests:
                        break;
                    case Enums.EditorEntities.Tilemaps:
                        eventAggregator.Publish(new OnCreateEmptyTilemap() { Root = root, ID = Guid.NewGuid(), Context = contextMenuTilemap });
                        break;
                    case Enums.EditorEntities.Nodes:
                        break;
                    case Enums.EditorEntities.BattleScenes:
                        break;
                    case Enums.EditorEntities.FreeRoamScenes:
                        break;
                    case Enums.EditorEntities.RandomBattleScenes:
                        break;
                }
            };

            this.CloseAction = DockWindowCloseAction.Hide;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.radTreeView = new Telerik.WinControls.UI.RadTreeView();
            this.contextMenuRoot = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.contextMenuRootAddEntity = new Telerik.WinControls.UI.RadMenuItem();
            this.contextMenuTilemap = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.contextMenuEditTilemap = new Telerik.WinControls.UI.RadMenuItem();
            this.contextMenuDeleteTilemap = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView)).BeginInit();
            this.SuspendLayout();
            // 
            // radTreeView
            // 
            this.radTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTreeView.Location = new System.Drawing.Point(0, 0);
            this.radTreeView.Name = "radTreeView";
            this.radTreeView.Size = new System.Drawing.Size(150, 250);
            this.radTreeView.SpacingBetweenNodes = -1;
            this.radTreeView.TabIndex = 0;
            this.radTreeView.Text = "radTreeView1";
            // 
            // contextMenuRoot
            // 
            this.contextMenuRoot.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.contextMenuRootAddEntity});
            // 
            // contextMenuRootAddEntity
            // 
            this.contextMenuRootAddEntity.AccessibleDescription = "Add";
            this.contextMenuRootAddEntity.AccessibleName = "Add";
            this.contextMenuRootAddEntity.Name = "contextMenuRootAddEntity";
            this.contextMenuRootAddEntity.Text = "Add";
            // 
            // contextMenuTilemap
            // 
            this.contextMenuTilemap.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.contextMenuEditTilemap,
            this.contextMenuDeleteTilemap});
            // 
            // contextMenuEditTilemap
            // 
            this.contextMenuEditTilemap.AccessibleDescription = "contextMenuEditTilemap";
            this.contextMenuEditTilemap.AccessibleName = "contextMenuEditTilemap";
            this.contextMenuEditTilemap.Name = "contextMenuEditTilemap";
            this.contextMenuEditTilemap.Text = "Edit";
            this.contextMenuEditTilemap.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuDeleteTilemap
            // 
            this.contextMenuDeleteTilemap.AccessibleDescription = "Delete";
            this.contextMenuDeleteTilemap.AccessibleName = "Delete";
            this.contextMenuDeleteTilemap.Name = "contextMenuDeleteTilemap";
            this.contextMenuDeleteTilemap.Text = "Delete";
            // 
            // EntitiesView
            // 
            this.Controls.Add(radTreeView);
            this.Text = "Entities";
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
