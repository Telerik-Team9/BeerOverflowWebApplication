using BeerOverflow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Database.DataConfigurations
{
    public class RatingConfig : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.RatingGiven)
                .IsRequired(true);

            builder.HasOne(r => r.Beer)
                .WithMany(r => r.Ratings)
                .HasForeignKey(r => r.BeerId);

            builder.HasOne(r => r.User)
                .WithMany(r => r.Ratings)
                .HasForeignKey(r => r.UserId);
        }
    }
}
