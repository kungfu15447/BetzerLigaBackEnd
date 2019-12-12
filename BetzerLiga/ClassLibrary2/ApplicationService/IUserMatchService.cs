using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using BetzerLiga.Core.Entity;

namespace BetzerLiga.Core.ApplicationService
{
    public interface IUserMatchService
    {
        void Create(List<UserMatch> userMatches);
        List<UserMatch> GetAllUserMatchesForUserAndRound(int userId, int roundId);
    }
}
