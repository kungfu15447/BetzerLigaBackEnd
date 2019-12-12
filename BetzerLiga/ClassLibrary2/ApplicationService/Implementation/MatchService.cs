using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetzerLiga.Core.ApplicationService.Implementation.Logic;
using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;

namespace BetzerLiga.Core.ApplicationService.Implementation
{
    public class MatchService : IMatchService
    {
        private IMatchRepository _matchRepo;
        private RoundService _roundService;
        private MatchValidator _matchVali;

        public MatchService(IMatchRepository matchRepo, RoundService roundService)
        {
            _matchRepo = matchRepo;
            _roundService = roundService;
            _matchVali = new MatchValidator();
        }
        public List<Match> CreateMatches(List<Match> matches)
        {
            try
            {
                foreach (Match match in matches)
                {
                    _matchVali.CheckIfMatchIsNull(match);
                    _matchVali.ValidateMatch(match);
                    _matchVali.ValidateMatchStartDate(match);
                }
                return _matchRepo.CreateMatch(matches).ToList();
            }catch(Exception ex)
            {
                throw ex;
            }    
        }

        public Match DeleteMatch(Match match)
        {
            try
            {
                _matchVali.CheckIfMatchIsNull(match);
                return _matchRepo.DeleteMatch(match);
            }catch(Exception ex)
            {
                throw ex
            }
            
        }

        public List<Match> GetAllMatches()
        {
            return _matchRepo.ReadAll().ToList();
        }

        public Match GetMatchById(int id)
        {
            return _matchRepo.ReadMatchById(id);
        }

        public List<Match> GetMatchesByCurrentRoundAndByUserId(User user)
        {
            var currentRound = _roundService.GetCurrentRoundFromTournament();
            var matches = currentRound.Matches.FindAll(m => m.Tips.Equals(user.Tips));
            return matches;
        }


        public Match UpdateMatch(Match match)
        {
            try
            {
                _matchVali.CheckIfMatchIsNull(match);
                return _matchRepo.UpdateMatch(match);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
