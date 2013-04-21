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
        public static List<object> Airports = new List<object>();

        public static void LoadData () {
            FillPlanes();
            FillAirports();
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
                Destination = 1,
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
                Destination = 1,
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
                Destination = 2,
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
                Destination = 4,
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
                Destination = 3,
                Type = 3
            });
        }

        private static void FillAirports() 
        {
            Airports.Add(new {
                Id = 1,
                X = 303,
                Y = 161,
                City = "Chicago",
                @Airport = "O'Hare Intarnational"
            });

            Airports.Add(new
            {
                Id = 2,
                X = 642,
                Y = 157,
                City = "Rome",
                @Airport = "Ciampino Airport"
            });

            Airports.Add(new
            {
                Id = 3,
                X = 1063,
                Y = 179,
                City = "Tokyo",
                @Airport = "Haneda Airport"
            });

            Airports.Add(new
            {
                Id = 4,
                X = 452,
                Y = 377,
                City = "Rio de Janeiro",
                @Airport = "Galeão International"
            });
        }

        public static List<object> GetUpdatedLocations() 
        {
            List<object> newLocations = new List<object>();
            Random random = new Random();
            
            foreach (Plane plane in Planes)
	        {
                plane.X += random.Next(-2, 3);
                plane.Y += random.Next(-1, 2);
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
            public int Destination {get; set;}
            public int Type { get; set; }
        }      

    }
}