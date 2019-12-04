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
                IsDone = false,
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

            /*Round round1 = new Round
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
            round4.RoundPoints.Add(userRound4);*/
            Match match1 = new Match()
            {
                HomeTeam = "BIF",
                HomeScore = 3,
                GuestTeam = "FCK",
                GuestScore = 1,
                StartDate = new DateTime(2019, 11, 27),
                Round = round1,
                RoundId = 1,
                Tips = new List<UserMatch>()
            };
            Match match2 = new Match()
            {
                HomeTeam = "OB",
                HomeScore = 1,
                GuestTeam = "FCK",
                GuestScore = 2,
                StartDate = new DateTime(2019, 11, 27),
                Round = round1,
                RoundId = 1,
                Tips = new List<UserMatch>()
            };
            Match match3 = new Match()
            {
                HomeTeam = "FCM",
                HomeScore = 2,
                GuestTeam = "FCK",
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
            /*tour1.Rounds.Add(round2);
            tour1.Rounds.Add(round3);
            tour1.Rounds.Add(round4);*/
            //tour1.Participants.Add(usertour4);
            //tour1.Participants.Add(usertour5);
            //tour1.Participants.Add(usertour6);

            
            round1.Matches.Add(match1);
            round1.Matches.Add(match2);
            round1.Matches.Add(match3);
            tour1.Rounds.Add(round1);
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


            //round1.Matches.Add(match11);
            //round1.Matches.Add(match12);
            //round1.Matches.Add(match13);
            //round1.Matches.Add(match14);
            //round1.Matches.Add(match15);
            //round2.Matches.Add(match21);
            //round2.Matches.Add(match22);
            //round2.Matches.Add(match23);
            //round3.Matches.Add(match31);
            //round3.Matches.Add(match32);
            //round4.Matches.Add(match41);

            ctx.Tournaments.Add(tour1);

            ctx.Rounds.Add(round1);
            //ctx.Rounds.Add(round2);
            //ctx.Rounds.Add(round3);
            //ctx.Rounds.Add(round4);

            //ctx.Matches.Add(match11);
            //ctx.Matches.Add(match12);
            //ctx.Matches.Add(match13);
            //ctx.Matches.Add(match14);
            //ctx.Matches.Add(match15);

            ctx.SaveChanges();
            

        }
    }
}
