using AutoMapper;

namespace BoardTrade.Contract.MappingProfiles
{
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<UserDto, ApplicationUser>();
        }
    }
}
