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

        private readonly IRepository<Scene> sceneRepository;

        public EntitiesPresenter(IEntitiesView entitiesView, IRepository<Scene> sceneRepository)
        {
            this.view = entitiesView;

            this.sceneRepository = sceneRepository;

            this.sceneRepository.RepositoryChanged += () =>
            {
                RefreshTree();
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
                    case Enums.EditorEntities.Scenes:
                        CreateScene(view.SelectedNode);
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
                    case Enums.EditorEntities.Scenes:
                        DeleteScene(view.SelectedNode);
                        break;
                    case Enums.EditorEntities.Nodes:
                        break;
                }


            };

            this.view.EditEntityClicked += () =>
            {

            };

            this.view.NodeDoubleClicked += () =>
            {
                // Do the same as edit entity
            };
        }

        private void CreateScene(RadTreeNode selectedNode)
        {
            Guid id = Guid.NewGuid();

            ConsoleView.WriteLine(CommandFactory.ExecuteCommand(new Command()
            {
                Name = "Create Scene",
                Description = "Create an empty scene entity",
                CanExecute = () =>
                {
                    return true;
                },
                Execute = () =>
                {
                    //view.SelectedNode.Nodes.Add(new RadTreeNode() { Text = "Empty Scene", Name = "Scene", Value = })
                    Scene scene = new Scene() { ID = id };
                    scene.Initialize("Empty Scene", string.Empty, Configuration.Settings.TileWidth,
                        Configuration.Settings.TileHeight, Configuration.Settings.SceneWidth, Configuration.Settings.SceneHeight);

                    sceneRepository.SaveEntity(scene);

                    selectedNode.Nodes.Add(new RadTreeNode() { Text = "Empty Scene", Name = "Scene", Value = id, Tag = Enums.EditorEntities.Scenes });
                },
                UnExecute = () =>
                {
                    sceneRepository.RemoveEntities(entity => entity.ID == id);
                    selectedNode.Nodes.FirstOrDefault(node => (Guid)node.Value == id).Remove();
                },
            }));
        }

        private void DeleteScene(RadTreeNode selectedNode)
        {
            ConsoleView.WriteLine(CommandFactory.ExecuteCommand(new Command()
                {
                    Name = "Delete Scene",
                    Description = "Deletes selected scene",
                    CanExecute = () =>
                    {
                        // No restrictions currently
                        return true;
                    },
                    Execute = () =>
                    {
                        sceneRepository.RemoveEntities(entity => entity.ID == (Guid)selectedNode.Value);
                        selectedNode.Remove();
                    },
                }));
        }

        private void EditScene(RadTreeNode selectedNode)
        {
            // TODO: create a scene view with the nodes data
        }

        private void CreateSprite()
        {

        }

        private void RefreshTree()
        {
            foreach(var node in view.NodeCollection)
            {
                switch ((Enums.EditorEntities)node.Tag)
                {
                    case Enums.EditorEntities.Characters:
                        break;
                    case Enums.EditorEntities.Items:
                        break;
                    case Enums.EditorEntities.Quests:
                        break;
                    case Enums.EditorEntities.Scenes:
                        sceneRepository.FindEntities(x => true).ForEach(entity =>
                            {
                                node.Nodes.Add(new RadTreeNode() { Text = entity.Name, Name = entity.Name, Value = entity.ID, Tag = Enums.EditorEntities.Scenes });
                            });                        
                        break;
                    case Enums.EditorEntities.Nodes:
                        break;
                }
            }
        }
    }
}
