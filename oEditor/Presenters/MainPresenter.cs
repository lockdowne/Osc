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


            sceneRepository.OpenEntity += (scene) =>
            {
                // Create new window with scene values
                // Does not need to be a command as no logic is created just a tabbed window
                DockView(new TilemapView() { Tilemap = scene, Tag = scene.ID }, DockPosition.Fill);
                
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

        private void RefreshDockWindows()
        {
            List<Guid> ids = new List<Guid>();
            ids.AddRange(sceneRepository.FindEntities(x => true).Select(i => i.ID));

            this.view.DockManager.DockWindows.Where(w => w.DockType == DockType.Document).ForEach(x =>
            {
                if (!ids.Contains((Guid)x.Tag))
                    x.Close();
            });

            ids.Clear();
        }

        private void DockView(DockWindow control, DockPosition position)
        {
            this.view.DockManager.DockWindow(control, position);
        }
    }
}
