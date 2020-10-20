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

            try {
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    
                    SqlCommand command = new SqlCommand("SELECT * FROM language", connection);

                    SqlDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read()) {
                        Language l = ReaderToLanguage(reader);
                        list.Add(l);
                    }
                }
            }
            catch (SqlException e) {
                Console.WriteLine(e);
                throw;
            }

            return list;
        }

        public bool AddNewLanguage(Language newLanguage)
        {
            throw new NotImplementedException();
        }

        public bool RemoveLanguage(Language deadLanguage)
        {
            throw new NotImplementedException();
        }
        
        private static Language ReaderToLanguage(SqlDataReader reader) {
            Language l = new Language {
                Name = Convert.ToString(reader["name"]),
                CountryCode = Convert.ToString(reader["countrycode"]),
                Percentage = Convert.ToInt32(reader["percentage"]),
                IsOfficial = Convert.ToBoolean(reader["isofficial"]),
            };
            return l;
        }
    }
}
