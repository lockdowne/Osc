using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace oEngine.Common
{
    public interface ILogger
    {
        bool CheckPath();

        void Log(string message, string methodName = "", string filePath = "", int line = 0);

        event Action<oEngine.Common.Logger.LogEntry> OnLogged;
    }
}
