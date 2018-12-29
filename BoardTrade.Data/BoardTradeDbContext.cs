using BoardTrade.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardTrade.Data
{
    public class BoardTradeDbContext : DbContext
    {
        public BoardTradeDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<BoardTradeUser> User { get; set; }
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
