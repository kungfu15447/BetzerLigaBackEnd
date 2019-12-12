using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using BetzerLiga.Core.Entity;

namespace BetzerLiga.Core.DomainService
{
    public interface IUserMatchRepository
    {
        void Create(List<UserMatch> userMatches);
        IEnumerable<UserMatch> GetAllUserMatchesForUserAndRound(int userId, int roundId);
    }
}
