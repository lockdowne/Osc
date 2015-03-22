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
    public class TilemapPresenter
    {
        private readonly ITilemapView view;

        private readonly IRepository<Tilemap> repository;

        public TilemapPresenter(ITilemapView sceneView, IRepository<Tilemap> sceneRepository)
        {
            this.view = sceneView;

            this.repository = sceneRepository;

            view.TilemapMouseDown += (s, e) =>
            {
               
            };

            view.TilemapMouseMove += (s, e) =>
            {

            };

            view.TilemapMouseUp += (s, e) =>
            {

            };

            view.TilemapMouseWheel += (s, e) =>
            {
                                
            };


        }
    }
}
