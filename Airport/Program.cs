namespace AirportProject
{
    internal class Program
    {
        static void Main()
        {
            List<Flight> flights = new List<Flight>
               {
                 new Flight(DateTime.Parse("2023-09-10 08:00"), DateTime.Parse("2023-09-10 10:00"), "A", DayOfWeek.Monday, City.NewYork, City.London, "Airline1"),
                 new Flight(DateTime.Parse("2023-09-11 09:30"), DateTime.Parse("2023-09-11 11:30"), "B", DayOfWeek.Tuesday, City.Paris, City.Berlin, "Airline2"),
                 new Flight(DateTime.Parse("2023-09-12 12:00"), DateTime.Parse("2023-09-12 14:00"), "C", DayOfWeek.Wednesday, City.Rome, City.Barcelona, "Airline3"),
                 new Flight(DateTime.Parse("2023-09-13 14:30"), DateTime.Parse("2023-09-13 16:30"), "D", DayOfWeek.Thursday, City.Amsterdam, City.Berlin, "Airline4"),
                 new Flight(DateTime.Parse("2023-09-14 10:00"), DateTime.Parse("2023-09-14 12:00"), "E", DayOfWeek.Friday, City.London, City.Paris, "Airline5"),
                 new Flight(DateTime.Parse("2023-09-15 15:30"), DateTime.Parse("2023-09-15 17:30"), "F", DayOfWeek.Saturday, City.Prague, City.Vienna, "Airline6")
             };

            Airport airport = new Airport("My Airport", flights);

            // Отримання та виведення рейсів на сьогодні
            Console.WriteLine("Рейси на сьогодні:");
            var todayFlights = airport.GetFlightsForToday();
            foreach (var flight in todayFlights)
            {
                Console.WriteLine(flight);
            }
        }

    }
}