﻿using BetzerLiga.Core.Entity;
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
                .HasMany(r => r.Matches)
                .WithOne(m => m.Round);

            ModelBuilder.Entity<Follower>()
               .HasKey(f => new { f.FollowId, f.AuthorizedUserId });

            ModelBuilder.Entity<Follower>()
                .HasOne(pt => pt.Follow)
                .WithMany()
                .HasForeignKey(pt => pt.FollowId)
                .OnDelete(DeleteBehavior.Cascade);

            ModelBuilder.Entity<Follower>()
                .HasOne(pt => pt.AuthorizedUser)
                .WithMany(t => t.Following)
                .HasForeignKey(pt => pt.AuthorizedUserId)
                .OnDelete(DeleteBehavior.Cascade);
            /*
            ModelBuilder.Entity<Follower>()
                .HasKey(f => new {f.FollowId, f.AuthorizedUserId});

            ModelBuilder.Entity<Follower>()
                .HasOne(f => f.AuthorizedUser)
                .WithMany(u => u.Following)
                .HasForeignKey(f => f.AuthorizedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            ModelBuilder.Entity<Follower>()
                .HasOne(f => f.Follow)
                .WithMany(fo => fo.Following)
                .HasForeignKey(f => f.FollowId);
                */
            ModelBuilder.Entity<Round>()
                .HasOne(r => r.Tournament)
                .WithMany(t => t.Rounds)
                .HasForeignKey(r => r.TournamentId);

            ModelBuilder.Entity<Tournament>()
                .HasMany(t => t.Rounds)
                .WithOne(r => r.Tournament);

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
        public DbSet<UserTour> Participants { get; set; }
        public DbSet<UserRound> RoundPoints { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Follower> Following { get; set; }
        public DbSet<UserMatch> UserMatches { get; set; }
    }
}
