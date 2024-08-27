using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace InjectionInloggning
{
    public class MySqlDatabaseService : IDatabaseService
    {
        private readonly string _connectionString;

        public MySqlDatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool AuthenticateUser(string username, string password)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT * FROM users WHERE username = @username AND password = @password;";
                using (var cmd = new MySqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    try
                    {
                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            return reader.Read();
                        }
                    }
                    catch
                    {
                        // Hantera undantag om det behövs
                        throw;
                    }
                }
            }
        }
    }
}
