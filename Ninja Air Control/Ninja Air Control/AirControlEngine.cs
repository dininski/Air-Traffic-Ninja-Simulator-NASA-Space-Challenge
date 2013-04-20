using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl
{
    /// <summary>
    /// Represents game engine. Is responsible for running the simulation. 
    /// </summary>
    public class AirControlEngine
    {
        private List<Aircraft> allAircraft;
        private List<Airport> allAirports;

        public AirControlEngine(List<Aircraft> initialAircraft)
        {
            this.allAircraft = new List<Aircraft>();
            this.allAirports = new List<Airport>();
        }

        public void Start()
        {
            // while (true)
            // {
            // aircrafts update position
            // }
        }
    }
}