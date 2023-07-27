namespace lines.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string? Description { get; set; }
        public string? Avatar { get; set; }
    }
}
