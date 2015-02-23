using oEditor.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView mainView;

        public MainPresenter(IMainView mainView)
        {
            // Main view initialization
            this.mainView = mainView;

            this.mainView.DockWindowClosing += (sender, e) =>
            {
                e.Cancel = false;

                if (e.NewWindow is SceneView)
                {
                    switch (mainView.ShowMessageBox("Do you want to save your changes?", "Save changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3))
                    {
                        case DialogResult.Yes:
                            // TODO: Save map
                            break;
                        case DialogResult.No:

                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                    }
                }
            };
            
        }
    }
}
