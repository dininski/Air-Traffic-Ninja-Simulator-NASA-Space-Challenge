using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightSchedules
{
    public class AirPort
    {
        public string Name { get; set; }
        public Coordinate Coordinates { get; set; }
        public string Country { get; set; }

        public IEnumerable<Route> RoutesFromThisAirPort { get; set; }
    }
}
