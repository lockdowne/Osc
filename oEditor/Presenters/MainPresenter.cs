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
        private readonly IRepository<Scene> sceneRepository;

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

            sceneRepository = new SceneRepository();

            entitiesView = new EntitiesView();
            entitiesPresenter = new EntitiesPresenter(entitiesView, sceneRepository);

            consoleView = new ConsoleView();

            // Default docks
            DockView((ConsoleView)consoleView, DockPosition.Bottom);
            DockView((EntitiesView)entitiesView, DockPosition.Right);

            this.view.WindowClosing += (sender, e) =>
            {
                
                if(e.OldWindow is ToolWindow)
                {

                }
            };

        }

        private void DockView(Control control, DockPosition position)
        {
            this.view.DockManager.DockControl(control, position);
        }
    }
}
