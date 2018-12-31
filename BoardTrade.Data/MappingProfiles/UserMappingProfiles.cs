using AutoMapper;
using BoardTrade.Data.Models;

namespace BoardTrade.Contract.MappingProfiles
{
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
