using BeerOverflow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerOverflow.Database.DataConfigurations
{
    public class DrankListConfig : IEntityTypeConfiguration<DrankList>
    {
        public void Configure(EntityTypeBuilder<DrankList> builder)
        {
            builder.HasKey(dl => dl.Id);

            builder.HasOne(dl => dl.Beer)
                .WithMany(dl => dl.DrankList)
                .HasForeignKey(dl => dl.BeerId);

            builder.HasOne(dl => dl.User)
                .WithMany(dl => dl.DrankList)
                .HasForeignKey(dl => dl.UserId);
        }
    }
}
