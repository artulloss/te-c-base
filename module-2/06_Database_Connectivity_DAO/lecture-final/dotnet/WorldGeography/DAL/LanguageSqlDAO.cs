using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class LanguageSqlDAO : ILanguageDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a sql based language dao.
        /// </summary>
        /// <param name="databaseConnectionString"></param>
        public LanguageSqlDAO(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }

        public IList<Language> GetLanguages(string countryCode)
        {
            List<Language> list = new List<Language>();
            try
            {
                //create a sql connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //open it
                    conn.Open();
                    // create a sql command to get all of the languages for countrycode
                    SqlCommand cmd = new SqlCommand("SELECT countrycode,language,isofficial, percentage " +
                        "FROM countrylanguage WHERE countrycode = @countryCode", conn);
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);

                    //   execute that
                    SqlDataReader reader = cmd.ExecuteReader();
                    //  read the results
                    while (reader.Read())
                    {
                        //for every row, create a new language object and add it to the list
                        Language lang = new Language();
                        lang.CountryCode = Convert.ToString(reader["countrycode"]);
                        lang.Name = Convert.ToString(reader["language"]);
                        lang.IsOfficial = Convert.ToBoolean(reader["isofficial"]);
                        lang.Percentage = Convert.ToInt32(reader["percentage"]);
                        list.Add(lang);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error getting languages.");
                Console.WriteLine(e.Message);
                throw;
            }
            return list;
        }

        public bool AddNewLanguage(Language newLanguage)
        {
            bool success = false;
            try
            {
                //create a sql connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //open it
                    conn.Open();
                    // create a sql command to add a new language
                    SqlCommand cmd = new SqlCommand("INSERT INTO countrylanguage(countrycode,language,isofficial,percentage)" +
                                                   " VALUES(@countryCode,@language,@isOfficial,@percentage)", conn);
                    cmd.Parameters.AddWithValue("@countryCode", newLanguage.CountryCode);
                    cmd.Parameters.AddWithValue("@language", newLanguage.Name);
                    cmd.Parameters.AddWithValue("@isOfficial", newLanguage.IsOfficial);
                    cmd.Parameters.AddWithValue("@percentage", newLanguage.Percentage);

                    //   execute that
                    int numRowsAffected = cmd.ExecuteNonQuery();

                    if (numRowsAffected == 1)
                        success = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error getting languages.");
                Console.WriteLine(e.Message);
                //swallow the exception instead of rethrowing - then the program will just print the error and keep goign
            }
            return success;

        }

        public bool RemoveLanguage(Language deadLanguage)
        {
            bool success = false;
            try
            {
                //create a sql connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //open it
                    conn.Open();
                    // create a sql command to add a new language
                    SqlCommand cmd = new SqlCommand("DELETE FROM countrylanguage WHERE countrycode=@countryCode AND language=@name", conn);
                    cmd.Parameters.AddWithValue("@countryCode", deadLanguage.CountryCode);
                    cmd.Parameters.AddWithValue("@name", deadLanguage.Name);

                    //   execute that
                    int numRowsAffected = cmd.ExecuteNonQuery();

                    if (numRowsAffected == 1)
                        success = true;
                    else
                        Console.WriteLine("Oh no! You deleted " + numRowsAffected + " rows!!!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error getting languages.");
                Console.WriteLine(e.Message);
                throw;
            }
            return success;
        }


     
    }
}
