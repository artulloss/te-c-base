using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceLecture.Auctioneering
{
    /// <summary>
    /// This class represents a general auction.
    /// </summary>
    public class Auction
    {
        /// <summary>
        /// This is an encapsulated field that holds all placed bids.
        /// </summary>
        private List<Bid> allBids = new List<Bid>();

        /// <summary>
        /// Represents the current high bid.
        /// </summary>
        public Bid CurrentHighBid { get; private set; } = new Bid("", 0);

        /// <summary>
        /// All placed bids returned as an array.
        /// </summary>
        public Bid[] AllBids => allBids.ToArray();

        /// <summary>
        /// Indicates if the auction has ended yet.n
        /// </summary>
        public bool HasEnded { get; protected set; }
        
        public string ItemAuctioned { get; }

        public Auction(string itemAuctioned)
        {
            ItemAuctioned = itemAuctioned;
        }

        /// <summary>
        /// Places a Bid on the Auction
        /// </summary>
        /// <param name="offeredBid">The bid to place.</param>
        /// <returns>True if the new bid is the current winning bid</returns>
        public virtual bool PlaceBid(Bid offeredBid)
        {
            // Block bidding on a HasEnded auction
            if (HasEnded) return false;
            
            // Print out the bid details.
            Console.WriteLine(offeredBid.Bidder + " bid " + offeredBid.BidAmount.ToString("C"));

            // Record it as a bid by adding it to allBids
            
            allBids.Add(offeredBid);

            // Check to see IF the offered bid is higher than the current bid amount
                // if yes, set offered bid as the current high bid

            bool changed = false;

            if (offeredBid.BidAmount > CurrentHighBid.BidAmount)
            {
                CurrentHighBid = offeredBid;
                changed = true;
            }

            // Output the current high bid
            
            Console.WriteLine(CurrentHighBid.BidAmount);

            // Return if this is the new highest bid
            return changed;            
        }                
    }
}
