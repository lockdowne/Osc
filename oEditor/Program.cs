using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using oEditor.Views;
using oEditor.Presenters;

namespace oEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Change to interface
            IMainView view = new MainView();

            MainPresenter main = new MainPresenter(view);

            Application.Run((MainView)view);
        }
    }
}
