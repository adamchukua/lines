using AutoMapper;
using Lines.DTOs;
using Lines.Entities;

namespace Lines.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostBasicInfoDTO>()
                .ForMember(dest => dest.RepostsCount, opt => opt.MapFrom(src => src.Reposts.Count()))
                .ForMember(dest => dest.LikesCount, opt => opt.MapFrom(src => src.Likes.Count()))
                .ForMember(dest => dest.RepliesCount, opt => opt.MapFrom(src => src.Replies.Count()))
                .ReverseMap();
        }
    }
}
