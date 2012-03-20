using System;
using System.Web;
using System.ComponentModel;

namespace TennisLibrary
{
    public class GamePoint
    {
        public GamePoint()
        {
        }

        public GamePoint(int score)
        {
            this.Score = score;
            this.IsWinner = false;
        } 

        public GamePoint(int score, int set)
        {
            this.Score = score;
            this.Set = set;
            this.IsWinner = false;
        }
        
        public GamePoint(int score, int set, bool iswinner)
        {
            this.Score = score;
            this.Set = set;
            this.IsWinner = iswinner;
        }

        public int Score { get; set; }
        public int Set { get; set; }
        public bool IsWinner { get; set; }
    }
}
