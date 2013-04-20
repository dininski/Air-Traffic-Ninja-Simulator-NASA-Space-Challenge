using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl
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

        public Dispatcher Dispatcher { get; private set; }

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

        public Airport(string name, Position3D coordinates, Dispatcher dispatcher)
        {
            this.Name = name;
            this.Coordinates = coordinates;
            this.ATC = new List<AirTrafficController>();
            this.Dispatcher = dispatcher;
        }

        // TODO: ADD traffic controller method


        // has:
        //-AirTrafficController - tower and ground
        //-Dispatcher
        //-number of active runways (int)
    }
}