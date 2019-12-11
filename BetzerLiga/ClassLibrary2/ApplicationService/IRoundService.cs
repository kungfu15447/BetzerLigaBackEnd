using System;
using System.Collections.Generic;
using System.Text;
using BetzerLiga.Core.Entity;

namespace BetzerLiga.Core.ApplicationService
{
    public interface IRoundService
    {
        Round Create(Round round);
        Round ReadById(int id);
        List<Round> ReadAll();
        Round Update(Round roundUpdated);
        Round Delete(int id);
        Round GetCurrentRoundFromTournament();
        Round GetMatchesByCurrentRoundAndByUserId(int userId);
    }
}
