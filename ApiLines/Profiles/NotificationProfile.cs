using AutoMapper;
using Api.DTOs;
using Api.Entities;
    
namespace Api.Profiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<NotificationBasicInfoDTO, Notification>().ReverseMap();
        }
    }
}
