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
            ModelBuilder.Entity<Tournament>()
                .HasMany(t => t.Participants)
                .WithOne(p => p.Tournament)
                .HasForeignKey(p => p.TournamentId);

            ModelBuilder.Entity<User>()
                .HasMany(u => u.Tournaments)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            ModelBuilder.Entity<User>()
                .HasMany(u => u.Tips)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            ModelBuilder.Entity<Match>()
                .HasMany(m => m.Tips)
                .WithOne(t => t.Match)
                .HasForeignKey(t => t.MatchId);

            ModelBuilder.Entity<Match>()
                .HasOne(m => m.Round);

            ModelBuilder.Entity<Round>()
                .HasMany(r => r.Matches)
                .WithOne(m => m.Round);

            

        }

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Round> Rounds { get; set; }
    }
}
