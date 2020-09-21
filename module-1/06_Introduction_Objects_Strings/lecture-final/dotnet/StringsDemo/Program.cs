using System;
using System.Xml;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //datatype(which can be a class) identifier = new datatype(intial values); 
            string katie = new string("Katie");
            //House katiesHouse = new House(3, 2, "blue");
            string nullStr; 
            string emptyString = ""; 

            string name = "Ada Lovelace";
            name = "Jim bob";
            name.Split(" ");
            name.ToUpper();  //this line DOES NOT change name, name = name.ToUpper(); 

            /*Pass by Value vs Pass by Reference */
            int[] myArray = { 1, 1, 11 };
            changeArrayParams(myArray);
            changeIntParams(myArray[1]);
            //what's going to print from below
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine(myArray[i]);
            }
            int[] arr2 = { 5, 1, 11 }; //this contains the same VALUES as myArray at this point
            int[] arr3 = myArray;
            Console.WriteLine("arr2 == myArray is " + (arr2 == myArray));  
            Console.WriteLine("arr3 == myArray is " + (arr3 == myArray));
            //arr1 == arr2 MEANS ARE THEY POINTING TO THE SAME PLACE IN MEMORY
            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            name = "Ada Lovelace";
            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e

            Console.WriteLine("First and Last Character. {0} {1}", name.Substring(0, 1), name[name.Length - 1]);
            Console.WriteLine(name.Substring(0, 1));
            Console.WriteLine(name[name.Length - 1]);

            // 2. How do we write code that prints out the first three characters
            // Output: Ada

             Console.WriteLine("First 3 characters: {0} ",name.Substring(0,3));
             

            // 3. Now print out the first three and the last three characters
            // Output: Adaace

             Console.WriteLine("First and Last 3 characters: {0}{1} ",name.Substring(0,3), name.Substring(name.Length-3,3));

            // 4. What about the last word?
            // Output: Lovelace

            //split by space, and then get the last element in the array
            string[] words = name.Split(' ');
            Console.WriteLine("last word using split:" + words[words.Length - 1]);

            //find the index of the last space and then get the substring to the right of that
            int lastSpace = name.LastIndexOf(' ');
            Console.WriteLine("Last word"+name.Substring(lastSpace));

            // Console.WriteLine("Last Word: ");

            // 5. Does the string contain inside of it "Love"?
            // Output: true

            Console.WriteLine("Contains \"Love\" " + name.Contains("Love"));
            Console.WriteLine("Contains \"love\" " + name.Contains("love")); //this IS CASE SENSITIVE

            bool caseInsensitive = name.ToUpper().Contains("LOVE"); 

            // 6. Where does the string "lace" show up in name?
            // Output: 8

            Console.WriteLine("Index of \"lace\": " + name.IndexOf("lace") );

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3

            //treat it as an array of characters, search/loop through and check for a's
            int count = 0;
            for (int i=0; i<name.Length; i++)
            {
                if (name[i] == 'a' || name[i] == 'A')
                    count++;             
            }

            //look for the first 'a' or 'A' and then look in the rest of the substring using IndexOf
            int countUsingIndex = 0;
            char[] searchFor = { 'a', 'A' };
            int index = name.IndexOfAny(searchFor);
            string rest = name;
            while (index != -1)
            {
                countUsingIndex++;
                rest = rest.Substring(index + 1);
                index = rest.IndexOfAny(searchFor);
            }

            Console.WriteLine("Number of \"a's\": " + count+ " using index:" + countUsingIndex);

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"

            name = name.Replace("Ada", "Ada, Countess of Lovelace");

             Console.WriteLine(name);

            // 9. Set name equal to null.
            name = null;

            // 10. If name is equal to null or "", print out "All Done".
            if (name==null || name == "")
            {
                Console.WriteLine("All Done");
            }


            Console.ReadLine();
        }

        static void changeArrayParams (int[] array)
        {
            array[0] = 5;
        }

        static void changeIntParams(int x)
        {
            x = 10;
           // myArray[1] = x; myArray is not in scope
        }
    }
}