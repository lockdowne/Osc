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
    public class TilemapController : IController,      
        ISubscriber<OnTilemapSelectionBoxClicked>,
        ISubscriber<OnTilemapDrawClicked>, ISubscriber<OnTilemapGridClicked>, ISubscriber<OnTilePatternGenerated>, ISubscriber<OnDrawModeMouseClicked>,
        ISubscriber<OnEraseModeMouseClicked>, ISubscriber<OnCollisionModeMouseClicked>, ISubscriber<OnTilemapEraseClicked>, ISubscriber<OnTilemapCollisionClicked>,
        ISubscriber<OnTilemapLayerVisibilityChanged>, ISubscriber<OnTilemapResizeClicked>, ISubscriber<OnTilemapRedoClicked>, ISubscriber<OnTilemapUndoClicked>
    {
        private readonly ITilemapDocumentView view;

        private readonly ICommandManager commandManager;

        private readonly IEventAggregator eventAggregator;

        private readonly IRepository<Tilemap> tilemapRepository;
        private readonly IRepository<TilemapAsset> tilemapAssetRepository;

        public TilemapController(ITilemapDocumentView tilemapDocumentView, ICommandManager commandManager, IEventAggregator eventAggregator, IRepository<Tilemap> tilemapRepository, IRepository<TilemapAsset> tilemapAssetRepository)
        {
            this.view = tilemapDocumentView;

            this.commandManager = commandManager;

            this.eventAggregator = eventAggregator;

            this.tilemapRepository = tilemapRepository;
            this.tilemapAssetRepository = tilemapAssetRepository;

            this.eventAggregator.Subscribe(this);

            LoadTilemap();
        }

        public Guid ID { get; set; }

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
            int previousWidth = this.view.Tilemap.Width;
            int previousHeight = this.view.Tilemap.Height;

            TilemapResizeView resize = new TilemapResizeView(this.view.Tilemap.Width, this.view.Tilemap.Height);

            if (resize.ShowDialog() == DialogResult.OK)
            {
                commandManager.ExecuteCommand(new Command()
                {
                    Name = "Tilemap resized",
                    CanExecute = () => { return item != null && (previousWidth != resize.TilemapWidth || previousHeight != resize.TilemapHeight); },
                    Execute = () =>
                    {
                        this.view.Tilemap.CollisionLayer.Resize(resize.TilemapWidth, resize.TilemapHeight);

                        this.view.Tilemap.Width = resize.TilemapWidth;
                        this.view.Tilemap.Height = resize.TilemapHeight;

                        this.view.Tilemap.GroundLayer.Resize(resize.TilemapWidth, resize.TilemapHeight);
                        this.view.Tilemap.ObjectLayer.Resize(resize.TilemapWidth, resize.TilemapHeight);
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
                        if(this.view.Tilemap.GroundLayer.ID == id)
                        {
                            this.view.Tilemap.GroundLayer.IsVisble = true;
                        }
                        else if (this.view.Tilemap.ObjectLayer.ID == id)
                        {
                            this.view.Tilemap.ObjectLayer.IsVisble = true;
                        }
                    }
                    else if(item.Item.CheckState == ToggleState.Off)
                    {
                        if (this.view.Tilemap.GroundLayer.ID == id)
                        {
                            this.view.Tilemap.GroundLayer.IsVisble = false;
                        }
                        else if (this.view.Tilemap.ObjectLayer.ID == id)
                        {
                            this.view.Tilemap.ObjectLayer.IsVisble = false;
                        }
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
            var node = this.view.TilemapLayersListBox.SelectedItem;

            commandManager.ExecuteCommand(new Command()
            {
                Name = "Drawn Tilemap Asset",
                CanExecute = () => { return item != null && this.view.TilePattern != null  && tilemapAssetRepository.Find(t => t.ID == this.view.TilePattern.ID) != null && node != null; },
                Execute = () =>
                {
                    TilemapAsset asset = tilemapAssetRepository.Find(t => t.ID == this.view.TilePattern.ID);

                    this.view.TilePattern.FindAllTilesetNames().ForEach(t =>
                    {
                        AddTileset(t);
                    });

                    Layer<TilemapAsset> layer = null;

                    if(this.view.Tilemap.GroundLayer.ID.ToString() == node.Tag.ToString())
                    {
                        layer = this.view.Tilemap.GroundLayer;
                    }
                    else if(this.view.Tilemap.ObjectLayer.ID.ToString() == node.Tag.ToString())
                    {
                        layer = this.view.Tilemap.ObjectLayer;
                    }
                    // Invert Camera
                    Point coordinate = MathExtension.IsoPixelsToCoordinate(this.view.TilePattern.Position, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight);

                    if(MathExtension.CoordinateWithinBounds(coordinate.X, coordinate.Y, layer.Width, layer.Height))
                    {
                        layer.Columns[coordinate.X].Rows[coordinate.Y] = asset;
                    }
                },
                UnExecute = () =>
                {

                }
            }, true, item.ClassName());
        }

        public void OnEvent(OnEraseModeMouseClicked item)
        {
            /*Layer<TileVisual> layer = this.view.Tilemap.FindLayerByIndex(this.view.TilemapLayersListBox.SelectedIndex);
                       
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
            }, true, item.ClassName());*/
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

        public void ApplyTilePattern(TilePattern pattern)
        {
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Pattern Changed",
                CanExecute = () => { return pattern != null && pattern.Pattern != null && pattern.Pattern.Any(); },
                Execute = () =>
                {
                    this.view.TilePattern = pattern;
                },
            }, false);
        }

        private void LoadTilemap()
        {
            
            commandManager.ExecuteCommand(new Command()
            {
                Name = "Loaded Tilemap",
                CanExecute = () => { return this.view.Tilemap != null; },
                Execute = () =>
                {
                    Tilemap tilemap = this.view.Tilemap;
                   
                    this.view.TilemapLayersListBox.Items.Insert(this.view.TilemapLayersListBox.Items.Count, new ListViewDataItem() { Text = tilemap.GroundLayer.Name, Tag = tilemap.GroundLayer.ID, CheckState = ToggleState.On });
                    this.view.TilemapLayersListBox.Items.Insert(this.view.TilemapLayersListBox.Items.Count, new ListViewDataItem() { Text = tilemap.ObjectLayer.Name, Tag = tilemap.ObjectLayer.ID, CheckState = ToggleState.On });
                    //tilemap.FindTilesets(t => { return true; }).ForEach(tileset =>
                    //{
                           
                    //        this.view.TilesetPages.Pages.Add(new TilesetPage(eventAggregator)
                    //        {
                    //            Tileset = tileset,
                    //            Text = tileset.TextureName,
                    //            Name = tileset.TextureName,
                    //        });
                          
                    //});
                },
            }, false);
           
            
        }

        private void AddTileset(string name)
        {
            if (view.Tilemap.FindTilesets(t => t.TextureName == name).Any())
                return;

            Tileset tileset = new Tileset()
            {
                ID = Guid.NewGuid(),
                Name = Path.GetFileNameWithoutExtension(name),
                TextureName = name,
                Texture = XnaHelper.Instance.LoadTexture(Consts.OscPaths.TexturesDirectory + @"\" + name),
            };

            this.view.Tilemap.AddTileset(tileset);
        }
    }
}
