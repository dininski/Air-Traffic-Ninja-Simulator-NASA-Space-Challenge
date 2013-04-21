using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinjaAirControl.Data;

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

        public virtual void InitializeSimultion()
        {
            Airport newAirport=new Airport("John F. Kennedy International Airport", new Position3D( -90.9187999m,46.5482781m,251),new Person("John Kennedy"));
            allAirports.Add(newAirport);
        }

        public virtual void Start()
        {
        }
    }
}