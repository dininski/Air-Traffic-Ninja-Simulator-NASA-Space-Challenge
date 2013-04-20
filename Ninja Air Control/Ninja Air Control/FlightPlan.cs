using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinjaAirControl.Data;

namespace NinjaAirControl
{
    /// <summary>
    /// Holds information about the flight
    /// </summary>
    public class FlightPlan
    {
        public Airport DepartureAirport { get; private set; }

        public Airport ArrivalAirport { get; private set; }

        public DateTime DepartureDateTime { get; private set; }

        public DateTime EstimatedArrivalDateTime { get; private set; }

        public int PreplannedSpeed { get; private set; }

        public FlightRoute PreplannedRoute { get; private set; }

        public int EnRouteAltitude { get; private set; }

        public FlightType Type { get; private set; }

        // TODO: Add method changeArrivalAirport()
        // TODO: Add method recalculateEstimatedArrivalDateTime()
        
        public FlightPlan(
            Airport departureAirport,
            Airport arrivalAirport,
            DateTime departureDateTime,
            DateTime estimatedArrivalDateTime,
            int preplannedSpeed,
            FlightRoute preplannedRoute,
            int enRouteAltitude,
            FlightType type)
        {
            this.DepartureAirport = departureAirport;
            this.ArrivalAirport = arrivalAirport;
            this.DepartureDateTime = departureDateTime;
            this.EstimatedArrivalDateTime = estimatedArrivalDateTime;
            this.PreplannedSpeed = preplannedSpeed;
            this.PreplannedRoute = preplannedRoute;
            this.EnRouteAltitude = enRouteAltitude;
            this.Type = type;
        }
    }
}