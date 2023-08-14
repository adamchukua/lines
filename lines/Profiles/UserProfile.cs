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
            CreateMap<UserWithPostsDTO, User>().ReverseMap();
            CreateMap<PostBasicInfoDTO, Post>().ReverseMap();
            CreateMap<Like, PostBasicInfoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Post.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Post.Text))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Post.User))
                .ForMember(dest => dest.RepliesCount, opt => opt.MapFrom(src => src.Post.Replies.Count()))
                .ForMember(dest => dest.RepostsCount, opt => opt.MapFrom(src => src.Post.Reposts.Count()))
                .ForMember(dest => dest.LikesCount, opt => opt.MapFrom(src => src.Post.Likes.Count()));
        }
    }
}
