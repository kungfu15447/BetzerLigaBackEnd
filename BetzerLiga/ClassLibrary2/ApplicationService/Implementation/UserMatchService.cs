using System;
using System.Collections.Generic;
using System.Text;
using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;

namespace BetzerLiga.Core.ApplicationService.Implementation
{
    public class UserMatchService: IUserMatchService
    {
        private IUserMatchRepository _umRepo;

        public UserMatchService(IUserMatchRepository umRepo)
        {
            _umRepo = umRepo;
        }
        public void Create(UserMatch userMatch)
        {
            throw new NotImplementedException();
        }
    }
}
