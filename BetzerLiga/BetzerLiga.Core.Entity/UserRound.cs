using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Core.Entity
{
    public class UserRound
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Round Round { get; set; }
        public int RoundId { get; set; }
        public int UserPoints { get; set; }
    }
}
