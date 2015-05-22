using oEditor.Aggregators;
using oEditor.Controls;
using oEditor.Views;
using oEngine.Common;
using oEngine.Entities;
using oEngine.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace oEditor.Presenters
{
    public class TilemapPresenter : IPresenter, ISubscriber<OnTilemapDescriptionChanged>,
        ISubscriber<OnTilemapHeightChanged>, ISubscriber<OnTilemapWidthChanged>,
        ISubscriber<OnTilemapMouseDown>, ISubscriber<OnTilemapMouseWheel>,
        ISubscriber<OnTilemapMouseUp>, ISubscriber<OnTilemapMouseMove>,
        ISubscriber<OnTilemapNameChanged>, ISubscriber<OnMergeLayer>,
        ISubscriber<OnAddTileset>, ISubscriber<OnRemoveTileset>,
        ISubscriber<OnAddTilemapLayer>, ISubscriber<OnRemoveTilemapLayer>,
        ISubscriber<OnMoveTilemapLayerUp>, ISubscriber<OnMoveTilemapLayerDown>,
        ISubscriber<OnAddTilesetTexture>, ISubscriber<OnSelectTilesetTexture>,
        ISubscriber<OnRenameTilemapLayer>, ISubscriber<OnRenameTilemapLayerOK>,
        ISubscriber<OnPaintModeClicked>

    {
        private readonly ITilemapToolboxView toolbox;

        private readonly ITilemapDocumentView view;

        private readonly IEventAggregator eventAggregator;
        
        private readonly CommandManager commandManager;

        private Enums.PaintModes paintMode;

        private int[,] tilemapValues;

        public Tilemap Tilemap { get; set; }

        public TilemapPresenter(IEventAggregator eventAggregator, ITilemapToolboxView toolbox, ITilemapDocumentView view, Tilemap tilemap)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.Subscribe(this);

            this.toolbox = toolbox;

            this.view = view;

            this.Tilemap = tilemap;

            this.view.Tilemap = tilemap;

            this.commandManager = new CommandManager();

            this.paintMode = Enums.PaintModes.Draw;

            RefreshTilemap();
        }


      

        public void OnEvent(OnRenameTilemapLayerOK e)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Rename Tilemap Layer OK",
                CanExecute = () =>
                { 
                    return !string.IsNullOrEmpty(e.LayerName)
                        && (toolbox.SelectedTilemapLayer == null ? false : Tilemap.FindTilemapLayers(l => l.ID == (Guid)toolbox.SelectedTilemapLayer.Tag).Any())
                        /*&& Regex.IsMatch(e.LayerName, @"^[A-Z0-9 _]*[A-Z0-9][A-Z0-9 _]*$")*/;
                },
                Execute = () =>
                {
                    Layer<TileVisual> layer = Tilemap.FindTilemapLayers(l => l.ID == (Guid)toolbox.SelectedTilemapLayer.Tag).FirstOrDefault();
                                        
                    layer.Name = e.LayerName;
                    toolbox.SelectedTilemapLayer.Text = e.LayerName;

                    RefreshTilemap();
                   
                },
            }, false);
        }

        public void OnEvent(OnRenameTilemapLayer e)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Rename Tilemap Layer",
                CanExecute = () => { return e.Item != null; },
                Execute = () =>
                {
                    TilemapLayerRenameView rename = new TilemapLayerRenameView(eventAggregator, e.Item.Text);
                    rename.ShowDialog();
                },
            }, false);
        }

        public void OnEvent(OnSelectTilesetTexture e)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Tileset Selected",
                CanExecute = () => { return !Tilemap.FindTilesets(t => t.TextureName == e.FileName).Any(); },
                Execute = () =>
                {                
                    // Create new tileset
                    Tileset tileset = new Tileset() 
                    {
                        ID = Guid.NewGuid(),
                        Name = Path.GetFileNameWithoutExtension(e.FileName),
                        TextureName = e.FileName,
                        Texture = XnaHelper.Instance.LoadTexture(Consts.OscPaths.TilesetTexturesDirectory + @"\" + e.FileName),
                    };

                

                    //toolbox.HideCloseButtonForPage(page);

                    // Set up toolbox with new tileset
                    toolbox.TilesetsPages.Pages.Add(new TilesetPage(eventAggregator)
                    {
                        Tileset = tileset,
                        Text = Path.GetFileNameWithoutExtension(e.FileName),
                        Name = e.FileName,
                    });

                    // Set up tilemap to add this tileset
                    Tilemap.AddTileset(tileset);

                    RefreshTilemap();
                },
            }, false);
        }

        public void OnEvent(OnRemoveTileset e)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Remove Tilset",
                CanExecute = () => { return e.Page != null && (e.Page == null ? false : Tilemap.FindTilesets(t => t.TextureName == e.Page.Name).Any()); },
                Execute = () =>
                {
                    DialogResult dialog = RadMessageBox.Show(Consts.AlertMessages.Messages.RemoveTileset, Consts.AlertMessages.Captions.RemoveTileset, MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button2);

                    if(dialog == DialogResult.Yes)
                    {
                        // Get id of tileset
                        Guid tilesetID = Tilemap.FindTilesets(t => t.TextureName == e.Page.Name).FirstOrDefault().ID;

                        // Remove from model
                        Tilemap.RemoveTileset(tilesetID);
                        
                        // Remove from toolbox
                        toolbox.TilesetsPages.Pages.Remove(e.Page);

                        RefreshTilemap();
                    }
                },
            }, false);
        }

        public void OnEvent(OnAddTilesetTexture e)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Add Tileset Texture",
                CanExecute = () => { return true; },
                Execute = () =>
                {
                    // Open file dialog to find png
                    using (OpenFileDialog dialog = new OpenFileDialog())
                    {
                        dialog.Filter = "Image Files (.png)|*.png;";
                        dialog.Multiselect = false;
                        dialog.RestoreDirectory = true;

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            // Get filepath
                            string filePath = dialog.FileName;
                            string fileName = Path.GetFileName(filePath);

                            // Check paths
                            if (!Directory.Exists(Consts.OscPaths.TilesetTexturesDirectory))
                            {
                                Directory.CreateDirectory(Consts.OscPaths.TilesetTexturesDirectory);
                            }

                            
                            if (File.Exists(Consts.OscPaths.TilesetTexturesDirectory + @"\" + fileName))
                            {
                                RadMessageBox.Show(Consts.AlertMessages.Messages.ImageAlreadyExists, Consts.AlertMessages.Captions.ImageAlreadyExists, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            }
                            else
                            {
                                // Copy file into osc path
                                File.Copy(filePath, Consts.OscPaths.TilesetTexturesDirectory + @"\" + fileName);
                                e.List.Items.Add(fileName);
                            }
                        }
                    }
                },                    
            }, false);
            
        }

   

        public void OnEvent(OnRemoveTilemapLayer e)
        {
           
        }

        public void OnEvent(OnAddTileset e)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Open Tileset List View",
                CanExecute = () => { return true; },
                Execute = () => 
                {  
                    TilesetListView tilesetListView = new TilesetListView(eventAggregator);
                    tilesetListView.ShowDialog();
                },
            }, false);          
        }

        public void OnEvent(OnAddTilemapLayer e)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Add Tilemap Layer",
                CanExecute = () =>
                {
                    return Tilemap != null;
                },
                Execute = () =>
                {
                    Guid id = Guid.NewGuid();

                    Tilemap.AddTilemapLayer(id, "Tilemap Layer", string.Empty);
                    toolbox.TilemapLayersListBox.Items.Add(new ListViewDataItem() { Text = "Tilemap Layer", Tag = id });
                    RefreshTilemap();
                },
            }, false);
        }

     

        public void OnEvent(OnMergeLayer e)
        {
           
        }

        public void OnEvent(OnMoveTilemapLayerDown e)
        {
          
        }

        public void OnEvent(OnMoveTilemapLayerUp e)
        {
        
        }

     

        public void OnEvent(OnTilemapDescriptionChanged e)
        {
      
        }

        public void OnEvent(OnTilemapWidthChanged e)
        {
      
        }

        public void OnEvent(OnTilemapHeightChanged e)
        {
      
        }

        public void OnEvent(OnTilemapMouseMove e)
        {
           
        }
        
        public void OnEvent(OnTilemapMouseDown e)
        {

        }

        public void OnEvent(OnTilemapMouseUp e)
        {
      
        }

        public void OnEvent(OnTilemapMouseWheel e)
        {
       
        }

        public void OnEvent(OnTilemapNameChanged e)
        {
          
        }

        public void OnEvent(OnPaintModeClicked e)
        {
            this.paintMode = e.PaintMode;
        }

        private void RefreshTilemap()
        {
            this.view.Tilemap = Tilemap;
            toolbox.TilemapWidth = Tilemap.Width;
            toolbox.TilemapHeight = Tilemap.Height;
            toolbox.TilemapDescription = Tilemap.Description;
            toolbox.TilemapName = Tilemap.Name;
        }
    }
}
