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
                .HasOne(m => m.Round)
                .WithMany(r => r.Matches)
                .HasForeignKey(m => m. RoundId);

            ModelBuilder.Entity<Round>()
                .HasOne(r => r.Tournament)
                .WithMany(t => t.Rounds)
                .HasForeignKey(r => r.TournamentId);

            ModelBuilder.Entity<UserRound>()
                .HasOne<Round>(ur => ur.Round)
                .WithMany(r => r.RoundPoints)
                .HasForeignKey(ur => ur.RoundId);

            ModelBuilder.Entity<UserRound>()
                .HasOne<User>(ur => ur.User)
                .WithMany(u => u.RoundPoints)
                .HasForeignKey(ur => ur.UserId);
        }

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Round> Rounds { get; set; }
    }
}
