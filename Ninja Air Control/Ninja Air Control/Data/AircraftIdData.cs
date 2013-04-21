namespace NinjaAirControl.Data
{
    /// <summary>
    /// Hold data concerning an aircraft
    /// </summary>
    public struct AircraftIdData
    {
        public string Id { get; private set; }
        public string Model { get; private set; }
        public string Airline { get; private set; }
        public bool HasRvsmEquipment { get; private set; }

        public AircraftIdData(string id, 
            string model, 
            string airline, 
            bool hasRvsmEquipment) : this()
        {
            this.Id = id;
            this.Model = model;
            this.Airline = airline;
            this.HasRvsmEquipment = hasRvsmEquipment;
        }
    }
}
