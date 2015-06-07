using Osc.Rotch.Editor.Controls;
using Osc.Rotch.Engine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using Osc.Rotch.Editor.Events;
using Osc.Rotch.Engine.Aggregators;

namespace Osc.Rotch.Editor.Views
{
    public class EntitiesView : ToolWindow, IEntitiesView
    {
        private IEventAggregator eventAggregator;

        private Telerik.WinControls.UI.RadContextMenu contextMenuRoot;
        private System.ComponentModel.IContainer components;
        private Telerik.WinControls.UI.RadMenuItem contextMenuRootAddEntity;
        private Telerik.WinControls.UI.RadContextMenu contextMenuChild;
        private Telerik.WinControls.UI.RadMenuItem contextMenuChildEdit;
        private Telerik.WinControls.UI.RadMenuItem contextMenuChildDelete;
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

        public RadContextMenu ContextMenuChild
        {
            get { return contextMenuChild; }
        }

        public EntitiesView(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            this.InitializeComponent();

            // Create fixed root nodes
            radTreeView.Nodes.Add(new EntitiesRootNode()
            {
                EntityType = Enums.EntityTypes.Tilemaps,
                Text = Enums.EntityTypes.Tilemaps.ToString(),
                ContextMenu = contextMenuRoot,
            });

            radTreeView.NodeMouseDoubleClick += (sender, e) =>
            {
                EntitiesChildNode selectedNode = SelectedNode as EntitiesChildNode;

                if (selectedNode == null)
                    return;
                              

                switch (selectedNode.EntityType)
                {
                    case Enums.EntityTypes.Characters:
                        break;
                    case Enums.EntityTypes.Items:
                        break;
                    case Enums.EntityTypes.Quests:
                        break;
                    case Enums.EntityTypes.Tilemaps:
                        this.eventAggregator.Publish(new OnTilemapNodeDoubleClicked() { Node = selectedNode });
                        break;
                    case Enums.EntityTypes.Nodes:
                        break;
                    case Enums.EntityTypes.BattleScenes:
                        break;
                    case Enums.EntityTypes.FreeRoamScenes:
                        break;
                    case Enums.EntityTypes.RandomBattleScenes:
                        break;
                }

                
            };

            this.contextMenuChildDelete.Click += (sender, e) =>
            {
                EntitiesChildNode child = SelectedNode as EntitiesChildNode;

                if (child == null)
                    return;

                switch (child.EntityType)
                {
                    case Enums.EntityTypes.Characters:
                        break;
                    case Enums.EntityTypes.Items:
                        break;
                    case Enums.EntityTypes.Quests:
                        break;
                    case Enums.EntityTypes.Tilemaps:
                        this.eventAggregator.Publish(new OnDeleteTilemapNodeClicked() { Node = child });
                        break;
                    case Enums.EntityTypes.Nodes:
                        break;
                    case Enums.EntityTypes.BattleScenes:
                        break;
                    case Enums.EntityTypes.FreeRoamScenes:
                        break;
                    case Enums.EntityTypes.RandomBattleScenes:
                        break;
                }
            };

            this.contextMenuChildEdit.Click += (sender, e) =>
            {
                EntitiesChildNode child = SelectedNode as EntitiesChildNode;

                if (child == null)
                    return;

                switch (child.EntityType)
                {
                    case Enums.EntityTypes.Characters:
                        break;
                    case Enums.EntityTypes.Items:
                        break;
                    case Enums.EntityTypes.Quests:
                        break;
                    case Enums.EntityTypes.Tilemaps:
                        this.eventAggregator.Publish(new OnEditTilemapNodeClicked() { Node = child });
                        break;
                    case Enums.EntityTypes.Nodes:
                        break;
                    case Enums.EntityTypes.BattleScenes:
                        break;
                    case Enums.EntityTypes.FreeRoamScenes:
                        break;
                    case Enums.EntityTypes.RandomBattleScenes:
                        break;
                }
            };

            this.contextMenuRootAddEntity.Click += (sender, e) =>
            {
                EntitiesRootNode root = SelectedNode as EntitiesRootNode;

                if (root == null)
                    return;

                switch (root.EntityType)
                {
                    case Enums.EntityTypes.Characters:
                        break;
                    case Enums.EntityTypes.Items:
                        break;
                    case Enums.EntityTypes.Quests:
                        break;
                    case Enums.EntityTypes.Tilemaps:
                        this.eventAggregator.Publish(new OnCreateTilemapNode() { Root = root, Node = new EntitiesChildNode() { Text = Consts.Nodes.Tilemap, ID = Guid.NewGuid(), ContextMenu = contextMenuChild, EntityType = Enums.EntityTypes.Tilemaps } });
                        break;
                    case Enums.EntityTypes.Nodes:
                        break;
                    case Enums.EntityTypes.BattleScenes:
                        break;
                    case Enums.EntityTypes.FreeRoamScenes:
                        break;
                    case Enums.EntityTypes.RandomBattleScenes:
                        break;
                }
            };

            this.CloseAction = DockWindowCloseAction.Hide;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntitiesView));
            this.radTreeView = new Telerik.WinControls.UI.RadTreeView();
            this.contextMenuRoot = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.contextMenuRootAddEntity = new Telerik.WinControls.UI.RadMenuItem();
            this.contextMenuChild = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.contextMenuChildEdit = new Telerik.WinControls.UI.RadMenuItem();
            this.contextMenuChildDelete = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView)).BeginInit();
            this.SuspendLayout();
            // 
            // radTreeView
            // 
            this.radTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTreeView.Location = new System.Drawing.Point(0, 0);
            this.radTreeView.Name = "radTreeView";
            this.radTreeView.Size = new System.Drawing.Size(200, 200);
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
            this.contextMenuRootAddEntity.Image = ((System.Drawing.Image)(resources.GetObject("contextMenuRootAddEntity.Image")));
            this.contextMenuRootAddEntity.Name = "contextMenuRootAddEntity";
            this.contextMenuRootAddEntity.Text = "Add";
            // 
            // contextMenuChild
            // 
            this.contextMenuChild.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.contextMenuChildEdit,
            this.contextMenuChildDelete});
            // 
            // contextMenuChildEdit
            // 
            this.contextMenuChildEdit.AccessibleDescription = "contextMenuEditTilemap";
            this.contextMenuChildEdit.AccessibleName = "contextMenuEditTilemap";
            this.contextMenuChildEdit.Image = ((System.Drawing.Image)(resources.GetObject("contextMenuChildEdit.Image")));
            this.contextMenuChildEdit.Name = "contextMenuChildEdit";
            this.contextMenuChildEdit.Text = "Edit";
            this.contextMenuChildEdit.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuChildDelete
            // 
            this.contextMenuChildDelete.AccessibleDescription = "Delete";
            this.contextMenuChildDelete.AccessibleName = "Delete";
            this.contextMenuChildDelete.Image = ((System.Drawing.Image)(resources.GetObject("contextMenuChildDelete.Image")));
            this.contextMenuChildDelete.Name = "contextMenuChildDelete";
            this.contextMenuChildDelete.Text = "Delete";
            // 
            // EntitiesView
            // 
            this.Controls.Add(this.radTreeView);
            this.Text = "Entities";
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
