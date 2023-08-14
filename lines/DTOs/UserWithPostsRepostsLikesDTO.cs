﻿using System.ComponentModel.DataAnnotations;

namespace Lines.DTOs
{
    public class UserWithPostsRepostsLikesDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [MaxLength(200, ErrorMessage = "Max length for profile's descriptions is 200 symbols")]
        public string? Description { get; set; }
        [MaxLength(100)]
        public string? Avatar { get; set; }
        [Required]
        public IReadOnlyList<PostBasicInfoDTO> Posts { get; set; }
        [Required]
        public IReadOnlyList<RepostBasicInfoDTO> Reposts { get; set; }
        [Required]
        public int FollowersCount { get; set; }
        [Required]
        public int FollowingCount { get; set; }
        [Required]
        public IReadOnlyList<PostBasicInfoDTO> Likes { get; set; }
    }
}
