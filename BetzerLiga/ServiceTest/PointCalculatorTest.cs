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
                Tournament = tour,
                TotalGoals = 0,
                Matches = new List<Match>()
            };
            PointCalculator pointCalc = new PointCalculator();
            int roundTier = pointCalc.CalculateRoundTier(round);

            Assert.True(roundTier == result);
        }
    }
}
