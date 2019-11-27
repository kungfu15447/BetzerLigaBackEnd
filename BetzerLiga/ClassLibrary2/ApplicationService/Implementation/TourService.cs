using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;

namespace BetzerLiga.Core.ApplicationService.Implementation
{
    public class TourService : ITourService
    {
        private ITourRepository _tourRepo;
        public TourService(ITourRepository tourRepo)
        {
            _tourRepo = tourRepo;
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

        public Tournament GetTourById(int id)
        {
            return _tourRepo.ReadTourById(id);
        }

        public Tournament UpdateTournament(Tournament Tour)
        {
            return _tourRepo.UpdateTour(Tour);
        }
    }
}
