using BetzerLiga.Core.ApplicationService.Implementation.Logic;
using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ServiceTest
{
    public class TournamentValidatorTest
    {
        [Fact]
        public void TestGetOngionTournament()
        {
            List<Tournament> tournaments = new List<Tournament>();
            Tournament tour1 = new Tournament
            {
                Id = 1,
                Name = "Tournament1",
                IsDone = true
            };
            Tournament tour2 = new Tournament
            {
                Id = 2,
                Name = "Tournament1",
                IsDone = true
            };
            Tournament tour3 = new Tournament
            {
                Id = 3,
                Name = "Tournament1",
                IsDone = true
            };
            Tournament tour4 = new Tournament
            {
                Id = 4,
                Name = "Tournament1",
                IsDone = false
            };
            tournaments.Add(tour1);
            tournaments.Add(tour2);
            tournaments.Add(tour3);
            tournaments.Add(tour4);
            TournamentValidator tourVali = new TournamentValidator();
            Tournament tournament = tourVali.GetOnGoingTournament(tournaments);
            Assert.False(tournament.IsDone);
        }
    }
}
