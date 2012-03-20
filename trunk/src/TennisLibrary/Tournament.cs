using System;
using System.Web;
using System.ComponentModel;

namespace TennisLibrary
{
    public class Tournament
    {
        private string _name;
        private System.Collections.Generic.List<Match> _matches = new System.Collections.Generic.List<Match>();

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public System.Collections.Generic.List<Match> Matches
        {
            get
            {
                return _matches;
}
            set { _matches = value; }
        }
    }
}
