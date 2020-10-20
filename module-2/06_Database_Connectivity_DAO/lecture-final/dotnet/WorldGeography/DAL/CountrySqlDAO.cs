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

        public IList<Country> GetCountries()
        {
            return GetCountries("%");
        }

        /// <summary>
        /// This creates a new country with sql results containing columns: code,name,continent,region,surfacearea,population,governmentform
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Country ConvertReaderToCountry(SqlDataReader reader)
        {
            Country c = new Country();
            c.Code = Convert.ToString(reader["code"]);
            c.Name = Convert.ToString(reader["name"]);
            c.Continent = Convert.ToString(reader["continent"]);
            c.Region = Convert.ToString(reader["region"]);
            c.SurfaceArea = Convert.ToDouble(reader["surfacearea"]);
            c.Population = Convert.ToInt32(reader["population"]);
            c.GovernmentForm = Convert.ToString(reader["governmentform"]);
            //c.HeadOfState = Convert.ToString(reader["headofstate"]); ERROR not in the select list
            return c;
        }

        public IList<Country> GetCountries(string continent)
        {
            List<Country> list = new List<Country>();
            try
            {
                //connection to the db
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //open it
                    conn.Open();
                    //create a sql command
                    SqlCommand cmd = new SqlCommand("SELECT code,name,continent,region,surfacearea,population,governmentform FROM country WHERE continent Like @continentName;", conn);
                    cmd.Parameters.AddWithValue("@continentName", continent);
                    //execute the sql command
                    SqlDataReader reader = cmd.ExecuteReader();

                    //read the results 
                    while (reader.Read())
                    {
                        //   create a country for each row
                        Country c = ConvertReaderToCountry(reader);

                        //   add that country to the list
                        list.Add(c);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error getting countries.");
                Console.WriteLine(e.Message);
                throw;
            }
            return list; 
        }

        public List<Country>  GetCountriesSpeakingLanguage(string languageName)   
        {
            List<Country> list = new List<Country>();

            try
            {
                //create a sql connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //open it
                    conn.Open();
                    // create a sql command to get all of the languages for countrycode
                    SqlCommand cmd = new SqlCommand("SELECT code,name,continent,region,surfacearea,population,governmentform " +
                                                    "FROM country " +
                                                    "INNER JOIN countrylanguage ON country.code = countrylanguage.countrycode " +
                                                    "WHERE language = @languageName", conn);
                    cmd.Parameters.AddWithValue("@languageName", languageName);

                    //   execute that
                    SqlDataReader reader = cmd.ExecuteReader();
                    //  read the results
                    while (reader.Read())
                    {

                        //for every row, create a country and add it tot he list
                        Country c = ConvertReaderToCountry(reader);

                        //   add that country to the list
                        list.Add(c);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error getting countries that speak langugae.");
                Console.WriteLine(e.Message);
                throw;
            }
            return list;
        }
    }
}
