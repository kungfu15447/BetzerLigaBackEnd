﻿using BetzerLiga.Core.DomainService;
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
                .Select(to => new Tournament
                {
                    Id = to.Id,
                    Name = to.Name,
                    NumberOfRounds = to.NumberOfRounds,
                    IsDone = to.IsDone,
                    EndDate = to.EndDate,
                    StartDate = to.StartDate,
                    Participants = to.Participants
                        .Select(p => new UserTour() { 
                            Id = p.Id,
                            UserId = p.UserId,
                            User = p.User,
                            TournamentId = p.TournamentId,
                            TotalUserPoints = p.TotalUserPoints
                        }).ToList(),
                    Rounds = to.Rounds
                        .Select(r => new Round
                        {
                            Id = r.Id,
                            RoundNumber = r.RoundNumber,
                            TournamentId = r.TournamentId,
                            TotalGoals = r.TotalGoals,
                            TippingDeadLine = r.TippingDeadLine,
                            Matches = r.Matches
                            .Select(m => new Match
                            {
                                Id = m.Id,
                                HomeTeam = m.HomeTeam,
                                HomeScore = m.HomeScore,
                                GuestTeam = m.GuestTeam,
                                GuestScore = m.GuestScore,
                                StartDate = m.StartDate,
                                RoundId = m.RoundId,
                                Tips = m.Tips
                                .Select(um => new UserMatch 
                                {
                                    Id = um.Id,
                                    UserId = um.UserId,
                                    MatchId = um.MatchId,
                                    GuestTip = um.GuestTip,
                                    HomeTip = um.HomeTip,
                                    Rating = um.Rating,
                                    TotalPoints = um.TotalPoints
                                }).ToList()
                            }).ToList(),
                            RoundPoints = r.RoundPoints
                            .Select(ur => new UserRound 
                            {
                                Id = ur.Id,
                                UserId = ur.UserId,
                                RoundId = ur.RoundId,
                                UserPoints = ur.UserPoints
                            }).ToList()
                        }).ToList()
                })
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

            foreach (Round round in Tour.Rounds)
            {
                _context.RoundPoints.RemoveRange(
                    _context.RoundPoints.Where(rp => rp.RoundId == round.Id));
                foreach (UserTour participant in userTours)
                {
                    UserRound ur = new UserRound
                    {
                        UserId = participant.UserId,
                        RoundId = round.Id,
                        UserPoints = 0
                    };
                    _context.Entry(ur).State = EntityState.Added;
                }
            }

            _context.SaveChanges();
            return Tour;
        }
    }
}
