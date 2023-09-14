namespace Api.Entities
{
    public class Post
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Text { get; set; }
        public long? RepliedPostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
        public IEnumerable<Repost> Reposts { get; set; }
        public IEnumerable<Like> Likes { get; set; }
        public IEnumerable<Post> Replies { get; set; }
        public Post ParentPost { get; set; }

        public Post()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
