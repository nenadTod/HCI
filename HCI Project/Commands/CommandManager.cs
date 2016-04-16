using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HCI_Project
{
    class CommandManager
    {

        static private CommandManager instance = null;

        LinkedList<Command> commands = new LinkedList<Command>();
        LinkedList<Command> undoneCommands = new LinkedList<Command>();

        private CommandManager()
        {
        }

        internal static CommandManager Instance
        {
            get 
            {
                if (instance == null)
                    instance = new CommandManager();

                return CommandManager.instance; 
            }
        }

        public void DoCommand(Command command)
        {
            try
            {
                command.Perform();
                commands.AddLast(command);
                undoneCommands.Clear();
                MainWindow.history.Reload();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UndoCommand()
        {
            if (commands.Count != 0)
            {
                Command c = commands.Last.Value;
                c.Rollback();
                undoneCommands.AddFirst(c);
                commands.RemoveLast();
            }
        }

        public void RedoCommand()
        {
            if (undoneCommands.Count != 0)
            {
                Command c = undoneCommands.First.Value;
                c.Perform();
                commands.AddLast(c);
                undoneCommands.RemoveFirst();
            }
        }

        public LinkedList<Command> getCommands()
        {
            return commands;
        }

        public LinkedList<Command> getUndoneCommands()
        {
            return undoneCommands;
        }

    }
}
