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
                Following = new List<Follower>()
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
                TotalUserPoints = 100
            };
            UserTour usertour2 = new UserTour
            {
                User = user2,
                TotalUserPoints = 200
            };
            UserTour usertour3 = new UserTour
            {
                User = user3,
                TotalUserPoints = 201
            };
            UserTour usertour4 = new UserTour
            {
                User = user4,
                TotalUserPoints = 50
            };
            UserTour usertour5 = new UserTour
            {
                User = user5,
                TotalUserPoints = 250
            };
            UserTour usertour6 = new UserTour
            {
                User = user6,
                TotalUserPoints = 150
            };


            tour1.Participants.Add(usertour1);
            tour1.Participants.Add(usertour2);
            tour1.Participants.Add(usertour3);
            tour1.Participants.Add(usertour4);
            tour1.Participants.Add(usertour5);
            tour1.Participants.Add(usertour6);


            ctx.Tournaments.Add(tour1);


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
