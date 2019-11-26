using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Core.Entity
{
    public class Match
    {
        public int Id { get; set; }
        public string HomeTeam { get; set; }
        public int HomeScore { get; set; }
        public string GuestTeam { get; set; }
        public int GuestScore { get; set; }
        public DateTime StartDate { get; set; }
        public Round Round { get; set; }
        public List<UserMatch> Tips { get; set; }

    }
}
