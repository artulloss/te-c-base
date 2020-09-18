using System;

namespace BaseballApp
{
    class Program
    {
        public const short MIN_PLAYERS = 1;
        public const short MAX_PLAYERS = 20;
        public const short MIN_AT_BAT = 1;
        public const short MAX_AT_BAT = 24;
        static void Main(string[] args)
        {
            short playerCount = 0;
            while (playerCount < MIN_PLAYERS || playerCount > MAX_PLAYERS)
                playerCount = PromptForShort("How many players are on the team?: ");
            Player[] players = new Player[playerCount];
            string name;
            short timesAtBat;
            short numberOfHits;
            for (short i = 0; i < playerCount; i++)
            {
                Console.Write("What is the players name?: ");
                name = Console.ReadLine();
                timesAtBat = 0;
                while (timesAtBat < MIN_AT_BAT || timesAtBat > MAX_AT_BAT)
                    timesAtBat = PromptForShort("How many times has the player been at bat?: ");
                numberOfHits = -1;
                while (numberOfHits < 0 || numberOfHits > MAX_AT_BAT || numberOfHits > timesAtBat)
                    numberOfHits = PromptForShort("How many times did the player hit?: ");
                Player player = new Player(name, timesAtBat, numberOfHits);
                players[i] = player;
            }


            Player bestPlayer = new Player("Invalid", 1, 0);
            double bestBattingAvg = -1;
            foreach (Player player in players)
            {
                double battingAvg = (double) player.GetNumberOfHits() / player.GetTimesAtBat();
                if (battingAvg > (double) bestPlayer.GetNumberOfHits() / bestPlayer.GetTimesAtBat())
                {
                    bestPlayer = player;
                    bestBattingAvg = battingAvg;
                }

                Console.WriteLine("Player            Batting Average");
                Console.WriteLine(player.GetName() + "            " + battingAvg);
            }
            Console.WriteLine(bestPlayer.GetName() + " had the highest batting average of " + bestBattingAvg);
        }

        public static short PromptForShort(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if(short.TryParse(Console.ReadLine() ?? "0", out short n))
                    return n;
            }
        }

    }
}
