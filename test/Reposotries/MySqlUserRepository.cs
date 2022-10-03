using Catalog.Settings;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using test.Models;

public class MySqlUserRepository : IUserRepository
{

    public void CreateUser(User user)
    {
        using (IDbConnection connection = new MySqlConnection(MySqlDbSettings.ConnectionString))
        {

            connection.Open();
            var query = @" INSERT INTO	users (Name,Email,Password) VALUES(@Name,@Email,@Password)";
            connection.Query<User>(query, new { Name = user.Name, Email = user.Email, Password = user.Password });
        }
    }

    public IEnumerable<User> GetAllUsers()
    {
        using (IDbConnection connection = new MySqlConnection(MySqlDbSettings.ConnectionString))
        {

            connection.Open();
            var query = @" SELECT * FROM users";
            var users = connection.Query<User>(query);

            return users;
        }
    }

    public void UpdateUser(User user)
    {
        using (IDbConnection connection = new MySqlConnection(MySqlDbSettings.ConnectionString))
        {
            var query = @"UPDATE users 
                          SET name = @name,email = @email,password = @password
                          WHERE id=@id";
            connection.Query<User>(query, new { name = user.Name, id = user.Id, email = user.Email, password = user.Password });
        }
    }

    public void DeleteUser(int UserId)
    {
        using (IDbConnection connection = new MySqlConnection(MySqlDbSettings.ConnectionString))
        {

            connection.Open();
            var query = @"DELETE FROM users WHERE id=@UserId";
            connection.Query<User>(query, new { UserId = UserId });

        }
    }
}
