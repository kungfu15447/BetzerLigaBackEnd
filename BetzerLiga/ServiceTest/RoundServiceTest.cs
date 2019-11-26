using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;
using BetzerLiga.Core.ApplicationService;
using BetzerLiga.Core.Entity;
using Xunit;
using Xunit.Sdk;

namespace ServiceTest
{
    public class RoundServiceTest
    {
        private IRoundService _roundService;

        public RoundServiceTest(IRoundService roundService)
        {
            _roundService = roundService;
        }

        [Fact]
        private void TestExceptionThrownOnCreateWhenNotEnoughInfo()
        {
            var round = new Round
            {
                RoundNumber = 1,
                TotalGoals = 24,
                Matches = new List<Match>()
            };
            var ex = Assert.Throws<InvalidDataException>(() => _roundService.Create(round));
            var expectedException = "You have not put in all of the info, please do this";

            Assert.Equal(expectedException, ex.Message);
        }
    }
}
