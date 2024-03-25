using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class TouristRepository : IRepository<int, Tourist>
{
    private static readonly ILog log = LogManager.GetLogger("Tourist Repository");

    IDictionary<String, string> props;

    public TouristRepository(IDictionary<String, string> props)
    {
        log.Info("Creating TouristRepository ");
        this.props = props;
    }


    public Tourist findOne(int id)
    {
        logger.Trace("Finding Tourist by ID: {0}", id);
        using (SqlConnection connection = dbUtils.GetConnection())
        {
            string query = "SELECT * FROM tourist WHERE id=@id;";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string name = reader.GetString("name");
                        Tourist tourist = new Tourist(name);
                        tourist.Id = id;
                        logger.Trace("Found Tourist: {0}", tourist);
                        return Optional.Of(tourist);
                    }
                }
            }
        }
        logger.Trace("Tourist not found with ID: {0}", id);
        return Optional.Empty<Tourist>();
    }

    public IEnumerable<Tourist> findAll()
    {
        logger.Trace("Finding all Tourists");
        List<Tourist> tourists = new List<Tourist>();
        using (SqlConnection connection = dbUtils.GetConnection())
        {
            string query = "SELECT * FROM tourist;";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int touristId = reader.GetInt32("id");
                        string name = reader.GetString("name");
                        Tourist tourist = new Tourist(name);
                        tourist.Id = touristId;
                        tourists.Add(tourist);
                    }
                }
            }
        }
        logger.Trace("Found {0} Tourists", tourists.Count);
        return tourists;
    }

    public Tourist save(Tourist entity)
    {
        logger.Trace("Saving Tourist: {0}", entity);
        using (SqlConnection connection = dbUtils.GetConnection())
        {
            string query = "INSERT INTO tourist (name) VALUES (@name);";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", entity.Name);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                logger.Trace("Saved {0} instances", rowsAffected);
            }
        }
        return Optional.Empty<Tourist>();
    }

    public Tourist delete(int id)
    {
        logger.Trace("Deleting Tourist with ID: {0}", id);
        using (SqlConnection connection = dbUtils.GetConnection())
        {
            string query = "DELETE FROM tourist WHERE id=@id;";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                logger.Trace("Deleted {0} instances", rowsAffected);
            }
        }
        return Optional.Empty<Tourist>();
    }

    public Tourist update(Tourist entity)
    {
        logger.Trace("Updating Tourist with ID: {0}", id);
        using (SqlConnection connection = dbUtils.GetConnection())
        {
            string query = "UPDATE tourist SET name=@name WHERE id=@id;";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", entity.Name);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                logger.Trace("Updated {0} instances", rowsAffected);
            }
        }
    }