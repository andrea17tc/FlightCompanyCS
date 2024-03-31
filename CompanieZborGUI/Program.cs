using System.Configuration;
using CompanieZborGUI.repository;
using CompanieZborGUI.service;

namespace CompanieZborGUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            IDictionary<String, string> props = new SortedList<String, String>();
            props.Add("ConnectionString", GetConnectionStringByName("companieZbor"));

            FlightRepository flightRepository = new FlightRepository(props);
            PurchaseRepository purchaseRepository= new PurchaseRepository(props);
            TouristRepository touristRepository= new TouristRepository(props);
            TripRepository tripRepository = new TripRepository(props, touristRepository,purchaseRepository);
            UserRepository userRepository= new UserRepository(props);

            Service service = new Service(flightRepository, purchaseRepository, touristRepository, tripRepository, userRepository);


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(service));
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