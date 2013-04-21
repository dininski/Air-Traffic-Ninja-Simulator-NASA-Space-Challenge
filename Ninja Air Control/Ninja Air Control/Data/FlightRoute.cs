using System.Collections.Generic;
using NinjaAirControl.Utils;
using System;

namespace NinjaAirControl.Data
{
    /// <summary>
    /// Describes a route of an aircraft.
    /// Holds a list of fixes.
    /// </summary>
    public class FlightRoute
    {
        private List<AirspaceFix> routePoints;

        /// <summary>
        /// In order to draw the route on screen we need a list of points. 
        /// Flight are not made on straight line sometimes they go around mountains and other high stuff(towers)
        /// So we need list of point lets say between 2 miles and this list will describe the flight vector
        /// </summary>
        public List<AirspaceFix> RoutePoints
        {
            get
            {
                return this.routePoints;
            }
            private set
            {
                this.routePoints = value;
            }
        }
        
        public FlightRoute()
        { 
            RoutePoints = new List<AirspaceFix>();
        }

        public void AddFix(AirspaceFix newFix)
        {
            RoutePoints.Add(newFix);
        }

        public AirspaceFix GetNextFix()
        {
            foreach (AirspaceFix fix in routePoints)
            {
                if (!fix.IsVisited)
                {
                    return fix;
                }
            }

            throw new IndexOutOfRangeException("All fixes have been visited!");
        }
        // TODO: Remove ?
    }
}