using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Core.ApplicationService
{
    public interface IMatchService
    {
        Match CreateMatch(Match match);
        Match DeleteMatch(Match match);
        Match UpdateMatch(Match match);
        List<Match> GetAllMatches();
        Match GetMatchById(int id);
        List<Match> GetMatchesByCurrentRoundAndByUserId(User user);
    }
}
