using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;

namespace AuctionApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao _dao;

        public AuctionsController(IAuctionDao auctionDao = null) {
            _dao = auctionDao ?? new AuctionDao();
        }
        
        [HttpGet]
        public List<Auction> GetAuctions(string title, string title_like, double currentBid_lte = 0) {
            return _dao.List().Where(a =>
            { // I kind of wrote this without realizing there were functions in the DAO that do it for you
                bool titleEqual = title == null || a.Title == title; // Added this one extra
                bool titleLike = title_like == null || a.Title.ToLower().Contains(title_like.ToLower());
                bool lessThanEqual = currentBid_lte == 0 || a.CurrentBid <= currentBid_lte;
                return titleEqual && titleLike && lessThanEqual;
            }).ToList();
        }

        [HttpGet("{id}")]
        public Auction GetAuctionById(int id) {
            return _dao.Get(id);
        }

        [HttpPost]
        public Auction CreateAuction(Auction auction) {
            return _dao.Create(auction);
        }
    }
}
