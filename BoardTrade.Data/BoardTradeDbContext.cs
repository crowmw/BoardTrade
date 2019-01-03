using BoardTrade.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BoardTrade.Data
{
    public class BoardTradeDbContext : IdentityDbContext
    {
        public BoardTradeDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserBoardGame> UsersBoardGames { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BoardGame>()
                .HasIndex(bg => bg.Slug)
                .IsUnique();

            base.OnModelCreating(builder);
        }
    }
}
