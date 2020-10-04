using Microsoft.EntityFrameworkCore;
using BeerOverflow.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerOverflow.Database.DataConfigurations
{
    internal class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .HasOne(r => r.Beer)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BeerId);
        }
    }
}
