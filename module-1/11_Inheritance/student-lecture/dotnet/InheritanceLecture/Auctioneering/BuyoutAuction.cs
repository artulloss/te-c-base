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
        /// <param name="buyoutPrice">The max auction price</param>
        public BuyoutAuction(int buyoutPrice = 500)
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