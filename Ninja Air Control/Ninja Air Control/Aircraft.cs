using System;

namespace NinjaAirControl
{
    public class Aircraft
    {
        public AircraftIdData Identification { get; private set; }

        public AirTrafficController TrafficController { get; private set; }

        public Position3D CurrentPosition { get; private set; }

        public int Speed { get; private set; }

        public int CurrentHeadingInDegrees { get; private set; }
        
        private DateTime lastUpdated; 

        public Aircraft(AircraftIdData identification,
            AirTrafficController trafficController,
            FlightPlan flightPlan,
            int speed,
            int currentHeadingInDegrees)
        {
            this.Identification = identification;
            this.TrafficController = trafficController;
            //the initial position is the position of the departure airport
            this.CurrentPosition = flightPlan.DepartureAirport.Coordinates;
            this.lastUpdated = flightPlan.DepartureDateTime;
            this.Speed = speed;
            this.CurrentHeadingInDegrees = currentHeadingInDegrees;
        }

        public void UpdatePosition()
        {
            double currentHeadingInRadians = MeasureConverter.ConvertDegreeToRadian(CurrentHeadingInDegrees);
            decimal newLongitude = CurrentPosition.Longitude;
            decimal newLatitude = CurrentPosition.Latitude;
            DateTime currentDateTime= new DateTime();
            int distanceElapsed = (currentDateTime - lastUpdated).Hours * Speed;
            newLongitude += (decimal)(distanceElapsed * Math.Sin(currentHeadingInRadians));
            newLatitude += (decimal)(distanceElapsed * Math.Cos(currentHeadingInRadians));
            this.CurrentPosition = new Position3D(newLongitude, newLatitude, CurrentPosition.Altitude);
            lastUpdated = currentDateTime;
        }
        //TODO: Calculate current position method
        //TODO: Method that changes the speed
    }
}