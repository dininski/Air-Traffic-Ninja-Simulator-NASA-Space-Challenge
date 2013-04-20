using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl
{
    public class Dispatcher
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                name = value;
            }
        }

        public Dispatcher(string name)
        {
            this.Name = name;
        }
    }
}