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
        public bool IsDone { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Round> Rounds { get; set; }
        public List<UserTour> Participants { get; set; }
    }
}
