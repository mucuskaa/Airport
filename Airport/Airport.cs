using System;
using System.Diagnostics.Metrics;

namespace AirportProject
{
    internal class Airport
    {
        public string Name { get; set; }
        public List<Flight> Flights { get; set; }
        
        public Airport(string name, List<Flight> flights)
        {
            Name = name;
            Flights = flights;
        }

        public void AddFlight(Flight flight)
        {
            Flights.Add(flight);
        }

        public List<Flight> GetFlightsForToday()
        {
            var today = DateTime.Now.Date;
            var flightsForToday = Flights .Where(flight => flight.DepartureDay == today).OrderBy(flight => flight.DepartureTime).ToList();

            return flightsForToday;
        }

        //сортування за датою відпраки
        public List<Flight> SearchByDate(DateTime departureDay)
        {
            var flightsForDate = Flights.Where(flight => flight.DepartureDay == departureDay).OrderBy(flight => flight.DepartureTime).ToList();

            return flightsForDate;
        }


        //місто прибуття
        public List<Flight> SearchByArrivalCity(City arrivalCity)
        {
            var flightsByArrivalCity = Flights.Where(flight => flight.ArrivalCity == arrivalCity).OrderBy(flight => flight.DepartureTime).ToList();

            return flightsByArrivalCity;
        }


        // дата відправки і місто прибуття

        public List<Flight> SearchByArrivalCityAndDate(City arrivalCity, DateTime date)
        {
            var flightsByArrivalCityAndDate = Flights.Where(flight => flight.ArrivalCity == arrivalCity && flight.DepartureDay == date.Date).OrderBy(flight => flight.DepartureTime).ToList();

            return flightsByArrivalCityAndDate;
        }

        //дата прибуття 
        public List<Flight> SearchByArrivalDate(DateTime arrivalDate)
        {
            var flightsForDate = Flights.Where(flight => flight.ArrivalDay == arrivalDate.Date).OrderBy(flight => flight.DepartureTime).ToList();

            return flightsForDate;
        }

        //дата відправки і час відправки 
        public List<Flight> SearchByDepartureDateTime(DateTime departureDateTime)
        {
            var departureDateTimeLower = departureDateTime.AddMinutes(-30);
            var departureDateTimeUpper = departureDateTime.AddMinutes(30);

            var flightsForDateTimeRange = Flights.Where(flight => flight.DepartureTime >= departureDateTimeLower && flight.DepartureTime <= departureDateTimeUpper).OrderBy(flight => flight.DepartureTime).ToList();

            return flightsForDateTimeRange;
        }



    }
}
