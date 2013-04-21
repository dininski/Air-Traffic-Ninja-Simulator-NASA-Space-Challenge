using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl
{
    public class ConflictDetector
    {
        public List<Flight> AllFlights { get; private set; }
        public bool HasConflict { get; private set; }

        public ConflictDetector()
        {
            this.AllFlights = new List<Flight>();
            this.HasConflict=false;
        }

        public ConflictDetector(List<Flight> allFlights)
        {
            this.AllFlights = new List<Flight>(allFlights);
            this.HasConflict=false;
        }

        public void AddFlight(Flight newFlight) 
        {
            AllFlights.Add(newFlight);
        }

        public bool CheckForConflict()
        {
            int numberOfFlights = AllFlights.Count;
            for (int flightCountOuter = 0; flightCountOuter < numberOfFlights-1; flightCountOuter++)
            {
                for (int flightCountInner = numberOfFlights+1; flightCountInner < numberOfFlights; flightCountInner++)
                {
                    decimal altitudeFirstAircraft=(decimal)(AllFlights[flightCountInner].CurrentPosition.Altitude);
                    decimal altitudeSecondAircraft = (decimal)(AllFlights[flightCountOuter].CurrentPosition.Altitude);
                    decimal minVerticalSeparation = FindMinimalVerticalSeparation(flightCountInner, flightCountOuter);
                    if (Math.Abs(altitudeFirstAircraft - altitudeSecondAircraft) < minVerticalSeparation)
                    {
                        decimal latitudeFirtAircraft=AllFlights[flightCountInner].CurrentPosition.Latitude;
                        decimal latitudeSecondAircraft = AllFlights[flightCountOuter].CurrentPosition.Latitude;
                        decimal longitudeFirstAircraft = AllFlights[flightCountInner].CurrentPosition.Longitude;
                        decimal longitudeSecondAircraft = AllFlights[flightCountOuter].CurrentPosition.Longitude;
                        decimal minHorizontalSeparation=FindMinimalHorizontalSeparation(AllFlights[flightCountInner], 
                            AllFlights[flightCountOuter]);
                        decimal aircraftDistance = FindDistanceBetweenAircrafts(latitudeFirtAircraft, latitudeSecondAircraft, 
                            longitudeFirstAircraft, longitudeSecondAircraft);
                        if (aircraftDistance<minHorizontalSeparation)
                        {
                            HasConflict = true;
                        }
                    }
                }
            }

            return HasConflict;
        }

        private decimal FindDistanceBetweenAircrafts(decimal latitudeFirtAircraft, decimal latitudeSecondAircraft,
            decimal longitudeFirstAircraft, decimal longitudeSecondAircraft)
        {
            double distance = Math.Sqrt((double)((latitudeFirtAircraft - latitudeSecondAircraft) * (latitudeFirtAircraft - latitudeSecondAircraft)+
                (longitudeFirstAircraft - longitudeSecondAircraft) * (longitudeFirstAircraft - longitudeSecondAircraft)));
            return (decimal)distance;
        }

        private decimal FindMinimalHorizontalSeparation(Flight firstFlight, Flight secondFlight)
        {
            if (firstFlight.TrafficController.ControllerType== Data.TrafficControllerType.Approach ||
                secondFlight.TrafficController.ControllerType== Data.TrafficControllerType.Approach)
            {
                return 3;
            }
            {
                return 5;
            }
        }
  
        private decimal FindMinimalVerticalSeparation(int flightCountInner, int flightCountOuter)
        {
            if (AllFlights[flightCountInner].Aircraft.Identification.HasRvsmEquipment && AllFlights[flightCountOuter].Aircraft.Identification.HasRvsmEquipment)
            {
               return 1000;
            }
            else
            {
                return 2000;
            }
        }
    }
}
