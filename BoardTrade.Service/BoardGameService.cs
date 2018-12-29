using BoardTrade.Data;
using BoardTrade.Data.Interfaces;
using BoardTrade.Data.Models;
using System;
using System.Collections.Generic;

namespace BoardTrade.Service
{
    public class BoardGameService : IBoardGame
    {
        private readonly BoardTradeDbContext _ctx;

        public BoardGameService(BoardTradeDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<BoardGame> GetAll()
        {
            return _ctx.BoardGames;
        }

        public BoardGame GetById(Guid id)
        {
            return _ctx.BoardGames.Find(id);
        }
    }
} 
