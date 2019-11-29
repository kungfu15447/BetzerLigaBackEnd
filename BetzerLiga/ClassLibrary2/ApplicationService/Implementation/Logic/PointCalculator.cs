using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetzerLiga.Core.ApplicationService.Implementation.Logic
{
    public class PointCalculator
    {
        private double _multiplier = 1.25;
        private int _defaultRightWin = 6;
        private int _defaultRightResult = 20;
        private int _defaultRightPoints = 2;
        private int _defaultRatingPoint = 12;
        private int _defaultRoundTier = 0;
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
            _defaultRoundTier = currentRoundTier;
            return currentRoundTier;
        }

        public void CalculateTournamentPoints(Tournament tournament)
        {
            foreach (UserTour user in tournament.Participants)
            {
                foreach (Round round in tournament.Rounds)
                {

                }
            }
        }

        public int CalculateRoundForUser(Round round, User user)
        {
            int totalRoundPoints = 0;
            foreach (Match match in round.Matches)
            {
                UserMatch tips = match.Tips.FirstOrDefault(t => t.UserId == user.Id);
                tips.TotalPoints = CalculateTips(tips, match);
                totalRoundPoints += tips.TotalPoints;
            }

            return totalRoundPoints;
        }

        public int CalculateTips(UserMatch tip, Match match)
        {
            int pointsForMatch = 0;
            if ((tip.HomeTip > tip.GuestTip && match.HomeScore > match.GuestScore)
                || (tip.HomeTip < tip.GuestTip && match.HomeScore < match.GuestScore)
                || (tip.HomeTip == tip.GuestTip && match.HomeScore == match.GuestScore))
            {
                pointsForMatch += _defaultRightWin + CalculateRatingBonus(tip.Rating);
            }
            if (tip.HomeTip == match.HomeScore && tip.GuestTip == match.GuestScore)
            {
                pointsForMatch += _defaultRightResult;
            }
            if (tip.HomeTip == match.GuestScore && tip.GuestTip == match.HomeScore)
            {
                pointsForMatch += _defaultRightPoints;
            }

            return pointsForMatch;
        }

        public int CalculateRatingBonus(int rating)
        {
            if (rating == 0)
            {
                return 0;
            }else
            {
                int ratingBonus = _defaultRatingPoint;
                for (int i = rating; i > 1; i--)
                {
                    ratingBonus -= 2;
                }
                return ratingBonus;
            }       
        }

        public int CalculateBonusTierPoints(int points)
        {
            throw new NotFiniteNumberException();
        }

        




    }
}
