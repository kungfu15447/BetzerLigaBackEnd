using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using BetzerLiga.Core.ApplicationService.Implementation.Logic;
using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;
using System.Linq;

namespace BetzerLiga.Core.ApplicationService.Implementation
{
    public class RoundService:IRoundService
    {
        private IRoundRepository _roundRepo;
        private IMatchRepository _matchRepo;
        private RoundValidator _roundVali;

        public RoundService(IRoundRepository roundRepo,
            IMatchRepository matchRepo)
        {
            _roundRepo = roundRepo;
            _matchRepo = matchRepo;
            _roundVali = new RoundValidator();
        }
        public Round Create(Round round)
        {
            var validatedRound = _roundVali.ValidateRound(round);
            return _roundRepo.Create(validatedRound);
        }

        public Round ReadById(int id)
        {
            return _roundVali.SortingByUserPoints(_roundRepo.ReadById(id));
        }

        public List<Round> ReadAll()
        {
            return _roundRepo.ReadAll();
        }

        public Round Update(Round roundUpdated)
        {
            var validatedRound = _roundVali.ValidateRound(roundUpdated);
            return _roundRepo.Update(validatedRound);
        }

        public Round Delete(int id)
        {
            return _roundRepo.Delete(id);
        }

        public Round GetCurrentRoundFromTournament()
        {
            return _roundVali.ValidateCurrentRound(_roundRepo.ReadAll());
        }

        public Round GetMatchesByCurrentRoundAndByUserId(int userId)
        {
            /*List<UserMatch> sortedList = new List<UserMatch>();
            Round currentRound = GetCurrentRoundFromTournament();
            List<Match> matchesInRound = currentRound.Matches;
            foreach (var match in matchesInRound)
            {
                foreach (var tips in match.Tips)
                {
                    if (tips.UserId == userId)
                    {
                        sortedList.Add(tips);
                    }
                }
                
            }
            currentRound.Matches.Clear();
            currentRound.Matches.AddRange(sortedList.Select(um=>um.Match));*/
            var matches = _matchRepo.ReadMatchCurrentRound(userId).ToList();
            var round = new Round
            {
                Matches = matches
            };
            return round;
        }
    }
}
