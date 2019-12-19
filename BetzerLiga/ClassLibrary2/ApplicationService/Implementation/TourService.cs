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
            try
            {
                _tourVali.CheckIfTournamentIsNull(Tour);
                _tourVali.ValidateDatesIsNotBeforeTodayOnCreatedTournament(Tour);
                return _tourRepo.CreateTour(_tourVali.ValidateTournament(Tour));
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public Tournament DeleteTournament(Tournament Tour)
        {
            try
            {
                _tourVali.CheckIfTournamentIsNull(Tour);
                return _tourRepo.DeleteTour(Tour);
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public List<Tournament> GetAllTour()
        {        
            return _tourRepo.ReadAll().ToList();
        }

        public Tournament GetTourById(int id)
        {
            try
            {
                Tournament tournament = _tourRepo.ReadTourById(id);
                _tourVali.CheckIfTournamentIsNull(tournament);
                if (!tournament.IsDone || DateTime.Compare(tournament.StartDate, DateTime.Now) <= 0)
                {
                    _pointCalc.CalculateTournamentPoints(tournament);
                    tournament.Participants.OrderByDescending(ut => ut.TotalUserPoints);
                }
                return tournament;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Tournament UpdateTournament(Tournament tour)
        {
            try
            {
                _tourVali.CheckIfTournamentIsNull(tour);
                _tourVali.ValidateTournament(tour);
                _tourVali.CheckIfIdIsValid(tour);
                if (DateTime.Compare(tour.EndDate, DateTime.Now) == -1)
                {
                    tour.IsDone = true;
                }
                Tournament existingTour = _tourRepo.ReadTourById(tour.Id);
                _tourVali.CheckIfTournamentIsNull(existingTour);
                return _tourRepo.UpdateTour(tour);
            }catch(Exception ex)
            {
                throw ex;
            }    
        }
    }
}
