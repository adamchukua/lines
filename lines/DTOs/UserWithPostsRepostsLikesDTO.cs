using Lines.Entities;

namespace Lines.DTOs
{
    public class UserWithPostsRepostsLikesDTO
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string? Description { get; set; }
        public string? Avatar { get; set; }
        public IEnumerable<PostBasicInfoDTO> Posts { get; set; }
        public IEnumerable<RepostBasicInfoDTO> Reposts { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
        public IEnumerable<PostBasicInfoDTO> Likes { get; set; }
    }
}
