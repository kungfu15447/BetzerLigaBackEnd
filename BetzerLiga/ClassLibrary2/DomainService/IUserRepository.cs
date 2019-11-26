using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Core.DomainService
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User GetUserById(int id);

        void Add(User user);

        User Update(User UserToUpdate);

        User Delete(int id);
    }
}
