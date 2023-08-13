using AutoMapper;
using Lines.DTOs;
using Lines.Entities;

namespace Lines.Profiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<NotificationBasicInfoDTO, Notification>().ReverseMap();
        }
    }
}
