using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Infrastructure.SQL.Repositories
{
    class MatchRepository : IMatchRepository
    {
        private BetzerLigaContext _context;

        public MatchRepository(BetzerLigaContext context)
        {
            _context = context;
        }
        public Match CreateMatch(Match Match)
        {
            _context.Attach(Match).State = EntityState.Added;
            return Match;
        }

        public Match DeleteMatch(Match Match)
        {
            _context.Remove(Match);
            _context.SaveChanges();
            return Match;
        }

        public IEnumerable<Match> ReadAll()
        {
            return _context.Matches;
        }

        public Match ReadMatchById(int Id)
        {
            throw new NotImplementedException();
        }

        public Match UpdateMatch(Match Match)
        {
            throw new NotImplementedException();
        }
    }
}
