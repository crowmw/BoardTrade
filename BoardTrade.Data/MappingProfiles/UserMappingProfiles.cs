using AutoMapper;
using BoardTrade.Data.Models;
using BoardTrade.Dtos;

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
