namespace InheritanceLecture.Auctioneering
{
    public class ReserveAuction : Auction
    {
        private int _reservePrice;

        public ReserveAuction(int reservePrice)
        {
            _reservePrice = reservePrice;
        }

        public override bool PlaceBid(Bid offeredBid)
        {
            return offeredBid.BidAmount >= _reservePrice && base.PlaceBid(offeredBid);
        }
    }
}