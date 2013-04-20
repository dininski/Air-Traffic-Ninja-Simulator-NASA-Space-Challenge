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
      
        public Pilot(string name, Aircraft aircraft)
        {
            this.Name = name;
            this.Aircraft = aircraft;
        }
    }
}
