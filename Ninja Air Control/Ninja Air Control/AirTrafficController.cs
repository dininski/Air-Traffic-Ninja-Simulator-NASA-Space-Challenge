using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl
{
    public class AirTrafficController
    {
        private TrafficControllerType controllerType;

        public TrafficControllerType ControllerType
        {
            get
            {
                return controllerType;
            }
            private set
            {
                controllerType = value;
            }
        }
        
        public AirTrafficController(TrafficControllerType controllerType)
        {
            this.ControllerType = controllerType;
        }
    }
}