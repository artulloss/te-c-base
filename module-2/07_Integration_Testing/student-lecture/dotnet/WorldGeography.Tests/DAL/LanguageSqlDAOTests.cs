using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorldGeography.DAL;
using WorldGeography.Models;
using WorldGeography.Tests.DAL;

namespace WorldGeography.Tests
{
    [TestClass]
    public class LanguageSqlDAOTests : WorldDAOTests
    {
        [TestMethod]
        [DataRow("USA", 1)]
        [DataRow("XYZ", 0)]
        public void GetLanguagesTest(string countryCode, int expectedCount)
        {
            // Arrange
            LanguageSqlDAO sqlDao = new LanguageSqlDAO(ConnectionString);

            // Act
            IList<Language> languages = sqlDao.GetLanguages(countryCode);

            // Assert
            Assert.AreEqual(expectedCount, languages.Count);

        }

        [TestMethod]
        [DataRow("Pig Latin")]
        [DataRow("Javanese")]
        [DataRow("C#inese")]
        public void AddLanguage(string name)
        {
            // Arrange
            LanguageSqlDAO sqlDao = new LanguageSqlDAO(ConnectionString);

            int initialRows = GetRowCount("countrylanguage");

            // Act
            sqlDao.AddNewLanguage(
                new Language {
                    CountryCode = "USA",
                    IsOfficial = false,
                    Name = name,
                    Percentage = 1
                }
            );

            int afterRows = GetRowCount("countrylanguage");

            // Assert
            Assert.AreNotEqual(initialRows, afterRows);

        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void AddLanguage_FailsBecauseLanguageExists()
        {
            // Arrange
            
            LanguageSqlDAO sqlDao = new LanguageSqlDAO(ConnectionString);
            Language language = new Language {
                CountryCode = "USA",
                Name = "Test Language",
                IsOfficial = true,
                Percentage = 100
            };

            // Act

            sqlDao.AddNewLanguage(language);

            // Assert
            // SqlException is expected to be thrown
        }

        [TestMethod]
        public void RemoveLanguage()
        {
            // Arrange

            LanguageSqlDAO sqlDao = new LanguageSqlDAO(ConnectionString);
            Language language = new Language {
                CountryCode = "USA",
                Name = "Test Language",
                IsOfficial = true,
                Percentage = 100
            };

            // Act

            bool result = sqlDao.RemoveLanguage(language);

            // Assert
            Assert.IsTrue(result);

        }

    }
}
