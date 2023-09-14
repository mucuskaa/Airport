using System;

namespace AirportProject
{
    internal class Program
    {
        static void Main()
        {
            List<Flight> flights = GetFlightsFromDB();
            DateTime date;
            City userCity;
            string userInput;
            int option, secondOption;
            bool temp = false;

            Airport airport = new Airport("SkyHarbor Airport", flights);

        MainMenu:
            Console.WriteLine($"{new string('-', 10)}{airport.Name}{new string('-', 10)}");

            while (!temp)
            {
                DisplayMainMenu();

                while (!Int32.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Wrong input");
                }

                switch (option)
                {
                    case 1:
                        {
                            Console.Clear();

                            var todayArrivals = airport.GetArrivingFlightsForToday(City.Kyiv);
                            TableBuilder.DisplayFlights(todayArrivals);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();

                            var todaydepartures = airport.GetDepartingFlightsForToday(DateTime.Now);
                            TableBuilder.DisplayFlights(todaydepartures);
                            break;
                        }
                    case 3:
                        {
                            DisplayFirstSubMenu();
                            while (!Int32.TryParse(Console.ReadLine(), out secondOption))
                            {
                                Console.WriteLine("Wrong input");
                            }
                            switch (secondOption)
                            {
                                case 1:
                                    {
                                        Console.Clear();
                                        Console.Write("Enter arrival city: ");
                                        userInput = Console.ReadLine();
                                        userCity = Validator.ValidateCity(userInput);

                                        Console.Write("Enter departure date (yyyy-MM-dd) : ");
                                        userInput = Console.ReadLine();
                                        date = Validator.ValidateDate(userInput);

                                        var flightsByDestinationAndDate = airport.SearchByArrivalCityAndDate(userCity, date);
                                        TableBuilder.DisplayFlights(flightsByDestinationAndDate);
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.Clear();
                                        Console.Write("Enter flight number: ");
                                        string numberInput = Console.ReadLine();

                                        Console.Write("Enter departure date (yyyy-MM-dd) : ");
                                        userInput = Console.ReadLine();
                                        date = Validator.ValidateDate(userInput);

                                        var flightsByNumberAndDate = airport.SearchByFlightNumberAndDate(numberInput, date);
                                        TableBuilder.DisplayFlights(flightsByNumberAndDate);
                                        break;
                                    }
                            }

                            break;
                        }
                    case 4:
                        {
                            DisplaySecondSubMenu();
                            while (!Int32.TryParse(Console.ReadLine(), out secondOption))
                            {
                                Console.WriteLine("Wrong input");
                            }
                            switch (secondOption)
                            {
                                case 1:
                                    {
                                        Console.Clear();
                                        Console.Write("Enter departure city: ");
                                        userInput = Console.ReadLine();
                                        userCity = Validator.ValidateCity(userInput);

                                        Console.Write("Enter departure date (yyyy-MM-dd) : ");
                                        userInput = Console.ReadLine();
                                        date = Validator.ValidateDate(userInput);

                                        var flightsByDestinationAndDate = airport.SearchByDepartureCityAndDate(userCity, date);
                                        TableBuilder.DisplayFlights(flightsByDestinationAndDate);
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.Clear();
                                        Console.Write("Enter flight number: ");
                                        string numberInput = Console.ReadLine();

                                        Console.Write("Enter departure date (yyyy-MM-dd) : ");
                                        userInput = Console.ReadLine();
                                        date = Validator.ValidateDate(userInput);

                                        var flightsByNumberAndDate = airport.SearchByFlightNumberAndDate(numberInput, date);
                                        TableBuilder.DisplayFlights(flightsByNumberAndDate);
                                        break;
                                    }
                            }
                            break;
                        }
                    case 5:
                        Console.Clear();
                        goto MainMenu;
                    case 6:
                        Console.WriteLine("----------Good bye----------");
                        temp = true;
                        break;
                }

            }

            static List<Flight> GetFlightsFromDB()
            {
                return new List<Flight>
             {
                 new Flight(DateTime.Now.AddHours(1).AddMinutes(-19), DateTime.Now.AddHours(1).AddMinutes(19), "A", City.Kyiv, City.London, "SkyWings Airlines", "AA345", "On Time",Direction.Departing),
                 new Flight(DateTime.Now.AddHours(1).AddMinutes(33), DateTime.Now.AddHours(2).AddMinutes(33), "B", City.Kyiv, City.Berlin, "AeroJet Express", "DL678", "Delayed",Direction.Departing),
                 new Flight(DateTime.Now.AddHours(2).AddMinutes(-27), DateTime.Now.AddHours(3).AddMinutes(27), "C", City.Kyiv, City.Barcelona, "Horizon Airline", "UA123", "On Time",Direction.Departing),
                 new Flight(DateTime.Now.AddMinutes(40), DateTime.Now.AddHours(2).AddMinutes(41), "A", City.Kyiv, City.Berlin, "StarStream Airways", "AA355", "On Time", Direction.Departing),
                 new Flight(DateTime.Now.AddMinutes(15), DateTime.Now.AddHours(1).AddMinutes(27), "C", City.Kyiv, City.Vienna, "OceanAir International", "UA223", "Delayed", Direction.Departing),

                 new Flight(DateTime.Now.AddHours(2).AddMinutes(-19), DateTime.Now.AddHours(3).AddMinutes(19), "A", City.NewYork, City.Kyiv, "Horizon Airline", "AI345", "On Time"),
                 new Flight(DateTime.Now.AddMinutes(33), DateTime.Now.AddHours(2).AddMinutes(33), "B", City.Paris, City.Kyiv, "SkyWings Airlines", "DL778", "On Time"),
                 new Flight(DateTime.Now.AddHours(1).AddMinutes(-27), DateTime.Now.AddHours(2).AddMinutes(27), "C", City.Rome, City.Kyiv, "AeroJet Express", "UA823", "Delayed"),
                 new Flight(DateTime.Now.AddMinutes(40), DateTime.Now.AddHours(1).AddMinutes(41), "A", City.Amsterdam, City.Kyiv, "SkyWings Airlines", "AA375", "On Time"),
                 new Flight(DateTime.Now.AddHours(1).AddMinutes(7), DateTime.Now.AddHours(2).AddMinutes(3), "B", City.London, City.Kyiv, "OceanAir International", "WR678", "On Time"),
                 new Flight(DateTime.Now.AddHours(1).AddMinutes(15), DateTime.Now.AddHours(2).AddMinutes(27), "C", City.Prague, City.Kyiv, "SkyWings Airlines", "OL322", "On Time"),

                 new Flight(DateTime.Parse("2023-09-01 13:00"), DateTime.Parse("2023-09-01 15:00"), "A", City.Madrid, City.Kyiv, "AeroJet Express", "TYA534", "On Time"),
                 new Flight(DateTime.Parse("2023-09-10 16:30"), DateTime.Parse("2023-09-10 18:30"), "B", City.Kyiv, City.Warsaw, "SkyWings Airlines", "BA456", "On Time", Direction.Departing),
                 new Flight(DateTime.Parse("2023-09-07 11:15"), DateTime.Parse("2023-09-07 13:15"), "C", City.Vienna, City.Kyiv, "OceanAir International", "SQ789", "Delayed"),
                 new Flight(DateTime.Parse("2023-09-14 14:45"), DateTime.Parse("2023-09-14 16:45"), "A", City.Kyiv, City.Paris, "SunRise Airlines", "MN356", "On Time", Direction.Departing),
                 new Flight(DateTime.Parse("2023-09-17 08:30"), DateTime.Parse("2023-09-17 10:30"), "B", City.Lisbon, City.Kyiv, "StarStream Airways", "UT908", "On Time"),
                 new Flight(DateTime.Parse("2023-09-08 09:00"), DateTime.Parse("2023-09-08 11:00"), "C", City.Kyiv, City.Budapest, "SkyWings Airlines", "BC547", "Delayed",Direction.Departing),
                 new Flight(DateTime.Parse("2023-09-22 11:45"), DateTime.Parse("2023-09-22 13:45"), "A", City.Berlin, City.Kyiv, "Horizon Airline", "FH712", "On Time"),
                 new Flight(DateTime.Parse("2023-09-13 13:30"), DateTime.Parse("2023-09-13 14:30"), "B", City.Kyiv, City.NewYork, "AeroJet Express", "RD905", "On Time", Direction.Departing),
                 new Flight(DateTime.Parse("2023-09-20 09:15"), DateTime.Parse("2023-09-20 11:15"), "C", City.Kyiv, City.Berlin, "KyivAir", "KA987", "On Time", Direction.Departing),
                 new Flight(DateTime.Parse("2023-09-21 18:45"), DateTime.Parse("2023-09-21 20:45"), "B", City.Kyiv, City.Paris, "EuroWings", "EW321", "On Time", Direction.Departing),
                 new Flight(DateTime.Parse("2023-09-12 13:30"), DateTime.Parse("2023-09-12 15:30"), "C", City.Kyiv, City.Rome, "SkyItalia", "SI654", "On Time", Direction.Departing),
                 new Flight(DateTime.Parse("2023-09-16 16:00"), DateTime.Parse("2023-09-16 18:00"), "A", City.Kyiv, City.London, "BritAirways", "BA789", "On Time", Direction.Departing),
                 new Flight(DateTime.Parse("2023-09-30 11:30"), DateTime.Parse("2023-09-30 13:30"), "A", City.Kyiv, City.Amsterdam, "HollandAir", "HA456", "On Time", Direction.Departing),
                 new Flight(DateTime.Parse("2023-09-20 09:15"), DateTime.Parse("2023-09-20 11:15"), "C", City.Prague, City.Kyiv, "KyivAir", "KA987", "On Time"),
                 new Flight(DateTime.Parse("2023-09-22 18:45"), DateTime.Parse("2023-09-22 20:45"), "B", City.Amsterdam, City.Kyiv, "EuroWings", "EW321", "On Time"),
                 new Flight(DateTime.Parse("2023-09-25 13:30"), DateTime.Parse("2023-09-25 15:30"), "B", City.Vienna, City.Kyiv, "SkyItalia", "SI654", "On Time"),
                 new Flight(DateTime.Parse("2023-09-27 16:00"), DateTime.Parse("2023-09-27 18:00"), "C", City.Istanbul, City.Kyiv, "BritAirways", "BA789", "On Time"),
                 new Flight(DateTime.Parse("2023-09-30 11:30"), DateTime.Parse("2023-09-30 13:30"), "A", City.Lisbon, City.Kyiv, "HollandAir", "HA456", "On Time")


             };
            }

            static void DisplayMainMenu()
            {
                Console.WriteLine("Choose option: ");
                Console.WriteLine("1-Today’s arrivals");
                Console.WriteLine("2-Today's departures");
                Console.WriteLine("3-Search flight by arrival city");
                Console.WriteLine("4-Search flight by departure city");
                Console.WriteLine("5-Back to Main Menu");
                Console.WriteLine("6-Quit program");
            }

            static void DisplayFirstSubMenu()
            {
                Console.WriteLine("1-Search by destination and departure date");
                Console.WriteLine("2-Search by flight number and departure date");
            }
        }

        private static void DisplaySecondSubMenu()
        {
            Console.WriteLine("1-Search by departure city and departure date");
            Console.WriteLine("2-Search by flight number and departure date");
        }
    }
}