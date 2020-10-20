using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class CountrySqlDAO : ICountryDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a sql based country dao.
        /// </summary>
        /// <param name="databaseconnectionString"></param>
        public CountrySqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public IList<Country> GetCountries() {
            return GetCountriesWhere();
        }
        public IList<Country> GetCountriesWhere(string where = "1 = 1")
        {
            List<Country> list = new List<Country>();
            try {
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(
                        "SELECT code, name, continent, region, surfacearea, population, governmentform FROM country WHERE @condition;",
                        connection);
                    sqlCommand.Parameters.AddWithValue("@condition", where);
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read()) {
                        Country c = ReaderToCountry(dataReader);
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

        private Country ReaderToCountry(SqlDataReader dataReader) {
            Country c = new Country() {
                Code = Convert.ToString(dataReader["code"]),
                Name = Convert.ToString(dataReader["name"]),
                Continent = Convert.ToString(dataReader["continent"]),
                Region = Convert.ToString(dataReader["region"]),
                SurfaceArea = Convert.ToDouble(dataReader["surfacearea"]),
                Population = Convert.ToInt32(dataReader["population"]),
                GovernmentForm = Convert.ToString(dataReader["governmentform"]),
            };
            return c;
        }

        public IList<Country> GetCountries(string continent) {
            return GetCountriesWhere($"continent = {continent}");
        }
    }
}
