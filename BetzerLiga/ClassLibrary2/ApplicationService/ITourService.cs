using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Core.ApplicationService
{
    public interface ITourService
    {
        List<Tournament> GetAllTour();
        Tournament GetTourById(int id);
        Tournament CreateTournament(Tournament Tour);
        Tournament DeleteTournament(Tournament Tour);
        Tournament UpdateTournament(Tournament Tour);
        Tournament GetCurrentOnGoingTournament();
    }
}
