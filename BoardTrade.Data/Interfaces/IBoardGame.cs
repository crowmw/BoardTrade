using BoardTrade.Data.Models;
using System;
using System.Collections.Generic;

namespace BoardTrade.Data.Interfaces
{
    public interface IBoardGame
    {
        IEnumerable<BoardGame> GetAll();
        BoardGame GetById(Guid id);
    }
}
