using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;
using BetzerLiga.Core.ApplicationService;
using BetzerLiga.Core.ApplicationService.Implementation;
using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;
using BetzerLiga.Infrastructure.SQL;
using BetzerLiga.Infrastructure.SQL.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Sdk;

namespace ServiceTest
{
    public class RoundServiceTest
    {


        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        private void TestExceptionThrownWhenRoundNumberIsLessThanOne(int roundNumber)
        {
            IRoundService roundService = new RoundService();
            var round = new Round
            {
                RoundNumber = roundNumber
            };
            Assert.Throws<InvalidDataException>(() => _roundService.Create(round));
            
        }
    }
}
