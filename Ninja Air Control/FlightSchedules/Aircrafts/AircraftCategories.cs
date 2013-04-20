namespace FlightSchedules.Aircrafts
{
    public enum AircraftCategories
    {
        /// <summary>
        /// Weight: 12,500 lbs. or less 
        /// Single-engine
        /// Propeller-driven
        /// Includes All helicopters
        /// Other information:
        /// Speed: 100-160 knots
        /// Altitude: 10,000 feet and below
        /// Climb Rate: 1,000 feet per minute or less
        /// Weight Class: Small (S)
        /// </summary>
        CategoryI,

        /// <summary>
        /// Weight: 12,500 lbs. or less
        /// Twin-engine
        /// Propeller-driven
        /// Other information:
        /// Speed: 160-250 knots
        /// Altitude: FL240 and below
        /// Climb Rate: 1,000-2,000 feet per minute
        /// Weight Class: Small (S)
        /// </summary>
        CategoryII,

        /// <summary>
        /// All not included in categoryI and categoryII
        /// Speed: 300-550 knots
        /// Altitude: FL450 and below
        /// Climb Rate: 2,000-4,000 feet per minute
        /// </summary>
        CategoryIII
    }
}
