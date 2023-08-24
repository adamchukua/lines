using Lines.Resources;
using System.ComponentModel.DataAnnotations;

namespace Lines.DTOs
{
    public class UserWithPostsDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [MaxLength(200, ErrorMessageResourceName = "MaxLengthDescription", ErrorMessageResourceType = typeof(ValidationResources))]
        public string? Description { get; set; }
        [MaxLength(100)]
        public string? Avatar { get; set; }
        [Required]
        public IReadOnlyList<PostBasicInfoDTO> Posts { get; set; }
        [Required]
        public int FollowersCount { get; set; }
        [Required]
        public int FollowingCount { get; set; }
    }
}
