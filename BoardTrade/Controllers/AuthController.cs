using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardTrade.Data;
using BoardTrade.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardTrade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BoardTradeDbContext _ctx;
        private readonly SignInManager<BoardTradeUser> _signInMgr;

        public AuthController(BoardTradeDbContext ctx, SignInManager<BoardTradeUser> signInMgr)
        {
            _ctx = ctx;
            _signInMgr = signInMgr;
        }


    }
}