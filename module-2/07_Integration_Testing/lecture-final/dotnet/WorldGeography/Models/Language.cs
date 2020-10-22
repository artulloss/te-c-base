using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldGeography.Models
{
    public class Language
    {
        public string Name { get; set; }
        public bool IsOfficial { get; set; }
        public int Percentage { get; set; }
        public string CountryCode { get; set; }

        public override bool Equals(object obj)
        {
            Language lang = (Language)obj;
            return lang.Name == this.Name &&
                lang.IsOfficial == this.IsOfficial && 
                lang.Percentage == this.Percentage && 
                lang.CountryCode == this.CountryCode;
        }

        public override string ToString()
        {
            return Name.PadRight(30) + CountryCode.PadRight(5) + (IsOfficial ? "Official" : "Unofficial").PadRight(15) + (Percentage/100.00).ToString("P").PadRight(5);
        }
    }
}
