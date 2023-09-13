using System;

namespace AirportProject
{
    internal class Program
    {
        static void Main()
        {
            List<Flight> flights = GetFlightsFromDB();

            DisplayInfo display = new DisplayInfo();
            Validation validation = new Validation();
            DateTime date;
            City arrivalCity;
            string userInput;
            int option;
            bool temp = false;

            Airport airport = new Airport("My Airport", flights);

        MainMenu:
            Console.WriteLine($"{new string('-', 10)}{airport.Name}{new string('-', 10)}\n");

            Console.WriteLine("Flights for today\n");
            var todayFlights = airport.GetFlightsForToday();
            display.DisplayTable(todayFlights);

            

            while (!temp)
            {
                display.DisplayMenu();

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
                        arrivalCity = validation.ValidateCity(userInput);

                        Console.Write("Enter date of departure(yyyy-MM-dd) : ");
                        userInput = Console.ReadLine();
                        date = validation.ValidateDate(userInput);

                        var flightsForDateAndCity = airport.SearchByArrivalCityAndDate(arrivalCity, date);
                        display.DisplayTable(flightsForDateAndCity);
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Enter date of departure(yyyy-MM-dd) : ");
                        userInput = Console.ReadLine();
                        date = validation.ValidateDate(userInput);

                        var flightsForDate = airport.SearchByDate(date);
                        display.DisplayTable(flightsForDate);
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter arrival city: ");
                        userInput = Console.ReadLine();
                        arrivalCity = validation.ValidateCity(userInput);

                        var flightsForCity = airport.SearchByArrivalCity(arrivalCity);
                        display.DisplayTable(flightsForCity);
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Enter arrival date (yyyy-MM-dd) : ");
                        userInput = Console.ReadLine();
                        date = validation.ValidateDate(userInput);

                        var flightsForArrivalDate = airport.SearchByArrivalDate(date);
                        display.DisplayTable(flightsForArrivalDate);
                        break;
                    case 5:
                        Console.Clear();
                        Console.Write("Enter arrival date (yyyy-MM-dd hh:mm) : ");
                        userInput = Console.ReadLine();
                        date = validation.ValidateDate(userInput);

                        var flightsForDepartureDateTime = airport.SearchByDepartureDateTime(date);
                        display.DisplayTable(flightsForDepartureDateTime);
                        break;
                    case 6:
                        Console.Write("Enter flight number : ");
                        userInput = Console.ReadLine();

                        var flightsForNumber = airport.SearchByFlightNumber(userInput);
                        display.DisplayTable(flightsForNumber);
                        break;
                    case 7:
                        Console.Clear();
                        goto MainMenu;
                        break;
                    case 8:
                        Console.WriteLine("----------Good bye----------");
                        temp = true;
                        break;
                }

            }

            static List<Flight> GetFlightsFromDB()
            {
                return new List<Flight>
               {
                 new Flight(DateTime.Now.AddHours(-2).AddMinutes(-19), DateTime.Now.AddHours(4).AddMinutes(19), "A", City.NewYork, City.London, "Airline1", "AA345"),
                 new Flight(DateTime.Now.AddHours(-5).AddMinutes(33),DateTime.Now.AddHours(-1).AddMinutes(33), "B", City.Paris, City.Berlin, "Airline2","DL678"),
                 new Flight(DateTime.Now.AddHours(1).AddMinutes(-27),DateTime.Now.AddHours(5).AddMinutes(27), "C", City.Rome, City.Barcelona, "Airline3","UA123"),
                 new Flight(DateTime.Now.AddHours(-4).AddMinutes(-42),DateTime.Now.AddMinutes(41), "A", City.Amsterdam, City.Berlin, "Airline4","AA345"),
                 new Flight(DateTime.Now.AddHours(3).AddMinutes(7),DateTime.Now.AddHours(6).AddMinutes(3), "B", City.London, City.Paris, "Airline5","DL678"),
                 new Flight(DateTime.Now.AddHours(-1).AddMinutes(15),DateTime.Now.AddHours(4).AddMinutes(27), "C", City.Prague, City.Vienna, "Airline6","UA123"),
                 new Flight(DateTime.Parse("2023-09-14 13:00"), DateTime.Parse("2023-09-14 15:00"), "A", City.Madrid, City.Paris, "Airline7", "AA345"),
                 new Flight(DateTime.Parse("2023-09-10 16:30"), DateTime.Parse("2023-09-17 18:30"), "B", City.Paris, City.Warsaw, "Airline8","BA456"),
                 new Flight(DateTime.Parse("2023-09-15 11:15"), DateTime.Parse("2023-09-14 13:15"), "C", City.Vienna, City.Paris, "Airline9","SQ789"),
                 new Flight(DateTime.Parse("2023-09-14 14:45"), DateTime.Parse("2023-09-19 16:45"), "A", City.Barcelona, City.Paris, "Airline10", "AA345"),
                 new Flight(DateTime.Parse("2023-09-01 08:30"), DateTime.Parse("2023-09-14 10:30"), "B", City.Lisbon, City.Paris, "Airline11","SQ789"),
                 new Flight(DateTime.Parse("2023-09-10 09:00"), DateTime.Parse("2023-09-21 11:00"), "C", City.Warsaw, City.Budapest, "Airline12","BA456"),
                 new Flight(DateTime.Parse("2023-09-22 11:45"), DateTime.Parse("2023-09-22 13:45"), "A", City.Berlin, City.Amsterdam, "Airline13","AA345"),
                 new Flight(DateTime.Parse("2023-09-10 13:30"), DateTime.Parse("2023-09-23 14:30"), "B", City.Paris, City.London, "Airline14","DL678")
             };
            }

            
        }

    }
}