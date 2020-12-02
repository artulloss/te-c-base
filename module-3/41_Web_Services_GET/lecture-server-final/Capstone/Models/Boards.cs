using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Rootobject
    {
        public Board[] boards { get; set; }
    }

    public class Board
    {
        public int id { get; set; }
        public string title { get; set; }
        public string backgroundColor { get; set; }
        public Card[] cards { get; set; }
    }

    public class Card
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string avatar { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public string tag { get; set; }
        public Comment[] comments { get; set; }
    }

    public class Comment
    {
        public int id { get; set; }
        public string author { get; set; }
        public string body { get; set; }
        public string postedOn { get; set; }
    }
}
