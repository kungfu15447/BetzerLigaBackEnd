using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;
using BetzerLiga.Infrastructure.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetzerLiga.RestAPI.Initializer
{
    public class DBInitializer
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
                Email = "MadsMadsen@Mads.dk",
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                IsAdmin = false
            };

        }
    }
}
