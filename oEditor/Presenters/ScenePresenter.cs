using oEditor.Repositories;
using oEditor.Views;
using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oEditor.Presenters
{
    public class ScenePresenter
    {
        private readonly ISceneView view;

        private readonly IRepository<Scene> repository;

        public ScenePresenter(ISceneView sceneView, IRepository<Scene> sceneRepository)
        {
            this.view = sceneView;

            this.repository = sceneRepository;

            view.SceneMouseDown += (s, e) =>
            {
               
            };

            view.SceneMouseMove += (s, e) =>
            {

            };

            view.SceneMouseUp += (s, e) =>
            {

            };

            view.SceneMouseWheel += (s, e) =>
            {
                                
            };
        }
    }
}
