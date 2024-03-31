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