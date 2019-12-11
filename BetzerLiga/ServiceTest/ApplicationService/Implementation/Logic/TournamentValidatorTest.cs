using BetzerLiga.Core.ApplicationService.Implementation.Logic;
using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ServiceTest.ApplicationService.Implementation.Logic
{
    public class TournamentValidatorTest
    {
        [Fact]
        public void TestThrowsExceptionIfTournamentIsNull()
        {
            TournamentValidator tourVali = new TournamentValidator();
            Tournament tour = null;
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            tourVali.CheckIfTournamentIsNull(tour));
            Assert.Equal("Tournament cant be nothing", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfTournamentNameIsEmptyOrNull()
        {
            TournamentValidator tourVali = new TournamentValidator();
            Tournament tour = new Tournament
            {
                Name = ""
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            tourVali.ValidateTournament(tour));
            Assert.Equal("Tournament cannot have an empty name", ex.Message);
        }

        
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-2)]
        public void TestThrowsExceptionIfTournamentNumberOfRoundsIsNegativeOrZero(int numberOfRounds)
        {
            TournamentValidator tourVali = new TournamentValidator();
            Tournament tour = new Tournament
            {
                Name = "TestTournament",
                NumberOfRounds = numberOfRounds
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            tourVali.ValidateTournament(tour));
            Assert.Equal("Number of rounds on tournament cannot be negative or zero", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfTournamentEndDateIsBeforeStartDate()
        {
            TournamentValidator tourVali = new TournamentValidator();
            Tournament tour = new Tournament
            {
                Name = "TestTournament",
                NumberOfRounds = 3,
                EndDate = new DateTime(2019, 12, 10),
                StartDate = new DateTime(2019, 12, 24)
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            tourVali.ValidateTournament(tour));
            Assert.Equal("End date cant be before startdate", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfTournamentEndDateAndStartdateIsBeforeToday()
        {
            TournamentValidator tourVali = new TournamentValidator();
            Tournament tour = new Tournament
            {
                Name = "TestTournament",
                NumberOfRounds = 3,
                EndDate = new DateTime(2019, 10, 25),
                StartDate = new DateTime(2019, 10, 20)
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            tourVali.ValidateDatesIsNotBeforeTodayOnCreatedTournament(tour));
            Assert.Equal("End date or start date cannot be before today", ex.Message);
        }

    }
}


