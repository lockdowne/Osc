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

namespace oEditor.Controllers
{
    public class ConsoleController : IConsoleController
    {
        private readonly IConsoleView view;

        private readonly ILogger logger;

        public ConsoleController(IConsoleView consoleView, ILogger logger)
        {
            this.view = consoleView;
            this.logger = logger;

            //this.view.Grid.Columns.ForEach(column => column.BestFit());

            this.logger.OnLogged += (entry) =>
            {
                view.Grid.Rows.Add(view.Grid.Rows.Count, entry.Message, entry.ClassName, entry.MethodName, entry.LineNumber, entry.DateTime);
            };

            this.Subscribe<OnWriteConsole>(async obj =>
            {
                var item = await obj;

                if (!string.IsNullOrEmpty(item.Message))
                {
                    
                }
            });

            this.Subscribe<OnParseConsoleCommand>(async obj =>
            {
                var item = await obj;

                if(!string.IsNullOrEmpty(item.Command))
                {                 
                    //view.RadListControl.Invoke(new Action(() => view.RadListControl.Items.Add(item.Command)));
                    view.RadTextBox.Invoke(new Action(() => view.RadTextBox.Text = ""));
                }
            });
            
        } 
    }
}
