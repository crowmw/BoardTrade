using System;
using System.Collections.Generic;
using AutoMapper;
using BoardTrade.Data.Interfaces;
using BoardTrade.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoardTrade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        private readonly IBoardGame _boardGameService;

        public BoardGameController(IBoardGame boardGameService, IMapper mapper)
        {
            _boardGameService = boardGameService;
        }

        // GET api/boardgame
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<BoardGame>> Get()
        {
            var boardGames = _boardGameService.GetAll();

            if (boardGames == null) return NotFound($"Not found any board game");

            return Ok(boardGames);
        }

        // GET api/boardgame/5
        [HttpGet("{id}")]
        public ActionResult<BoardGame> Get(Guid id)
        {
            var boardGame = _boardGameService.GetById(id);

            if(boardGame == null) return NotFound($"Board game ${id} was not found.");

            return Ok(boardGame);
        }

        // POST api/boardgame
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        
        // PUT api/boardgame/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/boardgame/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
