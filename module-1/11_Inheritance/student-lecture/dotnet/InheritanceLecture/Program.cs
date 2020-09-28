using InheritanceLecture.Auctioneering;
using System;

namespace InheritanceLecture
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new general auction
            Console.WriteLine("Starting a general auction");
            Console.WriteLine("-----------------");

            Auction generalAuction = new Auction();
            
            Console.WriteLine("Has the auction ended? " + generalAuction.HasEnded);

            generalAuction.PlaceBid(new Bid("Josh", 1));
            generalAuction.PlaceBid(new Bid("Fonz", 23));
            generalAuction.PlaceBid(new Bid("Rick Astley", 13));
            generalAuction.PlaceBid(new Bid("Katie", 25));
            //....
            //....
            // This might go on until the auction runs out of time or hits a max # of bids
            
            Console.WriteLine("*RESERVE AUCTION*");
            ReserveAuction reserveAuction = new ReserveAuction(50);

            reserveAuction.PlaceBid(new Bid("Katie", 25));
            Console.WriteLine("Has the auction ended? " + generalAuction.HasEnded);
            reserveAuction.PlaceBid(new Bid("Adam", 75));

            Console.WriteLine("*BUYOUT AUCTION*");

            Auction buyoutAuction = new BuyoutAuction();
            buyoutAuction.PlaceBid(new Bid("Josh", 1));
            buyoutAuction.PlaceBid(new Bid("Fonz", 23));
            buyoutAuction.PlaceBid(new Bid("Rick Astley", 13));
            buyoutAuction.PlaceBid(new Bid("Katie", 25));
            
        }
    }
}
