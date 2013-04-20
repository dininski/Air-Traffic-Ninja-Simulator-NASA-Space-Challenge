using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl
{
    public class AirControlEngine
    {
        private List<Aircraft> allAircraft;
        private List<Airport> allAirports;

        public AirControlEngine(List<Aircraft> initialAircraft)
        {
            allAircraft = new List<Aircraft>();
            allAirports = new List<Airport>();
        }

        public void Start()
        {
            //while (true)
            //{
                //aircrafts update position
            //}
        }
    }
}
