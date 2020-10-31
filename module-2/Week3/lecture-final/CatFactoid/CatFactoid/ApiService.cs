using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatFactoid
{
    public class ApiService
    {
        private string API_URL;
        RestClient client = new RestClient();
        public ApiService(string url)
        {
            API_URL = url;
        }

        public string GetRandomCatFact()
        {
            RestRequest request = new RestRequest(API_URL);
            IRestResponse<CatFact> restResponse = client.Get<CatFact>(request);
            return restResponse.Data.Fact;
        }
    }
}
