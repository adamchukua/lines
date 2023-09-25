using AutoMapper;
using Api.DTOs;
using Api.Entities;

namespace Api.Profiles
{
    public class LikeProfile : Profile
    {
        public LikeProfile()
        {
            CreateMap<LikeBasicInfoDTO, Like>().ReverseMap();
            CreateMap<AddLikeDTO, Like>().ReverseMap();
            CreateMap<DeleteLikeDTO, Like>().ReverseMap();
        }
    }
}
