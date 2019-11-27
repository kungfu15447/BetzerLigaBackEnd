using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;

namespace BetzerLiga.Core.ApplicationService.Implementation
{
    public class MatchService : IMatchService
    {
        private IMatchRepository _matchRepo;
        public MatchService(IMatchRepository matchRepo)
        {
            _matchRepo = matchRepo;
        }
        public Match CreateMatch(Match match)
        {
            return _matchRepo.CreateMatch(match);
        }

        public Match DeleteMatch(Match match)
        {
            return _matchRepo.DeleteMatch(match);
        }

        public List<Match> GetAllMatches()
        {
            return _matchRepo.ReadAll().ToList();
        }

        public Match GetMatchById(int id)
        {
            return _matchRepo.ReadMatchById(id);
        }

        public Match UpdateMatch(Match match)
        {
            return _matchRepo.UpdateMatch(match);
        }
    }
}
