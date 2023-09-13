using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirportProject
{
    internal class Flight
    {
        public DateTime DepartureDay { get; }
        public DateTime ArrivalDay { get; }
        public DateTime DepartureTime { get; }
        public DateTime ArrivalTime { get; }
        public TimeSpan Duration => ArrivalTime - DepartureTime;
        public City DepartureCity { get; }
        public City ArrivalCity { get; }
        public string Terminal { get; }
        public string Airline { get; }
        public string FlightNumber { get; }
        public string Status { get; }
        public Direction Direction { get; set; }


        public Flight(
            DateTime departureTime, 
            DateTime arrivalTime, 
            string terminal, 
            City originCity, 
            City destinationCity, 
            string aircompany, 
            string flightNumber,
            string status,
            Direction direction = Direction.Arraiving)
        {
            DepartureDay = departureTime.Date;
            ArrivalDay = arrivalTime.Date;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Terminal = terminal;
            DepartureCity = originCity;
            ArrivalCity = destinationCity;
            Airline = aircompany;
            FlightNumber = flightNumber;
            Status = status;
            Direction = direction;
        }
    }
}
