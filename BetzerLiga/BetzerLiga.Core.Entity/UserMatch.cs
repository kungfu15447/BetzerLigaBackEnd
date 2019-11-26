using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Core.Entity
{
    public class UserMatch
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Match Match { get; set; }
        public int MatchId { get; set; }
        public int HomeTip { get; set; }
        public int GuestTip { get; set; }
    }
}
