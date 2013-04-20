namespace FlightSchedules.Aircrafts
{
    public abstract class Aircraft
    {
        //        Categories.
        //B. Weight classes.
        //C. Designators.
        //D. Performance characteristics.
        //E. Identification features.
        public AircraftCategories Category { get; set; }
        public AircraftTypes Type { get; set; }
        public decimal OptimalSpeedInKilometersPerHours { get; set; }
        public decimal MaximumSpeedInKilometersPerHours { get; set; }
        public decimal WeightInKilograms { get; set; }
        public decimal FuelConsumptionPerHour { get; set; }
        public int PassangersCount { get; set; }
        public string IdentificationNumber { get; set; }

    }
}
