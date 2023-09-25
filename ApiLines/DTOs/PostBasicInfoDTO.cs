using System.ComponentModel.DataAnnotations;
using Api.Resources;

namespace Api.DTOs
{
    public class PostBasicInfoDTO
    {
        [Required]
        public long Id { get; set; }
        [Required(ErrorMessageResourceName = "TextRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [MaxLength(300, ErrorMessageResourceName = "MaxLengthPost", ErrorMessageResourceType = typeof(ValidationResources))]
        public string Text { get; set; }
        public PostBasicInfoDTO? ParentPost { get; set; }
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
