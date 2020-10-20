using System;
using System.Collections.Generic;
using System.Text;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class MockCityDAO : ICityDAO
    {
        public void AddCity(City city)
        {
            
        }

        public IList<City> GetCitiesByCountryCode(string countryCode)
        {
            //returns soem fake data
            List<City> list = new List<City>();
            list.Add(new City());
            return list;
        }
    }
}
