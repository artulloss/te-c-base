using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Items
{
    public class UserSqlDao : IUserDao
    {
        private readonly string connectionString;

        public UserSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<User> GetAllUsers()
        {
            // Implement this method to pull in all users from database
            IList<User> users = new List<User>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM users", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.HasRows) return users;
                    while (reader.Read())
                    {
                        users.Add(ReaderToUser(reader));
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }

            return users;
        }

        public void Save(User newUser)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand insertCmd = new SqlCommand(@"INSERT INTO users(first_name, last_name, email, role, created)
                            VALUES (@first_name, @last_name, @email, @role, @created)", conn);
                    // Safely add values into sql
                    insertCmd.Parameters.AddWithValue("@first_name", newUser.FirstName);
                    insertCmd.Parameters.AddWithValue("@last_name", newUser.LastName);
                    insertCmd.Parameters.AddWithValue("@email", newUser.Email);
                    insertCmd.Parameters.AddWithValue("@role", newUser.Role);
                    insertCmd.Parameters.AddWithValue("@created", newUser.Created);
                    insertCmd.ExecuteNonQuery();
                    SqlCommand selectCmd = new SqlCommand("SELECT TOP 1 @@IDENTITY FROM users", conn);
                    newUser.Id = Convert.ToInt64(selectCmd.ExecuteScalar());
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        private static User ReaderToUser(SqlDataReader reader)
        {
            User user = new User
            {
                Id = (int) reader["id"], // Casting or using Convert.To<Type> works here
                FirstName = Convert.ToString(reader["first_name"]),
                LastName = Convert.ToString(reader["last_name"]),
                Email = Convert.ToString(reader["email"]),
                Role = Convert.ToString(reader["role"]),
                Created = Convert.ToDateTime(reader["created"])
            };
            return user;
        }
    }
}