using Lines.Entities;

namespace Lines.DTOs
{
    public class FollowerBasicInfoDTO
    {
        public long Id { get; set; }
        public long FollowerId { get; set; }
        public long FollowingId { get; set; }
        public UserBasicInfoDTO FollowerUser { get; set; }
        public UserBasicInfoDTO FollowingUser { get; set; }
    }
}
