namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string p1res = "";
        private string p2res = "";
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            p1point = 0;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";
            if (p1point == p2point && p1point < 3)
            {
                score = GetScoreName(p1point);
                score += "-All";
                return score;
            }
            if (p1point == p2point && p1point > 2)
                return "Deuce";

            bool isWinner;
            string winner;
            (isWinner, winner) = IsAPlayerWinning();

            if (isWinner)
            {
                return $"Win for {winner}";
            }

            bool isAdvantage;
            string advantaged;
            (isAdvantage, advantaged) = IsAPlayerAdvantaged();

            if (isAdvantage)
            {
                return $"Advantage {advantaged}";
            }
            

            p1res = GetScoreName(p1point);
            p2res = GetScoreName(p2point);
            score = p1res + "-" + p2res;
            return score;
        }

        private (bool, string) IsAPlayerAdvantaged()
        {
            if (p1point > p2point && p2point >= 3)
            {
                return (true, player1Name);
            }

            if (p2point > p1point && p1point >= 3)
            {
                return (true, player2Name);
            }

            return (false, null);
        }

        private (bool,string) IsAPlayerWinning()
        {
            if (p1point >= 4 && (p1point - p2point) >= 2)
            {
                return (true, player1Name);
            }

            if (p2point >= 4 && (p2point - p1point) >= 2)
            {
                return (true, player2Name);
            }

            return (false, null);
        }

        private string GetScoreName(int points)
        {
            string score = "Forty";
            switch (points)
            {
                case 0:
                    score = "Love";
                    break;
                case 1:
                    score = "Fifteen";
                    break;
                case 2:
                    score = "Thirty";
                    break;
            }

            return score;
        }

        private void P1Score()
        {
            p1point++;
        }

        private void P2Score()
        {
            p2point++;
        }

        public void WonPoint(string player)
        {
            if (player == player1Name)
                P1Score();
            else
                P2Score();
        }

    }
}

