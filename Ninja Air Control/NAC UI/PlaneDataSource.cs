using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaAirControl;
using NinjaAirControl.Data;

namespace NAC_UI
{
    public class PlaneDataSource
    {
        public static List<Plane> Planes = new List<Plane>();
        public static List<object> Airports = new List<object>();
        private static List<Flight> flights = new List<Flight>();
        private static List<Airport> airport = new List<Airport>();

        public static void LoadData()
        {
            FillPlanes();
            FillAirports();
        }

        private static void FillPlanes()
        {


            Planes.Add(new Plane
            {
                Identification = "K7H570BG",
                Speed = 2000,
                X = 300,
                Y = 200,
                Z = 20000,
                Company = "Pacific Airlines",
                Destination = "Chicago",
                Type = 1
            });
        }

        private static void FillAirports()
        {
            Airport jfk = new Airport("John F. Kennedy International Airport", new Position3D(-90.9187999m, 46.5482781m, 251), new Person("John Kennedy"));

            Airports.Add(new
            {
                X = jfk.Coordinates.LatitudeInNauticalMiles/18,
                Y = jfk.Coordinates.LongitudeInNauticalMiles/18,
                City = "NY",
                @Airport = jfk.Name
            });

            //Airports.Add(new
            //{
            //    X = 452,
            //    Y = 377,
            //    City = "Rio de Janeiro",
            //    @Airport = "Galeão International"
            //});
        }

        public static List<object> GetUpdatedLocations()
        {
            List<object> newLocations = new List<object>();

            foreach (Flight flight in flights)
            {
                flight.UpdatePosition();
                Plane plane = new Plane();
                plane.X = (int)(flight.CurrentPosition.LongitudeInNauticalMiles/18);
                plane.Y = (int)(flight.CurrentPosition.LatitudeInNauticalMiles/18);
                plane.Z = (int)(flight.CurrentPosition.Altitude);

                newLocations.Add(new
                {
                    X = plane.X,
                    Y = plane.Y,
                    Z = plane.Z,
                    Id = flight.Aircraft.Identification.Id
                });
            }

            return newLocations;
        }

        public class Plane
        {
            public string Identification { get; set; }
            public int Speed { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
            public string Company { get; set; }
            public string Destination { get; set; }
            public int Type { get; set; }
        }

    }
}