using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oEngine.Entities;
using oEngine.Common;
using System.Runtime.CompilerServices;

namespace oEngine.Managers
{
    public class CommandManager : ICommandManager
    {
        private readonly Stack<Command> undo = new Stack<Command>();
        private readonly Stack<Command> redo = new Stack<Command>();

        private readonly ILogger logger;

        public CommandManager(ILogger logger)
        {
            this.logger = logger;
        }

        public void ExecuteCommand(Command command, bool saveToStack = true, [CallerMemberName]string methodName = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int line = 0)
        {
            try
            {
                if (command.CanExecute())
                {
                    command.Execute();

                    logger.Log(command.Name, methodName, filePath, line);

                    if (saveToStack)
                    {
                        undo.Push(command);
                        redo.Clear();
                    }
                }
            }
            catch (Exception exception)
            {
                logger.Log(exception.ToString(), methodName, filePath, line);
            }
        }

        public void Undo([CallerMemberName]string methodName = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int line = 0)
        {            
            try
            {
                if (undo.Count <= 0)
                    return;

                Command command = undo.Pop();
                command.UnExecute();

                logger.Log(command.Name, methodName, filePath, line);

                redo.Push(command);
            }
            catch (Exception exception)
            {
                logger.Log(exception.ToString(), methodName, filePath, line);
            }          
        }

        public void Redo([CallerMemberName]string methodName = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int line = 0)
        {           
            try
            {
                if (redo.Count <= 0)
                    return;

                Command command = undo.Pop();
                command.UnExecute();

                logger.Log(command.Name, methodName, filePath, line);

                redo.Push(command);
            }
            catch (Exception exception)
            {
                logger.Log(exception.ToString(), methodName, filePath, line);
            }
        }  

        public Task ExecuteCommandAsync(Command command, bool saveToStack = true, [CallerMemberName]string methodName = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int line = 0)
        {
            return Task.Run(() =>
                {
                    try
                    {
                        if (command.CanExecute())
                        {
                            command.Execute();

                            logger.Log(command.Name, methodName, filePath, line);

                            if (saveToStack)
                            {
                                undo.Push(command);
                                redo.Clear();
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        logger.Log(exception.ToString(), methodName, filePath, line);
                    }
                });
                               
        }

        public Task UndoAsync([CallerMemberName]string methodName = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int line = 0)
        {
            return Task.Run(() =>
                {
                    try
                    {
                        if (undo.Count <= 0)
                            return;

                        Command command = undo.Pop();
                        command.UnExecute();

                        logger.Log(command.Name, methodName, filePath, line);

                        redo.Push(command);
                    }
                    catch (Exception exception)
                    {
                        logger.Log(exception.ToString(), methodName, filePath, line);
                    }
                });           
        }

        public Task RedoAsync([CallerMemberName]string methodName = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int line = 0)
        {
            return Task.Run(() =>
                {
                    try
                    {
                        if (redo.Count <= 0)
                            return;

                        Command command = undo.Pop();
                        command.UnExecute();

                        logger.Log(command.Name, methodName, filePath, line);

                        redo.Push(command);
                    }
                    catch (Exception exception)
                    {
                        logger.Log(exception.ToString(), methodName, filePath, line);
                    }
                });
        }        

        public void Clear()
        {
            redo.Clear();
            undo.Clear();
        }
    }
}
