﻿namespace lines.Models
{
    public class Like
    {
        public long Id { get; set; }
        public long PostId { get; set; }
        public long UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
