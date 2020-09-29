namespace InheritanceLecture.Auctioneering
{
    public class ReserveAuction : Auction
    {
        private int _reservePrice;

        public ReserveAuction(string itemToBeAuctioned, int reservePrice) : base(itemToBeAuctioned)
        {
            _reservePrice = reservePrice;
        }

        public override bool PlaceBid(Bid offeredBid)
        {
            return offeredBid.BidAmount >= _reservePrice && base.PlaceBid(offeredBid);
        }
    }
}