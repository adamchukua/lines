using Lines.Entities;

namespace Lines.DTOs
{
    public class LikeBasicInfoDTO
    {
        public long Id { get; set; }
        public long PostId { get; set; }
        public long UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public PostBasicInfoDTO Post { get; set; }
        public UserBasicInfoDTO User { get; set; }
    }
}
