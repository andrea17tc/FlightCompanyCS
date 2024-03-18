using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ro.Mpp2024.Model;

namespace Ro.Mpp2024.Repository
{
    public class FlightRepository : IRepository<int, Flight>
    {
        private readonly JdbcUtils dbUtils;
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public FlightRepository(SqlConnectionStringBuilder props)
        {
            logger.Info("Initializing FlightRepository with properties: {0}", props.ConnectionString);
            dbUtils = new JdbcUtils(props);
        }

        public Optional<Flight> FindOne(int id)
        {
            logger.Trace("Finding Flight by ID: {0}", id);
            using (SqlConnection connection = dbUtils.GetConnection())
            {
                string query = "SELECT * FROM flight WHERE id=@id;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string destination = reader.GetString("destination");
                            DateTime date = reader.GetDateTime("date");
                            string airport = reader.GetString("airport");
                            int noSeats = reader.GetInt32("noTotalSeats");
                            Flight flight = new Flight(destination, date, airport, noSeats);
                            flight.Id = id;
                            logger.Trace("Found Flight: {0}", flight);
                            return Optional.Of(flight);
                        }
                    }
                }
            }
            logger.Trace("Flight not found with ID: {0}", id);
            return Optional.Empty<Flight>();
        }

        public IEnumerable<Flight> FindAll()
        {
            logger.Trace("Finding all Flights");
            List<Flight> flights = new List<Flight>();
            using (SqlConnection connection = dbUtils.GetConnection())
            {
                string query = "SELECT * FROM flight;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string destination = reader.GetString("destination");
                            DateTime date = reader.GetDateTime("date");
                            string airport = reader.GetString("airport");
                            int noSeats = reader.GetInt32("noTotalSeats");
                            Flight flight = new Flight(destination, date, airport, noSeats);
                            flight.Id = id;
                            flights.Add(flight);
                        }
                    }
                }
            }
            logger.Trace("Found {0} Flights", flights.Count);
            return flights;
        }

        public Optional<Flight> Save(Flight entity)
        {
            logger.Trace("Saving Flight: {0}", entity);
            using (SqlConnection connection = dbUtils.GetConnection())
            {
                string query = "INSERT INTO flight (destination, date, airport, noTotalSeats) VALUES (@destination, @date, @airport, @noTotalSeats);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@destination", entity.Destination);
                    command.Parameters.AddWithValue("@date", entity.DateTime);
                    command.Parameters.AddWithValue("@airport", entity.Airport);
                    command.Parameters.AddWithValue("@noTotalSeats", entity.NoTotalSeats);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    logger.Trace("Saved {0} instances", rowsAffected);
                }
            }
            return Optional.Empty<Flight>();
        }

        public Optional<Flight> Delete(int id)
        {
            logger.Trace("Deleting Flight with ID: {0}", id);
            using (SqlConnection connection = dbUtils.GetConnection())
            {
                string query = "DELETE FROM flight WHERE id=@id;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    logger.Trace("Deleted {0} instances", rowsAffected);
                }
            }
            return Optional.Empty<Flight>();
        }

        public Optional<Flight> Update(int id, Flight entity)
        {
            logger.Trace("Updating Flight with ID: {0}", id);
            using (SqlConnection connection = dbUtils.GetConnection())
            {
                string query = "UPDATE flight SET date=@date, airport=@airport WHERE id=@id;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@date", entity.DateTime);
                    command.Parameters.AddWithValue("@airport", entity.Airport);
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    logger.Trace("Updated {0} instances", rowsAffected);
                }
            }
            return Optional.Empty<Flight>();
        }
    }
}
