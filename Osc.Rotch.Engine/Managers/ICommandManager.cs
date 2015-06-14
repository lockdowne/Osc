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
        bool CanUndo { get; }
        bool CanRedo { get; }

        void ExecuteCommand(Command command, bool saveToStack = true, [CallerMemberName]string methodName = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int line = 0);

        void Undo();
        void Redo();

        Task ExecuteCommandAsync(Command command, bool saveToStack = true, [CallerMemberName]string methodName = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int line = 0);
        
        Task UndoAsync();
        Task RedoAsync();

        void Clear();
    }
}
