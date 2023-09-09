using System;

namespace AirportProject
{
    internal class Airport
    {
        public string Name { get; set; }
        public List<Flight> Flights { get; set; }
        public List<Flight> FlightsForToday { get; }
        
        public Airport(string name, List<Flight> flights)
        {
            Name = name;
            Flights = flights;
            FlightsForToday = new List<Flight>();
        }

        public void AddFlight(Flight flight)
        {
            Flights.Add(flight);
        }

        public List<Flight> GetFlightsForToday()
        {
            var today = DateTime.Now.DayOfWeek;
            foreach (var flight in Flights)
            {
                if(flight.DaysOfWeek==today)
                {
                    FlightsForToday.Add(flight);
                }
            }
            FlightsForToday.Sort();
            return FlightsForToday;
        }
    }
}
