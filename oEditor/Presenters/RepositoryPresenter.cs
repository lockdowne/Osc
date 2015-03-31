using oEditor.Aggregators;
using oEditor.Repositories;
using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oEditor.Controls;
using oEngine.Common;
using Telerik.WinControls.UI;
using oEditor.Common;

namespace oEditor.Presenters
{
    public class RepositoryPresenter : ISubscriber<OnCreateEmptyTilemap>,
        ISubscriber<OnDeleteTilemap>, ISubscriber<OnMainLoaded>,
        ISubscriber<OnEntitiesViewLoaded>
    {
        private readonly IEventAggregator eventAggregator;

        private readonly IRepository<Tilemap> tilemapRepository;

        public RepositoryPresenter(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.Subscribe(this);

            tilemapRepository = new TilemapRepository();
        }

        /// <summary>
        /// Initialize child nodes in entities view
        /// </summary>
        /// <param name="e"></param>
        public void OnEvent(OnEntitiesViewLoaded e)
        {
            e.View.TreeView.Nodes.Where(n => n.GetType() == typeof(EntitiesRootNode)).ForEach(node =>
            {
                EntitiesRootNode castedNode = (EntitiesRootNode)node;

                switch (castedNode.EntityType)
                {
                    case Enums.EditorEntities.Characters:
                        break;
                    case Enums.EditorEntities.Items:
                        break;
                    case Enums.EditorEntities.Quests:
                        break;
                    case Enums.EditorEntities.Tilemaps:
                        tilemapRepository.FindEntities(t => true).ForEach(t =>
                        {
                            castedNode.Nodes.Add(new EntitiesTilemapNode() { ID = t.ID, Text = t.Name, ContextMenu = e.View.ContextMenuTilemap});
                        });
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
            });
        }

        public void OnEvent(OnMainLoaded e)
        {
        }

        public void OnEvent(OnDeleteTilemap e)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void OnEvent(OnCreateEmptyTilemap e)
        {
            Tilemap tilemap = new Tilemap() { ID = e.ID };
            tilemap.Initialize("Empty Tilemap", "", Configuration.Settings.TileWidth, Configuration.Settings.TileHeight, Configuration.Settings.SceneWidth, Configuration.Settings.SceneHeight);

            try
            {
                tilemapRepository.SaveEntity(tilemap);
            }
            catch(Exception exception)
            {
                Logger.Log("RepositoryPresenter", "OnCreateEmptyTilemap", exception);
            }
        }
    }
}
