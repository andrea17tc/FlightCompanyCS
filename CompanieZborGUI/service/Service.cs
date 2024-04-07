using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanieZborGUI.repository;
using CompanieZborGUI.model;
using CompanieZborGUI.utils;
using System.Linq;
using System.ServiceProcess;

namespace CompanieZborGUI.service 
{
    public class Service: IObservable
    {
        FlightRepository flightRepository;
        PurchaseRepository purchaseRepository;
        TouristRepository touristRepository;
        TripRepository tripRepository;
        UserRepository userRepository;
        int userID;
        int flightID=0;
        int touristID=0;

        List<IObserver> observers = new List<IObserver>();

        public Service(FlightRepository flightRepository, PurchaseRepository purchaseRepository,
        TouristRepository touristRepository, TripRepository tripRepository, UserRepository userRepository)
        {
            this.flightRepository = flightRepository;
            this.purchaseRepository = purchaseRepository;
            this.touristRepository = touristRepository;
            this.tripRepository = tripRepository;
            this.userRepository = userRepository;
        }

        public void setFlightID(int id)
        {
            flightID = id;
        }

        public void setTouristID(int id)
        {
            touristID = id;
        }

        public IEnumerable<Flight> findAllAvailableFlights()
        {
            List<Flight> flights = flightRepository.findAll().Where(flight => flight.NoTotalSeats > 0).ToList();
            return flights;
        }
        public IEnumerable<string> findAllFlightDestinations()
        {
            List<string> destinations = new List<string>();
            destinations = flightRepository.findAll().Select(flight => flight.Destination.Trim()).Distinct().ToList();
            return destinations;
        }


        public IEnumerable<Flight> findFlightsByDestination(string destination, List<Flight> flights)
        {
            List<Flight> flightsToDestination = flights.Where(flight => flight.Destination.Trim() == destination).ToList();
            return flightsToDestination;
        }

        public IEnumerable<Flight> findFlightsByDate(DateTime date, List<Flight> flights)
        {
            List<Flight> flightsOfDate = flights.Where(flight => Equals(flight.Date.Date, date)).ToList();
            return flightsOfDate;
        }

        public IEnumerable<Flight> findFlightsByDestinationAndDate(string destination, DateTime date)
        {
            List<Flight> flights = findAllAvailableFlights().ToList();
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

        public int findNumberAvailableaSeatsForFlight()
        {
            return flightRepository.findOne(flightID).NoTotalSeats;
        }

        public void saveTourist(string touristName,int purchaseID=0)
        {
            Tourist tourist = new Tourist(touristName);
            if (touristRepository.findByName(touristName) == null)
            {
                touristRepository.save(tourist);
                touristID = touristRepository.findByName(touristName).Id;
            }
            else
            {
                touristID = touristRepository.findByName(touristName).Id;
            }
            if (purchaseID != 0)
            {
                saveTrip(purchaseID, touristID);
            }
        }

        public void saveTrip(int purchaseID, int touristID)
        {
            try
            {
                Tourist t = touristRepository.findOne(touristID);
                Purchase p = purchaseRepository.findOne(purchaseID);
                Trip trip = new Trip(t, p);
                tripRepository.save(trip);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        public int savePurchase(string clientName, string clientAdress)
        {
            try
            {
                saveTourist(clientName);
                int touristID = touristRepository.findByName(clientName).Id;
                Flight f = flightRepository.findOne(flightID);
                User u = userRepository.findOne(userID);
                Tourist t = touristRepository.findOne(touristID);
                Purchase p = new Purchase(f, u, t, clientAdress);
                purchaseRepository.save(p);
                int purchaseID = purchaseRepository.findByClientAndFlight(flightID, touristID).Id;
                return purchaseID;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            
        }

        public void updateFlight(int noSeats)
        {
            try
            {
                Flight f = flightRepository.findOne(flightID);
                int nr = f.NoTotalSeats - noSeats;
                flightRepository.updateNoSeats(flightID, nr);
                notifyObservers();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message); 
            }
            
        }

        public void addObserver(IObserver obs)
        {
            observers.Add(obs);
        }

        public void removeObserver(IObserver obs)
        {
            observers.Remove(obs);
        }

        public void notifyObservers()
        {
            observers.ForEach(obs => obs.update());
        }
    }
}
