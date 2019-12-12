using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Core.ApplicationService
{
    public interface IMatchService
    {
        IEnumerable<Match> CreateMatch(List<Match> matches);
        Match DeleteMatch(Match match);
        Match UpdateMatch(Match match);
        List<Match> GetAllMatches();
        Match GetMatchById(int id);
        List<Match> ReadMatchesFromRound(int userId, int roundId);

    }
}
