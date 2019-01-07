using AutoMapper;
using BoardTrade.Data;
using BoardTrade.Data.Interfaces;
using BoardTrade.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BoardTrade.Service
{
    public class UserService : IUser
    {
        private readonly BoardTradeDbContext _ctx;
        private readonly UserManager<User> _usrMgr;
        private readonly SignInManager<User> _signInMgr;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _hasher;
        private readonly IConfigurationRoot _config;

        public UserService(BoardTradeDbContext ctx, UserManager<User> usrMgr, SignInManager<User> signInMgr, IPasswordHasher<User> hasher, IMapper mapper, IConfigurationRoot config)
        {
            _ctx = ctx;
            _usrMgr = usrMgr;
            _signInMgr = signInMgr;
            _mapper = mapper;
            _hasher = hasher;
            _config = config;
        }

        public async Task<User> Login(string userNameOrEmail, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new InvalidOperationException("Password is required");

            if (await _usrMgr.FindByNameAsync(userNameOrEmail) == null)
                throw new InvalidOperationException($"Username {userNameOrEmail} does not exists. Try Register first.");

            var user = await _usrMgr.FindByEmailAsync(userNameOrEmail);

            var signInResult = new SignInResult();
            if(user != null)
            {
                var passwordCheck = await _signInMgr.CheckPasswordSignInAsync(user, password, false);
                if (!passwordCheck.Succeeded)
                    throw new InvalidOperationException("Incorrect password.");

                signInResult = await _signInMgr.PasswordSignInAsync(user.UserName, password, false, false);
            } else
            {
                user = await _usrMgr.FindByNameAsync(userNameOrEmail);
                var passwordCheck = await _signInMgr.CheckPasswordSignInAsync(user, password, false);
                if (!passwordCheck.Succeeded)
                    throw new InvalidOperationException("Incorrect password.");

                signInResult = await _signInMgr.PasswordSignInAsync(userNameOrEmail, password, false, false);
            }

            if (signInResult.Succeeded)
            {
                return user;
            }

            throw new InvalidOperationException("Login failed.");
        }

        public async Task<User> Register(string userName, string email, string password, string passwordConfirm)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new InvalidOperationException("Password is required");

            if (password != passwordConfirm)
                throw new InvalidOperationException("Passwords do not match");

            if (await _usrMgr.FindByNameAsync(userName) != null)
                throw new InvalidOperationException($"Username {userName} is already taken.");

            if (await _usrMgr.FindByEmailAsync(email) != null)
                throw new InvalidOperationException($"Email address {email} is already registered.");

            var user = new User
            {
                UserName = userName,
                Email = email
            };

            var userResult = await _usrMgr.CreateAsync(user, password);
            var roleResult = await _usrMgr.AddToRoleAsync(user, "User");

            if (!userResult.Succeeded || !roleResult.Succeeded)
            {
                throw new InvalidOperationException("Failed to register user");
            }

            user = await _usrMgr.FindByNameAsync(userName);

            return user;
        }

        public async Task Logout()
        {
            await _signInMgr.SignOutAsync();
        }

        public string CreateToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Tokens:Issuer"],
                audience: _config["Tokens:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
