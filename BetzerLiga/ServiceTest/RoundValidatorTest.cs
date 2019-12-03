using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BetzerLiga.Core.ApplicationService;
using BetzerLiga.Core.ApplicationService.Implementation;
using BetzerLiga.Core.ApplicationService.Implementation.Logic;
using BetzerLiga.Core.Entity;
using Xunit;

namespace ServiceTest
{
    public class RoundValidatorTest
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        private void TestExceptionThrownWhenRoundNumberIsLessThanOne(int roundNumber)
        { 
            RoundValidator rv = new RoundValidator();
            var round = new Round
            {
                RoundNumber = roundNumber
            };
            Assert.Throws<InvalidDataException>(()=> rv.ValidateRound(round));

        }

        [Fact]
        private void TestForLastRoundInListByRoundNumber()
        {
            RoundValidator rv = new RoundValidator();
            var rounds = new List<Round>();
            var round1 = new Round
            {
                RoundNumber = 1,
                TournamentId = 1,
                TotalGoals = 2,
                RoundPoints = new List<UserRound>(),
                Matches = new List<Match>()

            };
            var round2 = new Round
            {
                RoundNumber = 2,
                TournamentId = 1,
                TotalGoals = 2,
                RoundPoints = new List<UserRound>(),
                Matches = new List<Match>()
            };
            var round3 = new Round
            {
                RoundNumber = 3,
                TournamentId = 1,
                TotalGoals = 2,
                RoundPoints = new List<UserRound>(),
                Matches = new List<Match>()
            };
            var round4 = new Round
            {
                RoundNumber = 3,
                TournamentId = 2,
                TotalGoals = 2,
                RoundPoints = new List<UserRound>(),
                Matches = new List<Match>()
            };
            var tour1 = new Tournament
            {
                Id = 1,
                isDone = true
            };
            var tour2 = new Tournament
            {
                Id = 2,
                isDone = false
            };

            round1.Tournament = tour1;
            round2.Tournament = tour1;
            round3.Tournament = tour1;
            round4.Tournament = tour2;

            rounds.Add(round1);
            rounds.Add(round2);
            rounds.Add(round3);
            rounds.Add(round4);

            Assert.Equal(round4, rv.ValidateCurrentRound(rounds));

        }
    }
}
