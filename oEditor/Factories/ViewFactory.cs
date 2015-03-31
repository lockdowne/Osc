using oEditor.Aggregators;
using oEditor.Presenters;
using oEditor.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oEditor.Factories
{
    public static class ViewFactory
    {
        public static EntitiesPresenter p;

        public static IEntitiesView CreateEntitiesView(IEventAggregator eventAggregator)
        {
            IEntitiesView view = new EntitiesView(eventAggregator);
            //EntitiesPresenter presenter = new EntitiesPresenter(eventAggregator, view); // Cant do this its disposed
            p = new EntitiesPresenter(eventAggregator, view);

            return view;
        }
    }
}
