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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HCI_Project.EditDialogs;
using HCI_Project.AddDialogs;
using Xceed.Wpf.AvalonDock.Layout;
using HCI_Project.Controls;
using MapControl;

namespace HCI_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, Reloadable
    {

        private Point startPoint;
        private Dictionary<String, LayoutDocument> mapDocuments = new Dictionary<string, LayoutDocument>();
        private String textSearch = "";
        private bool fullscreen = false;
        public static HistoryWindow history;

        public MainWindow()
        {
            history = new HistoryWindow(this);
            InitializeComponent();
            ReloadSpecies();
            ReloadMaps();
            BingMapsTileLayer.ApiKey = "Au179_ITfDMxFrmg8hN_UPhUJ3TzvAkaRubWk9pCCsHdvTsqyc9BZV930jG_pBpf";
        }

        public ResourceMap GetMapById(String id)
        {
            return mapDocuments[id].Content as ResourceMap;
        }

        public List<ResourceMap> getMaps()
        {
            return (from m in mapDocuments.Values select m.Content as ResourceMap).ToList();
        }

        public void Reload()
        {
            ReloadSpecies();
            history.Reload();
        }

        public void ReloadMaps()
        {
            var context = DataBase.Instance().DataEnteties;
            var maps = context.Maps;
            mapList.DataContext = maps.ToList();

            foreach (var map in maps)
            {
                LayoutDocument x = new LayoutDocument();
                x.Title = map.name;

                ResourceMap resourceMap = new ResourceMap(map.name);
                x.Content = resourceMap;

                mapDocuments.Add(map.name, x);
                Documents.Children.Add(x);

                var dBE = DataBase.Instance().DataEnteties;
                var locations = dBE.ResourceLocation.Where(f => f.maps_id == map.name);

                foreach (var location in locations)
                {
                    resourceMap.AddPin(location);
                }
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {

            var result = MessageBox.Show("Do You want to save your work?", "", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                if (result == MessageBoxResult.Yes)
                {
                    DataBase.Instance().Save();
                }

                history.closable = true;
                history.Close();
            }

            base.OnClosing(e);
        }


        public void ReloadSpecies()
        {
            var context = DataBase.Instance().DataEnteties;
            if (searchBox.Text != "")
            {
                speciesList.DataContext = (from s in context.Species where s.name.ToUpper().Contains(textSearch.ToUpper()) select s).ToList();
            }
            else
            {
                speciesList.DataContext = context.Species.ToList();
                Species s;
            }
        }

        private void UndoCommandBinding_Executed(object sender, RoutedEventArgs e)
        {
            CommandManager.Instance.UndoCommand();
            ReloadSpecies();
            history.Reload();
        }

        private void RedoCommandBinding_Executed(object sender, RoutedEventArgs e)
        {
            CommandManager.Instance.RedoCommand();
            ReloadSpecies();
            history.Reload();
        }

        private void EditTagsClick(object sender, RoutedEventArgs e)
        {
            EditTag editTagDialog = new EditTag(this);
            editTagDialog.ShowDialog();
        }

        private void EditTypesClick(object sender, RoutedEventArgs e)
        {
            EditType EditTypeDialog = new EditType(this);
            EditTypeDialog.ShowDialog();
        }

        private void EditSpeciesClick(object sender, RoutedEventArgs e)
        {
            EditSpecies editSpeciesDialog = new EditSpecies(this);
            editSpeciesDialog.ShowDialog();
        }

        private void FullScreenCommandBinding_Executed(object sender, RoutedEventArgs e)
        {
            fullscreen = !fullscreen;

            if (fullscreen)
            {
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = WindowState.Normal;
            }
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SpeciesDialogClick(object sender, RoutedEventArgs e)
        {
            SpeciesDialog ASW = new SpeciesDialog(this);
            ASW.ShowDialog();
        }

        private void TypeWindowClick(object sender, RoutedEventArgs e)
        {
            TypeWindow ATW = new TypeWindow();
            ATW.ShowDialog();
        }

        private void TagDialogClick(object sender, RoutedEventArgs e)
        {
            TagDialog td = new TagDialog();
            td.ShowDialog();
        }

        private void SaveCommandBinding_Executed(object sender, RoutedEventArgs e)
        {
            DataBase.Instance().Save();
        }

        private void SpeciesMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);

            if(e.ClickCount == 2)
            {
                var context = DataBase.Instance().DataEnteties;
                var speciesDialog = new SpeciesDialog(context.Species.Find((sender as StackPanel).Uid),this);
                speciesDialog.ShowDialog();
            }
        }

        private void SpeciesMouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {

                StackPanel panel = (StackPanel)sender;
                DataObject data = new DataObject();

                if(panel != null)
                {
                    data.SetData(DataFormats.StringFormat, panel.Uid);
                }

                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy);
            } 
        }

        private void MapClick(object sender, RoutedEventArgs e)
        {
            Button p = (Button)sender;
            LayoutDocument d = mapDocuments[p.Uid];

            if (Documents.Children.Contains(d))
            {
                dockingManager.ActiveContent = d;
            }
        }

        private void MapDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Button p = (Button)sender;
            LayoutDocument d = mapDocuments[p.Uid];

            if (!Documents.Children.Contains(d))
            {
                Documents.Children.Add(d);
            }

            dockingManager.ActiveContent = d;
        }

        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            this.textSearch = searchBox.Text;
            ReloadSpecies();
        }


        private void ThrashDragOver(object sender, DragEventArgs e)
        {
            base.OnDragOver(e);
            e.Effects = DragDropEffects.Link;
            e.Handled = true;
        }

        private void TrashDrop(object sender, DragEventArgs e)
        {
            base.OnDrop(e);

            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string id = (string)e.Data.GetData(DataFormats.StringFormat);

                try
                {
                    if (e.Effects.HasFlag(DragDropEffects.Link))
                    {
                        var pushpin = e.Data.GetData(typeof(ResourcePushpin)) as ResourcePushpin;
                        var command = new RemoveCommand(pushpin);
                        CommandManager.Instance.DoCommand(command);
                    }

                    e.Handled = true;
                }
                catch
                {
                    // Nenad obradjuje exception-e....
                }
            }
            e.Handled = true;
        }

        private void FilterCommandBinding_Executed(object sender, RoutedEventArgs e)
        {
            var map = dockingManager.ActiveContent as ResourceMap;
            map.TogleFilterVisiblity();
        }

        private void HistoryClick(object sender, RoutedEventArgs e)
        {
            if (!history.IsVisible)
            {
                history.Show();
                history.Reload();
            }
            else
            {
                history.Hide();
                history.Reload();
            }
        }

    }
}
