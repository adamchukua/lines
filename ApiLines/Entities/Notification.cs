namespace Api.Entities
{
    public class Notification
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
    }
}
