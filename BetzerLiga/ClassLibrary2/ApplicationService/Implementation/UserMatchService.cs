using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;

namespace BetzerLiga.Core.ApplicationService.Implementation
{
    public class UserMatchService: IUserMatchService
    {
        private IUserMatchRepository _umRepo;

        public UserMatchService(IUserMatchRepository umRepo)
        {
            _umRepo = umRepo;
        }
        public void Create(List<UserMatch> userMatches)
        {
            _umRepo.Create(userMatches);
        }

        public List<UserMatch> GetAllUserMatchesForUserAndRound(int userId, int roundId)
        {
            return _umRepo.GetAllUserMatchesForUserAndRound(userId, roundId).ToList();
        }

        public void UpdateUserMatches(List<UserMatch> tipsUpdated)
        {
            _umRepo.UpdateUserMatches(tipsUpdated);
        }
    }
}
