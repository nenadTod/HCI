using HCI_Project.Controls;
using MapControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Project
{
    class PlaceCommand : Command
    {

        String id;
        MapControl.Location pinLocation;
        ResourceMap map;

        ResourcePushpin pin;

        public PlaceCommand(String id, MapControl.Location pinLocation, ResourceMap map)
        {
            this.id = id;
            this.pinLocation = pinLocation;
            this.map = map;
        }

        public override void Perform()
        {
            var dBE = DataBase.Instance().DataEnteties;

            ResourceLocation l = new ResourceLocation();
            l.Species = dBE.Species.Find(id);
            l.Maps = dBE.Maps.Find(map.MapId);
            l.latitude = pinLocation.Latitude;
            l.longitude = pinLocation.Longitude;

            dBE.ResourceLocation.Add(l);
            dBE.SaveChanges();

            if(pin == null)
            {
                pin = map.AddPin(l);
            }
            else
            {
                MapPanel.SetLocation(pin, new MapControl.Location(l.latitude, l.longitude));
                map.AddPin(pin);
            }

            pin.Location = l;
        }

        public override void Rollback()
        {
            var dBE = DataBase.Instance().DataEnteties;

            ResourceLocation l = dBE.ResourceLocation.Find(pin.Location.id);
            dBE.ResourceLocation.Remove(l);
            dBE.SaveChanges();

            map.RemovePin(pin);
        }

        public override string description
        {
            get { return "Place pushpin"; }
        }
    }
}
