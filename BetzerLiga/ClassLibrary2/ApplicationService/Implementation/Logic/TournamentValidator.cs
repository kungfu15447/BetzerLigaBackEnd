using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BetzerLiga.Core.ApplicationService.Implementation.Logic
{
    public class TournamentValidator
    {
        public Tournament ValidateTournament(Tournament tour)
        {
            if (String.IsNullOrEmpty(tour.Name))
            {
                throw new InvalidDataException("Tournament cannot have an empty name");
            }
            if (tour.NumberOfRounds <= 0)
            {
                throw new InvalidDataException("Number of rounds on tournament cannot be negative or zero");
            }
            if (DateTime.Compare(tour.EndDate, tour.StartDate) == -1)
            {
                throw new InvalidDataException("End date cant be before startdate");
            }
            return tour;
        }

        public void CheckIfTournamentIsNull(Tournament tour)
        {
            if (tour == null)
            {
                throw new InvalidDataException("Tournament cant be nothing");
            }
        }

        public void CheckIfIdIsValid(Tournament tour)
        {
            if (tour.Id <= 0)
            {
                throw new InvalidDataException("Id not valid!");
            }
        }

        public void ValidateDatesIsNotBeforeTodayOnCreatedTournament(Tournament tour)
        {
            if (DateTime.Compare(tour.EndDate, DateTime.Now) == -1
                || DateTime.Compare(tour.StartDate, DateTime.Now) == -1)
            {
                throw new InvalidDataException("End date or start date cannot be before today");
            }
        }
    }
}
