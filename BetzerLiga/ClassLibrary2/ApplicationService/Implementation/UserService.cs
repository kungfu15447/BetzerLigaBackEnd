using System;
using System.Collections.Generic;
using System.Text;
using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;

namespace BetzerLiga.Core.ApplicationService.Implementation
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRep;
        public UserService(IUserRepository userRep)
        {
            _userRep = userRep;
        }

        public User Add(User user)
        {
            return _userRep.Add(user);
        }

        public User Delete(int id)
        {
            return _userRep.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRep.GetAll();
        }

        public User GetUserById(int id)
        {
            return _userRep.GetUserById(id);
        }

        public User Update(User UserToUpdate)
        {
            return _userRep.Update(UserToUpdate);
        }
    }
}
