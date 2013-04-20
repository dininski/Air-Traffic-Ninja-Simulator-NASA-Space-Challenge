using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl
{
    public class FlightRoute
    {
        private List<AirspaceFix> route;

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