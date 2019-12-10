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
                .Include(t => t.Participants);
        }

        public Tournament ReadTourById(int Id)
        {
            return _context.Tournaments
                .Include(r => r.Rounds)
                .ThenInclude(r => r.RoundPoints)
                .Include(r => r.Rounds)
                .ThenInclude(r => r.Matches)
                .ThenInclude(m => m.Tips)
                .Include(t => t.Participants)
                .ThenInclude(p => p.User)
                .FirstOrDefault(t => t.Id == Id);
        }

        public Tournament UpdateTour(Tournament Tour)
        {
            _context.Attach(Tour).State = EntityState.Modified;

            var userTours = new List<UserTour>(Tour.Participants ?? new List<UserTour>());
            _context.Participants.RemoveRange(
                _context.Participants.Where(p => p.TournamentId == Tour.Id)
                );
            foreach (var ut in userTours)
            {
                _context.Entry(ut).State = EntityState.Added;
            }
            /*var userFollower = new List<Follower>(UserToUpdate.Following ?? new List<Follower>());
            _context.Following.RemoveRange(
                _context.Following.Where(f => f.AuthorizedUserId == UserToUpdate.Id)
                );
            foreach (var uf in userFollower)
            {
                _context.Entry(uf).State = EntityState.Added;
            }*/
            _context.SaveChanges();
            return Tour;
        }
    }
}
