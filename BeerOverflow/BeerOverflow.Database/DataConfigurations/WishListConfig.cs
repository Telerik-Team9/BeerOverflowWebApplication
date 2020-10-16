using BeerOverflow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerOverflow.Database.DataConfigurations
{
    public class WishListConfig : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name)
                .IsRequired(true);

            builder.HasOne(w => w.Beer)
                .WithMany(w => w.Wishlists)
                .HasForeignKey(w => w.BeerId);

            builder.HasOne(w => w.User)
                .WithMany(w => w.Wishlists)
                .HasForeignKey(w => w.UserId);
        }
    }
}
