using RestSharp;
using System.Collections.Generic;

namespace AuctionApp
{
    public class APIService
    {
        static readonly string API_URL = "http://localhost:3000/";
        static readonly RestClient Client = new RestClient();
        private T GetRequest<T>(string endpoint) where T : new()
        {
            RestRequest request = new RestRequest(endpoint);
            return Client.Get<T>(request).Data;
        }
        
        public List<Auction> GetAllAuctions()
        {
            return GetRequest<List<Auction>>(API_URL + "auctions");
        }

        public Auction GetDetailsForAuction(int auctionId)
        {
            return GetRequest<Auction>(API_URL + $"auctions/{auctionId}");
        }

        public List<Auction> GetAuctionsSearchTitle(string searchTitle)
        {
            return GetRequest<List<Auction>>(API_URL + $"auctions?title_like={searchTitle}");
        }

        public List<Auction> GetAuctionsSearchPrice(double searchPrice)
        {
            return GetRequest<List<Auction>>(API_URL + $"auctions?currentBid_lte={searchPrice}");
        }
    }
}