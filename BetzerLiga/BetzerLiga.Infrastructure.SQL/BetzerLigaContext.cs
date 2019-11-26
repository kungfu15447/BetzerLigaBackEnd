using BetzerLiga.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Infrastructure.SQL
{
    public class BetzerLigaContext : DbContext
    {
        public BetzerLigaContext(DbContextOptions opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {

        }

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Round> Rounds { get; set; }
    }
}
