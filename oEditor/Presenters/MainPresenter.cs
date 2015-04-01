using oEditor.Aggregators;
using oEditor.Common;
using oEditor.Controls;
using oEditor.Repositories;
using oEditor.Views;
using oEngine.Common;
using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Presenters 
{
    public class MainPresenter : ISubscriber<OnMainLoaded>,
        ISubscriber<OnCreateEmptyTilemap>, ISubscriber<OnTilemapNodeDoubleClicked>,
        ISubscriber<OnDeleteTilemap>
        
    {
        private readonly IEventAggregator eventAggregator;

        private readonly IMainView view;

        private readonly EntitiesPresenter entitiesPresenter;
        private readonly IEntitiesView entitiesView;

        private readonly IRepository<Tilemap> tilemapRepository;

        public MainPresenter(IEventAggregator eventAggregator, IMainView mainView)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.Subscribe(this);

            this.view = mainView;

            this.tilemapRepository = new TilemapRepository();
 
            this.entitiesView = new EntitiesView(eventAggregator);
            this.entitiesPresenter = new EntitiesPresenter(eventAggregator, entitiesView);

            this.view.DockManager.DockWindow((DockWindow)entitiesView, DockPosition.Right);
     
        }
        public void OnEvent(OnTilemapNodeDoubleClicked e)
        { 
            // Prevent creating a new instance of the views when the tabbed view is currently open
            // Need to decide how toolbox will interact with this functionality

            DockWindow window = view.DockManager.DockWindows.Where(w => w.GetType() == typeof(TilemapDocumentView)).FirstOrDefault(w => ((ITilemapDocumentView)w).ID == e.Node.ID);

            if(window != null)
            {
                window.Select();
                return;
            }
            

            Tilemap tilemap = tilemapRepository.FindEntities(t => t.ID == e.Node.ID).FirstOrDefault();

            
            if (tilemap == null)
                throw new Exception("Tilemap does not exist in file, the file is corrupt or missing");

            ITilemapDocumentView tilemapView = new TilemapDocumentView(eventAggregator);
            tilemapView.ID = tilemap.ID;
            ITilemapToolboxView tilemapToolbox = new TilemapToolboxView(eventAggregator);
            tilemapToolbox.ID = tilemap.ID;
            TilemapPresenter tilemapPresenter = new TilemapPresenter(eventAggregator, tilemapToolbox, tilemapView, tilemap);

            view.DockManager.DockWindow((ToolWindow)tilemapToolbox, DockPosition.Left);
            view.DockManager.DockWindow((DocumentWindow)tilemapView, DockPosition.Fill);
        }

        public void OnEvent(OnMainLoaded e)
        {
            entitiesView.TreeView.Nodes.Where(n => n.GetType() == typeof(EntitiesRootNode)).ForEach(node =>
            {
                EntitiesRootNode castedNode = (EntitiesRootNode)node;

                switch (castedNode.EntityType)
                {
                    case Enums.EntityTypes.Characters:
                        break;
                    case Enums.EntityTypes.Items:
                        break;
                    case Enums.EntityTypes.Quests:
                        break;
                    case Enums.EntityTypes.Tilemaps:
                        tilemapRepository.FindEntities(t => true).ForEach(t =>
                        {
                            castedNode.Nodes.Add(new EntitiesTilemapNode() { ID = t.ID, Text = t.Name, ContextMenu = entitiesView.ContextMenuTilemap });
                        });
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
            });
        }

        /// <summary>
        /// Initialize child nodes in entities view
        /// </summary>
        /// <param name="e"></param>
        public void OnEvent(OnEntitiesViewLoaded e)
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
            catch (Exception exception)
            {
                Logger.Log("RepositoryPresenter", "OnCreateEmptyTilemap", exception);
            }
        }
    }
}
