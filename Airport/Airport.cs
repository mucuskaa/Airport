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


        public List<Flight> GetArrivingFlightsForToday(City arrivalCity)
        {
            var today = DateTime.Now.Date;
            var arrivingFlightsForToday = Flights
               .Where(flight => flight.Direction == Direction.Arraiving && flight.ArrivalDay.Date == today && flight.ArrivalCity == arrivalCity)
               .OrderBy(flight => flight.ArrivalTime)
               .ToList();

            return arrivingFlightsForToday;
        }

        public List<Flight> GetDepartingFlightsForToday(DateTime today)
        {         
            var departingFlightsForToday = Flights
               .Where(flight => flight.DepartureDay.Date == today.Date&&flight.DepartureCity == City.Kyiv)
               .OrderBy(flight => flight.DepartureTime)
               .ToList();

            return departingFlightsForToday;
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

        //Пошук за номером рейсу і датою вильоту:
        public List<Flight> SearchByFlightNumberAndDate(string flightNumber, DateTime date)
        {
            var flightsByNumberAndDate = Flights
               .Where(flight => (String.Compare(flight.FlightNumber, flightNumber.Trim(), ignoreCase: true) == 0) && flight.DepartureDay.Date == date.Date)
               .OrderBy(flight => flight.DepartureTime)
               .ToList();

            return flightsByNumberAndDate;
        }

        //Пошук за місцем вильоту і датою вильоту:
        public List<Flight> SearchByDepartureCityAndDate(City departureCity, DateTime date)
        {
            var flightsByDepartureCityAndDate = Flights
               .Where(flight => flight.DepartureCity == departureCity && flight.DepartureDay.Date == date.Date)
               .OrderBy(flight => flight.DepartureTime)
               .ToList();

            return flightsByDepartureCityAndDate;
        }

    }
}
