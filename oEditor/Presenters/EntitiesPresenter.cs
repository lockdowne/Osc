using oEditor.Common;
using oEditor.Repositories;
using oEditor.Views;
using oEngine.Common;
using oEngine.Entities;
using oEngine.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace oEditor.Presenters
{
    public class EntitiesPresenter
    {
        private readonly IEntitiesView view;

        private readonly IRepository<Tilemap> sceneRepository;

        public EntitiesPresenter(IEntitiesView entitiesView, IRepository<Tilemap> sceneRepository)
        {
            this.view = entitiesView;

            this.sceneRepository = sceneRepository;

            this.sceneRepository.RepositoryChanged += () =>
            {
                try
                {
                    // Should refresh individual parts of tree based of repo change
                    RefreshTree();
                }
                catch(Exception exception)
                {
                    ConsoleView.WriteLine(exception.ToString());
                    Logger.Log("EntitiesPresenter", "RepositoryChanged", exception);
                }
            };

            this.view.AddEntityClicked += () =>
            {
                // Check if there is a selected node
                if (view.SelectedNode == null)
                    return;

                // Ensure the node is the parent
                if (view.SelectedNode.RootNode != view.SelectedNode)
                    return;


                switch ((Enums.EditorEntities)view.SelectedNode.Tag)
                {
                    case Enums.EditorEntities.Characters:
                        break;
                    case Enums.EditorEntities.Items:
                        break;
                    case Enums.EditorEntities.Quests:
                        break;
                    case Enums.EditorEntities.Tilemaps:
                        CreateScene();
                        break;
                    case Enums.EditorEntities.Nodes:
                        break;
                }
            };

            this.view.DeleteEntityClicked += () =>
            {
                if (view.SelectedNode == null)
                    return;

                if (view.SelectedNode.RootNode == view.SelectedNode)
                    return;

                switch ((Enums.EditorEntities)view.SelectedNode.Tag)
                {
                    case Enums.EditorEntities.Characters:
                        break;
                    case Enums.EditorEntities.Items:
                        break;
                    case Enums.EditorEntities.Quests:
                        break;
                    case Enums.EditorEntities.Tilemaps:
                        DeleteScene(view.SelectedNode);
                        break;
                    case Enums.EditorEntities.Nodes:
                        break;
                }


            };

            this.view.EditEntityClicked += () =>
            {
                try
                {
                    OpenEntity();
                }
                catch (Exception exception)
                {
                    ConsoleView.WriteLine(exception.ToString());
                    Logger.Log("EntitiesPresenter", "EditEntityClicked", exception);
                }
            };

            this.view.NodeDoubleClicked += () =>
            {
                try
                {
                    OpenEntity();
                }
                catch(Exception exception)
                {
                    ConsoleView.WriteLine(exception.ToString());
                    Logger.Log("EntitiesPresenter", "NodeDoubleClicked", exception);
                }
                
            };

            try
            {
                RefreshTree();
            }
            catch (Exception exception)
            {
                ConsoleView.WriteLine(exception.ToString());
                Logger.Log("EntitiesPresenter", "Constructor", exception);
            }
        }

        private void CreateScene()
        {
            Guid id = Guid.NewGuid();

            ConsoleView.WriteLine(CommandFactory.ExecuteCommand(new Command()
            {
                Name = "Create Empty Scene",
                CanExecute = () =>
                {
                    return true;
                },
                Execute = () =>
                {
                    //view.SelectedNode.Nodes.Add(new RadTreeNode() { Text = "Empty Tilemap", Name = "Tilemap", Value = })
                    Tilemap scene = new Tilemap() { ID = id };
                    scene.Initialize("Empty Scene", string.Empty, Configuration.Settings.TileWidth,
                        Configuration.Settings.TileHeight, Configuration.Settings.SceneWidth, Configuration.Settings.SceneHeight);

                    sceneRepository.SaveEntity(scene);

                    //selectedNode.Nodes.Add(new RadTreeNode() { Text = "Empty Tilemap", Name = "Tilemap", Value = id, Tag = Enums.EditorEntities.Scenes });
                },
                UnExecute = () =>
                {
                    sceneRepository.RemoveEntities(entity => entity.ID == id);
                    //selectedNode.Nodes.FirstOrDefault(node => (Guid)node.Value == id).Remove();
                },
            }));
        }

        private void DeleteScene(RadTreeNode selectedNode)
        {
            // Get dialog result outside command as we dont need a undo/redo calling it
            if (MainView.ShowMessageBox(Consts.AlertMessages.DeleteConfirmation, Consts.AlertMessages.DeleteConfirmationCaption,
                System.Windows.Forms.MessageBoxButtons.YesNo, Telerik.WinControls.RadMessageIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                return;

            Tilemap scene = sceneRepository.FindEntities(x => x.ID == (Guid)selectedNode.Value).FirstOrDefault();

            ConsoleView.WriteLine(CommandFactory.ExecuteCommand(new Command()
            {
                Name = "Delete Scene",
                CanExecute = () =>
                {
                    return (scene != null);
                },
                Execute = () =>
                {
                    sceneRepository.RemoveEntities(entity => entity.ID == scene.ID);
                },
                UnExecute = () =>
                {
                    sceneRepository.SaveEntity(scene);
                },
            }));
        }

        private void RefreshTree()
        {  
            foreach(var node in view.NodeCollection)
            {
                node.Nodes.Clear();

                switch ((Enums.EditorEntities)node.Tag)
                {
                    case Enums.EditorEntities.Characters:
                        break;
                    case Enums.EditorEntities.Items:
                        break;
                    case Enums.EditorEntities.Quests:
                        break;
                    case Enums.EditorEntities.Tilemaps:
                        sceneRepository.FindEntities(x => true).ForEach(entity =>
                        {
                            Console.WriteLine("Debug: " + entity.Name);
                            node.Nodes.Add(new RadTreeNode() { Text = entity.Name, Name = entity.Name, Value = entity.ID, Tag = Enums.EditorEntities.Tilemaps });
                        });                        
                        break;
                    case Enums.EditorEntities.Nodes:
                        break;
                }
            }
        }

        private void OpenEntity()
        {
            RadTreeNode node = view.SelectedNode;

            if (node == null)
                return;

            if (node.RootNode == node)
                return;

            switch ((Enums.EditorEntities)node.Tag)
            {
                case Enums.EditorEntities.Characters:
                    break;
                case Enums.EditorEntities.Items:
                    break;
                case Enums.EditorEntities.Quests:
                    break;
                case Enums.EditorEntities.Tilemaps:                    
                    sceneRepository.OnOpenEntity(sceneRepository.FindEntities(x => x.ID == (Guid)node.Value).FirstOrDefault());
                    break;
                case Enums.EditorEntities.Nodes:
                    break;
            }
        }
    }
}
