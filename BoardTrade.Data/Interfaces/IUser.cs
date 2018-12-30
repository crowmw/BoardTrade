using BoardTrade.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoardTrade.Data.Interfaces
{
    public interface IUser
    {
        Task<SignInResult> Login(string userNameOrEmail, string password);
        Task<User> Register(string userName, string email, string password, string passwordConfirm);
    }
}
