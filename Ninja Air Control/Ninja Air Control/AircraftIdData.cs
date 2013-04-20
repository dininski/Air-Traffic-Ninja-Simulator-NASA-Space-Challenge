using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl
{
    public struct AircraftIdData
    {
        public string Id { get; private set; }

        public string Model { get; private set; }

        public string Airline { get; private set; }

        public AircraftType Type { get; private set; }

        public string Squack { get; set; }

        public bool HasRvsmEquipment { get; private set; }

        public AircraftIdData(string id,
            string model,
            string airline,
            AircraftType type,
            string squack,
            bool hasRvsmEquipment) : this()
        {
            this.Id = id;
            this.Model = model;
            this.Airline = airline;
            this.Type = type;
            this.Squack = squack;
            this.HasRvsmEquipment = hasRvsmEquipment;
        }
    }
}