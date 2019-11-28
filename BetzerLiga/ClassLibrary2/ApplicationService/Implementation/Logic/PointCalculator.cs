using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Core.ApplicationService.Implementation.Logic
{
    public class PointCalculator
    {
        private double _multiplier = 1.25;
        public int CalculateRoundTier(Round round)
        {
            int currentRoundTier;
            double amountOfTiers = 3.0;
            double tierDividerDecimal = round.Tournament.NumberOfRounds / amountOfTiers;
            int tierDivider = Convert.ToInt32(Math.Ceiling(tierDividerDecimal));

            if (round.RoundNumber > tierDivider && round.RoundNumber <= tierDivider * 2)
            {
                currentRoundTier = 2;
            }else if(round.RoundNumber > tierDivider * 2)
            {
                currentRoundTier = 3;
            }else
            {
                currentRoundTier = 1;
            }

            return currentRoundTier;
        }

        public void CalculateTournamentPoints(Tournament tournament)
        {
            throw new NotImplementedException();
        }

        



        




    }
}
