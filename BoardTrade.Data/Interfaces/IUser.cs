using BoardTrade.Data.Models;
using System.Threading.Tasks;

namespace BoardTrade.Data.Interfaces
{
    public interface IUser
    {
        Task<User> Login(string userNameOrEmail, string password);
        Task<User> Register(string userName, string email, string password, string passwordConfirm);
        Task Logout();
    }
}
