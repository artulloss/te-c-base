using System;

namespace InheritanceLecture.Auctioneering
{
    public class BuyoutAuction : Auction
    {
        private readonly int _buyoutPrice;
        
        /// <summary>
        /// A buyout auction sets a buyout price that the bidder can use
        /// allowing the auction to end
        /// </summary>
        /// <param name="itemToBeAuctioned">The item to be auctioned</param>
        /// <param name="buyoutPrice">The max auction price</param>
        public BuyoutAuction(string itemToBeAuctioned, int buyoutPrice = 500) : base(itemToBeAuctioned)
        {
            _buyoutPrice = buyoutPrice;
        }

        public override bool PlaceBid(Bid offeredBid)
        {
            if (HasEnded)
                return false;
            if (offeredBid.BidAmount >= _buyoutPrice)
            {
                HasEnded = true;
                Console.WriteLine($"{offeredBid.Bidder} bought out the bid!");
            }

            return base.PlaceBid(offeredBid);
        }
    }
}