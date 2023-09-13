using System;

namespace AirportProject
{
    internal class Program
    {
        static void Main()
        {
            List<Flight> flights = GetFlightsFromDB();

            Validation validation = new Validation();
            DateTime date;
            City userCity;
            string userInput;
            int option, secondOption;
            bool temp = false;

            Airport airport = new Airport("SkyHarbor Airport", flights);

        MainMenu:
            Console.WriteLine($"{new string('-', 10)}{airport.Name}{new string('-', 10)}\n");

            Console.WriteLine("Flights for today\n");



            while (!temp)
            {
                Console.WriteLine("\nChoose option: ");
                Console.WriteLine("1-Today’s arrivals");
                Console.WriteLine("2-Today's departures");
                Console.WriteLine("3-Search flight by arrival city");
                Console.WriteLine("4-Search flight by departure city");
                Console.WriteLine("5-beck to main menu");
                Console.WriteLine("6-Quit program");


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
                            DisplayInfo.DisplayDepartureTable(todayArrivals);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();

                            var todaydepartures = airport.GetDepartingFlightsForToday(DateTime.Now);
                            DisplayInfo.DisplayArrivalTable(todaydepartures);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("1-Search by destination and departure date");
                            Console.WriteLine("2-Search by flight number and departure date");
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
                                        userCity = validation.ValidateCity(userInput);

                                        Console.Write("Enter departure date (yyyy-MM-dd) : ");
                                        userInput = Console.ReadLine();
                                        date = validation.ValidateDate(userInput);

                                        var flightsByDestinationAndDate=airport.SearchByArrivalCityAndDate(userCity, date);
                                        DisplayInfo.DisplayDepartureTable(flightsByDestinationAndDate);
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.Clear();
                                        Console.Write("Enter flight number: ");
                                        string numberInput = Console.ReadLine();

                                        Console.Write("Enter departure date (yyyy-MM-dd) : ");
                                        userInput = Console.ReadLine();
                                        date = validation.ValidateDate(userInput);

                                        var flightsByNumberAndDate=airport.SearchByFlightNumberAndDate(numberInput, date);
                                        DisplayInfo.DisplayDepartureTable(flightsByNumberAndDate);
                                        break;
                                    }
                            }

                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("1-Search by departure city and departure date");
                            Console.WriteLine("2-Search by flight number and departure date");
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
                                        userCity = validation.ValidateCity(userInput);

                                        Console.Write("Enter departure date (yyyy-MM-dd) : ");
                                        userInput = Console.ReadLine();
                                        date = validation.ValidateDate(userInput);

                                        var flightsByDestinationAndDate = airport.SearchByDepartureCityAndDate(userCity, date);
                                        DisplayInfo.DisplayDepartureTable(flightsByDestinationAndDate);
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.Clear();
                                        Console.Write("Enter flight number: ");
                                        string numberInput = Console.ReadLine();

                                        Console.Write("Enter departure date (yyyy-MM-dd) : ");
                                        userInput = Console.ReadLine();
                                        date = validation.ValidateDate(userInput);

                                        var flightsByNumberAndDate = airport.SearchByFlightNumberAndDate(numberInput, date);
                                        DisplayInfo.DisplayArrivalTable(flightsByNumberAndDate);
                                        break;
                                    }
                            }
                            break;
                        }
                    case 5:
                        Console.Clear();
                        goto MainMenu;
                        break;
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
                 new Flight(DateTime.Now.AddHours(1).AddMinutes(-19), DateTime.Now.AddHours(1).AddMinutes(19), "A", City.Kyiv, City.London, "SkyWings Airlines", "AA345", "On Time"),
new Flight(DateTime.Now.AddHours(1).AddMinutes(33), DateTime.Now.AddHours(2).AddMinutes(33), "B", City.Kyiv, City.Berlin, "AeroJet Express", "DL678", "Delayed"),
new Flight(DateTime.Now.AddHours(2).AddMinutes(-27), DateTime.Now.AddHours(3).AddMinutes(27), "C", City.Kyiv, City.Barcelona, "Horizon Airline", "UA123", "On Time"),
new Flight(DateTime.Now.AddMinutes(40), DateTime.Now.AddHours(2).AddMinutes(41), "A", City.Kyiv, City.Berlin, "StarStream Airways", "AA345", "On Time"),
new Flight(DateTime.Now.AddMinutes(15), DateTime.Now.AddHours(1).AddMinutes(27), "C", City.Kyiv, City.Vienna, "OceanAir International", "UA123", "Delayed"),

new Flight(DateTime.Now.AddHours(2).AddMinutes(-19), DateTime.Now.AddHours(3).AddMinutes(19), "A", City.NewYork, City.Kyiv, "Horizon Airline", "AA345", "On Time"),
new Flight(DateTime.Now.AddMinutes(33), DateTime.Now.AddHours(2).AddMinutes(33), "B", City.Paris, City.Kyiv, "SkyWings Airlines", "DL678", "On Time"),
new Flight(DateTime.Now.AddHours(1).AddMinutes(-27), DateTime.Now.AddHours(2).AddMinutes(27), "C", City.Rome, City.Kyiv, "AeroJet Express", "UA123", "Delayed"),
new Flight(DateTime.Now.AddMinutes(40), DateTime.Now.AddHours(1).AddMinutes(41), "A", City.Amsterdam, City.Kyiv, "SkyWings Airlines", "AA345", "On Time"),
new Flight(DateTime.Now.AddHours(1).AddMinutes(7), DateTime.Now.AddHours(2).AddMinutes(3), "B", City.London, City.Kyiv, "OceanAir International", "DL678", "On Time"),
new Flight(DateTime.Now.AddHours(1).AddMinutes(15), DateTime.Now.AddHours(2).AddMinutes(27), "C", City.Prague, City.Kyiv, "SkyWings Airlines", "UA123", "On Time"),

new Flight(DateTime.Parse("2023-09-14 13:00"), DateTime.Parse("2023-09-14 15:00"), "A", City.Madrid, City.Kyiv, "AeroJet Express", "AA345", "On Time"),
new Flight(DateTime.Parse("2023-09-10 16:30"), DateTime.Parse("2023-09-17 18:30"), "B", City.Kyiv, City.Warsaw, "SkyWings Airlines", "BA456", "On Time"),
new Flight(DateTime.Parse("2023-09-15 11:15"), DateTime.Parse("2023-09-14 13:15"), "C", City.Vienna, City.Kyiv, "OceanAir International", "SQ789", "Delayed"),
new Flight(DateTime.Parse("2023-09-14 14:45"), DateTime.Parse("2023-09-14 16:45"), "A", City.Kyiv, City.Paris, "SunRise Airlines", "AA345", "On Time"),
new Flight(DateTime.Parse("2023-09-01 08:30"), DateTime.Parse("2023-09-14 10:30"), "B", City.Lisbon, City.Kyiv, "StarStream Airways", "SQ789", "On Time"),
new Flight(DateTime.Parse("2023-09-10 09:00"), DateTime.Parse("2023-09-21 11:00"), "C", City.Kyiv, City.Budapest, "SkyWings Airlines", "BA456", "Delayed"),
new Flight(DateTime.Parse("2023-09-22 11:45"), DateTime.Parse("2023-09-22 13:45"), "A", City.Berlin, City.Kyiv, "Horizon Airline", "AA345", "On Time"),
new Flight(DateTime.Parse("2023-09-10 13:30"), DateTime.Parse("2023-09-23 14:30"), "B", City.Kyiv, City.London, "AeroJet Express", "DL678", "On Time")

             };
            }


        }

    }
}