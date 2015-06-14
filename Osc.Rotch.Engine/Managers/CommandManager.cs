using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osc.Rotch.Engine.Entities;
using Osc.Rotch.Engine.Common;
using System.Runtime.CompilerServices;

namespace Osc.Rotch.Engine.Managers
{
    public class CommandManager : ICommandManager
    {
        private readonly Stack<Command> undo = new Stack<Command>();
        private readonly Stack<Command> redo = new Stack<Command>();

        private readonly ILogger logger;

        public bool CanUndo
        {
            get { return undo.Any(); }
        }

        public bool CanRedo
        {
            get { return redo.Any(); }
        }


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

        public void Undo()
        {            
            try
            {
                if (!undo.Any())
                    return;

                Command command = undo.Pop();
                command.UnExecute();

                logger.Log(command.Name);

                redo.Push(command);
            }
            catch (Exception exception)
            {
                logger.Log(exception.ToString());
            }          
        }

        public void Redo()
        {           
            try
            {
                if (!redo.Any())
                    return;

                Command command = undo.Pop();
                command.UnExecute();

                logger.Log(command.Name);

                redo.Push(command);
            }
            catch (Exception exception)
            {
                logger.Log(exception.ToString());
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

        public Task UndoAsync()
        {
            return Task.Run(() =>
                {
                    try
                    {
                        if (!undo.Any())
                            return;

                        Command command = undo.Pop();
                        command.UnExecute();

                        logger.Log(command.Name);

                        redo.Push(command);
                    }
                    catch (Exception exception)
                    {
                        logger.Log(exception.ToString());
                    }
                });           
        }

        public Task RedoAsync()
        {
            return Task.Run(() =>
                {
                    try
                    {
                        if (!redo.Any())
                            return;

                        Command command = undo.Pop();
                        command.UnExecute();

                        logger.Log(command.Name);

                        redo.Push(command);
                    }
                    catch (Exception exception)
                    {
                        logger.Log(exception.ToString());
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
