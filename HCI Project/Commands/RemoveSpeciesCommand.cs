using HCI_Project.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Project.Commands
{
    class RemoveSpeciesCommand : Command
    {
        Species species = null;
        List<KeyValuePair<String, ResourceLocation>> savedLocations = new List<KeyValuePair<String, ResourceLocation>>();
        List<ResourcePushpin> pushPins = new List<ResourcePushpin>();

        MainWindow window = null;

        public RemoveSpeciesCommand(Species s, MainWindow window)
        {
            this.species = s;
            this.window = window;
        }

        public override void Perform()
        {
            var dBE = DataBase.Instance().DataEnteties;
            var locations = (from l in dBE.ResourceLocation where l.species_id == species.id select l).ToList();

            foreach (var location in locations)
            {
                savedLocations.Add(new KeyValuePair<string, ResourceLocation>(location.maps_id, location));
            }

            dBE.ResourceLocation.RemoveRange(locations);
            dBE.Species.Remove(species);

            dBE.SaveChanges();

            var maps = window.getMaps();

            pushPins.Clear();
            foreach(var map in maps)
            {
                pushPins.AddRange(map.getPinsBySpecies(species.id));
                map.RemovePinsBySpecies(species.id);
            }
        }

        public override void Rollback()
        {
            var dBE = DataBase.Instance().DataEnteties;

            foreach (var location in savedLocations)
            {
                location.Value.maps_id = location.Key;
                location.Value.Species = species;
            }

            dBE.Species.Add(species);
            dBE.ResourceLocation.AddRange(from l in savedLocations select l.Value);

            foreach (var pin in pushPins)
            {
                var map = window.GetMapById(pin.Location.maps_id);
                map.AddPin(pin);
            }

            dBE.SaveChanges();
        }

        public override string description
        {
            get { return "Remove specie"; }
        }
    }
}
