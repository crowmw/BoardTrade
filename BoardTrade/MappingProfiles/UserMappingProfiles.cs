using AutoMapper;
using BoardTrade.Data.Models;
using BoardTrade.Dtos;

namespace BoardTrade.Mapping
{
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<UserDto, User>()
                .ReverseMap();
 
        }
    }
}
