using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaAirControl.Processing
{
    public class FlightProcessor
    {
        #region Events

        public delegate void PossibleCollisionEventHandler(object sender, FlightEventArgs e);

        public delegate void ApproachingBadWeatherEventHandler(object sender, FlightEventArgs e);

        public event PossibleCollisionEventHandler PossibleCollision;

        public event ApproachingBadWeatherEventHandler ApproachingBadWeather;

        #endregion

        #region Raise Events

        private void RaiseOnApproachingBadWeather(Flight flight, WarningLevel level)
        {
            if (ApproachingBadWeather != null)
            {
                var eventArg = new FlightEventArgs();
                eventArg.WarningLevel = level;
                eventArg.Flights.Add(flight);
                ApproachingBadWeather(this, eventArg);
            }
        }

        private void RaiseOnPossibleCollision(Flight flight, Flight flight2, WarningLevel level)
        {
            if (PossibleCollision != null)
            {
                var eventArg = new FlightEventArgs();
                eventArg.WarningLevel = level;
                eventArg.Flights.Add(flight);
                eventArg.Flights.Add(flight2);
                PossibleCollision(this, eventArg);
            }
        }

        #endregion

        public void ProcessCurrentFlights()
        {
            ProcessCurrentFlights(LoadCurrentFlights());
        }

        /// <summary>
        /// This method should load all currently going flights.
        /// The source of the information is not important for this class
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Flight> LoadCurrentFlights()
        {
            //TODO Load current flights from db
            return SampleData.SampleData.GetSampleFlights();
        }

        private void ProcessCurrentFlights(IEnumerable<Flight> flights)
        {
            if (flights == null)
                return;

            var currentFlights = flights.OrderBy(x => x.CurrentPosition).ToArray();

            for (int i = 0; i< currentFlights.Count(); i++)
            {
                var flight = currentFlights[i];
                int k = i + 1;
                if(k == currentFlights.Count())
                    break; // We checked them all
                
                var flight2 = currentFlights[k];

                if (CheckForCollision(flight, flight2))
                    CheckForCollisionSolution(flight, flight2);
                if (CheckForBadWeather(flight))
                    CheckForBadWeatherSolution(flight);


            }
        }

        #region Virtual Dispacher

        private void CheckForBadWeatherSolution(Flight flight)
        {
            //throw new NotImplementedException();
            //TODO make some calculations to determine How can solve this problem
        }

        private void CheckForCollisionSolution(Flight flight, Flight flight2)
        {
            //throw new NotImplementedException();
            //TODO make calculations and try to solve this problem
        }

        #endregion

        #region Helpers

        private bool CheckForBadWeather(Flight flight)
        {
            //TODO get the weather from some online service and check if the flight is approaching bad meteorological conditions
            var rand = new Random();
            if (rand.Next(10) % 2 == 0)
            {
                RaiseOnApproachingBadWeather(flight, WarningLevel.Normal);
                return true;
            }
            else
            {
                RaiseOnApproachingBadWeather(flight, WarningLevel.High);
                return false;
            }            
        }        

        private bool CheckForCollision(Flight flight, Flight flight2)
        {
            //TODO check according to Data in Constants if the two flights are too close to each other
            
            var rand = new Random();
            if (rand.Next(10) % 2 == 0)
            {
                RaiseOnPossibleCollision(flight, flight2, WarningLevel.Normal);
                return true;
            }
            else
            {
                RaiseOnPossibleCollision(flight, flight2, WarningLevel.High);
                return false;
            }
        }

        #endregion
    }
}
