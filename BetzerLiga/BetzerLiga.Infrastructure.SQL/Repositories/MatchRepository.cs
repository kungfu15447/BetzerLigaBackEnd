using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetzerLiga.Infrastructure.SQL.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private BetzerLigaContext _context;

        public MatchRepository(BetzerLigaContext context)
        {
            _context = context;
        }
        public IEnumerable<Match> CreateMatch(List<Match> matches)
        {
            foreach (var item in matches)
            {
                _context.Matches.Add(item);
            }
            _context.SaveChanges();
            return matches;
        }

        public Match DeleteMatch(Match Match)
        {
            _context.Remove(Match);
            _context.SaveChanges();
            return Match;
        }

        public IEnumerable<Match> ReadAll()
        {
            return _context.Matches
                .Include(m => m.Round)
                .Include(m => m.Tips)
                .ThenInclude(t => t.User);
        }

        public IEnumerable<Match> ReadMatchCurrentRound(int userId)
        {
            var lastRound = _context.Rounds.Max(x => x.Id);
            var tipsFound = _context.Matches
                .Where(m => m.Tips.Exists(um => um.UserId == userId && um.Match.Round.Id == lastRound))
                .Include(m => m.Tips)
                .Select(m => new Match
                {
                    Id = m.Id,
                    Round = m.Round,
                    GuestScore = m.GuestScore,
                    GuestTeam = m.GuestTeam,
                    HomeScore = m.HomeScore,
                    HomeTeam = m.HomeTeam,
                    RoundId = m.RoundId,
                    StartDate = m.StartDate,
                    Tips = m.Tips.Where(t => t.UserId == userId).ToList()
                });
            return tipsFound;
        }

        public Match ReadMatchById(int Id)
        {
            return _context.Matches
                .Include(m => m.Round)
                .Include(m => m.Tips)
                .ThenInclude(t => t.User)
                .FirstOrDefault(m => m.Id == Id);
        }

        public Match UpdateMatch(Match Match)
        {
            _context.Attach(Match).State = EntityState.Modified;
            _context.SaveChanges();
            return Match;
        }
    }
}
