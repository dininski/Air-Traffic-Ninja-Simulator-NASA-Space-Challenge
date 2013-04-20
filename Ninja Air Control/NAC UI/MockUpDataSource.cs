using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaAirControl;

namespace NAC_UI
{
    public class MockUpDataSource
    {
        public static List<Plane> Planes = new List<Plane>();        

        public static void LoadData () {
            FillPlanes();
        }

        private static void FillPlanes() {
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

            Planes.Add(new Plane
            {
                Identification = "LZ775GTH",
                Speed = 2200,
                X = 530,
                Y = 120,
                Z = 18000,
                Company = "Bulgaria Air",
                Destination = "Pernik",
                Type = 2
            });

            Planes.Add(new Plane
            {
                Identification = "BB23FK17",
                Speed = 2000,
                X = 1000,
                Y = 300,
                Z = 10000,
                Company = "Pacific Airlines",
                Destination = "Los Angeles",
                Type = 1
            });

            Planes.Add(new Plane
            {
                Identification = "JK2140MM",
                Speed = 1600,
                X = 740,
                Y = 120,
                Z = 33000,
                Company = "Air France",
                Destination = "Veracruz",
                Type = 2
            });

            Planes.Add(new Plane
            {
                Identification = "BS2314RK",
                Speed = 3000,
                X = 100,
                Y = 534,
                Z = 24000,
                Company = "Emirates",
                Destination = "Dubai",
                Type = 3
            });
        }

        public static List<object> GetUpdatedLocations() 
        {
            List<object> newLocations = new List<object>();
            Random random = new Random();
            
            foreach (Plane plane in Planes)
	        {
                plane.X += random.Next(-2, 2);
                plane.Y += random.Next(-1, 1);
                plane.Z += random.Next(-1000, 1000);

                newLocations.Add(new { 
                    X = plane.X,
                    Y = plane.Y,
                    Z = plane.Z,
                    Id = plane.Identification
                });
	        }

            return newLocations;
        }

        public class Plane
        { 
            public string Identification { get; set;}
            public int Speed {get; set;}
            public int X {get; set;}
            public int Y {get; set;}
            public int Z {get; set;}
            public string Company {get; set;}
            public string Destination {get; set;}
            public int Type { get; set; }
        }

    }
}