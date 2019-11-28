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
                Email = "MadsMadsen@Mads.dk",
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                IsAdmin = false
            };

            Tournament tour1 = new Tournament
            {
                Name = "TournaTest",
                NumberOfRounds = 12,
                isDone = false,
                Rounds = new List<Round>(),
                Participants = new List<UserTour>()
            };

            UserTour usertour1 = new UserTour
            {
                User = user1,
                TotalUserPoints = 270
            };

            ctx.Users.Add(user1);

            tour1.Participants.Add(usertour1);

            ctx.Tournaments.Add(tour1);

            ctx.SaveChanges();
            

        }
    }
}
