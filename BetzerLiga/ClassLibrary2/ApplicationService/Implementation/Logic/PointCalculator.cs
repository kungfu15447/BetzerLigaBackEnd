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
        private int _defaultRoundTier = 1;
        private int _defaultPointsForTotalGoals = 30;
        private int _defaultPointsForTotalMatchesCorrect = 3;
        private int _defaultPointsForWinner = 27;
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

            foreach (Round round in tournament.Rounds)
            {
                _defaultRoundTier = CalculateRoundTier(round);
                round.TotalGoals = CalculateTotalGoalsThisRound(round);
                foreach (UserTour user in tournament.Participants)
                {
                    UserRound currentUser = round.RoundPoints.FirstOrDefault(r => r.UserId == user.UserId);
                    if (currentUser != null)
                    {
                        currentUser.UserPoints = CalculateRoundForUser(round, user.User);

                        int totalGoalsGuessedByUser = CalculateTotalGoalsThisRoundByUser(round, user.User);
                        currentUser.UserPoints += CalculatePointsForTotalGoalsThisRound(round, totalGoalsGuessedByUser);
                    }
                    
                }
                round.RoundPoints = round.RoundPoints.OrderByDescending(ur => ur.UserPoints).ToList();
                CalculatePointsForWinnersThisRound(round);
            }

            foreach(UserTour user in tournament.Participants)
            {
                foreach(Round round in tournament.Rounds)
                {
                    user.TotalUserPoints = 0;
                    user.TotalUserPoints += round.RoundPoints.FirstOrDefault(r => r.UserId == user.UserId).UserPoints;
                } 
            }
        }

        public int CalculateRoundForUser(Round round, User user)
        {
            int correctMatchesGuessed = 0;
            int totalRoundPoints = 0;

            foreach (Match match in round.Matches)
            {
                if (DateTime.Compare(match.StartDate, DateTime.Now) <= 0)
                {
                    UserMatch tips = match.Tips.FirstOrDefault(t => t.UserId == user.Id);
                    tips.TotalPoints = CalculateTips(tips, match);
                    if (tips.TotalPoints > CalculateBonusTierPoints(_defaultRightPoints))
                    {
                        correctMatchesGuessed++;
                    }
                    totalRoundPoints += tips.TotalPoints;
                }
            }

            totalRoundPoints += CalculatePointsForTotalMatchesCorrect(correctMatchesGuessed);
            return totalRoundPoints;
        }

        public int CalculateTips(UserMatch tip, Match match)
        {
            int pointsForMatch = 0;
            if ((tip.HomeTip > tip.GuestTip && match.HomeScore > match.GuestScore)
                || (tip.HomeTip < tip.GuestTip && match.HomeScore < match.GuestScore)
                || (tip.HomeTip == tip.GuestTip && match.HomeScore == match.GuestScore))
            {
                pointsForMatch += CalculateBonusTierPoints(_defaultRightWin) + 
                    CalculateBonusTierPoints(CalculateRatingBonus(tip.Rating));
            }
            if (tip.HomeTip == match.HomeScore && tip.GuestTip == match.GuestScore)
            {
                pointsForMatch += CalculateBonusTierPoints(_defaultRightResult);
            }
            if (tip.HomeTip == match.GuestScore && tip.GuestTip == match.HomeScore)
            {
                pointsForMatch += CalculateBonusTierPoints(_defaultRightPoints);
            }

            return pointsForMatch;
        }

        public int CalculateRatingBonus(int rating)
        {
            int degradeRating = 2;
            if (rating == 0)
            {
                return 0;
            }else
            {
                int ratingBonus = _defaultRatingPoint;
                for (int i = rating; i > 1; i--)
                {
                    ratingBonus -= degradeRating;
                }
                return ratingBonus;
            }       
        }

        public int CalculateBonusTierPoints(int points)
        {
            double pointsToBeCalculated = points;
            for (int i = 1; i < _defaultRoundTier; i++)
            {
                pointsToBeCalculated = Math.Ceiling(pointsToBeCalculated *= _multiplier);
            }

            return Convert.ToInt32(pointsToBeCalculated);
        }

        
        public int CalculatePointsForTotalGoalsThisRound(Round round, int goalsGuessedByUser)
        {
            if (round.TotalGoals == goalsGuessedByUser)
            {
                return CalculateBonusTierPoints(_defaultPointsForTotalGoals);
            }else
            {
                return 0;
            }
        }

        public int CalculatePointsForTotalMatchesCorrect(int indexForCorrectMatches)
        {
            int startingPointsApplier = 4;
            int pointsCalculated = 0;
            int startingValue = 5;
            if (indexForCorrectMatches >= startingValue)
            {
                pointsCalculated = _defaultPointsForTotalMatchesCorrect;
                for (int i = startingValue; i < indexForCorrectMatches; i++)
                {
                    pointsCalculated += startingPointsApplier;
                    startingPointsApplier++;
                }
            }
            return CalculateBonusTierPoints(pointsCalculated);
        }

        public void CalculatePointsForWinnersThisRound(Round round)
        {
            int lowestWinnerInLeaderBoard = 6;
            int pointsDegrader = 7;
            int points = _defaultPointsForWinner;

            if (round.RoundPoints.Count <= lowestWinnerInLeaderBoard)
            {
                lowestWinnerInLeaderBoard = round.RoundPoints.Count;
            }

            for (int i = 0; i < lowestWinnerInLeaderBoard; i++)
            {
                round.RoundPoints[i].UserPoints += CalculateBonusTierPoints(points);
                points -= pointsDegrader;
                pointsDegrader--;
            }
        }

        private int CalculateTotalGoalsThisRound(Round round)
        {
            int totalGoals = 0;
            foreach (Match match in round.Matches)
            {
                totalGoals += (match.HomeScore + match.GuestScore);
            }
            return totalGoals;
        }

        private int CalculateTotalGoalsThisRoundByUser(Round round, User user)
        {
            int totalGoals = 0;
            foreach(Match match in round.Matches)
            {
                UserMatch tips = match.Tips.FirstOrDefault(t => t.UserId == user.Id);
                totalGoals += (tips.GuestTip + tips.HomeTip);
            }
            return totalGoals;
        }

        public void SetRoundTier(int roundTier)
        {
            _defaultRoundTier = roundTier;
        }
    }
}
