using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Core.Entity
{
    public class Round
    {
        public int Id { get; set; }
        public int RoundNumber { get; set; }
        public Tournament Tournament { get; set; }
        public int TotalGoals { get; set; }
        public List<Match> Matches { get; set; }
    }
}
