using Telerik.WinControls.Enumerations;
using Osc.Rotch.Editor.Repositories;
using Osc.Rotch.Editor.Views;
using Osc.Rotch.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osc.Rotch.Engine.Common;
using Osc.Rotch.Editor.Events;
using Osc.Rotch.Engine.Managers;
using System.Windows.Forms;
using System.IO;
using Telerik.WinControls;
using Osc.Rotch.Editor.Controls;
using Telerik.WinControls.UI;
using Osc.Rotch.Editor.Common;
using Osc.Rotch.Engine.Aggregators;
using Osc.Rotch.Engine.Patterns;
using Microsoft.Xna.Framework;

namespace Osc.Rotch.Editor.Controllers
{
    public class TilemapAssetController : IController, ISubscriber<OnAddTileset>, ISubscriber<OnSelectTilesetTexture>,
        ISubscriber<OnAddTilesetTexture>, ISubscriber<OnRemoveTileset>, ISubscriber<OnAddTilemapLayer>, ISubscriber<OnRemoveTilemapLayer>,
        ISubscriber<OnMoveTilemapLayerUp>, ISubscriber<OnMoveTilemapLayerDown>, ISubscriber<OnRenameTilemapLayer>, ISubscriber<OnTilemapSelectionBoxClicked>,
        ISubscriber<OnTilemapDrawClicked>, ISubscriber<OnTilemapGridClicked>, ISubscriber<OnTilePatternGenerated>, ISubscriber<OnDrawModeMouseClicked>,
        ISubscriber<OnEraseModeMouseClicked>, ISubscriber<OnTilemapEraseClicked>, ISubscriber<OnTilemapCollisionClicked>,
        ISubscriber<OnTilemapLayerVisibilityChanged>, ISubscriber<OnTilemapResizeClicked>, ISubscriber<OnTilemapRedoClicked>, ISubscriber<OnTilemapUndoClicked>,
        ISubscriber<OnTilemapCopyClicked>, ISubscriber<OnTilemapCutClicked>, ISubscriber<OnTilemapTruncateClicked>
    {
        private readonly ITilemapAssetDocumentView view;

        private readonly ICommandManager commandManager;

        private readonly IEventAggregator eventAggregator;

        private readonly IRepository<TilemapAsset> repository;
        
        public Guid ID { get; set; }

        public TilemapAssetController(ITilemapAssetDocumentView tilemapDocumentView, ICommandManager commandManager, IEventAggregator eventAggregator, IRepository<TilemapAsset> tilemapAssetRepository)
        {
            this.view = tilemapDocumentView;

            this.commandManager = commandManager;

            this.eventAggregator = eventAggregator;

            this.repository = tilemapAssetRepository;

            this.eventAggregator.Subscribe(this);

            LoadTilemapAsset();
        }

        

        public void OnEvent(OnTilemapTruncateClicked item)
        {
            List<Layer<TileVisual>> previousAsset = new List<Layer<TileVisual>>(this.view.TilemapAssetEditor.Asset.VisualLayers);
            int previousWidth = this.view.TilemapAssetEditor.Asset.VisualLayers.FirstOrDefault() == null ? Configuration.Settings.SceneWidth : this.view.TilemapAssetEditor.Asset.VisualLayers.FirstOrDefault().Width;
            int previousHeight = this.view.TilemapAssetEditor.Asset.VisualLayers.FirstOrDefault() == null ? Configuration.Settings.SceneHeight : this.view.TilemapAssetEditor.Asset.VisualLayers.FirstOrDefault().Height;

            commandManager.ExecuteCommand(new Command()
            {
                Name = "Truncated",
                CanExecute = () => { return item != null; },
                Execute = () =>
                {
                    this.view.TilemapAssetEditor.Truncate();
                    this.RefreshTilemapLayersControl();
                },
                UnExecute = () =>
                {
                    this.view.TilemapAssetEditor.Asset.VisualLayers.Clear();
                    this.view.TilemapAssetEditor.Asset.VisualLayers = new List<Layer<TileVisual>>(previousAsset);
                    this.view.TilemapAssetEditor.Width = previousWidth;
                    this.view.TilemapAssetEditor.Height = previousHeight;
                    this.RefreshTilemapLayersControl();
                },
            }, true, item.ClassName());
        }

        public void OnEvent(OnTilemapCopyClicked item)
        {
         
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Copied",
                CanExecute = () => { return item != null && (this.view.SelectedTilemapLayer.Tag as Guid?) != null && this.view.SelectionBoxStart != null && this.view.SelectionBoxEnd != null; },
                Execute = () =>
                {
                    Guid id = (Guid)this.view.SelectedTilemapLayer.Tag;

                    Layer<TileVisual> layer = this.view.TilemapAssetEditor.FindTilemapLayers(t => t.ID == id).FirstOrDefault();

                    Vector2 startPosition = this.view.SelectionBoxStart.Value;
                    Vector2 endPosition = this.view.SelectionBoxEnd.Value;

                    TilePattern pattern = new TilePattern()
                    {
                        Tint = Color.White,
                        Alpha = Configuration.Settings.TilePatternOpacity,
                        Origin = Vector2.Zero,
                        TileWidth = Configuration.Settings.TileWidth,
                        TileHeight = Configuration.Settings.TileHeight,
                        Pattern = layer,
                        Position = Vector2.Zero,
                        Tilesets = new List<Tileset>(this.view.TilemapAssetEditor.Tilesets),
                    };

                    Layer<TileVisual> newLayer = new Layer<TileVisual>();
                    newLayer.Initialize(layer.Width, layer.Height);

                    MathExtension.CoordSelector(startPosition, endPosition, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).ForEach(point =>
                    {
                        if(MathExtension.CoordinateWithinBounds(point.X, point.Y, layer.Width, layer.Height))
                        {
                            newLayer.Columns[point.X].Rows[point.Y].TilesetIndex = layer.Columns[point.X].Rows[point.Y].TilesetIndex;
                            newLayer.Columns[point.X].Rows[point.Y].TilesetName = layer.Columns[point.X].Rows[point.Y].TilesetName;
                        }
                    });

                    pattern.Pattern = MathExtension.Truncate(newLayer);

                    this.view.TilePattern = pattern;
                    
                   // layer.FindSection()

                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnTilemapCutClicked item)
        {
            List<Layer<TileVisual>> previousAsset = Serializer.Clone<List<Layer<TileVisual>>>(this.view.TilemapAssetEditor.Asset.VisualLayers);
            int previousWidth = this.view.TilemapAssetEditor.Asset.VisualLayers.FirstOrDefault() == null ? Configuration.Settings.SceneWidth : this.view.TilemapAssetEditor.Asset.VisualLayers.FirstOrDefault().Width;
            int previousHeight = this.view.TilemapAssetEditor.Asset.VisualLayers.FirstOrDefault() == null ? Configuration.Settings.SceneHeight : this.view.TilemapAssetEditor.Asset.VisualLayers.FirstOrDefault().Height;

            commandManager.ExecuteCommand(new Command()
            {
                Name = "Cut",
                CanExecute = () => { return item != null && (this.view.SelectedTilemapLayer.Tag as Guid?) != null && this.view.SelectionBoxStart != null && this.view.SelectionBoxEnd != null; },
                Execute = () =>
                {
                    Guid id = (Guid)this.view.SelectedTilemapLayer.Tag;

                    Layer<TileVisual> layer = this.view.TilemapAssetEditor.FindTilemapLayers(t => t.ID == id).FirstOrDefault();

                    Vector2 startPosition = this.view.SelectionBoxStart.Value;
                    Vector2 endPosition = this.view.SelectionBoxEnd.Value;

                    TilePattern pattern = new TilePattern()
                    {
                        Tint = Color.White,
                        Alpha = Configuration.Settings.TilePatternOpacity,
                        Origin = Vector2.Zero,
                        TileWidth = Configuration.Settings.TileWidth,
                        TileHeight = Configuration.Settings.TileHeight,
                        Pattern = layer,
                        Position = Vector2.Zero,
                        Tilesets = new List<Tileset>(this.view.TilemapAssetEditor.Tilesets),
                    };

                    Layer<TileVisual> newLayer = new Layer<TileVisual>();
                    newLayer.Initialize(layer.Width, layer.Height);

                    MathExtension.CoordSelector(startPosition, endPosition, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).ForEach(point =>
                    {
                        if (MathExtension.CoordinateWithinBounds(point.X, point.Y, layer.Width, layer.Height))
                        {
                            newLayer.Columns[point.X].Rows[point.Y].TilesetIndex = layer.Columns[point.X].Rows[point.Y].TilesetIndex;
                            newLayer.Columns[point.X].Rows[point.Y].TilesetName = layer.Columns[point.X].Rows[point.Y].TilesetName;

                            layer.Columns[point.X].Rows[point.Y].TilesetIndex = -1;
                            layer.Columns[point.X].Rows[point.Y].TilesetName = string.Empty;
                        }
                    });

                    pattern.Pattern = MathExtension.Truncate(newLayer);

                    this.view.TilePattern = pattern;

                    // layer.FindSection()

                },
                UnExecute = () =>
                {
                    this.view.TilemapAssetEditor.Asset.VisualLayers.Clear();
                    this.view.TilemapAssetEditor.Asset.VisualLayers = new List<Layer<TileVisual>>(previousAsset);
                    this.view.TilemapAssetEditor.Width = previousWidth;
                    this.view.TilemapAssetEditor.Height = previousHeight;
                    this.RefreshTilemapLayersControl();
                },
            }, true, item.ClassName());
        }

        public void OnEvent(OnTilemapUndoClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Undo",
                CanExecute = () => { return item != null && commandManager.CanUndo; },
                Execute = () =>
                {
                    commandManager.Undo();
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnTilemapRedoClicked item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Redo",
                CanExecute = () => { return item != null && commandManager.CanRedo; },
                Execute = () =>
                {
                    commandManager.Redo();
                },
            }, false, item.ClassName());
        }

        public void OnEvent(OnTilemapResizeClicked item)
        {
            int previousWidth = this.view.TilemapAssetEditor.Width;
            int previousHeight = this.view.TilemapAssetEditor.Height;

            TilemapResizeView resize = new TilemapResizeView(this.view.TilemapAssetEditor.Width, this.view.TilemapAssetEditor.Height);

            if (resize.ShowDialog() == DialogResult.OK)
            {
                commandManager.ExecuteCommand(new Command()
                {
                    Name = "Tilemap resized",
                    CanExecute = () => { return item != null && (previousWidth != resize.TilemapWidth || previousHeight != resize.TilemapHeight); },
                    Execute = () =>
                    {
                        this.view.TilemapAssetEditor.FindTilemapLayers(t => { return true; }).ForEach(layer =>
                        {
                            layer.Resize(resize.TilemapWidth, resize.TilemapHeight);
                        });

                        //this.view.TilemapAssetEditor.CollisionLayer.Resize(resize.TilemapWidth, resize.TilemapHeight);

                        this.view.TilemapAssetEditor.Width = resize.TilemapWidth;
                        this.view.TilemapAssetEditor.Height = resize.TilemapHeight;
                    },
                    UnExecute = () =>
                    {
                        // TODO: undo resize
                    },
                }, true, item.ClassName());
            }
        }

        public void OnEvent(OnTilemapLayerVisibilityChanged item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Tilemap Layer Visiblity Toggled",
                CanExecute = () => { return item != null && item.Item != null; },
                Execute = () =>
                {
                    Guid id = (Guid)item.Item.Tag;

                    if (item.Item.CheckState == ToggleState.On)
                    {
                        this.view.TilemapAssetEditor.FindTilemapLayers(l => l.ID == id).FirstOrDefault().IsVisble = true;
                    }
                    else if (item.Item.CheckState == ToggleState.Off)
                    {
                        this.view.TilemapAssetEditor.FindTilemapLayers(l => l.ID == id).FirstOrDefault().IsVisble = false;
                    }
                },
            }, false, item.ClassName());
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

