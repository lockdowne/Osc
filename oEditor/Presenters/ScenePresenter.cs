using oEditor.Views;
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

        public ScenePresenter(ISceneView sceneView)
        {
            this.view = sceneView;           

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
