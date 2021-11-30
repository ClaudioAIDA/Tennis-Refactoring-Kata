namespace Tennis
{
    public class TennisPlayer
    {
        private int score;
        public string Name { get; }
        private static readonly string[] SCORENAMES = { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisPlayer(string name)
        {
            this.Name = name;
        }

        public bool IsWinningTo(TennisPlayer opponent)
        {
            return this.score > opponent.score;
        }

        public string GetScoreName()
        {
            return SCORENAMES[score];
        }

        public bool IsTiedTo(TennisPlayer opponent)
        {
            return this.score == opponent.score;
        }

        public bool IsAdvantagedTo(TennisPlayer opponent)
        {
            return ((this.score - opponent.score) * (this.score - opponent.score) == 1);
        }

        public void WonPoint()
        {
            this.score += 1;
        }

        public bool IsStartingPoint(TennisPlayer opponent)
        {
            return (this.score < 4 && opponent.score < 4) && (this.score + opponent.score < 6);
        }
    }

    public class TennisGame3 : ITennisGame
    {
        private readonly TennisPlayer player1;
        private readonly TennisPlayer player2;

        public TennisGame3(string player1Name, string player2Name)
        {
            player1 = new TennisPlayer(player1Name);
            player2 = new TennisPlayer(player2Name);
        }

        public string GetScore()
        {
            if (player1.IsStartingPoint(player2))
            {
                return player1.IsTiedTo(player2) ? player1.GetScoreName() + "-All" : player1.GetScoreName() + "-" + player2.GetScoreName();
            }

            if (player1.IsTiedTo(player2))
                return "Deuce";
            string winningPlayer = player1.IsWinningTo(player2) ? player1.Name : player2.Name;
            return player1.IsAdvantagedTo(player2) ? "Advantage " + winningPlayer : "Win for " + winningPlayer;
        }


        public void WonPoint(string playerName)
        {
            if (playerName == player1.Name)
                player1.WonPoint();
            else
                player2.WonPoint();
        }
    }
}

