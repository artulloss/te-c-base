using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
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
            ILanguageDAO dao = new LanguageSqlDAO(ConnectionString);

            //Act
            IList<Language> list = dao.GetLanguages(countryCode);
            //Assert
            Assert.AreEqual(expectedCount, list.Count);


            /* Not using DataRow attributes
            // Act
            IList<Language> list = dao.GetLanguages("USA");
            // Assert
            Assert.AreEqual(1, list.Count);
            list = dao.GetLanguages("XYZ");
            // Assert
            Assert.AreEqual(0, list.Count);
            */


        }

        [TestMethod]
        public void AddLanguage()
        {
            // Arrange
            Language lang = new Language();
            lang.CountryCode = "USA";
            lang.IsOfficial = false;
            lang.Name = "Wakandian";
            lang.Percentage = 5;

            ILanguageDAO dao = new LanguageSqlDAO(ConnectionString);

            // Act
            int beforeRowCount = GetRowCount("countrylanguage");
            bool result = dao.AddNewLanguage(lang);

            // Assert
            Assert.IsTrue(result);

            ICollection<Language> allUSLanguages = dao.GetLanguages("USA");           
            CollectionAssert.Contains((ICollection)allUSLanguages, lang);

            Assert.AreEqual(beforeRowCount + 1, GetRowCount("countrylanguage"));

        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void AddLanguage_FailsBecauseLanguageExists()
        {
            // Arrange
            ILanguageDAO dao = new LanguageSqlDAO(ConnectionString);
            ICollection<Language> allUSLanguages = dao.GetLanguages("USA");
            Language dup = allUSLanguages.ToArray()[0];
            //dup.Name = "something else"; the PK is the language and the countrycode so if we change the name, then it doesn't have a pk dup
            
            // Act
            dao.AddNewLanguage(dup);

            // Assert
            // SqlException is expected to be thrown
        }

        [TestMethod]
        public void RemoveLanguage()
        {
            // Arrange
            ILanguageDAO dao = new LanguageSqlDAO(ConnectionString);
            ICollection<Language> allUSLanguages = dao.GetLanguages("USA");
            Language lang = allUSLanguages.ToArray()[0];

            // Act
            int beforeRowCount = GetRowCount("countrylanguage");
            bool result = dao.RemoveLanguage(lang);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(beforeRowCount - 1, GetRowCount("countrylanguage"));

        }

        [TestMethod]
        public void TestUpdateLanguage()
        {
            //Arrange
            ILanguageDAO dao = new LanguageSqlDAO(ConnectionString);
            ICollection<Language> allUSLanguages = dao.GetLanguages("USA");
            Language lang = allUSLanguages.ToArray()[0];

            lang.Percentage = 50;

            //Act
            bool result = dao.UpdateLanguage(lang);

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(50, lang.Percentage);//this is NOT checkign the DAO

            ICollection<Language> updatedLanguages = dao.GetLanguages("USA");
            CollectionAssert.Contains((ICollection)updatedLanguages, lang);
        }

    }
}
