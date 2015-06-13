using Osc.Rotch.Editor.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Osc.Rotch.Editor.Common
{
    public static class ProgressHelper
    {
        // TODO: Not make this so shitty
        public static void Show(Action action)
        {
            LoadingView view = new LoadingView();

            Task.Run(action).ContinueWith(task => { Thread.Sleep(1000); if (view.InvokeRequired) { view.Invoke(new Action(() => view.Close())); } else { view.Close(); } });

            

            if (view.InvokeRequired)
                view.Invoke(new Action(() => view.ShowDialog()));
            else
                view.ShowDialog();
        }
    }
}
