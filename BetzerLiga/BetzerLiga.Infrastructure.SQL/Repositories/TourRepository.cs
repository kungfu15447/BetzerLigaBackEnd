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
            return _context.Tournaments;
        }

        public Tournament ReadTourById(int id)
        {
            return _context.Tournaments
                .FirstOrDefault(t => t.Id == id);
        }

        public Tournament UpdateTour(Tournament Tour)
        {
            _context.Attach(Tour).State = EntityState.Modified;
            return Tour;
        }
    }
}
