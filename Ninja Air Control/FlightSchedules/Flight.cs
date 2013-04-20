using FlightSchedules.Aircrafts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightSchedules.Persons;

namespace FlightSchedules
{
    public class Flight
    {
        public Aircraft Aircraft { get; set; }

        public AirPort DepartureAirport { get; set; }

        public AirPort ArrivalAirport { get; set; }

        public int Passangers { get; set; }

        public Route Route { get; set; }

        public PersonInformation FlightCoordinator { get; set; }

        public List<PersonInformation> Pilots { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public DateTime EstimatedArrivalDateTime { get; set; }

    }
}
