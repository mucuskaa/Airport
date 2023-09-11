using System;

namespace AirportProject
{
    internal class Program
    {
        static void Main()
        {
            List<Flight> flights = new List<Flight>
               {
                 new Flight(DateTime.Parse("2023-09-11 10:00"), DateTime.Parse("2023-09-10 10:00"), "A", DayOfWeek.Monday, City.NewYork, City.London, "Airline1"),
                 new Flight(DateTime.Parse("2023-09-11 09:30"), DateTime.Parse("2023-09-11 11:30"), "B", DayOfWeek.Tuesday, City.Paris, City.Berlin, "Airline2"),
                 new Flight(DateTime.Parse("2023-09-10 12:00"), DateTime.Parse("2023-09-12 14:00"), "C", DayOfWeek.Wednesday, City.Rome, City.Barcelona, "Airline3"),
                 new Flight(DateTime.Parse("2023-09-10 14:30"), DateTime.Parse("2023-09-13 16:30"), "A", DayOfWeek.Thursday, City.Amsterdam, City.Berlin, "Airline4"),
                 new Flight(DateTime.Parse("2023-09-09 10:00"), DateTime.Parse("2023-09-14 12:00"), "B", DayOfWeek.Friday, City.London, City.Paris, "Airline5"),
                 new Flight(DateTime.Parse("2023-09-18 15:30"), DateTime.Parse("2023-09-15 17:30"), "C", DayOfWeek.Saturday, City.Prague, City.Vienna, "Airline6"),
                 new Flight(DateTime.Parse("2023-09-14 13:00"), DateTime.Parse("2023-09-14 15:00"), "A", DayOfWeek.Sunday, City.Madrid, City.Paris, "Airline7"),
                 new Flight(DateTime.Parse("2023-09-07 16:30"), DateTime.Parse("2023-09-17 18:30"), "B", DayOfWeek.Monday, City.Paris, City.Warsaw, "Airline8"),
                 new Flight(DateTime.Parse("2023-09-15 11:15"), DateTime.Parse("2023-09-14 13:15"), "C", DayOfWeek.Tuesday, City.Vienna, City.Paris, "Airline9"),
                 new Flight(DateTime.Parse("2023-09-14 14:45"), DateTime.Parse("2023-09-19 16:45"), "A", DayOfWeek.Wednesday, City.Barcelona, City.Paris, "Airline10"),
                 new Flight(DateTime.Parse("2023-09-01 08:30"), DateTime.Parse("2023-09-14 10:30"), "B", DayOfWeek.Thursday, City.Lisbon, City.Paris, "Airline11"),
                 new Flight(DateTime.Parse("2023-09-13 09:00"), DateTime.Parse("2023-09-21 11:00"), "C", DayOfWeek.Friday, City.Warsaw, City.Budapest, "Airline12"),
                 new Flight(DateTime.Parse("2023-09-22 11:45"), DateTime.Parse("2023-09-22 13:45"), "A", DayOfWeek.Saturday, City.Berlin, City.Amsterdam, "Airline13"),
                 new Flight(DateTime.Parse("2023-09-10 12:30"), DateTime.Parse("2023-09-23 14:30"), "B", DayOfWeek.Sunday, City.Paris, City.London, "Airline14")
             };

            Airport airport = new Airport("My Airport", flights);
            string tableHeader = string.Format("| {0,-10} | {1,-10} | {2,-20} | {3,-20} | {4,-8:HH:mm} | {5,-8} |", "Day", "Departure", "Departure city", "Destination", "Arrival", "Terminal");

        MainMenu:
            Console.WriteLine($"{new string('-', 10)}{airport.Name}{new string('-', 10)}\n");

            Console.WriteLine("Flights for today");
            Console.WriteLine($"{tableHeader}");

            var todayFlights = airport.GetFlightsForToday();
            foreach (var flight in todayFlights)
            {
                Console.WriteLine(flight);
            }

            DateTime date;
            City arrivalCity;
            string userInput;
            int option;
            bool temp = false;
            
            while (!temp)
            {
                Console.WriteLine("\nChoose option: ");
                Console.WriteLine("1-Search flight by arrival city and date");
                Console.WriteLine("2-Search flight by departureday");
                Console.WriteLine("3-Search flight by arrival city");
                Console.WriteLine("4-Search flight by arrival date");
                Console.WriteLine("5-Search flight by departure date and time");
                Console.WriteLine("6-beck to main menu");
                Console.WriteLine("7-Out program");

                while (!Int32.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Wrong input");
                }

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Enter arrival city: ");
                        userInput = Console.ReadLine();
                        while (!Enum.IsDefined(typeof(City), userInput))
                        {
                            Console.WriteLine($"I'm sorry, but we do not have flights to that city at the moment.\nPlease choose another destination ");
                            userInput = Console.ReadLine();
                        }
                        arrivalCity = (City)Enum.Parse(typeof(City), userInput, true);

                        Console.Write("Enter date of departure(yyyy-MM-dd) : ");
                        while (!DateTime.TryParse(Console.ReadLine(), out date))
                        {
                            Console.WriteLine("Wrong input");
                        }
                        var flightsForDateAndCity = airport.SearchByArrivalCityAndDate(arrivalCity, date);

                        if (flightsForDateAndCity.Count==0)
                        {
                            Console.WriteLine($"I'm sorry, but we do not have flights to that city and date at the moment.");

                        }
                        else {
                            Console.WriteLine("Table: ");
                            Console.WriteLine($"{tableHeader}");
                            
                            foreach (var flight in flightsForDateAndCity)
                            {
                                Console.WriteLine(flight);
                            } 
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Enter date of departure(yyyy-MM-dd) : ");
                        while (!DateTime.TryParse(Console.ReadLine(), out date))
                        {
                            Console.WriteLine("Wrong input");
                        }
                        var flightsForDate = airport.SearchByDate(date);

                        if (flightsForDate.Count == 0)
                        {
                            Console.WriteLine($"I'm sorry, but we do not have flights for that date at the moment.");

                        }
                        else
                        {
                            Console.WriteLine("Table: ");
                            Console.WriteLine($"{tableHeader}");

                            foreach (var flight in flightsForDate)
                            {
                                Console.WriteLine(flight);
                            }
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter arrival city: ");
                        userInput = Console.ReadLine();
                        while (!Enum.IsDefined(typeof(City), userInput))
                        {
                            Console.WriteLine($"I'm sorry, but we do not have flights to that city at the moment.\nPlease choose another destination ");
                            userInput = Console.ReadLine();
                        }
                        arrivalCity = (City)Enum.Parse(typeof(City), userInput, true);

                        var flightsForCity = airport.SearchByArrivalCity(arrivalCity);

                        if (flightsForCity.Count == 0)
                        {
                            Console.WriteLine($"I'm sorry, but we do not have flights to that city at the moment.");
                        }
                        else
                        {
                            Console.WriteLine("Table: ");
                            Console.WriteLine($"{tableHeader}");

                            foreach (var flight in flightsForCity)
                            {
                                Console.WriteLine(flight);
                            }
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Enter arrival date (yyyy-MM-dd) : ");
                        while (!DateTime.TryParse(Console.ReadLine(), out date))
                        {
                            Console.WriteLine("Wrong input");
                        }
                        var flightsForAerivalDate = airport.SearchByArrivalDate(date);

                        if (flightsForAerivalDate.Count == 0)
                        {
                            Console.WriteLine($"I'm sorry, but we do not have flights to that date at the moment.");
                        }
                        else
                        {
                            Console.WriteLine("Table: ");
                            Console.WriteLine($"{tableHeader}");

                            foreach (var flight in flightsForAerivalDate)
                            {
                                Console.WriteLine(flight);
                            }
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.Write("Enter arrival date (yyyy-MM-dd hh:mm) : ");
                        while (!DateTime.TryParse(Console.ReadLine(), out date))
                        {
                            Console.WriteLine("Wrong input");
                        }
                        var flightsForDepartureDateTime = airport.SearchByDepartureDateTime(date);

                        if (flightsForDepartureDateTime.Count == 0)
                        {
                            Console.WriteLine($"I'm sorry, but we do not have flights to that date at the moment.");
                        }
                        else
                        {
                            Console.WriteLine("Table: ");
                            Console.WriteLine($"{tableHeader}");

                            foreach (var flight in flightsForDepartureDateTime)
                            {
                                Console.WriteLine(flight);
                            }
                        }
                        break;
                    case 6:
                        Console.Clear();
                        goto MainMenu;
                        break;
                    case 7:
                        Console.WriteLine("----------Good bye----------");
                        temp = true;
                        break;
                }

            }
        }

    }
}