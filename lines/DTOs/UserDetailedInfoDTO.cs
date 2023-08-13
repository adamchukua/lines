using Lines.Entities;

namespace Lines.DTOs
{
    public class UserDetailedInfoDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Avatar { get; set; }
        public IEnumerable<PostBasicInfoDTO> Posts { get; set; }
        public IEnumerable<RepostBasicInfoDTO> Reposts { get; set; }
        public IEnumerable<FollowerBasicInfoDTO> Followers { get; set; }
        public IEnumerable<FollowerBasicInfoDTO> Following { get; set; }
        public IEnumerable<LikeBasicInfoDTO> Likes { get; set; }
        public IEnumerable<NotificationBasicInfoDTO> Notifications { get; set; }
    }
}
