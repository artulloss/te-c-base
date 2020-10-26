using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp
{
    public class APIService
    {
        static readonly string API_URL = "http://localhost:3000/";
        static readonly RestClient Client = new RestClient();

        private class GetRequest<T> where T : new()
        {
            public T Data { get; }
            public GetRequest(string endpoint) {
                RestRequest request = new RestRequest(endpoint);
                Data = Client.Get<T>(request).Data;
            }
        }
        public List<Auction> GetAllAuctions() {
            return new GetRequest<List<Auction>>(API_URL + "auctions").Data;
        }

        public Auction GetDetailsForAuction(int auctionId)
        {
            return new GetRequest<Auction>(API_URL + $"auctions/{auctionId}").Data;
        }

        public List<Auction> GetAuctionsSearchTitle(string searchTitle)
        {
            return new GetRequest<List<Auction>>(API_URL + $"auctions?title_like={searchTitle}").Data;
        }

        public List<Auction> GetAuctionsSearchPrice(double searchPrice)
        {
            return new GetRequest<List<Auction>>(API_URL + $"auctions?currentBid_lte={searchPrice}").Data;
        }
    }
}
