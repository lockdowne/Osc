using oEngine.Common;
using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace oEngine.Factories
{
    public static class CommandFactory
    {
        private static readonly Stack<Command> undo = new Stack<Command>();
        private static readonly Stack<Command> redo = new Stack<Command>();

        /// <summary>
        /// Executes command
        /// </summary>
        /// <param name="command">Command to execute if able</param>
        /// <param name="saveToStack">Set to true for undo/redo compatibility</param>
        /// <returns>Logging message</returns>
        public static string ExecuteCommand(Command command, bool saveToStack = true)
        {
           
            try
            {
                if(command.CanExecute())
                {                         
                    command.Execute();

                    if (saveToStack)
                    {
                        undo.Push(command);
                        redo.Clear();
                    }

                    if(string.IsNullOrEmpty(command.Description))
                        return "Command: " + command.Name;

                    return "Command: " + command.Name + " - " + command.Description;
                }
            }
            catch(Exception exception)
            {
                Logger.Log("CommandFactory", "ExecuteCommand", exception, command.Description);

                if (string.IsNullOrEmpty(command.Description))
                    return "Command: " + command.Name + Environment.NewLine + "Exception: " + exception.ToString(); ;

                return "Error: " + command.Name + " - " + command.Description + Environment.NewLine + "Exception: " + exception.ToString();
            }

            return "Command: Cannot execute";
        }

        /// <summary>
        /// Undos previous command
        /// </summary>
        /// <returns>Logging message</returns>
        public static string Undo()
        {
            if (undo.Count <= 0)
                return "Command: Undo - Nothing to undo";

            try
            {
                Command command = undo.Pop();
                command.UnExecute();
                redo.Push(command);
            }
            catch(Exception exception)
            {
                Logger.Log("CommandFactory", "UndoCommand", exception);
                return "Command: Error Undo" + Environment.NewLine + "Exception - " + exception.ToString();
            }

            return "Command: Cannot Undo";
        }

        /// <summary>
        /// Redos undoed command
        /// </summary>
        /// <returns>Logging message</returns>
        public static string Redo()
        {
            if (redo.Count <= 0)
                return "Command: Redo - Nothing to redo";

            try
            {
                Command command = undo.Pop();
                command.UnExecute();
                redo.Push(command);
            }
            catch (Exception exception)
            {
                Logger.Log("CommandFactory", "UndoCommand", exception);
                return "Command: Error Undo" + Environment.NewLine + "Exception - " + exception.ToString();
            }

            return "Command: Cannot Undo";
        }

        /// <summary>
        /// Clears stacks
        /// </summary>
        public static void Clear()
        {
            undo.Clear();
            redo.Clear();
        }
    }
}
