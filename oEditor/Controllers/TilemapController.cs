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

namespace oEditor.Controllers
{
    public class TilemapController
    {
        private readonly ITilemapDocumentView view;

        private readonly ICommandManager commandManager;

        private readonly IRepository<Tilemap> repository;

        public TilemapController(ITilemapDocumentView tilemapDocumentView, ICommandManager commandManager, IRepository<Tilemap> tilemapRepository)
        {
            this.view = tilemapDocumentView;

            this.commandManager = commandManager;

            this.repository = tilemapRepository;

            this.Subscribe<OnAddTileset>(async obj =>
            {
                var item = await obj;

                string name = item.ClassName();

                commandManager.ExecuteCommand(new Command()
                {
                    Name = name,
                    CanExecute = () => { return true; },
                    Execute = () =>
                    {
                        TilesetListView dialog = new TilesetListView();
                        dialog.ShowDialog();
                    },
                    UnExecute = () => { },
                }, false, name);

            });

            this.Subscribe<OnSelectTilesetTexture>(async obj =>
            {
                var item = await obj;

                string name = item.ClassName();

                commandManager.ExecuteCommand(new Command()
                {
                    Name = name,
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

                        this.view.TilesetPages.Pages.Add(new TilesetPage()
                        {
                            Tileset = tileset,
                            Text = Path.GetFileNameWithoutExtension(item.FileName),
                            Name = item.FileName,
                        });

                        this.view.Tilemap.AddTileset(tileset);
                    },
                    UnExecute = () => { },
                }, false, name);
            });

            this.Subscribe<OnAddTilesetTexture>(async obj =>
            {
                var item = await obj;

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
            });

            this.Subscribe<OnRemoveTileset>(async obj =>
            {
                var item = await obj;

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
                        }
                    },
                    UnExecute = () => { },

                }, false, name);
            });

            this.Subscribe<OnAddTilemapLayer>(async obj =>
            {
                var item = await obj;

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
            });

            this.Subscribe<OnRemoveTilemapLayer>(async obj =>
            {
                var item = await obj;

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
            });

            this.Subscribe<OnMoveTilemapLayerUp>(async obj =>
            {
                var item = await obj;

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
            });

            this.Subscribe<OnMoveTilemapLayerDown>(async obj =>
            {
                var item = await obj;

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
            });

            this.Subscribe<OnRenameTilemapLayer>(async obj =>
            {
                var item = await obj;

                string name = item.ClassName();

                commandManager.ExecuteCommand(new Command()
                {
                    Name = name,
                    CanExecute = () => { return item != null && item.Item != null && this.view.Tilemap.FindTilemapLayers(l => l.Name == item.Item.Text).FirstOrDefault() != null; },
                    Execute = () =>
                    {
                        ListItemRenameView renameView = new ListItemRenameView(item.Item.Text);

                        if(renameView.ShowDialog() == DialogResult.OK)
                        {
                            string layerName = renameView.Text;
                            
                            Layer<TileVisual> layer = this.view.Tilemap.FindTilemapLayers(l => l.Name == item.Item.Text).FirstOrDefault();

                            if (string.IsNullOrEmpty(layerName))
                                return;

                            layer.Name = layerName;
                            item.Item.Text = layerName;
                        }
                    },
                }, false, name);
            });

            this.Subscribe<OnTilemapSelectionBoxClicked>(async obj =>
            {
                var item = await obj;

                string name = item.ClassName();

                commandManager.ExecuteCommand(new Command()
                {
                    Name = name,
                    CanExecute = () => { return item != null; },
                    Execute = () =>
                    {
                        
                    },
                });
            });

            this.Subscribe<OnTilemapDrawClicked>(async obj =>
            {
                var item = await obj;

                string name = item.ClassName();

                commandManager.ExecuteCommand(new Command()
                {
                    Name = name,
                    CanExecute = () => { return item != null; },
                    Execute = () =>
                    {

                    },
                });
            });
        }
    }
}
