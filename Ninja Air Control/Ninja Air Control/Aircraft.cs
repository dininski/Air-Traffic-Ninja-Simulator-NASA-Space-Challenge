using System;

namespace NinjaAirControl
{
    public class Aircraft
    {
        public AircraftIdData Identification { get; private set; }

        public AirTrafficController TrafficController { get; private set; }

        public Pilot Pilot { get; private set; }

        public FlightPlan FlightPlan { get; private set; }

        public Position3D CurrentPosition { get; private set; }

        public int Speed { get; private set; }

        public int CurrentHeadingInDegrees { get; private set; }

        public Aircraft(AircraftIdData identification,
            AirTrafficController trafficController,
            Pilot pilot,
            FlightPlan flightPlan,
            int speed,
            int currentHeadingInDegrees)
        {
            this.Identification = identification;
            this.TrafficController = trafficController;
            this.Pilot = pilot;
            this.FlightPlan = flightPlan;
            //the initial position is the position of the departure airport
            this.CurrentPosition = FlightPlan.DepartureAirport.Coordinates;
            this.Speed = speed;
            this.CurrentHeadingInDegrees = currentHeadingInDegrees;
        }

        public void UpdatePosition()
        {
            decimal newLongitude = CurrentPosition.Longitude;
            double currentHeadingInRadians = (Math.PI * CurrentHeadingInDegrees) / 180;
            newLongitude += (decimal)(Speed / Math.Sin(currentHeadingInRadians));
            decimal newLatitude = CurrentPosition.Latitude;
            newLatitude += (decimal)(Speed / Math.Cos(currentHeadingInRadians));
            this.CurrentPosition = new Position3D(newLongitude, newLatitude, CurrentPosition.Altitude);
        }
        //TODO: Calculate current position method
        //TODO: Method that changes the speed
    }
}