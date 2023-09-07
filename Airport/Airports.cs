using System;

namespace Airport
{
    internal class Airports
    {
        private Plane[] planes;
        public int CountOfFlights { get; }
        public Airports(Plane[] planes)
        {
            this.planes = planes;
            CountOfFlights = planes.Length;
            SortByFlightNumber();
        }
        

        public void SortByFlightNumber()
        {
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 1; i < planes.Length; i++)
                {
                    if (planes[i - 1].FlightNumber < planes[i].FlightNumber)
                    {
                        Plane temp = planes[i - 1];
                        planes[i - 1] = planes[i];
                        planes[i] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
        public Plane FindByDestination(string destination)
        {
            foreach (Plane plane in planes)
            {
                if (plane.Destination == destination)
                {
                    return plane;
                }
            }

            return null; 
        }
    }
}
