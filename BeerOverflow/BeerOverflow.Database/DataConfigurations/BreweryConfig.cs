using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BeerOverflow.Models;

namespace BeerOverflow.Database.DataConfigurations
{
    internal class BreweryConfig : IEntityTypeConfiguration<Brewery>
    {
        public void Configure(EntityTypeBuilder<Brewery> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasIndex(br => br.Name)
                   .IsUnique(true);

            builder.Property(b => b.Name)
                   .HasMaxLength(40)
                   .IsRequired(true);

            builder.HasOne(b => b.Country)
                   .WithMany(c => c.Breweries)
                   .HasForeignKey(c => c.CountryId);
        }
    }
}
