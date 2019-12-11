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
        public List<Match> CreateMatch(List<Match> Matches)
        {
            _context.Attach(Matches).State = EntityState.Added;
            _context.SaveChanges();
            return Matches;
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
