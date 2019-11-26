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
    }
}
