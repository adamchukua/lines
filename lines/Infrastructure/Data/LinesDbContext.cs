using lines.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lines.Infrastructure.Data
{
    public class LinesDbContext : IdentityDbContext
    {
        public LinesDbContext(DbContextOptions<LinesDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Repost> Reposts { get; set; }
        
        public DbSet<Follower> Followers { get; set; }

        public DbSet<Hashtag> Hashtags { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(LinesDbContext).Assembly);
        }
    }
}
