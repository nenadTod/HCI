using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using System.Data;
using HCI_Project.AddDialogs;
using HCI_Project.Commands;

namespace HCI_Project.EditDialogs
{
    /// <summary>
    /// Interaction logic for EditTag.xaml
    /// </summary>
    public partial class EditTag : Window, Reloadable
    {
        TagItem selectedItem;
        ObservableCollection<TagItem> tagItemList = new ObservableCollection<TagItem>();
        private object _tagLock = new object();

        MainWindow mainWindow;

        public EditTag(MainWindow window)
        {
            BindingOperations.EnableCollectionSynchronization(tagItemList, _tagLock);

            InitializeComponent();
            LoadTagFromDatabase();
            lista.ItemsSource = tagItemList;
            mainWindow = window;
        }

        public class TagItem
        {
            public string ID { get; set; }
            public string TagColor { get; set; }
            public string Desc { get; set; }
        }

        private void LoadTagFromDatabase()
        {
            var dB = DataBase.Instance();
            var dBE = dB.DataEnteties;
            var query = dBE.Tag;

            tagItemList.Clear();

            foreach (var tag in query)
            {
                tagItemList.Add(new TagItem { ID = tag.id, TagColor = tag.color, Desc = tag.desc });
            }

        }

        private void ListMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dBEEnteties = DataBase.Instance().DataEnteties;
            selectedItem = (TagItem)lista.SelectedItems[0];

            var tag = dBEEnteties.Tag.Find(selectedItem.ID);

            if(tag != null)
            {
                new TagDialog(tag, this).Show();;
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            string currentText = searchBox.Text;

            if (!currentText.Equals(""))
            {
                lista.ItemsSource = from t in tagItemList where t.ID.ToUpper().Contains(currentText.ToUpper()) select t;
            }
            else
            {
                lista.ItemsSource = tagItemList;
            }
        }

        private void SearchGotFocus(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text.Equals("Search..."))
            {
                searchBox.Text = "";
            }
        }

        private void ButtonRemoveClick(object sender, RoutedEventArgs e)
        {
            var dBEEnteties = DataBase.Instance().DataEnteties;
            selectedItem = (TagItem)lista.SelectedItems[0];

            if (selectedItem != null)
            {
                var tag = dBEEnteties.Tag.Find(selectedItem.ID);

                if (tag != null)
                {
                    RemoveTagsCommand command = new RemoveTagsCommand(tag);
                    CommandManager.Instance.DoCommand(command);
                    Reload();
                }
            }
        }

        private void ButtonOkClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonAddClick(object sender, RoutedEventArgs e)
        {
            TagDialog dialog = new TagDialog(this);
            dialog.Show();
        }


        public void Reload()
        {
            mainWindow.ReloadSpecies();
            LoadTagFromDatabase();
        }
    }
}
