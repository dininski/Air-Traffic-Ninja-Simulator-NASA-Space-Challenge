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
            Pilot pilot, FlightPlan flightPlan, 
            Position3D currentPosition, 
            int speed, 
            int currentHeadingInDegrees)
        {
            this.Identification = identification;
            this.TrafficController = trafficController;
            this.Pilot = pilot;
            this.FlightPlan = flightPlan;
            this.CurrentPosition = currentPosition;
            this.Speed = speed;
            this.CurrentHeadingInDegrees = currentHeadingInDegrees;
        }

        //TODO: Calculate current position method
        //TODO: Method that changes the speed
    }
}