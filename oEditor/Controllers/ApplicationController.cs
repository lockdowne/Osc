using oEditor.Repositories;
using oEditor.Views;
using oEngine.Aggregators;
using oEngine.Common;
using oEngine.Entities;
using oEngine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Controllers
{
    public class ApplicationController : IController
    {
        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme theme;

        public ApplicationController()
        {            
            // Set main theme for all telerik controls
            theme = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark";

            // Logger
            ILogger logger = new Logger();

            // Repositories
            IRepository<Tilemap> tilemapRepository = new TilemapRepository();

            IEventAggregator eventAggregator = new EventAggregator();

            // Entities
            IEntitiesView entitiesView = new EntitiesView(eventAggregator);
            IEntitiesController entitiesController = new EntitiesController(entitiesView, new CommandManager(logger), tilemapRepository, eventAggregator);

            IProjectView projectView = new ProjectView(eventAggregator);
            IProjectController projectController = new ProjectController(projectView);

            // Console
            IConsoleView consoleView = new ConsoleView(eventAggregator);
            IConsoleController consoleController = new ConsoleController(consoleView, logger, eventAggregator);
            
            // Create main view
            IMainView mainView = new MainView();
            MainController mainController = new MainController(mainView, entitiesController, new CommandManager(logger), logger, eventAggregator, tilemapRepository);
            mainController.DockWindow((DockWindow)consoleView, DockPosition.Bottom);
            mainController.DockWindow((DockWindow)projectView, DockPosition.Right);
            mainController.DockWindow((DockWindow)entitiesView, DockPosition.Right);

            logger.Log("Program Initialized");

            Application.Run((Form)mainView);

            
        }
    }
}
