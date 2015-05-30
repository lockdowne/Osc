using Telerik.WinControls.Enumerations;
using oEditor.Repositories;
using oEditor.Views;
using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oEngine.Common;
using oEditor.Events;
using oEngine.Managers;
using System.Windows.Forms;
using System.IO;
using Telerik.WinControls;
using oEditor.Controls;
using Telerik.WinControls.UI;
using oEditor.Common;
using oEngine.Aggregators;
using oEngine.Patterns;
using Microsoft.Xna.Framework;

namespace oEditor.Controllers
{
    public class TilemapController : IController, ISubscriber<OnAddTileset>, ISubscriber<OnSelectTilesetTexture>,
        ISubscriber<OnAddTilesetTexture>, ISubscriber<OnRemoveTileset>, ISubscriber<OnAddTilemapLayer>, ISubscriber<OnRemoveTilemapLayer>,
        ISubscriber<OnMoveTilemapLayerUp>, ISubscriber<OnMoveTilemapLayerDown>, ISubscriber<OnRenameTilemapLayer>, ISubscriber<OnTilemapSelectionBoxClicked>,
        ISubscriber<OnTilemapDrawClicked>, ISubscriber<OnTilemapGridClicked>, ISubscriber<OnTilePatternGenerated>, ISubscriber<OnDrawModeMouseClicked>,
        ISubscriber<OnEraseModeMouseClicked>, ISubscriber<OnCollisionModeMouseClicked>, ISubscriber<OnTilemapEraseClicked>, ISubscriber<OnTilemapCollisionClicked>
    {
        private readonly ITilemapDocumentView view;

        private readonly ICommandManager commandManager;

        private readonly IEventAggregator eventAggregator;

        private readonly IRepository<Tilemap> repository;

        public TilemapController(ITilemapDocumentView tilemapDocumentView, ICommandManager commandManager, IEventAggregator eventAggregator, IRepository<Tilemap> tilemapRepository)
        {
            this.view = tilemapDocumentView;

            this.commandManager = commandManager;

            this.eventAggregator = eventAggregator;

            this.repository = tilemapRepository;

            this.eventAggregator.Subscribe(this);

            LoadTilemap();
        }

        public void OnEvent(OnTilemapPropertiesClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Tilemap Properties Opened",
                CanExecute = () => { return this.view.Tilemap != null; },
                Execute = () =>
                {
                    Tilemap tilemap = this.view.Tilemap;

                    int previousWidth = tilemap.Width;
                    int previousHeight = tilemap.Height;

                    TilemapPropertiesView propertiesView = new TilemapPropertiesView(tilemap.Name, tilemap.Description, tilemap.Width, tilemap.Height);

                    if(propertiesView.ShowDialog() == DialogResult.OK)
                    {
                        // Set name
                        tilemap.Name = propertiesView.TilemapName;

                        // TODO: Switch tilemapproperties view to eventaggregator to rename node in entitiesview

                        // Set description
                        tilemap.Description = propertiesView.TilemapDescription;

                        // Resize if needed
                        int newWidth = propertiesView.TilemapWidth;
                        int newHeight = propertiesView.TilemapHeight;

                        if(previousHeight != newHeight || previousWidth != newWidth)
                        {
                            // TODO: Resize tilemap
                            
                        }
                    }

                    propertiesView.Close();
                    
                },
            });
        }

        public void OnEvent(OnTilemapCollisionClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Collision Mode Enabled",
                CanExecute = () => { return item != null; },
                Execute = () =>
                {
                    this.view.TilemapState = Enums.TilemapStates.Collision;
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnTilemapEraseClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Erase Mode Enabled",
                CanExecute = () => { return item != null; },
                Execute = () =>
                {
                    this.view.TilemapState = Enums.TilemapStates.Erase;
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnCollisionModeMouseClicked item)
        {
            Layer<TileCollision> layer = this.view.Tilemap.CollisionLayer;

            commandManager.ExecuteCommand(new Command()
            {
                Name = "Applied Collision",
                CanExecute = () => { return item != null && item.Positions.Count > 0 && layer != null; },
                Execute = () =>
                {
                    item.Positions.ForEach(pos =>
                    {
                        Point coordinates = MathExtension.IsoPixelsToCoordinate(pos, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight);

                        TileCollision tile = layer.GetTile(coordinates.X, coordinates.Y);

                        if(tile != null)
                        {
                            tile.IsCollidable = !tile.IsCollidable;
                        }
                    });
                },
                UnExecute = () =>
                {
                }
            }, false, item.ClassName());
        }

        public void OnEvent(OnDrawModeMouseClicked item)
        {
            Layer<TileVisual> layer = this.view.Tilemap.FindLayerByIndex(this.view.TilemapLayersListBox.SelectedIndex);

            TilePattern pattern = this.view.TilePattern;

            if (layer == null || pattern == null)
                return;

            Point coordinates = MathExtension.IsoPixelsToCoordinate(this.view.TilePattern.Position, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight);

            int startX = coordinates.X;
            int startY = coordinates.Y;

            int width = this.view.TilePattern.Pattern.GetLength(0);
            int height = this.view.TilePattern.Pattern.GetLength(1);

            TileVisual[,] oldSection = layer.FindSection(startX, startY, width, height);
            
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Drawn Pattern",
                CanExecute = () => { return item != null && this.view.TilePattern != null && layer != null; },
                Execute = () =>
                {  
                    for(int x = 0; x < width; x++)
                    {
                        for(int y = 0; y < height; y++)
                        {
                            //layer.Columns[x + startX].Rows[y + startY].TilesetIndex = pattern.Pattern[x, y];
                            //layer.Columns[x + startX].Rows[y + startY].TilesetName = pattern.Tileset.TextureName;

                            TileVisual tile = layer.GetTile(x + startX, y + startY);

                            if (tile != null)
                            {
                                tile.TilesetIndex = pattern.Pattern[x, y];
                                tile.TilesetName = pattern.Tileset.TextureName;
                            }
                        }
                    }
                },
                UnExecute = () =>
                {
                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            TileVisual tile = layer.GetTile(x + startX, y + startY);
                            tile.TilesetIndex = oldSection[x, y].TilesetIndex;
                            tile.TilesetName = oldSection[x, y].TilesetName;
                        }
                    }
                }
            }, true, item.ClassName());
        }

        public void OnEvent(OnEraseModeMouseClicked item)
        {
            Layer<TileVisual> layer = this.view.Tilemap.FindLayerByIndex(this.view.TilemapLayersListBox.SelectedIndex);
                       
            if (layer == null)
                return;
                        
            List<Tuple<Tuple<int, int>, TileVisual>> previousTiles = new List<Tuple<Tuple<int,int>,TileVisual>>();
            item.Positions.ForEach(pos =>
            {
                Point coordinates = MathExtension.IsoPixelsToCoordinate(pos, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight);

                TileVisual tile = layer.GetTile(coordinates.X, coordinates.Y);

                if (tile != null)
                {
                    previousTiles.Add(new Tuple<Tuple<int, int>, TileVisual>(new Tuple<int, int>(coordinates.X, coordinates.Y), new TileVisual()
                        {
                            Description = tile.Description,
                            Height = tile.Height,
                            ID = tile.ID,
                            Name = tile.Name,
                            TilesetIndex = tile.TilesetIndex,
                            TilesetName = tile.TilesetName,
                        }));
                }
            });

            commandManager.ExecuteCommand(new Command()
            {
                Name = "Erased Tiles",
                CanExecute = () => { return item != null && layer != null && previousTiles.Count > 0; },
                Execute = () =>
                {
                    item.Positions.ForEach(pos =>
                    {
                        Point coord = MathExtension.IsoPixelsToCoordinate(pos, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight);

                        TileVisual tile = layer.GetTile(coord.X, coord.Y);

                        if (tile != null)
                        {
                            tile.TilesetIndex = -1;
                            tile.TilesetName = string.Empty;
                        }
                    });
                },
                UnExecute = () =>
                {
                    previousTiles.ForEach(t =>
                    {
                        int x = t.Item1.Item1;
                        int y = t.Item1.Item2;

                        TileVisual tile = layer.GetTile(x, y);

                        if(tile != null)
                        {
                            tile.TilesetIndex = t.Item2.TilesetIndex;
                            tile.TilesetName = t.Item2.TilesetName;
                        }
                    });
                }
            }, true, item.ClassName());
        }

        public void OnEvent(OnTilePatternGenerated item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Pattern Created",
                CanExecute = () => { return item != null && item.TilePattern != null; },
                Execute = () =>
                {
                    this.view.TilePattern = item.TilePattern;
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnTilemapGridClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Toggled Grid",
                CanExecute = () => { return item != null; },
                Execute = () =>
                {
                    switch (item.ToggleState)
                    {
                        case ToggleState.Off:
                            this.view.Tilemap.IsGridVisible = false;
                            break;
                        case ToggleState.On:
                            this.view.Tilemap.IsGridVisible = true;
                            break;
                        case ToggleState.Indeterminate:
                            break;
                    }
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnTilemapDrawClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Draw Mode Enabled",
                CanExecute = () => { return item != null; },
                Execute = () =>
                {
                    this.view.TilemapState = Enums.TilemapStates.Draw;
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnTilemapSelectionBoxClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Selection Mode Enabled",
                CanExecute = () => { return item != null; },
                Execute = () =>
                {
                    this.view.TilemapState = Enums.TilemapStates.Selection;
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnRenameTilemapLayer item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Renamed Layer",
                CanExecute = () => { return item != null && item.Item != null && this.view.Tilemap.FindTilemapLayers(l => l.Name == item.Item.Text).FirstOrDefault() != null; },
                Execute = () =>
                {
                    ListItemRenameView renameView = new ListItemRenameView(item.Item.Text);

                    if(renameView.ShowDialog() == DialogResult.OK)
                    {
                        string layerName = renameView.ItemValue;

                        Layer<TileVisual> layer = this.view.Tilemap.FindTilemapLayers(l => l.Name == item.Item.Text).FirstOrDefault();

                        if (string.IsNullOrEmpty(layerName))
                            return;

                        layer.Name = layerName;
                        item.Item.Text = layerName;
                    }
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnMoveTilemapLayerDown item)
        {
            string name = item.ClassName();

            int index = this.view.TilemapLayersListBox.SelectedIndex;

            commandManager.ExecuteCommand(new Command()
            {
                Name = name,
                CanExecute = () => { return item != null && item.Item != null && index >= 0 && index + 1 >= this.view.TilemapLayersListBox.Items.Count && index >= this.view.TilemapLayersListBox.Items.Count; },
                Execute = () =>
                {
                    this.view.TilemapLayersListBox.Items.Swap(index, index + 1);
                    this.view.Tilemap.MoveLayerDown(index);
                },
                UnExecute = () => { },
            }, false, name);
        }

        public void OnEvent(OnMoveTilemapLayerUp item)
        {
            string name = item.ClassName();

            int index = this.view.TilemapLayersListBox.SelectedIndex;

            commandManager.ExecuteCommand(new Command()
            {
                Name = name,
                CanExecute = () => { return item != null && item.Item != null && index >= 0 && index - 1 >= 0; },
                Execute = () =>
                {
                    this.view.TilemapLayersListBox.Items.Swap(index, index - 1);
                    this.view.Tilemap.MoveLayerUp(index);
                },
                UnExecute = () => { },
            }, false, name);
        }

        public void OnEvent(OnRemoveTilemapLayer item)
        {
            string name = item.ClassName();

            commandManager.ExecuteCommand(new Command()
            {
                Name = name,
                CanExecute = () => { return item != null && item.Item != null && (item.Item.Tag as Guid?) != null; },
                Execute = () =>
                {
                    Guid id = (Guid)item.Item.Tag;

                    this.view.Tilemap.RemoveTilemapLayer(id);
                    this.view.TilemapLayersListBox.Items.Remove(item.Item);
                },
                UnExecute = () => { },
            }, false, name);
        }

        public void OnEvent(OnAddTilemapLayer item)
        {
            string name = item.ClassName();

            commandManager.ExecuteCommand(new Command()
            {
                Name = name,
                CanExecute = () => { return true; },
                Execute = () =>
                {
                    Guid id = Guid.NewGuid();

                    this.view.Tilemap.AddTilemapLayer(id, Consts.Editor.TilemapLayerName, string.Empty);
                    this.view.TilemapLayersListBox.Items.Add(new ListViewDataItem() { Text = Consts.Editor.TilemapLayerName, Tag = id });
                },
                UnExecute = () => { },
            }, false, name);
        }

        public void OnEvent(OnRemoveTileset item)
        {
            string name = item.ClassName();

            commandManager.ExecuteCommand(new Command()
            {
                Name = name,
                CanExecute = () => { return item != null && item.Page != null; },
                Execute = () =>
                {
                    DialogResult dialog = RadMessageBox.Show(Consts.AlertMessages.Messages.RemoveTileset, Consts.AlertMessages.Captions.RemoveTileset, MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button2);

                    if (dialog == DialogResult.Yes)
                    {
                        // Get id of tileset
                        Guid tilesetID = this.view.Tilemap.FindTilesets(t => t.TextureName == item.Page.Name).FirstOrDefault().ID;

                        // Remove from model
                        this.view.Tilemap.RemoveTileset(tilesetID);

                        // Remove from toolbox
                        this.view.TilesetPages.Pages.Remove(item.Page);

                        this.view.TilePattern = null;
                    }
                },
                UnExecute = () => { },

            }, false, name);
        }

        public void OnEvent(OnAddTilesetTexture item)
        {
            string name = item.ClassName();

            commandManager.ExecuteCommand(new Command()
            {
                Name = name,
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
                                item.List.Items.Add(fileName);
                            }
                        }
                    }
                },
                UnExecute = () => { },
            }, false, name);
        }

        public void OnEvent(OnSelectTilesetTexture item)
        {
            string name = item.ClassName();

            commandManager.ExecuteCommand(new Command()
            {
                Name = "Added tileset object to tilemap",
                CanExecute = () => { return true; },
                Execute = () =>
                {
                    // Create new tileset
                    Tileset tileset = new Tileset()
                    {
                        ID = Guid.NewGuid(),
                        Name = Path.GetFileNameWithoutExtension(item.FileName),
                        TextureName = item.FileName,
                        Texture = XnaHelper.Instance.LoadTexture(Consts.OscPaths.TilesetTexturesDirectory + @"\" + item.FileName),
                    };

                    this.view.TilesetPages.Pages.Add(new TilesetPage(eventAggregator)
                    {
                        Tileset = tileset,
                        Text = Path.GetFileNameWithoutExtension(item.FileName),
                        Name = item.FileName,
                    });

                    this.view.Tilemap.AddTileset(tileset);
                },
                UnExecute = () => { },
            }, false, name);
        }

        public void OnEvent(OnAddTileset item)
        {
            string name = item.ClassName();

            commandManager.ExecuteCommand(new Command()
            {
                Name = "Opened tileset dialog",
                CanExecute = () => { return true; },
                Execute = () =>
                {
                    TilesetListView dialog = new TilesetListView(eventAggregator);
                    dialog.ShowDialog();
                },
                UnExecute = () => { },
            }, false, name);
        }

        private async void LoadTilemap()
        {
            await Task.Run(() =>
            {
                commandManager.ExecuteCommand(new Command()
                {
                    Name = "Loaded Tilemap",
                    CanExecute = () => { return this.view.Tilemap != null; },
                    Execute = () =>
                    {
                        Tilemap tilemap = this.view.Tilemap;

                        tilemap.FindTilemapLayers(t => { return true; }).ForEach(layer =>
                        {
                            this.view.TilemapLayersListBox.Invoke(new Action(() =>
                            {
                                this.view.TilemapLayersListBox.Items.Add(new ListViewDataItem() { Text = layer.Name, Tag = layer.ID });
                            }));
                        });

                        tilemap.FindTilesets(t => { return true; }).ForEach(tileset =>
                        {
                            this.view.TilesetPages.Invoke(new Action(() =>
                            {
                                this.view.TilesetPages.Pages.Add(new TilesetPage(eventAggregator)
                                {
                                    Tileset = tileset,
                                    Text = tileset.TextureName,
                                    Name = tileset.TextureName,
                                });
                            }));
                        });
                    },
                }, false);
            });
            
        }
    }
}
