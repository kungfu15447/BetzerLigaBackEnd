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
        private TournamentValidator _tourVali;
        public TourService(ITourRepository tourRepo)
        {
            _tourRepo = tourRepo;
            _pointCalc = new PointCalculator();
            _tourVali = new TournamentValidator();
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
            return _tourRepo.ReadAll().ToList();
        }

        public Tournament GetCurrentOnGoingTournament()
        {
            Tournament onGoingTournament = _tourVali.GetOnGoingTournament(_tourRepo.ReadAll().ToList());
            if (onGoingTournament != null)
            {
                _pointCalc.CalculateTournamentPoints(onGoingTournament);
            }
            return onGoingTournament;
        }

        public Tournament GetTourById(int id)
        {
            Tournament tournament = _tourRepo.ReadTourById(id);
            if (!tournament.IsDone)
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
