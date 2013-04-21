using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinjaAirControl.Utils;

namespace NinjaAirControl
{
    /// <summary>
    /// Holds position in the 3D space.
    /// Constructor takes as arguments longitude and altitude as geographic coordinates
    /// </summary>
    public class Position3D : IComparable
    {
        // longitude, latitude - degrees!
        // altitde - feet !
        private decimal longitude; // x
        private decimal latitude; // y
        private decimal? altitude; // z

        public Position3D(decimal longitude, decimal latitude, decimal? altitude = null)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.Altitude = altitude;
        }

        /// <summary>
        /// Property for getting longitude in Nautical Miles. 
        /// Center of the coordinate system is point 0,0 that has geographic coordinates 
        /// -180 degrees longitude and 90 degrees latitude
        /// </summary>
        public int LongitudeInNauticalMiles
        {
            get
            {
                return MeasureConverter.ConvertLongtitudeDegreesToNauticalMiles(this.Longitude);
            }
        }

        /// <summary>
        /// Property for getting latitude in Nautical Miles. 
        /// Center of the coordinate system is point 0,0 that has geographic coordinates 
        /// -180 degrees longitude and 90 degrees latitude
        /// </summary>
        public int LatitudeInNauticalMiles
        {
            get
            {
                return MeasureConverter.ConvertLatitudeDegreesToNauticalMiles(this.Latitude);
            }
        }

        public decimal Longitude
        {
            get
            {
                return this.longitude;
            }

            private set
            {
                //if (value < 0)
                //{
                //    throw new ArgumentOutOfRangeException("Longitude cannot be negative.");
                //}

                this.longitude = value;
            }
        }

        public decimal Latitude
        {
            get
            {
                return this.latitude;
            }

            private set
            {
                //if (value < 0)
                //{
                //    throw new ArgumentOutOfRangeException("Latitude cannot be negative.");
                //}

                this.latitude = value;
            }
        }

        public decimal? Altitude
        {
            get
            {
                return this.altitude;
            }

            private set
            {
                //if (value < 0)
                //{ 
                //    // Aircfraft submarine
                //    throw new ArgumentOutOfRangeException("Altitude cannot be negative.");
                //}

                this.altitude = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Longitude: {0}, Latitude: {1}, Altitude: {2}", this.longitude, this.latitude, this.altitude);
        }

        /// <summary>
        /// Compares two Position3D objects
        /// </summary>
        /// <param name="obj">takes a Position3D object</param>
        /// <returns>returns 0 if they are equal or 1 if they are different</returns>
        public int CompareTo(object obj)
        {
            var comparePosition = obj as Position3D;
            int compareResult;
            if (this.Latitude == comparePosition.Latitude &&
                this.Longitude == comparePosition.Longitude &&
                this.altitude == comparePosition.altitude)
            {
                compareResult = 0;
            }
            else
            {
                compareResult = 1;
            }

            return compareResult;
        }
    }
}