using BoardTrade.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardTrade.Data
{
    public class BoardTradeDbInitializer
    {
        private readonly BoardTradeDbContext _ctx;

        public BoardTradeDbInitializer(BoardTradeDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Seed()
        {
            if(!_ctx.BoardGames.Any())
            {
                _ctx.AddRange(_sampleBoardGames);
                await _ctx.SaveChangesAsync();
            }
        }

        List<BoardGame> _sampleBoardGames = new List<BoardGame>
        {
            new BoardGame()
            {
                Id =Guid.NewGuid(),
                Slug = "agricola",
                Name = "Agricola",
                OriginalName = "Agricola",
                Description = "Game about building a farm",
                ImageUrl = "https://cf.geekdo-images.com/itemrep/img/MkVLwT3DDgaauwZzLMpgrC7uaX8=/fit-in/246x300/pic259085.jpg",
                ThumbnailUrl = "https://cf.geekdo-images.com/itemrep/img/MkVLwT3DDgaauwZzLMpgrC7uaX8=/fit-in/246x300/pic259085.jpg",
                MinPlayers = 2,
                MaxPlayers = 4,
                PlayingTime = 100,
                IsExpansion = false,
                YearPublished = 2007,
                Rating = 8.0F,
                AverageRating = 8.0F,
                Rank = 22,
                TimeOfCreation = DateTime.Now,
                TimeOfModification = DateTime.Now
            },
            new BoardGame()
            {
                Id =Guid.NewGuid(),
                Slug = "pandemic",
                Name = "Pandemia",
                OriginalName = "Pandemic",
                Description = "Game about fighting agains pandemia on map",
                ImageUrl = "https://cf.geekdo-images.com/itemrep/img/cTrAWasNHyKMcNs8Zrv5O7sKS6M=/fit-in/246x300/pic1534148.jpg",
                ThumbnailUrl = "https://cf.geekdo-images.com/itemrep/img/cTrAWasNHyKMcNs8Zrv5O7sKS6M=/fit-in/246x300/pic1534148.jpg",
                MinPlayers = 2,
                MaxPlayers = 4,
                PlayingTime = 45,
                IsExpansion = false,
                YearPublished = 2008,
                Rating = 7.6F,
                AverageRating = 7.6F,
                Rank = 75,
                TimeOfCreation = DateTime.Now,
                TimeOfModification = DateTime.Now
            },
            new BoardGame()
            {
                Id =Guid.NewGuid(),
                Slug = "7_wonders",
                Name = "7 Cudów Świata",
                OriginalName = "7 Wonders",
                Description = "Game about building an Wonders",
                ImageUrl = "https://cf.geekdo-images.com/itemrep/img/fR5_q-7pMDmhLP8SPLOwPcUeLVo=/fit-in/246x300/pic860217.jpg",
                ThumbnailUrl = "https://cf.geekdo-images.com/itemrep/img/fR5_q-7pMDmhLP8SPLOwPcUeLVo=/fit-in/246x300/pic860217.jpg",
                MinPlayers = 2,
                MaxPlayers = 7,
                PlayingTime = 30,
                IsExpansion = false,
                YearPublished = 2010,
                Rating = 7.8F,
                AverageRating = 7.8F,
                Rank = 44,
                TimeOfCreation = DateTime.Now,
                TimeOfModification = DateTime.Now
            }
        };
    }
}
