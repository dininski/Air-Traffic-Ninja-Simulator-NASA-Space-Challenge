using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl
{
    public static class MeasureConverter
    {
        public static double ConvertDegreeToRadian(double degree) 
        {
            return (Math.PI * degree) / 180;
        }

        //gps coordinates to cartesian coordinate and reverse
    }
}
