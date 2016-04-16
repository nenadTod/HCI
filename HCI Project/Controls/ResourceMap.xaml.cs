using MapControl;
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

namespace HCI_Project.Controls
{
    /// <summary>
    /// Interaction logic for ResourceMap.xaml
    /// </summary>
    public partial class ResourceMap : UserControl
    {

        private const int maxZoomingLevel = 8;
        private const int minZoomingLevel = 3;
        private String mapId = null;
        private bool filterVisible = false;

        public String MapId
        {
            get { return mapId; }
        }

        public ResourceMap(String id)
        {
            InitializeComponent();
            mapId = id;
        }

        public ResourcePushpin AddPin(ResourceLocation location)
        {
            ResourcePushpin pin = new ResourcePushpin(location);

            var l = new MapControl.Location(location.latitude, location.longitude);
            MapPanel.SetLocation(pin, l);
            pin.Content = location.Species.name;
            pin.Uid = location.Species.id;
            map.Children.Add(pin);

            return pin;
        }

        public ResourcePushpin AddPin(ResourcePushpin pin)
        {
            map.Children.Add(pin);
            return pin;
        }

        public void RemovePin(ResourcePushpin pin)
        {
            map.Children.Remove(pin);
        }


        public List<ResourcePushpin> getPinsBySpecies(String speciesID)
        {
            return (from pin in map.Children.OfType<ResourcePushpin>() where pin.Uid == speciesID select pin).ToList();
        }

        public void RemovePinsBySpecies(String speciesID)
        {
            var x = (from pin in map.Children.OfType<ResourcePushpin>() where pin.Uid == speciesID select pin).ToList();
            
            foreach(var pin in x)
            {
                map.Children.Remove(pin);
            }
        }

        public void TogleFilterVisiblity()
        {
            filterVisible = !filterVisible;
            Filter.Visibility = filterVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        private void MapDragOver(object sender, DragEventArgs e)
        {
            base.OnDragOver(e);
            e.Effects = DragDropEffects.Move | DragDropEffects.Copy;
            e.Handled = true;
        }

        private void MapDrop(object sender, DragEventArgs e)
        {
            base.OnDrop(e);

            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string id = (string)e.Data.GetData(DataFormats.StringFormat);

                try
                {
                    Point mousePosition = e.GetPosition(map);
                    var pinLocation = map.ViewportPointToLocation(mousePosition);

                    if (e.Effects.HasFlag(DragDropEffects.Copy))
                    {
                        PlaceCommand command = new PlaceCommand(id, pinLocation, this);
                        CommandManager.Instance.DoCommand(command);
                    }
                    else if (e.Effects.HasFlag(DragDropEffects.Move))
                    {
                        var pushpin = e.Data.GetData(typeof(ResourcePushpin)) as ResourcePushpin;
                        MoveCommand command = new MoveCommand(pushpin, this, pinLocation);
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

        private void ApplyButtonClick(object sender, RoutedEventArgs e)
        {
            var pins = map.Children.OfType<ResourcePushpin>();

            foreach (var pin in pins)
            {
                pin.Visibility = Visibility.Visible;
            }

            IEnumerable<ResourcePushpin> selectedPins = null;

            switch(FilterType.Text)
            {
                case "-": selectedPins = new List<ResourcePushpin>(); break;
                case "Id": selectedPins = pins.Where(x => !x.Location.species_id.ToUpper().Contains(FilterText.Text.ToUpper())); break;
                case "Name": selectedPins = pins.Where(x => !x.Location.Species.name.ToUpper().Contains(FilterText.Text.ToUpper())); break;
                case "Status": 
                    {
                        selectedPins = from pin in pins
                                       where pin.Location.Species.status == StatusFilterChoice.SelectedIndex
                                       select pin;
                        break; 
                    }
                case "Tag":
                    {
                        selectedPins = from pin in pins 
                                       where pin.Location.Species.Tag_Species.All(ts => !ts.tag_id.ToUpper().Contains(FilterText.Text.ToUpper())) 
                                       select pin;
                        break;
                    }
                case "On IUCN Red List":
                    {
                        selectedPins = from pin in pins
                                       where pin.Location.Species.IUCN != (UCNFilterChoice.Text == "On the list" ? 1 : 0)
                                       select pin; ;
                        break;
                    }
            }
            
            foreach(var pin in selectedPins)
            {
                pin.Visibility = Visibility.Collapsed;
            }
        }

        private void RemoveFilerButtonClick(object sender, RoutedEventArgs e)
        {
            var pins = map.Children.OfType<ResourcePushpin>();

            foreach (var pin in pins)
            {
                pin.Visibility = Visibility.Visible;
            }
        }

        private void FilterTypeChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((e.AddedItems[0] as ComboBoxItem).Content as string) == "Status")
            {
                FilterText.Visibility = Visibility.Collapsed;
                StatusFilterChoice.Visibility = Visibility.Visible;
                UCNFilterChoice.Visibility = Visibility.Collapsed;
            }
            else if (((e.AddedItems[0] as ComboBoxItem).Content as string) == "On IUCN Red List")
            {
                FilterText.Visibility = Visibility.Collapsed;
                StatusFilterChoice.Visibility = Visibility.Collapsed;
                UCNFilterChoice.Visibility = Visibility.Visible;
            }
            else
            {
                FilterText.Visibility = Visibility.Visible;
                StatusFilterChoice.Visibility = Visibility.Collapsed;
                UCNFilterChoice.Visibility = Visibility.Collapsed;
            }
        }

       
    }
}
