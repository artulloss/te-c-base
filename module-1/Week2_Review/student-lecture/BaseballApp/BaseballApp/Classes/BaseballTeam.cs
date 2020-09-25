using System.Collections.Generic;

namespace BaseballApp.Classes
{
    public class BaseballTeam
    {
        private List<BaseballPlayer> _team = new List<BaseballPlayer>();

        public List<BaseballPlayer> Team => _team;
        public int TeamSize { get; set; }
        public BaseballTeam(int numPlayers)
        {
            TeamSize = numPlayers;
        }
        public void AddPlayer(BaseballPlayer player)
        {
            _team.Add(player);
        }
        public BaseballPlayer getPlayerWithBestBattingAverage()
        {
            BaseballPlayer bestBaseballPlayer = new BaseballPlayer();
            foreach (BaseballPlayer player in _team)
                if (player.BattingAverage > bestBaseballPlayer.BattingAverage)
                    bestBaseballPlayer = player;
            return bestBaseballPlayer;
        }
    }
}