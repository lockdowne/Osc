using oEditor.Aggregators;
using oEditor.Views;
using oEngine.Entities;
using oEngine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oEditor.Presenters
{
    public class TilemapPresenter : ISubscriber<OnTilemapDescriptionChanged>,
        ISubscriber<OnTilemapHeightChanged>, ISubscriber<OnTilemapWidthChanged>,
        ISubscriber<OnTilemapMouseDown>, ISubscriber<OnTilemapMouseWheel>,
        ISubscriber<OnTilemapMouseUp>, ISubscriber<OnTilemapMouseMove>,
        ISubscriber<OnTilemapNameChanged>
    {
        private readonly ITilemapToolboxView toolbox;

        private readonly ITilemapDocumentView view;

        private readonly IEventAggregator eventAggregator;
        
        private readonly CommandManager commandManager;

        private readonly Tilemap tilemap;

        public TilemapPresenter(IEventAggregator eventAggregator, ITilemapToolboxView toolbox, ITilemapDocumentView view, Tilemap tilemap)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.Subscribe(this);

            this.toolbox = toolbox;

            this.view = view;

            this.tilemap = tilemap;

            this.commandManager = new CommandManager();
        }
        public void OnEvent(OnTilemapMouseDown e)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void OnEvent(OnTilemapDescriptionChanged e)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void OnEvent(OnTilemapWidthChanged e)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void OnEvent(OnTilemapHeightChanged e)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void OnEvent(OnTilemapMouseMove e)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void OnEvent(OnTilemapMouseUp e)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void OnEvent(OnTilemapMouseWheel e)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void OnEvent(OnTilemapNameChanged e)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
