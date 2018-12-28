using BoardTrade.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BoardTrade.Data
{
    public class BoardTradeDbContext : DbContext
    {
        public BoardTradeDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<UserBoardGame> UsersBoardGames { get; set; }
    }
}
