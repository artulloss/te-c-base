using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture.Auctioneering
{
    /// <summary>
    /// A buyout auction sets a buyout price that the bidder can use allowing
    /// the auction to end.
    /// </summary>
    public class BuyoutAuction : Auction
    {
        //data members/instance variables
        private int buyoutPrice;

        public int BuyoutPrice
        {
            get
            {
                return buyoutPrice; 
            }
        }

        //public int BuyoutPrice { get;  } this is an alternative, to just use the property with the automatic backing variable

        public BuyoutAuction(int buyoutPrice)
        {
            this.buyoutPrice = buyoutPrice;
        }

        /// <summary>
        /// if the offeredBid meets the buyoutprice, mark the auction as ended
        /// </summary>
        /// <param name="offeredBid"></param>
        /// <returns></returns>
        public override bool PlaceBid(Bid offeredBid)
        {
            bool isWinning = false;
            //we only do something if the buyout price has not been met yet
            if (!HasEnded)
            {
                //if the offeredBid is bigger than the buyout price we want to mark the auction as ended and bid the buyoutPrice
                if (offeredBid.BidAmount >= buyoutPrice)
                {
                    Bid buyoutBid = new Bid(offeredBid.Bidder, buyoutPrice);
                    isWinning = base.PlaceBid(buyoutBid);
                    //base.MarkAuctionEnded(); //using base might make code easier to read but is optional
                    MarkAuctionEnded();
                    Console.WriteLine("Buyout has been met.");
                }
                else  //either way we'll want to place the bid
                {
                    isWinning = base.PlaceBid(offeredBid);
                }                          

            }
            return isWinning;
        }
    }
}
