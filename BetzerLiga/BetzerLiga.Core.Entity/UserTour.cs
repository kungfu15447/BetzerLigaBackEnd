using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Core.Entity
{
    public class UserTour
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Tournament Tournament { get; set; }
        public int TournamentId { get; set; }
        public int TotalUserPoints { get; set; }
    }
}