        public void OnEvent(OnDrawModeMouseClicked item)
        {
            int index = this.view.TilemapLayersListBox.SelectedIndex;

            Layer<TileVisual> layer = this.view.TilemapAssetEditor.FindLayerByIndex(index);
            Layer<TileVisual> previousLayer = Serializer.Clone<Layer<TileVisual>>(layer);

            TilePattern pattern = this.view.TilePattern;

            if (layer == null || pattern == null)
                return;

            Point coordinates = MathExtension.IsoPixelsToCoordinate(this.view.TilePattern.Position, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight);

            int startX = coordinates.X;
            int startY = coordinates.Y;

            int width = this.view.TilePattern.Pattern.Width;
            int height = this.view.TilePattern.Pattern.Height;

            TileVisual[,] oldSection = layer.FindSection(startX, startY, width, height);

            commandManager.ExecuteCommand(new Command()
            {
                Name = "Drawn Pattern",
                CanExecute = () => { return item != null && this.view.TilePattern != null && layer != null; },
                Execute = () =>
                {
                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            TileVisual tile = layer.GetTile(x + startX, y + startY);

                            if (tile != null)
                            {
                                tile.TilesetIndex = pattern.Pattern.Columns[x].Rows[y].TilesetIndex;
                                tile.TilesetName = pattern.Pattern.Columns[x].Rows[y].TilesetName;
                            }
                        }
                    }
                },
                UnExecute = () =>
                {

                    Layer<TileVisual> newLayer = this.view.TilemapAssetEditor.FindLayerByIndex(index);

                    for(int x = 0; x < previousLayer.Width; x++)
                    {
                        for (int y = 0; y < previousLayer.Height; y++)
                        {
                            newLayer.Columns[x].Rows[y].TilesetIndex = previousLayer.Columns[x].Rows[y].TilesetIndex;
                            newLayer.Columns[x].Rows[y].TilesetName = previousLayer.Columns[x].Rows[y].TilesetName;
                        }
                    }

                    this.view.TilemapAssetEditor.Width = previousLayer.Width;
                    this.view.TilemapAssetEditor.Height = previousLayer.Height;
                    //this.RefreshTilemapLayersControl();
                }
            }, true, item.ClassName());
        }

        public void OnEvent(OnEraseModeMouseClicked item)
        {
            int index = this.view.TilemapLayersListBox.SelectedIndex;

            Layer<TileVisual> layer = this.view.TilemapAssetEditor.FindLayerByIndex(index);

            Layer<TileVisual> previousLayer = Serializer.Clone<Layer<TileVisual>>(layer);

            if (layer == null)
                return;           

            commandManager.ExecuteCommand(new Command()
            {
                Name = "Erased Tiles",
                CanExecute = () => { return item != null && layer != null; },
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
                    Layer<TileVisual> newLayer = this.view.TilemapAssetEditor.FindLayerByIndex(index);

                    for (int x = 0; x < previousLayer.Width; x++)
                    {
                        for (int y = 0; y < previousLayer.Height; y++)
                        {
                            newLayer.Columns[x].Rows[y].TilesetIndex = previousLayer.Columns[x].Rows[y].TilesetIndex;
                            newLayer.Columns[x].Rows[y].TilesetName = previousLayer.Columns[x].Rows[y].TilesetName;
                        }
                    }

                    this.view.TilemapAssetEditor.Width = previousLayer.Width;
                    this.view.TilemapAssetEditor.Height = previousLayer.Height;
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
                            this.view.TilemapAssetEditor.IsGridVisible = false;
                            break;
                        case ToggleState.On:
                            this.view.TilemapAssetEditor.IsGridVisible = true;
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
                CanExecute = () => { return item != null && item.Item != null && this.view.TilemapAssetEditor.FindTilemapLayers(l => l.Name == item.Item.Text).FirstOrDefault() != null; },
                Execute = () =>
                {
                    ListItemRenameView renameView = new ListItemRenameView(item.Item.Text);

                    if (renameView.ShowDialog() == DialogResult.OK)
                    {
                        string layerName = renameView.ItemValue;

                        Layer<TileVisual> layer = this.view.TilemapAssetEditor.FindTilemapLayers(l => l.Name == item.Item.Text).FirstOrDefault();

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
            Guid id = (Guid)this.view.SelectedTilemapLayer.Tag;

            Layer<TileVisual> layer = this.view.TilemapAssetEditor.FindTilemapLayers(l => l.ID == id).FirstOrDefault();

            int index = this.view.TilemapAssetEditor.FindLayerIndex(layer);

            commandManager.ExecuteCommand(new Command()
            {
                Name = "Moved Layer Down",
                CanExecute = () => { return item != null && item.Item != null && this.view.SelectedTilemapLayer != null && layer != null; },
                Execute = () =>
                {
                  

                    //this.view.TilemapLayersListBox.Items.Swap(index, index + 1);
                    this.view.TilemapAssetEditor.MoveLayerDown(index);

                    this.RefreshTilemapLayersControl();
                },
                UnExecute = () =>
                {
                    this.view.TilemapAssetEditor.MoveLayerUp(index + 1);

                    this.RefreshTilemapLayersControl();
                },
            }, true, item.ClassName());
        }

        public void OnEvent(OnMoveTilemapLayerUp item)
        {
            Guid id = (Guid)this.view.SelectedTilemapLayer.Tag;

            Layer<TileVisual> layer = this.view.TilemapAssetEditor.FindTilemapLayers(l => l.ID == id).FirstOrDefault();

            int index = this.view.TilemapAssetEditor.FindLayerIndex(layer);

            commandManager.ExecuteCommand(new Command()
            {
                Name = "Moved Layer Up",
                CanExecute = () => { return item != null && item.Item != null && this.view.SelectedTilemapLayer != null && layer != null; },
                Execute = () =>
                {
            

                    //this.view.TilemapLayersListBox.Items.Swap(index, index - 1);
                    this.view.TilemapAssetEditor.MoveLayerUp(index);

                    this.RefreshTilemapLayersControl();
                },
                UnExecute = () =>
                {
                    this.view.TilemapAssetEditor.MoveLayerDown(index - 1);

                    this.RefreshTilemapLayersControl();
                },
            }, true, item.ClassName());
        }

        public void OnEvent(OnRemoveTilemapLayer item)
        {
            Layer<TileVisual> previousLayer = this.view.TilemapAssetEditor.FindTilemapLayers(t => t.ID == (Guid)item.Item.Tag).FirstOrDefault();
   
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Removed Tilemap Layer",
                CanExecute = () => { return item != null && item.Item != null && (item.Item.Tag as Guid?) != null; },
                Execute = () =>
                {
                    Guid id = (Guid)item.Item.Tag;

                    this.view.TilemapAssetEditor.RemoveTilemapLayer(id);
                    this.view.TilemapLayersListBox.Items.Remove(item.Item);
                },
                UnExecute = () => { },
            }, false, item.ClassName());
        }

        public void OnEvent(OnAddTilemapLayer item)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Added Tilemap Layer",
                CanExecute = () => { return true; },
                Execute = () =>
                {
                    Guid id = Guid.NewGuid();

                    this.view.TilemapAssetEditor.AddTilemapLayer(id, Consts.Editor.TilemapLayerName, string.Empty);
                    this.view.TilemapLayersListBox.Items.Add(new ListViewDataItem() { Text = Consts.Editor.TilemapLayerName, Tag = id, CheckState = ToggleState.On });
                },
                UnExecute = () => { },
            }, false, item.ClassName());
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
                        Tileset tileset = this.view.TilemapAssetEditor.FindTilesets(t => t.TextureName == item.Page.Name).FirstOrDefault();

                        TilemapAssetEditor tilemap = this.view.TilemapAssetEditor;
                        
                        // Remove from model
                        this.view.TilemapAssetEditor.RemoveTileset(tileset.ID);

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
                            if (!Directory.Exists(Consts.OscPaths.TexturesDirectory))
                            {
                                Directory.CreateDirectory(Consts.OscPaths.TexturesDirectory);
                            }


                            if (File.Exists(Consts.OscPaths.TexturesDirectory + @"\" + fileName))
                            {
                                RadMessageBox.Show(Consts.AlertMessages.Messages.ImageAlreadyExists, Consts.AlertMessages.Captions.ImageAlreadyExists, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            }
                            else
                            {
                                // Copy file into osc path
                                File.Copy(filePath, Consts.OscPaths.TexturesDirectory + @"\" + fileName);
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
                        Texture = XnaHelper.Instance.LoadTexture(Consts.OscPaths.TexturesDirectory + @"\" + item.FileName),
                    };

                    this.view.TilesetPages.Pages.Add(new TilesetPage(eventAggregator)
                    {
                        Tileset = tileset,
                        Text = Path.GetFileNameWithoutExtension(item.FileName),
                        Name = item.FileName,
                    });

                    this.view.TilemapAssetEditor.AddTileset(tileset);
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

        private void LoadTilemapAsset()
        {

            commandManager.ExecuteCommand(new Command()
            {
                Name = "Loaded Tilemap Asset",
                CanExecute = () => { return this.view.TilemapAssetEditor != null; },
                Execute = () =>
                {
                    TilemapAssetEditor tilemap = this.view.TilemapAssetEditor;
                    tilemap.Width = tilemap.Asset.VisualLayers.FirstOrDefault() == null ? Configuration.Settings.SceneWidth : tilemap.Asset.VisualLayers.FirstOrDefault().Width;
                    tilemap.Height = tilemap.Asset.VisualLayers.FirstOrDefault() == null ? Configuration.Settings.SceneHeight : tilemap.Asset.VisualLayers.FirstOrDefault().Height;
                    tilemap.IsGridVisible = true;
                    tilemap.TileHeight = Configuration.Settings.TileHeight;
                    tilemap.TileWidth = Configuration.Settings.TileWidth;

                    List<string> tilesetNames = new List<string>();

                    tilemap.Asset.VisualLayers.ForEach(layer =>
                    {
                        int index = tilemap.FindLayerIndex(layer);

                        this.view.TilemapLayersListBox.Items.Insert(index, new ListViewDataItem() { Text = layer.Name, Tag = layer.ID, CheckState = ToggleState.On });

                        layer.IsVisble = true;

                        // Iterate through layer to find needed tileset images
                        for(int x = 0; x < layer.Width; x++)
                        {
                            for(int y = 0; y < layer.Height; y++)
                            {
                                TileVisual tile = layer.Columns[x].Rows[y];
                                
                                if(!string.IsNullOrEmpty(tile.TilesetName))
                                {
                                    if (!tilesetNames.Contains(tile.TilesetName))
                                        tilesetNames.Add(tile.TilesetName);
                                }
                            }
                        }
                    });

                    tilesetNames.ForEach(str =>
                    {
                        Tileset tileset = new Tileset()
                        {
                            ID = Guid.NewGuid(),
                            Name = Path.GetFileNameWithoutExtension(str),
                            TextureName = str,
                            Texture = XnaHelper.Instance.LoadTexture(Consts.OscPaths.TexturesDirectory + @"\" + str),
                        };

                        this.view.TilesetPages.Pages.Add(new TilesetPage(eventAggregator)
                        {
                            Tileset = tileset,
                            Text = Path.GetFileNameWithoutExtension(str),
                            Name = str,
                        });

                        this.view.TilemapAssetEditor.AddTileset(tileset);
                    });
                },
            }, false);


        }
       

        private void RefreshTilemapLayersControl()
        {
            this.view.TilemapLayersListBox.Items.Clear();

            TilemapAssetEditor tilemap = this.view.TilemapAssetEditor;

            tilemap.FindTilemapLayers(t => { return true; }).ForEach(layer =>
            {
                int index = tilemap.FindLayerIndex(layer);

                this.view.TilemapLayersListBox.Items.Insert(index, new ListViewDataItem() { Text = layer.Name, Tag = layer.ID, CheckState = ToggleState.On });

                layer.IsVisble = true;

            });
        }
    }
}
