using AutoMapper;
using Lines.DTOs;
using Lines.Entities;

namespace Lines.Profiles
{
    public class LikeProfile : Profile
    {
        public LikeProfile()
        {
            CreateMap<LikeBasicInfoDTO, Like>().ReverseMap();
        }
    }
}
