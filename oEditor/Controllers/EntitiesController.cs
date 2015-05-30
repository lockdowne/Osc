using oEditor.Views;
using oEngine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oEngine.Common;
using oEngine.Controls;
using oEditor.Events;
using oEngine.Entities;
using oEditor.Repositories;
using oEditor.Controls;
using oEditor.Common;
using oEngine.Aggregators;

namespace oEditor.Controllers
{
    public class EntitiesController : IEntitiesController, ISubscriber<OnCreateTilemapNode>
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
                Name = "LoadAllNodes",
                ID = Guid.NewGuid(),
                Description = "Populate all created nodes",
            }, false);
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
                    tilemapRepository.SaveAsync();

                    // Add node to tree
                    //item.Root.Nodes.Add(item.Node);
                    item.Root.Nodes.Add(item.Node);
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
                    rootNode.Nodes.Add(new EntitiesTilemapNode() { ID = tilemap.ID, Text = tilemap.Name });
                });
            });
        }
    }
}
