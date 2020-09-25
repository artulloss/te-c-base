using System;
using System.Collections.Generic;
using System.Text;

namespace BaseballApp.Classes
{
    public class BaseballTeam
    {
        private List<BaseballPlayer> team = new List<BaseballPlayer>();
        public int TeamSize { get; set; }

        public BaseballTeam(int size)
        {
            TeamSize = size;
        }

        public void AddPlayer(BaseballPlayer p)
        {
            team.Add(p);
        }


        public BaseballPlayer[] Players { get { return team.ToArray(); } }
    }
}
