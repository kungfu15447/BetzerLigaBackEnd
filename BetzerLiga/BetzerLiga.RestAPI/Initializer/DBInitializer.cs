using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;
using BetzerLiga.Infrastructure.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetzerLiga.RestAPI.Initializer
{
    public class DBInitializer : IDBInitializer
    {
        private IAuthenticationHelper authenticationHelper;
        public DBInitializer(IAuthenticationHelper authHelper)
        {
            authenticationHelper = authHelper;
        }

        public void Seed(BetzerLigaContext ctx)
        {
            string password = "1234";
            Byte[] passwordHashUser, passwordSaltUser;

            authenticationHelper.CreatePasswordHash(password, out passwordHashUser, out passwordSaltUser);

            User user1 = new User
            {
                Firstname = "Mads",
                Lastname = "Madsen",
                Email = "MadsMadsen@google.dk",
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                IsAdmin = true,
                
            };

            User user2 = new User
            {
                Firstname = "Lars",
                Lastname = "Lars",
                Email = "LarsLarsen@google.dk",
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                IsAdmin = true
            };

            User user3 = new User
            {
                Firstname = "Frederik",
                Lastname = "Frederiksen",
                Email = "FrederikFrederiksen@google.dk",
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                IsAdmin = true
            };

            User user4 = new User
            {
                Firstname = "Ole",
                Lastname = "Olsen",
                Email = "Olsen@Mads.dk",
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                IsAdmin = true
            };

            User user5 = new User
            {
                Firstname = "John",
                Lastname = "Johnsen",
                Email = "JohnJohnsen@google.dk",
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                IsAdmin = true
            };

            User user6 = new User
            {
                Firstname = "Erik",
                Lastname = "Eriksen",
                Email = "ErikEriksen@google.dk",
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                IsAdmin = true
            };



            user1 = ctx.Users.Add(user1).Entity;
            user2 = ctx.Users.Add(user2).Entity;
            user3 = ctx.Users.Add(user3).Entity;
            user4 = ctx.Users.Add(user4).Entity;
            user5 = ctx.Users.Add(user5).Entity;
            user6 = ctx.Users.Add(user6).Entity;

            ctx.SaveChanges();

        }
    }
}
