using BetzerLiga.Core.ApplicationService.Implementation.Logic;
using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ServiceTest
{
    public class PointCalculatorTest
    {
        [Theory]
        [InlineData(3, 1)]
        [InlineData(5, 1)]
        [InlineData(6, 2)]
        [InlineData(8, 2)]
        [InlineData(10, 2)]
        [InlineData(11, 3)]
        [InlineData(12, 3)]
        [InlineData(14, 3)]
        public void TestRoundTierGetsCalculatedCorrectly(int roundNumber, int result)
        {
            Tournament tour = new Tournament()
            {
                Id = 1,
                Name = "Tournament",
                NumberOfRounds = 14,
                isDone = false,
                Rounds = new List<Round>(),
                Participants = new List<UserTour>()
            };
            Round round = new Round()
            {
                Id = 1,
                RoundNumber = roundNumber,
                TournamentId = 1,
                Tournament = tour,
                TotalGoals = 0,
                Matches = new List<Match>()
            };
            PointCalculator pointCalc = new PointCalculator();
            int roundTier = pointCalc.CalculateRoundTier(round);

            Assert.True(roundTier == result);
        }

        [Fact]
        public void TestCalculateRoundForUserCalculatesCorrectPoints()
        {
            User user1 = new User()
            {
                Id = 1,
                Firstname = "Karl",
                Lastname = "Bielsen",
                IsAdmin = false,
                Email = "test@gmail.com",
                Tips = new List<UserMatch>(),
                Tournaments = new List<UserTour>(),
                RoundPoints = new List<UserRound>()
            };
            Tournament tour = new Tournament()
            {
                Id = 1,
                Name = "Tournament",
                NumberOfRounds = 14,
                isDone = false,
                Rounds = new List<Round>(),
                Participants = new List<UserTour>()
            };
            Round round = new Round()
            {
                Id = 1,
                RoundNumber = 1,
                TournamentId = 1,
                Tournament = tour,
                TotalGoals = 0,
                Matches = new List<Match>(),
                RoundPoints = new List<UserRound>()

            };
            Match match1 = new Match()
            {
                Id = 1,
                HomeTeam = "Home",
                HomeScore = 3,
                GuestTeam = "Guest",
                GuestScore = 1,
                StartDate = new DateTime(2019, 11, 27),
                Round = round,
                RoundId = 1,
                Tips = new List<UserMatch>()
            };
            Match match2 = new Match()
            {
                Id = 2,
                HomeTeam = "Home",
                HomeScore = 1,
                GuestTeam = "Guest",
                GuestScore = 2,
                StartDate = new DateTime(2019, 11, 27),
                Round = round,
                RoundId = 1,
                Tips = new List<UserMatch>()
            };
            Match match3 = new Match()
            {
                Id = 3,
                HomeTeam = "Home",
                HomeScore = 2,
                GuestTeam = "Guest",
                GuestScore = 2,
                StartDate = new DateTime(2019, 11, 27),
                Round = round,
                RoundId = 1,
                Tips = new List<UserMatch>()
            };
            UserMatch tips1 = new UserMatch()
            {
                Id = 1,
                User = user1,
                UserId = 1,
                Match = match1,
                MatchId = 1,
                HomeTip = 3,
                GuestTip = 1,
                Rating = 1
            };
            UserMatch tips2 = new UserMatch()
            {
                Id = 2,
                User = user1,
                UserId = 1,
                Match = match2,
                MatchId = 2,
                HomeTip = 2,
                GuestTip = 1,
                Rating = 2
            };
            UserMatch tips3 = new UserMatch()
            {
                Id = 2,
                User = user1,
                UserId = 1,
                Match = match3,
                MatchId = 3,
                HomeTip = 3,
                GuestTip = 3,
                Rating = 3
            };
            UserTour ustour = new UserTour()
            {
                Id = 1,
                Tournament = tour,
                TournamentId = 1,
                User = user1,
                UserId = 1,
                TotalUserPoints = 0
            };
            UserRound usRound = new UserRound()
            {
                Id = 1,
                Round = round,
                RoundId = 1,
                User = user1,
                UserId = 1,
                UserPoints = 0
            };
            tour.Rounds.Add(round);
            tour.Participants.Add(ustour);
            round.Matches.Add(match1);
            round.Matches.Add(match2);
            round.Matches.Add(match3);
            round.RoundPoints.Add(usRound);
            user1.Tips.Add(tips1);
            user1.Tips.Add(tips2);
            user1.Tips.Add(tips3);
            match1.Tips.Add(tips1);
            match2.Tips.Add(tips2);
            match3.Tips.Add(tips3);
            user1.Tournaments.Add(ustour);
            user1.RoundPoints.Add(usRound);

            int expectedResult = 54;
            PointCalculator pointCalc = new PointCalculator();
            int totalRoundPoints = pointCalc.CalculateRoundForUser(round, user1);

            Assert.True(expectedResult == totalRoundPoints);
        }

        [Fact]
        public void TestCalculateTips()
        {
            User user1 = new User()
            {
                Id = 1,
                Firstname = "Karl",
                Lastname = "Bielsen",
                IsAdmin = false,
                Email = "test@gmail.com",
                Tips = new List<UserMatch>(),
                Tournaments = new List<UserTour>(),
                RoundPoints = new List<UserRound>()
            };
            Match match1 = new Match()
            {
                Id = 1,
                HomeTeam = "Home",
                HomeScore = 3,
                GuestTeam = "Guest",
                GuestScore = 1,
                StartDate = new DateTime(2019, 11, 27),
                RoundId = 1,
                Tips = new List<UserMatch>()
            };
            UserMatch tips1 = new UserMatch()
            {
                Id = 1,
                User = user1,
                UserId = 1,
                Match = match1,
                MatchId = 1,
                HomeTip = 3,
                GuestTip = 1,
                Rating = 1
            };
            user1.Tips.Add(tips1);
            PointCalculator pointCalc = new PointCalculator();
            int expectedResult = 38;
            int actualResult = pointCalc.CalculateTips(tips1, match1);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(1, 12)]
        [InlineData(2, 10)]
        [InlineData(3, 8)]
        [InlineData(0,0)]
        public void TestCalculateRatingBonus(int rating, int points)
        {
            
            PointCalculator pointCalc = new PointCalculator();
            int expectedResult = points;
            int actualResult = pointCalc.CalculateRatingBonus(rating);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(6, 10, 8)]
        [InlineData(6, 12, 10)]
        [InlineData(6, 3, 6)]
        [InlineData(12, 8, 15)]
        [InlineData(12, 11, 19)]
        [InlineData(12, 1, 12)]
        public void TestCalculateBonusTierPoints(int pointsTesting, int roundNumber, int expectedResult)
        {
            PointCalculator pointCalc = new PointCalculator();
            Tournament tour = new Tournament
            {
                Id = 1,
                NumberOfRounds = 14,
                Name = "Testuring",
                isDone = false
            };
            Round round = new Round
            {
                Id = 1,
                RoundNumber = roundNumber,
                TotalGoals = 0,
                Tournament = tour,
                TournamentId = tour.Id
            };
            pointCalc.CalculateRoundTier(round);
            int actualResult = pointCalc.CalculateBonusTierPoints(pointsTesting);
            Assert.Equal(expectedResult, actualResult);
        }
        
        [Theory]
        [InlineData(20, 30)]
        [InlineData(21, 0)]
        public void TestCalculatePointsForTotalGoalsThisRound(int goalsGuessedByUser, int expectedResult)
        {
            Round round = new Round
            {
                Id = 1,
                RoundNumber = 1,
                TotalGoals = 20
            };

            PointCalculator pointCalc = new PointCalculator();
            int actualResult = pointCalc.CalculatePointsForTotalGoalsThisRound(round, goalsGuessedByUser);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
