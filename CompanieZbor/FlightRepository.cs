using log4net;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class FlightRepository : IRepository<int, Flight>
{
    private static readonly ILog log = LogManager.GetLogger("FlightRepository");

    IDictionary<String, string> props;

    public FlightRepository(IDictionary<String, string> props)
    {
        log.Info("Creating FlightRepository ");
        this.props = props;
    }

    public Flight findOne(int id)
    {
        log.InfoFormat("Finding Flight by ID: {0}", id);
        IDbConnection con = DBUtils.getConnection(props);

        using (var connection = con.CreateCommand())
        {
            connection.CommandText = "Select";
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
        log.Trace("Flight not found with ID: {0}", id);
        return Optional.Empty<Flight>();
    }

    public IEnumerable<Flight> findAll()
    {
        log.Trace("Finding all Flights");
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
        log.Trace("Found {0} Flights", flights.Count);
        return flights;
    }

    public Flight save(Flight entity)
    {
        log.Trace("Saving Flight: {0}", entity);
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
                log.Trace("Saved {0} instances", rowsAffected);
            }
        }
        return Optional.Empty<Flight>();
    }

    public Flight delete(int id)
    {
        log.Trace("Deleting Flight with ID: {0}", id);
        using (SqlConnection connection = dbUtils.GetConnection())
        {
            string query = "DELETE FROM flight WHERE id=@id;";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                log.Trace("Deleted {0} instances", rowsAffected);
            }
        }
        return Optional.Empty<Flight>();
    }

    public Flight update(Flight entity)
    {
        log.Trace("Updating Flight with ID: {0}", id);
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
                log.Trace("Updated {0} instances", rowsAffected);
            }
        }
        return ;
    }

}

