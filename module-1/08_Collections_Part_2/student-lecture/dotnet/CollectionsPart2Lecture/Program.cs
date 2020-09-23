using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsPart2Lecture
{
    public class CollectionsPart2Lecture
	{
        static void Main(string[] args)
        {
			Console.WriteLine("####################");
			Console.WriteLine("       DICTIONARIES");
			Console.WriteLine("####################");
			Console.WriteLine();

			// Lookup if we paid by SSN
			
			// By SSN if we paid in full

			Dictionary<string, bool> paidInFullBySSN = new Dictionary<string, bool>();

			paidInFullBySSN["111-11-1111"] = true;
			paidInFullBySSN["222-22-2222"] = false;
			paidInFullBySSN["111-11-1111"] = true;
			paidInFullBySSN.Add("333-33-333", false);
			// paidInFullBySSN.Add("333-33-333", true); // ERROR
			// Dictionary[<Key>] = <Value> Will update or set
			// Dictionary.Add(<Key>, <Value>) Will set, error on update
			
			// Zip Codes
			
			Dictionary<string, string> zipCodes = new Dictionary<string, string>()
			{
				{"Jacob", "45419"},
				{"Katie", "45419"},
				{"Adam", "45241"}
			};
			
			// Basketball Coach - for ONE team and want to track the fouls for your team only
			
			Dictionary<int, int> fouls = new Dictionary<int, int>();
			AddFoulToPlayer(fouls, 35); // Jason, number 35 is a brute
			AddFoulToPlayer(fouls, 34);
			AddFoulToPlayer(fouls, 35);
			AddFoulToPlayer(fouls, 35);
			AddFoulToPlayer(fouls, 35);
			AddFoulToPlayer(fouls, 18);
			AddFoulToPlayer(fouls, 1);
			Console.WriteLine($"player 35 has {fouls[35]} fouls.");

			if(fouls.Remove(1)) // False if 1 doesnt exist
				Console.WriteLine("Removed all fouls from player with jersey 1");

	        foreach (KeyValuePair<int, int> kvp in fouls)
			{
				Console.WriteLine($"Key: {kvp.Key} Value: {kvp.Value}");
			}

	        // Sets

	        HashSet<string> studentsWhoReturnedLaptops = new HashSet<string> {"Amy", "Eric"};

	        Console.WriteLine($"Did Amy return her laptop? {studentsWhoReturnedLaptops.Contains("Amy")}");
	        Console.WriteLine($"Did Adam return his laptop? {studentsWhoReturnedLaptops.Contains("Adam")}");
	        
	        HashSet<string> studentsWhoReturnedMonitors = new HashSet<string>();

	        studentsWhoReturnedMonitors.Add("Adam");
	        studentsWhoReturnedMonitors.Add("Lisa");
	        studentsWhoReturnedMonitors.Add("Amy");
	        
	        Console.WriteLine($"Students who returned both a laptop and monitor: {String.Join('|', studentsWhoReturnedLaptops.Intersect(studentsWhoReturnedMonitors))}");
	        Console.WriteLine($"Students who returned a laptop or a monitor: {String.Join('|', studentsWhoReturnedLaptops.Union(studentsWhoReturnedMonitors))}");
	        
        }

        private static void AddFoulToPlayer(Dictionary<int, int> fouls, int jerseyNumber)
        {
	        fouls[jerseyNumber] = fouls.ContainsKey(jerseyNumber) ? fouls[jerseyNumber] + 1 : 1;
        }
        
	}
}
