using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinjaAirControl.Data;
using NinjaAirControl.Utils;

namespace NinjaAirControl
{
    /// <summary>
    /// Describes a single flight.
    /// Could be active, if aircraft is in flight or inactive if aircraft is on ground.
    /// </summary>
    public class Flight
    {
        private DateTime lastUpdated; 

        public Aircraft Aircraft { get; private set; }

        public AirTrafficController TrafficController { get; private set; } 

        public Person Pilot { get; private set; }

        public FlightPlan FlightPlan { get; private set; }

        public string Squack { get; set; }

        public bool IsActive { get; private set; }       
       
        public Position3D CurrentPosition { get; private set; }

        public int CurrentSpeed { get; private set; }

        public int CurrentAltitude { get; set; }

        public int CurrentHeadingInDegrees { get; private set; }     

        public Flight(Aircraft aircraft, Person pilot, FlightPlan flightPlan, string squack)
        {
            this.Aircraft = aircraft;
            this.Pilot = pilot;
            this.FlightPlan = flightPlan;
            this.Squack = squack;
            this.IsActive = true;
            this.CurrentPosition = flightPlan.DepartureAirport.Coordinates; //set first position to be equal to the departure airport
        }
        /// <summary>
        /// Checks status of flight and sets the IsActive property
        /// </summary>
        public void CheckFlightStatus() 
        {
            if (CurrentPosition.CompareTo(FlightPlan.ArrivalAirport.Coordinates) == 0)
            {
                IsActive = false;
            }
        }

        /// <summary>
        /// Method responsible for updating the position of aircraft at a certain time.
        /// </summary>
        public void UpdatePosition()
        {
            double currentHeadingInRadians = MeasureConverter.ConvertDegreeToRadian(CurrentHeadingInDegrees);
            decimal newLongitude = CurrentPosition.Longitude;
            decimal newLatitude = CurrentPosition.Latitude;
            DateTime currentDateTime = new DateTime();
            int distanceElapsed = (currentDateTime - lastUpdated).Hours * CurrentSpeed;
            newLongitude += (decimal)(distanceElapsed * Math.Sin(currentHeadingInRadians));
            newLatitude += (decimal)(distanceElapsed * Math.Cos(currentHeadingInRadians));
            this.CurrentPosition = new Position3D(newLongitude, newLatitude, CurrentPosition.Altitude);
            lastUpdated = currentDateTime;
        }
        //TODO: Calculate current position method
        //TODO: Method that changes the speed
    }
}
