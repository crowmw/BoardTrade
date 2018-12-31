using BoardTrade.Dtos;
using System.Threading.Tasks;

namespace BoardTrade.Data.Interfaces
{
    public interface IUser
    {
        Task<UserDto> Login(string userNameOrEmail, string password);
        Task<UserDto> Register(string userName, string email, string password, string passwordConfirm);
        Task Logout();
    }
}
