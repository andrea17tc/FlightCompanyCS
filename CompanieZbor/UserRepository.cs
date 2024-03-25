using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class UserRepository : IRepository<int, User>
{
    private static readonly ILog log = LogManager.GetLogger("User Repository");
    IDictionary<String, string> props;

    public UserRepository(IDictionary<String, string> props)
    {
        log.Info("Creating UserRepository ");
        this.props = props;
    }

    public User findOne(int id)
    {
        logger.Trace("Finding User by ID: {0}", id);
        using (SqlConnection connection = dbUtils.GetConnection())
        {
            string query = "SELECT * FROM user WHERE id=@id;";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int userId = reader.GetInt32("id");
                        string username = reader.GetString("username");
                        string password = reader.GetString("password");
                        User user = new User(username, password);
                        user.Id = userId;
                        logger.Trace("Found User: {0}", user);
                        return Optional.Of(user);
                    }
                }
            }
        }
        logger.Trace("User not found with ID: {0}", id);
        return Optional.Empty<User>();
    }

    public IEnumerable<User> findAll()
    {
        logger.Trace("Finding all Users");
        List<User> users = new List<User>();
        using (SqlConnection connection = dbUtils.GetConnection())
        {
            string query = "SELECT * FROM user;";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int userId = reader.GetInt32("id");
                        string username = reader.GetString("username");
                        string password = reader.GetString("password");
                        User user = new User(username, password);
                        user.Id = userId;
                        users.Add(user);
                    }
                }
            }
        }
        logger.Trace("Found {0} Users", users.Count);
        return users;
    }

    public User save(User entity)
    {
        logger.Trace("Saving User: {0}", entity);
        using (SqlConnection connection = dbUtils.GetConnection())
        {
            string query = "INSERT INTO user (username, password) VALUES (@username, @password);";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", entity.Username);
                command.Parameters.AddWithValue("@password", entity.Password);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                logger.Trace("Saved {0} instances", rowsAffected);
            }
        }
        return Optional.Empty<User>();
    }

    public User delete(int id)
    {
        logger.Trace("Deleting User with ID: {0}", id);
        using (SqlConnection connection = dbUtils.GetConnection())
        {
            string query = "DELETE FROM user WHERE id=@id;";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                logger.Trace("Deleted {0} instances", rowsAffected);
            }
        }
        return Optional.Empty<User>();
    }

    public User update(User entity)
    {
        logger.Trace("Updating User with ID: {0}", id);
        using (SqlConnection connection = dbUtils.GetConnection())
        {
            string query = "UPDATE user SET password=@password WHERE id=@id;";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@password", entity.Password);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                logger.Trace("Updated {0} instances", rowsAffected);
            }
        }
        return Optional.Empty<User>();
    }
}

