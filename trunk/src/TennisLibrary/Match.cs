using System;
using System.Web;
using System.ComponentModel;

namespace TennisLibrary
{
    public class Match
    {
        public int MatchIndex { get; set; }

        public string Court
        {
            get;
            set;
        }

        public bool InProgress
        {
            get;
            set;
        }

        public MatchProgress Status
        {
            get;
            set;
        }

        public Player Player1
        {
            get;
            set;
        }

        public Player Player2
        {
            get;
            set;
        }

        public string Duration  // change to duration
        { get; set; }

        public DateTime DatePlayed
        { get; set; }

        public string Tournament
        { get; set; }

        public string SurfaceType
        { get; set; }

        public MatchTypes MatchType
        {
            get;
            set;
        }
    }
}
