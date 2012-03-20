using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.MediaCenter.UI;
using TennisWMC.wsTennis;

namespace TennisWMC
{
    public class TennisScoresPage : ModelItem
    {
        private TennisScoresCollection _tennis = new TennisScoresCollection();
        private Match[] _singles = new Match[0];
        private Match[] _doubles = new Match[0];

        private string _status;
        private Match _matchDetails = new Match() { Court = string.Empty, DatePlayed = new DateTime(), Duration = string.Empty, SurfaceType = string.Empty, Tournament = string.Empty };
        
        public TennisScoresPage()
        {
            try
            {
                wsTennis.Service ws = new Service();
                this._tennis = ws.GetTennisScoresForWMC(ScoreTypes.ALL_MATCHES);
                this._singles = this._tennis.Singles;
                this._doubles = this._tennis.Doubles;
                this._status = "Success";
            }

            catch
            {
                this._status = "Failure";
            }
        }

        public Match[] Singles
        {
            get { return this._singles; }
        }

        public Match[] Doubles
        {
            get { return this._doubles; }
        }

        public int NumberOfMatches
        {
            get { return this._singles.Length; }
        }

        public string ScoreRetrievalStatus
        {
            get { return this._status; }
            set { this._status = value; }
        }

        public void SetMatchDetails(int indexValue, MatchTypes matchType)
        {
            if (indexValue > -1)
            {
                switch (matchType)
                {
                    case MatchTypes.SINGLES:
                        this._matchDetails = _singles[indexValue];
                        break;
                    case MatchTypes.DOUBLES:
                        this._matchDetails = _doubles[indexValue];
                        break;
                }
            }

            FirePropertyChanged("MatchDetails");
            FirePropertyChanged("Court");
        }

        public Match MatchDetails
        {
            get { //FirePropertyChanged("MatchDetails"); FirePropertyChanged("Court"); 
                return _matchDetails; }
            set { this._matchDetails = value; FirePropertyChanged("MatchDetails"); FirePropertyChanged("Court"); }
        }
    }
}
