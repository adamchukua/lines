using Lines.Entities;

namespace Lines.DTOs
{
    public class NotificationBasicInfoDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserBasicInfoDTO User { get; set; }
    }
}
