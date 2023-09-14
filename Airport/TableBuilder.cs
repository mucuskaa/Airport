using System;
using System.Collections.Generic;

namespace AirportProject
{
    internal static class TableBuilder
    {
        public static void DisplayFlights(List<Flight> flights)
        {
            if (!flights.Any())
            {
                Console.WriteLine($"I'm sorry, but there are no flights matching your request.\n");
            }
            else
            {

                string tableHeader = string.Format(
                "| {0,-7} | {1,-7} | {2,-10} | {3,-5} | {4,-22} | {5,-20} | {6,-15} | {7,-8} |",
                "Flight",
                "Status",
                "Date",
                "Time",
                "Airline",
                "Departure City",
                "Destination",
                "Terminal");

                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine($"{tableHeader}\n{new string('-', tableHeader.Length)}");

                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Black;

                foreach (var flight in flights)
                {
                    string flightInfo = string.Format(
                        "| {0,-7} | {1,-7} | {2,-10:dd:MM:yyyy} | {3,-5:HH:mm} | {4,-22} | {5,-20} | {6,-15} | {7,-8:HH:mm} |",
                        flight.FlightNumber,
                        flight.Status,
                        flight.DepartureDay,
                        flight.DepartureTime,
                        flight.Airline,
                        flight.DepartureCity,
                        flight.ArrivalCity,
                        flight.Terminal);

                    Console.WriteLine(flightInfo);
                }

                Console.ResetColor();
            }
        }
    }
}
