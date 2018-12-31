using BoardTrade.Data;
using BoardTrade.Data.Interfaces;
using BoardTrade.Data.Models;
using BoardTrade.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BoardTrade.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BoardTradeDbContext _ctx;
        private readonly SignInManager<User> _signInMgr;
        private readonly IUser _usr;

        public AuthController(BoardTradeDbContext ctx, SignInManager<User> signInMgr, IUser usr)
        {
            _ctx = ctx;
            _signInMgr = signInMgr;
            _usr = usr;
        }

        [AllowAnonymous]
        [HttpPost("api/auth/login")]
        public async Task<IActionResult> Login([FromBody] CredentialDto credentials)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(await _usr.Login(credentials.UserName, credentials.Password));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("api/auth/register")]
        public async Task<IActionResult> Register([FromBody] RegisterCredentialDto credentials)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _usr.Register(credentials.UserName, credentials.Email, credentials.Password, credentials.PasswordConfirm));   
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("api/auth/logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _usr.Logout();
                return Ok($"Logged out user {this.User.Identity.Name}");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}