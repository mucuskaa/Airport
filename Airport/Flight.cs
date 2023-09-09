using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirportProject
{
    internal class Flight : IComparable<Flight>
    {
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public TimeSpan Duration => ArrivalTime - DepartureTime;
        public DayOfWeek DaysOfWeek { get; set; }
        public City OriginCity { get; set; }
        public City DestinationCity { get; set; }
        public string Terminal { get; set; }
        public string Aircompany { get; set; }

        public Flight(DateTime departureTime, DateTime arrivalTime, string terminal, DayOfWeek daysOfWeek, City originCity, City destinationCity, string aircompany)
        {
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Terminal = terminal;
            DaysOfWeek = daysOfWeek;
            OriginCity = originCity;
            DestinationCity = destinationCity;
            Aircompany = aircompany;
        }
        public int CompareTo(Flight other)
        {
            if (this.DepartureTime < other.DepartureTime)
                return -1;
            else if (this.DepartureTime > other.DepartureTime)
                return 1;
            else
                return 0;
        }
        public override string ToString()
        {
            return $"Flight from {OriginCity} to {DestinationCity}, Departure: {DepartureTime}, Arrival: {ArrivalTime}, Terminal: {Terminal}";
        }
    }
}
