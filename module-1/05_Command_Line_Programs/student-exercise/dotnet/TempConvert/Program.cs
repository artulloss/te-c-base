using System;

namespace TempConvert
{
    /// <summary>
    /// Program should look like this
    /// 
    /// Please enter the temperature: 58
    /// Is the temperature in (C)elsius, or (F)ahrenheit? F
    /// 58F is 14C.
    ///
    /// Conversion Formula: Tc = (Tf - 32) / 1.8
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string strTemp = PromptForInput("Please enter the temperature: ");
            bool validTemp = int.TryParse(strTemp, out int temp);
            if (!validTemp)
            {
                Console.WriteLine("Please enter a valid temperature.");
                Main(args);
                return;
            }
            bool tempTypeValid = false;
            bool isFahrenheit = false;
            while (!tempTypeValid)
            {
                string strTempType = PromptForInput("Is the temperature in (C)elsius or (F)ahrenheit? ");
                string lowerStrTempType = strTempType.ToLower();
                if (lowerStrTempType == "c" || lowerStrTempType == "celsius")
                {
                    tempTypeValid = true;
                }
                else if (lowerStrTempType == "f" || lowerStrTempType == "fahrenheit")
                {
                    isFahrenheit = true;
                    tempTypeValid = true;
                }
            }
            double convertedTemp = isFahrenheit ? (temp - 32) / 1.8 : temp * 1.8 + 32;
            Console.WriteLine(temp + (isFahrenheit ? "F" : "C") + " is " + convertedTemp + (isFahrenheit ? "C." : "F."));
        }
        static string PromptForInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}