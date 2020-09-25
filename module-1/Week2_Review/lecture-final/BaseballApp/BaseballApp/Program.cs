﻿using BaseballApp.Classes;
using System;

namespace BaseballApp
{
    /*
        The application should ask the coach how many players are on his/her team. 

        For each player, the application should ask for the players name, number of times at bat, and number of hits.

        The application should then print the name and batting average of each player.

        Lastly, the application should print the player's name and batting average for the player with the highest batting average. 
        In case of a tie, the first player entered should be the one that prints.

        Notes: this application does NOT need to worry with making sure that user input is the correct TYPE. So if we ask for an int, we can 
        assume that the user enters an int. BUT, we cannot assume that the user enters data taht makes sense so we should check that.
    */
    class Program
    {
        static void Main(string[] args)
        {
            const int MIN_PLAYERS_ON_TEAM = 1; //only you can prevent magic numbers
            const int MAX_PLAYERS_ON_TEAM = 20;

            /* make sure that the user entered a reasonable number of players and keep asking them if they didn't*/
            Console.WriteLine("Hi, coach! ");

            int numPlayers = getIntInput("How many players are on your team?", MIN_PLAYERS_ON_TEAM, MAX_PLAYERS_ON_TEAM);

            BaseballPlayer[] players = new BaseballPlayer[numPlayers];

            for (int i = 0; i < numPlayers; i++)
            {
                BaseballPlayer bp = new BaseballPlayer(); 
                Console.WriteLine("What is the players name?");
                bp.Name = Console.ReadLine();

                int atBat = getIntInput("How many times has the player been at bat?", 1, 24);
                bp.AtBats = atBat; 
                /*
                Console.WriteLine("How many times has the player been at bat?");
                string strAtBat = Console.ReadLine();
                double atBat = double.Parse(strAtBat);
                */

                int timesHit = getIntInput("How many times has the player hit?", 0, atBat);
                bp.NumHits = timesHit;
                /*
                Console.WriteLine("How many times has the player hit?");
                string strTimesHit = Console.ReadLine();
                int timesHit = int.Parse(strTimesHit);
                */

                players[i] = bp; 

            }

            //print the name and batting average of each player
            Console.WriteLine("Player name\tBatting average");
            /* prefer the foreach loop because we don't care about the index i and we aren't chagning it
            for (int i =0; i<numPlayers; i++)
            {
                Console.WriteLine(players[i].Name + " " + players[i].BattingAverageString); 
            }
            */

            foreach (BaseballPlayer b in players)
            {
                Console.WriteLine(b.Name + "\t" + b.BattingAverageString);
            }

            //print the player name and batting average of the player with the highest batting average
            BaseballPlayer playerWithHighestBattingAverage = players[0];           
            for(int i=1; i<numPlayers; i++) //start at one because we're assuming first element is the highest to start
            {
                if (players[i].BattingAverage > playerWithHighestBattingAverage.BattingAverage)
                {
                    playerWithHighestBattingAverage = players[i];
                }
            }
            Console.WriteLine(playerWithHighestBattingAverage.Name + " had the best batting average of " + playerWithHighestBattingAverage.BattingAverageString);

            /*
            Console.WriteLine("Fun with strings at the end");
            string languages = "C#;Java;javascript";
            string[] arrayLanguages = languages.Split("java");

            string sentence = "we will be done in time to each lunch at a reasonable time.";
            string[] words = sentence.Split(' ');
            Console.WriteLine("the third word is " + words[2]);
            */

        }

        static int getIntInput(string msg, int low, int high)
        {
            int retValue = low-1;
            bool hasError = false;
            while(retValue<low || retValue>high) //while the user entry is lower than low or higher than high
            {
                if (hasError)
                {
                    Console.WriteLine("You have entered invalid input. Please enter an int between {0} and {1}", low, high);
                }
                Console.WriteLine(msg); //prompt them for the input
                string input = Console.ReadLine();
                retValue = int.Parse(input); //read it in again
                hasError = true;
            }
            return retValue; //once they give us valid data, it kicks out of the while loop so we should return
        }
    }
}
