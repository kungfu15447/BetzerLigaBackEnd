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
        Match UpdateMatch(Match Match);
        List<Match> CreateMatch(List<Match> Matches);
        Match DeleteMatch(Match Match);
    }
}
