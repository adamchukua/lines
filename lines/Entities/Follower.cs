namespace Lines.Entities
{
    public class Follower
    {
        public long Id { get; set; }
        public long FollowerId { get; set; }
        public long FollowingId { get; set; }
        public User FollowerUser { get; set; }
        public User FollowingUser { get; set; }
    }
}
