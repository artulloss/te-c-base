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
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString)) //create the connection
                {
                    //Open the connection
                    conn.Open();

                    //sql command to execute, AND the connection
                    //set to population "1); DROP TABLE city; --"
                    SqlCommand cmd = new SqlCommand("INSERT INTO city VALUES(@name,@countrycode,@district,@population);", conn);
                    cmd.Parameters.AddWithValue("@name", city.Name);
                    cmd.Parameters.AddWithValue("@countrycode", city.CountryCode);
                    cmd.Parameters.AddWithValue("@district", city.District);
                    cmd.Parameters.AddWithValue("@population", city.Population);

                    int numRowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Number of rows affected: " + numRowsAffected);

                    cmd = new SqlCommand("SELECT MAX(id) FROM city;",conn);
                    int id = Convert.ToInt32(cmd.ExecuteScalar());

                    Console.WriteLine("The new city id is: " + id);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error saving city.");
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IList<City> GetCitiesByCountryCode(string countryCode)
        {
            List<City> list = new List<City>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT id,name,countrycode,district,population FROM city WHERE countrycode = @countryCode;", conn);
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read()) //go to next row if there's still rows to read
                    {
                        City c = ConvertReaderToCity(reader);
                        list.Add(c);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("An error occurred reading cities by country.");
                Console.WriteLine(e.Message);
                throw;
            }
            return list;

        }

        private City ConvertReaderToCity(SqlDataReader reader)
        {
            City c = new City();
            c.CityId = Convert.ToInt32(reader["id"]);
            c.Name = Convert.ToString(reader["name"]);
            c.CountryCode = Convert.ToString(reader["countrycode"]);
            c.District = Convert.ToString(reader["district"]);
            c.Population = Convert.ToInt32(reader["population"]);
            return c;
        }
    }
}
