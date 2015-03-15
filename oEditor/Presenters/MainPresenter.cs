using oEditor.Common;
using oEditor.Views;
using oEngine.Commands;
using oEngine.Common;
using oEngine.Entities;
using oEngine.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView view;

        private EntitiesPresenter entitiesPresenter;

        // TODO: Do dependincy injection to add the presenters view to main
        public MainPresenter(IMainView mainView)
        {
            this.view = mainView;

            EntitiesView entitiesView = new EntitiesView();
            this.entitiesPresenter = new EntitiesPresenter(entitiesView);

            this.view.DockManager.DockControl(entitiesView, DockPosition.Right);


        }
    }
}
