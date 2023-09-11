using System.ComponentModel.DataAnnotations;
using Api.Entities;

namespace Api.DTOs
{
    public class FollowerBasicInfoDTO
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public long FollowerId { get; set; }
        [Required]
        public long FollowingId { get; set; }
        [Required]
        public UserBasicInfoDTO FollowerUser { get; set; }
        [Required]
        public UserBasicInfoDTO FollowingUser { get; set; }
    }
}
