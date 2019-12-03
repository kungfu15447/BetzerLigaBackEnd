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
                RoundPoints = new List<UserRound>(),
                Tournaments = new List<UserTour>(),
                Tips = new List<UserMatch>()
            };

            User user2 = new User
            {
                Firstname = "Lars",
                Lastname = "Lars",
                Email = "LarsLarsen@google.dk",
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                IsAdmin = true,
                RoundPoints = new List<UserRound>(),
                Tournaments = new List<UserTour>(),
                Tips = new List<UserMatch>()
            };

            User user3 = new User
            {
                Firstname = "Frederik",
                Lastname = "Frederiksen",
                Email = "FrederikFrederiksen@google.dk",
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                IsAdmin = true,
                RoundPoints = new List<UserRound>(),
                Tournaments = new List<UserTour>(),
                Tips = new List<UserMatch>()
            };

            User user4 = new User
            {
                Firstname = "Ole",
                Lastname = "Olsen",
                Email = "Olsen@Mads.dk",
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                IsAdmin = true,
                RoundPoints = new List<UserRound>(),
                Tournaments = new List<UserTour>(),
                Tips = new List<UserMatch>()
            };

            User user5 = new User
            {
                Firstname = "John",
                Lastname = "Johnsen",
                Email = "JohnJohnsen@google.dk",
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                IsAdmin = true,
                RoundPoints = new List<UserRound>(),
                Tournaments = new List<UserTour>(),
                Tips = new List<UserMatch>()
            };

            User user6 = new User
            {
                Firstname = "Erik",
                Lastname = "Eriksen",
                Email = "ErikEriksen@google.dk",
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                IsAdmin = true,
                RoundPoints = new List<UserRound>(),
                Tournaments = new List<UserTour>(),
                Tips = new List<UserMatch>()
            };
            Tournament tour1 = new Tournament
            {
                Name = "TournaTest",
                NumberOfRounds = 12,
                isDone = false,
                Rounds = new List<Round>(),
                Participants = new List<UserTour>()
            };

            Round round1 = new Round
            {
                RoundNumber = 11,
                Tournament = tour1,
                TotalGoals = 0,
                Matches = new List<Match>(),
                RoundPoints = new List<UserRound>()
            };

            UserRound userRound1 = new UserRound
            {
                User = user1,
                Round = round1,
                UserPoints = 0
            };
            UserRound userRound2 = new UserRound
            {
                User = user2,
                Round = round1,
                UserPoints = 0
            };
            UserRound userRound3 = new UserRound
            {
                User = user3,
                Round = round1,
                UserPoints = 0
            };

            UserTour usertour1 = new UserTour
            {
                User = user1,
                TotalUserPoints = 0
            };
            UserTour usertour2 = new UserTour
            {
                User = user2,
                TotalUserPoints = 0
            };
            UserTour usertour3 = new UserTour
            {
                User = user3,
                TotalUserPoints = 0
            };
            UserTour usertour4 = new UserTour
            {
                User = user4,
                TotalUserPoints = 0
            };
            UserTour usertour5 = new UserTour
            {
                User = user5,
                TotalUserPoints = 0
            };
            UserTour usertour6 = new UserTour
            {
                User = user6,
                TotalUserPoints = 0
            };

            Match match1 = new Match()
            {
                HomeTeam = "Home",
                HomeScore = 3,
                GuestTeam = "Guest",
                GuestScore = 1,
                StartDate = new DateTime(2019, 11, 27),
                Round = round1,
                RoundId = 1,
                Tips = new List<UserMatch>()
            };
            Match match2 = new Match()
            {
                HomeTeam = "Home",
                HomeScore = 1,
                GuestTeam = "Guest",
                GuestScore = 2,
                StartDate = new DateTime(2019, 11, 27),
                Round = round1,
                RoundId = 1,
                Tips = new List<UserMatch>()
            };
            Match match3 = new Match()
            {
                HomeTeam = "Home",
                HomeScore = 2,
                GuestTeam = "Guest",
                GuestScore = 2,
                StartDate = new DateTime(2019, 11, 27),
                Round = round1,
                RoundId = 1,
                Tips = new List<UserMatch>()
            };

            UserMatch tips1 = new UserMatch()
            {
                User = user1,
                Match = match1,
                HomeTip = 3,
                GuestTip = 1,
                Rating = 1
            };
            UserMatch tips2 = new UserMatch()
            {
                User = user1,
                Match = match2,
                MatchId = 2,
                HomeTip = 2,
                GuestTip = 1,
                Rating = 2
            };
            UserMatch tips3 = new UserMatch()
            {
                User = user1,
                Match = match3,
                HomeTip = 3,
                GuestTip = 3,
                Rating = 3
            };
            UserMatch tips4 = new UserMatch()
            {
                User = user2,
                Match = match1,
                HomeTip = 2,
                GuestTip = 3,
                Rating = 1
            };
            UserMatch tips5 = new UserMatch()
            {
                User = user2,
                Match = match2,
                HomeTip = 1,
                GuestTip = 1,
                Rating = 2
            };
            UserMatch tips6 = new UserMatch()
            {
                User = user2,
                Match = match3,
                HomeTip = 2,
                GuestTip = 3,
                Rating = 3
            };
            UserMatch tips7 = new UserMatch()
            {
                User = user3,
                Match = match1,
                HomeTip = 4,
                GuestTip = 5,
                Rating = 1
            };
            UserMatch tips8 = new UserMatch()
            {
                User = user3,
                Match = match2,
                HomeTip = 4,
                GuestTip = 4,
                Rating = 2
            };
            UserMatch tips9 = new UserMatch()
            {
                User = user3,
                Match = match3,
                HomeTip = 5,
                GuestTip = 4,
                Rating = 3
            };
            
            tour1.Participants.Add(usertour1);
            tour1.Participants.Add(usertour2);
            tour1.Participants.Add(usertour3);
            //tour1.Participants.Add(usertour4);
            //tour1.Participants.Add(usertour5);
            //tour1.Participants.Add(usertour6);
            tour1.Rounds.Add(round1);
            round1.Matches.Add(match1);
            round1.Matches.Add(match2);
            round1.Matches.Add(match3);
            round1.RoundPoints.Add(userRound1);
            round1.RoundPoints.Add(userRound2);
            round1.RoundPoints.Add(userRound3);
            match1.Tips.Add(tips1);
            match1.Tips.Add(tips4);
            match1.Tips.Add(tips7);
            match2.Tips.Add(tips2);
            match2.Tips.Add(tips5);
            match2.Tips.Add(tips8);
            match3.Tips.Add(tips3);
            match3.Tips.Add(tips6);
            match3.Tips.Add(tips9);
            ctx.Tournaments.Add(tour1);
            ctx.Rounds.Add(round1);
            ctx.Matches.Add(match1);
            ctx.Matches.Add(match2);
            ctx.Matches.Add(match3);

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
