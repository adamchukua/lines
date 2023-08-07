using Microsoft.AspNetCore.Identity;

namespace lines.Entities
{
    public class User : IdentityUser<long>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Avatar { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Repost> Reposts { get; set; }
        public IEnumerable<Follower> Followers { get; set; }
        public IEnumerable<Follower> Following { get; set; }
        public IEnumerable<Like> Likes { get; set; }
        public IEnumerable<Notification> Notifications { get; set; }
    }
}
