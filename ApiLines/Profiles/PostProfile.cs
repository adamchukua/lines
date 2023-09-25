using AutoMapper;
using Api.DTOs;
using Api.Entities;

namespace Api.Profiles
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

            CreateMap<Post, AddPostDTO>().ReverseMap();
        }
    }
}
