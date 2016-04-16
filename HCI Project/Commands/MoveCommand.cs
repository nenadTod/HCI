using HCI_Project.Controls;
using MapControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_Project
{
    class MoveCommand : Command
    {

        ResourcePushpin pushpin;
        ResourceMap map;
        MapControl.Location pinLocation;

        String previousMapId;
        MapControl.Map previousMap;
        double previousLongitude;
        double previousLatitude;

        public MoveCommand(ResourcePushpin pushpin, ResourceMap map, MapControl.Location pinLocation)
        {
            this.pushpin = pushpin;
            this.map = map;
            this.pinLocation = pinLocation;
        }

        public override void Perform()
        {
            var dBE = DataBase.Instance().DataEnteties;
            var locationObject = dBE.ResourceLocation.Find(pushpin.Location.id);
            
            previousMapId = locationObject.maps_id;
            locationObject.Maps = dBE.Maps.Find(map.MapId);

            previousLatitude = locationObject.latitude;
            previousLongitude = locationObject.longitude;
            locationObject.latitude = pinLocation.Latitude;
            locationObject.longitude = pinLocation.Longitude;
            
            previousMap = pushpin.Parent as MapControl.Map;
            previousMap.Children.Remove(pushpin);

            MapPanel.SetLocation(pushpin, new MapControl.Location(locationObject.latitude, locationObject.longitude));
            map.AddPin(pushpin);

            dBE.SaveChanges();
        }

        public override void Rollback()
        {
            var dBE = DataBase.Instance().DataEnteties;
            var locationObject = dBE.ResourceLocation.Find(pushpin.Location.id);

            locationObject.Maps = dBE.Maps.Find(previousMapId);
            locationObject.latitude = previousLatitude;
            locationObject.longitude = previousLongitude;

            map.RemovePin(pushpin);

            MapPanel.SetLocation(pushpin, new MapControl.Location(locationObject.latitude, locationObject.longitude));
            (((previousMap.Parent as Grid).Parent as Grid).Parent as ResourceMap).AddPin(pushpin);

            dBE.SaveChanges();
        }

        public override string description
        {
            get { return "Move pushpin"; }
        }
    }
}
