using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HCI_Project
{
    /// <summary>
    /// Interaction logic for HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window, Reloadable
    {
        public ObservableCollection<Command> commandItemList = new ObservableCollection<Command>();
        private object _commandLock = new object();
        private int current_command_index = -1;

        public bool closable = false;

        Reloadable window = null;

        public HistoryWindow(Reloadable window)
        {
            this.window = window;
            BindingOperations.EnableCollectionSynchronization(commandItemList, _commandLock);
            InitializeComponent();
            Reload();
        }

    
        public void Reload()
        {
            commandItemList.Clear();

            var commands = CommandManager.Instance.getCommands();

            foreach (var command in commands)
            {
                commandItemList.Add(command);
            }


            foreach (var command in CommandManager.Instance.getUndoneCommands())
            {
                commandItemList.Add(command);
            }

            current_command_index = commands.Count - 1;
            commandList.SelectedIndex = commands.Count - 1;
            commandList.ItemsSource = commandItemList;
        }

        private void ItemSelected(object sender, SelectionChangedEventArgs e)
        {
            int item = commandList.SelectedIndex;

            if (commandList.SelectedItems.Count != 0)
            {
                if (item > current_command_index)
                {
                    for(int i = current_command_index; i < item; i++)
                    {
                        CommandManager.Instance.RedoCommand();
                        window.Reload();
                    }
                }
                else
                {
                    for (int i = current_command_index; i != item; i--)
                    {
                        CommandManager.Instance.UndoCommand();
                        window.Reload();
                    }
                }

                current_command_index = item;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           this.Hide();
           e.Cancel = !closable;
        }

        
    }
}
