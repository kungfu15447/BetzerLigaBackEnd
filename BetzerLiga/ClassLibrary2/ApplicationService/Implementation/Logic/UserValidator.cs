using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BetzerLiga.Core.ApplicationService.Implementation.Logic
{
    public class UserValidator
    {
        public User ValidateUser(User user)
        {
            if (String.IsNullOrEmpty(user.Firstname) || String.IsNullOrEmpty(user.Lastname))
            {
                throw new InvalidDataException("A users firstname and/or lastname cannot be empty");
            }
            if (String.IsNullOrEmpty(user.Email))
            {
                throw new InvalidDataException("An users Email cannot be empty");
            }
            if (CheckIfNameContainsNumbers(user))
            {
                throw new InvalidDataException("A users firstname and/or lastname cannot contain numbers");
            }
            return user;
        }
        public void CheckIfIdIsValid(User user)
        {
            if (user.Id <= 0)
            {
                throw new InvalidDataException("Id not valid!");
            }
        }

        public void CheckIfUserIsNull(User user)
        {
            if(user == null)
            {
                throw new InvalidDataException("Could not find user/user does not exist");
            }
        }

        private bool CheckIfNameContainsNumbers(User user)
        {
            string fullname = user.Firstname + " " + user.Lastname;
            bool isNumber = false;
            foreach (Char cha in fullname.ToCharArray(0, fullname.Length))
            {
                if (char.IsDigit(cha))
                {
                    isNumber = true;
                }
            }
            return isNumber;
        }
    }
}
