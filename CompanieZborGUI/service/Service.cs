using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanieZborGUI.repository;
using CompanieZborGUI.model;
using System.Linq;

namespace CompanieZborGUI.service
{
    public class Service
    {
        FlightRepository flightRepository;
        PurchaseRepository purchaseRepository;
        TouristRepository touristRepository;
        TripRepository tripRepository;
        UserRepository userRepository;
        int userID;

        public Service(FlightRepository flightRepository, PurchaseRepository purchaseRepository,
        TouristRepository touristRepository, TripRepository tripRepository, UserRepository userRepository)
        {
            this.flightRepository = flightRepository;
            this.purchaseRepository = purchaseRepository;
            this.touristRepository = touristRepository;
            this.tripRepository = tripRepository;
            this.userRepository = userRepository;
        }

        public IEnumerable<string> findAllFlightDestinations()
        {
            List<string> destinations = new List<string>();
            destinations = flightRepository.findAll().Select(flight => flight.Destination.Trim()).Distinct().ToList();
            return destinations;
        }


        public IEnumerable<Flight> findFlightsByDestination(string destination, List<Flight> flights)
        {
            List<Flight> flightsToDestination = flights.Where(flight => flight.Destination == destination).ToList();
            return flightsToDestination;
        }

        public IEnumerable<Flight> findFlightsByDate(DateOnly date, List<Flight> flights)
        {
            List<Flight> flightsOfDate = flights.Where(flight => Equals(flight.Date.Date, date)).ToList();
            return flightsOfDate;
        }

        public IEnumerable<Flight> findFlightsByDestinationAndDate(string destination, DateOnly date)
        {
            List<Flight> flights = flightRepository.findAll().ToList();
            List<Flight> flightsByDate = findFlightsByDate(date, flights).ToList();
            List<Flight> flightsByDestinationAndDate = findFlightsByDestination(destination, flightsByDate).ToList();
            return flightsByDestinationAndDate;
        }

        public Boolean findUser(string username, string password)
        {
            User user = userRepository.findByUsername(username);
            if (user == null)
            {
                return false;
            }

            if (user.Password == password)
            {
                userID = user.Id;
                return true;
            }
            return false;

        }


    }
}
