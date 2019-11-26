using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Core.ApplicationService
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();

        User GetUserById(int id);

        void Add(User user);

        User Update(User UserToUpdate);

        User Delete(int id);

        User NewUser(string firstName, string lastName, bool isAdmin, string email,
            byte[] passwordHash, byte[] passwordSalt, List<UserTour> tournaments, List<UserMatch> tips, List<User> following);
    }
}
