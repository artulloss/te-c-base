using System;

namespace LinearConvert
{
    /// <summary>
    /// Please enter the length: 58
    /// Is the measurement in (m)eter, or (f)eet? f
    /// 58f is 17m.
    /// 
    /// Conversion Formulas
    /// m = f * 0.3048
    /// f = m * 3.2808399
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            if (!double.TryParse(PromptForInput("Please enter the length: "), out double length) || length < 0)
            {
                Console.WriteLine("Please enter a valid length!");
                Main(args);
            }

            string unit = PromptForInput("Is the measurement in (m)eters, or (f)eet? ");
            unit = unit.ToLower();
            if (unit == "m" || unit == "meters")
            {
                Console.WriteLine(length + "m is " + length * 3.2808399 + "f.");
                return;
            } 
            if (unit == "f" || unit == "feet")
            {
                Console.WriteLine(length + "f is " + length * 0.3048 + "m.");
                return;
            }
            Main(args);
        }

        static string PromptForInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

    }
}
