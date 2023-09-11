using Api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Data
{
    public class LinesDbContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
        public LinesDbContext(DbContextOptions<LinesDbContext> options)
            : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Repost> Reposts { get; set; }
        
        public DbSet<Follower> Followers { get; set; }

        public DbSet<Hashtag> Hashtags { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(LinesDbContext).Assembly);
        }
    }
}
