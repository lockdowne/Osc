using oEditor.Common;
using oEditor.Repositories;
using oEditor.Views;
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
        private readonly IRepository<Tilemap> sceneRepository;

        private readonly IMainView view;

        // Create all repos here and inject into all presenters

        // Entities window
        private IEntitiesView entitiesView;
        private EntitiesPresenter entitiesPresenter;

        // Console window
        private IConsoleView consoleView;        
       
        public MainPresenter(IMainView mainView)
        {
            this.view = mainView;

            sceneRepository = new TilemapRepository();

            entitiesView = new EntitiesView();
            entitiesPresenter = new EntitiesPresenter(entitiesView, sceneRepository);

            consoleView = new ConsoleView();

            // Default docks
            DockView((ConsoleView)consoleView, DockPosition.Bottom);
            DockView((EntitiesView)entitiesView, DockPosition.Right);


            sceneRepository.OpenEntity += (tilemap) =>
            {
                // Create new window with scene values
                // Does not need to be a command as no logic is created just a tabbed window

                var window = view.DockManager.DockWindows.Where(w => w.DockType == DockType.Document && typeof(ITabbedView).IsAssignableFrom(w.GetType())).FirstOrDefault(w => ((ITabbedView)w).ID == tilemap.ID);

                if (window == null)
                {
                    DockView(new TilemapView() { Tilemap = tilemap, ID = tilemap.ID, EntityType = Enums.EditorEntities.Tilemaps, Text = tilemap.Name }, DockPosition.Fill);
                }
                else
                    window.Select();

                SetToolbox(Enums.EditorEntities.Tilemaps);
            };

            sceneRepository.RepositoryChanged += () =>
            {
                // There should probably be individual methods specific to each repo changed event
                try
                {
                    RefreshDockWindows();
                }
                catch(Exception exception)
                {
                    Logger.Log("MainPresenter", "RepositoryChanged", exception);
                    ConsoleView.WriteLine(exception.ToString());
                }
            };

        }

        private void SetToolbox(Enums.EditorEntities type)        
        {
            // TODO: Set toolbox views value 
            switch (type)
            {
                case Enums.EditorEntities.Characters:
                    break;
                case Enums.EditorEntities.Items:
                    break;
                case Enums.EditorEntities.Quests:
                    break;
                case Enums.EditorEntities.Tilemaps:
                    //this.view.Toolbox = new TilemapToolbox();
                    break;
                case Enums.EditorEntities.Nodes:
                    break;
                case Enums.EditorEntities.BattleScene:
                    break;
                case Enums.EditorEntities.FreeRoamScene:
                    break;
                case Enums.EditorEntities.RandomBattleScene:
                    break;
            }
        }

        private void RefreshDockWindows()
        {
            List<Guid> ids = new List<Guid>();
            ids.AddRange(sceneRepository.FindEntities(x => true).Select(i => i.ID));

            // TODO: Add remaining repos

            List<DockWindow> windowsToClose = new List<DockWindow>();

            this.view.DockManager.DockWindows.Where(w => w.DockType == DockType.Document && typeof(ITabbedView).IsAssignableFrom(w.GetType())).ForEach(x =>
            {
                if (!ids.Contains(((ITabbedView)x).ID))
                    windowsToClose.Add(x);
            });

            windowsToClose.ForEach(w => w.Close());
            windowsToClose.Clear();
            ids.Clear();
        }

        private void DockView(DockWindow control, DockPosition position)
        {
            this.view.DockManager.DockWindow(control, position);
        }
    }
}
