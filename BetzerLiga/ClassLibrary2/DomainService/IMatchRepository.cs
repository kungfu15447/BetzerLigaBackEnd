using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Core.DomainService
{
    public interface IMatchRepository
    {
        Match ReadMatchById (int Id);
        IEnumerable<Match> ReadAll();
        IEnumerable<Match> ReadMatchCurrentRound(int userId);
        Match UpdateMatch(Match Match);
        Match CreateMatch(Match Match);
        Match DeleteMatch(Match Match);
    }
}
