using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Ada Lovelace";

            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e

            Console.WriteLine("First and Last Character. ");

            char first = name[0];
            //Console.WriteLine(name.Substring(0, 1));
            char last = name[name.Length - 1];
            //Console.WriteLine(name.Substring(name.Length - 1, 1));

            Console.WriteLine("First: {0}, Last: {1}", first, last);

            // 2. How do we write code that prints out the first three characters
            // Output: Ada

            Console.WriteLine("First 3 characters: {0}", name.Substring(0, 3));
            //Console.WriteLine(name[0] + name[1] + name[2]);

            // 3. Now print out the first three and the last three characters
            // Output: Adaace

            Console.WriteLine("Last 3 characters: " + name.Substring(0, 3) + name.Substring(name.Length - 3, 3));

            // 4. What about the last word?
            // Output: Lovelace

            // Console.WriteLine("Last Word: ");

            string[] splitName = name.Split(" ");
            Console.WriteLine(splitName[splitName.Length - 1]);

            Console.WriteLine(name.Substring(name.LastIndexOf(" ", StringComparison.CurrentCulture) + 1));

            // 5. Does the string contain inside of it "Love"?
            // Output: true
            string lName = name.ToLower();
            Console.WriteLine("Contains \"Love\": " + name.Contains("Love"));
            Console.WriteLine("Contains \"Love\" (case insensitive)" + lName.Contains("love"));

            // 6. Where does the string "lace" show up in name?
            // Output: 8

            Console.WriteLine("Index of \"lace\": " + name.IndexOf("lace", StringComparison.CurrentCulture));

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3

            int count = 0;
            for (int i = 0; i < name.Length; i++)
            {
                //if (name[i].ToString().ToLower() == "a")
                if (name[i] == 'a' || name[i] == 'A')
                    count++;
            }

            Console.WriteLine("Number of \"a's\": {0}", count);

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"

            name.Replace("Ada", "Ada, Countess of Lovelace");

            Console.WriteLine(name);

            // 9. Set name equal to null.


            name = null;

            // 10. If name is equal to null or "", print out "All Done".

            if(name == null || name == "")
                Console.WriteLine("All Done");
        }
    }
}