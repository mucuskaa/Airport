using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportProject
{
    internal class DisplayInfo
    {
        public void DisplayMenu()
        {
            Console.WriteLine("\nChoose option: ");
            Console.WriteLine("1-Search flight by arrival city and date");
            Console.WriteLine("2-Search flight by departure day");
            Console.WriteLine("3-Search flight by arrival city");
            Console.WriteLine("4-Search flight by arrival date");
            Console.WriteLine("5-Search flight by departure date and time");
            Console.WriteLine("6-Search flight by number");
            Console.WriteLine("7-beck to main menu");
            Console.WriteLine("8-Quit program");
        }
        private string DisplayFlight(Flight flight)
        {
                string flightInfo = string.Format("| {0,-7} | {1,-12:dd:MM:yyyy} | {2,-13:HH:mm} | {3,-20} | {4,-20} | {5,-8:HH:mm} | {6,-8} |", flight.FlightNumber, flight.DepartureDay, flight.DepartureTime, flight.DepartureCity, flight.ArrivalCity, flight.ArrivalTime, flight.Terminal);
                string tableSeparator = new string('-', flightInfo.Length);

            return $"{tableSeparator}\n{flightInfo}";
        }

        public void DisplayTable(List<Flight> flights)
        {
            if (flights.Count == 0)
            {
                Console.WriteLine($"I'm sorry, but there are no flights matching your request.\n");
            }
            else
            {
                string tableHeader = string.Format("| {0,-7} | {1,-12:dd:MM:yyyy} | {2,-13:HH:mm} | {3,-20} | {4,-20} | {5,-8:HH:mm} | {6,-8} |", "Flight", "Day", "Departure", "Departure city", "Destination", "Arrival", "Terminal");
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{tableHeader}");
                Console.ForegroundColor = ConsoleColor.Yellow;

                foreach (var flight in flights)
                {
                    Console.WriteLine(DisplayFlight(flight));
                }
                Console.ResetColor();

            }
        }
    }
}
