using System;
using System.Collections.Generic;

namespace AirportProject
{
    internal static class TableBuilder
    {
        private static void DisplayTable(List<Flight> flights, bool showDepartureCity)
        {
            if (!flights.Any())
            {
                Console.WriteLine($"I'm sorry, but there are no flights matching your request.\n");
            }
            else
            {
                string tableHeader = string.Format(
                    "| {0,-7} | {1,-7} | {2,-12} | {3,-12} | {4,-25} | {5,-20} | {6,-8} |",
                    "Flight",
                    "Status",
                    "Date",
                    "Time",
                    "Airline",
                    showDepartureCity ? "Departure City" : "Destination",
                    "Terminal");

                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine($"{tableHeader}\n{new string('-',tableHeader.Length)}");

                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Black;

                foreach (var flight in flights)
                {
                    string flightInfo = string.Format(
                        "| {0,-7} | {1,-7} | {2,-12:dd:MM:yyyy} | {3,-12:HH:mm} | {4,-25} | {5,-20} | {6,-8:HH:mm} |",
                        flight.FlightNumber,
                        flight.Status,
                        flight.DepartureDay,
                        flight.DepartureTime,
                        flight.Airline,
                        showDepartureCity ? flight.DepartureCity : flight.ArrivalCity,
                        flight.Terminal);

                    Console.WriteLine(flightInfo);
                }

                Console.ResetColor();
            }
        }

        public static void  DisplayArrivalTable(List<Flight> flights)
        {
            DisplayTable(flights, false); 
        }

        public static void DisplayDepartureTable(List<Flight> flights)
        {
            DisplayTable(flights, true);
        }
    }
}
