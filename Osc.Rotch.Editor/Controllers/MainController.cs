using Osc.Rotch.Editor.Repositories;
using Osc.Rotch.Editor.Views;
using Osc.Rotch.Engine.Entities;
using Osc.Rotch.Engine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI.Docking;
using Osc.Rotch.Engine.Common;
using Osc.Rotch.Editor.Events;
using Osc.Rotch.Engine.Aggregators;
using Osc.Rotch.Editor.Common;
using System.Threading;
using Telerik.WinControls;

namespace Osc.Rotch.Editor.Controllers
{
    public class MainController : ISubscriber<OnTilemapNodeDoubleClicked>, ISubscriber<OnConsoleWindowVisibilityChanged>,
        ISubscriber<OnProjectWindowVisibilityChanged>, ISubscriber<OnEntitiesWindowVisibilityChanged>, ISubscriber<OnLocalClicked>, ISubscriber<OnSyncClicked>
        
    {
        private readonly IMainView view;

        private readonly IRepository<Tilemap> tilemapRepository;

        private readonly ICommandManager commandManager;

        private readonly ILogger logger;

        private readonly IEventAggregator eventAggregator;

        private List<IController> activeControllers = new List<IController>();


        public MainController(IMainView mainView, ICommandManager commandManager, ILogger logger, IEventAggregator eventAggregator, IRepository<Tilemap> tilemapRepository)
        {
            this.view = mainView;

            this.commandManager = commandManager;

            this.eventAggregator = eventAggregator;

            this.tilemapRepository = tilemapRepository;

            this.logger = logger;

            this.eventAggregator.Subscribe(this);
            //this.view.DockManager.DockWindow((DockWindow)entitiesController.View, DockPosition.Right);     
       
            // TODO: Do heavy lifting of initial set up here
            //ProgressHelper.Show(() => { Thread.Sleep(4000); });

        }

        //public void OnEvent(OnTilemapPropertiesSaved item)
        //{
        //    commandManager.ExecuteCommand(new Command()
        //    {
        //        Name = "Tilemap properties changed",
        //        CanExecute = () => { return item != null; },
        //        Execute = () =>
        //        {
        //            Tilemap tilemap = tilemapRepository.Find(t => t.ID == item.ID);

        //            int previousWidth = tilemap.Width;
        //            int previousHeight = tilemap.Height;

        //            tilemap.Name = item.TilemapName;
        //            tilemap.Description = item.TilemapDescription;                    

        //            if (previousWidth != item.TilemapWidth || previousHeight != item.TilemapHeight)
        //            {
        //                tilemap.FindTilemapLayers(t => { return true; }).ForEach(layer =>
        //                {
        //                    layer.Resize(item.TilemapWidth, item.TilemapHeight);
        //                });

        //                tilemap.CollisionLayer.Resize(item.TilemapWidth, item.TilemapHeight);

        //                tilemap.Width = item.TilemapWidth;
        //                tilemap.Height = item.TilemapHeight;
        //            }                    
        //        },
        //    }, false, item.ClassName());
        //}

        public void OnEvent(OnSyncClicked item)
        {
            
        }

        public void OnEvent(OnLocalClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Saved to local",
                CanExecute = () => { return item != null; },
                Execute = () =>
                {
                    // Show loading screen
                    ProgressHelper.Show(() =>
                    {
                        tilemapRepository.Save();
                        // TODO: Save all repos here

                        // TODO: Save project files here

                        // TODO: AKA SAVE EVERYTHING HERE
                    });
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnEntitiesWindowVisibilityChanged item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Entities Visibility Changed",
                CanExecute = () => { return item != null; },
                Execute = () =>
                {
                    ToolWindow window = this.view.DockManager.DockWindows.FirstOrDefault(w => w.Name == Consts.Editor.Windows.Entities) as ToolWindow;

                    // Dont check for null

                    if (item.IsVisible)
                        window.Show();
                    else
                        window.Hide();
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnProjectWindowVisibilityChanged item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Project Explorer Visibility Changed",
                CanExecute = () => { return item != null; },
                Execute = () =>
                {
                    ToolWindow window = this.view.DockManager.DockWindows.FirstOrDefault(w => w.Name == Consts.Editor.Windows.ProjectExplorer) as ToolWindow;

                    // Dont check for null

                    if (item.IsVisible)
                        window.Show();
                    else
                        window.Hide();
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnConsoleWindowVisibilityChanged item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Console Visibility Changed",
                CanExecute = () => { return item != null; },
                Execute = () =>
                {
                    ToolWindow window = this.view.DockManager.DockWindows.FirstOrDefault(w => w.Name == Consts.Editor.Windows.Console) as ToolWindow;

                    // Dont check for null

                    if (item.IsVisible)
                        window.Show();
                    else
                        window.Hide();
                },
            }, false, item.ClassName());
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
