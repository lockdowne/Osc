using oEditor.Repositories;
using oEditor.Views;
using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using oEngine.Common;
using Microsoft.Xna.Framework.Graphics;
using Telerik.WinControls.UI;

namespace oEditor.Presenters
{
    public class TilemapToolsPresenter
    {
        private readonly ITilemapToolsView view;

        private readonly IRepository<Tilemap> repository;

        private readonly Guid ID;

        public TilemapToolsPresenter(Guid tilemapID, ITilemapToolsView tilemapToolsView, IRepository<Tilemap> tilemapRepository)
        {
            this.view = tilemapToolsView;

            this.repository = tilemapRepository;

            this.ID = tilemapID;

            this.repository.RepositoryChanged += () =>
            {

            };

            this.view.AddLayerClicked += () =>
            {

            };
            
            this.view.DeleteLayerClicked += () =>
            {

            };

            this.view.AddTilesetClicked += () =>
            {
                Tilemap tilemap = tilemapRepository.FindEntities(entity => entity.ID == ID).FirstOrDefault();

                if (tilemap == null)
                    return;

                // Probably should not be undo-able
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files (.png)|*.png";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.Multiselect = false;

                    try
                    {
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            CheckDirectory();

                            string filePath = Path.GetFullPath(openFileDialog.FileName);
                            string fileName = @"\" + Path.GetFileName(filePath);
                            string fileNameNoExtension = Path.GetFileNameWithoutExtension(filePath);

                            if(File.Exists(Consts.OscPaths.TexturesDirectory + fileName))
                            {
                                // Do not create local copy when another image with the same name already exists
                                MainView.ShowMessageBox(Consts.AlertMessages.ImageAlreadyExists, "Error", MessageBoxButtons.OK, Telerik.WinControls.RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                            else
                            {
                                // Create local copy of image
                                File.Copy(filePath, Consts.OscPaths.TexturesDirectory + fileName);
                            }

                            // Create new tileset                         
                            tilemap.AddTileset(new Tileset() { ID = Guid.NewGuid(), Name = fileNameNoExtension, TextureName = fileNameNoExtension });

                            tilemapRepository.SaveEntity(tilemap);
                        }
                    }
                    catch (FileLoadException fileException)
                    {
                        Logger.Log("TilemapToolsPresenter", "AddTilsetClicked", fileException);
                        ConsoleView.WriteLine(fileException.Message);
                    }
                    catch(Exception exception)
                    {
                        Logger.Log("TilemapToolsPresenter", "AddTilsetClicked", exception);
                        ConsoleView.WriteLine(exception.Message);
                    }
                }


                
            };           

            this.view.DeleteTilesetClicked += () =>
            {

            };

            this.view.MoveLayerDownClicked += () =>
            {

            };

            this.view.MoveLayerUpClicked += () =>
            {

            };
        }

        private void CheckDirectory()
        {
            if (!Directory.Exists(Consts.OscPaths.TexturesDirectory))
                Directory.CreateDirectory(Consts.OscPaths.TexturesDirectory);
        }
    }
}
