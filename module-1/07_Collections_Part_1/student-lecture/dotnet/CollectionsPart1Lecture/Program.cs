using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CollectionsPart1Lecture
{
    public class CollectionsPart1Lecture
	{
        static void Main(string[] args)
        {
			Console.WriteLine("####################");
			Console.WriteLine("       LISTS");
			Console.WriteLine("####################");

			List<string> names = new List<string>()
            {
				"Adam",
				"Zach",
				"Lisa",
            };


			Console.WriteLine("####################");
			Console.WriteLine("Lists are ordered");
			Console.WriteLine("####################");

            Console.WriteLine(string.Join('|', names));

			Console.WriteLine("####################");
			Console.WriteLine("Lists allow duplicates");
			Console.WriteLine("####################");

			names.Add("Adam");

            Console.WriteLine(string.Join('|', names));

			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be inserted in the middle");
			Console.WriteLine("####################");

			names.Insert(names.Count / 2, "Jeff");
            Console.WriteLine(string.Join('|', names));

			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be removed by index");
			Console.WriteLine("####################");

			names.RemoveAt((names.Count - 1) / 2);

			Console.WriteLine("####################");
			Console.WriteLine("Find out if something is already in the List");
			Console.WriteLine("####################");

			if(names.Contains("Adam"))
				Console.WriteLine("Adam is in the list");

			Console.WriteLine("####################");
			Console.WriteLine("Find index of item in List");
			Console.WriteLine("####################");

			Console.WriteLine("Adam first appears at " + names.IndexOf("Adam"));


			Console.WriteLine("####################");
			Console.WriteLine("Lists can be turned into an array");
			Console.WriteLine("####################");

            string[] namesArray = names.ToArray();

            Console.WriteLine(string.Join('|', namesArray));

            Console.WriteLine("####################");
			Console.WriteLine("Lists can be sorted");
			Console.WriteLine("####################");

			names.Sort();
            Console.WriteLine(string.Join('|', names));

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be reversed too");
			Console.WriteLine("####################");

            names.Reverse();
            Console.WriteLine(string.Join('|', names));

			Console.WriteLine("####################");
			Console.WriteLine("       FOREACH");
			Console.WriteLine("####################");
			Console.WriteLine();

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            Dictionary<string, int> quizScores = new Dictionary<string, int>
            {
                { "Lisa", 100 },
                { "Juan", 95 },
                { "Adam", 90 }
            };
            foreach (var name in quizScores.Keys.ToList())
            { 
                Console.WriteLine(name + " has score " + quizScores[name]);   
            }

            Queue<string> instructorWaitingQueue = new Queue<string>();
			instructorWaitingQueue.Enqueue(("Adam"));
			instructorWaitingQueue.Enqueue("Lisa");
			instructorWaitingQueue.Enqueue("Jason");
			instructorWaitingQueue.Enqueue("Travis");
            //Console.WriteLine("helping " + instructorWaitingQueue.Peek());
            //instructorWaitingQueue.Dequeue();
			//Console.WriteLine("helping " + instructorWaitingQueue.Dequeue());
			// This does all
            while (instructorWaitingQueue.Count > 0)
            {
				Console.WriteLine("helping " + instructorWaitingQueue.Dequeue());
            }

			Stack<string> webSitesVisited = new Stack<string>();
			webSitesVisited.Push("duckduckgo.com");
			webSitesVisited.Push("discord.gg");
			webSitesVisited.Push("youtube.com");
			webSitesVisited.Push("github.com");

            while(webSitesVisited.Count > 0)
            { 
                Console.WriteLine("Last website " + webSitesVisited.Pop());
            }
        }
	}
}