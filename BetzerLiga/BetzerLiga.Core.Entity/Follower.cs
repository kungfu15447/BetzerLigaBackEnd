using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Core.Entity
{
    public class Follower
    {
        public int AuthorizedUserId { get; set; }
        public virtual User AuthorizedUser { get; set; }

        public int FollowId { get; set; }
        public virtual User Follow { get; set; }
    }
}
