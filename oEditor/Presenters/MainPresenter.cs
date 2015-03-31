using oEditor.Aggregators;
using oEditor.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Presenters 
{
    public class MainPresenter : ISubscriber<OnMainLoaded>
    {
        private readonly IEventAggregator eventAggregator;

        private readonly IMainView view;

        private readonly EntitiesPresenter entitiesPresenter;
        private readonly IEntitiesView entitiesView;

        public MainPresenter(IEventAggregator eventAggregator, IMainView mainView)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.Subscribe(this);

            this.view = mainView;
 
            this.entitiesView = new EntitiesView(eventAggregator);
            this.entitiesPresenter = new EntitiesPresenter(eventAggregator, entitiesView);

            this.view.DockManager.DockWindow((DockWindow)entitiesView, DockPosition.Right);
     
        }
        public void OnEvent(OnMainLoaded e)
        {       
            eventAggregator.Publish(new OnEntitiesViewLoaded() { View = entitiesView });
        }
    }
}
