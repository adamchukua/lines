using Lines.Entities;

namespace Lines.DTOs
{
    public class RepostBasicInfoDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long PostId { get; set; }

        public UserBasicInfoDTO User { get; set; }
        public PostBasicInfoDTO Post { get; set; }
    }
}
