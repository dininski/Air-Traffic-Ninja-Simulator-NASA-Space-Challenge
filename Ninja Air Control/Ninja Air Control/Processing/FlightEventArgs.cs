using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl.Processing
{
    public enum WarningLevel{Normal, High, Critical}

    public class FlightEventArgs : EventArgs
    {
        public List<Flight> Flights { get; set; }

        public WarningLevel WarningLevel { get; set; }

        public FlightEventArgs()
        {
            Flights = new List<Flight>();
        }

        public FlightEventArgs(List<Flight> flights, WarningLevel warningLevel)
        {
            Flights = flights;
            WarningLevel = warningLevel;
        }
    }
}
