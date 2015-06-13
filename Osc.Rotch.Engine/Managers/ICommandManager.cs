using Osc.Rotch.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Rotch.Engine.Managers
{
    public interface ICommandManager
    {
        void ExecuteCommand(Command command, bool saveToStack = true, [CallerMemberName]string methodName = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int line = 0);

        void Undo(string methodName = "", string filePath = "", int line = 0);
        void Redo(string methodName = "", string filePath = "", int line = 0);

        Task ExecuteCommandAsync(Command command, bool saveToStack = true, [CallerMemberName]string methodName = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int line = 0);
        
        Task UndoAsync(string methodName = "", string filePath = "", int line = 0);
        Task RedoAsync(string methodName = "", string filePath = "", int line = 0);

        void Clear();
    }
}
