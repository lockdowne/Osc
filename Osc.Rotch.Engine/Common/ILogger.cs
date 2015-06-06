using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Engine.Common
{
    public interface ILogger
    {
        bool CheckPath();

        void Log(string message, string methodName = "", string filePath = "", int line = 0);

        event Action<Osc.Engine.Common.Logger.LogEntry> OnLogged;
    }
}
