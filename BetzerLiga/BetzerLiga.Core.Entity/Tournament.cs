using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Core.Entity
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfRounds { get; set; }
        public bool isDone { get; set; }
        public List<Round> Rounds { get; set; }
        public List<UserTour> Participants { get; set; }
    }
}
