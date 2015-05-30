using oEditor.Repositories;
using oEditor.Views;
using oEngine.Entities;
using oEngine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI.Docking;
using oEngine.Common;
using oEditor.Events;
using oEngine.Aggregators;
using oEditor.Common;

namespace oEditor.Controllers
{
    public class MainController : ISubscriber<OnTilemapNodeDoubleClicked>
    {
        private readonly IMainView view;

        private readonly IRepository<Tilemap> tilemapRepository;

        private readonly IEntitiesController entitiesController;

        private readonly ICommandManager commandManager;

        private readonly ILogger logger;

        private List<IController> activeControllers = new List<IController>();


        public MainController(IMainView mainView, IEntitiesController entitiesController, ICommandManager commandManager, ILogger logger, IRepository<Tilemap> tilemapRepository)
        {
            this.view = mainView;
            this.entitiesController = entitiesController;

            this.commandManager = commandManager;

            this.tilemapRepository = tilemapRepository;

            this.logger = logger;

            this.Subscribe();
            //this.view.DockManager.DockWindow((DockWindow)entitiesController.View, DockPosition.Right);            
        }

        public void OnEvent(OnTilemapNodeDoubleClicked item)
        {
            string name = item.ClassName();

            commandManager.ExecuteCommand(new Command()
            {
                CanExecute = () =>
                {
                    if (item == null)
                        return false;

                    return item.Node != null && tilemapRepository.Find(tilemap => tilemap.ID == item.Node.ID) != null;
                },
                Execute = () =>
                {
                    Tilemap tilemap = tilemapRepository.Find(t => t.ID == item.Node.ID);

                    ITilemapDocumentView documentView = new TilemapDocumentView() { Tilemap = tilemap };
                    TilemapController tilemapController = new TilemapController(documentView, new CommandManager(logger), tilemapRepository);

                    activeControllers.Add(tilemapController);

                    DockWindow((DockWindow)documentView, DockPosition.Fill);
                },
                UnExecute = () =>
                {

                },
                ID = Guid.NewGuid(),
                Name = "Opened Tilemap",
                Description = "Opens the selected tilemap node and opens it for editing",
            }, false, name);

        }

        public void DockWindow(DockWindow window, DockPosition position)
        {
            this.view.DockManager.DockWindow(window, position);
        }
    }
}
