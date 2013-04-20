using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl
{
    public class Position3D
    {
        private decimal longitude; // x
        private decimal latitude; // y
        private decimal? altitude; // z

        public Position3D(decimal longitude, decimal latitude, decimal? altitude = null)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.Altitude = altitude;
        }

        public decimal Longitude
        {
            get
            {
                return this.longitude;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Latitude cannot be negative.");
                }

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
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Latitude cannot be negative.");
                }

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
                if (value < 0)
                { // Aircfraft submarine
                    throw new ArgumentOutOfRangeException("Latitude cannot be negative.");
                }

                this.altitude = value;
            }
        }
    }
}