using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                throw new InvalidDataException("A round cannot be created with a round number less than 1");
            }
            else if (round.TotalGoals < 0)
            {
                throw new InvalidDataException("A round cannot be created with total goals less than 0 ");
            }
            return round;
        }

        public Round ValidateCurrentRound(List<Round> roundList)
        {
            int currentRound = 0;
            List<Round> listSorted = new List<Round>();
            foreach (var round in roundList)
            {
                if (!round.Tournament.isDone)
                {
                    listSorted.Add(round);
                }
            }

            foreach (var round in listSorted)
            {
                if (round.RoundNumber > currentRound)
                {
                    currentRound = round.RoundNumber;
                }
            }

            return listSorted.FirstOrDefault(r => r.RoundNumber == currentRound);

        }
    }
}
