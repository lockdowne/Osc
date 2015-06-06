using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Engine.Aggregators
{
    public interface IEventAggregatorAsync
    {
        Task<Task[]> Publish<TEvent>(object sender, Task<TEvent> eventDataTask);
        Task Subscribe<TEvent>(object sender, Func<Task<TEvent>, Task> eventHandlerTaskFactory);
        Task Unsubscribe<TEvent>(object sender);
    }
}
