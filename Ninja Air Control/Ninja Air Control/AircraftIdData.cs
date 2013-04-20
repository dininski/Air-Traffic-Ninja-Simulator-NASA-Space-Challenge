using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl
{
    /// <summary>
    /// Hold data concerning an aircraft
    /// </summary>
    public struct AircraftIdData
    {
        public string Id { get; private set; }
        public string Model { get; private set; }
        public string Airline { get; private set; }
        public string Squack { get; set; }
        public bool HasRvsmEquipment { get; private set; }

        public AircraftIdData(string id, 
            string model, 
            string airline, 
            string squack, 
            bool hasRvsmEquipment) : this()
        {
            this.Id = id;
            this.Model = model;
            this.Airline = airline;
            this.Squack = squack;
            this.HasRvsmEquipment = hasRvsmEquipment;
        }
    }
}
