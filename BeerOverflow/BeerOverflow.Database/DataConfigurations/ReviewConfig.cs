﻿using BeerOverflow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerOverflow.Database.DataConfigurations
{
    internal class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Content)
                   .IsRequired(true)
                   .HasMaxLength(255);

            builder
                .HasOne(r => r.Beer)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BeerId);

            builder
                .HasOne(r => r.User)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.UserId);
        }
    }
}
