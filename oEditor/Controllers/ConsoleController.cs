using oEditor.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oEngine.Common;
using oEditor.Events;
using System.Data;
using System.IO;
using oEngine.Aggregators;

namespace oEditor.Controllers
{
    public class ConsoleController : IConsoleController, ISubscriber<OnWriteConsole>, ISubscriber<OnParseConsoleCommand>
    {
        private readonly IConsoleView view;

        private readonly ILogger logger;

        private readonly IEventAggregator eventAggregator;

        public ConsoleController(IConsoleView consoleView, ILogger logger, IEventAggregator eventAggregator)
        {
            this.view = consoleView;
            this.logger = logger;
            this.eventAggregator = eventAggregator;

            this.eventAggregator.Subscribe(this);

            //this.view.Grid.Columns.ForEach(column => column.BestFit());

            this.logger.OnLogged += (entry) =>
            {
                view.Grid.Rows.Add(view.Grid.Rows.Count.ToString().PadLeft(4, '0'), entry.Message, entry.ClassName, entry.MethodName, entry.LineNumber, entry.DateTime);
            };
            
        } 
        public void OnEvent(OnWriteConsole e)
        {
            if (!string.IsNullOrEmpty(e.Message))
            {

            }
        }

        public void OnEvent(OnParseConsoleCommand e)
        {
            if (!string.IsNullOrEmpty(e.Command))
            {
                //view.RadListControl.Invoke(new Action(() => view.RadListControl.Items.Add(item.Command)));
                view.RadTextBox.Text = "";
            }
        }
    }
}
