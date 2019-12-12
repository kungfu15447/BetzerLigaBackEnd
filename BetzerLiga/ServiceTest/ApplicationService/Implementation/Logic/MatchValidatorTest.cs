using BetzerLiga.Core.ApplicationService.Implementation.Logic;
using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ServiceTest.ApplicationService.Implementation.Logic
{
    public class MatchValidatorTest
    {
        [Fact]
        public void TestThrowsExceptionIfHomeTeamAndGuestTeamIsEmptyOrNull()
        {
            MatchValidator matchVali = new MatchValidator();

            Match match = new Match()
            {
                GuestTeam = "",
                HomeTeam = ""
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            matchVali.ValidateMatch(match));
            Assert.Equal("The home and guest team on a match cannot be empty", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfHomeTeamIsEmptyOrNull()
        {
            MatchValidator matchVali = new MatchValidator();

            Match match = new Match()
            {
                GuestTeam = "FBC",
                HomeTeam = ""
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            matchVali.ValidateMatch(match));
            Assert.Equal("The home and guest team on a match cannot be empty", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfGuestTeamIsEmptyOrNull()
        {
            MatchValidator matchVali = new MatchValidator();

            Match match = new Match()
            {
                GuestTeam = "",
                HomeTeam = "FBC"
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            matchVali.ValidateMatch(match));
            Assert.Equal("The home and guest team on a match cannot be empty", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfHomeScoreAndGuestScoreIsNegative()
        {
            MatchValidator matchVali = new MatchValidator();

            Match match = new Match()
            {
                GuestTeam = "DBF",
                HomeTeam = "FBC",
                HomeScore = -1,
                GuestScore = -1
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            matchVali.ValidateMatch(match));
            Assert.Equal("Home and Guest score cannot be lower than zero", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfHomeScoreIsNegative()
        {
            MatchValidator matchVali = new MatchValidator();

            Match match = new Match()
            {
                GuestTeam = "DBF",
                HomeTeam = "FBC",
                HomeScore = -1,
                GuestScore = 2
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            matchVali.ValidateMatch(match));
            Assert.Equal("Home and Guest score cannot be lower than zero", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfGuestScoreIsNegative()
        {
            MatchValidator matchVali = new MatchValidator();

            Match match = new Match()
            {
                GuestTeam = "DBF",
                HomeTeam = "FBC",
                HomeScore = 2,
                GuestScore = -1
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            matchVali.ValidateMatch(match));
            Assert.Equal("Home and Guest score cannot be lower than zero", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfMatchStartDateIsBeforeTodayOnCreate()
        {
            MatchValidator matchVali = new MatchValidator();

            Match match = new Match()
            {
                GuestTeam = "DBF",
                HomeTeam = "FBC",
                HomeScore = 2,
                GuestScore = 2,
                StartDate = new DateTime(2019, 11 ,10)
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            matchVali.ValidateMatchStartDate(match));
            Assert.Equal("Start date on match cannot be before today", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfHomeTeamAndGuestTeamContainsNumbers()
        {
            MatchValidator matchVali = new MatchValidator();

            Match match = new Match()
            {
                GuestTeam = "DBF123",
                HomeTeam = "FBC123",
                HomeScore = 2,
                GuestScore = 3,
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            matchVali.ValidateMatch(match));
            Assert.Equal("The teams on match cannot contain numbers", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfHomeTeamContainsNumbers()
        {
            MatchValidator matchVali = new MatchValidator();

            Match match = new Match()
            {
                GuestTeam = "DBF",
                HomeTeam = "FBC22",
                HomeScore = 2,
                GuestScore = 3,
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            matchVali.ValidateMatch(match));
            Assert.Equal("The teams on match cannot contain numbers", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfGuestTeamContainsNumbers()
        {
            MatchValidator matchVali = new MatchValidator();

            Match match = new Match()
            {
                GuestTeam = "DBF33",
                HomeTeam = "FBC",
                HomeScore = 2,
                GuestScore = 3,
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            matchVali.ValidateMatch(match));
            Assert.Equal("The teams on match cannot contain numbers", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfMatchIsNull()
        {
            MatchValidator matchVali = new MatchValidator();

            Match match = null;
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            matchVali.CheckIfMatchIsNull(match));
            Assert.Equal("Match must be something", ex.Message);
        }
    }
}
