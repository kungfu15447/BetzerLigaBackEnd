using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Core.ApplicationService.Implementation.Logic
{
    public class TournamentValidator
    {
        public Tournament GetOnGoingTournament(List<Tournament> tournaments)
        {
            foreach(Tournament tournament in tournaments)
            {
                if (!tournament.IsDone)
                {
                    return tournament;
                }
            }
            return null;
        }
    }
}
