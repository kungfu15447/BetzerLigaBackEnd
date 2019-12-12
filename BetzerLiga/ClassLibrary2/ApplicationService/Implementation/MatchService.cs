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
        private IRoundService _roundService;

        public MatchService(IMatchRepository matchRepo, IRoundService roundService)
        {
            _matchRepo = matchRepo;
            _roundService = roundService;
        }
        public IEnumerable<Match> CreateMatch(List<Match> matches)
        {
            return _matchRepo.CreateMatch(matches);
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

        public List<Match> ReadMatchesFromRound(int userId, int roundId)
        {
            return _matchRepo.ReadMatchesFromRound(userId, roundId).ToList();
        }

        public List<Match> GetMatchesByCurrentRoundAndByUserId(User user)
        {
            var currentRound = _roundService.GetCurrentRoundFromTournament();
            var matches = currentRound.Matches.FindAll(m => m.Tips.Equals(user.Tips));
            return matches;
        }


        public Match UpdateMatch(Match match)
        {
            return _matchRepo.UpdateMatch(match);
        }

        
    }
}
