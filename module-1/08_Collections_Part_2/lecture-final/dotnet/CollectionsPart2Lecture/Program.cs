using System;
using System.Collections.Generic;

namespace CollectionsPart2Lecture
{
    public class CollectionsPart2Lecture
	{
        static void Main(string[] args)
        {

            /*Review Lists*/
            List<double> quizScores = new List<double>() { 89.5, 50, 94, 85, 62, 55 };
            //print - i could use either
            for (int i = 0; i < quizScores.Count; i++)
            {
                Console.Write(quizScores[i] + " ");
            }
            Console.WriteLine("\n**using foreach**");
            foreach (double score in quizScores)
            {
                Console.Write(score + " ");
            }
            Console.WriteLine("\n**using String join**");
            Console.WriteLine(String.Join(' ', quizScores));

            //what is the average quizScore
            double forSum = 0;
            for (int i = 0; i < quizScores.Count; i++)
            {
                forSum += quizScores[i];
            }
            Console.WriteLine("Average using for: " + forSum / quizScores.Count);

            Console.WriteLine("\n**using foreach**");
            double foreachSum = 0;
            foreach (double score in quizScores)
            {
                foreachSum += score;
            }
            Console.WriteLine("Average using foreach: " + foreachSum / quizScores.Count);

            //did brian fail (<70) two quizzes in a row?
            //a for loop is preferable
            bool failedTwo = false;
            for (int i = 0; i < quizScores.Count - 1; i++)
            {
                if (quizScores[i] < 70 && quizScores[i + 1] < 70)
                {
                    failedTwo = true;
                    break;
                }
            }
            Console.WriteLine("Are there two failures in a row? " + failedTwo);


            //i can force foreach to work. but it's a bit hacky and hard to read
            bool failedTwoInForEach = false;
            bool lastOneFailed = false;
            foreach (double score in quizScores)
            {
                if (score < 70)
                {
                    if (lastOneFailed)
                    {
                        failedTwoInForEach = true;
                        break;
                    }
                    else
                    {
                        lastOneFailed = true;
                    }
                }
            }

            Console.WriteLine("####################");
            Console.WriteLine("       DICTIONARIES");
            Console.WriteLine("####################");
            Console.WriteLine();

            //by ssn if you've paid in full
            Dictionary<string, bool> paidInFullBySSN = new Dictionary<string, bool>();
            paidInFullBySSN["111-11-1111"] = true;
            Console.WriteLine("Has 111-11-1111 paid? " + paidInFullBySSN["111-11-1111"]);
            paidInFullBySSN["222-22-2222"] = false;
            paidInFullBySSN["222-22-2222"] = true;

            // [ ] => add or update
            // .Add => add only; can't update this weay

            //paidInFullBySSN.Add("111-11-1111", true);//ERROR BECAUSE ALREADY EXISTS

            //look up your zip code by your name
            Dictionary<string, string> zipCodes = new Dictionary<string, string>();
            zipCodes["jacob"] = "45419";
            zipCodes["katie"] = "45419";//duplicate VALUES are ok. duplicate keys are FORBIDDEN - it will update

            zipCodes["adddam"] = "45241";
            //oh no i spelled adam's name wrong
            //no way to update key
            zipCodes["adam"] = zipCodes["adddam"];
            zipCodes.Remove("adddam");

            //basketball coach - for ONE team and want to track the fouls for your team only
            Dictionary<int, int> fouls = new Dictionary<int, int>();

            //fouls by playername instead of jersey number
            Dictionary<string, int> foulsByName = new Dictionary<string, int>();
            foulsByName["jason"] = 1; 
            
            AddFoulToPlayer(fouls,35);
            AddFoulToPlayer(fouls, 34);
            //jason is a brute and gets another foul
            AddFoulToPlayer(fouls, 35);
            AddFoulToPlayer(fouls, 35);
            AddFoulToPlayer(fouls, 35);
            AddFoulToPlayer(fouls, 18); //jersey number is the KEY so it must be unique

            AddFoulToPlayer(fouls, 999);
            fouls.Remove(999);

            bool tryToRemove11 = fouls.Remove(11);
            Console.WriteLine("Was 11 in the dictionary previuosly? " + tryToRemove11);

            Console.WriteLine("player 35 has " + fouls[35] + " fouls");

            //is anyone fouled out
            bool someoneFouledOut = fouls.ContainsValue(5);
            Console.WriteLine("has anyone fouled out? " + someoneFouledOut);

            //get the set of all the keys
            //what players have 1 or more fouls?
            IEnumerable<int> playserThisFouls = fouls.Keys;

            //print just the jersey number of who has a foul
            foreach (int key in fouls.Keys)
            {
                Console.WriteLine(key+",");
            }
            //print the jersey number and number of fouls for everyone who has 1 or more fouls
            foreach (int key in fouls.Keys)
            {
                Console.WriteLine("Player number " + key + " has " + fouls[key] + " fouls.");
            }
            //how many players have fouls?
            Console.WriteLine("number of players with fouls: " + fouls.Count);

            //loop through keyvaluepairs
            Console.WriteLine("Loop through all of the key value pairs");
            foreach (KeyValuePair<int,int> kvp in fouls)
            {
                Console.WriteLine("Player number {0} has {1} fouls.", kvp.Key, kvp.Value);
            }

            //quiz scores by student name 
            Dictionary<string, List<double>> quizScoresByName = new Dictionary<string, List<double>>();
            List<double> amysQuizScores = new List<double>() { 99, 89.9, 95, 87 };
            quizScoresByName["amy"] = amysQuizScores;

            /*SETS*/
            HashSet<string> studentsWhoReturnedLaptops = new HashSet<string>();
            studentsWhoReturnedLaptops.Add("amy");
            studentsWhoReturnedLaptops.Add("eric");

            Console.WriteLine("did amy return her laptop? " + studentsWhoReturnedLaptops.Contains("amy"));
            Console.WriteLine("did jason return his laptop? " + studentsWhoReturnedLaptops.Contains("amy"));

        }

        private static void AddFoulToPlayer(Dictionary<int, int> fouls, int jerseyNumber)
        {

            //fouls[35] = fouls[35] + 1; //this will do what i want if jason is already in the dictionary, but if not, it'll fail
            //fouls[35] = 1; //this is assuming this is jason's first foul

            //if jason - key 35 is in the dictionary already, increment his foul count by 1, otherwise add him with 1
            if (fouls.ContainsKey(jerseyNumber))
            {
                fouls[jerseyNumber] = fouls[jerseyNumber] + 1; //updating the key 35 in the dictionary = get the value for key 35 and add 1 to it
                                                               //fouls[jerseyNumber]++; i could also do this
                                                               //fouls[jerseyNumber] += 1; or this also
            }
            else
            {
                fouls[jerseyNumber] = 1; //we are ADDING the key 35 to the dictionary with value 1
                               //fouls.Add(35, 1); this would be safe HERE because I know it's NOT there so i won't get an exception
            }
        }
    }
}
