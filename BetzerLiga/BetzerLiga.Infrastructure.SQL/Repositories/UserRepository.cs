using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetzerLiga.Infrastructure.SQL.Repositories
{
    public class UserRepository : IUserRepository
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
            _context.Following.RemoveRange(_context.Following.Where(f => f.AuthorizedUserId == id));
            var userRemoved = _context.Remove(new User { Id = id }).Entity;
            _context.SaveChanges();
            return userRemoved;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.Include(u => u.Following)
                .AsNoTracking()
                .OrderBy(u => u.Id)
                .Select(u => new User { 
                    Id = u.Id,
                    IsAdmin = u.IsAdmin,
                    Firstname = u.Firstname,
                    Email = u.Email,
                    Following = u.Following,
                    Lastname = u.Lastname
                });
        }

        public User GetUserById(int id)
        {
            return _context.Users.Include(u => u.Following)
                .AsNoTracking()
                .Select(u => new User
                {
                    Id = u.Id,
                    IsAdmin = u.IsAdmin,
                    Firstname = u.Firstname,
                    Email = u.Email,
                    Following = u.Following,
                    Lastname = u.Lastname
                })
                .FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.Include(u => u.Following)
                .AsNoTracking()
                .FirstOrDefault(u => u.Email == email);
        }

        public User Update(User UserToUpdate)
        {
            var userFollower = new List<Follower>(UserToUpdate.Following ?? new List<Follower>());
            if (UserToUpdate != null)
            {
                _context.Attach(UserToUpdate).State = EntityState.Modified;
            }
            var userMatch = new List<UserMatch>(UserToUpdate.Tips ?? new List<UserMatch>());
            foreach (var um in userMatch)
            {
                _context.Entry(um).State = EntityState.Added;
            }

            var followers = _context.Following.Where(f => f.AuthorizedUser.Id == UserToUpdate.Id);
            foreach (var item in followers)
            {
                _context.Remove(item);
            }
            //Der er to kald til databasen, fordi det første kald fixer en entity framework bug med unique constraint.
            _context.SaveChanges();

            foreach (var uf in userFollower)
            {
                _context.Entry(uf).State = EntityState.Added;
            }
            _context.SaveChanges();
            UserToUpdate.PasswordHash = UserToUpdate.PasswordSalt = null;
            return UserToUpdate;
        }
    }
}
