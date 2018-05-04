using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCounter
{
    class GameManager
    {
        //variables
        int[] scores;

        //constructor
        public GameManager()
        {

        }

        //Methods
        public int FindWinner(int player1Score)
        {
            int highScore = 0;
            scores = new int[1];

            scores[0] = player1Score;

            foreach (int score in scores)
            {
                if(highScore< score)
                {
                    highScore = score;
                }
                else
                {
                    highScore = highScore;
                }
            }
            return highScore;
        }

        public int FindWinner(int player1Score, int player2Score)
        {
            int highScore = 0;
            scores = new int[2];

            scores[0] = player1Score;
            scores[1] = player2Score;

            foreach (int score in scores)
            {
                if (highScore < score)
                {
                    highScore = score;
                }
                else
                {
                    highScore = highScore;
                }
            }
            return highScore;
        }

        public int FindWinner(int player1Score, int player2Score, int player3Score)
        {
            int highScore = 0;
            scores = new int[3];

            scores[0] = player1Score;
            scores[1] = player2Score;
            scores[2] = player3Score;

            foreach (int score in scores)
            {
                if (highScore < score)
                {
                    highScore = score;
                }
                else
                {
                    highScore = highScore;
                }
            }
            return highScore;
        }
        public int FindWinner(int player1Score, int player2Score, int player3Score,int player4Score)
        {
            int highScore = 0;
            scores = new int[4];

            scores[0] = player1Score;
            scores[1] = player2Score;
            scores[2] = player3Score;
            scores[3] = player4Score;

            foreach (int score in scores)
            {
                if (highScore < score)
                {
                    highScore = score;
                }
                else
                {
                    highScore = highScore;
                }
            }
            return highScore;
        }
        public int FindWinner(int player1Score, int player2Score, int player3Score, int player4Score, int player5Score)
        {
            int highScore = 0;
            scores = new int[5];

            scores[0] = player1Score;
            scores[1] = player2Score;
            scores[2] = player3Score;
            scores[3] = player4Score;
            scores[4] = player5Score;

            foreach (int score in scores)
            {
                if (highScore < score)
                {
                    highScore = score;
                }
                else
                {
                    highScore = highScore;
                }
            }
            return highScore;
        }
        public int FindWinner(int player1Score, int player2Score, int player3Score, int player4Score, int player5Score, int player6Score)
        {
            int highScore = 0;
            scores = new int[6];

            scores[0] = player1Score;
            scores[1] = player2Score;
            scores[2] = player3Score;
            scores[3] = player4Score;
            scores[4] = player5Score;
            scores[5] = player6Score;

            foreach (int score in scores)
            {
                if (highScore < score)
                {
                    highScore = score;
                }
                else
                {
                    highScore = highScore;
                }
            }
            return highScore;
        }

        
    }//end class
}//end namespace
