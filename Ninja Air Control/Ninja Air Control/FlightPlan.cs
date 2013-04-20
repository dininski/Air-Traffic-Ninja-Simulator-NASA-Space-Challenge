using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl
{
    public class FlightPlan
    {
        public Airport DepartureAirport { get; private set; }

        public Airport ArrivalAirport { get; private set; }

        public DateTime DepartureDateTime { get; private set; }

        public DateTime EstimatedArrivalDateTime { get; private set; }

        public int PreplannedSpeed { get; private set; }

        public FlightRoute PreplannedRoute { get; private set; }

        public int EnRouteAltitude { get; private set; }

        // TODO: Add method changeArrivalAirport()
        // TODO: Add method recalculateEstimatedArrivalDateTime()
        // has:
        //-departure Airport
        //-time of departure (DateTime)
        //-arrival Airport
        //-estimated time of arrival (DateTime)
        //-flight speed (int)
        //-flight Route
        //-flight altitude (int)
        
        public FlightPlan(
            Airport departureAirport,
            Airport arrivalAirport,
            DateTime departureDateTime,
            DateTime estimatedArrivalDateTime,
            int preplannedSpeed,
            FlightRoute preplannedRoute,
            int enRouteAltitude)
        {
            this.DepartureAirport = departureAirport;
            this.ArrivalAirport = arrivalAirport;
            this.DepartureDateTime = departureDateTime;
            this.EstimatedArrivalDateTime = estimatedArrivalDateTime;
            this.PreplannedSpeed = preplannedSpeed;
            this.PreplannedRoute = preplannedRoute;
            this.EnRouteAltitude = enRouteAltitude;
        }
    }
}