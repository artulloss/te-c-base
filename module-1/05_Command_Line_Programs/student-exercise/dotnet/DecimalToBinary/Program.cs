using System;

namespace DecimalToBinary
{
    /// <summary>
    /// Please enter in a series of decimal values (separated by spaces): 460 8218 1 31313 987654321
    ///
    /// 460 in binary is 111001100
    /// 8218 in binary is 10000000011010
    /// 1 in binary is 1
    /// 31313 in binary is 111101001010001
    /// 987654321 in binary is 111010110111100110100010110001
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter in a series of decimal values (separated by spaces): ");
            string[] stringNumbers = (Console.ReadLine() ?? "").Split(" ");
            for (int i = 0; i < stringNumbers.Length; i++)
            {
                if (!int.TryParse(stringNumbers[i], out int number) || number < 0)
                {
                    Main(args);
                    return;
                } 
                //Console.WriteLine(number + " in binary is " + Convert.ToString(number, 2)); // Lazy way
                Console.WriteLine(number + " in binary is " + ConvertIntToBinary(number));
            }
        }
        static string ConvertIntToBinary(int number)
        {
            string output = "";
            while (number > 0)
            {
                output += number % 2 == 0 ? 1 : 0;
                number /= 2;
            }
            return output;
        }
    }
}
