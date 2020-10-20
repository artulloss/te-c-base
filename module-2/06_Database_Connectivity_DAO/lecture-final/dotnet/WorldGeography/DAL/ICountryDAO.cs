using System;
using System.Collections.Generic;
using System.Text;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public interface ICountryDAO
    {
        /// <summary>
        /// Gets all countries.
        /// </summary>
        /// <returns></returns>
        IList<Country> GetCountries();

        /// <summary>
        /// Gets all countries for a continent.
        /// </summary>
        /// <param name="continent">The continent to filter by.</param>
        /// <returns></returns>
        IList<Country> GetCountries(string continent);

        /// <summary>
        /// Get a list of the countries where the language is spoken
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        List<Country> GetCountriesSpeakingLanguage(string language);
    }
}
