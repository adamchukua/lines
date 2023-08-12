using AutoMapper;
using Lines.DTOs;
using Lines.Entities;

namespace Lines.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserBasicInfoDTO, User>().ReverseMap();
        }
    }
}
