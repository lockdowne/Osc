using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace oEngine.Managers
{
    public interface ICommandManager
    {
        Task ExecuteCommand(Command command, bool saveToStack = true, [CallerMemberName]string methodName = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int line = 0);
        
        Task Undo(string methodName = "", string filePath = "", int line = 0);
        Task Redo(string methodName = "", string filePath = "", int line = 0);

        void Clear();
    }
}
