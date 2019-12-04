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

            UserRound userRound11 = new UserRound
            {
                User = user1,
                UserPoints = 24,
            };
            UserRound userRound12 = new UserRound
            {
                User = user1,
                UserPoints = 13,
            };
            UserRound userRound13 = new UserRound
            {
                User = user1,
                UserPoints = 56,
            }; 
            UserRound userRound14 = new UserRound
            {
                User = user1,
                UserPoints = 76,
            };
            UserRound userRound21 = new UserRound()
            {

                User = user2,
                UserPoints =  24
            };
            UserRound userRound22 = new UserRound()
            {

                User = user2,
                UserPoints = 70 
            };
            UserRound userRound23 = new UserRound()
            {

                User = user2,
                UserPoints = 101
            };
            UserRound userRound24 = new UserRound()
            {

                User = user2,
                UserPoints = 9
            };
            UserRound userRound31 = new UserRound()
            {

                User = user3,
                UserPoints = 60
            };
            UserRound userRound32 = new UserRound()
            {

                User = user3,
                UserPoints = 112
            };
            UserRound userRound33 = new UserRound()
            {

                User = user3,
                UserPoints = 110
            };
            UserRound userRound34 = new UserRound()
            {

                User = user3,
                UserPoints = 10
            };
            UserRound userRound41 = new UserRound()
            {

                User = user4,
                UserPoints = 97
            };
            UserRound userRound42 = new UserRound()
            {

                User = user4,
                UserPoints = 65
            };
            UserRound userRound43 = new UserRound()
            {

                User = user4,
                UserPoints = 25
            };
            UserRound userRound44 = new UserRound()
            {

                User = user4,
                UserPoints = 30
            };
        
        Match match11 = new Match()
            {
            HomeTeam = "EFB",
            HomeScore = 0,
            GuestTeam = "BIF",
            GuestScore = 0,
            StartDate = new DateTime(),
            RoundId = 1,
            Tips = new List<UserMatch>()
            };
        Match match12 = new Match()
        {
            HomeTeam = "FCM",
            HomeScore = 0,
            GuestTeam = "FCK",
            GuestScore = 0,
            StartDate = new DateTime(),
            RoundId = 1,
            Tips = new List<UserMatch>()
        };
        Match match13 = new Match()
        {
            HomeTeam = "EFB",
            HomeScore = 0,
            GuestTeam = "FCM",
            GuestScore = 0,
            StartDate = new DateTime(),
            RoundId = 1,
            Tips = new List<UserMatch>()
        };
        Match match14 = new Match()
        {
            HomeTeam = "OB",
            HomeScore = 0,
            GuestTeam = "BIF",
            GuestScore = 0,
            StartDate = new DateTime(),
            RoundId = 1,
            Tips = new List<UserMatch>()
        };
        Match match15 = new Match
        {
            HomeTeam = "FCK",
            HomeScore = 0,
            GuestTeam = "OB",
            GuestScore = 0,
            StartDate = new DateTime(),
            RoundId = 1,
            Tips = new List<UserMatch>()
        };
        Match match21 = new Match
        {
            HomeTeam = "AAB",
            HomeScore = 2,
            GuestTeam = "OB",
            GuestScore = 0,
            StartDate = new DateTime(),
            RoundId = 1,
            Tips = new List<UserMatch>()
        };
        Match match22 = new Match
        {
            HomeTeam = "FCK",
            HomeScore = 0,
            GuestTeam = "AGF",
            GuestScore = 0,
            StartDate = new DateTime(),
            RoundId = 1,
            Tips = new List<UserMatch>()
        };
        Match match23 = new Match
        {
            HomeTeam = "AGF",
            HomeScore = 0,
            GuestTeam = "AAB",
            GuestScore = 0,
            StartDate = new DateTime(),
            RoundId = 1,
            Tips = new List<UserMatch>()
        };
        Match match31 = new Match
        {
            HomeTeam = "ACH",
            HomeScore = 0,
            GuestTeam = "FCK",
            GuestScore = 0,
            StartDate = new DateTime(),
            RoundId = 1,
            Tips = new List<UserMatch>()
        };
        Match match32 = new Match
        {
            HomeTeam = "FCK",
            HomeScore = 0,
            GuestTeam = "EFB",
            GuestScore = 0,
            StartDate = new DateTime(),
            RoundId = 1,
            Tips = new List<UserMatch>()
        };
        Match match41 = new Match
        {
            HomeTeam = "BIF",
            HomeScore = 0,
            GuestTeam = "OB",
            GuestScore = 0,
            StartDate = new DateTime(),
            RoundId = 1,
            Tips = new List<UserMatch>()
        };


            round1.RoundPoints.Add(userRound11);
            round1.RoundPoints.Add(userRound21);
            round1.RoundPoints.Add(userRound31);
            round1.RoundPoints.Add(userRound42);
            round2.RoundPoints.Add(userRound12);
            round2.RoundPoints.Add(userRound22);
            round2.RoundPoints.Add(userRound32);
            round2.RoundPoints.Add(userRound42);
            round3.RoundPoints.Add(userRound13);
            round3.RoundPoints.Add(userRound23);
            round3.RoundPoints.Add(userRound33);
            round3.RoundPoints.Add(userRound43);
            round4.RoundPoints.Add(userRound14);
            round4.RoundPoints.Add(userRound24);
            round4.RoundPoints.Add(userRound34);
            round4.RoundPoints.Add(userRound44);


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

            round1.Matches.Add(match11);
            round1.Matches.Add(match12);
            round1.Matches.Add(match13);
            round1.Matches.Add(match14);
            round1.Matches.Add(match15);
            round2.Matches.Add(match21);
            round2.Matches.Add(match22);
            round2.Matches.Add(match23);
            round3.Matches.Add(match31);
            round3.Matches.Add(match32);
            round4.Matches.Add(match41);

            ctx.Tournaments.Add(tour1);

            ctx.Rounds.Add(round1);
            ctx.Rounds.Add(round2);
            ctx.Rounds.Add(round3);
            ctx.Rounds.Add(round4);

            ctx.Matches.Add(match11);
            ctx.Matches.Add(match12);
            ctx.Matches.Add(match13);
            ctx.Matches.Add(match14);
            ctx.Matches.Add(match15);

            ctx.SaveChanges();
            

        }
    }
}
