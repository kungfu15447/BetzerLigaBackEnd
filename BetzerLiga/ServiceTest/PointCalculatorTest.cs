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
        [Fact]
        public void TestRoundTierGetsCalculatedCorrectly()
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

            };
            PointCalculator pointCalc = new PointCalculator();


        }
    }
}
