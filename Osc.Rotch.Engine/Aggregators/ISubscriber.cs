using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Engine.Aggregators
{
   public interface ISubscriber<T>
    {
        void OnEvent(T item);
    }
}

