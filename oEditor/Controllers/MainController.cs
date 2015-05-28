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

namespace oEditor.Controllers
{
    public class MainController
    {
        private readonly IMainView view;

        private readonly IRepository<Tilemap> tilemapRepository;

        private readonly IEntitiesController entitiesController;

        private readonly ICommandManager commandManager;


        public MainController(IMainView mainView, IEntitiesController entitiesController, ICommandManager commandManager, IRepository<Tilemap> tilemapRepository)
        {
            this.view = mainView;
            this.entitiesController = entitiesController;

            this.commandManager = commandManager;

            this.tilemapRepository = tilemapRepository;

            //this.view.DockManager.DockWindow((DockWindow)entitiesController.View, DockPosition.Right);

            this.Subscribe<OnTilemapNodeDoubleClicked>(async obj =>
            {
                string name = "OnTilemapNodeDoubleClicked";

                var item = await obj;

                await commandManager.ExecuteCommand(new Command()
                    {
                        CanExecute = () =>
                        {
                            if (obj.Exception != null)
                                return false;

                            if (item == null)
                                return false;

                            return item.Node != null && tilemapRepository.Find(tilemap => tilemap.ID == item.Node.ID) != null;
                        },
                        Execute = () =>
                        {
                            Tilemap tilemap = tilemapRepository.Find(t => t.ID == item.Node.ID);

                            //view.DockManager.Invoke(new Action(() => DockWindow((DockWindow)new TilemapDocumentView() { Tilemap = tilemap }, DockPosition.Fill)));
                        },
                        UnExecute = () =>
                        {

                        },
                        ID = Guid.NewGuid(),
                        Name = name,
                        Description = "Opens the selected tilemap node and opens it for editing",
                    }, false, name);

                // Write to console view
                //this.Publish(new OnWriteConsole() { Message = commandManager.LastCommandString }.AsTask());
            });
        }

        public void DockWindow(DockWindow window, DockPosition position)
        {
            this.view.DockManager.DockWindow(window, position);
        }
    }
}
