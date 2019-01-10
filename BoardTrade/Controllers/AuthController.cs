using AutoMapper;
using BoardTrade.Data;
using BoardTrade.Data.Interfaces;
using BoardTrade.Data.Models;
using BoardTrade.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BoardTrade.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BoardTradeDbContext _ctx;
        private readonly SignInManager<User> _signInMgr;
        private readonly UserManager<User> _usrMgr;
        private readonly IConfigurationRoot _config;
        private readonly ILogger<AuthController> _logger;
        private IPasswordHasher<User> _hasher;
        private IUser _usr;
        private IMapper _mapper;

        public AuthController(BoardTradeDbContext ctx, SignInManager<User> signInMgr, UserManager<User> usrMgr, IPasswordHasher<User> hasher, IUser usr, IMapper mapper, IConfigurationRoot config, ILogger<AuthController> logger)
        {
            _ctx = ctx;
            _signInMgr = signInMgr;
            _usrMgr = usrMgr;
            _hasher = hasher;
            _usr = usr;
            _mapper = mapper;
            _config = config;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("api/auth/login")]
        public async Task<IActionResult> Login([FromBody] LoginCredentialsDto credentials)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await _usr.Login(credentials.UserName, credentials.Password);

                return Ok(_mapper.Map<UserDto>(user));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("api/auth/register")]
        public async Task<IActionResult> Register([FromBody] RegisterCredentialsDto credentials)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await _usr.Register(credentials.UserName, credentials.Email, credentials.Password, credentials.PasswordConfirm);

                var token = _usr.CreateToken(user);

                _logger.LogInformation("Registered new user");

                return Ok(_mapper.Map<User, UserDto>(user, o=>
                {
                    o.AfterMap((src, dest) => dest.Token = token);
                }));
            }
            catch (Exception ex)
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

        [HttpPost("api/auth/token")]
        public async Task<IActionResult> CreateToken([FromBody] LoginCredentialsDto model)
        {
            try
            {
                var user = await _usrMgr.FindByNameAsync(model.UserName);
                if(user != null)
                {
                    if(_hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) == PasswordVerificationResult.Success){
                        var token = _usr.CreateToken(user);

                        if(token != null)
                        {
                            return Ok(new
                            {
                                access_token = token,
                            });
                        }
                    }
                    return BadRequest("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest("Failed to generate token");
        }
    }
}