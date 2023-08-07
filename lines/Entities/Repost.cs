namespace lines.Entities
{
    public class Repost
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long PostId { get; set; }

        public User User { get; set; }
        public Post Post { get; set; }
    }
}
