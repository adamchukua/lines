using AutoMapper;
using Api.DTOs;
using Api.Entities;

namespace Api.Profiles
{
    public class RepostProfile : Profile
    {
        public RepostProfile()
        {
            CreateMap<RepostBasicInfoDTO, Repost>().ReverseMap();
        }
    }
}
