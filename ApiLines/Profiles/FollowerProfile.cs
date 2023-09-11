using AutoMapper;
using Api.DTOs;
using Api.Entities;

namespace Api.Profiles
{
    public class FollowerProfile : Profile
    {
        public FollowerProfile()
        {
            CreateMap<FollowerBasicInfoDTO, Follower>().ReverseMap();
        }
    }
}
