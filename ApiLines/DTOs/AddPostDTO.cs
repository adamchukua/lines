using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    public class AddPostDTO
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        [StringLength(500)]
        public string Text { get; set; }
        public long? RepliedPostId { get; set; }
    }
}