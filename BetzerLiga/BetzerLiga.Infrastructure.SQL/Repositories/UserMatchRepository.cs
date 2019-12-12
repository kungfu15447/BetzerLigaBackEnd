using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace BetzerLiga.Infrastructure.SQL.Repositories
{
    public class UserMatchRepository: IUserMatchRepository
    {
        private BetzerLigaContext _ctx;

        public UserMatchRepository(BetzerLigaContext ctx)
        {
            _ctx = ctx;
        }
        public void Create(List<UserMatch> userMatches)
        {
            foreach (var userMatch in userMatches)
            {
                _ctx.UserMatches.Attach(userMatch).State = EntityState.Added;
            }
            _ctx.SaveChanges();
        }

        public IEnumerable<UserMatch> GetAllUserMatchesForUserAndRound(int userId, int roundId)
        {
            Round round = _ctx.Rounds.FirstOrDefault(r => r.Id == roundId);
            List<UserMatch> tips = new List<UserMatch>();
            tips = _ctx.UserMatches
                .Where(um => um.UserId == userId)
                .Include(um => um.Match)
                .Select(um => new UserMatch
                {
                    Id = um.Id,
                    Rating = um.Rating,
                    MatchId = um.MatchId,
                    UserId = um.UserId,
                    HomeTip = um.HomeTip,
                    GuestTip = um.GuestTip,
                    Match = um.Match,
                    User = um.User
                }).ToList();
            return tips;
                //.Where(m => m.Tips.Exists(um => um.UserId == userId && um.Match.Round.Id == lastRound))
                //.Include(m => m.Tips)
                //.Select(m => new Match
                //{
                //    Id = m.Id,
                //    Round = m.Round,
                //    GuestScore = m.GuestScore,
                //    GuestTeam = m.GuestTeam,
                //    HomeScore = m.HomeScore,
                //    HomeTeam = m.HomeTeam,
                //    RoundId = m.RoundId,
                //    StartDate = m.StartDate,
                //    Tips = m.Tips.Where(t => t.UserId == userId).ToList()
                //});
        }

        public void UpdateUserMatches(List<UserMatch> tipToUpdate)
        {
            foreach (var um in tipToUpdate)
            {
                _ctx.Entry(um).State = EntityState.Modified;
            }
            _ctx.SaveChanges();
        }
    }
}
