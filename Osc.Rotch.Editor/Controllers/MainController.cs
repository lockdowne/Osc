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
        ISubscriber<OnProjectWindowVisibilityChanged>, ISubscriber<OnEntitiesWindowVisibilityChanged>, ISubscriber<OnLocalClicked>, ISubscriber<OnSyncClicked>,
        ISubscriber<OnTilemapPropertiesSaved>, ISubscriber<OnDocumentWindowClosed>, ISubscriber<OnDeleteTilemapNodeClicked>, ISubscriber<OnThemeClicked>, ISubscriber<OnSettingsClicked>,
        ISubscriber<OnResetConfiguration>, ISubscriber<OnDeleteTilemapAssetsNodeClicked>, ISubscriber<OnTilemapAssetsNodeDoubleClicked>, ISubscriber<OnTilemapAssetPropertiesSaved>
        
    {
        private readonly IMainView view;

        private readonly IRepository<Tilemap> tilemapRepository;
        private readonly IRepository<TilemapAsset> tilemapAssetRepository;

        private readonly ICommandManager commandManager;

        private readonly ILogger logger;

        private readonly IEventAggregator eventAggregator;

        private List<IController> activeControllers = new List<IController>();


        public MainController(IMainView mainView, ICommandManager commandManager, ILogger logger, IEventAggregator eventAggregator, IRepository<Tilemap> tilemapRepository, IRepository<TilemapAsset> tilemapAssetRepository)
        {
            this.view = mainView;

            this.commandManager = commandManager;

            this.eventAggregator = eventAggregator;

            this.tilemapRepository = tilemapRepository;
            this.tilemapAssetRepository = tilemapAssetRepository;

            this.logger = logger;

            this.eventAggregator.Subscribe(this);
            //this.view.DockManager.DockWindow((DockWindow)entitiesController.View, DockPosition.Right);     
       
            // TODO: Do heavy lifting of initial set up here
            //ProgressHelper.Show(() => { Thread.Sleep(4000); });

        }

        public void OnEvent(OnTilemapAssetsNodeDoubleClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                CanExecute = () =>
                {

                    return item != null && item.Node != null && tilemapAssetRepository.Find(tilemapAsset => tilemapAsset.ID == item.Node.ID) != null;
                },
                Execute = () =>
                {
                    TilemapAsset tilemapAsset = tilemapAssetRepository.Find(t => t.ID == item.Node.ID);
                    IEventAggregator aggregator = new EventAggregator();

                    ITilemapAssetDocumentView documentView = new TilemapAssetDocumentView(aggregator)
                    {
                        ID = tilemapAsset.ID,
                        Name = tilemapAsset.ID.ToString(),
                        Text = tilemapAsset.Name,
                        TilemapAssetEditor = new TilemapAssetEditor()
                        {
                            ID = tilemapAsset.ID,
                            Asset = tilemapAsset,
                            IsGridVisible = true,
                            Height = tilemapAsset.VisualLayers.FirstOrDefault() == null ? Configuration.Settings.SceneHeight : tilemapAsset.VisualLayers.FirstOrDefault().Height,
                            Width = tilemapAsset.VisualLayers.FirstOrDefault() == null ? Configuration.Settings.SceneWidth : tilemapAsset.VisualLayers.FirstOrDefault().Width,
                            Name = tilemapAsset.Name,
                            TileHeight = Configuration.Settings.TileHeight,
                            TileWidth = Configuration.Settings.TileWidth,
                            Tilesets = new List<Tileset>(),
                        }
                    };

                    TilemapAssetController tilemapAssetController = new TilemapAssetController(documentView, new CommandManager(logger), aggregator, tilemapAssetRepository) { ID = tilemapAsset.ID };
                    activeControllers.Add(tilemapAssetController);

                    if (!this.view.DockManager.DockWindows.DocumentWindows.Any(window => window.Name == tilemapAsset.ID.ToString()))
                        DockWindow((DockWindow)documentView, DockPosition.Fill);
                    

                    //Tilemap tilemap = tilemapRepository.Find(t => t.ID == item.Node.ID);

                    //IEventAggregator aggregator = new EventAggregator();

                    //ITilemapDocumentView documentView = new TilemapDocumentView(aggregator) { Tilemap = tilemap, Name = tilemap.ID.ToString(), Text = tilemap.Name };
                    //TilemapController tilemapController = new TilemapController(documentView, new CommandManager(logger), aggregator, tilemapRepository) { ID = tilemap.ID };

                    //activeControllers.Add(tilemapController);

                    //if (!this.view.DockManager.DockWindows.DocumentWindows.Any(window => window.Name == tilemap.ID.ToString()))
                    //    DockWindow((DockWindow)documentView, DockPosition.Fill);
               
                },
                UnExecute = () =>
                {

                },
                ID = Guid.NewGuid(),
                Name = "Opened Tilemap Asset",
            }, false, item.ClassName());
        }

        public void OnEvent(OnResetConfiguration item)
        {
            var result = RadMessageBox.Show(Consts.AlertMessages.Messages.ResetConfiguration, Consts.AlertMessages.Captions.ResetConfiguration, System.Windows.Forms.MessageBoxButtons.YesNo, RadMessageIcon.Question);
            
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Reset Configuration",
                CanExecute = () => { return result == System.Windows.Forms.DialogResult.Yes; },
                Execute = () =>
                {
                    Configuration.Settings = Settings.Default();
                    Configuration.SaveSettings();
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnSettingsClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Opened Settings",
                CanExecute = () => { return true; },
                Execute = () =>
                {
                    SettingsView settings = new SettingsView();
                    settings.ShowDialog();
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnThemeClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Opened Theme",
                CanExecute = () => { return true; },
                Execute = () =>
                {
                    ThemeView theme = new ThemeView();
                    theme.ShowDialog();
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnDeleteTilemapNodeClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Closed Window",
                CanExecute = () => { return item != null && item.Node != null && this.view.DockManager.DockWindows.DocumentWindows.FirstOrDefault(window => window.Name == item.Node.ID.ToString()) != null; },
                Execute = () =>
                {
                    this.view.DockManager.DockWindows.DocumentWindows.FirstOrDefault(window => window.Name == item.Node.ID.ToString()).Close();
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnDeleteTilemapAssetsNodeClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Closed Window",
                CanExecute = () => { return item != null && item.Node != null && this.view.DockManager.DockWindows.DocumentWindows.FirstOrDefault(window => window.Name == item.Node.ID.ToString()) != null; },
                Execute = () =>
                {
                    this.view.DockManager.DockWindows.DocumentWindows.FirstOrDefault(window => window.Name == item.Node.ID.ToString()).Close();
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnDocumentWindowClosed item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Removed Window",
                CanExecute = () => { return item != null && item.Window != null && activeControllers.FirstOrDefault(controller => controller.ID.ToString() == item.Window.Name) != null; },
                Execute = () =>
                {
                    activeControllers.Remove(activeControllers.FirstOrDefault(controller => controller.ID.ToString() == item.Window.Name));
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnTilemapPropertiesSaved item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Tilemap properties changed",
                CanExecute = () => { return item != null && !string.IsNullOrEmpty(item.TilemapName) && this.view.DockManager.DockWindows.DocumentWindows.FirstOrDefault(window => window.Name == item.ID.ToString()) != null; },
                Execute = () =>
                {
                    this.view.DockManager.DockWindows.DocumentWindows.FirstOrDefault(window => window.Name == item.ID.ToString()).Text = item.TilemapName;                 
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnTilemapAssetPropertiesSaved item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Tilemap properties changed",
                CanExecute = () => { return item != null && !string.IsNullOrEmpty(item.TilemapAssetName) && this.view.DockManager.DockWindows.DocumentWindows.FirstOrDefault(window => window.Name == item.ID.ToString()) != null; },
                Execute = () =>
                {
                    this.view.DockManager.DockWindows.DocumentWindows.FirstOrDefault(window => window.Name == item.ID.ToString()).Text = item.TilemapAssetName;
                },
            }, false, item.ClassName());
        }


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

                        tilemapAssetRepository.Save();
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

                    ITilemapDocumentView documentView = new TilemapDocumentView(aggregator) { Tilemap = tilemap, Name = tilemap.ID.ToString(), Text = tilemap.Name };
                    TilemapController tilemapController = new TilemapController(documentView, new CommandManager(logger), aggregator, tilemapRepository) { ID = tilemap.ID };

                    activeControllers.Add(tilemapController);

                    if (!this.view.DockManager.DockWindows.DocumentWindows.Any(window => window.Name == tilemap.ID.ToString()))
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
