using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl
{
    public class Flight
    {
        public Aircraft Aircraft { get; private set; }

        public Pilot Pilot { get; private set; }

        public FlightPlan FlightPlan { get; private set; }

        public bool IsActive { get; private set; }

        public Flight(Aircraft aircraft, Pilot pilot, FlightPlan flightPlan)
        {
            this.Aircraft = aircraft;
            this.Pilot = pilot;
            this.FlightPlan = flightPlan;
            this.IsActive = true;
        }

        public void CheckFlightStatus() 
        {
            if (this.Aircraft.CurrentPosition.CompareTo(FlightPlan.ArrivalAirport.Coordinates) == 0)
            {
                IsActive = false;
            }
        }
    }
}
