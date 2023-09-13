using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportProject
{
    internal static class Validatior
    {
        public static City ValidateCity(string userInput)
        {
            City arrivalCity;
            while (!Enum.IsDefined(typeof(City), userInput))
            {
                Console.WriteLine($"I'm sorry, but we do not have flights to that city at the moment.\n" +
                    $"Please choose another destination\n");
                userInput = Console.ReadLine();
            }
            arrivalCity = (City)Enum.Parse(typeof(City), userInput, true);
            return arrivalCity;
        }

        public static DateTime ValidateDate(string userInput)
        {
            DateTime date;
            while (!DateTime.TryParse(userInput, out date))
            {
                Console.WriteLine("Wrong input");
            }

            return date;
        }
    }
}
