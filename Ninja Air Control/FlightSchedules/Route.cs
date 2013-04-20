using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightSchedules
{
    /// <summary>
    /// This class represent only route
    /// </summary>
    public class Route
    {
        public List<Coordinate> RoutePath { get; set; }
        public string Name { get; set; }
        public decimal Distance { get; set; }
    }
}
