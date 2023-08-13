namespace Lines.DTOs
{
    public class PostBasicInfoDTO
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long? RepliedPostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserBasicInfoDTO User { get; set; }
        public int RepostsCount { get; set; }
        public int LikesCount { get; set; }
        public int RepliesCount { get; set; }
    }
}
