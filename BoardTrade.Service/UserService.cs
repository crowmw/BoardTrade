using BoardTrade.Data;
using BoardTrade.Data.Interfaces;
using BoardTrade.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoardTrade.Service
{
    public class UserService : IUser
    {
        private readonly BoardTradeDbContext _ctx;
        private readonly UserManager<User> _usrMgr;
        private readonly SignInManager<User> _signInMgr;

        public UserService(BoardTradeDbContext ctx, UserManager<User> usrMgr, SignInManager<User> signInMgr)
        {
            _ctx = ctx;
            _usrMgr = usrMgr;
            _signInMgr = signInMgr;
        }

        public async Task<SignInResult> Login(string userNameOrEmail, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new InvalidOperationException("Password is required");

            if (await _usrMgr.FindByNameAsync(userNameOrEmail) == null)
                throw new InvalidOperationException($"Username {userNameOrEmail} does not exists. Try Register first.");

            var user = await _usrMgr.FindByEmailAsync(userNameOrEmail);
            if(user != null)
            {
                var passwordCheck = await _signInMgr.CheckPasswordSignInAsync(user, password, false);
                if (!passwordCheck.Succeeded)
                    throw new InvalidOperationException("Incorrect password.");

                return await _signInMgr.PasswordSignInAsync(user.UserName, password, false, false);
            } else
            {
                user = await _usrMgr.FindByNameAsync(userNameOrEmail);
                var passwordCheck = await _signInMgr.CheckPasswordSignInAsync(user, password, false);
                if (!passwordCheck.Succeeded)
                    throw new InvalidOperationException("Incorrect password.");

                return await _signInMgr.PasswordSignInAsync(userNameOrEmail, password, false, false);
            }
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

            return user;
        }
    }
}
