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
    /// Interaction logic for EditSpecies.xaml
    /// </summary>
    public partial class EditSpecies : Window, Reloadable
    {

        private MainWindow mainWindow;
        SpeciesItem selectedItem;

        public ObservableCollection<SpeciesItem> speciesItemList = new ObservableCollection<SpeciesItem>();
        private object _speciesLock = new object();

        public EditSpecies(MainWindow main)
        {
            this.mainWindow = main;
            BindingOperations.EnableCollectionSynchronization(speciesItemList, _speciesLock);

            InitializeComponent();
            LoadSpeciesFromDatabase();
            lista.ItemsSource = speciesItemList;
        }

        public class SpeciesItem
        {
            public string Icon { get; set; }
            public string Name { get; set; }
            public string Tag { get; set; }
            public string Type { get; set; }
            public string Status { get; set; }
            public string Desc { get; set; }
            public string ID { get; set; }
            public long IUCN { get; set; }
            public string Date { get; set; }
        }

        private void LoadSpeciesFromDatabase()
        {
            var dB = DataBase.Instance();
            var dBE = dB.DataEnteties;

            var query = dBE.Species;

            speciesItemList.Clear();

            foreach (var species in query)
            {
                speciesItemList.Add(new SpeciesItem { Name = species.name, 
                                                      Icon = species.icon, 
                                                      Tag = "ovde ide tag", 
                                                      Type = species.type_id, 
                                                      Status = getStatusFromEnum(species.status), 
                                                      ID = species.id, 
                                                      Date = species.dd, 
                                                      Desc = species.desc, 
                                                      IUCN = (long)Convert.ToDouble(species.IUCN) });
            }

            //lista.ItemsSource = speciesItemList;
        }

        String getStatusFromEnum(long e)
        {
            switch(e)
            {
                case 0 : return "Critically Endangered";
                case 1 : return "Endangered";
                case 2 : return "Vulnerable";
                case 3 : return "Dependent on Conservation of Habitat";
                case 4 : return "Near Risk";
                case 5: return "Lowest Risk";
            }

            return "";
        }

        private void AddSpeciesButton(object sender, RoutedEventArgs e)
        {
            SpeciesDialog ASW = new SpeciesDialog(this);
            ASW.ShowDialog();
        }


        private void RemoveSpeciesButton(object sender, RoutedEventArgs e)
        {
            var dBEEnteties = DataBase.Instance().DataEnteties;
            if (lista.SelectedItems.Count != 0)
            {
                selectedItem = (SpeciesItem)lista.SelectedItems[0];
                var selectedSpecies = dBEEnteties.Species.Find(selectedItem.ID);

                if (selectedSpecies != null)
                {
                    var command = new RemoveSpeciesCommand(selectedSpecies, mainWindow);
                    CommandManager.Instance.DoCommand(command);
                    Reload();
                }
            }
        }

        private void ListSizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach(GridViewColumn column in ((GridView)lista.View).Columns) {
                column.Width = lista.Width / 5;
            }
        }

        private void ListMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dBEEnteties = DataBase.Instance().DataEnteties;
            if (lista.SelectedItems.Count != 0)
            {
                selectedItem = (SpeciesItem)lista.SelectedItems[0];
                var selectedSpecies = dBEEnteties.Species.Find(selectedItem.ID);

                if (selectedSpecies != null)
                {
                    new SpeciesDialog(selectedSpecies, mainWindow).ShowDialog();
                }
            }
        }

        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            string currentText = searchBox.Text;

            if (!currentText.Equals(""))
            {
                lista.ItemsSource = from s in speciesItemList where s.Name.ToUpper().Contains(currentText.ToUpper()) select s;
            }
            else
            {
                lista.ItemsSource = speciesItemList;
            }
        }

        private void SearchGotFocus(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text.Equals("Search..."))
            {
                searchBox.Text = "";
            }
        }

        private void ButtonOkClick(object sender, RoutedEventArgs e)
        {
            Close();
        }


        public void Reload()
        {
            mainWindow.ReloadSpecies();
            LoadSpeciesFromDatabase();
        }
    }
}
