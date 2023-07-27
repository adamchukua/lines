namespace lines.Models
{
    public class Follower
    {
        public long Id { get; set; }
        public long FollowerId { get; set; }
        public long FollowerUserId { get; set; }
    }
}
