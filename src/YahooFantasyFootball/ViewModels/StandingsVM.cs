using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YahooFantasyFootball.ViewModels
{
    public class StandingsVM
    {
        public string leagueName { get; set; }
        public ICollection<TeamStanding> TeamStandings { get; set; }
    }

    public class TeamStanding
    {
        public string TeamManager { get; set; }
        public int Placement { get; set; }
        public int NumberOfMoves { get; set; }
        public string logoUrl { get; set; }

    }
}
