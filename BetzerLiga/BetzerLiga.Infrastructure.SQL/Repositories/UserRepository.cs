using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Infrastructure.SQL.Repositories
{
    class UserRepository : IUserRepository
    {
        private BetzerLigaContext _context;

        public UserRepository(BetzerLigaContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            if(user != null)
            {
                _context.Attach(user).State = EntityState.Added;
            }
        }

        public User Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public User Update(User UserToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
