using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace BetzerLiga.Infrastructure.SQL.Repositories
{
    public class RoundRepository: IRoundRepository
    {
        private BetzerLigaContext _ctx;

        public RoundRepository(BetzerLigaContext ctx)
        {
            _ctx = ctx;
        }
        public Round Create(Round round)
        {
            _ctx.Attach(round).State = EntityState.Added;
            _ctx.SaveChanges();
            return round;
        }

        public Round ReadById(int id)
        {
            return _ctx.Rounds
                .Include(r => r.RoundPoints)
                .ThenInclude(ur => ur.User)
                .Include(r=>r.Matches)
                .ThenInclude(m=>m.Tips)
                .ThenInclude(um=>um.Match)
                .Include(r => r.Tournament)
                .ThenInclude(t => t.Participants)
                .FirstOrDefault(r => r.Id == id);
        }

        public List<Round> ReadAll()
        {
            return _ctx.Rounds
                .Include(r => r.Matches)
                .ThenInclude(m => m.Tips)
                .ThenInclude(um => um.Match)
                .Include(r=>r.Tournament)
                .ThenInclude(t=>t.Participants)
                .Include(r => r.RoundPoints)
                .ThenInclude(ur => ur.User)
                .ToList();
        }

        public Round Update(Round roundUpdated)
        {
            var newMatches = new List<Match>();
            if (roundUpdated.Matches != null)
            {
                newMatches = roundUpdated.Matches;
            }
            _ctx.Attach(roundUpdated).State = EntityState.Modified;
            _ctx.Matches.RemoveRange(
                _ctx.Matches.Where(m=>m.Round.Id == roundUpdated.Id)
                );
            foreach (var match in newMatches)
            {
                _ctx.Entry(match).State = EntityState.Added;
            }

            if (roundUpdated.Matches != null)
            {
                _ctx.Entry(roundUpdated).Reference(r => r.Matches).IsModified = true;
            }
                
            _ctx.Entry(roundUpdated).Reference(r => r.Matches).IsModified = true;


            _ctx.SaveChanges();
            return roundUpdated;
        }

        public Round Delete(int id)
        {
            var roundDeleted = _ctx.Remove(new Round {Id = id}).Entity;
            _ctx.SaveChanges();
            return roundDeleted;
        }
    }
}
