using System;
using System.Web;
using System.ComponentModel;

namespace TennisLibrary
{
    public class Player
    {
        private System.Collections.Generic.List<GamePoint> _gamesWon = new System.Collections.Generic.List<GamePoint>();
        private string _name;
        private bool _winner;

        public System.Collections.Generic.List<GamePoint> GamesWon
        {
            get
            {
                return _gamesWon;
}
            set { _gamesWon = value; }
        }

        public String Name
        {
            get
            {
                return _name;
}
            set { _name = value; }
        }

        public bool IsWinner
        {
            get
            {
                return _winner;
}
            set { _winner = value; }
        }
    }
}
