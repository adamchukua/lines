using Lines.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lines.Infrastructure.Data.EntityConfiguration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.ParentPost)
                .WithMany(p => p.Replies)
                .HasForeignKey(p => p.RepliedPostId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.Text).HasMaxLength(300).IsRequired();
            builder.Property(p => p.CreatedAt).ValueGeneratedOnAdd();
        }
    }
}
