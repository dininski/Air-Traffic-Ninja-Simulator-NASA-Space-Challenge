using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninja_Air_Control
{
    public class Airport
    {
        public Position3D Coordinates { get; set; }
        // has:
        //-AirTrafficController - tower and ground
        //-Dispatcher
        //-number of active runways (int)
    }
}
