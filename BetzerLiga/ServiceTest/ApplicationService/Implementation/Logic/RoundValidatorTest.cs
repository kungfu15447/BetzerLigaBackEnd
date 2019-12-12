using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BetzerLiga.Core.ApplicationService;
using BetzerLiga.Core.ApplicationService.Implementation;
using BetzerLiga.Core.ApplicationService.Implementation.Logic;
using BetzerLiga.Core.Entity;
using Xunit;

namespace ServiceTest.ApplicationService.Implementation.Logic
{
    public class RoundValidatorTest
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        public void TestExceptionThrownWhenRoundNumberIsLessThanOne(int roundNumber)
        { 
            RoundValidator rv = new RoundValidator();
            var round = new Round
            {
                RoundNumber = roundNumber
            };
            Assert.Throws<InvalidDataException>(()=> rv.ValidateRound(round));

        }
    }
}
