using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;

namespace AuctionApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao dao;

        public AuctionsController(IAuctionDao auctionDao)
        {
            dao = auctionDao;
        }

        [HttpGet]
        public List<Auction> List(string title_like = "", double currentBid_lte = 0)
        {
            if (title_like != "")
            {
                return dao.SearchByTitle(title_like);
            }
            if (currentBid_lte > 0)
            {
                return dao.SearchByPrice(currentBid_lte);
            }

            return dao.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Auction> Get(int id)
        {
            Auction auction = dao.Get(id);
            if (auction != null)
            {
                return Ok(auction);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Auction> Create(Auction auction) {
            auction = dao.Create(auction);     
            return Created($"/auction/{auction.Id}", auction);
        }

        [HttpPut("/auctions/{id}")]
        public ActionResult<Auction> Update(int id, Auction auction) {
            return dao.Get(id) != null
                ? (ActionResult) Ok(dao.Update(id, auction))
                : NotFound("Auction not found");
        }

        [HttpDelete("/auctions/{id}")]
        public ActionResult Delete(int id) {
            return dao.Delete(id) ? (ActionResult) NoContent() : NotFound("Auction not found");
        }


    }
}
