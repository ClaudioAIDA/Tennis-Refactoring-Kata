using System;

namespace Tennis
{
    class Player
    {
        public int Score { get; private set; }
        public string PlayerName { get; }

        public Player(string playerName)
        {
            PlayerName = playerName;
        }

        public void AddPoint()
        {
            Score++;
        }

        public bool isWinning(Player player2)
        {
            return Score > player2.Score;
        }
    }

    enum ScoreName
    {
        Love = 0,
        Fifteen = 1,
        Thirty = 2,
        Forty = 3,
        Deuce = 4
    }

    class Referee
    {
        public string SayScore(Player player1, Player player2)
        {
            if (player1.Score == player2.Score)
            {
                if (player1.Score >= 3)
                    return ScoreName.Deuce.ToString();

                return GetPointsWord(player1.Score) + "-All";
            }

            if (player1.Score >= 4 || player2.Score >= 4)
            {
                var scoreDifference = Math.Abs(player1.Score - player2.Score);
                var winningPlayer = GetWinningPlayer(player1, player2);
                if (scoreDifference == 1) return "Advantage " + winningPlayer.PlayerName;
                return  "Win for " + winningPlayer.PlayerName;
            }

            return GetPointsWord(player1.Score) + "-" + GetPointsWord(player2.Score);
        }

        private Player GetWinningPlayer(Player player1, Player player2)
        {
            if (player1.isWinning(player2)) return player1;
            return player2;
        }

        private string GetPointsWord(int score)
        {
            return ((ScoreName)score).ToString();
        }

    }

    class TennisGame1 : ITennisGame
    {
        private readonly Player player1;
        private readonly Player player2;
        private readonly Referee referee;

        public TennisGame1(string player1Name, string player2Name)
        {
            player1 = new Player(player1Name);
            player2 = new Player(player2Name);
            referee = new Referee();
        }

        public void WonPoint(string playerName)
        {
            if (player1.PlayerName == playerName)
                player1.AddPoint();
            else
                player2.AddPoint();
        }

        public string GetScore()
        {
            return referee.SayScore(player1, player2);
        }
    }
}

