using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class CitySqlDAO : ICityDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a new sql-based city dao.
        /// </summary>
        /// <param name="databaseconnectionString"></param>
        public CitySqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public void AddCity(City city)
        {
            try {
                using (SqlConnection conn = new SqlConnection()) {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO city VALUES (@name, @countrycode, @district, @population);", conn);
                    sqlCommand.Parameters.AddWithValue("@name", city.Name);
                    sqlCommand.Parameters.AddWithValue("@countrycode", city.CountryCode);
                    sqlCommand.Parameters.AddWithValue("@district", city.District);
                    sqlCommand.Parameters.AddWithValue("@population", city.Population);
                    sqlCommand.ExecuteNonQuery();
                    
                    sqlCommand = new SqlCommand("SELECT MAX(id) FROM city;", conn);

                    sqlCommand.ExecuteNonQuery();
                    

                }
            }
            catch (SqlException e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public IList<City> GetCitiesByCountryCode(string countryCode)
        {
            List<City> list = new List<City>();

            try {
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    
                    SqlCommand command = new SqlCommand("SELECT * FROM city WHERE countrycode = @countryCode", connection);

                    SqlDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read()) {
                        City c = ReaderToCity(reader);
                        list.Add(c);
                    }
                }
            }
            catch (SqlException e) {
                Console.WriteLine(e);
                throw;
            }

            return list;
        }

        private static City ReaderToCity(SqlDataReader reader) {
            City c = new City {
                CityId = Convert.ToInt32(reader["id"]),
                Name = Convert.ToString(reader["name"]),
                CountryCode = Convert.ToString(reader["countrycode"]),
                District = Convert.ToString(reader["district"]),
                Population = Convert.ToInt32(reader["population"])
            };
            return c;
        }
    }
}
