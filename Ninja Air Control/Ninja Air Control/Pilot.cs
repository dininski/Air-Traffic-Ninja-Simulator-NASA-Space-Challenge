using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl
{
    public class Pilot
    {
        public string Name { get; private set; }
        public Aircraft Aircraft { get; private set; }

        public Pilot(string name)
        {
            this.Name = name;
        }

        public void SetAircraft(Aircraft pilotedAircraft)
        {
            this.Aircraft = pilotedAircraft;
        }
    }
}
