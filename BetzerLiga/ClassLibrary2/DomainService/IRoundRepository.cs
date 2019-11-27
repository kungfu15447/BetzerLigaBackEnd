using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using BetzerLiga.Core.Entity;

namespace BetzerLiga.Core.DomainService
{
    public interface IRoundRepository
    {
        Round Create(Round round);
        Round ReadById(int id);
        List<Round> ReadAll(Round round);
        Round Update(Round roundUpdated);
        Round Delete(int id);
    }
}
