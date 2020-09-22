using System;
using System.Collections.Generic;


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
				"Zach",
				"Matt",
				"Lisa"
			};
			names.Add("Katie");
			names.Add("Amy");
			names.Add("Jason");

			List<string> students = new List<string>();
			students.AddRange(names);

			List<int> quizScores = new List<int>() { 89, 90, 95, 77, 87, 89, 45 };
			quizScores.Add(100);
			//quizScores.Add(99.5); can only add ints


			Console.WriteLine("####################");
			Console.WriteLine("Lists are ordered");
			Console.WriteLine("####################");
			for (int i=0; i<students.Count; i++)
            {
				Console.WriteLine(students[i]);
            }
			Console.WriteLine("use join to print");
			Console.WriteLine(String.Join('|', students));

			students.Insert(2, "Chris");
			Console.WriteLine("Adding Chris at index 2: "+String.Join('|', students));

			Console.WriteLine("####################");
			Console.WriteLine("Lists allow duplicates");
			Console.WriteLine("####################");
			students.Add("Lisa");
			Console.WriteLine(String.Join('|', students));

			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be inserted in the middle");
			Console.WriteLine("####################");

			students.Insert(4, "Eric");
			Console.WriteLine("\nAdding Eric at index 4: " + String.Join('|', students));


			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be removed by index");
			Console.WriteLine("####################");
			students.RemoveAt(4);
			Console.WriteLine("\nRemove at index 4: " + String.Join('|', students));

			//try remove by name
			students.Remove("Amy");
			Console.WriteLine("\nRemove Amy: " + String.Join('|', students));

			students.Remove("Lisa");
			Console.WriteLine("\nRemove Lisa: " + String.Join('|', students));

			Console.WriteLine("####################");
			Console.WriteLine("Find out if something is already in the List");
			Console.WriteLine("####################");

			//is lisa still in our list?
			Console.WriteLine("Is Lisa in our list? "+students.Contains("Lisa"));


			Console.WriteLine("####################");
			Console.WriteLine("Find index of item in List");
			Console.WriteLine("####################");

			//what's the index of Lisa?
			Console.WriteLine("Found Lisa at index "+students.IndexOf("Lisa"));

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be turned into an array");
			Console.WriteLine("####################");
			string[] studentArray = students.ToArray(); 


			Console.WriteLine("####################");
			Console.WriteLine("Lists can be sorted");
			Console.WriteLine("####################");
			students.Sort();
			Console.WriteLine("\nAfter Sort: " + String.Join('|', students));


			Console.WriteLine("####################");
			Console.WriteLine("Lists can be reversed too");
			Console.WriteLine("####################");
			students.Reverse();
			Console.WriteLine("\nAfter Reverse: " + String.Join('|', students));

			Console.WriteLine("####################");
			Console.WriteLine("       FOREACH");
			Console.WriteLine("####################");
			//print students using a foreach loop
			foreach (string x in names)
			{
				Console.Write(x + "\n"); 
            }
			for (int i=0; i<names.Count; i++)
            {
				string x = names[i];
				Console.Write(x + "\n");
			}

			//BONUS - Add + 10 to all quizScores
			int quizBonus = 10; 
			for(int i=0; i<quizScores.Count; i++)
            {
				quizScores[i] = quizScores[i] + quizBonus; 
            }

			/* it's FORBIDDEN to modify values in the foreach loop
			foreach (string n in names)
            {
				//n = "Dr. " + n; 
            }
			*/

			/*queues FIFO, enqueue dequeue */
			Queue<string> instructorWaitingArea = new Queue<string>();
			instructorWaitingArea.Enqueue("jason");
			instructorWaitingArea.Enqueue("matt");
			instructorWaitingArea.Enqueue("jacob");
			instructorWaitingArea.Enqueue("travis");
			Console.WriteLine("who's next in line? " + instructorWaitingArea.Peek());

			string helping = instructorWaitingArea.Dequeue();
			Console.WriteLine("helping " + helping);
			Console.WriteLine("who's next in line? " + instructorWaitingArea.Peek());
			//help everyone
			while (instructorWaitingArea.Count > 0)
            {
				helping = instructorWaitingArea.Dequeue();
				Console.WriteLine("helping " + helping);
			}


			/*Stack example push pop */
			Stack<string> websitesVisited = new Stack<string>();
			websitesVisited.Push("www.google.com");
			websitesVisited.Push("www.twitter");
			websitesVisited.Push("www.popularmechanics.com");
			websitesVisited.Push("slashdot.com");
			websitesVisited.Push("youtube.com");


			while (websitesVisited.Count > 0)
            {
				//hit the back array
				string lastVisited = websitesVisited.Pop();
				Console.WriteLine("going back to " + lastVisited);
            }

			Console.WriteLine();


		}
	}
}
