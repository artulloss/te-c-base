using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture.Auctioneering
{
    /// <summary>
    /// A reserve auction has a minimum reserve price. Bids below the reserve are ignored
    /// </summary>
    public class ReserveAuction : Auction
    {
        private int reservePrice;

        public ReserveAuction(int reservePrice)
        {
            this.reservePrice = reservePrice;
        }

        //change the behavior of PlaceBid to ignore bids that don't meet the reserve
        public override bool PlaceBid(Bid offeredBid)
        {
            bool isCurrentWinning = false;
            if (offeredBid.BidAmount >= reservePrice) //if the offered bid meets the reseve
            {
                isCurrentWinning = base.PlaceBid(offeredBid); //base keyword calls the method on the PARENT
                Console.WriteLine("Rserve has been met.");
            } 
            //ignore the bid if it doesn't meet the reseve or do nothing
            return isCurrentWinning;
        }

        public void SomePublicMethod()
        {

        }
    }
}
