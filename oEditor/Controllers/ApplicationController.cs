using oEditor.Repositories;
using oEditor.Views;
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

            // Entities
            IEntitiesView entitiesView = new EntitiesView();
            IEntitiesController entitiesController = new EntitiesController(entitiesView, new CommandManager(logger), tilemapRepository);

            // Console
            IConsoleView consoleView = new ConsoleView();
            IConsoleController consoleController = new ConsoleController(consoleView, logger);
            
            // Create main view
            IMainView mainView = new MainView();
            MainController mainController = new MainController(mainView, entitiesController, new CommandManager(logger), logger, tilemapRepository);
            mainController.DockWindow((DockWindow)consoleView, DockPosition.Bottom);
            mainController.DockWindow((DockWindow)entitiesView, DockPosition.Right);

            logger.Log("Program Initialized");

            Application.Run((Form)mainView);

            
        }
    }
}
