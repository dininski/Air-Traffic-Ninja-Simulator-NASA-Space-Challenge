namespace NinjaAirControl.Data
{
    /// <summary>
    /// This class should not contain data connected with the flight. 
    /// It's wrong what shall we do such data when the plane lands?
    /// Should unite this with AircraftIdData
    /// </summary>
    public class Aircraft
    {
        public AircraftIdData Identification { get; private set; }               

        public int MaximumSpeed { get; private set; }

        public int OptimalSpeed { get; set; }

        public Aircraft(AircraftIdData identification, int speed)
        {
            this.Identification = identification;
            this.MaximumSpeed = speed;
        }
    }
}