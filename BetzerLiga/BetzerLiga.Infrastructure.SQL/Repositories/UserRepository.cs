using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public User Add(User user)
        {
            if(user != null)
            {
                _context.Attach(user).State = EntityState.Added;
            }
            var userSaved = _context.Users.Add(user).Entity;
            _context.SaveChanges();
            return userSaved;
        }

        public User Delete(int id)
        {
            var userRemoved = _context.Remove(new User { Id = id }).Entity;
            _context.SaveChanges();
            return userRemoved;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users
                .OrderBy(u => u.Id)
                .Include(u => u.Firstname);
        }

        public User GetUserById(int id)
        {
            return _context.Users
                .FirstOrDefault(u => u.Id == id);
        }

        public User Update(User UserToUpdate)
        {
            if(UserToUpdate != null)
            {
                _context.Attach(UserToUpdate).State = EntityState.Modified;
            }
            var userMatch = new List<UserMatch>(UserToUpdate.Tips ?? new List<UserMatch>());
            foreach (var um in userMatch)
            {
                _context.Entry(um).State = EntityState.Added;
            }
            _context.SaveChanges();
            return UserToUpdate;
        }
    }
}
