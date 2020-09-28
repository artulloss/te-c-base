using InheritanceLecture.Auctioneering;
using System;
using System.Collections.Generic;

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
            //generalAuction.HasEnded = true; not allowed because private set
          
            generalAuction.PlaceBid(new Bid("Josh", 1));
            generalAuction.PlaceBid(new Bid("Fonz", 23));
            generalAuction.PlaceBid(new Bid("Rick Astley", 13));
            Bid katieBid = new Bid("Katie", 25);
            generalAuction.PlaceBid(katieBid);

            //....
            //....
            // This might go on until the auction runs out of time or hits a max # of bids

            Console.WriteLine("****RESERVE AUCTION****");
            ReserveAuction reserve = new ReserveAuction(50);
            reserve.PlaceBid(new Bid("katie", 25));
            Console.WriteLine("Has the auction ended? " + reserve.HasEnded);
            reserve.PlaceBid(new Bid("eric", 75));

            Console.WriteLine("****Buyout AUCTION****");
            BuyoutAuction buyout = new BuyoutAuction(50);
            buyout.PlaceBid(new Bid("katie", 25));
            Console.WriteLine("Has the auction ended? " + buyout.HasEnded);
            buyout.PlaceBid(new Bid("eric", 75));
            buyout.PlaceBid(new Bid("amy", 100));

            Auction myAuction = new ReserveAuction(100);
            List<Auction> allTheAuctions = new List<Auction>();
            allTheAuctions.Add(new ReserveAuction(50));
            allTheAuctions.Add(new ReserveAuction(550));
            allTheAuctions.Add(new Auction());
            allTheAuctions.Add(new BuyoutAuction(1000));

            foreach(Auction a in allTheAuctions)
            {
                Bid makeMyBid = new Bid("katie", 45);
                a.PlaceBid(makeMyBid);
            }

            Console.ReadLine();
        }
    }
}
