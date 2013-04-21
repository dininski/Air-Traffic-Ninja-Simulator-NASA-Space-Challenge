using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinjaAirControl.Data;

namespace NinjaAirControl.Processing.SampleData
{
    public class SampleData
    {
        public static IEnumerable<Flight> GetSampleFlights()
        {
            var result = new List<Flight>()
                             {
                                 new Flight(GetAricraft(1), new Person("Pilot" + 1),  GetFlightPlan(1), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 11),  GetFlightPlan(11), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 111),  GetFlightPlan(111), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 1111),  GetFlightPlan(1111), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 11111),  GetFlightPlan(11111), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 111111),  GetFlightPlan(111111), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 2),  GetFlightPlan(2), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 22),  GetFlightPlan(22), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 222),  GetFlightPlan(222), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 2222),  GetFlightPlan(2222), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 22222),  GetFlightPlan(22222), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 3),  GetFlightPlan(3), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 33),  GetFlightPlan(33), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 333),  GetFlightPlan(333), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 3333),  GetFlightPlan(3333), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 33333),  GetFlightPlan(33333), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 4),  GetFlightPlan(4), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 44),  GetFlightPlan(44), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 444),  GetFlightPlan(444), "don't know what this is"),
                                 new Flight(GetAricraft(1), new Person("Pilot" + 4444),  GetFlightPlan(4444), "don't know what this is"),
                             };
            return result;
        }

        private static Aircraft GetAricraft(int number)
        {
            return new Aircraft(new AircraftIdData(number.ToString(), "Sample model "+ number, "Airline " + number, true), 50);
        }

        private static FlightPlan GetFlightPlan(int number)
        {
            return new FlightPlan(new Airport("Airport" + number, new Position3D(23, 34, 2), new Person("Dispacher" + number)),
                new Airport("Airport" + number + 1, new Position3D(23, 34, 2), new Person("Dispacher" + number + 1)),
                DateTime.Now, DateTime.Now.AddHours(2), 40, new FlightRoute(), 10, FlightType.Scheduled);
        }
    }
}
