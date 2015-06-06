using Osc.Rotch.Editor.Views;
using Osc.Engine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osc.Engine.Common;
using Osc.Engine.Controls;
using Osc.Rotch.Editor.Events;
using Osc.Engine.Entities;
using Osc.Rotch.Editor.Repositories;
using Osc.Rotch.Editor.Controls;
using Osc.Rotch.Editor.Common;
using Osc.Engine.Aggregators;
using Telerik.WinControls;
using System.Windows.Forms;

namespace Osc.Rotch.Editor.Controllers
{
    public class EntitiesController : IEntitiesController, ISubscriber<OnCreateTilemapNode>, ISubscriber<OnEditTilemapNodeClicked>, ISubscriber<OnDeleteTilemapNodeClicked>
    {
        private readonly IEntitiesView view;

        private readonly ICommandManager commandManager;

        private readonly IRepository<Tilemap> tilemapRepository;

        private readonly IEventAggregator eventAggregator;

        public EntitiesController(IEntitiesView entitiesView, ICommandManager commandManager, IRepository<Tilemap> tilemapRepository, IEventAggregator eventAggregator)
        {
            this.view = entitiesView;
            this.commandManager = commandManager;
            this.tilemapRepository = tilemapRepository;
            this.eventAggregator = eventAggregator;

            this.eventAggregator.Subscribe(this);

            // Command load nodes
            commandManager.ExecuteCommand(new Command()
            {
                CanExecute = () =>
                {
                    return true;
                },
                Execute = () =>
                {
                    LoadAllNodes(); 
                },
                UnExecute = () =>
                {

                },
                Name = "Loaded Nodes",
                ID = Guid.NewGuid(),
                Description = "Populate all created nodes",
            }, false);
        }


        public void OnEvent(OnDeleteTilemapNodeClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Deleted Tilemap",
                CanExecute = () => { return item != null && item.Node != null && tilemapRepository.Find(t => t.ID == item.Node.ID) != null; },
                Execute = () =>
                {
                    if (RadMessageBox.Show(Consts.AlertMessages.Messages.RemoveTilemap, Consts.AlertMessages.Captions.RemoveTilemap, System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Tilemap tilemap = tilemapRepository.Find(t => t.ID == item.Node.ID);

                        tilemapRepository.Remove(tilemap);

                        //tilemapRepository.Save();

                        item.Node.Remove();
                    }
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnEditTilemapNodeClicked item)
        {
            if (item == null)
                return;

            Tilemap tilemap = tilemapRepository.Find(t => t.ID == item.Node.ID);

            int previousWidth = tilemap.Width;
            int previousHeight = tilemap.Height;

            if (tilemap == null)
                return;

            TilemapPropertiesView propertiesView = new TilemapPropertiesView(tilemap.Name, tilemap.Description, tilemap.Width, tilemap.Height);

            DialogResult result = propertiesView.ShowDialog();

            commandManager.ExecuteCommand(new Command()
            {
                Name = "Edited Tilemap",
                CanExecute = () => { return item != null && item.Node != null && tilemap != null && result == DialogResult.OK && !string.IsNullOrEmpty(propertiesView.TilemapName); },
                Execute = () =>
                {
                    tilemap.Name = propertiesView.TilemapName;
                    tilemap.Description = propertiesView.TilemapDescription;

                    if(previousWidth != propertiesView.TilemapWidth || previousHeight != propertiesView.TilemapHeight)
                    {
                        tilemap.FindTilemapLayers(t => { return true; }).ForEach(layer =>
                        {
                            layer.Resize(propertiesView.TilemapWidth, propertiesView.TilemapHeight);
                        });

                        tilemap.CollisionLayer.Resize(propertiesView.TilemapWidth, propertiesView.TilemapHeight);

                        tilemap.Width = propertiesView.TilemapWidth;
                        tilemap.Height = propertiesView.TilemapHeight;
                    }

                    item.Node.Text = propertiesView.TilemapName;
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnCreateTilemapNode item)
        {
            commandManager.ExecuteCommandAsync(new Command()
            {
                CanExecute = () =>
                {
                    if (item == null)
                        return false;

                    return item.Root != null && item.Node != null;
                },
                Execute = () =>
                {
                    // Create empty tilemap
                    Tilemap tilemap = new Tilemap()
                    {
                        ID = item.Node.ID,
                        IsGridVisible = true,
                    };
                    tilemap.Initialize(Consts.Nodes.EmptyTilemap, string.Empty, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight, Configuration.Settings.SceneWidth, Configuration.Settings.SceneHeight);

                    // Add to repo
                    tilemapRepository.Add(tilemap);

                    // Save tilemap
                    //tilemapRepository.Save();

                    // Add node to tree
                    //item.Root.Nodes.Add(item.Node);
                    if (this.view.TreeView.InvokeRequired)
                    {
                        this.view.TreeView.Invoke(new Action(() => { item.Root.Nodes.Add(item.Node); }));
                    }
                    else
                    {
                        item.Root.Nodes.Add(item.Node);
                    }
                },
                UnExecute = () =>
                {

                },
                Name = "Created New Tilemap",
                ID = Guid.NewGuid(),
                Description = "Creates new tilemap node under Tilemaps root in Entities tool window",
            }, false, item.ClassName());
        }

        private async Task LoadAllNodes()
        {
            await LoadTilemapNodes();
        }

        private Task LoadTilemapNodes()
        {
            return Task.Run(() =>
                {
                    EntitiesRootNode rootNode = view.TreeView.Nodes.FirstOrDefault(node => node is EntitiesRootNode && ((EntitiesRootNode)node).EntityType == Enums.EntityTypes.Tilemaps) as EntitiesRootNode;

                    if (rootNode == null)
                        return;


                    tilemapRepository.FindAll(predicate => true).ForEach(tilemap =>
                    {
                        rootNode.Nodes.Add(new EntitiesChildNode() { ID = tilemap.ID, Text = tilemap.Name, EntityType = Enums.EntityTypes.Tilemaps, ContextMenu = this.view.ContextMenuChild });
                    });
                });
        }
    }
}
