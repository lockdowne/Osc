using Osc.Rotch.Editor.Views;
using Osc.Rotch.Engine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osc.Rotch.Engine.Common;
using Osc.Rotch.Engine.Controls;
using Osc.Rotch.Editor.Events;
using Osc.Rotch.Engine.Entities;
using Osc.Rotch.Editor.Repositories;
using Osc.Rotch.Editor.Controls;
using Osc.Rotch.Editor.Common;
using Osc.Rotch.Engine.Aggregators;
using Telerik.WinControls;
using System.Windows.Forms;

namespace Osc.Rotch.Editor.Controllers
{
    public class EntitiesController : IEntitiesController, ISubscriber<OnCreateTilemapNode>, ISubscriber<OnEditTilemapNodeClicked>, ISubscriber<OnDeleteTilemapNodeClicked>,
        ISubscriber<OnTilemapPropertiesSaved>, ISubscriber<OnCreateTilemapAssetsNode>, ISubscriber<OnEditTilemapAssetsNodeClicked>, ISubscriber<OnDeleteTilemapAssetsNodeClicked>,
        ISubscriber<OnTilemapAssetPropertiesSaved>
    {
        private readonly IEntitiesView view;

        private readonly ICommandManager commandManager;

        private readonly IRepository<Tilemap> tilemapRepository;
        private readonly IRepository<TilemapAsset> tilemapAssetRepository;

        private readonly IEventAggregator eventAggregator;

        public EntitiesController(IEntitiesView entitiesView, ICommandManager commandManager, IEventAggregator eventAggregator, IRepository<Tilemap> tilemapRepository, IRepository<TilemapAsset> tilemapAssetRepository)
        {
            this.view = entitiesView;
            this.commandManager = commandManager;
            this.tilemapRepository = tilemapRepository;
            this.tilemapAssetRepository = tilemapAssetRepository;
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
        public void OnEvent(OnDeleteTilemapAssetsNodeClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Deleted Tilemap Asset",
                CanExecute = () => { return item != null && item.Node != null && tilemapAssetRepository.Find(t => t.ID == item.Node.ID) != null; },
                Execute = () =>
                {
                    TilemapAsset tilemapAsset = tilemapAssetRepository.Find(t => t.ID == item.Node.ID);

                    tilemapAssetRepository.Remove(tilemapAsset);
                    item.Node.Remove();
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnCreateTilemapAssetsNode item)
        {
            commandManager.ExecuteCommandAsync(new Command()
            {
                CanExecute = () =>
                {
                    return item != null && item.Root != null && item.Node != null;
                },
                Execute = () =>
                {
                    // Create empty tilemap
                    TilemapAsset tilemapAsset = new TilemapAsset()
                    {
                        ID = item.Node.ID,
                        Alpha = 1.0f,
                        Name = Consts.Nodes.TilemapAsset,
                        VisualLayers = new List<Layer<TileVisual>>(),
                    };
                    // Add to repo
                    tilemapAssetRepository.Add(tilemapAsset);

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
                Name = "Created New Tilemap Asset",
                ID = Guid.NewGuid(),
            }, false, item.ClassName());
        }

        public void OnEvent(OnEditTilemapAssetsNodeClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Opened Tilemap Asset Properties Window",
                CanExecute = () => { return item != null && tilemapAssetRepository.Find(t => t.ID == item.Node.ID) != null; },
                Execute = () =>
                {
                    TilemapAsset tilemap = tilemapAssetRepository.Find(t => t.ID == item.Node.ID);

                    TilemapAssetPropertiesView propertiesView = new TilemapAssetPropertiesView(eventAggregator);
                    propertiesView.ID = tilemap.ID;
                    propertiesView.TilemapAssetName = tilemap.Name;
                    propertiesView.TilemapAssetDescription = tilemap.Description;
                    propertiesView.ShowDialog();

                },
            }, false, item.ClassName());     
        }

        public void OnEvent(OnTilemapPropertiesSaved item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Tilemap properties changed",
                CanExecute = () => { return item != null && !string.IsNullOrEmpty(item.TilemapName) && this.view.SelectedNode != null && tilemapRepository.Find(t => t.ID == item.ID) != null; },
                Execute = () =>
                {
                    Tilemap tilemap = tilemapRepository.Find(t => t.ID == item.ID);

                    tilemap.Name = item.TilemapName;
                    tilemap.Description = item.TilemapDescription;                                       

                    this.view.SelectedNode.Text = item.TilemapName;
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnTilemapAssetPropertiesSaved item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Tilemap properties changed",
                CanExecute = () => { return item != null && !string.IsNullOrEmpty(item.TilemapAssetName) && this.view.SelectedNode != null && tilemapAssetRepository.Find(t => t.ID == item.ID) != null; },
                Execute = () =>
                {
                    TilemapAsset tilemap = tilemapAssetRepository.Find(t => t.ID == item.ID);

                    tilemap.Name = item.TilemapAssetName;
                    tilemap.Description = item.TilemapAssetDescription;

                    this.view.SelectedNode.Text = item.TilemapAssetName;
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnDeleteTilemapNodeClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Deleted Tilemap",
                CanExecute = () => { return item != null && item.Node != null && tilemapRepository.Find(t => t.ID == item.Node.ID) != null; },
                Execute = () =>
                {                    
                    Tilemap tilemap = tilemapRepository.Find(t => t.ID == item.Node.ID);

                    tilemapRepository.Remove(tilemap);
                    item.Node.Remove();                    
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnEditTilemapNodeClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Opened Tilemap Properties Window",
                CanExecute = () => { return item != null && tilemapRepository.Find(t => t.ID == item.Node.ID) != null; },
                Execute = () =>
                {
                    Tilemap tilemap = tilemapRepository.Find(t => t.ID == item.Node.ID);

                    TilemapPropertiesView propertiesView = new TilemapPropertiesView(eventAggregator);
                    propertiesView.ID = tilemap.ID;
                    propertiesView.TilemapName = tilemap.Name;
                    propertiesView.TilemapDescription = tilemap.Description;
                    propertiesView.ShowDialog();

                },
            }, false, item.ClassName());                       
        }

        public void OnEvent(OnCreateTilemapNode item)
        {
            commandManager.ExecuteCommand(new Command()
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
                    tilemap.Initialize(Consts.Nodes.Tilemap, string.Empty, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight, Configuration.Settings.SceneWidth, Configuration.Settings.SceneHeight);

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

        private async void LoadAllNodes()
        {
            await Task.Run(() =>
            {
                // Tilemaps
                EntitiesRootNode tilemapRootNode = view.TreeView.Nodes.FirstOrDefault(node => node is EntitiesRootNode && ((EntitiesRootNode)node).EntityType == Enums.EntityTypes.Tilemaps) as EntitiesRootNode;

                if (tilemapRootNode == null)
                    return;

                tilemapRepository.FindAll(predicate => true).ForEach(tilemap =>
                {
                    tilemapRootNode.Nodes.Add(new EntitiesChildNode() { ID = tilemap.ID, Name = tilemap.ID.ToString(), Text = tilemap.Name, EntityType = Enums.EntityTypes.Tilemaps, ContextMenu = this.view.ContextMenuChild });
                });

                // Tilemap Assets
                EntitiesRootNode tilemapAssetRootNode = view.TreeView.Nodes.FirstOrDefault(node => node is EntitiesRootNode && ((EntitiesRootNode)node).EntityType == Enums.EntityTypes.TilemapAssets) as EntitiesRootNode;

                if (tilemapAssetRootNode == null)
                    return;

                tilemapAssetRepository.FindAll(predicate => true).ForEach(tilemap =>
                {
                    tilemapAssetRootNode.Nodes.Add(new EntitiesChildNode() { ID = tilemap.ID, Name = tilemap.ID.ToString(), Text = tilemap.Name, EntityType = Enums.EntityTypes.TilemapAssets, ContextMenu = this.view.ContextMenuChild });
                });
            });    
        }
    }
}
