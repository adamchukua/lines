using System.ComponentModel.DataAnnotations;

namespace Lines.DTOs
{
    public class PostBasicInfoDTO
    {
        [Required]
        public long Id { get; set; }
        [Required(ErrorMessage = "Text is required")]
        [MaxLength(300, ErrorMessage = "Max length for post's text is 300 symbols")]
        public string Text { get; set; }
        public long? RepliedPostId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public UserBasicInfoDTO User { get; set; }
        [Required]
        public int RepostsCount { get; set; }
        [Required]
        public int LikesCount { get; set; }
        [Required]
        public int RepliesCount { get; set; }
    }
}
