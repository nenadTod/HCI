using HCI_Project.Controls;
using MapControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Project
{
    class RemoveCommand : Command
    {

        ResourcePushpin pushpin;
        Map map;

        double longitude;
        double latitude;
        String speciesId;
        String mapId;

        public RemoveCommand(ResourcePushpin pushpin)
        {
            this.pushpin = pushpin;
            map = pushpin.Parent as Map;
        }

        public override void Perform()
        {
            var dBE = DataBase.Instance().DataEnteties;
            var locationObject = dBE.ResourceLocation.Find(pushpin.Location.id);

            longitude = locationObject.longitude;
            latitude = locationObject.latitude;
            speciesId = locationObject.species_id;
            mapId = locationObject.maps_id;

            dBE.ResourceLocation.Remove(locationObject);
            dBE.SaveChanges();

            map.Children.Remove(pushpin);
        }

        public override void Rollback()
        {
            var dBE = DataBase.Instance().DataEnteties;
            var location = new ResourceLocation();
            
            location.longitude = longitude;
            location.latitude = latitude;
            location.Maps = dBE.Maps.Find(mapId);
            location.Species = dBE.Species.Find(speciesId);

            dBE.ResourceLocation.Add(location);
            dBE.SaveChanges();

            pushpin.Location = location;

            map.Children.Add(pushpin);
        }

        public override string description
        {
            get { return "Remove pushpin"; }
        }
    }
}
