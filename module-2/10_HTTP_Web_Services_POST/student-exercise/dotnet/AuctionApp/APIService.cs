using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AuctionApp
{
    public class APIService
    {
        const string API_URL = "http://localhost:3000/auctions";
        readonly IRestClient client;

        public APIService()
        {
            client = new RestClient();
        }
        public APIService(IRestClient restClient)
        {
            client = restClient;
        }

        private T GetRequest<T>(string endpoint) where T : new() {
            RestRequest request = new RestRequest(endpoint);
            IRestResponse<T> response = client.Get<T>(request);
            return (T) RequestWasSuccessful(response.ResponseStatus, response.StatusCode, response.IsSuccessful, response.Data);
        }
        
        private T PutRequest<T>(string endpoint, object body) where T : new() {
            RestRequest request = new RestRequest(endpoint);
            request.AddJsonBody(body);
            IRestResponse<T> response = client.Put<T>(request);
            return (T) RequestWasSuccessful(response.ResponseStatus, response.StatusCode, response.IsSuccessful, response.Data);
        }
        
        private T PostRequest<T>(string endpoint, object body) where T : new() {
            RestRequest request = new RestRequest(endpoint);
            request.AddJsonBody(body);
            IRestResponse<T> response = client.Post<T>(request);
            return (T) RequestWasSuccessful(response.ResponseStatus, response.StatusCode, response.IsSuccessful, response.Data);
        }
        
        private bool DeleteRequest(string endpoint){
            RestRequest request = new RestRequest(endpoint);
            IRestResponse response = client.Delete(request);
            return response.IsSuccessful && response.ResponseStatus == ResponseStatus.Completed;
        }


        private object RequestWasSuccessful(ResponseStatus responseStatus, HttpStatusCode statusCode, bool isSuccessful, object data) {
            if (responseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("Error occurred - unable to reach server.");
            }
            else if (!isSuccessful)
            {
                Console.WriteLine("Error occurred - received non-success response: " + (int) statusCode);
            }
            else
            {
                return data;
            }
            return null;
        }
        
        public List<Auction> GetAllAuctions() {
            return GetRequest<List<Auction>>(API_URL);
        }

        public Auction GetDetailsForAuction(int auctionId) {
            return GetRequest<Auction>(API_URL + "/" + auctionId);
        }

        public List<Auction> GetAuctionsSearchTitle(string searchTitle)
        {
            return GetRequest<List<Auction>>(API_URL + "?title_like=" + searchTitle);
        }

        public List<Auction> GetAuctionsSearchPrice(double searchPrice)
        {
            return GetRequest<List<Auction>>(API_URL + "?currentBid_lte=" + searchPrice);
        }

        public Auction AddAuction(Auction newAuction) {
            return PostRequest<Auction>(API_URL, newAuction);
        }

        public Auction UpdateAuction(Auction auctionToUpdate) {
            return PutRequest<Auction>(API_URL + $"/{auctionToUpdate.Id}", auctionToUpdate);
        }

        public bool DeleteAuction(int auctionId) {
            return DeleteRequest(API_URL + $"/{auctionId}");
        }
    }
}
