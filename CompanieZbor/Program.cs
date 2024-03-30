using CompanieZbor.repository;
using System.Configuration;
using CompanieZbor.model;

namespace CompanieZbor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            IDictionary<String, string> props = new SortedList<String, String>();
            props.Add("ConnectionString", GetConnectionStringByName("companieZbor"));

            FlightRepository flightRepository = new FlightRepository(props);
            IEnumerable<Flight> flights = flightRepository.findAll();
            /*foreach (Flight flight in flights)
            {
                Console.WriteLine(flight);
            }
            

            

            Flight f = new Flight("Paris", d , "Beauvois", 120);

            flightRepository.save(f);
            flights = flightRepository.findAll();
            foreach (Flight flight in flights)
            {
                Console.WriteLine(flight);
            }*/

            DateTime d = DateTime.Parse("08-Apr-2024 01:20");
            Flight f = new Flight("Paris", d, "Beauvois Paris", 120);
            flightRepository.update(f);
            flights = flightRepository.findAll();
            foreach (Flight flight in flights)
            {
                Console.WriteLine(flight);
            }


        }

        static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }
    }

}