using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BetzerLiga.Core.Entity;

namespace BetzerLiga.Core.ApplicationService.Implementation.Logic
{
    public class RoundValidator
    {
        public Round ValidateRound(Round round)
        {
            if (round.RoundNumber < 1)
            {
                throw new InvalidDataException("bla bla");
            }
            else if (round.TotalGoals > 0)
            {
                throw new InvalidDataException("bla bla bla ");
            }
            return round;
        }
    }
}
