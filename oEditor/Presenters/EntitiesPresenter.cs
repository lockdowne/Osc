using oEditor.Aggregators;
using oEditor.Controls;
using oEditor.Views;
using oEngine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oEditor.Presenters
{
    public class EntitiesPresenter : ISubscriber<OnCreateEmptyTilemap>
    {
        private readonly IEventAggregator eventAggregator;

        private readonly IEntitiesView view;

        public EntitiesPresenter(IEventAggregator eventAggregator, IEntitiesView entitiesView)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.Subscribe(this);

            this.view = entitiesView;
        }

        public void OnEvent(OnCreateEmptyTilemap e)
        {
            try
            {
                EntitiesTilemapNode node = new EntitiesTilemapNode() { Text = "Empty Tilemap", ID = e.ID, ContextMenu = e.Context };

                node.DoubleClicked += () =>
                {
                    // Edit entity
                    //eventAggregator.Publish()
                };


                e.Root.Nodes.Add(node);
            }
            catch(Exception exception)
            {
                Logger.Log("EntitiesPresenter", "OnCreateEmptyTilemap", exception);
            }
        }
    }
}
