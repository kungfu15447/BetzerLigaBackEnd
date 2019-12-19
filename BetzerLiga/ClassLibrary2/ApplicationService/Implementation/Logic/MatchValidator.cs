using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BetzerLiga.Core.ApplicationService.Implementation.Logic
{
    public class MatchValidator
    {
        public Match ValidateMatch(Match match)
        {
            if (String.IsNullOrEmpty(match.HomeTeam) || String.IsNullOrEmpty(match.GuestTeam))
            {
                throw new InvalidDataException("The home and guest team on a match cannot be empty");
            }
            if (match.HomeScore < 0 || match.GuestScore < 0)
            {
                throw new InvalidDataException("Home and Guest score cannot be lower than zero");
            }
            if (CheckIfTeamAndGuestContainsNumbers(match))
            {
                throw new InvalidDataException("The teams on match cannot contain numbers");
            }
            return match;
        }

        public void ValidateMatchStartDate(Match match)
        {
            if (DateTime.Compare(match.StartDate, DateTime.Now) == -1)
            {
                throw new InvalidDataException("Start date on match cannot be before today");
            }
        }

        private bool CheckIfTeamAndGuestContainsNumbers(Match match)
        {
            string bothTeams = match.HomeTeam + " " + match.GuestTeam;
            bool isNumber = false;
            foreach (Char cha in bothTeams.ToCharArray(0, bothTeams.Length))
            {
                if (char.IsDigit(cha))
                {
                    isNumber = true;
                }
            }
            return isNumber;
        }

        public void CheckIfMatchIsNull(Match match)
        {
            if (match == null)
            {
                throw new InvalidDataException("Match must be something");
            }
        }

        public void CheckIfIdIsValid(Match match)
        {
            if (match.Id <= 0)
            {
                throw new InvalidDataException("Id is not valid!");
            }
        }
    }
}
