using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;

namespace TenmoClient
{
    public class ApiService
    {
        private RestClient client = new RestClient();
        private const string API_URL = "https://localhost:44315/";

        public ApiService(string token="")
        {
            client.Authenticator = new JwtAuthenticator(token);
        }

        public void SetAuth(string token)
        {
            client.Authenticator = new JwtAuthenticator(token);
        }

        public int GetCountUsers()
        {            

            RestRequest request = new RestRequest(API_URL + "users/count");            
            IRestResponse<int> response = client.Get<int>(request);
            //check the response
            
            return response.Data;
        }
    }
}
