using oEditor.Aggregators;
using oEditor.Repositories;
using oEditor.Views;
using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace oEditor.Presenters
{
    public class ApplicationPresenter
    {
        private readonly IEventAggregator eventAggregator;

        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme theme;

        public ApplicationPresenter()
        {            
            // Set main theme for all telerik controls
            theme = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark";

            // Intialize
            eventAggregator = new EventAggregator();

            // Create main view
            IMainView mainView = new MainView(eventAggregator);
            MainPresenter mainPresenter = new MainPresenter(eventAggregator, mainView);

            Application.Run((RadForm)mainView);

            
        }
    }
}
