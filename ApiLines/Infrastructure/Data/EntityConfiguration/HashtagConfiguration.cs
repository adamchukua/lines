﻿using Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Data.EntityConfiguration
{
    public class HashtagConfiguration : IEntityTypeConfiguration<Hashtag>
    {
        public void Configure(EntityTypeBuilder<Hashtag> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Tag).HasMaxLength(50).IsRequired();
        }
    }
}
