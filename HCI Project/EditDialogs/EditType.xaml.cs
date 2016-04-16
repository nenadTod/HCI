using HCI_Project.Commands;
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

namespace HCI_Project.EditDialogs
{
    /// <summary>
    /// Interaction logic for EditType.xaml
    /// </summary>
    public partial class EditType : Window, Reloadable
    {
        TypeItem selectedItem;
        ObservableCollection<TypeItem> typeItemList = new ObservableCollection<TypeItem>();
        private object _typeLock = new object();

        MainWindow mainWindow;

        public EditType(MainWindow window)
        {
            BindingOperations.EnableCollectionSynchronization(typeItemList, _typeLock);

            InitializeComponent();
            LoadTypeFromDatabase();
            lista.ItemsSource = typeItemList;
            mainWindow = window;
        }

        public class TypeItem
        {
            public string ID { get; set; }
            public string Icon { get; set; }
            public string Name { get; set; }
            public string Desc { get; set; }
        }

        private void LoadTypeFromDatabase()
        {
            typeItemList.Clear();

            var dB = DataBase.Instance();
            var dBE = dB.DataEnteties;

            var query = dBE.Type;

            foreach (var type in query)
            {
                typeItemList.Add(new TypeItem { ID = type.id, Icon = type.icon, Name = type.name, Desc = type.desc });
            }

        }

        private void ListMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dBEEnteties = DataBase.Instance().DataEnteties;
            selectedItem = (TypeItem)lista.SelectedItems[0];

            var selectedType = dBEEnteties.Type.Find(selectedItem.ID);
            
            if(selectedType != null)
            {
                new TypeWindow(selectedType, this).ShowDialog();
            }
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            TypeWindow TWD = new TypeWindow(this);
            TWD.ShowDialog();
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            var dBEEnteties = DataBase.Instance().DataEnteties;
            selectedItem = (TypeItem)lista.SelectedItems[0];

            var selectedType = dBEEnteties.Type.Find(selectedItem.ID);

            if (selectedType != null)
            {
                RemoveTypeCommand command = new RemoveTypeCommand(selectedType);
                CommandManager.Instance.DoCommand(command);
                Reload();
            }
        }

        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            string currentText = searchBox.Text;

            if (!currentText.Equals(""))
            {
                lista.ItemsSource = from t in typeItemList where t.ID.ToUpper().Contains(currentText.ToUpper()) select t;
            }
            else
            {
                lista.ItemsSource = typeItemList;
            }
        }

        private void SearchGotFocus(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text.Equals("Search..."))
            {
                searchBox.Text = "";
            }
        }

        public void Reload()
        {
            mainWindow.ReloadSpecies();
            LoadTypeFromDatabase();
        }
    }
}
