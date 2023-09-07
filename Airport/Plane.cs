using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class Plane
    {
        public string Destination { get; set; }
        public int FlightNumber { get; set; }
        public string TypeOfPlane { get; set; }

        public Plane(string destination, int flightNumber, string typeOfPlane) {
            Destination = destination;
            FlightNumber = flightNumber;
            TypeOfPlane = typeOfPlane;
        }
    }
}
