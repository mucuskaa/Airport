using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirportProject
{
    internal class Flight
    {
        public DateTime DepartureDay { get; set; }
        public DateTime ArrivalDay { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public TimeSpan Duration => ArrivalTime - DepartureTime;
        public DayOfWeek DaysOfWeek { get; set; }
        public City OriginCity { get; set; }
        public City ArrivalCity { get; set; }
        public string Terminal { get; set; }
        public string Aircompany { get; set; }

        private static  bool isTableHeaderPrinted = false;

        public Flight(DateTime departureTime, DateTime arrivalTime, string terminal, DayOfWeek daysOfWeek, City originCity, City destinationCity, string aircompany)
        {
            DepartureDay = departureTime.Date;
            ArrivalDay = arrivalTime.Date;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Terminal = terminal;
            DaysOfWeek = daysOfWeek;
            OriginCity = originCity;
            ArrivalCity = destinationCity;
            Aircompany = aircompany;
        }
        public override string ToString()
        {
            string flightInfo = string.Format("| {0,-10:dd:MM:yyyy} | {1,-10:HH:mm} | {2,-20} | {3,-20} | {4,-8:HH:mm} | {5,-8} |", DepartureDay, DepartureTime, OriginCity, ArrivalCity, ArrivalTime, Terminal);

            string tableSeparator = new string('-', flightInfo.Length);

            if (!isTableHeaderPrinted)
            {
                string tableHeader = string.Format("| {0,-10} | {1,-10} | {2,-20} | {3,-20} | {4,-8:HH:mm} | {5,-8} |", "Day", "Departure", "Departure city", "Destination", "Arrival", "Terminal");
                string headerSeparator = new string('-', tableHeader.Length);
                string table = $"{headerSeparator}\n{flightInfo}";
                isTableHeaderPrinted = true;
                return table;
            }

            return $"{tableSeparator}\n{flightInfo}";

        }
    }
}
