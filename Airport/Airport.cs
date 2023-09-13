using System;
using System.Diagnostics.Metrics;

namespace AirportProject
{
    internal class Airport
    {
        public string Name { get; }
        public List<Flight> Flights { get; }

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
            var flightsForToday = Flights
               .Where(flight => flight.DepartureDay == today)
               .OrderBy(flight => flight.DepartureTime)
               .ToList();

            return flightsForToday;
        }

        //сортування за датою відпраки
        public List<Flight> SearchByDate(DateTime departureDay)
        {
            var flightsForDate = Flights
               .Where(flight => flight.DepartureDay.Date == departureDay.Date)
               .OrderBy(flight => flight.DepartureTime)
               .ToList();

            return flightsForDate;
        }

        //місто прибуття
        public List<Flight> SearchByArrivalCity(City arrivalCity)
        {
            var flightsByArrivalCity = Flights
               .Where(flight => flight.ArrivalCity == arrivalCity)
               .OrderBy(flight => flight.DepartureTime)
               .ToList();

            return flightsByArrivalCity;
        }

        // дата відправки і місто прибуття

        public List<Flight> SearchByArrivalCityAndDate(City arrivalCity, DateTime date)
        {
            var flightsByArrivalCityAndDate = Flights
               .Where(flight => flight.ArrivalCity == arrivalCity && flight.DepartureDay.Date == date.Date)
               .OrderBy(flight => flight.DepartureTime)
               .ToList();

            return flightsByArrivalCityAndDate;
        }

        //дата прибуття 
        public List<Flight> SearchByArrivalDate(DateTime arrivalDate)
        {
            var flightsForDate = Flights
               .Where(flight => flight.ArrivalDay.Date == arrivalDate.Date)
               .OrderBy(flight => flight.DepartureTime)
               .ToList();

            return flightsForDate;
        }

        //дата відправки і час відправки 
        public List<Flight> SearchByDepartureDateTime(DateTime departureTime)
        {
            var departureTimeLower = departureTime.AddMinutes(-30);
            var departureTimeUpper = departureTime.AddMinutes(30);

            var flightsForDateTimeRange = Flights
               .Where(flight => flight.DepartureTime >= departureTimeLower && flight.DepartureTime <= departureTimeUpper)
               .OrderBy(flight => flight.DepartureTime)
               .ToList();

            return flightsForDateTimeRange;
        }
        public List<Flight> SearchByFlightNumber(string flightnumber)
        {
            var flightsByNumber=Flights
                .Where((flight) => flight.FlightNumber == flightnumber)
                .OrderBy(flight => flight.DepartureTime)
               .ToList();
            return flightsByNumber;
        }
    }
}
