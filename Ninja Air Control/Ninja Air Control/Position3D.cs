using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl
{
    public class Position3D
    {
        private double longitude; // x
        private double latitude; // y
        private double? altitude; // z

        public Position3D(double longitude, double latitude, double? altitude = null)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.Altitude = altitude;
        }

        public double Longitude
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

        public double Latitude
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

        public double? Altitude
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