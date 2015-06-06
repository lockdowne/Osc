using Osc.Rotch.Editor.Repositories;
using Osc.Rotch.Editor.Views;
using Osc.Engine.Entities;
using Osc.Engine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI.Docking;
using Osc.Engine.Common;
using Osc.Rotch.Editor.Events;
using Osc.Engine.Aggregators;
using Osc.Rotch.Editor.Common;

namespace Osc.Rotch.Editor.Controllers
{
    public class MainController : ISubscriber<OnTilemapNodeDoubleClicked>
    {
        private readonly IMainView view;

        private readonly IRepository<Tilemap> tilemapRepository;

        private readonly IEntitiesController entitiesController;

        private readonly ICommandManager commandManager;

        private readonly ILogger logger;

        private readonly IEventAggregator eventAggregator;

        private List<IController> activeControllers = new List<IController>();


        public MainController(IMainView mainView, IEntitiesController entitiesController, ICommandManager commandManager, ILogger logger, IEventAggregator eventAggregator, IRepository<Tilemap> tilemapRepository)
        {
            this.view = mainView;
            this.entitiesController = entitiesController;

            this.commandManager = commandManager;

            this.eventAggregator = eventAggregator;

            this.tilemapRepository = tilemapRepository;

            this.logger = logger;

            this.eventAggregator.Subscribe(this);
            //this.view.DockManager.DockWindow((DockWindow)entitiesController.View, DockPosition.Right);            
        }

        public void OnEvent(OnTilemapNodeDoubleClicked item)
        {
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

                    IEventAggregator aggregator = new EventAggregator();

                    ITilemapDocumentView documentView = new TilemapDocumentView(aggregator) { Tilemap = tilemap, Name = tilemap.Name };
                    TilemapController tilemapController = new TilemapController(documentView, new CommandManager(logger), aggregator, tilemapRepository);

                    activeControllers.Add(tilemapController);

                    DockWindow((DockWindow)documentView, DockPosition.Fill);
                },
                UnExecute = () =>
                {

                },
                ID = Guid.NewGuid(),
                Name = "Opened Tilemap",
                Description = "Opens the selected tilemap node and opens it for editing",
            }, false, item.ClassName());

        }

        public void DockWindow(DockWindow window, DockPosition position)
        {
            this.view.DockManager.DockWindow(window, position);
        }
    }
}
