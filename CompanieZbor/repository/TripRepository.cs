using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ro.Mpp2024.Model;

namespace Ro.Mpp2024.Repository
{
    public class TripRepository : IRepository<int, Trip>
    {
        private readonly TouristRepository touristRepository;
        private readonly PurchaseRepository purchaseRepository;
        private readonly JdbcUtils dbUtils;
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public TripRepository(SqlConnectionStringBuilder props, TouristRepository touristRepository, PurchaseRepository purchaseRepository)
        {
            logger.Info("Initializing TripRepository with properties: {0}", props.ConnectionString);
            dbUtils = new JdbcUtils(props);
            this.touristRepository = touristRepository;
            this.purchaseRepository = purchaseRepository;
        }

        public Optional<Trip> FindOne(int id)
        {
            logger.Trace("Finding Trip by ID: {0}", id);
            using (SqlConnection connection = dbUtils.GetConnection())
            {
                string query = "SELECT * FROM trip WHERE id=@id;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int touristID = reader.GetInt32("touristID");
                            int purchaseID = reader.GetInt32("purchaseID");
                            Tourist tourist = touristRepository.FindOne(touristID).Value;
                            Purchase purchase = purchaseRepository.FindOne(purchaseID).Value;
                            Trip trip = new Trip(tourist, purchase);
                            trip.Id = id;
                            logger.Trace("Found Trip: {0}", trip);
                            return Optional.Of(trip);
                        }
                    }
                }
            }
            logger.Trace("Trip not found with ID: {0}", id);
            return Optional.Empty<Trip>();
        }

        public IEnumerable<Trip> FindAll()
        {
            logger.Trace("Finding all Trips");
            List<Trip> trips = new List<Trip>();
            using (SqlConnection connection = dbUtils.GetConnection())
            {
                string query = "SELECT * FROM trip;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tripId = reader.GetInt32("id");
                            int touristID = reader.GetInt32("touristID");
                            int purchaseID = reader.GetInt32("purchaseID");
                            Tourist tourist = touristRepository.FindOne(touristID).Value;
                            Purchase purchase = purchaseRepository.FindOne(purchaseID).Value;
                            Trip trip = new Trip(tourist, purchase);
                            trip.Id = tripId;
                            trips.Add(trip);
                        }
                    }
                }
            }
            logger.Trace("Found {0} Trips", trips.Count);
            return trips;
        }

        public Optional<Trip> Save(Trip entity)
        {
            logger.Trace("Saving Trip: {0}", entity);
            using (SqlConnection connection = dbUtils.GetConnection())
            {
                string query = "INSERT INTO trip (touristID, purchaseID) VALUES (@touristID, @purchaseID);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@touristID", entity.Tourist.Id);
                    command.Parameters.AddWithValue("@purchaseID", entity.Purchase.Id);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    logger.Trace("Saved {0} instances", rowsAffected);
                }
            }
            return Optional.Empty<Trip>();
        }

        public Optional<Trip> Delete(int id)
        {
            logger.Trace("Deleting Trip with ID: {0}", id);
            using (SqlConnection connection = dbUtils.GetConnection())
            {
                string query = "DELETE FROM trip WHERE id=@id;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    logger.Trace("Deleted {0} instances", rowsAffected);
                }
            }
            return Optional.Empty<Trip>();
        }

        public Optional<Trip> Update(int id, Trip entity)
        {
            logger.Trace("Updating Trip with ID: {0}", id);
            using (SqlConnection connection = dbUtils.GetConnection())
            {
                string query = "UPDATE trip SET touristID=@touristID WHERE id=@id;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@touristID", entity.Tourist.Id);
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    logger.Trace("Updated {0} instances", rowsAffected);
                }
            }
            return Optional.Empty<Trip>();
        }
    }
}
