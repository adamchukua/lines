using AutoMapper;
using Lines.DTOs;
using Lines.Entities;

namespace Lines.Profiles
{
    public class FollowerProfile : Profile
    {
        public FollowerProfile()
        {
            CreateMap<FollowerBasicInfoDTO, Follower>().ReverseMap();
        }
    }
}
