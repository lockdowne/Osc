using Osc.Rotch.Editor.Repositories;
using Osc.Rotch.Editor.Views;
using Osc.Rotch.Engine.Aggregators;
using Osc.Rotch.Engine.Common;
using Osc.Rotch.Engine.Entities;
using Osc.Rotch.Engine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace Osc.Rotch.Editor.Controllers
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
            IMainView mainView = new MainView(eventAggregator);
            MainController mainController = new MainController(mainView, new CommandManager(logger), logger, eventAggregator, tilemapRepository);
            mainController.DockWindow((DockWindow)consoleView, DockPosition.Bottom);
            mainController.DockWindow((DockWindow)projectView, DockPosition.Right);
            mainController.DockWindow((DockWindow)entitiesView, DockPosition.Right);
                    
            logger.Log("Program Initialized");

            Application.Run((Form)mainView);

            
        }
    }
}
