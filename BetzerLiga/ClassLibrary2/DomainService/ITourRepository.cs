using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Core.DomainService
{
    public interface ITourRepository
    {
        IEnumerable<Tournament> ReadAll();
        Tournament ReadTourById(int id);
        Tournament CreateTour(Tournament Tour);
        Tournament DeleteTour(Tournament Tour);
        Tournament UpdateTour(Tournament Tour);
    }
}
