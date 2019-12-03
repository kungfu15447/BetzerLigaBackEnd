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

            Round round1 = new Round
            {
                RoundNumber = 1,
                TotalGoals = 14,
                RoundPoints = new List<UserRound>(),
                Matches = new List<Match>(),
                TournamentId = 1,
            };
            Round round2 = new Round
            {
                RoundNumber = 2,
                TotalGoals = 23,
                RoundPoints = new List<UserRound>(),
                Matches = new List<Match>(),
                TournamentId = 1
            };
            Round round3 = new Round
            {
                RoundNumber = 3,
                TotalGoals = 17,
                RoundPoints = new List<UserRound>(),
                Matches = new List<Match>(),
                TournamentId = 1
            };
            Round round4 = new Round
            {
                RoundNumber = 4,
                TotalGoals = 10,
                RoundPoints = new List<UserRound>(),
                Matches = new List<Match>(),
                TournamentId = 1
            };

            UserRound userRound1 = new UserRound
            {
                User = user1,
                UserPoints = 24,
            };
            UserRound userRound2 = new UserRound
            {
                User = user2,
                UserPoints = 13,
            };
            UserRound userRound3 = new UserRound
            {
                User = user3,
                UserPoints = 56,
            }; 
            UserRound userRound4 = new UserRound
            {
                User = user4,
                UserPoints = 76,
            };
            UserRound userRound5 = new UserRound()
            {

                User = user1,
                UserPoints =  24
            };

            //round1.RoundPoints.Add(userRound1);
            //round1.RoundPoints.Add(userRound2);
            //round1.RoundPoints.Add(userRound3);
            //round1.RoundPoints.Add(userRound4);
            //round2.RoundPoints.Add(userRound1);
            //round2.RoundPoints.Add(userRound2);
            //round2.RoundPoints.Add(userRound3);
            //round2.RoundPoints.Add(userRound4);
            //round3.RoundPoints.Add(userRound1);
            //round3.RoundPoints.Add(userRound2);
            //round3.RoundPoints.Add(userRound3);
            //round3.RoundPoints.Add(userRound4);
            round4.RoundPoints.Add(userRound1);
            round4.RoundPoints.Add(userRound2);
            round4.RoundPoints.Add(userRound3);
            round4.RoundPoints.Add(userRound4);


            tour1.Participants.Add(usertour1);
            tour1.Participants.Add(usertour2);
            tour1.Participants.Add(usertour3);
            tour1.Participants.Add(usertour4);
            tour1.Participants.Add(usertour5);
            tour1.Participants.Add(usertour6);

            tour1.Rounds.Add(round1);
            tour1.Rounds.Add(round2);
            tour1.Rounds.Add(round3);
            tour1.Rounds.Add(round4);

            user1 = ctx.Users.Add(user1).Entity;
            user2 = ctx.Users.Add(user2).Entity;
            user3 = ctx.Users.Add(user3).Entity;
            user4 = ctx.Users.Add(user4).Entity;
            user5 = ctx.Users.Add(user5).Entity;
            user6 = ctx.Users.Add(user6).Entity;


            ctx.Tournaments.Add(tour1);

            ctx.Rounds.Add(round1);
            ctx.Rounds.Add(round2);
            ctx.Rounds.Add(round3);
            ctx.Rounds.Add(round4);

            


            ctx.SaveChanges();
            

        }
    }
}
