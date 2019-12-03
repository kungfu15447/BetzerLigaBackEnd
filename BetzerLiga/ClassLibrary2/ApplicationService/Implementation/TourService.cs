using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetzerLiga.Core.ApplicationService.Implementation.Logic;
using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;

namespace BetzerLiga.Core.ApplicationService.Implementation
{
    public class TourService : ITourService
    {
        private ITourRepository _tourRepo;
        private PointCalculator _pointCalc;
        public TourService(ITourRepository tourRepo)
        {
            _tourRepo = tourRepo;
            _pointCalc = new PointCalculator();
        }
        public Tournament CreateTournament(Tournament Tour)
        {
            return _tourRepo.CreateTour(Tour);
        }

        public Tournament DeleteTournament(Tournament Tour)
        {
            return _tourRepo.DeleteTour(Tour);
        }

        public List<Tournament> GetAllTour()
        {
            List<Tournament> tournaments = _tourRepo.ReadAll().ToList();
            foreach (Tournament tournament in tournaments)
            {
                if (!tournament.isDone)
                {
                    _pointCalc.CalculateTournamentPoints(tournament);
                }
            }
            return tournaments;
        }

        public Tournament GetTourById(int id)
        {
            Tournament tournament = _tourRepo.ReadTourById(id);
            if (!tournament.isDone)
            {
                _pointCalc.CalculateTournamentPoints(tournament);
                tournament.Participants.OrderByDescending(ut => ut.TotalUserPoints);
            }
            return tournament;
        }

        public Tournament UpdateTournament(Tournament Tour)
        {
            return _tourRepo.UpdateTour(Tour);
        }
    }
}
