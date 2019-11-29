using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetzerLiga.Infrastructure.SQL.Repositories
{
    public class TourRepository : ITourRepository
    {
        private BetzerLigaContext _context;

        public TourRepository(BetzerLigaContext context)
        {
            _context = context;
        }
        public Tournament CreateTour(Tournament Tour)
        {
            _context.Attach(Tour).State = EntityState.Added;
            _context.SaveChanges();
            return Tour;
        }

        public Tournament DeleteTour(Tournament Tour)
        {
            _context.Remove(Tour);
            _context.SaveChanges();
            return Tour;
        }

        public IEnumerable<Tournament> ReadAll()
        {
            return _context.Tournaments
                .Include(r => r.Rounds)
                .Include(t => t.Participants)
                .ThenInclude(p => p.User)
                .ThenInclude(u => u.Tips);
        }

        public Tournament ReadTourById(int Id)
        {
            return _context.Tournaments
                .Include(r => r.Rounds)
                .Include(t => t.Participants)
                .ThenInclude(p => p.User)
                .ThenInclude(u => u.Tips)
                .FirstOrDefault(t => t.Id == Id);
        }

        public Tournament UpdateTour(Tournament Tour)
        {
            _context.Attach(Tour).State = EntityState.Modified;
            _context.SaveChanges();
            return Tour;
        }
    }
}
