namespace Airport
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("---AIRPORT---");


            Console.WriteLine("Enter count of flights");
            int countOfPlanes;
            while (!int.TryParse(Console.ReadLine(), out countOfPlanes))
            {
                Console.WriteLine("Incorrect input");
            }
            Plane[] planes = new Plane[countOfPlanes];

            for (int i = 0; i < planes.Length; i++)
            {
                int flightNumber;
                Console.WriteLine($"Enter destination of {i + 1} flight");
                string destination = Console.ReadLine();

                Console.WriteLine($"Enter number of {i + 1} flight");
                while(!int.TryParse(Console.ReadLine(), out flightNumber))
                {
                    Console.WriteLine("Incorrect input");
                }

                Console.WriteLine($"Enter type of {i + 1} plane");
                string typeOfPlane = Console.ReadLine();

                planes[i] = new Plane(destination, flightNumber, typeOfPlane);
            }

            Airports airport = new Airports(planes);
            Console.WriteLine("Enter destination to search:");
            string searchDestination = Console.ReadLine();
            Plane foundPlane = airport.FindByDestination(searchDestination);

            if (foundPlane != null)
            {
                Console.WriteLine("Found plane:");
                Console.WriteLine($"Destination: {foundPlane.Destination}");
                Console.WriteLine($"Flight Number: {foundPlane.FlightNumber}");
                Console.WriteLine($"Type of Plane: {foundPlane.TypeOfPlane}");
            }
            else
            {
                Console.WriteLine("No plane found with the specified destination.");
            }

        }
    }
}