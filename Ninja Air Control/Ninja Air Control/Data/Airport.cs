using System.Collections.Generic;

namespace NinjaAirControl.Data
{
    public class Airport
    {
        private int activeRunwaysCount;
        private List<AirTrafficController> airTrafficController;
        private string name;
            
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                name = value;
            }
        }
        
        public Position3D Coordinates { get; private set; }

        public List<AirTrafficController> ATC
        {
            get
            {
                return this.airTrafficController;
            }
            private set
            {
                this.ATC = airTrafficController;
            }
        }

        public Person Dispatcher { get; private set; }

        public int ActiveRunwaysCount
        {
            get
            {
                return activeRunwaysCount;
            }
            private set
            {
                activeRunwaysCount = value;
            }
        }

        public Airport(string name, Position3D coordinates, Person dispatcher)
        {
            this.Name = name;
            this.Coordinates = coordinates;
            this.airTrafficController = new List<AirTrafficController>();
            this.Dispatcher = dispatcher;
        }
        // TODO: ADD traffic controller method
    }
}