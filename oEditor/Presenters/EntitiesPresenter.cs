using oEditor.Common;
using oEditor.Repositories;
using oEditor.Views;
using oEngine.Common;
using oEngine.Entities;
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

        private SceneRepository repo;

        public EntitiesPresenter(IEntitiesView entitiesView)
        {
            this.view = entitiesView;

            repo = new SceneRepository();


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
                    case Enums.EditorEntities.Sprites:
                        break;
                    case Enums.EditorEntities.Items:
                        break;
                    case Enums.EditorEntities.Quests:
                        break;
                    case Enums.EditorEntities.Scenes:
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




            };

            this.view.EditEntityClicked += () =>
            {

            };

            
        }

        private void CreateScene()
        {
            RadTreeNode node = new RadTreeNode() { Text = "Empty Scene", Name = "Scene" };
            //view.SelectedNode.Nodes.Add(new RadTreeNode() { Text = "Empty Scene", Name = "Scene", Value = })
            Scene scene = new Scene();
            scene.Initialize("Empty Scene", string.Empty, Configuration.Settings.TileWidth,
                Configuration.Settings.TileHeight, Configuration.Settings.SceneWidth, Configuration.Settings.SceneHeight);

            // TODO: Save to repo and have scene presenter load new tabbed document window in mainview
            //repo.SaveScene(scene); // Not implemented yet

            // This would be easy just to have main presenter handle all events

            node.Value = scene;

            this.view.SelectedNode.Nodes.Add(node);
        }

        private void CreateSprite()
        {

        }
    }
}
