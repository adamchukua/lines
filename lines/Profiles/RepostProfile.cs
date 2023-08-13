using AutoMapper;
using Lines.DTOs;
using Lines.Entities;

namespace Lines.Profiles
{
    public class RepostProfile : Profile
    {
        public RepostProfile()
        {
            CreateMap<RepostBasicInfoDTO, Repost>().ReverseMap();
        }
    }
}
