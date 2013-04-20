using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl
{
    /// <summary>
    /// Describes a route of an aircraft.
    /// Holds a list of fixes.
    /// </summary>
    public class FlightRoute
    {
        private List<AirspaceFix> route;

        /// <summary>
        /// In order to draw the route on screen we need a list of points. 
        /// Flight are not made on straight line sometimes they go around mountains and other high stuff(towers)
        /// So we need list of point lets say between 2 miles and this list will describe the flight vector
        /// </summary>
        public List<Position3D> FlightPath { get; set; }

        public List<AirspaceFix> Route
        {
            get
            {
                return this.route;
            }
            private set
            {
                this.route = value;
            }
        }
        
        public FlightRoute()
        { 
            Route = new List<AirspaceFix>();
        }

        public void AddFix(AirspaceFix newFix)
        {
            Route.Add(newFix);
        }
        // TODO: Remove ?
    }
}