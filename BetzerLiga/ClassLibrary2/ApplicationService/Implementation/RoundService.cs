using System;
using System.Collections.Generic;
using System.Text;
using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;

namespace BetzerLiga.Core.ApplicationService.Implementation
{
    public class RoundService:IRoundService
    {
        private IRoundRepository _roundRepo;

        public RoundService(IRoundRepository roundRepo)
        {
            _roundRepo = roundRepo;
        }
        public Round Create(Round round)
        {
            return _roundRepo.Create(round);
        }

        public Round ReadById(int id)
        {
            return _roundRepo.ReadById(id);
        }

        public List<Round> ReadAll()
        {
            return _roundRepo.ReadAll();
        }

        public Round Update(Round roundUpdated)
        {
            return _roundRepo.Update(roundUpdated);
        }

        public Round Delete(int id)
        {
            return _roundRepo.Delete(id);
        }
    }
}
