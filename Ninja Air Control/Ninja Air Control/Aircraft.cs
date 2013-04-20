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

        public bool HasLanded { get; private set; }

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
            HasLanded = false;
        }

        public void UpdatePosition()
        {
            double currentHeadingInRadians = MeasureConverter.ConvertDegreeToRadian(CurrentHeadingInDegrees);
            decimal newLongitude = CurrentPosition.Longitude;
            decimal newLatitude = CurrentPosition.Latitude;
            newLongitude += (decimal)(Speed * Math.Sin(currentHeadingInRadians));
            newLatitude += (decimal)(Speed * Math.Cos(currentHeadingInRadians));
            this.CurrentPosition = new Position3D(newLongitude, newLatitude, CurrentPosition.Altitude);

            if (CurrentPosition.CompareTo(FlightPlan.ArrivalAirport.Coordinates) == 0)
            {
                HasLanded = true;
            }
        }
        //TODO: Calculate current position method
        //TODO: Method that changes the speed
    }
}