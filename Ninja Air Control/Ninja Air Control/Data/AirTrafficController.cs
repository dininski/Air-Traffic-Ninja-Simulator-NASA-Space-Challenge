namespace NinjaAirControl.Data
{
    /// <summary>
    /// Models Air Traffic Controller posiotion.
    /// Responsible for controlling flights in controlled airspace.
    /// Could be eighter Ground Controller, Tower Controller, Approach and En-route
    /// </summary>
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