using System;
using System.Collections.Generic;
using System.Text;
using BetzerLiga.Core.ApplicationService.Implementation.Logic;
using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;

namespace BetzerLiga.Core.ApplicationService.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRep;
        private UserValidator _userVali;
        public UserService(IUserRepository userRep)
        {
            _userRep = userRep;
            _userVali = new UserValidator();
        }

        public User Add(User user)
        {
            try
            {
                _userVali.CheckIfUserIsNull(user);
                User validatedUser = _userVali.ValidateUser(user);
                return _userRep.Add(validatedUser);
            }catch(Exception ex)
            {
                throw ex;
            }
            
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
            try
            {
                User user = _userRep.GetUserById(id);
                _userVali.CheckIfUserIsNull(user);
                return user;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public User Update(User UserToUpdate)
        {
            try
            {
                _userVali.CheckIfUserIsNull(UserToUpdate);
                User checkedUser = _userVali.ValidateUser(UserToUpdate);
                return _userRep.Update(checkedUser);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
