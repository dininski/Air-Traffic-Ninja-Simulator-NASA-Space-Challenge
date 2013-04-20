using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl
{
    /// <summary>
    /// An additional class holding methods for arithmetical operations, 
    /// that convert one measurement into another
    /// </summary>
    public static class MeasureConverter
    {
        public static double ConvertDegreeToRadian(double degree) 
        {
            return (Math.PI * degree) / 180;
        }
        
        public static int ConvertLongtitudeDegreesToNauticalMiles(decimal longitude)
        {
            int longitudeMax = 180;
            int longitudeMin = -180;

            if (longitude >= longitudeMin && longitude <= longitudeMax)
            {
                return (int)((180 + longitude) * 60);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Longitude is out of Range!");
            }
        }

        public static int ConvertLatitudeDegreesToNauticalMiles(decimal latitude)
        {
            int longitudeMax = 90;
            int longitudeMin = -90;

            if (latitude >= longitudeMin && latitude <= longitudeMax)
            {
                return (int)((90 - latitude) * 60);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Longitude is out of Range!");
            }
        }
    }
}