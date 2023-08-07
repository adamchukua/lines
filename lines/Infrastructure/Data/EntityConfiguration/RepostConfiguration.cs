using lines.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lines.Infrastructure.Data.EntityConfiguration
{
    public class RepostConfiguration : IEntityTypeConfiguration<Repost>
    {
        public void Configure(EntityTypeBuilder<Repost> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(r => r.User)
                .WithMany(u => u.Reposts)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Post)
                .WithMany(p => p.Reposts)
                .HasForeignKey(r => r.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
